namespace LabOfKiwi.Html;

public partial class HtmlContainerElement : HtmlElement
{
    public HtmlContainerElement(HtmlAgilityPack.HtmlNode coreElement) : base(coreElement)
    {
    }

    public sealed override bool IsVoidElement => false;
}
