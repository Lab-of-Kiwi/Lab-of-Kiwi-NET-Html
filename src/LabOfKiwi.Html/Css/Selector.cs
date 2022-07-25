using System;

namespace LabOfKiwi.Html.Css;

public abstract class Selector
{
    internal Selector()
    {
    }

    public sealed override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj == null)
        {
            return false;
        }

        if (this is CompoundSelector compSelector1)
        {
            if (compSelector1.TryAsSimpleSelector(out SimpleSelector? simpSelector))
            {
                return simpSelector.Equals(obj);
            }
        }

        if (obj is CompoundSelector compSelector2)
        {
            if (compSelector2.TryAsSimpleSelector(out SimpleSelector? simpSelector))
            {
                return Equals(simpSelector);
            }
        }

        if (GetType() == obj.GetType())
        {
            return string.Equals(ToString(), obj.ToString());
        }

        return false;
    }

    public sealed override int GetHashCode()
    {
        return HashCode.Combine(typeof(Selector), ToString());
    }

    public abstract SelectorList Next(SubSelectorList selector);

    public abstract override string ToString();
}

public abstract class SubSelectorList : Selector
{
    internal SubSelectorList()
    {
    }

    public abstract ComplexSelector Child(SubComplexSelector selector);

    public abstract ComplexSelector Descendent(SubComplexSelector selector);

    public sealed override SelectorList Next(SubSelectorList selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new SelectorList(this, selector);
    }

    public abstract ComplexSelector NextSibling(SubComplexSelector selector);

    public abstract ComplexSelector SubsequentSibling(SubComplexSelector selector);
}

public abstract class SubComplexSelector : SubSelectorList
{
    internal SubComplexSelector()
    {
    }

    public abstract CompoundSelector Add(AttributeSelector selector);

    public abstract CompoundSelector Add(ClassSelector selector);

    public abstract CompoundSelector Add(PseudoClass selector);

    public sealed override ComplexSelector Child(SubComplexSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new ComplexSelector(this, Combinator.Child, selector);
    }

    public sealed override ComplexSelector Descendent(SubComplexSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new ComplexSelector(this, Combinator.Descendant, selector);
    }

    public sealed override ComplexSelector NextSibling(SubComplexSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new ComplexSelector(this, Combinator.NextSibling, selector);
    }

    public sealed override ComplexSelector SubsequentSibling(SubComplexSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new ComplexSelector(this, Combinator.SubsequentSibling, selector);
    }
}