using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Globalization;

namespace LabOfKiwi.Html.Elements;

public class CustomElement : HtmlContainerElement
{
    public CustomElement(string tagName)
    {
        ExpectedTagName = tagName;
    }

    public void SetAttributeValue(string attributeName, string? value)
    {
        if (attributeName == null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        if (value == null)
        {
            Set(attributeName, value);
            return;
        }

        switch(attributeName)
        {
            case "accesskey":
                SetAsSet<AccessKeyParser, char>(attributeName, value, " ");
                break;
            case "autocapitalize":
                Set<EnumParser<Autocapitalize>, Autocapitalize>(attributeName, value);
                break;
            case "autofocus":
            case "hidden":
            case "inert":
            case "itemscope":
                if (value.Length != 0)
                {
                    HtmlHelper.ThrowInvalidAttributeValueException(attributeName, value);
                }

                SetBoolean(attributeName, true);
                break;
            case "class":
            case "itemprop":
            case "itemref":
            case "itemtype":
                SetAsSet<TokenParser, string>(attributeName, value, " ");
                break;
            case "contenteditable":
            case "draggable":
            case "spellcheck":
                Set<TrueFalseParser, bool>(attributeName, value);
                break;
            case "enterkeyhint":
                Set<EnumParser<EnterKeyHint>, EnterKeyHint>(attributeName, value);
                break;
            case "id":
            case "slot":
                Set<TokenParser, string>(attributeName, value);
                break;
            case "inputmode":
                Set<EnumParser<InputMode>, InputMode>(attributeName, value);
                break;
            case "is":
                Set<ElementIsParser, string>(attributeName, value);
                break;
            case "itemid":
                Set<UrlParser, Uri>(attributeName, value);
                break;
            case "lang":
                Set<CultureInfoParser, CultureInfo>(attributeName, value);
                break;
            case "tabindex":
                Set<LongParser, long>(attributeName, value);
                break;
            case "dir":
                Set<TextDirectionParser, TextDirection>(attributeName, value);
                break;
            case "translate":
                Set<YesNoParser, bool>(attributeName, value);
                break;
        }
    }

    internal sealed override string ExpectedTagName { get; }
}
