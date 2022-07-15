using System.Collections.Generic;

namespace LabOfKiwi.Html.Processors;

public abstract class MultiSelectProcessor<TValue> : SelectProcessor<TValue>
{
    private readonly HashSet<TValue> _selected;

    protected MultiSelectProcessor()
    {
        _selected = new();
    }

    public bool HasSelection => _selected.Count > 0;

    public bool AddSelection(TValue selection)
    {
        return _selected.Add(selection);
    }

    public void ClearSelections()
    {
        _selected.Clear();
    }

    public sealed override bool IsSelected(TValue item)
    {
        return _selected.Contains(item);
    }

    internal sealed override bool IsMultiple => true;
}
