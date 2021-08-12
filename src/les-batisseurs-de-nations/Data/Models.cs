using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesBatisseursDeNations.Data
{
    public record EpisodeInfo(
        int Season, 
        int Number,
        string Title,
        string Description,
        TwitchChannel Streamer,
        DateTime StartDate, 
        DateTime EndDate,
        string TwitchVideoId,
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
        public bool HasTwitchVideoId => !string.IsNullOrEmpty(TwitchVideoId);
        public bool HasTitle => !string.IsNullOrEmpty(Title);
        public bool HasDescription => !string.IsNullOrEmpty(Description);

        public bool HasTeamMembers => Players.Any(x => x.IsTeamMember);

        public DateTime SoonBeforeStart => StartDate.AddMinutes(-30);
        public DateTime SoonAfterEnd => EndDate.AddMinutes(30);

        private readonly StreamState[] _liveState = new[] { StreamState.StartingSoon, StreamState.Playing, StreamState.MightStillBeOn };
        public bool IsLive => _liveState.Contains(State);


        private StreamState GetStreamState()
        {
            var now = DateTime.UtcNow.ConvertUtcToEasternTime();
            return now switch
            {
                { } when now < SoonBeforeStart => StreamState.Future,
                { } when now >= SoonBeforeStart && now < StartDate => StreamState.StartingSoon,
                { } when now >= StartDate && now < EndDate => StreamState.Playing,
                { } when now >= EndDate && now < SoonAfterEnd => StreamState.MightStillBeOn,
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
    public record TwitchChannel(Streamer StreamerId, string DisplayName, string ProfileImageUri, string ChannelUri, string ChannelName);

    public enum Streamer
    {
        FenyxLair,
        OnStartTuCa,
        Puppo,
        Havgood,
    }

    public enum StreamState
    {
        Ended,
        Playing,
        StartingSoon,
        Future,
        MightStillBeOn,
    }

    public record Season(int Number, IEnumerable<EpisodeInfo> Episodes);
}
