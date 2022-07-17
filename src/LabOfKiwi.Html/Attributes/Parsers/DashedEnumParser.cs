using LabOfKiwi.Collections;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

[Obsolete("Will be removed due to too much 'magic' going on here.")]
public readonly struct DashedEnumParser<T> : IAttributeParser<T> where T : struct, Enum
{
    private static readonly ConcurrentDictionary<Type, object> CachedValues = new();

    public bool IsValid(T input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out T output)
    {
        return Cache.Reverse.TryGetValue(input, out output);
    }

    public bool TryToString(T input, [MaybeNullWhen(false)] out string output)
    {
        return Cache.TryGetValue(input, out output);
    }

    private static ReadOnlyMap<T, string> Cache
    {
        get
        {
            Type type = typeof(T);

            object result = CachedValues.GetOrAdd(type, t =>
            {
                Map<T, string> map = new();

                foreach (T value in Enum.GetValues<T>())
                {
                    string? name = Enum.GetName(value);

                    if (name != null)
                    {
                        map[value] = name.ToSnakeCase().Replace('_', '-').ToLowerInvariant();
                    }
                }

                return map.AsReadOnly();
            });

            Debug.Assert(result is ReadOnlyMap<T, string>);
            return (ReadOnlyMap<T, string>)result;
        }
    }
}
