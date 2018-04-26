using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PocketToot
{
    public static class HtmlUtility
    {
        const string HTML_TAG_REGEX = "<[^>]+>";
        const string NEWLINE_REGEX = @"\r?\n";

        public static string ToPlainText(string html)
        {
            // first strip tags
            var stripped = html;
            stripped = Regex.Replace(html, HTML_TAG_REGEX, "");
            // because we're putting it on a single line entity, newln->space
            stripped = Regex.Replace(stripped, NEWLINE_REGEX, " ");
            // now entities...
            // TODO: entities
            return stripped;
        }
    }
}
