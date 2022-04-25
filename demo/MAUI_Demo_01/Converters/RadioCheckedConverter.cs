using System.Globalization;

namespace MAUI_Demo_01.Converters;

public class RadioCheckedConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var result = false;

        if (values.Length == 2)
        {
            if (values[0]?.GetType()?.Equals(values[1]?.GetType()) == true)
            {
                result = values[0].Equals(values[1]);
            }
        }

        return result;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        if (!(value is bool b) || targetTypes.Any(t => !t.IsAssignableFrom(typeof(bool))))
        {
            // Return null to indicate conversion back is not possible
            return null;
        }

        if (b)
        {
            return targetTypes.Select(t => (object)true).ToArray();
        }
        else
        {
            // Can't convert back from false because of ambiguity
            return null;
        }
    }
}