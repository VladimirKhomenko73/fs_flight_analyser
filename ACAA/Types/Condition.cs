using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACAA.CheckStrategies;

namespace ACAA.Types
{
    class Condition
    {
        private int conditionId;
        private Parameter conditionStartParameterValue;
        private string checkParameterValue;
        private CheckStrategy checkStrategy;

        public Condition(int id, Parameter conditionStartParameter, string checkParameter)
        {
            conditionId = id;
            conditionStartParameterValue = conditionStartParameter;
            checkParameterValue = checkParameter;
            switch (checkParameterValue)
            {
                case ">":
                    checkStrategy = new MoreThanValueCheckStrategy();
                    break;
                case "<":
                    checkStrategy = new LessThanValueCheckStrategy();
                    break;
                case "=":
                    checkStrategy = new EqualToValueCheckStrategy();
                    break;
                case ">=":
                    checkStrategy = new MoreThanOrEqualValueCheckStrategy();
                    break;
                case "<=":
                    checkStrategy = new LessThanOrEqualValueCheckStrategy();
                    break;
                case "!=":
                    checkStrategy = new NotEqualToValueCheckStrategy();
                    break;
                case ">*":
                    checkStrategy = new MoreThanValueByCheckStrategy();
                    break;
                case "<*":
                    checkStrategy = new LessThanValueByCheckStrategy();
                    break;
                case "=*":
                    checkStrategy = new ValueNotChangingCheckStrategy();
                    break;
                default:
                    break;
            }
        }

        public string startParameterName
        {
            get { return conditionStartParameterValue.GetName(); }
        }

        public int ConditionId
        {
            get { return conditionId; }
        }

        public bool Check(float parameterValue)
        {
            return checkStrategy.Check(conditionStartParameterValue.GetValueAsFloat(), parameterValue);
        }
    }
}
