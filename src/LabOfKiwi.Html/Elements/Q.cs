using LabOfKiwi.Html.Attributes.Parsers;
using System;

namespace LabOfKiwi.Html.Elements;

public class Q : HtmlContainerElement
{
    public Uri? Cite
    {
        get => GetObject<UrlParser, Uri>("cite");
        set => SetObject<UrlParser, Uri>("cite", value);
    }

    internal sealed override string ExpectedTagName => "q";
}
