using System;
using System.Diagnostics;

namespace LabOfKiwi.Html.Css;

public sealed class AttributeSelector : SimpleSelector
{
    private readonly string _attributeName;
    private readonly OperatorType? _operatorType;
    private readonly string? _value;
    private readonly CaseSensitivelyOption? _caseSensitivelyOption;

    public enum CaseSensitivelyOption
    {
        CaseInsensitive,
        CaseSensitive
    }

    public enum OperatorType
    {
        Matches,
        WordMatches,
        MatchesOrHyphenated,
        Prefixed,
        Suffixed,
        Contains
    }

    private AttributeSelector(string attributeName, OperatorType? operatorType, string? value, CaseSensitivelyOption? caseSensitivelyOption)
    {
        _attributeName = attributeName;
        _operatorType = operatorType;
        _value = value;
        _caseSensitivelyOption = caseSensitivelyOption;
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

        return new CompoundSelector(selector, this);
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

    public static AttributeSelector Contains(string attributeName, string value, CaseSensitivelyOption? caseSensitivelyOption = null)
    {
        return Create(attributeName, OperatorType.Contains, value, caseSensitivelyOption);
    }

    public static AttributeSelector Exists(string attributeName)
    {
        if (attributeName == null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        if (!IsValidAttributeName(attributeName))
        {
            throw new ArgumentException("Invalid attribute name.", nameof(attributeName));
        }

        return new AttributeSelector(attributeName, null, null, null);
    }

    public static AttributeSelector Matches(string attributeName, string value, CaseSensitivelyOption? caseSensitivelyOption = null)
    {
        return Create(attributeName, OperatorType.Matches, value, caseSensitivelyOption);
    }

    public static AttributeSelector MatchesOrHyphenated(string attributeName, string value, CaseSensitivelyOption? caseSensitivelyOption = null)
    {
        return Create(attributeName, OperatorType.MatchesOrHyphenated, value, caseSensitivelyOption);
    }

    public static AttributeSelector Prefixed(string attributeName, string value, CaseSensitivelyOption? caseSensitivelyOption = null)
    {
        return Create(attributeName, OperatorType.Prefixed, value, caseSensitivelyOption);
    }

    public static AttributeSelector Suffixed(string attributeName, string value, CaseSensitivelyOption? caseSensitivelyOption = null)
    {
        return Create(attributeName, OperatorType.Suffixed, value, caseSensitivelyOption);
    }

    public override string ToString()
    {
        if (_operatorType.HasValue)
        {
            Debug.Assert(_value != null);

            string op = _operatorType.Value switch
            {
                OperatorType.Matches => "=",
                OperatorType.WordMatches => "~=",
                OperatorType.MatchesOrHyphenated => "|=",
                OperatorType.Prefixed => "^=",
                OperatorType.Suffixed => "$=",
                OperatorType.Contains => "*=",
                _ => throw new NotImplementedException(),
            };

            string caseSens;

            if (_caseSensitivelyOption.HasValue)
            {
                caseSens = _caseSensitivelyOption.Value switch
                {
                    CaseSensitivelyOption.CaseInsensitive => " i",
                    CaseSensitivelyOption.CaseSensitive => " s",
                    _ => throw new NotImplementedException(),
                };
            }
            else
            {
                caseSens = string.Empty;
            }

            return $"[{_attributeName}{op}\"{_value}\"{caseSens}]";
        }

        return $"[{_attributeName}]";
    }

    public static AttributeSelector WordMatches(string attributeName, string value, CaseSensitivelyOption? caseSensitivelyOption = null)
    {
        return Create(attributeName, OperatorType.WordMatches, value, caseSensitivelyOption);
    }

    private static AttributeSelector Create(string attributeName, OperatorType operatorType, string value, CaseSensitivelyOption? caseSensitivelyOption)
    {
        if (attributeName == null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (!IsValidAttributeName(attributeName))
        {
            throw new ArgumentException("Invalid attribute name.", nameof(attributeName));
        }

        if (!IsValidValue(value))
        {
            throw new ArgumentException("Invalid value.", nameof(value));
        }

        return new AttributeSelector(attributeName, operatorType, value, caseSensitivelyOption);
    }

    private static bool IsValidAttributeName(string attributeName)
    {
        // TODO
        return true;
    }

    private static bool IsValidValue(string value)
    {
        // TODO
        return true;
    }
}
