using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Collections.Generic;

namespace LabOfKiwi.Html.Elements;

public class AREA : HtmlVoidElement
{
    public string? Alt
    {
        get => Get("alt");
        set => Set("alt", value);
    }

    public IList<float> Coordinates => GetList<FloatParser, float>("coords", delimiter: ",");

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

    public IList<Uri> Ping => GetList<UrlParser, Uri>("ping", delimiter: ",");

    public ReferrerPolicy? ReferrerPolicy
    {
        get => GetStruct<ReferrerPolicyParser, ReferrerPolicy>("referrerpolicy");
        set => SetStruct<ReferrerPolicyParser, ReferrerPolicy>("referrerpolicy", value);
    }

    public ISet<string> Relationships => GetSet<TokenParser, string>("rel", delimiter: " ");

    public Shape? Shape
    {
        get => GetEnum<Shape>("shape");
        set => SetEnum("shape", value);
    }

    public BrowsingContext? Target
    {
        get => GetStruct<BrowsingContextParser, BrowsingContext>("target");
        set => SetStruct<BrowsingContextParser, BrowsingContext>("target", value);
    }

    internal sealed override string ExpectedTagName => "area";
}
