using System;
using Newtonsoft.Json;


namespace ACAA.Types
{
    class Parameter
    {
        public string parameterName;
        public object parameterValue;


        #region Constructors
        public Parameter()
        {

        }

        public Parameter(Parameter obj)
        {
            parameterName = obj.GetName();
            parameterValue = obj.GetValue();
        }

        [JsonConstructor]
        public Parameter(string ParameterName, object ParameterValue)
        {
            parameterName = ParameterName;
            parameterValue = ParameterValue;
        }

        public Parameter(string name, float value)
        {
            parameterName = name;
            parameterValue = value;
        }

        #endregion

        #region GetProperty

        public string GetName()
        {
            return parameterName;
        }

        public object GetValue()
        {
            return parameterValue;
        }
        #endregion

        #region GetPropertyAs

        public int GetValueAsInt()
        {
            return Convert.ToInt32(parameterValue);
        }

        public double GetValueAsDouble()
        {
            return Convert.ToDouble(parameterValue);
        }

        public float GetValueAsFloat()
        {
            return Convert.ToSingle(parameterValue);
        }

        public bool GetValueAsBool()
        {
            return Convert.ToBoolean(parameterValue);
        }

        public string GetValueAsString()
        {
            return parameterValue.ToString();
        }

        #endregion

        #region SetValue

        public void SetValue(object value)
        {
            parameterValue = value;
        }

        public void SetValue(float value)
        {
            parameterValue = value;
        }

        #endregion

    }
}
