using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class BUTTON : HtmlContainerElement
{
    internal BUTTON(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public bool AllowFormValidation
    {
        get => !GetBoolean("formnovalidate");
        set => SetBoolean("formnovalidate", !value);
    }

    public string? Form
    {
        get => GetObject<TokenParser, string>("form");
        set => SetObject<TokenParser, string>("form", value);
    }

    public Uri? FormAction
    {
        get => GetObject<UrlParser, Uri>("formaction");
        set => SetObject<UrlParser, Uri>("formaction", value);
    }

    public EncodingType? FormEncodingType
    {
        get => GetStruct<EncodingTypeParser, EncodingType>("formenctype");
        set => SetStruct<EncodingTypeParser, EncodingType>("formenctype", value);
    }

    public FormSubmissionMethod? FormMethod
    {
        get => GetStruct<FormSubmissionMethodParser, FormSubmissionMethod>("formmethod");
        set => SetStruct<FormSubmissionMethodParser, FormSubmissionMethod>("formmethod", value);
    }

    public BrowsingContext? FormTarget
    {
        get => GetStruct<BrowsingContextParser, BrowsingContext>("formtarget");
        set => SetStruct<BrowsingContextParser, BrowsingContext>("formtarget", value);
    }

    public bool IsDisabled
    {
        get => GetBoolean("disabled");
        set => SetBoolean("disabled", value);
    }

    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }

    public ButtonType? Type
    {
        get => GetEnum<ButtonType>("type");
        set => SetEnum("type", value);
    }

    public string? Value
    {
        get => Get("value");
        set => Set("value", value);
    }
}
