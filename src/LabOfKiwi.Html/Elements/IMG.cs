using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Collections.Generic;

namespace LabOfKiwi.Html.Elements;

public class IMG : HtmlVoidElement
{
    public string? Alt
    {
        get => Get("alt");
        set => Set("alt", value);
    }

    public Crossorigin? Crossorigin
    {
        get => GetStruct<CrossoriginParser, Crossorigin>("crossorigin");
        set => SetStruct<CrossoriginParser, Crossorigin>("crossorigin", value);
    }

    public Decoding? Decoding
    {
        get => GetEnum<Decoding>("decoding");
        set => SetEnum("decoding", value);
    }

    public long? Height
    {
        get => GetStruct<LongParser.NonNegative, long>("height");
        set => SetStruct<LongParser.NonNegative, long>("height", value);
    }

    public bool IsMap
    {
        get => GetBoolean("ismap");
        set => SetBoolean("ismap", value);
    }

    public Loading? Loading
    {
        get => GetEnum<Loading>("loading");
        set => SetEnum("loading", value);
    }

    public ReferrerPolicy? ReferrerPolicy
    {
        get => GetStruct<ReferrerPolicyParser, ReferrerPolicy>("referrerpolicy");
        set => SetStruct<ReferrerPolicyParser, ReferrerPolicy>("referrerpolicy", value);
    }

    // TODO
    public string? Sizes
    {
        get => Get("sizes");
        set => Set("sizes", value);
    }

    public Uri? Source
    {
        get => GetObject<UrlParser, Uri>("src");
        set => SetObject<UrlParser, Uri>("src", value);
    }

    // TODO
    public IList<string> SourceSet => GetList<StringParser, string>("srcset", delimiter: ",");

    // TODO
    public string? UseMap
    {
        get => Get("usemap");
        set => Set("usemap", value);
    }

    public long? Width
    {
        get => GetStruct<LongParser.NonNegative, long>("width");
        set => SetStruct<LongParser.NonNegative, long>("width", value);
    }

    internal sealed override string ExpectedTagName => "img";
}
