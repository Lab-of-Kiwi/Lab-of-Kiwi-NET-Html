using System;
using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes;

public readonly struct Step : IEquatable<Step>
{
    public static readonly Step Any = default;

    private readonly float _value;

    private Step(float value)
    {
        _value = value;
    }

    public float? Value => _value != default ? _value : null;

    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is Step other && Equals(other);

    public bool Equals(Step other)
        => _value == other._value;

    public override int GetHashCode()
        => _value.GetHashCode();

    public override string ToString()
    {
        if (_value == default)
        {
            return "any";
        }

        return _value.ToString();
    }

    public static Step Create(float value)
    {
        if (float.IsNaN(value) || float.IsInfinity(value) || value <= 0F)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        return new Step(value);
    }

    public static bool TryParse(string? value, out Step result)
    {
        if (value != null)
        {
            if (value == "any")
            {
                result = Any;
                return true;
            }

            if (float.TryParse(value, out float fpResult))
            {
                if (!(float.IsNaN(fpResult) || float.IsInfinity(fpResult) || fpResult <= 0F))
                {
                    result = new Step(fpResult);
                    return true;
                }
            }
        }

        result = default;
        return false;
    }

    public static bool operator ==(Step left, Step right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Step left, Step right)
    {
        return !(left == right);
    }
}
