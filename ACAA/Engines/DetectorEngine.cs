using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACAA.Types;

namespace ACAA.Engines
{
    class DetectorEngine
    {
        Matrix matrix;
        Detector detector;

        public DetectorEngine(Matrix m, Detector d)
        {
            matrix = m;
            detector = d;
        }

        public void Analyze()
        {
            Phase detectingPhaseFromMatrix = (Phase)matrix.GetMatrixElementById(detector.DetectingPhase.ElementId);
            if (detectingPhaseFromMatrix.StartPackageNumber > 0)
            {
                foreach (MatrixElement mElement in detector.MatrixElements)
                {
                    if (mElement != null)
                    {
                        Detection detection = new Detection();
                        for (int i = detectingPhaseFromMatrix.StartPackageNumber; i <= detectingPhaseFromMatrix.EndPackageNumber; i++)
                        {

                            if (matrix.GetMatrix[mElement.ElementId, i] == true)
                            {
                                if (detection.StartIndex == -1)
                                {
                                    detection.StartIndex = i;
                                }
                                else
                                {
                                    detection.EndIndex = i;
                                }
                            }
                            else
                            {
                                if (detection.EndIndex != -1)
                                {
                                    detector.Detections.Add(detection);
                                    detection = new Detection();
                                }
                            }
                        }
                        if (detection.EndIndex != -1)
                        {
                            detector.Detections.Add(detection);
                            detection = new Detection();
                        }
                    }
                }
            }        
        }
    }
}
