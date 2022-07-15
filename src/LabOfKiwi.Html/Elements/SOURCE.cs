using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Collections.Generic;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class SOURCE : HtmlVoidElement
{
    internal SOURCE(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public long? Height
    {
        get => GetStruct<LongParser.NonNegative, long>("height");
        set => SetStruct<LongParser.NonNegative, long>("height", value);
    }

    // TODO
    public string? Media
    {
        get => Get("media");
        set => Set("media", value);
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
    public string? Type
    {
        get => Get("type");
        set => Set("type", value);
    }

    public long? Width
    {
        get => GetStruct<LongParser.NonNegative, long>("width");
        set => SetStruct<LongParser.NonNegative, long>("width", value);
    }
}
