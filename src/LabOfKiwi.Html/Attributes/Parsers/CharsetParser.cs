using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct CharsetParser : IAttributeParser<Encoding>
{
    public bool IsValid(Encoding input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out Encoding output)
    {
        try
        {
            output = Encoding.GetEncoding(input);
            return true;
        }
        catch
        {
            output = default;
            return false;
        }
    }

    public bool TryToString(Encoding input, [MaybeNullWhen(false)] out string output)
    {
        output = input.WebName.ToLowerInvariant();
        return true;
    }
}
