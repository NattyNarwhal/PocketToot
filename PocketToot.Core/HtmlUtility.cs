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
        const string EMOJI_REGEX_TEMPLATE = ":{0}:";
        const string EMOJI_IMAGE_TEMPLATE = "<img alt=\"{1}\" src=\"{0}\" width=\"{2}\" height=\"{2}\" />";

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

        public static string StatusContentsRenderingEmoji(Types.Status status, int size)
        {
            var content = status.Content;
            if (status.Emoji != null)
            {
                foreach (var emoji in status.Emoji)
                {
                    var tag = string.Format(EMOJI_IMAGE_TEMPLATE,
                        emoji.StaticUrl,
                        emoji.Shortcode,
                        size);
                    var shortcode = string.Format(EMOJI_REGEX_TEMPLATE, emoji.Shortcode);
                    content = Regex.Replace(content, shortcode, tag);
                }
            }
            return content;
        }
    }
}
