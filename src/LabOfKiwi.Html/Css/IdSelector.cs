using System;

namespace LabOfKiwi.Html.Css;

public sealed class IdSelector : SimpleSelector
{
    private readonly string _value;

    private IdSelector(string value)
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

    public static IdSelector Create(string id)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        // TODO validate id
        return new IdSelector(id);
    }

    public override string ToString()
    {
        return $"#{_value}";
    }
}
