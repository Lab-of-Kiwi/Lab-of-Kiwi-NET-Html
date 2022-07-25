using System;

namespace LabOfKiwi.Html.Css.Selectors;

public sealed class UniversalSelector : SimpleSelector
{
    public static readonly UniversalSelector Any                 = new("*");
    public static readonly UniversalSelector NamespacedAny       = new("*|*");
    public static readonly UniversalSelector AnyWithoutNamespace = new("|*");

    private readonly string _value;

    private UniversalSelector(string value)
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

    public static UniversalSelector OfNamespace(string ns)
    {
        if (ns == null)
        {
            throw new ArgumentNullException(nameof(ns));
        }

        // TODO validate namespace
        return new UniversalSelector($"{ns}|*");
    }

    public override string ToString()
    {
        return _value;
    }
}
