using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LesBatisseursDeNations.Data
{
    public class Database
    {
        public HashSet<Player> Players { get; } = new();
        public HashSet<TwitchChannel> TwitchChannels { get; } = new();
        public HashSet<EpisodeInfo> Episodes { get; } = new();

        public Database() => Seed();

        public void Seed()
        {
            // Players (team)
            var mamita = AddPlayer(new(
                Id: 1,
                DisplayName: "Mamita Lalouche Forgefeu",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/players/members/Mamita-Token.jpeg",
                CharacterSheetUri: "https://www.dndbeyond.com/characters/52417643",
                CharacterSheetImageUri: "https://media-waterdeep.cursecdn.com/avatars/18919/69/character-52417643.jpeg",
                IsTeamMember: true
            ));
            var gur = AddPlayer(new(
                Id: 2,
                DisplayName: "Gur Forgefeu",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/players/members/Gur-Token.jpeg",
                CharacterSheetUri: "https://www.dndbeyond.com/characters/37257773",
                CharacterSheetImageUri: "https://media-waterdeep.cursecdn.com/avatars/18919/106/character-37257773.jpeg",
                IsTeamMember: true
            ));
            var kilmi = AddPlayer(new(
                Id: 3,
                DisplayName: "Kilmi Forgefeu",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/players/members/Kilmi-Token.png",
                CharacterSheetUri: "https://www.dndbeyond.com/characters/53146981",
                CharacterSheetImageUri: "https://media-waterdeep.cursecdn.com/avatars/19098/543/character-53146981.jpeg",
                IsTeamMember: true
            ));
            var dhanlbek = AddPlayer(new(
                Id: 4,
                DisplayName: "Dhan'lbek Gardefeu",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/players/members/Dhanlbek-Token.jpeg",
                CharacterSheetUri: "https://www.dndbeyond.com/characters/53047510",
                CharacterSheetImageUri: "https://media-waterdeep.cursecdn.com/avatars/18919/152/character-53047510.jpeg",
                IsTeamMember: true
            ));

            // Players (non-team)
            var nalvyna = AddPlayer(new(
                Id: 100,
                DisplayName: "Nalvyna",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/players/others/Nalvyna-Token.jpeg",
                CharacterSheetUri: "https://www.dndbeyond.com/characters/52176074",
                CharacterSheetImageUri: "https://media-waterdeep.cursecdn.com/avatars/18926/858/character-52176074.jpeg",
                IsTeamMember: false
            ));

            // Other players
            var other1 = AddPlayer(new(
                Id: -1,
                DisplayName: "Autre joueur 1",
                ProfileImageUri: "",
                CharacterSheetUri: "",
                CharacterSheetImageUri: "",
                IsTeamMember: false
            ));
            var other2 = AddPlayer(new(
                Id: -2,
                DisplayName: "Autre joueur 2",
                ProfileImageUri: "",
                CharacterSheetUri: "",
                CharacterSheetImageUri: "",
                IsTeamMember: false
            ));
            var other3 = AddPlayer(new(
                Id: -3,
                DisplayName: "Autre joueur 3",
                ProfileImageUri: "",
                CharacterSheetUri: "",
                CharacterSheetImageUri: "",
                IsTeamMember: false
            ));
            var other4 = AddPlayer(new(
                Id: -4,
                DisplayName: "Autre joueur 4",
                ProfileImageUri: "",
                CharacterSheetUri: "",
                CharacterSheetImageUri: "",
                IsTeamMember: false
            ));
            var other5 = AddPlayer(new(
                Id: -5,
                DisplayName: "Autre joueur 5",
                ProfileImageUri: "",
                CharacterSheetUri: "",
                CharacterSheetImageUri: "",
                IsTeamMember: false
            ));

            // TwitchChannels
            var onStartTuCa = AddTwitchChannel(new(
                StreamerId: Streamer.OnStartTuCa,
                DisplayName: "On start tu ça?",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/streamers/onstarttuca-profile_image-150x150.png",
                ChannelUri: "https://www.twitch.tv/onstarttuca"
            ));
            var fenyxLair = AddTwitchChannel(new(
                StreamerId: Streamer.FenyxLair,
                DisplayName: "The Fenyx Lair",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/streamers/fenyx-profile_image-150x150.png",
                ChannelUri: "https://www.twitch.tv/thefenyxlair"
            ));
            var puppo = AddTwitchChannel(new(
                StreamerId: Streamer.Puppo,
                DisplayName: "Pour une poignee de pieces d'or",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/streamers/puppo-profile_image-150x150.png",
                ChannelUri: "https://www.twitch.tv/pourunepoigneedepiecesdor"
            ));
            var havgood = AddTwitchChannel(new(
                StreamerId: Streamer.Havgood,
                DisplayName: "havgood",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/streamers/havgood-profile_image-150x150.png",
                ChannelUri: "https://www.twitch.tv/havgood"
            ));

            // Episodes
            Episodes.Add(new(
                Season: 1,
                Number: 1,
                Title: "Ouverture du Westmarch des terres perdues",
                Description: "",
                Streamer: onStartTuCa,
                StartDate: new DateTime(2021, 07, 09, 20, 0, 0),
                EndDate: new DateTime(2021, 07, 09, 23, 0, 0),
                YouTubeEmbededUri: "https://www.youtube.com/embed/yt4xTDlBOQs",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860272989106339850",
                Players: new[] { kilmi, gur, mamita, dhanlbek, nalvyna },
                JournalEntries: new[]
                {
                    new JournalEntry(
                        Author: mamita,
                        PublishedDate: new(2021, 7, 11),
                        Content: "<p>Après un voyage en mer de quelques semaines qui nous ont semblé interminables, je dois bien l’avouer, nous sommes enfin arrivés mes frères, mon cousin et moi sur les Terres perdues. Les nains n’ont pas tous le pied marin (je fais surtout référence à Gur qui n’a pas cessé de rendre à la mer tout ce que je lui donnais à manger). Ces terres m’ont semblé à la fois dangereuses et remplies de la promesse d’un avenir prospère. Je dois dire que ma famille et moi chérissons le même rêve de bâtir une nouvelle nation forte et soudée de la trempe des nains de Norgorof, notre montagne adorée.</p><p>En arrivant au campement de base, qui est en fait un navire échoué qui a été renversé, nous avons pu voir la partie de la carte des lieux qui a été retrouvée. Sur celle-ci, il y avait un dessin représentant une pioche. Il ne nous en fallait pas plus pour nous convaincre de la première destination à atteindre. Une mine, notre future mine, devait nous attendre patiemment à seulement quelques jours de marche. Nous voyant partir, une elfe du nom de Nalvyna, qui voulait faire partie de la première expédition, s’est jointe à notre groupe. Je l’ai trouvée bien courageuse de vouloir s’acoquiner dès le départ avec quatre nains bien téméraires, mais je l’ai trouvée aussi un peu particulière, puisque je n’avais jamais vu un elfe avec ce genre de teint. J’ai tout d’abord cru qu’elle avait été très malade durant le trajet en mer (Gur n’avait pas bonne mine lui non plus), mais elle m’a dit qu’elle venait de sous la terre, alors ceci expliquait peut-être cela. N’empêche qu’il me semblait qu’un bon repas copieux lui redonnerait un peu de fraîcheur et pour cela, elle pouvait maintenant compter sur mes services.</p><p>Bref, nous sommes partis tous les cinq en direction du nord en suivant le chemin qui longeait le fleuve. Tout est bien différent de ce que nous sommes habitués de voir. Les palmiers côtoient les conifères, il y a des zones où le silence règne en maître, car les animaux ne s’y aventurent jamais, si bien que nous avons cru, l’espace d’un instant, que nous ne pourrions jamais trouver quelque espèce que ce soit à chasser en ces lieux. La cuisinière en moi était fort dépitée par cette nouvelle. La possible présence de champignons qui pourraient agrémenter mes recettes me faisait l’effet d’un petit baume au cœur, mais la peur de ne pouvoir nourrir ma famille aussi bien qu’à l’habitude me tenaillait toujours. Toutefois, je vous rassure tout de suite, il est très possible de pêcher (nous avons d’ailleurs attrapé un spécimen des plus étranges qui avait bien plus d’yeux qu’il n’en faut pour voir sous l’eau, mais qui était fort délicieux) et il y a aussi la Forêt du Loup Transplaneur qui grouille de bêtes en tout genre.</p><p>Sur le chemin nous menant à notre destin glorieux, nous avons croisé un cadavre desséché qui devait jadis être un aventurier elfe. Nalvyna s’y est intéressé pendant que, de notre côté, nous étions plutôt absorbés par la contemplation d’une exceptionnelle réalisation naine datant de plusieurs milliers d’années. Il semblerait que le chemin de pierres avait été fait par la troisième dynastie naine de Pointe-Fer. Cette découverte nous rapprochait davantage de notre but ultime! Pendant ce temps, Nalvyna qui fouillait le sac du mort a aussi fait une importante découverte pour la communauté. Elle a découvert une tonne de pièces d’or frappées du symbole du gantelet de la dynastie Pointe-Fer et quelques pierres précieuses! Voilà qui sera bien profitable pour l’établissement en ces terres hostiles.</p><p>Après avoir fait une sépulture au cadavre inconnu, en lui laissant quelques piécettes pour payer son passage, nous avons continué notre chemin en empruntant la route de pierres, ce qui nous a conduits dans la forêt. Celle-ci étant tellement dense qu’elle nous coupait la lumière du jour. Nous avons survécu de justesse à bons nombres de grands dangers : des créatures gigantesques aux dents acérées, des feuilles aussi coupantes que des lames de rasoir et aussi résistantes que la pierre, des crevasses formées par la végétation, etc. La première nuit est arrivée et nous avons dû établir un campement pour dormir. Ce qui est à la fois le plus étrange et le plus magnifique, c’est que la nuit est plus éclairée que le jour dans cette forêt, puisque tout est phosphorescent et émet de la lumière colorée. C’est un spectacle qu’il faut voir au moins une fois dans sa vie. Nous nous sommes même demandé s’il ne serait pas préférable de chasser pendant la nuit, car les animaux y sont plus visibles.</p><p>Le tour de garde de Gur venait de commencer lorsqu’un loup immense s’est approché du camp. À grands coups de marteau de guerre sur son bouclier, Gur nous a tous réveillés. Le loup a ensuite couru jusqu’au milieu du campement pour prendre un sac, puis il s’est volatilisé devant nos yeux. C’était le sac de Dhan’Lbek qui contenait son livre de magie et tous ses papiers de cartographe. Ce mystère du Loup transplaneur l’a obnubilé longtemps et, pour cette raison, j’ai baptisé cette forêt : « la Forêt du Loup Transplaneur ». Puis, mon tour de garde est enfin arrivé et je devais faire le petit-déjeuner de mes compagnons. J’étais beaucoup trop attelée à la tâche pour remarquer quelques dangers que ce soit. D’ailleurs, cela a bien valu la peine, puisque le repas était tellement délicieux qu’un genre de lézard-raptor qui rend les gens aveugles grâce à un flash lumineux n’a pas pu résister et il est parti avec mon chaudron et tout son contenu. Par chance, nous avons pu récupérer ce bien qui est le plus précieux de ma collection, puisqu’il s’agit d’un héritage familial.</p><p>En nous remettant en route, nous avons revu à quelques reprises de petites sculptures de roches qui ressemblaient à de petits bonshommes. Je n’ai aucune idée de qui pouvait bien en être l’artiste, mais c’était plutôt joli. Nous sommes finalement arrivés au pied de la montagne. La mine que nous espérions trouver était en fait une forteresse. Il y avait 45 marches qui menaient à une gigantesque porte d’une fabrication parfaite. La porte étant scellée, nous savions que nous ne pourrions pénétrer dans cette forteresse que le jour où nous en aurions trouvé les 4 clés.</p>"
                    )
                }
            ));
            Episodes.Add(new(
                Season: 1,
                Number: 2,
                Title: "",
                Description: "",
                Streamer: puppo,
                StartDate: new DateTime(2021, 07, 14, 19, 30, 0),
                EndDate: new DateTime(2021, 07, 14, 22, 30, 0),
                YouTubeEmbededUri: "",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860272995460317204",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
            ));
            Episodes.Add(new(
                Season: 1,
                Number: 3,
                Title: "",
                Description: "",
                Streamer: fenyxLair,
                StartDate: new DateTime(2021, 07, 15, 19, 30, 0),
                EndDate: new DateTime(2021, 07, 15, 22, 0, 0),
                YouTubeEmbededUri: "",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273002150101033",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
            ));
            Episodes.Add(new(
                Season: 1,
                Number: 4,
                Title: "",
                Description: "",
                Streamer: onStartTuCa,
                StartDate: new DateTime(2021, 07, 16, 20, 0, 0),
                EndDate: new DateTime(2021, 07, 16, 23, 0, 0),
                YouTubeEmbededUri: "",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273008199467088",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
            ));
            Episodes.Add(new(
                Season: 1,
                Number: 5,
                Title: "",
                Description: "",
                Streamer: puppo,
                StartDate: new DateTime(2021, 07, 21, 19, 30, 0),
                EndDate: new DateTime(2021, 07, 21, 22, 30, 0),
                YouTubeEmbededUri: "",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273014239133707",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
            ));
            Episodes.Add(new(
                Season: 1,
                Number: 6,
                Title: "",
                Description: "",
                Streamer: fenyxLair,
                StartDate: new DateTime(2021, 07, 22, 19, 30, 0),
                EndDate: new DateTime(2021, 07, 22, 22, 0, 0),
                YouTubeEmbededUri: "",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273020596387840",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
            ));
            Episodes.Add(new(
                Season: 1,
                Number: 7,
                Title: "",
                Description: "",
                Streamer: onStartTuCa,
                StartDate: new DateTime(2021, 07, 23, 20, 0, 0),
                EndDate: new DateTime(2021, 07, 23, 23, 0, 0),
                YouTubeEmbededUri: "",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273027836936212",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
            ));
            Episodes.Add(new(
                Season: 1,
                Number: 8,
                Title: "",
                Description: "",
                Streamer: havgood,
                StartDate: new DateTime(2021, 07, 24, 15, 0, 0),
                EndDate: new DateTime(2021, 07, 24, 18, 0, 0),
                YouTubeEmbededUri: "",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273033910419486",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
            ));
            Episodes.Add(new(
                Season: 1,
                Number: 9,
                Title: "",
                Description: "",
                Streamer: puppo,
                StartDate: new DateTime(2021, 07, 28, 19, 30, 0),
                EndDate: new DateTime(2021, 07, 28, 22, 30, 0),
                YouTubeEmbededUri: "",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273039534719047",
                Players: new[] { gur, dhanlbek, kilmi, other1, other2 },
                JournalEntries: default
            ));
            Episodes.Add(new(
                Season: 1,
                Number: 10,
                Title: "",
                Description: "",
                Streamer: fenyxLair,
                StartDate: new DateTime(2021, 07, 29, 19, 30, 0),
                EndDate: new DateTime(2021, 07, 29, 22, 0, 0),
                YouTubeEmbededUri: "",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273045993553920",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
            ));
            Episodes.Add(new(
                Season: 1,
                Number: 11,
                Title: "Special Ma Fête!",
                Description: "",
                Streamer: onStartTuCa,
                StartDate: new DateTime(2021, 07, 30, 20, 0, 0),
                EndDate: new DateTime(2021, 07, 31, 0, 0, 0),
                YouTubeEmbededUri: "",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273052062187531",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
            ));
            Episodes.Add(new(
                Season: 1,
                Number: 12,
                Title: "",
                Description: "",
                Streamer: havgood,
                StartDate: new DateTime(2021, 07, 31, 15, 0, 0),
                EndDate: new DateTime(2021, 07, 31, 18, 0, 0),
                YouTubeEmbededUri: "",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273057981661215",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
            ));
        }

        private Player AddPlayer(Player player)
        {
            Players.Add(player);
            return player;
        }

        private TwitchChannel AddTwitchChannel(TwitchChannel channel)
        {
            TwitchChannels.Add(channel);
            return channel;
        }

        //private EpisodeInfo AddEpisodeInfo(EpisodeInfo episode)
        //{
        //    Episodes.Add(episode);
        //    return episode;
        //}
    }
}
