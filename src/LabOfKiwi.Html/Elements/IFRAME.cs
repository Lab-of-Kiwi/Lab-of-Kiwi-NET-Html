using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;

namespace LabOfKiwi.Html.Elements;

public class IFRAME : HtmlVoidElement
{
    // TODO
    public string? Allow
    {
        get => Get("allow");
        set => Set("allow", value);
    }

    public bool AllowFullscreen
    {
        get => GetBoolean("allowfullscreen");
        set => SetBoolean("allowfullscreen", value);
    }

    public long? Height
    {
        get => GetStruct<LongParser.NonNegative, long>("height");
        set => SetStruct<LongParser.NonNegative, long>("height", value);
    }

    public Loading? Loading
    {
        get => GetEnum<Loading>("loading");
        set => SetEnum("loading", value);
    }

    // TODO
    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }

    public ReferrerPolicy? ReferrerPolicy
    {
        get => GetStruct<ReferrerPolicyParser, ReferrerPolicy>("referrerpolicy");
        set => SetStruct<ReferrerPolicyParser, ReferrerPolicy>("referrerpolicy", value);
    }

    public Sandbox Sandbox
    {
        get
        {
            string? rawValue = Get("sandbox");

            if (SandboxUtility.TryParse(rawValue, " ", out Sandbox result))
            {
                return result;
            }

            HtmlHelper.ThrowInvalidAttributeStateException("sandbox", $"Invalid value of '{rawValue}' is set.");
            return default;
        }

        set
        {
            string? rawValue = SandboxUtility.ToHTMLString(value, " ");
            Set("sandbox", rawValue);
        }
    }

    public Uri? Source
    {
        get => GetObject<UrlParser, Uri>("src");
        set => SetObject<UrlParser, Uri>("src", value);
    }

    // TODO
    public string? SourceDocument
    {
        get => Get("srcdoc");
        set => Set("srcdoc", value);
    }

    public long? Width
    {
        get => GetStruct<LongParser.NonNegative, long>("width");
        set => SetStruct<LongParser.NonNegative, long>("width", value);
    }

    internal sealed override string ExpectedTagName => "iframe";
}
