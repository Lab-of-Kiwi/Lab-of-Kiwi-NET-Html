using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Text;

namespace LabOfKiwi.Html.Elements;

public class FORM : HtmlContainerElement
{
    public Encoding? AcceptCharset
    {
        get => GetObject<CharsetParser, Encoding>("accept-charset");
        set => SetObject<CharsetParser, Encoding>("accept-charset", value);
    }

    public Uri? Action
    {
        get => GetObject<UrlParser, Uri>("action");
        set => SetObject<UrlParser, Uri>("action", value);
    }

    public bool AllowValidation
    {
        get => !GetBoolean("novalidate");
        set => SetBoolean("novalidate", !value);
    }

    public bool? AutoComplete
    {
        get => GetStruct<OnOffParser, bool>("autocomplete");
        set => SetStruct<OnOffParser, bool>("autocomplete", value);
    }

    public EncodingType? EncodingType
    {
        get => GetStruct<EncodingTypeParser, EncodingType>("enctype");
        set => SetStruct<EncodingTypeParser, EncodingType>("enctype", value);
    }

    public FormSubmissionMethod? Method
    {
        get => GetStruct<FormSubmissionMethodParser, FormSubmissionMethod>("method");
        set => SetStruct<FormSubmissionMethodParser, FormSubmissionMethod>("method", value);
    }

    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }

    public BrowsingContext? Target
    {
        get => GetStruct<BrowsingContextParser, BrowsingContext>("target");
        set => SetStruct<BrowsingContextParser, BrowsingContext>("target", value);
    }

    internal sealed override string ExpectedTagName => "form";
}
