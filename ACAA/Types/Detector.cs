using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAA.Types
{
    class Detector : MatrixElement
    {
        private Phase detectingPhase;
        private List<MatrixElement> matrixElements;
        private List<Detection> detections;

        public List<MatrixElement> MatrixElements { get => matrixElements; set => matrixElements = value; }
        public List<Detection> Detections { get => detections; set => detections = value; }
        public Phase DetectingPhase { get => detectingPhase; set => detectingPhase = value; }

        public Detector(int id, string name, Phase phase, List<MatrixElement> elementsList)
        {
            elementId = id;
            elementName = name;
            detectingPhase = phase;
            MatrixElements = elementsList;
            detections = new List<Detection>();
        }


    }
}
