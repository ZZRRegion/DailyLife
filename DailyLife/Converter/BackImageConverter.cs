using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace DailyLife.Converter
{
    class BackImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter != null)
            {
                try
                {
                    string path = parameter as string;
                    BitmapImage bmp = new BitmapImage(new Uri($"pack://application:,,,/BackImages/{path}", UriKind.RelativeOrAbsolute));
                    return bmp;
                }
                catch
                {

                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
