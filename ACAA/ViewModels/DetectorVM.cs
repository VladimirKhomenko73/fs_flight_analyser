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
    class DetectorVM : ViewModelBase
    {
        private List<MatrixElement> phaseElementsList;
        private List<MatrixElement> stateElementsList;
        private List<MatrixElement> eventElementsList;
        private MatrixElement selectedPhaseElement;
        private MatrixElement selectedStateElement;
        private MatrixElement selectedEventElement;
        private ObservableCollection<ChartListItem> elementParametersChartList;

        public ICommand showDetections { get; private set; }

        public DetectorVM()
        {
            showDetections = new RelayCommand(runDetectorEngine);
            #region Workspace registration
            Workspace.Workspace.Instance.Register(this);
            #endregion
        }

        public List<MatrixElement> PhaseElementsList
        {
            get
            {
                phaseElementsList = new List<MatrixElement>();
                if (Workspace.Workspace.Matrix != null)
                {
                    foreach (Phase p in Workspace.Workspace.Matrix.Phases)
                    {
                        phaseElementsList.Add(p);
                    }
                }
                return phaseElementsList;
            }
            set
            {
                phaseElementsList = value;
                OnPropertyChanged("PhaseElementsList");
            }
        }
        public List<MatrixElement> StateElementsList
        {
            get
            {
                stateElementsList = new List<MatrixElement>();
                if (Workspace.Workspace.Matrix != null)
                {
                    foreach (State s in Workspace.Workspace.Matrix.States)
                    {
                        stateElementsList.Add(s);
                    }
                }
                return stateElementsList;
            }
            set
            {
                stateElementsList = value;
                OnPropertyChanged("StateElementsList");
            }
        }
        public List<MatrixElement> EventElementsList
        {
            get
            {
                eventElementsList = new List<MatrixElement>();
                if (Workspace.Workspace.Matrix != null)
                {
                    foreach (Event e in Workspace.Workspace.Matrix.Events)
                    {
                        eventElementsList.Add(e);
                    }
                }
                return eventElementsList;
            }
            set
            {
                eventElementsList = value;
                OnPropertyChanged("EventElementsList");
            }
        }

        public MatrixElement SelectedPhaseElement
        {
            get
            {
                return selectedPhaseElement;
            }
            set
            {
                selectedPhaseElement = value;
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

        public MatrixElement SelectedStateElement
        {
            get
            {
                return selectedStateElement;
            }
            set
            {
                selectedStateElement = value;
            }
        }
        public MatrixElement SelectedEventElement
        {
            get
            {
                return selectedEventElement;
            }
            set
            {
                selectedEventElement = value;
            }
        }

        private void runDetectorEngine(object parameter)
        {
            if (Workspace.Workspace.Matrix != null)
            {
                Detector detector = new Detector(1, "CEBO", (Phase)Workspace.Workspace.Matrix.GetMatrixElementById(selectedPhaseElement.ElementId), new List<MatrixElement> { SelectedStateElement});
                DetectorEngine dEngine = new DetectorEngine(Workspace.Workspace.Matrix, detector);
                dEngine.Analyze();
                ObservableCollection<ChartListItem> tempElementParametersChartList = new ObservableCollection<ChartListItem>();

                tempElementParametersChartList.Add(new ChartListItem(detector.DetectingPhase.ElementId, detector.ElementName, detector.Detections));
                ElementParametersChartList = tempElementParametersChartList;
            }
        }

        [WorkspaceMessageSink("matrix")]
        private void matrixUpdate(object updateParameter)
        {
            OnPropertyChanged("PhaseElementsList");
            OnPropertyChanged("StateElementsList");
            OnPropertyChanged("EventElementsList");
        }
    }
}
