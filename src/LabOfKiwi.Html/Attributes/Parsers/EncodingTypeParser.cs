using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal readonly struct EncodingTypeParser : IAttributeParser<EncodingType>
{
    public bool IsValid(EncodingType input)
    {
        return true;
    }

    public bool TryParse(string input, [MaybeNullWhen(false)] out EncodingType output)
    {
        switch (input)
        {
            case "application/x-www-form-urlencoded":
                output = EncodingType.UrlEncoded;
                return true;
            case "multipart/form-data":
                output = EncodingType.MultipartFormData;
                return true;
            case "text/plain":
                output = EncodingType.PlainText;
                return true;
        }

        output = default;
        return false;
    }

    public bool TryToString(EncodingType input, [MaybeNullWhen(false)] out string output)
    {
        switch (input)
        {
            case EncodingType.UrlEncoded:
                output = "application/x-www-form-urlencoded";
                return true;
            case EncodingType.MultipartFormData:
                output = "multipart/form-data";
                return true;
            case EncodingType.PlainText:
                output = "text/plain";
                return true;
        }

        output = default;
        return false;
    }
}
