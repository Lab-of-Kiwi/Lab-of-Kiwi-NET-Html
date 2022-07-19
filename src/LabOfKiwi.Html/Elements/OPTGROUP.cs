namespace LabOfKiwi.Html.Elements;

public class OPTGROUP : HtmlContainerElement
{
    public bool IsDisabled
    {
        get => GetBoolean("disabled");
        set => SetBoolean("disabled", value);
    }

    public string? Label
    {
        get => Get("label");
        set => Set("label", value);
    }

    internal sealed override string ExpectedTagName => "optgroup";
}
