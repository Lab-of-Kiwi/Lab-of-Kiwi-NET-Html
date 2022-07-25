using LabOfKiwi.Text;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LabOfKiwi.Html.Css;

public sealed class SelectorList : Selector, IReadOnlyList<Selector>
{
    private readonly SubSelectorList[] _selectors;

    internal SelectorList(SubSelectorList selector1, SubSelectorList selector2)
    {
        _selectors = new SubSelectorList[] { selector1, selector2 };
    }

    private SelectorList(SubSelectorList[] selectors)
    {
        _selectors = selectors;
    }

    public Selector this[int index] => _selectors[index];

    public int Count => _selectors.Length;

    public IEnumerator<Selector> GetEnumerator()
    {
        return ((IList<SubSelectorList>)_selectors).GetEnumerator();
    }

    public override SelectorList Next(SubSelectorList selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        var selectors = _selectors.Add(selector);
        return new SelectorList(selectors);
    }

    public override string ToString()
    {
        StringJoiner sj = new(delimiter: ", ");

        foreach (var selector in _selectors)
        {
            sj.Add(selector.ToString());
        }

        return sj.ToString();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _selectors.GetEnumerator();
    }
}
