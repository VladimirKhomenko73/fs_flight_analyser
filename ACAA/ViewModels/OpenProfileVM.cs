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
    class OpenProfileVM : ViewModelBase
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

        public OpenProfileVM()
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
                //string json = File.ReadAllText(FilePath);
                //List<object> profileList = JsonConvert.DeserializeObject<List<object>>(json);
                List<object> profileList = new List<object>();

                List<Condition> conditionList1 = new List<Condition>
                {
                    new Condition(0, new Parameter("h", 0), "="),
                };
                List<Condition> conditionList2 = new List<Condition>
                {
                    new Condition(1, new Parameter("h", 0), ">"),
                };
                List<Condition> conditionList3 = new List<Condition>
                {
                    new Condition(2, new Parameter("vy", 0), ">"),
                };
                List<Condition> conditionList4 = new List<Condition>
                {
                    new Condition(3, new Parameter("vy", 0), "<"),
                };
                List<Condition> conditionList5 = new List<Condition>
                {
                    new Condition(4, new Parameter("xt", 0), "<"),
                    new Condition(5, new Parameter("h", 400), "<")
                };
                List<Condition> conditionList6 = new List<Condition>
                {
                    new Condition(6, new Parameter("h", 30), "<"),
                };
                List<Condition> conditionList7 = new List<Condition>
                {
                    new Condition(7, new Parameter("h", 30), "<"),
                };
                List<Condition> conditionList8 = new List<Condition>
                {
                    new Condition(8, new Parameter("h", 30), ">="),
                };
                List<Condition> conditionList9 = new List<Condition>
                {
                    new Condition(9, new Parameter("xt", 0), ">"),
                    new Condition(10, new Parameter("zt", 30), "<"),
                    new Condition(11, new Parameter("zt", -30), ">")
                };
                List<Condition> conditionList10 = new List<Condition>
                {
                    new Condition(12, new Parameter("vp", 0), "="),
                };
                List<Condition> conditionList11 = new List<Condition>
                {
                    new Condition(13, new Parameter("vp", 0), ">"),
                };
                List<Condition> conditionList12 = new List<Condition>
                {
                    new Condition(14, new Parameter("fuec1", 0), ">"),
                    new Condition(15, new Parameter("fuec2", 0), ">")
                };


                List<Event> eventList = new List<Event>
                {
                    new Event(0,"Touchdown",conditionList2, conditionList1),
                    new Event(1,"Decision altitude",conditionList8, conditionList7),
                    new Event(2,"V=0",conditionList11, conditionList10),
                };
                List<State> stateList = new List<State>
                {
                    new State(3,"Climbing", conditionList3),
                    new State(4,"Descending", conditionList3),
                    new State(5, "SubPhase 1", conditionList5),
                    new State(6, "SubPhase 2", conditionList6),
                    new State(7, "SubPhase 3", conditionList9),
                    new State(8, "CEBO On", conditionList12)
                };
                List<MatrixElement> phaseList = new List<MatrixElement>
                {
                    new State(5, "SubPhase 1", conditionList5),
                    new State(6, "SubPhase 1", conditionList5),
                    new State(7, "SubPhase 1", conditionList5),
                    new Event(0,"Touchdown",conditionList2, conditionList1)
                };




                foreach (Event e in eventList)
                {
                    profileList.Add(e);
                }
                foreach (State s in stateList)
                {
                    profileList.Add(s);
                }
                profileList.Add(new Phase(9,"Landing",phaseList));
                Workspace.Workspace.Matrix.AddMatrixElement(profileList);       
                
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
