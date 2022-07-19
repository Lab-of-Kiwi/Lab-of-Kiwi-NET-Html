using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;

namespace LabOfKiwi.Html.Elements;

public class AUDIO : HtmlContainerElement
{
    public Crossorigin? Crossorigin
    {
        get => GetStruct<CrossoriginParser, Crossorigin>("crossorigin");
        set => SetStruct<CrossoriginParser, Crossorigin>("crossorigin", value);
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

    internal sealed override string ExpectedTagName => "audio";
}
