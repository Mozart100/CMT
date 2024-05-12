using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows;

namespace CMT.Converters;

public abstract class Bool2ValueConverter<T> : MarkupExtension, IValueConverter
{
    protected Bool2ValueConverter()
    {
    }

    public T FalseValue { get; set; }

    public T TrueValue { get; set; }

    public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return System.Convert.ToBoolean(value) ? TrueValue : FalseValue;
    }

    public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value.Equals(TrueValue);
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}

public class Null2VisibilityConverter : Bool2ValueConverter<Visibility>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value != null ? TrueValue : FalseValue;
    }
}
