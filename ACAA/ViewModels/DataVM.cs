using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACAA.Types;
using ACAA.Workspace;
using ACAA.Engines;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ACAA.ViewModels
{
    class DataVM : ViewModelBase
    {
        public ICommand showPackage { get; private set; }

        public ICommand eventAnalysis { get; private set; }

        public ICommand stateAnalysis { get; private set; }

        public ICommand phaseAnalysis { get; private set; }

        private string packageParams;

        private MatrixElement selectedElement;

        private List<Parameter> packageParametersList;

        private List<MatrixElement> matrixElementsList;

        private ObservableCollection<ChartListItem> elementParametersChartList;

        public Matrix Matrix
        {
            get
            {
                return Workspace.Workspace.Matrix;
            }
        }

        public DataVM()
        {
            showPackage = new RelayCommand(getPackageParams);
            eventAnalysis = new RelayCommand(runEventEngine);
            stateAnalysis = new RelayCommand(runStateEngine);
            phaseAnalysis = new RelayCommand(runPhaseEngine);

            #region Workspace registration
            Workspace.Workspace.Instance.Register(this);
            #endregion
        }

        public string PackageParams
        {
            get
            {
                return packageParams;
            }
            set
            {
                packageParams = value;
                OnPropertyChanged("PackageParams");
            }
        }

        public List<Parameter> PackageParametersList
        {
            get
            {
                return packageParametersList;
            }
            set
            {
                packageParametersList = value;
                OnPropertyChanged("PackageParametersList");
            }
        }

        public List<MatrixElement> MatrixElementsList
        {
            get
            {
                matrixElementsList = new List<MatrixElement>();
                if (Workspace.Workspace.Matrix != null)
                {
                    foreach (Event e in Workspace.Workspace.Matrix.Events)
                    {
                        matrixElementsList.Add(e);
                    }
                    foreach (State s in Workspace.Workspace.Matrix.States)
                    {
                        matrixElementsList.Add(s);
                    }
                    foreach (Phase p in Workspace.Workspace.Matrix.Phases)
                    {
                        matrixElementsList.Add(p);
                    }
                }
                return matrixElementsList;
            }
            set
            {
                matrixElementsList = value;
                OnPropertyChanged("MatrixElementsList");
            }
        }

        public MatrixElement SelectedElement
        {
            get
            {
                return selectedElement;
            }
            set
            {
                selectedElement = value;
               

                if (value is Event)
                {
                    ObservableCollection<ChartListItem> tempElementParametersChartList = new ObservableCollection<ChartListItem>();

                    List<Condition> allConditions = new List<Condition>();

                    foreach (Condition c in (value as Event).EventPreviousConditions)
                    {
                        tempElementParametersChartList.Add(new ChartListItem(c.startParameterName, value, Workspace.Workspace.Instance.GetParameterDescription(c.startParameterName)));
                    }

                    ElementParametersChartList = tempElementParametersChartList;
                }
                if (value is State)
                {
                    ObservableCollection<ChartListItem> tempElementParametersChartList = new ObservableCollection<ChartListItem>();

                    foreach (Condition c in (value as State).StateConditions)
                    {
                        tempElementParametersChartList.Add(new ChartListItem(c.startParameterName, value, Workspace.Workspace.Instance.GetParameterDescription(c.startParameterName)));
                    }

                    ElementParametersChartList = tempElementParametersChartList;
                }
                if (value is Phase)
                {
                    ObservableCollection<ChartListItem> tempElementParametersChartList = new ObservableCollection<ChartListItem>();

                    tempElementParametersChartList.Add(new ChartListItem("h", value, Workspace.Workspace.Instance.GetParameterDescription("h")));

                    ElementParametersChartList = tempElementParametersChartList;
                }

            }
        }

        public ObservableCollection<ChartListItem> ElementParametersChartList
        {
            get
            {
                return elementParametersChartList;
            }
            set
            {
                elementParametersChartList = value;
                OnPropertyChanged("ElementParametersChartList");
            }
        }

        private void getPackageParams(object parameter)
        {
            int index;
            if (Int32.TryParse(parameter.ToString(), out index) == true)
            {
                PackageParams = Workspace.Workspace.Matrix.Packages[index].GetAllParametersAsString();
                PackageParametersList = Workspace.Workspace.Matrix.Packages[index].GetParametersAsList();
            }
        }

        private void runEventEngine(object parameter)
        {
            if (Matrix != null)
            {
                EventEngine eEngine = new EventEngine(Matrix);
                eEngine.Analyze();
                Workspace.Workspace.Instance.NotifyColleagues<object>("matrix", null);
            }
        }

        private void runStateEngine(object parameter)
        {
            if (Matrix != null)
            {
                StateEngine sEngine = new StateEngine(Matrix);
                sEngine.Analyze();
                Workspace.Workspace.Instance.NotifyColleagues<object>("matrix", null);
            }
        }

        private void runPhaseEngine(object parameter)
        {
            if (Matrix != null)
            {
                PhaseEngine pEngine = new PhaseEngine(Matrix);
                pEngine.Analyze();
                Workspace.Workspace.Instance.NotifyColleagues<object>("matrix", null);
            }
        }

        [WorkspaceMessageSink("matrix")]
        private void matrixUpdate(object updateParameter)
        {
            OnPropertyChanged("Matrix");
            OnPropertyChanged("MatrixElementsList");
        }

    }
}
