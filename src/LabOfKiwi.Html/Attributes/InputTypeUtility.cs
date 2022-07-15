using LabOfKiwi.Collections;
using LabOfKiwi.Html.Elements;
using System;
using System.Diagnostics;

namespace LabOfKiwi.Html.Attributes;

internal static class InputTypeUtility
{
    private static ReadOnlyMap<InputType, string> InputTypeWebNames;
    private static ReadOnlyMap<InputType, Type> InputTypesClasses;

    static InputTypeUtility()
    {
        Map<InputType, string> map1 = new(22)
        {
            { InputType.Hidden, "hidden" },
            { InputType.Text, "text" },
            { InputType.Search, "search" },
            { InputType.Telephone, "tel" },
            { InputType.Url, "url" },
            { InputType.Email, "email" },
            { InputType.Password, "password" },
            { InputType.Date, "date" },
            { InputType.Month, "month" },
            { InputType.Week, "week" },
            { InputType.Time, "time" },
            { InputType.DateTimeLocal, "datetime-local" },
            { InputType.Number, "number" },
            { InputType.Range, "range" },
            { InputType.Color, "color" },
            { InputType.Checkbox, "checkbox" },
            { InputType.RadioButton, "radio" },
            { InputType.FileUpload, "file" },
            { InputType.SubmitButton, "submit" },
            { InputType.ImageButton, "image" },
            { InputType.ResetButton, "reset" },
            { InputType.Button, "button" }
        };

        Map<InputType, Type> map2 = new(22)
        {
            { InputType.Hidden, typeof(INPUT.Hidden) },
            { InputType.Text, typeof(INPUT.Text) },
            { InputType.Search, typeof(INPUT.Search) },
            { InputType.Telephone, typeof(INPUT.Telephone) },
            { InputType.Url, typeof(INPUT.Url) },
            { InputType.Email, typeof(INPUT.Email) },
            { InputType.Password, typeof(INPUT.Password) },
            { InputType.Date, typeof(INPUT.Date) },
            { InputType.Month, typeof(INPUT.Month) },
            { InputType.Week, typeof(INPUT.Week) },
            { InputType.Time, typeof(INPUT.Time) },
            { InputType.DateTimeLocal, typeof(INPUT.DateTimeLocal) },
            { InputType.Number, typeof(INPUT.Number) },
            { InputType.Range, typeof(INPUT.Range) },
            { InputType.Color, typeof(INPUT.Color) },
            { InputType.Checkbox, typeof(INPUT.Checkbox) },
            { InputType.RadioButton, typeof(INPUT.RadioButton) },
            { InputType.FileUpload, typeof(INPUT.FileUpload) },
            { InputType.SubmitButton, typeof(INPUT.SubmitButton) },
            { InputType.ImageButton, typeof(INPUT.ImageButton) },
            { InputType.ResetButton, typeof(INPUT.ResetButton) },
            { InputType.Button, typeof(INPUT.Button) }
        };

        InputTypeWebNames = map1.AsReadOnly();
        InputTypesClasses = map2.AsReadOnly();
    }

    public static InputType GetInputType(Type type)
    {
        Debug.Assert(type.IsAssignableTo(typeof(INPUT)));

        if (InputTypesClasses.Reverse.TryGetValue(type, out InputType result))
        {
            return result;
        }

        return InputType.Unknown;
    }

    public static string ToWebString(this InputType value)
    {
        Debug.Assert(value != InputType.Unknown);
        return InputTypeWebNames[value];
    }

    public static Type GetClassType(this InputType value)
    {
        if (InputTypesClasses.TryGetValue(value, out Type? type))
        {
            return type;
        }

        return typeof(INPUT);
    }

    public static InputType Parse(string? input)
    {
        if (input != null && InputTypeWebNames.Reverse.TryGetValue(input, out InputType output))
        {
            return output;
        }

        return InputType.Unknown;
    }
}