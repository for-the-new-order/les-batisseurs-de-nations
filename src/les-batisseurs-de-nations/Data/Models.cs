using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesBatisseursDeNations.Data
{
    public record EpisodeInfo(
        int Season, 
        int Episode,
        string Title,
        string Description,
        TwitchChannel Streamer,
        DateTime StartDate, 
        DateTime EndDate, 
        string YouTubeEmbededUri, 
        string DiscordLink,
        IEnumerable<Player> Players,
        IEnumerable<JournalEntry> JournalEntries
    )
    {
        public StreamState State => GetStreamState();

        public bool HasJournalEntries => JournalEntries != null && JournalEntries.Any();
        public bool HasPlayers => Players != null && Players.Any();
        public bool HasDiscordLink => !string.IsNullOrEmpty(DiscordLink);
        public bool HasYouTubeUri => !string.IsNullOrEmpty(YouTubeEmbededUri);
        public bool HasTitle => !string.IsNullOrEmpty(Title);
        public bool HasDescription => !string.IsNullOrEmpty(Description);

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
    public record JournalEntry(Player Author, DateTime PublishedDate, string Content)
    {
        public string Title { get; init; }
        public string Abstract { get; init; }

        public bool HasTitle => !string.IsNullOrEmpty(Title);
        public bool HasAbstract => !string.IsNullOrEmpty(Abstract);
    }
    public record Player(
        int Id, 
        string DisplayName, 
        string ProfileImageUri, 
        string CharacterSheetUri, 
        string CharacterSheetImageUri,
        bool IsTeamMember
    )
    {
        public bool HasProfileImageUri => !string.IsNullOrEmpty(ProfileImageUri);
        public bool HasCharacterSheetUri => !string.IsNullOrEmpty(CharacterSheetUri);
        public bool HasCharacterSheetImageUri => !string.IsNullOrEmpty(CharacterSheetImageUri);
    }
    public record TwitchChannel(Streamer StreamerId, string DisplayName, string ProfileImageUri, string ChannelUri);

    public enum Streamer
    {
        FenyxLair,
        OnStartTuCa,
        Puppo,
    }

    public enum StreamState
    {
        Ended,
        Playing,
        StartingSoon,
        Future,
        MightStillBeOn,
    }

    public record Season(int Number, IEnumerable<int> EpisodesNumber);
}
