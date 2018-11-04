using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ACAA.Types;

namespace ACAA.Converters
{
    class ParameterListToDataViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<Parameter> list = value as List<Parameter>;
            if (list == null) return null;

            DataTable t = new DataTable();

            // Add columns with name 
            t.Columns.Add(new DataColumn("Name"));
            t.Columns.Add(new DataColumn("Value"));

            // Add rows to DataTable according to column number
            for (int r = 0; r < list.Count; r++)
            {
                DataRow newRow = t.NewRow();
                newRow[0] = list[r].GetName();
                newRow[1] = list[r].GetValueAsDouble();
                t.Rows.Add(newRow);
            }

            return t.DefaultView;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
