using LabOfKiwi.Collections;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;

namespace LabOfKiwi.Html;

public abstract partial class HtmlElement
{
    #region Getters
    internal string? Get(string attributeName)
    {
        return CoreNode.GetAttributeValue(attributeName, default(string));
    }

    internal bool GetBoolean(string attributeName)
    {
        return CoreNode.Attributes.Contains(attributeName);
    }

    internal TEnum? GetEnum<TEnum>(string attributeName) where TEnum : struct, Enum
    {
        return GetStruct<EnumParser<TEnum>, TEnum>(attributeName);
    }

    internal IList<TValue> GetList<TParser, TValue>(string attributeName, string delimiter)
        where TParser : struct, IAttributeParser<TValue>
        where TValue : notnull
    {
        return default(TParser).AsList(CoreNode, attributeName, delimiter);
    }

    internal TValue? GetObject<TParser, TValue>(string attributeName)
        where TParser : struct, IAttributeParser<TValue>
        where TValue : class
    {
        string? rawValue = Get(attributeName);

        if (rawValue != null)
        {
            rawValue = HttpUtility.HtmlDecode(rawValue);
            TParser parser = default;

            if (parser.TryParse(rawValue, out TValue? value))
            {
                Debug.Assert(parser.IsValid(value));
                return value;
            }
            else
            {
                HtmlHelper.ThrowInvalidAttributeStateException(attributeName, string.Format("Unable to parse value {0}", rawValue));
            }
        }

        return null;
    }

    internal IOrderedSet<TValue> GetOrderedSet<TParser, TValue>(string attributeName, string delimiter)
        where TParser : struct, IAttributeParser<TValue>
        where TValue : notnull
    {
        return default(TParser).AsOrderedSet(CoreNode, attributeName, delimiter);
    }

    internal ISet<TValue> GetSet<TParser, TValue>(string attributeName, string delimiter)
        where TParser : struct, IAttributeParser<TValue>
        where TValue : notnull
    {
        return default(TParser).AsSet(CoreNode, attributeName, delimiter);
    }

    internal TValue? GetStruct<TParser, TValue>(string attributeName)
        where TParser : struct, IAttributeParser<TValue>
        where TValue : struct
    {
        string? rawValue = Get(attributeName);

        if (rawValue != null)
        {
            rawValue = HttpUtility.HtmlDecode(rawValue);
            TParser parser = default;

            if (parser.TryParse(rawValue, out TValue value))
            {
                Debug.Assert(parser.IsValid(value));
                return value;
            }
            else
            {
                HtmlHelper.ThrowInvalidAttributeStateException(attributeName, string.Format("Unable to parse value {0}", rawValue));
            }
        }

        return null;
    }
    #endregion

    #region Setters
    internal void Set(string attributeName, string? value)
    {
        if (value == null)
        {

        }

        CoreNode.SetAttributeValue(attributeName, value != null ? HttpUtility.HtmlAttributeEncode(value) : null);
    }

    internal void SetBoolean(string attributeName, bool value)
    {
        if (value)
        {
            var attr = CoreNode.Attributes["attributeName"];
            
            if (attr == null)
            {
                attr = OwnerDocument.CoreDocument.CreateAttribute(attributeName);
                CoreNode.Attributes.Add(attr);
            }

            attr.Value = "";
            attr.QuoteType = HtmlAgilityPack.AttributeValueQuote.WithoutValue;
        }
        else
        {
            CoreNode.Attributes.Remove(attributeName);
        }
    }

    internal void SetEnum<TEnum>(string attributeName, TEnum? value) where TEnum : struct, Enum
    {
        SetStruct<EnumParser<TEnum>, TEnum>(attributeName, value);
    }

    internal void SetObject<TParser, TValue>(string attributeName, TValue? value)
        where TParser : struct, IAttributeParser<TValue>
        where TValue : class
    {
        if (value == null)
        {
            CoreNode.Attributes.Remove(attributeName);
            return;
        }

        TParser parser = default;

        if (!parser.IsValid(value))
        {
            HtmlHelper.ThrowInvalidAttributeValueException(attributeName, value);
        }

        bool parseResult = parser.TryToString(value, out string? rawValue);
        Debug.Assert(parseResult && rawValue != null);
        CoreNode.SetAttributeValue(attributeName, HttpUtility.HtmlAttributeEncode(rawValue));
    }

    internal void SetStruct<TParser, TValue>(string attributeName, TValue? value)
        where TParser : struct, IAttributeParser<TValue>
        where TValue : struct
    {
        if (!value.HasValue)
        {
            CoreNode.Attributes.Remove(attributeName);
            return;
        }

        TParser parser = default;

        if (!parser.IsValid(value.Value))
        {
            HtmlHelper.ThrowInvalidAttributeValueException(attributeName, value);
        }

        bool parseResult = parser.TryToString(value.Value, out string? rawValue);
        Debug.Assert(parseResult && rawValue != null);
        CoreNode.SetAttributeValue(attributeName, HttpUtility.HtmlAttributeEncode(rawValue));
    }
    #endregion
}
