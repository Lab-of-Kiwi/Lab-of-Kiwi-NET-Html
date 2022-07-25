using System;

namespace LabOfKiwi.Html.Css.Selectors;

public sealed class ClassSelector : SimpleSelector
{
    private readonly string _value;

    private ClassSelector(string value)
    {
        _value = value;
    }

    public override CompoundSelector Add(AttributeSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(this, selector);
    }

    public override CompoundSelector Add(ClassSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(this, selector);
    }

    public CompoundSelector Add(IdSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(selector, this);
    }

    public override CompoundSelector Add(PseudoClass selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(this, selector);
    }

    public CompoundSelector Add(PseudoElement selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(this, selector);
    }

    public CompoundSelector Add(TypeSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(selector, this);
    }

    public CompoundSelector Add(UniversalSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(selector, this);
    }

    public static ClassSelector Create(string className)
    {
        if (className == null)
        {
            throw new ArgumentNullException(nameof(className));
        }

        // TODO validate className
        return new ClassSelector(className);
    }

    public override string ToString()
    {
        return $".{_value}";
    }
}
