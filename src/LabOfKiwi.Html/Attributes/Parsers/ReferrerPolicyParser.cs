using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct ReferrerPolicyParser : IAttributeParser<ReferrerPolicy>
{
    public bool IsValid(ReferrerPolicy value)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out ReferrerPolicy output)
    {
        switch (input)
        {
            case "":
                output = ReferrerPolicy.None;
                return true;
            case "no-referrer":
                output = ReferrerPolicy.NoReferrer;
                return true;
            case "no-referrer-when-downgrade":
                output = ReferrerPolicy.NoReferrerWhenDowngrade;
                return true;
            case "same-origin":
                output = ReferrerPolicy.SameOrigin;
                return true;
            case "origin":
                output = ReferrerPolicy.Origin;
                return true;
            case "strict-origin":
                output = ReferrerPolicy.StrictOrigin;
                return true;
            case "origin-when-cross-origin":
                output = ReferrerPolicy.OriginWhenCrossOrigin;
                return true;
            case "strict-origin-when-cross-origin":
                output = ReferrerPolicy.StrictOriginWhenCrossOrigin;
                return true;
            case "unsafe-url":
                output = ReferrerPolicy.UnsafeUrl;
                return true;
        }

        output = default;
        return false;
    }

    public bool TryToString(ReferrerPolicy input, [MaybeNullWhen(false)] out string output)
    {
        switch (input)
        {
            case ReferrerPolicy.None:
                output = "";
                return true;
            case ReferrerPolicy.NoReferrer:
                output = "no-referrer";
                return true;
            case ReferrerPolicy.NoReferrerWhenDowngrade:
                output = "no-referrer-when-downgrade";
                return true;
            case ReferrerPolicy.SameOrigin:
                output = "same-origin";
                return true;
            case ReferrerPolicy.Origin:
                output = "origin";
                return true;
            case ReferrerPolicy.StrictOrigin:
                output = "strict-origin";
                return true;
            case ReferrerPolicy.OriginWhenCrossOrigin:
                output = "origin-when-cross-origin";
                return true;
            case ReferrerPolicy.StrictOriginWhenCrossOrigin:
                output = "strict-origin-when-cross-origin";
                return true;
            case ReferrerPolicy.UnsafeUrl:
                output = "unsafe-url";
                return true;
        }

        output = default;
        return false;
    }
}
