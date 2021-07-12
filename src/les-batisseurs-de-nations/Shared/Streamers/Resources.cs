using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesBatisseursDeNations.Shared.Streamers
{
    public class Resources
    {
        private static readonly string puppoCoverImage = "https://static-cdn.jtvnw.net/jtv_user_pictures/3b4741ae-b5a6-4d27-baf4-45daa3eaa018-profile_image-150x150.png";
        private static readonly string onStartTuCaCoverImage = "https://static-cdn.jtvnw.net/jtv_user_pictures/ebc91ff6-d4e4-4c44-944f-77abe9f47870-profile_image-150x150.png";
        private static readonly string fenyxCoverImage = "https://static-cdn.jtvnw.net/jtv_user_pictures/ffb95186-aa34-46b1-a17e-6842467f3603-profile_image-150x150.png";

        public static string AvatarUri(Streamer streamer) => streamer switch
        {
            Streamer.Puppo => puppoCoverImage,
            Streamer.FenyxLair => fenyxCoverImage,
            _ => onStartTuCaCoverImage,
        };
        public static string StreamerName(Streamer streamer) => streamer switch
        {
            Streamer.Puppo => "Pour une poignee de pieces d'or",
            Streamer.FenyxLair => "The Fenyx Lair",
            _ => "On start tu ça?",
        };
        public static string StreamerChannelLink(Streamer streamer) => streamer switch
        {
            Streamer.Puppo => "https://www.twitch.tv/pourunepoigneedepiecesdor",
            Streamer.FenyxLair => "https://www.twitch.tv/thefenyxlair",
            _ => "https://www.twitch.tv/onstarttuca",
        };
    }
}
