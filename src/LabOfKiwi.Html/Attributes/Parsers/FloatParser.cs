using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal readonly struct FloatParser : IAttributeParser<float>
{
    public bool IsValid(float input)
    {
        return !(float.IsNaN(input) || float.IsInfinity(input));
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out float output)
    {
        return float.TryParse(input, out output);
    }

    public bool TryToString(float input, [MaybeNullWhen(false)] out string output)
    {
        output = input.ToString();
        return true;
    }
}
