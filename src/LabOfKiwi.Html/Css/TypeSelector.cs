using System;

namespace LabOfKiwi.Html.Css;

public sealed class TypeSelector : SimpleSelector
{
    private readonly string _value;

    private TypeSelector(string value)
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

    public static TypeSelector OfType<TElement>() where TElement : HtmlElement, new()
    {
        string value = new TElement().ExpectedTagName;
        return new TypeSelector(value);
    }

    public override string ToString()
    {
        return _value;
    }
}
