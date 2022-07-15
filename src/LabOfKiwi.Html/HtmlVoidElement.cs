namespace LabOfKiwi.Html;

public abstract class HtmlVoidElement : HtmlElement
{
    internal HtmlVoidElement(HtmlAgilityPack.HtmlNode coreElement) : base(coreElement)
    {
    }

    public sealed override bool IsVoidElement => true;
}
