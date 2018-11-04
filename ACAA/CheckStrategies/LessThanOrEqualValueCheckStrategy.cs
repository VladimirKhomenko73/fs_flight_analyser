using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACAA.Types;

namespace ACAA.CheckStrategies
{
    class LessThanOrEqualValueCheckStrategy : CheckStrategy
    {
        public override bool Check(float eventParameterValue, float chekingParameterValue)
        {
            if (eventParameterValue>=chekingParameterValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
