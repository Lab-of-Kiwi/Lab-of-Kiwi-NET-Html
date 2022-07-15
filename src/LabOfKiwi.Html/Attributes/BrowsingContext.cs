using System;
using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes;

public readonly struct BrowsingContext : IEquatable<BrowsingContext>
{
    private static readonly string[] Reserved = new string[]
    {
        "_blank", "_self", "_parent", "_top"
    };

    public static readonly BrowsingContext Blank = new(Reserved[0]);
    public static readonly BrowsingContext Self = new(Reserved[1]);
    public static readonly BrowsingContext Parent = new(Reserved[2]);
    public static readonly BrowsingContext Top = new(Reserved[3]);

    private readonly string? _value;

    internal BrowsingContext(string value)
    {
        _value = value;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is BrowsingContext other && Equals(other);

    public bool Equals(BrowsingContext other)
        => Equals(_value, other._value);

    public override int GetHashCode()
        =>  _value?.GetHashCode() ?? 0;

    public static BrowsingContext Create(string text)
    {
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text));
        }

        if (text.Length == 0)
        {
            throw new ArgumentException("Browsing context must have at least one character.");
        }

        if (text[0] == '_' && !Reserved.Contains(text))
        {
            throw new ArgumentException("Browsing context cannot begin with underscore unless is one of the reserved names.");
        }

        return new BrowsingContext(text);
    }

    public override string ToString() => _value ?? Reserved[1];

    public static bool operator ==(BrowsingContext left, BrowsingContext right)
        => left.Equals(right);

    public static bool operator !=(BrowsingContext left, BrowsingContext right)
        => !(left == right);

    internal static bool TryParse(string value, out BrowsingContext result)
    {
        if (string.IsNullOrEmpty(value))
        {
            result = default;
            return false;
        }

        if (value[0] == '_' && !Reserved.Contains(value))
        {
            result = default;
            return false;
        }

        result = new(value);
        return true;
    }
}
