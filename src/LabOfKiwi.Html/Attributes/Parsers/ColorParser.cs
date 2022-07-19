using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal readonly struct ColorParser : IAttributeParser<Color>
{
    public bool IsValid(Color input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out Color output)
    {
        try
        {
            output = ColorTranslator.FromHtml(input);
            return true;
        }
        catch
        {
            output = default;
            return false;
        }
    }

    public bool TryToString(Color input, [MaybeNullWhen(false)] out string output)
    {
        output = "#" + input.R.ToString("x2") + input.G.ToString("x2") + input.B.ToString("x2");
        return true;
    }
}
