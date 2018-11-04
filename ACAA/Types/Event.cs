using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAA.Types
{
    class Event : MatrixElement
    {
        private List<Condition> eventPreviousConditions = new List<Condition>();
        private List<Condition> eventConditions = new List<Condition>();

        public Event(int id, string name, List<Condition> prevConditions, List<Condition> conditions)
        {
            elementId = id;
            elementName = name;
            eventPreviousConditions = prevConditions;
            eventConditions = conditions;
        }

        public int EventId
        {
            get { return elementId; }
        }
        public string EventName
        {
            get { return elementName; }
        }

        public List<Condition> EventPreviousConditions
        {
            get
            {
                return eventPreviousConditions;
            }
        }

        public List<Condition> EventConditions
        {
            get
            {
                return eventConditions;
            }
        }

        public bool Check(Package previousPackage, Package package)
        {
            return (CheckConditions(package, eventConditions)&&CheckConditions(previousPackage, eventPreviousConditions));
        }

        private bool CheckConditions(Package package, List<Condition> conditions)
        {
            bool check = true;
            foreach (Condition condition in conditions)
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
