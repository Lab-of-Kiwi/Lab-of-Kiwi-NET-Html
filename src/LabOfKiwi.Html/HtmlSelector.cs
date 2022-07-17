using System;
using System.Collections.Generic;
using System.Text;

namespace LabOfKiwi.Html;

public sealed class HtmlSelector
{
    private readonly HtmlSelector? _prev;
    private readonly string? _element;
    private string? _id;
    private readonly ISet<string> _classes;

    private char? _operator;
    private HtmlSelector? _next;

    private HtmlSelector(string? element) : this(null, element)
    {
    }

    private HtmlSelector(HtmlSelector? previous, string? element)
    {
        _prev = previous;
        _element = element;
        _classes = new HashSet<string>();
    }

    public string? Id => _id;

    public HtmlSelector AddClass(string? cls)
    {
        if (cls != null)
        {
            _classes.Add(cls);
        }

        return this;
    }

    public HtmlSelector Child()
    {
        return CreateNext('>', false);
    }

    public HtmlSelector Child<TElement>() where TElement : HtmlElement
    {
        return CreateNext<TElement>('>');
    }

    public HtmlSelector ChildUniversal()
    {
        return CreateNext('>', true);
    }

    public HtmlSelector ClearClasses()
    {
        _classes.Clear();
        return this;
    }

    public HtmlSelector Descendant()
    {
        return CreateNext(null, false);
    }

    public HtmlSelector Descendant<TElement>() where TElement : HtmlElement
    {
        return CreateNext<TElement>(null);
    }

    public HtmlSelector DescendantUniversal()
    {
        return CreateNext(null, true);
    }

    public HtmlSelector Next()
    {
        return CreateNext(',', false);
    }

    public HtmlSelector Next<TElement>() where TElement : HtmlElement
    {
        return CreateNext<TElement>(',');
    }

    public HtmlSelector NextUniversal()
    {
        return CreateNext(',', true);
    }

    public HtmlSelector SetId(string? id)
    {
        _id = id;
        return this;
    }

    public HtmlSelector Sibling(bool mustBeAdjacent)
    {
        return CreateNext(mustBeAdjacent ? '+' : '~', false);
    }

    public HtmlSelector Sibling<TElement>(bool mustBeAdjacent) where TElement : HtmlElement
    {
        return CreateNext<TElement>(mustBeAdjacent ? '+' : '~');
    }

    public HtmlSelector SiblingUniversal(bool mustBeAdjacent)
    {
        return CreateNext(mustBeAdjacent ? '+' : '~', true);
    }

    public static HtmlSelector Create()
    {
        return new HtmlSelector(null);
    }

    public static HtmlSelector Create<TElement>() where TElement : HtmlElement
    {
        string tag = ElementRegistry.GetTagName<TElement>();
        return new HtmlSelector(tag);
    }

    public static HtmlSelector CreateUniversal()
    {
        return new HtmlSelector("*");
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        if (_element != null)
        {
            sb.Append(_element);
        }

        if (_id != null)
        {
            sb.Append('#').Append(_id);
        }

        foreach (string cls in _classes)
        {
            sb.Append('.').Append(cls);
        }

        if (_next != null)
        {
            if (_operator.HasValue)
            {
                sb.Append(' ').Append(_operator.Value);
            }

            sb.Append(' ').Append(_next.ToString());
        }

        return sb.ToString();
    }

    private HtmlSelector CreateNext<TElement>(char? op) where TElement : HtmlElement
    {
        if (_next != null)
        {
            throw new InvalidOperationException("Next selector already set.");
        }

        string tag = ElementRegistry.GetTagName<TElement>();
        _operator = op;
        _next = new HtmlSelector(this, tag);
        return _next;
    }

    private HtmlSelector CreateNext(char? op, bool isUniversal)
    {
        if (_next != null)
        {
            throw new InvalidOperationException("Next selector already set.");
        }

        _operator = op;
        _next = new HtmlSelector(this, isUniversal ? "*" : null);
        return _next;
    }
}
