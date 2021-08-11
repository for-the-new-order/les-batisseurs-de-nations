using LesBatisseursDeNations.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesBatisseursDeNations.Shared
{
    public class RefreshLiveStream : ComponentBase
    {
        public const double OneHour = 3600000;
        private readonly System.Timers.Timer _redrawTimer = new();

        [Parameter]
        public Action StateHasChangedDelegate { get; set; }

        [Parameter]
        public EpisodeInfo NextEpisode { get; set; }

        protected override void OnParametersSet()
        {
            var firstInterval = GetRefreshInterval();
            if(firstInterval <= 0) {
                _redrawTimer.Close();
                return;
            }

            _redrawTimer.Interval = firstInterval;
            _redrawTimer.Elapsed += (_, _) =>
            {
                Console.WriteLine($"redrawTimer.Elapsed; IsLive: {NextEpisode.IsLive}");
                if (NextEpisode.IsLive)
                {
                    Console.WriteLine("Redrawing");
                    _redrawTimer.Stop();
                    StateHasChangedDelegate();
                }
                else
                {
                    var newInterval = GetRefreshInterval();
                    if (newInterval != _redrawTimer.Interval)
                    {
                        _redrawTimer.Interval = newInterval;
                    }
                }
            };
            _redrawTimer.Start();
        }

        private double GetRefreshInterval()
        {
            var now = DateTime.UtcNow.ConvertUtcToEasternTime();
            var nextEpisodeIsIn = NextEpisode.SoonBeforeStart - now;
            var interval = nextEpisodeIsIn.TotalMilliseconds < OneHour
                ? nextEpisodeIsIn.TotalMilliseconds
                : OneHour;
            Console.WriteLine($"Next refresh interval in {interval} ms.");
            return interval;
        }
    }
}
