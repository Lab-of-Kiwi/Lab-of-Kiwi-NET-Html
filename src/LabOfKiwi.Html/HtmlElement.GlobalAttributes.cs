using LabOfKiwi.Collections;
using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System.Collections.Generic;
using System.Globalization;

namespace LabOfKiwi.Html;

public partial class HtmlElement
{
    public IOrderedSet<char> AccessKey => GetOrderedSet<AccessKeyParser, char>("accesskey", delimiter: " ");

    public Autocapitalize? Autocapitalize
    {
        get => GetEnum<Autocapitalize>("autocapitalize");
        set => SetEnum("autocapitalize", value);
    }

    public ISet<string> Class => GetSet<TokenParser, string>("class", delimiter: " ");

    public bool? ContentEditable
    {
        get => GetStruct<TrueFalseParser, bool>("contenteditable");
        set => SetStruct<TrueFalseParser, bool>("contenteditable", value);
    }

    public IDictionary<string, string> CustomData => new AttributeDictionary("data-", CoreNode);

    public bool? Draggable
    {
        get => GetStruct<TrueFalseParser, bool>("draggable");
        set => SetStruct<TrueFalseParser, bool>("draggable", value);
    }

    public EnterKeyHint? EnterKeyHint
    {
        get => GetEnum<EnterKeyHint>("enterkeyhint");
        set => SetEnum("enterkeyhint", value);
    }

    public Events Events => new(this);

    public string? Id
    {
        get => GetObject<TokenParser, string>("id");
        set => SetObject<TokenParser, string>("id", value);
    }

    public InputMode? InputMode
    {
        get => GetEnum<InputMode>("inputmode");
        set => SetEnum("inputmode", value);
    }

    public string? Is
    {
        get => GetObject<ElementIsParser, string>("is");
        set => SetObject<ElementIsParser, string>("is", value);
    }

    public bool IsAutofocus
    {
        get => GetBoolean("autofocus");
        set => SetBoolean("autofocus", value);
    }

    public bool IsHidden
    {
        get => GetBoolean("hidden");
        set => SetBoolean("hidden", value);
    }

    public bool IsInert
    {
        get => GetBoolean("inert");
        set => SetBoolean("inert", value);
    }

    public bool IsItemScope
    {
        get => GetBoolean("itemscope");
        set => SetBoolean("itemscope", value);
    }

    public ItemAttributes ItemAttributes => new(this);

    public CultureInfo? Language
    {
        get => GetObject<CultureInfoParser, CultureInfo>("lang");
        set => SetObject<CultureInfoParser, CultureInfo>("lang", value);
    }

    public string? Nonce
    {
        get => Get("nonce");
        set => Set("nonce", value);
    }

    public string? Slot
    {
        get => GetObject<TokenParser, string>("slot");
        set => SetObject<TokenParser, string>("slot", value);
    }

    public bool? Spellcheck
    {
        get => GetStruct<TrueFalseParser, bool>("spellcheck");
        set => SetStruct<TrueFalseParser, bool>("spellcheck", value);
    }

    public string? Style
    {
        get => Get("style");
        set => Set("style", value);
    }

    public long? TabIndex
    {
        get => GetStruct<LongParser, long>("tabindex");
        set => SetStruct<LongParser, long>("tabindex", value);
    }

    public TextDirection? TextDirection
    {
        get
        {
            if (NodeName == "bdo")
            {
                return GetStruct<TextDirectionParser.BDO, TextDirection>("dir");
            }
            else
            {
                return GetStruct<TextDirectionParser, TextDirection>("dir");
            }
        }

        set
        {
            if (NodeName == "bdo")
            {
                SetStruct<TextDirectionParser.BDO, TextDirection>("dir", value);
            }
            else
            {
                SetStruct<TextDirectionParser, TextDirection>("dir", value);
            }
        }
    }

    public string? Title
    {
        get => Get("title");
        set => Set("title", value);
    }

    public bool? Translate
    {
        get => GetStruct<YesNoParser, bool>("translate");
        set => SetStruct<YesNoParser, bool>("translate", value);
    }
}
