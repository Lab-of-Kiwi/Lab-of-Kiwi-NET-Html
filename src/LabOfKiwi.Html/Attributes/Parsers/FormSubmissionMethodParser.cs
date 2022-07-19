using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal readonly struct FormSubmissionMethodParser : IAttributeParser<FormSubmissionMethod>
{
    public bool IsValid(FormSubmissionMethod input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out FormSubmissionMethod output)
    {
        switch (input.ToLowerInvariant())
        {
            case "get":
                output = FormSubmissionMethod.GET;
                return true;
            case "post":
                output = FormSubmissionMethod.POST;
                return true;
            case "dialog":
                output = FormSubmissionMethod.Dialog;
                return true;
        }

        output = default;
        return false;
    }

    public bool TryToString(FormSubmissionMethod input, [MaybeNullWhen(false)] out string output)
    {
        switch (input)
        {
            case FormSubmissionMethod.GET:
                output = "GET";
                return true;
            case FormSubmissionMethod.POST:
                output = "POST";
                return true;
            case FormSubmissionMethod.Dialog:
                output = "dialog";
                return true;
        }

        output = default;
        return false;
    }
}
