using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LabOfKiwi.Html.Css.Selectors;

public sealed class ComplexSelector : SubSelectorList, IEnumerable<(SubComplexSelector Left, Combinator Combinator, SubComplexSelector Right)>
{
    private readonly SubComplexSelector _rootSelector;
    private readonly CombinatorRecord[] _combinatorRecords;

    internal ComplexSelector(SubComplexSelector left, Combinator combinator, SubComplexSelector right)
    {
        _rootSelector = left;
        _combinatorRecords = new CombinatorRecord[] { new CombinatorRecord(combinator, right) };
    }

    private ComplexSelector(SubComplexSelector rootSelector, CombinatorRecord[] combinatorRecords)
    {
        _rootSelector = rootSelector;
        _combinatorRecords = combinatorRecords;
    }

    public override ComplexSelector Child(SubComplexSelector selector)
    {
        return Add(Combinator.Child, selector);
    }

    public override ComplexSelector Descendent(SubComplexSelector selector)
    {
        return Add(Combinator.Descendant, selector);
    }

    public IEnumerator<(SubComplexSelector Left, Combinator Combinator, SubComplexSelector Right)> GetEnumerator()
    {
        using var en = ((IList<CombinatorRecord>)_combinatorRecords).GetEnumerator();
        bool result = en.MoveNext();
        Debug.Assert(result);
        var previous = en.Current;

        yield return (_rootSelector, previous.Combinator, previous.Selector);

        while (en.MoveNext())
        {
            yield return (previous.Selector, en.Current.Combinator, en.Current.Selector);
            previous = en.Current;
        }
    }

    public override ComplexSelector NextSibling(SubComplexSelector selector)
    {
        return Add(Combinator.NextSibling, selector);
    }

    public override ComplexSelector SubsequentSibling(SubComplexSelector selector)
    {
        return Add(Combinator.SubsequentSibling, selector);
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(_rootSelector);

        foreach (var rec in _combinatorRecords)
        {
            rec.ToString(sb);
        }

        return sb.ToString();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private ComplexSelector Add(Combinator combinator, SubComplexSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        CombinatorRecord[] combinatorRecords = _combinatorRecords.Add(new CombinatorRecord(combinator, selector));
        return new ComplexSelector(_rootSelector, combinatorRecords);
    }

    private readonly struct CombinatorRecord
    {
        private readonly Combinator _combinator;
        private readonly SubComplexSelector _selector;

        public CombinatorRecord(Combinator combinator, SubComplexSelector selector)
        {
            _combinator = combinator;
            _selector = selector;
        }

        public Combinator Combinator => _combinator;

        public SubComplexSelector Selector => _selector;

        public void ToString(StringBuilder sb)
        {
            sb.Append(' ');

            switch (_combinator)
            {
                case Combinator.Child:
                    sb.Append('>').Append(' ');
                    break;
                case Combinator.NextSibling:
                    sb.Append('+').Append(' ');
                    break;
                case Combinator.SubsequentSibling:
                    sb.Append('~').Append(' ');
                    break;
            }

            sb.Append(_selector.ToString());
        }
    }
}
