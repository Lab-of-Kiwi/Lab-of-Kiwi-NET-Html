using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal readonly struct CultureInfoParser : IAttributeParser<CultureInfo>
{
    public bool IsValid(CultureInfo input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out CultureInfo output)
    {
        try
        {
            output = new CultureInfo(input);
            return true;
        }
        catch (CultureNotFoundException)
        {
            output = default;
            return false;
        }
    }

    public bool TryToString(CultureInfo input, [MaybeNullWhen(false)] out string output)
    {
        output = input.TwoLetterISOLanguageName;
        return true;
    }
}
