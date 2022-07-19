namespace LabOfKiwi.Html;

public abstract partial class HtmlContainerElement : HtmlElement
{
    internal HtmlContainerElement()
    {
    }

    public sealed override bool IsVoidElement => false;
}
