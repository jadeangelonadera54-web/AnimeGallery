using System.Collections.Generic;
using AnimeGallery.Models;

namespace AnimeGallery.Services;

public class AnimeCharacterService
{
    private static readonly List<AnimeCharacter> Characters = new()
    {
        new AnimeCharacter
        {
            Id = 1,
            Name = "Eren Yeager",
            JapaneseName = "エレン・イェーガー",
            AnimeSeries = "Attack on Titan",
            Category = "Dark Fantasy",
            Role = "Founding & Attack Titan",
            Affiliation = "Survey Corps / Jaegerists",
            Image = "eren.jpg",
            ShortDescription = "A determined warrior relentlessly pursuing absolute freedom for the people of Paradis.",
            FullBio = "Eren Yeager was a former member of the Survey Corps. He lived in Shiganshina District until the fall of Wall Maria, where he witnessed the tragedy that sparked his relentless resolve. Eren holds the combined power of three Titans: the Attack Titan, Founding Titan, and War Hammer Titan. His relentless drive to defend his loved ones led him on a path of destiny that shook the entire world.",
            SignatureAbility = "The Rumbling & Future Memory Sight",
            Abilities = new List<string> { "Titan Shifting", "Crystallized Hardening", "Founding Titan Command", "Omni-Directional Mobility Mastery" },
            NotableQuote = "If you don't fight, you can't win! Fight... Fight!",
            PowerLevel = 0.96,
            AgilityLevel = 0.86,
            IntelligenceLevel = 0.89,
            DurabilityLevel = 0.98
        },
        new AnimeCharacter
        {
            Id = 2,
            Name = "Ichigo Kurosaki",
            JapaneseName = "黒崎 一護",
            AnimeSeries = "Bleach",
            Category = "Supernatural",
            Role = "Substitute Soul Reaper",
            Affiliation = "Karakura Town / Soul Society Ally",
            Image = "ichigo.jpg",
            ShortDescription = "A fiercely loyal swordsman combining the spiritual powers of Shinigami, Hollow, and Quincy.",
            FullBio = "Ichigo Kurosaki is a human who obtained the powers of a Shinigami from Rukia Kuchiki to protect his family and town. Possessing extraordinary spiritual pressure, Ichigo mastered Bankai in record time and fought through Soul Society, Hueco Mundo, and the Quincy War. His Zanpakuto, Zangetsu, harnesses devastating energy slashes.",
            SignatureAbility = "Bankai: Tensa Zangetsu & Getsuga Tensho",
            Abilities = new List<string> { "Getsuga Jujisho", "Hollow Mask & Horn of Salvation", "Flash Step (Shunpo)", "Blut Vene & Quincy Reishi" },
            NotableQuote = "I'm not fighting because I think I'm gonna win! I have to fight! I have to protect them!",
            PowerLevel = 0.95,
            AgilityLevel = 0.97,
            IntelligenceLevel = 0.85,
            DurabilityLevel = 0.92
        },
        new AnimeCharacter
        {
            Id = 3,
            Name = "Manjiro Sano (Mikey)",
            JapaneseName = "佐野 万次郎",
            AnimeSeries = "Tokyo Revengers",
            Category = "Action",
            Role = "Tokyo Manji Gang Commander",
            Affiliation = "Tokyo Manji Gang (Toman)",
            Image = "mickey.jpg",
            ShortDescription = "The invincible leader of Toman, celebrated for his peerless martial arts and magnetic charisma.",
            FullBio = "Manjiro Sano, commonly known as Mikey, is the founding president and commander of the Tokyo Manji Gang. Known throughout Tokyo as the 'Invincible Mikey', he possesses legendary hand-to-hand fighting capability, notably his signature roundhouse kick that can incapacitate opponents instantly. Mikey bears the heavy weight of leading his friends and navigating tragic loss.",
            SignatureAbility = "Nuclear Roundhouse Kick",
            Abilities = new List<string> { "Apex Martial Arts Mastery", "Superhuman Agility & Reflexes", "Magnetic Charisma & Leadership", "Dark Impulse Awakening" },
            NotableQuote = "As long as I'm behind you, nobody's ever gonna beat you.",
            PowerLevel = 0.89,
            AgilityLevel = 0.98,
            IntelligenceLevel = 0.84,
            DurabilityLevel = 0.91
        },
        new AnimeCharacter
        {
            Id = 4,
            Name = "Sasuke Uchiha",
            JapaneseName = "うちは サスケ",
            AnimeSeries = "Naruto Shippuden",
            Category = "Action",
            Role = "Shadow Hokage & Last Uchiha",
            Affiliation = "Hidden Leaf Village (Konohagakure)",
            Image = "sasuke.jpg",
            ShortDescription = "A legendary shinobi master of lightning and fire, wielding the Sharingan and Rinnegan.",
            FullBio = "Sasuke Uchiha is one of the last surviving members of the renowned Uchiha clan. After avenging his clan, Sasuke underwent deep personal growth and dedicated his life to protecting the ninja world from the shadows as the 'Supporting Kage'. His mastery of visual jutsu, space-time ninjutsu, and lightning release makes him one of the most formidable ninja in history.",
            SignatureAbility = "Rinnegan Amenotejikara & Complete Susanoo",
            Abilities = new List<string> { "Chidori & Kirin Lightning", "Eternal Mangekyo Sharingan", "Amaterasu (Blaze Release)", "Space-Time Dimensional Portals" },
            NotableQuote = "I have long since closed my eyes... My only goal is in the darkness.",
            PowerLevel = 0.97,
            AgilityLevel = 0.96,
            IntelligenceLevel = 0.95,
            DurabilityLevel = 0.90
        },
        new AnimeCharacter
        {
            Id = 5,
            Name = "Ryomen Sukuna",
            JapaneseName = "両面 宿儺",
            AnimeSeries = "Jujutsu Kaisen",
            Category = "Dark Fantasy",
            Role = "The King of Curses",
            Affiliation = "Heian Era Sorcery / Apex Disaster",
            Image = "sukuna.jpg",
            ShortDescription = "The ancient undisputed King of Curses whose overwhelming cursed energy terrifies all realms.",
            FullBio = "Ryomen Sukuna is a legendary cursed spirit and the undisputed King of Curses who reigned supreme during the golden age of Jujutsu in the Heian period. Possessing four arms and two faces in his true form, Sukuna treats battle with cold amusement and unmatched tactical genius. Even fragments of his fingers constitute lethal special grade cursed items.",
            SignatureAbility = "Domain Expansion: Malevolent Shrine",
            Abilities = new List<string> { "Dismantle & Cleave Slashing", "Divine Flame (Fuga Furnace)", "Reverse Cursed Healing Technique", "Immense Cursed Energy Manipulation" },
            NotableQuote = "Stand proud. You are strong.",
            PowerLevel = 0.99,
            AgilityLevel = 0.98,
            IntelligenceLevel = 0.97,
            DurabilityLevel = 0.99
        },
        new AnimeCharacter
        {
            Id = 6,
            Name = "Sung Jin-Woo",
            JapaneseName = "ソン・ジヌ",
            AnimeSeries = "Solo Leveling",
            Category = "Supernatural",
            Role = "The Shadow Monarch",
            Affiliation = "Ahjin Guild / Shadow Army",
            Image = "sungjinwoo.jpg",
            ShortDescription = "The hunter who defied death to inherit the power of the immortal Shadow Monarch.",
            FullBio = "Formerly known as humanity's 'Weakest Hunter', Sung Jin-Woo survived the deadly Double Dungeon and received access to the System. By completing daily quests and conquering dungeons, Jin-Woo ascended to unprecedented heights. He became the Shadow Monarch, acquiring the ability to extract souls from fallen foes to serve as his undying, loyal shadow army.",
            SignatureAbility = "Shadow Extraction: 'ARISE'",
            Abilities = new List<string> { "Shadow Army Summoning", "Ruler's Authority (Telekinesis)", "Shadow Exchange (Instant Teleport)", "Monarch's Domain Amplification" },
            NotableQuote = "ARISE.",
            PowerLevel = 1.0,
            AgilityLevel = 0.99,
            IntelligenceLevel = 0.95,
            DurabilityLevel = 0.98
        },
        new AnimeCharacter
        {
            Id = 7,
            Name = "Tanjiro Kamado",
            JapaneseName = "竈門 炭治郎",
            AnimeSeries = "Demon Slayer",
            Category = "Dark Fantasy",
            Role = "Sun Breathing Swordsman",
            Affiliation = "Demon Slayer Corps",
            Image = "tanjiru.png",
            ShortDescription = "A compassionate swordsman fighting tirelessly to cure his demon sister and conquer evil.",
            FullBio = "Tanjiro Kamado joined the Demon Slayer Corps after a tragic attack by Muzan Kibutsuji left his family dead and his sister Nezuko turned into a demon. Tanjiro combines sheer tenacity with profound empathy even toward his foes. Through disciplined training, he mastered Water Breathing and rediscovered the legendary Sun Breathing (Hinokami Kagura).",
            SignatureAbility = "Sun Breathing (Hinokami Kagura)",
            Abilities = new List<string> { "Hinokami Kagura Sword Dance", "Water Breathing 10 Forms", "Transparent World Perception", "Demon Slayer Mark Awakening" },
            NotableQuote = "No matter how many people you may lose, you have no choice but to go on living.",
            PowerLevel = 0.92,
            AgilityLevel = 0.94,
            IntelligenceLevel = 0.88,
            DurabilityLevel = 0.95
        },
        new AnimeCharacter
        {
            Id = 8,
            Name = "Roronoa Zoro",
            JapaneseName = "ロロノア・ゾロ",
            AnimeSeries = "One Piece",
            Category = "Adventure",
            Role = "Master of Three-Sword Style",
            Affiliation = "Straw Hat Pirates",
            Image = "zoro.jpg",
            ShortDescription = "The fearsome swordsman and first mate striving to become the World's Greatest Swordsman.",
            FullBio = "Roronoa Zoro was a feared bounty hunter before becoming the first crewmate to join Monkey D. Luffy. Dedicated to keeping his promise to his childhood rival Kuina, Zoro trains relentlessly to surpass Dracule Mihawk. Zoro wields the legendary swords Wado Ichimonji, Sandai Kitetsu, and Enma, channeling terrifying Conqueror's Haki into devastating slashes.",
            SignatureAbility = "Three-Sword Style: King of Hell",
            Abilities = new List<string> { "Santoryu Ogi: Secret Sword Arts", "Advanced Conqueror's Haki", "Nine-Sword Style: Asura", "Flying Air Slashes (Pound Ho)" },
            NotableQuote = "If I die here, then I'm a man that could only make it this far.",
            PowerLevel = 0.97,
            AgilityLevel = 0.93,
            IntelligenceLevel = 0.86,
            DurabilityLevel = 1.0
        }
    };

    public List<AnimeCharacter> GetAllCharacters() => new(Characters);

    public List<string> GetCategories() => new()
    {
        "All",
        "Dark Fantasy",
        "Action",
        "Supernatural",
        "Adventure"
    };
}
