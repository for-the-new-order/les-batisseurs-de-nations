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
        public static string GetPlayDescription(this EpisodeInfo episode, UserOptions options) => episode.State switch
        {
            StreamState.Ended => $"L'épisode a joué {episode.StartDate.ToString("dddd le d MMMM yyyy", options.Culture)}",
            _ when episode.StartDate.DayOfYear == episode.EndDate.DayOfYear => $"Débute {episode.StartDate.ToString("dddd le d MMMM yyyy à h\\:mm tt", options.Culture)} à {episode.EndDate.ToString("h\\:mm tt", options.Culture)} (GMT{DateTimeExtensions.EasternZone.BaseUtcOffset.Hours})",
            _ => $"Débute {episode.StartDate.ToString("dddd le d MMMM yyyy à h\\:mm tt", options.Culture)} et prend fin {episode.EndDate.ToString("dddd le d MMMM yyyy à h\\:mm tt", options.Culture)} (GMT{DateTimeExtensions.EasternZone.BaseUtcOffset.Hours})",
        };
    }
}
