using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACAA.Types
{
    class Package : MatrixElement
    {
        private IDictionary<string, Parameter> parameterSet = new Dictionary<string, Parameter>();

        [JsonConstructor]
        public Package(int PackageNumber, Dictionary<string, Parameter> ParameterSet)
        {
            elementId = PackageNumber;
            parameterSet = ParameterSet;
        }

        public int packageNumber
        {
            get { return elementId; }
        }

        public Parameter GetParameter(string token)
        {
            if (parameterSet.ContainsKey(token))
            {
                return parameterSet[token];
            }
            else
            {
                return null;
            }

        }

        public bool ContainsParameter(string token)
        {
            return parameterSet.ContainsKey(token);
        }

        public string GetAllParametersAsString()
        {
            string parameterList = "";
            foreach (KeyValuePair<string, Parameter> param in parameterSet)
            {
                parameterList += String.Format("{0}:{1}{2}",param.Key,param.Value.GetValueAsFloat(), Environment.NewLine);
            }
            return parameterList;
        }

        public List<Parameter> GetParametersAsList()
        {
            return parameterSet.Values.ToList();
        }

    }
}
