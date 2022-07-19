namespace LabOfKiwi.Html.Elements;

public class DIALOG : HtmlContainerElement
{
    public bool IsOpen
    {
        get => GetBoolean("open");
        set => SetBoolean("open", value);
    }

    internal sealed override string ExpectedTagName => "dialog";
}
