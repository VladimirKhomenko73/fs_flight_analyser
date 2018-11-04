using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAA.Types
{
    class State : MatrixElement
    {
        private List<Condition> stateConditions = new List<Condition>();

        public State(int id, string name, List<Condition> conditions)
        {
            elementId = id;
            elementName = name;
            stateConditions = conditions;
        }

        public string StateName
        {
            get { return elementName; }
        }

        public List<Condition> StateConditions
        {
            get => stateConditions;
        }
        public int StateId
        {
            get { return elementId; }
        }

        public bool Check(Package package)
        {
            bool check = true;
            foreach (Condition condition in stateConditions)
            {
                Parameter parameter = package.GetParameter(condition.startParameterName);
                if (parameter != null)
                {
                    if (condition.Check(parameter.GetValueAsFloat()) == false)
                    {
                        check = false;
                        break;
                    }
                }

            }
            return check;
        }
    }
}
