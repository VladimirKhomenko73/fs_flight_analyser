using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Microsoft.Win32;
using ACAA.Types;
using Newtonsoft.Json;

namespace ACAA.ViewModels
{
    class OpenFileVM : ViewModelBase
    {
        private string filePath;
        public ICommand GetFilePath { get; private set; }

        public ICommand LoadFile { get; private set; }

        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        public OpenFileVM()
        {
            GetFilePath = new RelayCommand(OpenFile);
            LoadFile = new RelayCommand(LoadDataFromFile);
        }

        private void OpenFile(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                FilePath = openFileDialog.FileName;
        }

        private void LoadDataFromFile(object parameter)
        {
            try
            {
                string json = File.ReadAllText(FilePath);
                List<Package> packageList = JsonConvert.DeserializeObject<List<Package>>(json);

                int i = 0;
                List<Package> newPack = new List<Package>();
                foreach (Package p in packageList)
                {
                    List<Parameter> tempList = p.GetParametersAsList();
                    Dictionary<string, Parameter> tempDictionary = new Dictionary<string, Parameter>();
                    foreach (Parameter par in tempList)
                    {
                        tempDictionary.Add(par.parameterName, par);
                    }
                    newPack.Add(new Package(i, tempDictionary));
                    i++;
                }
                packageList = newPack;

                Workspace.Workspace.Instance.InitializeMatrix(packageList);
            }
            catch (System.ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Newtonsoft.Json.JsonReaderException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.IO.FileLoadException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}