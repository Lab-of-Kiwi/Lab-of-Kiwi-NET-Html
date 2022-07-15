using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Collections.Generic;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class SCRIPT : HtmlContainerElement
{
    internal SCRIPT(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public bool AllowModule
    {
        get => !GetBoolean("nomodule");
        set => SetBoolean("nomodule", !value);
    }

    public bool IsAsync
    {
        get => GetBoolean("async");
        set => SetBoolean("async", value);
    }

    public bool IsDeferred
    {
        get => GetBoolean("defer");
        set => SetBoolean("defer", value);
    }

    public ISet<string> Blocking => GetSet<TokenParser, string>("blocking", delimiter: " ");

    public Crossorigin? Crossorigin
    {
        get => GetStruct<DashedEnumParser<Crossorigin>, Crossorigin>("crossorigin");
        set => SetStruct<DashedEnumParser<Crossorigin>, Crossorigin>("crossorigin", value);
    }

    public string? Integrity
    {
        get => Get("integrity");
        set => Set("integrity", value);
    }

    public ReferrerPolicy? ReferrerPolicy
    {
        get => GetStruct<DashedEnumParser<ReferrerPolicy>, ReferrerPolicy>("referrerpolicy");
        set => SetStruct<DashedEnumParser<ReferrerPolicy>, ReferrerPolicy>("referrerpolicy", value);
    }

    public Uri? Source
    {
        get => GetObject<UrlParser, Uri>("src");
        set => SetObject<UrlParser, Uri>("src", value);
    }

    // TODO
    public string? Type
    {
        get => Get("type");
        set => Set("type", value);
    }
}
