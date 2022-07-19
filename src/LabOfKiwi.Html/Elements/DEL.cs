using LabOfKiwi.Html.Attributes.Parsers;
using System;

namespace LabOfKiwi.Html.Elements;

public class DEL : HtmlContainerElement
{
    public Uri? Cite
    {
        get => GetObject<UrlParser, Uri>("cite");
        set => SetObject<UrlParser, Uri>("cite", value);
    }

    // TODO
    public string? Datetime
    {
        get => Get("datetime");
        set => Set("datatime", value);
    }

    internal sealed override string ExpectedTagName => "del";
}
