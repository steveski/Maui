using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace CommunityToolkit.Maui.Converters;

/// <summary>
/// Converts/Extracts the incoming value from <see cref="TextChangedEventArgs"/> object and returns the value of <see cref="TextChangedEventArgs.NewTextValue"/> property from it.
/// </summary>
public class TextChangedEventArgsConverter : BaseConverterOneWay<TextChangedEventArgs?, object?>
{
    /// <inheritdoc/>
    public override object? DefaultConvertReturnValue { get; set; } = null;

    /// <summary>
    /// Converts/Extracts the incoming value from <see cref="TextChangedEventArgs"/> object and returns the value of <see cref="TextChangedEventArgs.NewTextValue"/> property from it.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="culture">(Not Used)</param>
    /// <returns>A <see cref="TextChangedEventArgs.NewTextValue"/> object from object of type <see cref="TextChangedEventArgs"/>.</returns>
    [return: NotNullIfNotNull("value")]
    public override object? ConvertFrom(TextChangedEventArgs? value, CultureInfo? culture = default) => value switch
    {
        null => null,
        _ => value.NewTextValue
    };

}