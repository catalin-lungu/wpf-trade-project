using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KmK_Business.Convertor
{
    public class BoolToPlanTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<bool>)
            {
                List<string> list = new List<string>();
                foreach (var val in (value as List<bool>))
                {
                    string r = ((bool)val == true) ? "Test Trading Plans" : "Validated Trading Plans";
                    list.Add(r);
                }

                return list;
            }
            else
            {
                return ((bool)value == true) ? "Test Trading Plans" : "Validated Trading Plans"; 
            }

            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (((string)value).Equals("Test Trading Plans")) ? true : false;
        }
    }
}
