using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LabOfKiwi.Html.Css.Selectors;

public sealed class CompoundSelector : SubComplexSelector, IReadOnlyCollection<SimpleSelector>
{
    private readonly SimpleSelector? _typeSelector;
    private readonly IdSelector? _idSelector;
    private readonly ClassSelector[] _classSelectors;
    private readonly AttributeSelector[] _attributeSelectors;
    private readonly PseudoClass[] _pseudoClasses;
    private readonly PseudoElement? _pseudoElement;

    internal CompoundSelector(TypeSelector typeSelector, IdSelector idSelector)
    {
        _typeSelector = typeSelector;
        _idSelector = idSelector;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = null;
    }

    internal CompoundSelector(TypeSelector typeSelector, ClassSelector classSelector)
    {
        _typeSelector = typeSelector;
        _idSelector = null;
        _classSelectors = new ClassSelector[] { classSelector };
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = null;
    }

    internal CompoundSelector(TypeSelector typeSelector, AttributeSelector attributeSelector)
    {
        _typeSelector = typeSelector;
        _idSelector = null;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = new AttributeSelector[] { attributeSelector };
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = null;
    }

    internal CompoundSelector(TypeSelector typeSelector, PseudoClass pseudoClass)
    {
        _typeSelector = typeSelector;
        _idSelector = null;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = new PseudoClass[] { pseudoClass };
        _pseudoElement = null;
    }

    internal CompoundSelector(TypeSelector typeSelector, PseudoElement pseudoElement)
    {
        _typeSelector = typeSelector;
        _idSelector = null;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = pseudoElement;
    }

    internal CompoundSelector(UniversalSelector typeSelector, IdSelector idSelector)
    {
        _typeSelector = typeSelector;
        _idSelector = idSelector;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = null;
    }

    internal CompoundSelector(UniversalSelector typeSelector, ClassSelector classSelector)
    {
        _typeSelector = typeSelector;
        _idSelector = null;
        _classSelectors = new ClassSelector[] { classSelector };
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = null;
    }

    internal CompoundSelector(UniversalSelector typeSelector, AttributeSelector attributeSelector)
    {
        _typeSelector = typeSelector;
        _idSelector = null;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = new AttributeSelector[] { attributeSelector };
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = null;
    }

    internal CompoundSelector(UniversalSelector typeSelector, PseudoClass pseudoClass)
    {
        _typeSelector = typeSelector;
        _idSelector = null;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = new PseudoClass[] { pseudoClass };
        _pseudoElement = null;
    }

    internal CompoundSelector(UniversalSelector typeSelector, PseudoElement pseudoElement)
    {
        _typeSelector = typeSelector;
        _idSelector = null;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = pseudoElement;
    }

    internal CompoundSelector(IdSelector idSelector, ClassSelector classSelector)
    {
        _typeSelector = null;
        _idSelector = idSelector;
        _classSelectors = new ClassSelector[] { classSelector };
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = null;
    }

    internal CompoundSelector(IdSelector idSelector, AttributeSelector attributeSelector)
    {
        _typeSelector = null;
        _idSelector = idSelector;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = new AttributeSelector[] { attributeSelector };
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = null;
    }

    internal CompoundSelector(IdSelector idSelector, PseudoClass pseudoClass)
    {
        _typeSelector = null;
        _idSelector = idSelector;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = new PseudoClass[] { pseudoClass };
        _pseudoElement = null;
    }

    internal CompoundSelector(IdSelector idSelector, PseudoElement pseudoElement)
    {
        _typeSelector = null;
        _idSelector = idSelector;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = pseudoElement;
    }

    internal CompoundSelector(ClassSelector classSelector1, ClassSelector classSelector2)
    {
        _typeSelector = null;
        _idSelector = null;
        _classSelectors = classSelector1.Equals(classSelector2) ? new ClassSelector[] { classSelector1, classSelector2 } : new ClassSelector[] { classSelector1 };
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = null;
    }

    internal CompoundSelector(ClassSelector classSelector, AttributeSelector attributeSelector)
    {
        _typeSelector = null;
        _idSelector = null;
        _classSelectors = new ClassSelector[] { classSelector };
        _attributeSelectors = new AttributeSelector[] { attributeSelector };
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = null;
    }

    internal CompoundSelector(ClassSelector classSelector, PseudoClass pseudoClass)
    {
        _typeSelector = null;
        _idSelector = null;
        _classSelectors = new ClassSelector[] { classSelector };
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = new PseudoClass[] { pseudoClass };
        _pseudoElement = null;
    }

    internal CompoundSelector(ClassSelector classSelector, PseudoElement pseudoElement)
    {
        _typeSelector = null;
        _idSelector = null;
        _classSelectors = new ClassSelector[] { classSelector };
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = pseudoElement;
    }

    internal CompoundSelector(AttributeSelector attributeSelector1, AttributeSelector attributeSelector2)
    {
        _typeSelector = null;
        _idSelector = null;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = attributeSelector1.Equals(attributeSelector2) ? new AttributeSelector[] { attributeSelector1, attributeSelector2 } : new AttributeSelector[] { attributeSelector1 };
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = null;
    }

    internal CompoundSelector(AttributeSelector attributeSelector, PseudoClass pseudoClass)
    {
        _typeSelector = null;
        _idSelector = null;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = new AttributeSelector[] { attributeSelector };
        _pseudoClasses = new PseudoClass[] { pseudoClass };
        _pseudoElement = null;
    }

    internal CompoundSelector(AttributeSelector attributeSelector, PseudoElement pseudoElement)
    {
        _typeSelector = null;
        _idSelector = null;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = new AttributeSelector[] { attributeSelector };
        _pseudoClasses = Array.Empty<PseudoClass>();
        _pseudoElement = pseudoElement;
    }

    internal CompoundSelector(PseudoClass pseudoClass1, PseudoClass pseudoClass2)
    {
        _typeSelector = null;
        _idSelector = null;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = pseudoClass1.Equals(pseudoClass2) ? new PseudoClass[] { pseudoClass1, pseudoClass2 } : new PseudoClass[] { pseudoClass1 };
        _pseudoElement = null;
    }

    internal CompoundSelector(PseudoClass pseudoClass, PseudoElement pseudoElement)
    {
        _typeSelector = null;
        _idSelector = null;
        _classSelectors = Array.Empty<ClassSelector>();
        _attributeSelectors = Array.Empty<AttributeSelector>();
        _pseudoClasses = new PseudoClass[] { pseudoClass };
        _pseudoElement = pseudoElement;
    }

    private CompoundSelector(SimpleSelector? typeSelector, IdSelector? idSelector, ClassSelector[] classSelectors, AttributeSelector[] attributeSelectors, PseudoClass[] pseudoClasses, PseudoElement? pseudoElement)
    {
        Debug.Assert(typeSelector == null || typeSelector is TypeSelector || typeSelector is UniversalSelector);
        _typeSelector = typeSelector;
        _idSelector = idSelector;
        _classSelectors = classSelectors;
        _attributeSelectors = attributeSelectors;
        _pseudoClasses = pseudoClasses;
        _pseudoElement = pseudoElement;
    }

    public int Count
    {
        get
        {
            int cnt = 0;

            if (_typeSelector != null) cnt++;
            if (_idSelector != null) cnt++;
            cnt += _classSelectors.Length;
            cnt += _attributeSelectors.Length;
            cnt += _pseudoClasses.Length;
            if (_pseudoElement != null) cnt++;

            Debug.Assert(cnt > 0);
            return cnt;
        }
    }

    public override CompoundSelector Add(AttributeSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        if (Array.IndexOf(_attributeSelectors, selector) == -1)
        {
            var newAttributeSelectors = _attributeSelectors.Add(selector);
            return new CompoundSelector(_typeSelector, _idSelector, _classSelectors, newAttributeSelectors, _pseudoClasses, _pseudoElement);
        }

        return this;
    }

    public override CompoundSelector Add(ClassSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        if (Array.IndexOf(_classSelectors, selector) == -1)
        {
            var newClassSelectors = _classSelectors.Add(selector);
            return new CompoundSelector(_typeSelector, _idSelector, newClassSelectors, _attributeSelectors, _pseudoClasses, _pseudoElement);
        }

        return this;
    }

    public override CompoundSelector Add(PseudoClass selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        if (Array.IndexOf(_pseudoClasses, selector) == -1)
        {
            var newPseudoClasses = _pseudoClasses.Add(selector);
            return new CompoundSelector(_typeSelector, _idSelector, _classSelectors, _attributeSelectors, newPseudoClasses, _pseudoElement);
        }

        return this;
    }

    public IEnumerator<SimpleSelector> GetEnumerator()
    {
        if (_typeSelector != null)
        {
            yield return _typeSelector;
        }

        if (_idSelector != null)
        {
            yield return _idSelector;
        }

        for (int i = 0; i < _classSelectors.Length; i++)
        {
            yield return _classSelectors[i];
        }

        for (int i = 0; i < _attributeSelectors.Length; i++)
        {
            yield return _attributeSelectors[i];
        }

        for (int i = 0; i < _pseudoClasses.Length; i++)
        {
            yield return _pseudoClasses[i];
        }

        if (_pseudoElement != null)
        {
            yield return _pseudoElement;
        }
    }

    public CompoundSelector Set(IdSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        if (!selector.Equals(_idSelector))
        {
            return new CompoundSelector(_typeSelector, selector, _classSelectors, _attributeSelectors, _pseudoClasses, _pseudoElement);
        }

        return this;
    }

    public CompoundSelector Set(PseudoElement selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        if (!selector.Equals(_pseudoElement))
        {
            return new CompoundSelector(_typeSelector, _idSelector, _classSelectors, _attributeSelectors, _pseudoClasses, selector);
        }

        return this;
    }

    public CompoundSelector Set(TypeSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        if (!selector.Equals(_typeSelector))
        {
            return new CompoundSelector(selector, _idSelector, _classSelectors, _attributeSelectors, _pseudoClasses, _pseudoElement);
        }

        return this;
    }

    public CompoundSelector Set(UniversalSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        if (!selector.Equals(_typeSelector))
        {
            return new CompoundSelector(selector, _idSelector, _classSelectors, _attributeSelectors, _pseudoClasses, _pseudoElement);
        }

        return this;
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        using (var en = GetEnumerator())
        {
            while (en.MoveNext())
            {
                sb.Append(en.Current.ToString());
            }
        }

        return sb.ToString();
    }

    internal bool TryAsSimpleSelector([MaybeNullWhen(false)] out SimpleSelector result)
    {
        using var en = GetEnumerator();
        bool moveResult = en.MoveNext();
        Debug.Assert(moveResult);
        var first = en.Current;

        if (!en.MoveNext())
        {
            result = first;
            return true;
        }

        result = default;
        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
