using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAA.Types
{
    class MatrixElement
    {
        protected int elementId;
        protected string elementName;

        public int ElementId
        {
            get { return elementId; }
        }
        public string ElementName
        {
            get { return elementName; }
        }
    }
}
