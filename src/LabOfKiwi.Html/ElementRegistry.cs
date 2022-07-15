using LabOfKiwi.Collections;
using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Elements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace LabOfKiwi.Html;

internal static class ElementRegistry
{
    private static readonly IReadOnlyMap<string, Type> ElementTypes;
    private static readonly IReadOnlyDictionary<Type, ConstructorInfo> TypeConstructors;
    private static readonly IReadOnlyDictionary<Type, ConstructorInfo> InputTypeConstructors;

    private static readonly Type[] CtorParameters = new Type[] { typeof(HtmlAgilityPack.HtmlNode) };

    static ElementRegistry()
    {
        string ns = typeof(ElementRegistry).Namespace + ".Elements";
        var elementTypes = new Map<string, Type>();
        var typeConstructors = new Dictionary<Type, ConstructorInfo>();

        foreach (Type type in Assembly.GetAssembly(typeof(ElementRegistry))!.GetTypes())
        {
            if (type.IsAssignableTo(typeof(INPUT)))
            {
                continue;
            }

            if (!string.Equals(type.Namespace, ns, StringComparison.Ordinal))
            {
                continue;
            }

            if (!type.IsAssignableTo(typeof(HtmlElement)))
            {
                continue;
            }

            if (type.Name != type.Name.ToUpperInvariant())
            {
                continue;
            }

            var constructor = GetElementConstructor(type);

            if (constructor == null)
            {
                continue;
            }

            elementTypes[type.Name.ToLowerInvariant()] = type;
            typeConstructors[type] = constructor;
        }

        ElementTypes = elementTypes;
        TypeConstructors = typeConstructors;

        var inputTypeConstructors = new Dictionary<Type, ConstructorInfo>();
        Add(inputTypeConstructors, typeof(INPUT));
        Add(inputTypeConstructors, typeof(INPUT.Hidden));
        Add(inputTypeConstructors, typeof(INPUT.Text));
        Add(inputTypeConstructors, typeof(INPUT.Search));
        Add(inputTypeConstructors, typeof(INPUT.Telephone));
        Add(inputTypeConstructors, typeof(INPUT.Url));
        Add(inputTypeConstructors, typeof(INPUT.Email));
        Add(inputTypeConstructors, typeof(INPUT.Password));
        Add(inputTypeConstructors, typeof(INPUT.Date));
        Add(inputTypeConstructors, typeof(INPUT.Month));
        Add(inputTypeConstructors, typeof(INPUT.Week));
        Add(inputTypeConstructors, typeof(INPUT.Time));
        Add(inputTypeConstructors, typeof(INPUT.DateTimeLocal));
        Add(inputTypeConstructors, typeof(INPUT.Number));
        Add(inputTypeConstructors, typeof(INPUT.Range));
        Add(inputTypeConstructors, typeof(INPUT.Color));
        Add(inputTypeConstructors, typeof(INPUT.Checkbox));
        Add(inputTypeConstructors, typeof(INPUT.RadioButton));
        Add(inputTypeConstructors, typeof(INPUT.FileUpload));
        Add(inputTypeConstructors, typeof(INPUT.SubmitButton));
        Add(inputTypeConstructors, typeof(INPUT.ImageButton));
        Add(inputTypeConstructors, typeof(INPUT.ResetButton));
        Add(inputTypeConstructors, typeof(INPUT.Button));

        InputTypeConstructors = inputTypeConstructors;
    }

    private static void Add(Dictionary<Type, ConstructorInfo> dict, Type type)
    {
        ConstructorInfo? constructor = GetElementConstructor(type);
        Debug.Assert(constructor != null);
        dict.Add(type, constructor);
    }

    private static ConstructorInfo? GetElementConstructor(Type type)
    {
        return type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, CtorParameters);
    }

    public static HtmlElement Instantiate(HtmlAgilityPack.HtmlNode xmlElement)
    {
        ConstructorInfo? constructor;

        if (xmlElement.Name == "input")
        {
            string typeValue = xmlElement.GetAttributeValue("type", "");
            InputType inputType = InputTypeUtility.Parse(typeValue);
            Type classType = InputTypeUtility.GetClassType(inputType);
            constructor = InputTypeConstructors[classType];
        }
        else if (ElementTypes.TryGetValue(xmlElement.Name, out Type? type))
        {
            constructor = TypeConstructors[type];
        }
        else
        {
            constructor = null;
        }

        if (constructor != null)
        {
            return (HtmlElement)constructor.Invoke(new object[] { xmlElement });
        }

        return new HtmlContainerElement(xmlElement);
    }

    public static TElement Instantiate<TElement>(HtmlAgilityPack.HtmlNode xmlElement) where TElement : HtmlElement
    {
        Type type = typeof(TElement);

        if (!InputTypeConstructors.TryGetValue(type, out ConstructorInfo? constructor))
        {
            constructor = TypeConstructors[type];
        }

        return (TElement)constructor.Invoke(new object[] { xmlElement });
    }

    public static string GetTagName<TElement>() where TElement : HtmlElement
    {
        if (typeof(TElement).IsAssignableTo(typeof(INPUT)))
        {
            return "input";
        }

        return ElementTypes.Reverse[typeof(TElement)];
    }
}
