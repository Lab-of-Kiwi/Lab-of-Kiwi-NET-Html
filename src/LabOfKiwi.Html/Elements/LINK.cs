using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace LabOfKiwi.Html.Elements;

public class LINK : HtmlVoidElement
{
    // TODO
    public string? As
    {
        get => Get("as");
        set => Set("as", value);
    }

    // TODO
    public string? Color
    {
        get => Get("color");
        set => Set("color", value);
    }

    public Crossorigin? Crossorigin
    {
        get => GetStruct<CrossoriginParser, Crossorigin>("crossorigin");
        set => SetStruct<CrossoriginParser, Crossorigin>("crossorigin", value);
    }

    public ISet<string> Blocking => GetSet<TokenParser, string>("blocking", delimiter: " ");

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

    // TODO
    public string? ImageSizes
    {
        get => Get("imagesizes");
        set => Set("imagesizes", value);
    }

    // TODO
    public IList<string> ImageSrcSet => GetList<StringParser, string>("imagesrcset", delimiter: ",");

    public string? Integrity
    {
        get => Get("integrity");
        set => Set("integrity", value);
    }

    public bool IsDisabled
    {
        get => GetBoolean("disabled");
        set => SetBoolean("disabled", value);
    }

    // TODO
    public string? Media
    {
        get => Get("media");
        set => Set("media", value);
    }

    public ReferrerPolicy? ReferrerPolicy
    {
        get => GetStruct<ReferrerPolicyParser, ReferrerPolicy>("referrerpolicy");
        set => SetStruct<ReferrerPolicyParser, ReferrerPolicy>("referrerpolicy", value);
    }

    public ISet<string> Relationships => GetSet<TokenParser, string>("rel", delimiter: " ");

    // TODO
    public ISet<string> Sizes => GetSet<TokenParser, string>("sizes", delimiter: " ");

    // TODO
    public string? Type
    {
        get => Get("type");
        set => Set("type", value);
    }

    internal sealed override string ExpectedTagName => "link";
}
