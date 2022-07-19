namespace LabOfKiwi.Html.Elements;

public class CustomElement : HtmlContainerElement
{
    public CustomElement(string tagName)
    {
        ExpectedTagName = tagName;
    }

    internal sealed override string ExpectedTagName { get; }
}
