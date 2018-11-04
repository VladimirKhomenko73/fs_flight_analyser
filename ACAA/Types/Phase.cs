using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAA.Types
{
    class Phase : MatrixElement
    {
        private List<MatrixElement> matrixElements;

        private int startPackageNumber;
        private int endPackageNumber;

        public Phase(int id, string name, List<MatrixElement> elementsList)
        {
            elementId = id;
            elementName = name;
            MatrixElements = elementsList;
            startPackageNumber = -1;
            endPackageNumber = -1;
        }

        public int StartPackageNumber { get => startPackageNumber; set => startPackageNumber = value; }
        public int EndPackageNumber { get => endPackageNumber; set => endPackageNumber = value; }
        public List<MatrixElement> MatrixElements { get => matrixElements; set => matrixElements = value; }
    }
}
