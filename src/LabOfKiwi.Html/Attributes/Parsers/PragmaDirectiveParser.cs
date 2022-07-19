using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal readonly struct PragmaDirectiveParser : IAttributeParser<PragmaDirective>
{
    public bool IsValid(PragmaDirective input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out PragmaDirective output)
    {
        switch (input)
        {
            case "content-type":
                output = PragmaDirective.ContentType;
                return true;
            case "default-style":
                output = PragmaDirective.DefaultStyle;
                return true;
            case "refresh":
                output = PragmaDirective.Refresh;
                return true;
            case "x-ua-compatible":
                output = PragmaDirective.XUACompatible;
                return true;
            case "content-security-policy":
                output = PragmaDirective.ContentSecurityPolicy;
                return true;
        }

        output = default;
        return false;
    }

    public bool TryToString(PragmaDirective input, [MaybeNullWhen(false)] out string output)
    {
        switch (input)
        {
            case PragmaDirective.ContentType:
                output = "content-type";
                return true;
            case PragmaDirective.DefaultStyle:
                output = "default-style";
                return true;
            case PragmaDirective.Refresh:
                output = "refresh";
                return true;
            case PragmaDirective.XUACompatible:
                output = "x-ua-compatible";
                return true;
            case PragmaDirective.ContentSecurityPolicy:
                output = "content-security-policy";
                return true;
        }

        output = default;
        return false;
    }
}
