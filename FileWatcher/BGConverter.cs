using System;
using System.Windows.Data;
using System.Windows.Media;

namespace FileWatcher
{
    public class BGConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string operation = (string)value;
            switch (operation)
            {
                case "Created":
                    return Brushes.Green;

                case "Deleted":
                    return Brushes.Red;

                case "Renamed":
                    return Brushes.Orange;
                default:
                    return Brushes.Black;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}