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
    class BoolArrayToDataViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Matrix matrix = value as Matrix;

            DataTable t = new DataTable();

            if (matrix != null)
            {
                bool[,] array = matrix.GetMatrix;
                if (array == null) return null;

                int rows = array.GetLength(0);
                if (rows == 0) return null;

                int columns = array.GetLength(1);
                //if (columns == 0) return null;
                               

                // Add columns with name 
                for (int c = 0; c < columns; c++)
                {
                    //t.Columns.Add(new DataColumn(matrix.Packages[c].GetAllParametersAsString()));
                    //t.Columns.Add(new DataColumn("Package " + c.ToString()));
                    t.Columns.Add(new DataColumn(c.ToString()));
                }

                // Add rows to DataTable according to column number
                for (int r = 0; r < rows; r++)
                {
                    DataRow newRow = t.NewRow();
                    for (int c = 0; c < columns; c++)
                    {
                        newRow[c] = array[r, c];
                    }
                    t.Rows.Add(newRow);
                }
            }

            return t.DefaultView;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
