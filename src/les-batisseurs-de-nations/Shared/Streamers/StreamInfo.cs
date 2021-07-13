using AntDesign;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LesBatisseursDeNations.Shared.Streamers
{
    public class StreamInfo
    {
        public int EpisodeNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Streamer Streamer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string YouTubeEmbededUri { get; set; }
        public string DiscordLink { get; set; }
        public string EpisodeEntryLink { get; set; }

        //public HashSet<StreamInfoAction> Actions { get; } = new();

        public StreamState State => GetStreamState();

        public bool HasEpisodeEntryLink => !string.IsNullOrEmpty(EpisodeEntryLink);
        public bool HasDiscordLink => !string.IsNullOrEmpty(DiscordLink);
        public bool HasYouTubeUri => !string.IsNullOrEmpty(YouTubeEmbededUri);
        public bool HasTitle => !string.IsNullOrEmpty(Title);

        private StreamState GetStreamState()
        {
            var now = DateTime.UtcNow.ConvertUtcToEasternTime();
            var soonBeforeStart = StartDate.AddMinutes(-30);
            var soonAfterEnd = StartDate.AddMinutes(30);
            return now switch
            {
                { } when now < soonBeforeStart => StreamState.Future,
                { } when now >= soonBeforeStart && now < StartDate => StreamState.StartingSoon,
                { } when now >= StartDate && now < EndDate => StreamState.Playing,
                { } when now >= EndDate && now < soonAfterEnd => StreamState.MightStillBeOn,
                _ => StreamState.Ended,
            };
        }
    }

    public enum StreamState
    {
        Ended,
        Playing,
        StartingSoon,
        Future,
        MightStillBeOn,
    }

    public class StreamInfoAction
    {
        public string Title { get; set; }
        public string Href { get; set; }
        public Icon Icon { get; set; }

        public HashSet<StreamInfoActionDisplayRule> DisplayRules { get; } = new();
    }

    public abstract record StreamInfoActionDisplayRule(StreamState State, Func<StreamState, bool> AllowsDelegate)
    {
        public virtual bool Allows(StreamState state) => AllowsDelegate(state);
    }

    public static class StreamInfoActionExtensions
    {
        private record AnyDisplayRule(StreamState State, StreamInfoAction Action)
            : StreamInfoActionDisplayRule(State, state => Action.DisplayRules.Any(x => x.State == state));

        public static StreamInfoAction AddDisplayRule(this StreamInfoAction info, StreamInfoActionDisplayRule rule)
        {
            info.DisplayRules.Add(rule);
            return info;
        }

        public static StreamInfoAction Include(this StreamInfoAction info, params StreamState[] states)
        {
            foreach (var state in states)
            {
                info.AddDisplayRule(new AnyDisplayRule(state, info));
            }
            return info;
        }

        public static StreamInfoAction Exclude(this StreamInfoAction info, params StreamState[] states)
        {
            HashSet<int> indexesToRemoves = new();
            for (int i = 0; i < info.DisplayRules.Count; i++)
            {
                var rule = info.DisplayRules.ElementAt(i);
                foreach (var state in states)
                {
                    if(state == rule.State)
                    {
                        indexesToRemoves.Add(i);
                    }
                }
            }
            foreach (var index in indexesToRemoves.Reverse())
            {
                var item = info.DisplayRules.ElementAt(index);
                info.DisplayRules.Remove(item);
            }
            return info;
        }
    }

    //public static class StreamInfoExtensions
    //{
    //    public static StreamInfo IN_POGRESS(this StreamInfo info)
    //    {
    //        info.Actions.Add(new()
    //        {
                
    //        });
    //        return info;
    //    }
    //}
}
