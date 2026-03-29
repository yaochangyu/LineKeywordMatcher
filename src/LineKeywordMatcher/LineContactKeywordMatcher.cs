namespace LineKeywordMatcher;

public static class LineContactKeywordMatcher
{
    public static bool ContainsLineKeyword(string input)
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

        var span = buffer[..len];

        return span.IndexOf("留下line".AsSpan()) >= 0
            || span.IndexOf("留下賴".AsSpan()) >= 0;
    }
}
