namespace LabOfKiwi.Html.Attributes.Parsers;

public readonly struct AcceptParser : IAttributeParser<string, StringParser>
{
    private static readonly string[] Predefined = new string[]
    {
        "audio/*", "video/*", "image/*"
    };

    public bool IsValid(string input)
    {
        if (Predefined.Contains(input)) return true;

        if (input.Length == 0) return false;

        if (input[0] == '/' || input[^1] == '/') return false;

        int slashCount = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '/') slashCount++;
            if (input[i] == ';') return false;
            if (input[i] == '*') return false;
        }

        return slashCount == 1;
    }
}
