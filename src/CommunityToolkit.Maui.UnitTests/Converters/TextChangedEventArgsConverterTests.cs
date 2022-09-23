using System.Globalization;
using CommunityToolkit.Maui.Converters;
using CommunityToolkit.Maui.UnitTests.Extensions;
using Xunit;

namespace CommunityToolkit.Maui.UnitTests.Converters;

public class TextChangedEventArgsConverterTests : BaseOneWayConverterTest<TextChangedEventArgsConverter>
{
	public static IReadOnlyList<object?[]> Data { get; } = new[]
	{
		new object?[] { null, null},
		new object?[] { new TextChangedEventArgs("Snoogan", "Snoogans"), "Snoogans"},
		new object?[] { new TextChangedEventArgs("Snoogans", "Snoogan"), "Snoogan"},
	};

	[Theory]
	[MemberData(nameof(Data))]
	public void TextChangedEventArgsConverter(TextChangedEventArgs value, object? expectedResult)
	{
		var textChangedEventArgsConverter = new TextChangedEventArgsConverter();

		var convertResult = ((ICommunityToolkitValueConverter)textChangedEventArgsConverter).Convert(value, typeof(object), null, CultureInfo.CurrentCulture);
		var convertFromResult = textChangedEventArgsConverter.ConvertFrom(value);

		Assert.Equal(expectedResult, convertResult);
		Assert.Equal(expectedResult, convertFromResult);
	}

	[Theory]
	[InlineData(1)]
	[InlineData(1.1)]
	[InlineData('c')]
	[InlineData(true)]
	public void InvalidConverterValuesThrowsArgumentException(object value)
	{
		var textChangedEventArgsConverter = new TextChangedEventArgsConverter();
		Assert.Throws<ArgumentException>(() => ((ICommunityToolkitValueConverter)textChangedEventArgsConverter).Convert(value, typeof(object), null, CultureInfo.CurrentCulture));
	}

	[Fact]
	public void TextChangedEventArgsConverterNullInputTest()
	{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.Throws<ArgumentNullException>(() => ((ICommunityToolkitValueConverter)new TextChangedEventArgsConverter()).Convert(new TextChangedEventArgs("", ""), null, null, null));
		Assert.Throws<ArgumentNullException>(() => ((ICommunityToolkitValueConverter)new TextChangedEventArgsConverter()).Convert(new TextChangedEventArgs(null, ""), null, null, null));
		Assert.Throws<ArgumentNullException>(() => ((ICommunityToolkitValueConverter)new TextChangedEventArgsConverter()).Convert(new TextChangedEventArgs("", null), null, null, null));
		Assert.Throws<ArgumentNullException>(() => ((ICommunityToolkitValueConverter)new TextChangedEventArgsConverter()).ConvertBack("", null, null, null));
		Assert.Throws<ArgumentNullException>(() => ((ICommunityToolkitValueConverter)new TextChangedEventArgsConverter()).ConvertBack(null, null, null, null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}
}