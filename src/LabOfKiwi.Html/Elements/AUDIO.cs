using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class AUDIO : HtmlContainerElement
{
    internal AUDIO(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public Crossorigin? Crossorigin
    {
        get => GetStruct<DashedEnumParser<Crossorigin>, Crossorigin>("crossorigin");
        set => SetStruct<DashedEnumParser<Crossorigin>, Crossorigin>("crossorigin", value);
    }

    public bool IsAutoPlay
    {
        get => GetBoolean("autoplay");
        set => SetBoolean("autoplay", value);
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
}