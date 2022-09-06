using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp4.Converter
{
    public class ColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 3)
            {
                return null;
            }
            byte a = System.Convert.ToByte(values[0]);
            byte b = System.Convert.ToByte(values[1]);
            byte c = System.Convert.ToByte(values[2]);
            Color color = Color.FromRgb(a, b, c);
            SolidColorBrush brush = new SolidColorBrush(color);
            return brush;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
