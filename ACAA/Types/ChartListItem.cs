using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACAA.Types;
using ACAA.Workspace;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace ACAA.Types
{
    class ChartListItem
    {
        private string parameterName;
        private string parameterDescription;
        private MatrixElement element;
        private ObservableDataSource<System.Windows.Point> parameterPoints;
        private ObservableDataSource<System.Windows.Point> elementPoints;

        public string ParameterName
        {
            get
            {
                return parameterName;
            }
            set
            {
                parameterName = value;
                List<Parameter> paramList = Workspace.Workspace.Matrix.GetParameterFromPackages(parameterName);
                List<System.Windows.Point> tempPoints = new List<System.Windows.Point>();

                double i = 0;

                foreach (Parameter param in paramList)
                {
                    tempPoints.Add(new System.Windows.Point(i, param.GetValueAsDouble()));
                    i++;
                }

                ParameterPoints = new ObservableDataSource<System.Windows.Point>(tempPoints);
            }
        }

        public MatrixElement Element
        {
            get
            {
                return element;
            }
            set
            {
                element = value;
                List<System.Windows.Point> tempPoints = new List<System.Windows.Point>();
                int[] tempArray = Workspace.Workspace.Matrix.GetMatrixElementRow(element.ElementId);

                for (int i = 0; i < tempArray.Length; i++)
                {
                    tempPoints.Add(new System.Windows.Point(i, tempArray[i] * 200));
                }

                ElementPoints = new ObservableDataSource<System.Windows.Point>(tempPoints);
            }
        }

        public string ParameterDescription
        {
            get
            {
                return parameterDescription;
            }
            set
            {
                parameterDescription = value;
            }
        }

        public ObservableDataSource<System.Windows.Point> ParameterPoints
        {
            get
            {
                return parameterPoints;
            }
            set
            {
                parameterPoints = value;
            }
        }

        public ObservableDataSource<System.Windows.Point> ElementPoints
        {
            get
            {
                return elementPoints;
            }
            set
            {
                elementPoints = value;
            }
        }

        public ChartListItem(string name, MatrixElement el, string description)
        {
            ParameterName = name;
            Element = el;
            ParameterDescription = String.Concat(name, " (", description, ")");
        }

        public ChartListItem(int phaseId, string name, List<Detection> detectionList)
        {
            int[] phaseRow = Workspace.Workspace.Matrix.GetMatrixElementRow(phaseId);
            List<System.Windows.Point> tempPoints = new List<System.Windows.Point>();

            for (int i = 0; i < phaseRow.Length; i++)
            {
                if (phaseRow[i] == 1)
                {
                    tempPoints.Add(new System.Windows.Point(i, 200));
                }
                else
                {
                    tempPoints.Add(new System.Windows.Point(i, 0));
                }
            }
            ElementPoints = new ObservableDataSource<System.Windows.Point>(tempPoints);

            tempPoints = new List<System.Windows.Point>();

            for (int i = 0; i < phaseRow.Length; i++)
            {
                foreach (Detection d in detectionList)
                {
                    if ((i >= d.StartIndex) && (i <= d.EndIndex))
                    {
                        tempPoints.Add(new System.Windows.Point(i, 100));
                    }
                    else
                    {
                        tempPoints.Add(new System.Windows.Point(i, 0));
                    }
                }
            }
            ParameterPoints = new ObservableDataSource<System.Windows.Point>(tempPoints);
            Phase p = (Phase)Workspace.Workspace.Matrix.GetMatrixElementById(phaseId);
            ParameterDescription = String.Concat(p.ElementName, " (", name, ")");
        }
    }
}
