using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal readonly struct CrossoriginParser : IAttributeParser<Crossorigin>
{
    public bool IsValid(Crossorigin value)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out Crossorigin output)
    {
        switch (input)
        {
            case "anonymous":
                output = Crossorigin.Anonymous;
                return true;
            case "use-credentials":
                output = Crossorigin.UseCredentials;
                return true;
        }

        output = default;
        return false;
    }

    public bool TryToString(Crossorigin input, [MaybeNullWhen(false)] out string output)
    {
        switch (input)
        {
            case Crossorigin.Anonymous:
                output = "anonymous";
                return true;
            case Crossorigin.UseCredentials:
                output = "use-credentials";
                return true;
        }

        output = default;
        return false;
    }
}
