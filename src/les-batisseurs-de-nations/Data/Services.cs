using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesBatisseursDeNations.Data
{
    public interface IPlayersService
    {
        Task<IEnumerable<Player>> AllAsync();
    }
    public interface ITwitchChannelsService
    {
        Task<IEnumerable<TwitchChannel>> AllAsync();
    }
    public interface IEpisodesService
    {
        Task<IEnumerable<EpisodeInfo>> AllAsync();
        Task<EpisodeInfo> FindAsync(int seasonNumber, int episodeNumber);
        Task<IEnumerable<Season>> AllSeasons();
    }

    public class StaticDataService : IPlayersService, ITwitchChannelsService, IEpisodesService
    {
        private readonly Database _database;
        public StaticDataService(Database database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        Task<IEnumerable<TwitchChannel>> ITwitchChannelsService.AllAsync()
        {
            return Task.FromResult(_database.TwitchChannels.AsEnumerable());
        }

        Task<IEnumerable<Player>> IPlayersService.AllAsync()
        {
            return Task.FromResult(_database.Players.AsEnumerable());
        }

        Task<IEnumerable<EpisodeInfo>> IEpisodesService.AllAsync()
        {
            return Task.FromResult(_database.Episodes.AsEnumerable());
        }

        Task<IEnumerable<Season>> IEpisodesService.AllSeasons()
        {
            var seasons = _database.Episodes
                .Select(x => x.Season)
                .Distinct()
                .OrderBy(x => x)
                .Select(seasonNumber => new Season(
                    seasonNumber, 
                    _database.Episodes
                        .Where(e => e.Season == seasonNumber)
                        .OrderBy(x => x.Number)
                ));
            return Task.FromResult(seasons);
        }

        Task<EpisodeInfo> IEpisodesService.FindAsync(int seasonNumber, int episodeNumber)
        {
            var episode = _database.Episodes
                .FirstOrDefault(x => x.Season == seasonNumber && x.Number == episodeNumber);
            return Task.FromResult(episode);
        }
    }
}
