using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;

namespace LabOfKiwi.Html.Elements;

public class VIDEO : HtmlContainerElement
{
    public Crossorigin? Crossorigin
    {
        get => GetStruct<DashedEnumParser<Crossorigin>, Crossorigin>("crossorigin");
        set => SetStruct<DashedEnumParser<Crossorigin>, Crossorigin>("crossorigin", value);
    }

    public long? Height
    {
        get => GetStruct<LongParser.NonNegative, long>("height");
        set => SetStruct<LongParser.NonNegative, long>("height", value);
    }

    public bool IsAutoPlay
    {
        get => GetBoolean("autoplay");
        set => SetBoolean("autoplay", value);
    }

    public bool IsInline
    {
        get => GetBoolean("playsinline");
        set => SetBoolean("playsinline", value);
    }

    public bool IsLoop
    {
        get => GetBoolean("loop");
        set => SetBoolean("loop", value);
    }

    public bool IsMuted
    {
        get => GetBoolean("muted");
        set => SetBoolean("muted", value);
    }

    public Uri? Poster
    {
        get => GetObject<UrlParser, Uri>("poster");
        set => SetObject<UrlParser, Uri>("poster", value);
    }

    public Preload? Preload
    {
        get => GetEnum<Preload>("preload");
        set => SetEnum("preload", value);
    }

    public bool ShowControls
    {
        get => GetBoolean("controls");
        set => SetBoolean("controls", value);
    }

    public Uri? Source
    {
        get => GetObject<UrlParser, Uri>("src");
        set => SetObject<UrlParser, Uri>("src", value);
    }

    public long? Width
    {
        get => GetStruct<LongParser.NonNegative, long>("width");
        set => SetStruct<LongParser.NonNegative, long>("width", value);
    }

    internal sealed override string ExpectedTagName => "video";
}
