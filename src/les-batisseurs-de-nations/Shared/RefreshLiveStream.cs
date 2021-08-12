using LesBatisseursDeNations.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LesBatisseursDeNations.Shared
{
    public class RefreshLiveStream : ComponentBase
    {
        public const double OneHour = 3600000;
        private readonly System.Timers.Timer _redrawTimer = new();
        private Queue<double> _delays = new Queue<double>();

        [Parameter]
        public Action StateHasChangedDelegate { get; set; }

        [Parameter]
        public EpisodeInfo NextEpisode { get; set; }

        [Parameter]
        public bool RefreshAfterEnded { get; set; }


        protected override void OnParametersSet()
        {
            ConfigureDelays();

            _redrawTimer.Interval = DequeueNextInterval();
            _redrawTimer.Elapsed += (_, _) =>
            {
                if (NextEpisode.State != StreamState.Ended || (NextEpisode.State == StreamState.Ended && RefreshAfterEnded))
                {
                    StateHasChangedDelegate();
                }
                _redrawTimer.Interval = DequeueNextInterval();
            };
            _redrawTimer.Start();

            double DequeueNextInterval()
            {
                if(_delays.Count == 0)
                {
                    Console.WriteLine($"DequeueNextInterval: {OneHour}");
                    return OneHour;
                }
                var next = _delays.Dequeue();
                Console.WriteLine($"DequeueNextInterval: {next}");
                return next;
            }

            //var firstInterval = GetRefreshInterval();
            //if(firstInterval <= 0) {
            //    _redrawTimer.Close();
            //    return;
            //}

            //_redrawTimer.Interval = firstInterval;
            //_redrawTimer.Elapsed += (_, _) =>
            //{
            //    Console.WriteLine($"redrawTimer.Elapsed; IsLive: {NextEpisode.IsLive}");
            //    if (NextEpisode.IsLive)
            //    {
            //        Console.WriteLine("Redrawing");
            //        if (RefreshAfterEnded)
            //        {
            //            _redrawTimer.Interval = OneHour;
            //        }
            //        else
            //        {
            //            _redrawTimer.Stop();
            //        }
            //        StateHasChangedDelegate();
            //    }
            //    else if(NextEpisode.State == StreamState.Ended)
            //    {
            //        StateHasChangedDelegate();
            //    }
            //    else
            //    {
            //        var newInterval = GetRefreshInterval();
            //        if (newInterval != _redrawTimer.Interval)
            //        {
            //            _redrawTimer.Interval = newInterval;
            //        }
            //    }
            //};
            //_redrawTimer.Start();
        }

        private void ConfigureDelays()
        {
            var now = DateTime.UtcNow.ConvertUtcToEasternTime();
            var nextEpisodeIsIn = NextEpisode.SoonBeforeStart - now;
            var nextEpisodeStartsAt = NextEpisode.StartDate - now;
            var nextEpisodeShouldEndAt = NextEpisode.EndDate - now;
            var nextEpisodeEndsAt = NextEpisode.SoonAfterEnd - now;

            Console.WriteLine($"NextEpisode.State: {NextEpisode.State}");

            switch (NextEpisode.State)
            {
                case StreamState.Future:
                    if (nextEpisodeIsIn.TotalMilliseconds > 0) { _delays.Enqueue(nextEpisodeIsIn.TotalMilliseconds); }
                    if (nextEpisodeStartsAt.TotalMilliseconds > 0) { _delays.Enqueue(nextEpisodeStartsAt.TotalMilliseconds); }
                    if (nextEpisodeShouldEndAt.TotalMilliseconds > 0) { _delays.Enqueue(nextEpisodeShouldEndAt.TotalMilliseconds); }
                    if (nextEpisodeEndsAt.TotalMilliseconds > 0) { _delays.Enqueue(nextEpisodeEndsAt.TotalMilliseconds); }
                    break;
                case StreamState.StartingSoon:
                    if (nextEpisodeStartsAt.TotalMilliseconds > 0) { _delays.Enqueue(nextEpisodeStartsAt.TotalMilliseconds); }
                    if (nextEpisodeShouldEndAt.TotalMilliseconds > 0) { _delays.Enqueue(nextEpisodeShouldEndAt.TotalMilliseconds); }
                    if (nextEpisodeEndsAt.TotalMilliseconds > 0) { _delays.Enqueue(nextEpisodeEndsAt.TotalMilliseconds); }
                    break;
                case StreamState.Playing:
                    if (nextEpisodeShouldEndAt.TotalMilliseconds > 0) { _delays.Enqueue(nextEpisodeShouldEndAt.TotalMilliseconds); }
                    if (nextEpisodeEndsAt.TotalMilliseconds > 0) { _delays.Enqueue(nextEpisodeEndsAt.TotalMilliseconds); }
                    break;
                case StreamState.MightStillBeOn:
                    if (nextEpisodeEndsAt.TotalMilliseconds > 0) { _delays.Enqueue(nextEpisodeEndsAt.TotalMilliseconds); }
                    break;
            }
        }

        //private double GetRefreshInterval()
        //{
        //    var now = DateTime.UtcNow.ConvertUtcToEasternTime();
        //    if(RefreshAfterEnded && now > NextEpisode.StartDate)
        //    {
        //        Console.WriteLine($"RefreshAfterEnded: {RefreshAfterEnded} | OneHour: {OneHour}");
        //        //return OneHour;
        //        return 5000;
        //    }
        //    var nextEpisodeIsIn = NextEpisode.SoonBeforeStart - now;
        //    if(nextEpisodeIsIn.TotalMilliseconds <= 0)
        //    {
        //        nextEpisodeIsIn = NextEpisode.StartDate - now;
        //    }
        //    var interval = nextEpisodeIsIn.TotalMilliseconds < OneHour
        //        ? nextEpisodeIsIn.TotalMilliseconds
        //        : OneHour;
        //    Console.WriteLine($"Next refresh interval in {interval} ms.");
        //    return interval;
        //}
    }
}
