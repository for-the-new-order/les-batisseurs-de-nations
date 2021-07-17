using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AntDesign;
using LesBatisseursDeNations.Data;

namespace LesBatisseursDeNations
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            ConfigureServices(builder.Services);

            // Set current language
            LocaleProvider.SetLocale("fr-FR");

            await builder.Build().RunAsync();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAntDesign();
            services.AddSingleton(new UserOptions());

            // Data
            services.AddSingleton<Database>();
            services.AddSingleton<ITwitchChannelsService, StaticDataService>();
            services.AddSingleton<IJournalEntriesService, StaticDataService>();
            services.AddSingleton<IPlayersService, StaticDataService>();
            services.AddSingleton<IEpisodesService, StaticDataService>();
        }
    }
}
