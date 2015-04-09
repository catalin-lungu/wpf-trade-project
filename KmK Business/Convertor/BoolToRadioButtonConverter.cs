using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KmK_Business.Convertor
{
    public class BoolToRadioButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var test = (bool?)value;
            
            bool result;
            if (parameter != null)
            {
                Boolean.TryParse(parameter.ToString(), out result);
            }
            else
            {
                result = false;
            }

            if (test == result)
            {
                return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result;
            if (parameter != null)
            {
                Boolean.TryParse(parameter.ToString(), out result);
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
