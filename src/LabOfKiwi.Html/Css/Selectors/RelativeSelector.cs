using LabOfKiwi.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LabOfKiwi.Html.Css.Selectors;

public abstract class RelativeSelector
{
    public static RelativeSelector Child(SubSelectorList selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new SingleRelativeSelector(Combinator.Child, selector);
    }

    public static RelativeSelector Descendant(SubSelectorList selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new SingleRelativeSelector(Combinator.Descendant, selector);
    }

    public abstract RelativeSelector Next(RelativeSelector selector);

    public static RelativeSelector NextSibling(SubSelectorList selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new SingleRelativeSelector(Combinator.NextSibling, selector);
    }

    public static RelativeSelector SubsequentSibling(SubSelectorList selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new SingleRelativeSelector(Combinator.SubsequentSibling, selector);
    }

    public abstract override string ToString();

    private sealed class SingleRelativeSelector : RelativeSelector
    {
        private readonly Combinator _combinator;
        private readonly SubSelectorList _selector;

        public SingleRelativeSelector(Combinator combinator, SubSelectorList selector)
        {
            _combinator = combinator;
            _selector = selector;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is SingleRelativeSelector other)
            {
                return _combinator == other._combinator && _selector.Equals(other._selector);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(typeof(RelativeSelector), _combinator, _selector);
        }

        public override RelativeSelector Next(RelativeSelector selector)
        {
            if (selector is SingleRelativeSelector single)
            {
                if (Equals(single))
                {
                    return this;
                }

                return new RelativeSelectorList(this, single);
            }

            if (selector is RelativeSelectorList list)
            {
                if (selector.Equals(list._selectors[0]))
                {
                    return list;
                }

                return new RelativeSelectorList(this, list);
            }

            Debug.Assert(selector == null);
            throw new ArgumentNullException(nameof(selector));
        }

        public override string ToString()
        {
            if (_combinator == Combinator.Descendant)
            {
                return _selector.ToString();
            }

            char combinator = _combinator switch
            {
                Combinator.Child => '>',
                Combinator.NextSibling => '+',
                Combinator.SubsequentSibling => '~',
                _ => throw new NotImplementedException(),
            };

            return $"{combinator} {_selector}";
        }
    }

    private sealed class RelativeSelectorList : RelativeSelector
    {
        internal readonly SingleRelativeSelector[] _selectors;

        public RelativeSelectorList(SingleRelativeSelector selector1, SingleRelativeSelector selector2)
        {
            _selectors = new SingleRelativeSelector[] { selector1, selector2 };
        }

        private RelativeSelectorList(SingleRelativeSelector[] selectors)
        {
            _selectors = selectors;
        }

        public RelativeSelectorList(SingleRelativeSelector selector1, RelativeSelectorList selector2)
        {
            var otherArray = selector2._selectors;
            int dupIndex = Array.IndexOf(otherArray, selector1);

            Debug.Assert(dupIndex != 0);

            if (dupIndex > 0)
            {
                _selectors = new SingleRelativeSelector[otherArray.Length];
                _selectors[0] = selector1;
                Array.Copy(otherArray, 0, _selectors, 1, dupIndex);
                Array.Copy(otherArray, dupIndex + 1, _selectors, dupIndex + 1, otherArray.Length - dupIndex - 1);
            }
            else
            {
                _selectors = new SingleRelativeSelector[otherArray.Length + 1];
                _selectors[0] = selector1;
                Array.Copy(otherArray, 0, _selectors, 1, otherArray.Length);
            }
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is RelativeSelectorList other)
            {
                return _selectors.StructurallyEquals(other._selectors);
            }

            return false;
        }

        public override int GetHashCode()
        {
            HashCode hashCode = new();

            foreach (var sel in _selectors)
            {
                hashCode.Add(sel);
            }

            return hashCode.ToHashCode();
        }

        public override RelativeSelector Next(RelativeSelector selector)
        {
            if (selector is SingleRelativeSelector single)
            {
                if (Array.IndexOf(_selectors, single) >= 0)
                {
                    return this;
                }

                return new RelativeSelectorList(_selectors.Add(single));
            }

            if (selector is RelativeSelectorList list)
            {
                if (ReferenceEquals(this, list))
                {
                    return this;
                }

                if (_selectors.StructurallyEquals(list._selectors))
                {
                    return this;
                }

                List<SingleRelativeSelector> selectors = new(_selectors.Length);

                selectors.AddRange(_selectors);

                foreach (var s in list._selectors)
                {
                    if (!selectors.Contains(s))
                    {
                        selectors.Add(s);
                    }
                }

                if (selectors.Count == _selectors.Length)
                {
                    return this;
                }

                return new RelativeSelectorList(selectors.ToArray());
            }

            Debug.Assert(selector == null);
            throw new ArgumentNullException(nameof(selector));
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
    }
}


