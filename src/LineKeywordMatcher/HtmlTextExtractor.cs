using System.Net;
using HtmlAgilityPack;

namespace LineKeywordMatcher;

internal static class HtmlTextExtractor
{
    internal static string ExtractText(string html)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(html);
        var raw = doc.DocumentNode.InnerText;
        return WebUtility.HtmlDecode(raw).Replace('\u00A0', ' ');
    }
}
