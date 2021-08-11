using LesBatisseursDeNations.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LesBatisseursDeNations.Shared
{
    public class RefreshLiveStream : ComponentBase
    {
        public const double OneHour = 3600000;
        private Timer redrawTimer = new Timer();

        [Parameter]
        public Action StateHasChangedDelegate { get; set; }

        [Parameter]
        public EpisodeInfo NextEpisode { get; set; }

        protected override void OnParametersSet()
        {
            var firstInterval = GetRefreshInterval();
            if(firstInterval <= 0) {
                redrawTimer.Close();
                return;
            }

            redrawTimer.Interval = firstInterval;
            redrawTimer.Elapsed += (_, _) =>
            {
                Console.WriteLine($"redrawTimer.Elapsed; IsLive: {NextEpisode.IsLive}");
                if (NextEpisode.IsLive)
                {
                    Console.WriteLine("Redrawing");
                    redrawTimer.Stop();
                    StateHasChangedDelegate();
                }
                else
                {
                    var newInterval = GetRefreshInterval();
                    if (newInterval != redrawTimer.Interval)
                    {
                        redrawTimer.Interval = newInterval;
                    }
                }
            };
            redrawTimer.Start();
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
