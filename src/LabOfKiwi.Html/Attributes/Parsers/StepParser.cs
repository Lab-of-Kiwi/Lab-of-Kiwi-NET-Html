using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct StepParser : IAttributeParser<Step>
{
    public bool IsValid(Step input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out Step output)
    {
        return Step.TryParse(input, out output);
    }

    public bool TryToString(Step input, [MaybeNullWhen(false)] out string output)
    {
        output = input.ToString();
        return true;
    }
}
