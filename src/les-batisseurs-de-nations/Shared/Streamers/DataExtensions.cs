using LesBatisseursDeNations.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LesBatisseursDeNations.Shared.Streamers
{
    public static class DataExtensions
    {
        public static MarkupString GenerateAbstractFromContent(this JournalEntry entry)
        {
            const int maxLength = 500;
            if (entry.Content.Length < maxLength)
            {
                return (MarkupString)entry.Content;
            }
            var markupRegex = new Regex("<[^>]>");
            var cleanedContent = markupRegex.Replace(entry.Content, "", 50);
            var clippedContent = cleanedContent.Substring(0, maxLength);
            var lastSpaceIndex = clippedContent.LastIndexOf(' ');
            var result = clippedContent.Substring(0, lastSpaceIndex) + "...";
            return (MarkupString)result;
        }
    }
}
