namespace LabOfKiwi.Html;

public abstract class HtmlVoidElement : HtmlElement
{
    internal HtmlVoidElement()
    {
    }

    public sealed override bool IsVoidElement => true;
}
