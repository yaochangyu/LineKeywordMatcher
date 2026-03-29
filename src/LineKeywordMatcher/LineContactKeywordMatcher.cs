namespace LineKeywordMatcher;

public class LineContactKeywordMatcher
{
    private readonly string[] _normalizedKeywords;

    public LineContactKeywordMatcher(IEnumerable<string> keywords)
    {
        _normalizedKeywords = keywords
            .Select(k => Normalize(k))
            .ToArray();
    }

    public bool ContainsLineKeyword(string input)
    {
        var normalized = Normalize(input);
        return _normalizedKeywords.Any(k => normalized.Contains(k, StringComparison.Ordinal));
    }

    public bool ContainsLineKeywordInHtml(string html)
    {
        var text = HtmlTextExtractor.ExtractText(html);
        return ContainsLineKeyword(text);
    }

    private static string Normalize(string input)
    {
        Span<char> buffer = stackalloc char[input.Length];
        var len = 0;

        foreach (var c in input)
        {
            if (char.IsWhiteSpace(c) || c == '\u3000')
                continue;

            var ch = (c >= '\uFF01' && c <= '\uFF5E')
                ? (char)(c - 0xFEE0)
                : c;

            buffer[len++] = char.ToLowerInvariant(ch);
        }

        return buffer[..len].ToString();
    }
}
