using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAA.Types
{
    class PhaseElement
    {
        private int phaseElementId;
        private int phaseElementStartIndex;
        private int phaseElementStopIndex;

        public PhaseElement(int id)
        {
            phaseElementId = id;
            phaseElementStartIndex = -1;
            phaseElementStopIndex = -1;
        }

        public int PhaseElementId { get => phaseElementId; set => phaseElementId = value; }
        public int PhaseElementStartIndex { get => phaseElementStartIndex; set => phaseElementStartIndex = value; }
        public int PhaseElementStopIndex { get => phaseElementStopIndex; set => phaseElementStopIndex = value; }
    }
}
