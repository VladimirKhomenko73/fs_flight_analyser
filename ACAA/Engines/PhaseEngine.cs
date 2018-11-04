using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACAA.Types;
using System.Collections;

namespace ACAA.Engines
{
    class PhaseEngine
    {
        Matrix matrix;

        public PhaseEngine(Matrix m)
        {
            matrix = m;
        }

        public void Analyze()
        {
            foreach (Phase phase in matrix.Phases)
            {
                List<Queue<PhaseElement>> phaseSeqContainer = GetElemets(phase);
                if (phaseSeqContainer != null)
                {
                    Queue<PhaseElement> phaseSequenceStartElements = phaseSeqContainer[0];
                    while (phaseSequenceStartElements.Count != 0)
                    {
                        PhaseElement startCandidate = phaseSequenceStartElements.Dequeue();
                        phase.StartPackageNumber = startCandidate.PhaseElementStartIndex;
                        phase.EndPackageNumber = CheckSequence(phaseSeqContainer, startCandidate, phaseSeqContainer[1]);
                        if (phase.EndPackageNumber != -1)
                        {
                            for (int i = phase.StartPackageNumber; i <= phase.EndPackageNumber; i++)
                            {
                                matrix.Set(phase.ElementId, i, true);
                            }
                        }
                        else
                        {
                            phase.StartPackageNumber = -1;
                        }
                    }
                    
                }
            }
        }

        private int CheckSequence(List<Queue<PhaseElement>> list, PhaseElement sequenceCandidate, Queue<PhaseElement> nextElementQueue)
        {
            Queue<PhaseElement> tempNextElementQueue = new Queue<PhaseElement>(nextElementQueue);
            while (tempNextElementQueue.Count != 0)
            {
                PhaseElement nextSequenceCandidate = tempNextElementQueue.Dequeue();
                if (nextSequenceCandidate.PhaseElementStartIndex > sequenceCandidate.PhaseElementStopIndex)
                {
                    return -1;
                }
                else
                {
                    if ((nextSequenceCandidate.PhaseElementStartIndex >= sequenceCandidate.PhaseElementStartIndex) && (nextSequenceCandidate.PhaseElementStartIndex <= sequenceCandidate.PhaseElementStopIndex))
                    {
                        int currentIndex = list.IndexOf(nextElementQueue);
                        if (currentIndex < list.Count-1)
                        {
                            return CheckSequence(list, nextSequenceCandidate, list[currentIndex + 1]);
                        }
                        else
                        {
                            return nextSequenceCandidate.PhaseElementStopIndex;
                        }
                    }
                }
            }
            return -1;

        }


        private List<Queue<PhaseElement>> GetElemets(Phase phase)
        {
            List<Queue<PhaseElement>> result = new List<Queue<PhaseElement>>();
            Queue<PhaseElement> phaseElementSequences;
            foreach (MatrixElement phaseMatrixElement in phase.MatrixElements)
            {
                phaseElementSequences = new Queue<PhaseElement>();

                PhaseElement phaseSequenceElement = new PhaseElement(phaseMatrixElement.ElementId);

                bool elementSequenceStarted = false;

                for (int i = 0; i < matrix.Packages.Count; i++)
                {
                    if (matrix.GetMatrix[phaseMatrixElement.ElementId, i] == true)
                    {
                        elementSequenceStarted = true;
                        if (phaseSequenceElement.PhaseElementStartIndex == -1)
                        {
                            phaseSequenceElement.PhaseElementStartIndex = i;
                        }
                        phaseSequenceElement.PhaseElementStopIndex = i;
                    }
                    else
                    {
                        if (elementSequenceStarted == true)
                        {
                            phaseElementSequences.Enqueue(phaseSequenceElement);
                            phaseSequenceElement = new PhaseElement(phaseMatrixElement.ElementId);
                            elementSequenceStarted = false;
                        }
                    }
                }

                if (elementSequenceStarted == true)
                {
                    phaseElementSequences.Enqueue(phaseSequenceElement);
                    phaseSequenceElement = new PhaseElement(phaseMatrixElement.ElementId);
                }
                if (phaseElementSequences.Count == 0)
                {
                    result = null;
                    break;
                }
                else
                {
                    result.Add(phaseElementSequences);
                }
            }
            return result;
        }
    }
}
