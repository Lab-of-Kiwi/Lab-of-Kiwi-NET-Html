using LabOfKiwi.Html.Attributes;

namespace LabOfKiwi.Html.Elements;

public class BODY : HtmlContainerElement
{
    public new BodyEvents Events => new(this);
}
