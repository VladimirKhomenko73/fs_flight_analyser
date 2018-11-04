using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAA.Types
{
    class Detection
    {
        private int startIndex;
        private int endIndex;

        public int StartIndex { get => startIndex; set => startIndex = value; }
        public int EndIndex { get => endIndex; set => endIndex = value; }

        public Detection()
        {
            startIndex = -1;
            endIndex = -1;
        }
    }
}
