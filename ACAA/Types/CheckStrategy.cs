using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAA.Types
{
    abstract class CheckStrategy
    {
        public abstract bool Check(float eventParameterValue,float chekingParameterValue);
    }
}
