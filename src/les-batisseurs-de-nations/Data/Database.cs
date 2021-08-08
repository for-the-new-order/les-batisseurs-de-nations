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

        private Player other1;
        private Player other2;
        private Player other3;
        private Player other4;
        private Player other5;

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
            var kilgur = AddPlayer(new(
                Id: 5,
                DisplayName: "Kilgur Grandfeu",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/players/members/Kilgur-Token.jpeg",
                CharacterSheetUri: "https://www.dndbeyond.com/characters/53901830",
                CharacterSheetImageUri: "https://media-waterdeep.cursecdn.com/avatars/19358/312/character-53901830.jpeg",
                IsTeamMember: true
            ));
            var reiauk = AddPlayer(new(
                Id: 5,
                DisplayName: "Reiauk Forcefeu",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/players/members/Reiauk-Token.jpeg",
                CharacterSheetUri: "https://www.dndbeyond.com/characters/54314526",
                CharacterSheetImageUri: "https://media-waterdeep.cursecdn.com/avatars/19210/299/character-54314526.jpeg",
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
            var attaZap = AddAuthor(id: 101, displayName: "Atta Talas’Kiir");
            var falemJDRNinja = AddAuthor(id: 102, displayName: "Falem");
            var gordon = AddAuthor(id: 103, displayName: "Gordon");
            var johc = AddAuthor(id: 104, displayName: "Johc");
            var luthion = AddAuthor(id: 105, displayName: "Luthion");

            var juliusOgen88 = AddAuthor(id: 106, displayName: "Julius Ming");
            var zognord = AddAuthor(id: 107, displayName: "Zognord aux poings d'argent");
            var jaari = AddAuthor(id: 108, displayName: "Jaari Halkarna");
            var valmo = AddAuthor(id: 109, displayName: "Valmo Leafheart");
            var klutch = AddAuthor(id: 110, displayName: "Kellen Lutchen (Klutch)");

            // Other players
            other1 = AddAuthor(id: -1, displayName: "Joueur 1", profileImageUri: "");
            other2 = AddAuthor(id: -2, displayName: "Joueur 2", profileImageUri: "");
            other3 = AddAuthor(id: -3, displayName: "Joueur 3", profileImageUri: "");
            other4 = AddAuthor(id: -4, displayName: "Joueur 4", profileImageUri: "");
            other5 = AddAuthor(id: -5, displayName: "Joueur 5", profileImageUri: "");

            // TwitchChannels
            var onStartTuCa = AddTwitchChannel(new(
                StreamerId: Streamer.OnStartTuCa,
                DisplayName: "On start tu ça?",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/streamers/onstarttuca-profile_image-150x150.png",
                ChannelUri: "https://www.twitch.tv/onstarttuca",
                ChannelName: "onstarttuca"
            ));
            var fenyxLair = AddTwitchChannel(new(
                StreamerId: Streamer.FenyxLair,
                DisplayName: "The Fenyx Lair",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/streamers/fenyx-profile_image-150x150.png",
                ChannelUri: "https://www.twitch.tv/thefenyxlair",
                ChannelName: "thefenyxlair"
            ));
            var puppo = AddTwitchChannel(new(
                StreamerId: Streamer.Puppo,
                DisplayName: "Pour une poignee de pieces d'or",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/streamers/puppo-profile_image-150x150.png",
                ChannelUri: "https://www.twitch.tv/pourunepoigneedepiecesdor",
                ChannelName: "pourunepoigneedepiecesdor"
            ));
            var havgood = AddTwitchChannel(new(
                StreamerId: Streamer.Havgood,
                DisplayName: "havgood",
                ProfileImageUri: "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/streamers/havgood-profile_image-150x150.png",
                ChannelUri: "https://www.twitch.tv/havgood",
                ChannelName: "havgood"
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
                TwitchVideoId: "1082222322",
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
                TwitchVideoId: "1094009118",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860272995460317204",
                Players: new[] { attaZap, falemJDRNinja, gordon, johc, luthion },
                JournalEntries: new[]
                {
                    new JournalEntry(
                        Author: attaZap,
                        PublishedDate: new(2021, 7, 15),
                        Content: "<p>Après un rude voyage en mer à explorer tous les coins du bateau MarieCéleste afin de mieux comprendre son architecture (bon, je suis tombé quelques fois des cordages mais à part les quelques bleus et mon épeule disloquée, rien de grave!), nous sommes finalement arrivés à cette terre remplie de promesse. Il fait beau quand on met pied à terre, un premier groupe formé de nain est allé en exploration. Peu après leur retour, notre petit groupe a décidé d’aider notre ami Johc qui souffre d’un étrange mal. On décide d’aller vers l’est pour trouver des herbes médicinales et aussi des épices pour Gordon, un cuisinier hors pair. </p><p>Le mélange de la flore est étrange, un peu de forêt boréale, de feuillus et d’arbres tropicaux. On s’enfonce dans la nature, il fait très chaud et humide. Les pierres de Johc nous guident dans cette végétation qui est mystérieusement silencieuse, aucun son d’animaux. Après quelques heures de marche, notre compagnon Johc semble souffrir de plus en plus de son étrange mal. Par chance, Falem, notre tortue a trouvé une sorte de plante qui ressemble à du lichen qui aide Johc à continuer. </p><p>Peu après, on se retrouve dans un endroit avec plein d’outils de fermes et un squelette d’humain empalé par une fourche. Une partie de la forêt est ravagée tout près, des arbres déracinés, des troncs brisés, etc… La forêt est encore plus silencieuse, on se sent regardé, observé…. Dans le sillon laissé dans la végétation probablement par une énorme créature, on voit un éclat métallique au loin. On décide d’aller voir. </p><p>Près de nous, un genre de bosquet offre un chemin vers cet éclat mais c’est une portion de la forêt qui est très sombre et qui finalement cache une gigantesque colonie d’araignées géantes. On s’aventure car il semble y avoir une flore spéciale qui pourrait aider notre compagnon Johc. À peine entré dans la noirceur, on trouve un squelette dans un tronc d’arbre qui a un peu d’équipement avec lui. En voulant aller chercher l’équipement, je mets le pied sur un champignon empoisonné et je soulève un nouage de spores. Les araignées sont tannées de notre présence et nous attaque. Le combat a est rude pour les araignées mais 4 araignées gigantesques viennent en renfort. Cette fois, le combat est rude pour nous! On se sent tout d’un coup inspiré par le destin et nous triomphons finalement! Il se fait tard et on décide de retourner au camp, mais juste avant de quitter cet endroit, on croit entendre le bruit d’une rivière au nord-est. </p><p>Nous ramenons de notre expédition avec un petit baril de mélasse (nourriture), 1 sac de champignon séché (nourriture), 1 petit couteau (dague), 1 gourde remplie d’un liquide inconnu, une chaudière de bois, 2 fourches, 1 bèche et 4 textiles.</p>"
                    ),
                    new JournalEntry(
                        Author: falemJDRNinja,
                        PublishedDate: new(2021, 7, 15),
                        Content: "<h2>Objectifs</h2><p>Trouver des sources de nourriture et d'herbes médicinales à l'Est de la colonie.</p><h2>Déroulement</h2><h3>Débarquement</h3><p>Nous sommes débarqué du Marie Céleste sous le regard de Ludovicius qui n'a pas hésité à nous rappeler que nous avions une dette de 100po pour notre traversée.</p><h3>C'est un départ</h3><p>C'est ainsi que nous avons commencé notre chemin vers l'Est.</p><p>Sur le chemin j'ai trouvé de l'Usné poudreuse, une sorte de lichen qui ressemble un peu à une espèce que je connais sur l'autre continent. Je devrais pouvoir en faire une potion de soins mineur en la réduisant en poudre.</p><p>Johc nous a guidé avec ses pierres à travers la forêt. La température était lourde, une humidité accapablante.</p><h3>Anciens colons</h3><p>Nous sommes arrivé à un endroit où la végétation devenait encore plus épaisse. Le chemin que nous avons parcouru semblait avoir été fait par une immense créature.</p><p>À l'entrée il y avait de vieux outils du passé ainsi qu'un squelette d'humanoide. Après un examen minutieux j'en suis venu à la conclusion qu'il était mort par empoisonnement.</p><h3>Attention, arachnides</h3><p>Dans la partie plus dense, nous avons découvert un territoire peuplé d'araignées venimeuses. Ce qui explique l'absence de bruit d'oiseaux et autres.</p><p>Nous avons aperçu au loin une lueur métallique, très intrigué et voulant trouver des herbes pour aider Johc nous avons avancé dans l'obscurité. Gordon c'est fait piqué quelques fois. Elles ne semblent pas apprécier le feu.</p><p>Atta à mis le pied sur un carpophore, ce qui a provoqué un nuage de spore empoisonné.</p><p>Luthion à découvert dans le creux d'un arbre les restes d'une pauvre créature serrant contre elle son butin.</p><p>Après avoir tué les petites araignées qui semblaient irritées par notre présence, quelques gros spéciments ont montré leurs pattes. Devant c'est insecte gigantesque, nous avons opté pour une stratégie de recule. Attaa c'est fait englué par l'une des araignées géantes. Il ne respirait plus quand Johc le soigna avec sa magie.</p><p>Nous avons vaincue la plupart des araignées, la dernière c'est enfuie voyant qu'elle ne pouvait pas gagner contre nous.</p><h3>Récolte</h3><p>Après ce combat, les araignées nous on laissée tranquilles. Nous en avons profité pour faire quelques récoltes.</p><p>Luthion a tenté de ramasser de la toile, mais sa technique laissait beaucoup à désirer. Il n'a pas réussi à récolter beaucoup de toile. Par contre Atta a mieux réussi.</p><p>Gordon a cuisiné des parties d'araignées. Le résultat semblait correct à première vue. Il faudra bien observer les réactions des goûteurs.</p><p>Johc c'est occupé de dépecer les carcasses d'araignées pour récupérer les mandibules.</p><p>Moi (Falem) j'ai cherché pour des plantes et j'ai fait d'excellente découverte. J'ai réussi à cueillir des champignons.</p><h3>Cartographie</h3><p>Lors de notre départ vers la colonie, Gordon percu très faiblement un bruit de rivière provenant du Nort-Est.</p><h2>Conclusion</h2><p>Nous sommes revenu sain et sauf à la colonie avec de belles découvertes. C'est un bon départ!</p><h3>Butin</h3><p>Résumé des objets que le groupe a trouvé lors de la mission</p><ul><li>2 Fourches (outils de ferme)</li><li>1 Bêche (outils de ferme)</li><li>4 Textiles</li><li>4 Mandibules d'araignées</li><li>1 Usné poudreuse</li><li>9 Champginons</li><li>15 Ration verdâtre à base d'araignée</li><li>1 Petit baril de mélasse</li><li>1 Sac de champignons séchés</li><li>1 Dague</li><li>1 Gourde remplie d'un liquide inconnu</li><li>1 Sceau en bois</li></ul>"
                    ),
                }
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
                TwitchVideoId: "1087957963",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273002150101033",
                Players: new[] { juliusOgen88, zognord, jaari, valmo, klutch },
                JournalEntries: new[]
                {
                    new JournalEntry(
                        Author: juliusOgen88,
                        PublishedDate: new(2021, 7, 16),
                        Content: "<h3>Première Lettre à mon père</h3><p>Hermès te bénisse mon père. Ma première semaine à été difficile. Le chef de camp nous tien bien en laisse avec une dette de 100 pièces d'or. Ne t'en fais pas je ferai honneur au nom de Ming.</p><p>La température est très élevé. Nous buvons beaucoup d'eau. J'ai réussi à me trouver des compagnons pour aller exploré la cote. 2 Guerriers, un humain nommé Jaari. Très efficace avec une lance courte. L'autre un nain des montagne nommé Zognord, Avec sa cotte de mail et bouclier. Il est un bon compatriote de première ligne. Un artificié nommé Kellen. Il veut devenir un grand petit guerrier. Il semble plustot un de es artificier de combat. Et pour terminé un bard halfling nommé Valmo. Vaillant au combat et un bon guérisseur.</p><p>Notre première rencontre un Brouillon/Tourbillon a une centaine de pieds de la rive. L'eau est chaude et trouble. Ma mage hand a touché quelque chose de solide mais mon courage c'est estompé. J'ai regagné la rive sain et sauf. Par la suite nous avons trouvé des oursins. Plus coriace que se qu'on connaît. Nous en avons rapporté 3 vivants au campement. Plus de détailles suivront. À notre grande surprise nous avons vu une baleine dans la baie. La baie est remplie de vie... Tu sais les histoires de pêcheur... Pieuvre géante et Kraken. Bien nous en avons été témoin. La créature marine à attrapé la baleine, et a causé deux grosse vagues.   La foret près de la cote est rempli d’araignées, nous avons continué notre chemin et rencontré plusieurs crabes géants. Nous avons presque perdu Valmo. Nous avons rapporté 6 livre de chair de crab. Avant de retraité au camp nous avons sentie de la fumé. La prochaine fois nous irons plus loin.</p><p>Dis à maman que je l'aime fort. N'envoyez pas mon frère me chercher. Dis à Kella de resté dévoué et de ne pas perdre la foie.</p>"
                    ),
                    new JournalEntry(
                        Author: klutch,
                        PublishedDate: new(2021, 7, 16),
                        Content: "<h3>Objectifs</h3><p>Explorer la côte sud-est du camp de base afin de voir s'il s'y trouve un endroit plus propice et stratégique pour y implanter la colonie, un camp de pêche et/ou un quai. Explorer et découvrir quelles sont les ressources disponibles pour la communauté ainsi que les dangers qui nous guêtent sur le territoire.</p><h3>Introduction</h3><p>Arrivée du Marie-Céleste aux abords de la côte de la baie, le capitaine semble très heureux d'arriver, le voyage a tout de même été long et ardu. Il rappelle à tous que nous lui devont chacun 100 P.O. pour notre passage vers les terres perdues et nous souhaite bonne chance dans cette aventure.</p><p>Deux groupes se sont déjà organisés et sont partis en mission qui se sont révélées plutôt dangeureuses et fertiles en découvertes et rebondissements. C'est non sans craintes que Zognord, Julius, Jaari, Valmo et Klutch, qui ont fait connaissance sur le Marie-Céleste se sont motivés à faire une première mission de reconnaissance afin de participer à l'effort collectif d'implantation de la colonie dans un endroit stratégique.</p><h3>Récit de Mission</h3><p>Arborant confiance et détermination, nous nous éloignons du camps de base en direction du sud-est longeant la plage. Il fait chaud et c'est très humide, nous marchons un bon 2 heures sans remarquer rien d'anormal, la plage est déserte et aucune trace au sol dans le sable. Notre navigateur de mission est Jaari, il nous guide efficacement nous évitant de nous perdre. Valmo et Julius ont pris en charge la tâche des ravitaillements. Pour leur part, Zognord et Klutch s'occuperont de surveiller les alentours afin d'y détecter les dangers potentiels. Aucun d'entre nous n'a le talent de cartographe, alors nous ne pouvons pas effectuer cette tâche et devront improviser pour marquer l'emplacement de nos trouvailles. Soudainement nous aperçevons à environ 100 pieds de la côte un phénomène étrange à la surface de l'eau.</p><p>Ça prend l'apparence d'un tourbillon. Julius intrigué veut essayer de s'en approcher pour mieux comprendre le phénomène, il s'attache à une corde et lorsqu'il est à portée de sa mage hand, il l'envoie pour aller toucher le vortex, avec surprise la mage hand touche quelque chose de solide, il décide ensuite de revenir sur la plage et nous décris ce qu'il a découvert.</p><p>Durant ce temps Klutch examine la végétation environnante et reconnait des essences intéressantes de bois, mais elles sont différentes de celles qu'il connaît. Afin de marquer l'essence de bois qui serait utile pour la construction de bâtiments ainsi que le phénomène de vortex, on plante une flèche dans l'arbre. Nous poursuivons notre route le long de la plage sous une chaleur qui continue de s'intensifier. au bout d'un moment le vortex semble diminuer en intensité. Nous aperçevons sur la plage ce que nous reconnaissons comme des oursins, mais visiblement plus gros avec de long pics acérés. Nous essayons d'en briser afin d'en récupérer la chair, mais ils sont très solides. Klutch aimerait bien en acquérir une afin de l'analyser et s'en faire un objet utilitaire. Nous décidons donc de faire un feu et bouillir les oursins afin de les tuer et les cuire.</p><p>Durant cette opération, Zognard et Klutch qui continue leur surveillance aperçoivent au loin une baleine géante qui saute hors de l'eau et quelques instant après, deux immences tentacules attrapent la balaine et la tire sous l'eau. Kraken au large! peu de temps après une énorme vague approche rapidement du rivage et tous courrons vers la forêt pour nous protéger des vagues jusqu'à ce que le tout ce calme. deux tentacules attrapent de multiples oursins sur la plage sous nos yeux ébahis. Jaari examine l'orée de la forêt et aperçoit de nombreuses toiles d'araignées ainsi que du mouvement dans les hauteurs, potentiellement des araignées géantes. Le groupe décide de retourner vers la plage et récupérer le chaudron et les 3 oursins à l'intérieur du chaudron épargnée par le kraken. on décide de les ramener comme ça enfermés dans le chaudron pour plus tard.</p><p>Désireux de quitter cet endroit avant que le kraken décide d'y revenir, nous avançons rapidement vers un endroit qui est plus bosselé et accidenté. Kellen pique dans une des bosses, ce qui semble attirer l'attention de 9 crabes géants sur nous. c'est le moment de la bastong!</p><h3>Combat avec 9 Crabes Géants</h3><p>Combat particulièrement difficile (de 9 rounds) par le surnombre des crabes géants. Nos armures ont tenu bon mais quelques membres de l'équipe sont tombés au combat et ensuite réanimés. Heureusement nous avons réussi à réduire le nombre de crabes et reprendre l'ascendance sur le combat et tous y survivre. Le destin et les dieux ont joués en notre faveur aux bons moments. Jaari et Zognord ont été brave et incisifs dans leurs attaques alors que Klutch ayant perdu sa concentration sur son sort de fearie fire, il fut rapidement encerclé et a du se camper en defensive avec un sanctuaire et espérer survivre. Julius et Valmo ont bien soutenu le groupe avec leurs sorts. Les crabes aiment prendre leur victimes dans leur pinces, on a tous été attrapé par les crabes a un moment dans le combat.</p><p>L'important c'est d'avoir survécu et pouvoir rapporter nouvelles et ressources à la communauté:</p><h3>Conclusion</h3><p>Épuisé par le combat et cette chaleur intense, nous ramassons nos affaires ainsi que ce que nous pouvons rapidement dépesser comme chair de crabe et retournons vers le camp de base en portant Valmo sur nous, toujours inconscient mais stabilisé. Kellen désire conserver au moins une coquille d'oursin, il a une idée en tête pour se faire un petit objet qui lui sera utile plus tard...</p><p>La côte est dangeureuse, ce sera difficile d'implanter la ville, un camps de pêche ou même un quai ici, la présence d'un kraken nous oblige a réfléchir à tous ces risques...par contre il y a moyen de trouver des ressources (bois, nourriture et textiles. des expéditions bien organisées pourront maximiser ces ressources! Je crois que ça vaut la peine d'aller plus loin sur la côte et avec le temps de la sécuriser en éliminant toute menace sur une base régulière.</p><h4>Trouvailles au cours de la mission</h4><p><ul><li>3 oursins (coquilles)</li><li>6 livres de chair de crabes géants</li><li>Présence de toiles d'araignée dans la forêt non loin du vortex et des chênes (potentiel de textile)</li><li>Présence d'une baleine et d'un kraken dans la baie aux environs du vortex (danger potentiel)</li><li>Présence d'oursins et de crabes sur la plage (Nourriture Potentielle)</li></ul></p><h4>Endroits visités avec des points d'intérêts</h4><p><ul><li>Présence d'essence d'arbres pour construction de bâtiments (chêne)</li><li>Présence d'un vortex a environ 10 pieds de la rive environ a 2 h de marche du camps de base et près des chênes.</li><ul></p>"
                    ),
                }
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
                TwitchVideoId: "1089262265",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273008199467088",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
                //JournalEntries: new[]
                //{
                //    new JournalEntry(
                //        Author: other1,
                //        PublishedDate: new(2021, 7, 1),
                //        Content: ""
                //    )
                //}
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
                TwitchVideoId: "",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273014239133707",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
                //JournalEntries: new[]
                //{
                //    new JournalEntry(
                //        Author: other1,
                //        PublishedDate: new(2021, 7, 1),
                //        Content: ""
                //    )
                //}
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
                TwitchVideoId: "1095074500",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273020596387840",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
                //JournalEntries: new[]
                //{
                //    new JournalEntry(
                //        Author: other1,
                //        PublishedDate: new(2021, 7, 1),
                //        Content: ""
                //    )
                //}
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
                TwitchVideoId: "1099327330",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273027836936212",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
                //JournalEntries: new[]
                //{
                //    new JournalEntry(
                //        Author: other1,
                //        PublishedDate: new(2021, 7, 1),
                //        Content: ""
                //    )
                //}
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
                TwitchVideoId: "1096896122",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273033910419486",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
                //JournalEntries: new[]
                //{
                //    new JournalEntry(
                //        Author: other1,
                //        PublishedDate: new(2021, 7, 1),
                //        Content: ""
                //    )
                //}
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
                TwitchVideoId: "1101193227",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273039534719047",
                Players: new[] { gur, dhanlbek, kilmi, other4, other5 },
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
                TwitchVideoId: "1102246201",
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
                TwitchVideoId: "1107044101",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273052062187531",
                Players: new[] { other1, other2, other3, mamita, other5 },
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
                TwitchVideoId: "1104077067",
                DiscordLink: "https://discord.com/channels/662746189069942802/859589836225511424/860273057981661215",
                Players: new[] { other1, other2, other3, other4, other5 },
                JournalEntries: new JournalEntry[0]
            ));

            // Aout 2021
            AddEpisode(
                episodeNumber: 13,
                streamer: puppo,
                startDate: new DateTime(2021, 8, 4, 19, 30, 0),
                discordLink: "https://discord.com/channels/662746189069942802/867209739040718849/867232943764144158",
                player1: mamita,
                player2: kilgur,
                player3: kilmi
            );
            AddEpisode(
                episodeNumber: 14,
                streamer: onStartTuCa,
                startDate: new DateTime(2021, 8, 6, 20, 0, 0),
                discordLink: "https://discord.com/channels/662746189069942802/867209739040718849/867232950545154058"
            );
            AddEpisode(
                episodeNumber: 15,
                streamer: puppo,
                startDate: new DateTime(2021, 8, 11, 19, 30, 0),
                discordLink: "https://discord.com/channels/662746189069942802/867209739040718849/867232957218553886"
            );
            AddEpisode(
                episodeNumber: 16,
                streamer: fenyxLair,
                startDate: new DateTime(2021, 8, 12, 19, 30, 0),
                discordLink: "https://discord.com/channels/662746189069942802/867209739040718849/867232964965957632",
                player1: reiauk,
                player2: dhanlbek,
                player3: kilmi
            );
            AddEpisode(
                episodeNumber: 17,
                streamer: onStartTuCa,
                startDate: new DateTime(2021, 8, 13, 20, 0, 0),
                discordLink: "https://discord.com/channels/662746189069942802/867209739040718849/867232972691472384"
            );
            AddEpisode(
                episodeNumber: 18,
                streamer: havgood,
                startDate: new DateTime(2021, 8, 14, 15, 0, 0),
                discordLink: "https://discord.com/channels/662746189069942802/867209739040718849/867232979885359114",
                player3: dhanlbek
            );
            AddEpisode(
                episodeNumber: 19,
                streamer: fenyxLair,
                startDate: new DateTime(2021, 8, 19, 19, 30, 0),
                discordLink: "https://discord.com/channels/662746189069942802/867209739040718849/867232987753611274"
            );
            AddEpisode(
                episodeNumber: 20,
                streamer: onStartTuCa,
                startDate: new DateTime(2021, 8, 20, 20, 0, 0),
                discordLink: "https://discord.com/channels/662746189069942802/867209739040718849/867232995516612628",
                player1: gur,
                player3: mamita
            );
            AddEpisode(
                episodeNumber: 21,
                streamer: puppo,
                startDate: new DateTime(2021, 8, 25, 19, 30, 0),
                discordLink: "https://discord.com/channels/662746189069942802/867209739040718849/867233002916544582"
            );
            AddEpisode(
                episodeNumber: 22,
                streamer: fenyxLair,
                startDate: new DateTime(2021, 8, 26, 19, 30, 0),
                discordLink: "https://discord.com/channels/662746189069942802/867209739040718849/867233010477432852",
                player2: kilgur,
                player3: reiauk,
                player4: gur
            );
            AddEpisode(
                episodeNumber: 23,
                streamer: onStartTuCa,
                startDate: new DateTime(2021, 8, 27, 20, 0, 0),
                discordLink: "https://discord.com/channels/662746189069942802/867209739040718849/867233018225754124"
            );
            AddEpisode(
                episodeNumber: 24,
                streamer: havgood,
                startDate: new DateTime(2021, 8, 28, 15, 0, 0),
                discordLink: "https://discord.com/channels/662746189069942802/867209739040718849/867233025024720947"
            );
        }

        private EpisodeInfo AddEpisode(
            int episodeNumber, TwitchChannel streamer, DateTime startDate, string discordLink,
            Player player1 = default, Player player2 = default, Player player3 = default, Player player4 = default, Player player5 = default,
            Func<EpisodeInfo, EpisodeInfo> configure = null)
        {
            var episode = new EpisodeInfo(
                Season: 1,
                Number: episodeNumber,
                Title: "",
                Description: "",
                Streamer: streamer,
                StartDate: startDate,
                EndDate: startDate.AddHours(3),
                YouTubeEmbededUri: "",
                TwitchVideoId: "",
                DiscordLink: discordLink,
                Players: new[] { player1 ?? other1, player2 ?? other2, player3 ?? other3, player4 ?? other4, player5 ?? other5 },
                JournalEntries: new JournalEntry[0]
            );
            var configuredEpisode = configure?.Invoke(episode);
            Episodes.Add(configuredEpisode ?? episode);
            return episode;
        }

        private Player AddPlayer(Player player)
        {
            Players.Add(player);
            return player;
        }

        private Player AddAuthor(int id, string displayName, string profileImageUri = "https://cdn.rpg.solutions/les-batisseurs-de-nations/images/players/Empty-Token.png")
        {
            var player = new Player(
                Id: id,
                DisplayName: displayName,
                ProfileImageUri: profileImageUri,
                CharacterSheetUri: "",
                CharacterSheetImageUri: "",
                IsTeamMember: false
            );
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
