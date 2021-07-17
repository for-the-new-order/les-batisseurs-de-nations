using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesBatisseursDeNations.Data
{
    public interface IJournalEntriesService
    {
        Task<IEnumerable<JournalEntry>> AllAsync();
    }
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
    }

    public class StaticDataService : IJournalEntriesService, IPlayersService, ITwitchChannelsService, IEpisodesService
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

        Task<IEnumerable<JournalEntry>> IJournalEntriesService.AllAsync()
        {
            var entries = _database.Episodes
                .Where(e => e.HasJournalEntries)
                .SelectMany(e => e.JournalEntries)
            ;
            return Task.FromResult(entries);
        }

        Task<IEnumerable<EpisodeInfo>> IEpisodesService.AllAsync()
        {
            return Task.FromResult(_database.Episodes.AsEnumerable());
        }
    }
}
