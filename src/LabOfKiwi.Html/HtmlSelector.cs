using LabOfKiwi.Collections;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabOfKiwi.Html;

public sealed class HtmlSelector
{
    private static readonly TokenParser TokenParser = new(); 

    private readonly HtmlSelector? _previous;
    private char _combinator;
    private HtmlSelector? _next;

    private string? _typeSelector;
    private string? _idSelector;
    private readonly ListSet<PseudoClass> _pseudoClasses;
    private PseudoElement? _pseudoElement;
    private readonly List<string> _classSelectors;

    private HtmlSelector() : this(null)
    {
    }

    private HtmlSelector(HtmlSelector? previous)
    {
        _previous = previous;
        _classSelectors = new List<string>();
        _pseudoClasses = new ListSet<PseudoClass>();
    }

    public HtmlSelector AddPseudoClass(PseudoClass value)
    {
        _pseudoClasses.Add(value);
        return this;
    }

    public IHtmlSelectorProvider Descendant()
    {
        return new HtmlSelectorProvider(this, default);
    }

    public IHtmlSelectorProvider Child()
    {
        return new HtmlSelectorProvider(this, '>');
    }

    public HtmlSelector ClearClasses()
    {
        // TODO validate classes can be cleared.
        var latest = Tail;
        latest._classSelectors.Clear();
        return latest;
    }

    public static IHtmlSelectorProvider Create()
    {
        return new HtmlSelectorProvider(null, default);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is HtmlSelector other)
        {
            return ReferenceEquals(Head, other.Head);
        }

        return false;
    }

    public override int GetHashCode()
    {
        if (_previous == null)
        {
            return base.GetHashCode();
        }

        return _previous.GetHashCode();
    }

    public IHtmlSelectorProvider NextSelector()
    {
        return new HtmlSelectorProvider(this, ',');
    }

    public IHtmlSelectorProvider NextSibling()
    {
        return new HtmlSelectorProvider(this, '+');
    }

    public HtmlSelector SetId(string? id)
    {
        var tail = Tail;

        if (id != null && !TokenParser.IsValid(id))
        {
            throw new ArgumentException("Invalid id.");
        }

        tail._idSelector = id;
        return tail;
    }

    public HtmlSelector SetPseudoElement(PseudoElement? pseudoElement)
    {
        _pseudoElement = pseudoElement;
        return this;
    }

    public IHtmlSelectorProvider SubsequentSibling()
    {
        return new HtmlSelectorProvider(this, '~');
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        Head.ToString(sb);
        return sb.ToString();
    }

    private HtmlSelector Head
    {
        get
        {
            if (_previous == null)
            {
                return this;
            }

            return _previous.Head;
        }
    }

    private HtmlSelector Tail
    {
        get
        {
            if (_next == null)
            {
                return this;
            }

            return _next.Tail;
        }
    }

    private void ToString(StringBuilder sb)
    {
        if (_typeSelector != null)
        {
            sb.Append(_typeSelector);
        }

        if (_idSelector != null)
        {
            sb.Append('#').Append(_idSelector);
        }

        foreach (var cls in _classSelectors)
        {
            sb.Append('.').Append(cls);
        }

        foreach (var pseudoClass in _pseudoClasses)
        {
            sb.Append(':').Append(pseudoClass.ToWebString());
        }

        if (_pseudoElement.HasValue)
        {
            sb.Append("::").Append(_pseudoElement.Value.ToWebString());
        }

        if (_next != null)
        {
            sb.Append(' ');

            if (_combinator != default)
            {
                sb.Append(_combinator).Append(' ');
            }

            _next.ToString(sb);
        }
    }

    private sealed class HtmlSelectorProvider : IHtmlSelectorProvider
    {
        private readonly HtmlSelector? _previous;
        private readonly char _combinator;
        private bool _provided;

        public HtmlSelectorProvider(HtmlSelector? previous, char combinator)
        {
            _previous = previous;
            _combinator = combinator;
            _provided = false;
        }

        public HtmlSelector AllTypes()
        {
            var sel = Create();
            sel._typeSelector = "*";
            return sel;
        }

        public HtmlSelector AllTypesWithAnyNamespace()
        {
            var sel = Create();
            sel._typeSelector = "*|*";
            return sel;
        }

        public HtmlSelector AllTypesWithNamespace(string ns)
        {
            if (ns == null)
            {
                throw new ArgumentNullException(nameof(ns));
            }

            // TODO validate namespace
            var sel = Create();
            sel._typeSelector = $"{ns}|*";
            return sel;
        }

        public HtmlSelector AllTypesWithoutNamespace()
        {
            var sel = Create();
            sel._typeSelector = "|*";
            return sel;
        }

        public HtmlSelector OfType<TElement>() where TElement : HtmlElement, new()
        {
            var sel = Create();
            sel._typeSelector = new TElement().ExpectedTagName;
            return sel;
        }

        public HtmlSelector OfType(string type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            // TODO validate type
            var sel = Create();
            sel._typeSelector = type;
            return sel;
        }

        public HtmlSelector WithClasses(params string[] classes)
        {
            if (classes == null)
            {
                throw new ArgumentNullException(nameof(classes));
            }

            if (classes.Length == 0)
            {
                throw new ArgumentException("At least one class is required.");
            }

            if (classes.Any(c => !TokenParser.IsValid(c)))
            {
                throw new ArgumentException("Classes contains an invalid value.");
            }

            var sel = Create();
            sel._classSelectors.AddRange(classes.Distinct());
            return sel;
        }

        public HtmlSelector WithId(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (!TokenParser.IsValid(id))
            {
                throw new ArgumentException("Invalid id.");
            }

            var sel = Create();
            sel._idSelector = id;
            return sel;
        }

        private HtmlSelector Create()
        {
            if (_provided)
            {
                throw new InvalidOperationException("Selector has already been provided.");
            }

            HtmlSelector selector = new(_previous);

            if (_previous != null)
            {
                _previous._combinator = _combinator;
                _previous._next = selector;
            }

            _provided = true;
            return selector;
        }
    }
}
