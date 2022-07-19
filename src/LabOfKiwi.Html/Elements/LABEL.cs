using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public class LABEL : HtmlContainerElement
{
    public string? For
    {
        get => GetObject<TokenParser, string>("for");
        set => SetObject<TokenParser, string>("for", value);
    }

}
