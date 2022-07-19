using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace LabOfKiwi.Html.Elements;

public class A : HtmlContainerElement
{
    public string? Download
    {
        get => Get("download");
        set => Set("download", value);
    }

    public Uri? Href
    {
        get => GetObject<UrlParser, Uri>("href");
        set => SetObject<UrlParser, Uri>("href", value);
    }

    public CultureInfo? HrefLang
    {
        get => GetObject<CultureInfoParser, CultureInfo>("hreflang");
        set => SetObject<CultureInfoParser, CultureInfo>("hreflang", value);
    }

    public IList<Uri> Ping => GetList<UrlParser, Uri>("ping", delimiter: ",");

    public ReferrerPolicy? ReferrerPolicy
    {
        get => GetStruct<ReferrerPolicyParser, ReferrerPolicy>("referrerpolicy");
        set => SetStruct<ReferrerPolicyParser, ReferrerPolicy>("referrerpolicy", value);
    }

    public ISet<string> Relationships => GetSet<TokenParser, string>("rel", delimiter: " ");

    public BrowsingContext? Target
    {
        get => GetStruct<BrowsingContextParser, BrowsingContext>("target");
        set => SetStruct<BrowsingContextParser, BrowsingContext>("target", value);
    }

    // TODO
    public string? Type
    {
        get => Get("type");
        set => Set("type", value);
    }

    internal sealed override string ExpectedTagName => "a";
}
