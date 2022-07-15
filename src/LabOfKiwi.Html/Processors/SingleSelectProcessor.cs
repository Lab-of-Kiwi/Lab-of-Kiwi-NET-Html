namespace LabOfKiwi.Html.Processors;

public abstract class SingleSelectProcessor<TValue> : SelectProcessor<TValue>
{
    private TValue? _selection = default;

    protected SingleSelectProcessor()
    {
    }

    public bool HasSelection { get; private set; } = false;

    public void ClearSelection()
    {
        _selection = default;
        HasSelection = false;
    }

    public sealed override bool IsSelected(TValue item)
    {
        return HasSelection && Equals(_selection, item);
    }

    public void Select(TValue selection)
    {
        _selection = selection;
        HasSelection = true;
    }

    internal sealed override bool IsMultiple => false;
}
