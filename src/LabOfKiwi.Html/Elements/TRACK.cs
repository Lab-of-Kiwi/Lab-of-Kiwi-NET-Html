using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Globalization;

namespace LabOfKiwi.Html.Elements;

public class TRACK : HtmlVoidElement
{
    public bool IsDefault
    {
        get => GetBoolean("default");
        set => SetBoolean("default", value);
    }

    public TrackKind? Kind
    {
        get => GetEnum<TrackKind>("kind");
        set => SetEnum("kind", value);
    }

    public string? Label
    {
        get => Get("label");
        set => Set("label", value);
    }

    public Uri? Source
    {
        get => GetObject<UrlParser, Uri>("src");
        set => SetObject<UrlParser, Uri>("src", value);
    }

    public CultureInfo? SourceLanguage
    {
        get => GetObject<CultureInfoParser, CultureInfo>("srclang");
        set => SetObject<CultureInfoParser, CultureInfo>("srclang", value);
    }

    internal sealed override string ExpectedTagName => "track";
}
