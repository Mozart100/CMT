using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace CMT.Converters;

public class PointToAngleConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var progress = (double)values[0];
        var progressBar = (ProgressBar)values[1];

        return 359.999 * (progress / (progressBar.Maximum - progressBar.Minimum));
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
