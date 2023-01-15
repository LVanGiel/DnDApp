using LVG.DND.Models;
using LVG.DND.streaming.Base;
using Newtonsoft.Json;

namespace LVG.DND.streaming
{
    internal class StreamRaces : BaseStream
    {
        List<Race> races = new List<Race>();
        string basepath = FileSystem.Current.AppDataDirectory;
        public StreamRaces()
        {
            PushRaces();
        }
        private void PushRaces()
        {
            var pathRaces = Path.Combine(basepath, @"Data\Races\");
            var pathString = Path.Combine(basepath, @"Data\");
            AddRaces();

            System.IO.Directory.CreateDirectory(pathString);
            System.IO.Directory.CreateDirectory(pathRaces);

            foreach (Race race in races)
            {
                CreateRaceFile(race, pathRaces);
            }
            
        }
        private void CreateRaceFile(Race race, string basepath)
        {
            var txtName = race.Name.Replace(" ", "") + ".txt";
            var path = Path.Combine(basepath, txtName);

            CreateFileCheck(path);
            File.WriteAllText(path, JsonConvert.SerializeObject(race));
        }
        public void AddRaces()
        {
            races = new List<Race>{
                //Dragonborn
                new Race(){ 
                    Name = "Dragonborn", 
                    AgeInfo = "Young dragonborn grow quickly. They walk hours after hatching, attain the size and development of a 10-year-old human child by the age of 3, and reach adulthood by 15. They live to be around 80",
                    SizeInfo = "Dragonborn are taller and heavier than humans, standing well over 6 feet tall and averaging almost 250 pounds. Your size is Medium",
                    AlignmentInfo = "Dragonborn tend towards extremes, making a conscious choice for one side or the other between Good and Evil (represented by Bahamut and Tiamat, respectively). More side with Bahamut than Tiamat (whose non-dragon followers are mostly kobolds), but villainous dragonborn can be quite terrible indeed. Some rare few choose to devote themselves to lesser dragon deities, such as Chronepsis (Neutral), and fewer still choose to worship Io, the Ninefold Dragon, who is all alignments at once",
                    BaseWalkingSpeed = 30,
                    BaseFlyingSpeed = 0,
                    ASBonus = new List<RaceAbilityScoreBonus>
                    {
                        new RaceAbilityScoreBonus{Bonus = 2, AbilityScoreName = "Strength"},
                        new RaceAbilityScoreBonus{Bonus = 1, AbilityScoreName = "Charisma"}
                    },
                    Traits = new List<Trait>(),
                    Languages = new List<Language>{ new Language("Common"), new Language("Draconic") },
                    Backstory = "",
                    SubRaces = new List<SubRace>{ 
                        new SubRace() {
                            Name = "Black",
                            Backstory = "Damagetype for these dragons is Acid",
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Acid Breath Weapon",
                                    SpellLevel=0,
                                    Description = "You can use your action to exhale destructive energy. It deals damage in an area according to your ancestry. When you use your breath weapon, all creatures in the area must make a saving throw, the type of which is determined by your ancestry. The DC of this saving throw is 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increase to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th level. After using your breath weapon, you cannot use it again until you complete a short or long rest. HBInstead, you may use your breath weapon a number of times equal to your Constitution modifier. You regain expended uses on a short or long rest",
                                    Range = "5' by 30' line (DEX save)"
                                }
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>()
                        },
                        new SubRace() {
                            Name = "Copper",
                            Backstory = "Damagetype for these dragons is Acid",
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Acid Breath Weapon",
                                    SpellLevel=0,
                                    Description = "You can use your action to exhale destructive energy. It deals damage in an area according to your ancestry. When you use your breath weapon, all creatures in the area must make a saving throw, the type of which is determined by your ancestry. The DC of this saving throw is 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increase to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th level. After using your breath weapon, you cannot use it again until you complete a short or long rest. HBInstead, you may use your breath weapon a number of times equal to your Constitution modifier. You regain expended uses on a short or long rest",
                                    Range = "5' by 30' line (DEX save)"
                                }
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>()
                        },
                        new SubRace() {
                            Name = "Blue",
                            Backstory = "Damagetype for these dragons is Lightning",
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Lightning Breath Weapon",
                                    SpellLevel=0,
                                    Description = "You can use your action to exhale destructive energy. It deals damage in an area according to your ancestry. When you use your breath weapon, all creatures in the area must make a saving throw, the type of which is determined by your ancestry. The DC of this saving throw is 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increase to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th level. After using your breath weapon, you cannot use it again until you complete a short or long rest. HBInstead, you may use your breath weapon a number of times equal to your Constitution modifier. You regain expended uses on a short or long rest",
                                    Range = "5' by 30' line (DEX save)"
                                }
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>()
                        },
                        new SubRace() {
                            Name = "Bronze",
                            Backstory = "Damagetype for these dragons is Lightning",
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Lightning Breath Weapon",
                                    SpellLevel=0,
                                    Description = "You can use your action to exhale destructive energy. It deals damage in an area according to your ancestry. When you use your breath weapon, all creatures in the area must make a saving throw, the type of which is determined by your ancestry. The DC of this saving throw is 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increase to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th level. After using your breath weapon, you cannot use it again until you complete a short or long rest. HBInstead, you may use your breath weapon a number of times equal to your Constitution modifier. You regain expended uses on a short or long rest",
                                    Range = "5' by 30' line (DEX save)"
                                }
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>()
                        },
                        new SubRace() {
                            Name = "Brass",
                            Backstory = "Damagetype for these dragons is Fire",
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Fire Breath Weapon",
                                    SpellLevel=0,
                                    Description = "You can use your action to exhale destructive energy. It deals damage in an area according to your ancestry. When you use your breath weapon, all creatures in the area must make a saving throw, the type of which is determined by your ancestry. The DC of this saving throw is 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increase to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th level. After using your breath weapon, you cannot use it again until you complete a short or long rest. HBInstead, you may use your breath weapon a number of times equal to your Constitution modifier. You regain expended uses on a short or long rest",
                                    Range = "5' by 30' line (DEX save)"
                                }
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>()
                        },
                        new SubRace() {
                            Name = "Gold",
                            Backstory = "Damagetype for these dragons is Fire",
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Fire Breath Weapon",
                                    SpellLevel=0,
                                    Description = "You can use your action to exhale destructive energy. It deals damage in an area according to your ancestry. When you use your breath weapon, all creatures in the area must make a saving throw, the type of which is determined by your ancestry. The DC of this saving throw is 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increase to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th level. After using your breath weapon, you cannot use it again until you complete a short or long rest. HBInstead, you may use your breath weapon a number of times equal to your Constitution modifier. You regain expended uses on a short or long rest",
                                    Range = "15' cone (DEX save)"
                                }
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>()
                        },
                        new SubRace() {
                            Name = "Green",
                            Backstory = "Damagetype for these dragons is Poison",
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Poison Breath Weapon",
                                    SpellLevel=0,
                                    Description = "You can use your action to exhale destructive energy. It deals damage in an area according to your ancestry. When you use your breath weapon, all creatures in the area must make a saving throw, the type of which is determined by your ancestry. The DC of this saving throw is 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increase to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th level. After using your breath weapon, you cannot use it again until you complete a short or long rest. HBInstead, you may use your breath weapon a number of times equal to your Constitution modifier. You regain expended uses on a short or long rest",
                                    Range = "15' cone (CON save)"
                                }
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>()
                        },
                        new SubRace() {
                            Name = "Red",
                            Backstory = "Damagetype for these dragons is Fire",
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Fire Breath Weapon",
                                    SpellLevel=0,
                                    Description = "You can use your action to exhale destructive energy. It deals damage in an area according to your ancestry. When you use your breath weapon, all creatures in the area must make a saving throw, the type of which is determined by your ancestry. The DC of this saving throw is 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increase to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th level. After using your breath weapon, you cannot use it again until you complete a short or long rest. HBInstead, you may use your breath weapon a number of times equal to your Constitution modifier. You regain expended uses on a short or long rest",
                                    Range = "15' cone (DEX save)"
                                }
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>()
                        },
                        new SubRace() {
                            Name = "Silver",
                            Backstory = "Damagetype for these dragons is Cold",
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Cold Breath Weapon",
                                    SpellLevel=0,
                                    Description = "You can use your action to exhale destructive energy. It deals damage in an area according to your ancestry. When you use your breath weapon, all creatures in the area must make a saving throw, the type of which is determined by your ancestry. The DC of this saving throw is 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increase to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th level. After using your breath weapon, you cannot use it again until you complete a short or long rest. HBInstead, you may use your breath weapon a number of times equal to your Constitution modifier. You regain expended uses on a short or long rest",
                                    Range = "15' cone (CON  save)"
                                }
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>()
                        },
                        new SubRace() {
                            Name = "White",
                            Backstory = "Damagetype for these dragons is Cold",
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Cold Breath Weapon",
                                    SpellLevel=0,
                                    Description = "You can use your action to exhale destructive energy. It deals damage in an area according to your ancestry. When you use your breath weapon, all creatures in the area must make a saving throw, the type of which is determined by your ancestry. The DC of this saving throw is 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increase to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th level. After using your breath weapon, you cannot use it again until you complete a short or long rest. HBInstead, you may use your breath weapon a number of times equal to your Constitution modifier. You regain expended uses on a short or long rest",
                                    Range = "15' cone (CON  save)"
                                }
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>()
                        }
                    }
               }
                
                //Gnome
                ,new Race(){
                    Name = "Gnome",
                    AgeInfo = "Gnomes mature at the same rate as humans, and most are expected to settle into adult life around the age of 40. They can live to 350 years on average, but it's not too uncommon for them to reach 500 years of age",
                    SizeInfo = "Gnomes are between 3 and 4 feet tall and weigh around 40 pounds. Your size is Small",
                    AlignmentInfo = "Dragonborn tend towards extremes, making a conscious choice for one side or the other between Good and Evil (represented by Bahamut and Tiamat, respectively). More side with Bahamut than Tiamat (whose non-dragon followers are mostly kobolds), but villainous dragonborn can be quite terrible indeed. Some rare few choose to devote themselves to lesser dragon deities, such as Chronepsis (Neutral), and fewer still choose to worship Io, the Ninefold Dragon, who is all alignments at once",
                    BaseWalkingSpeed = 25,
                    BaseFlyingSpeed = 0,
                    ASBonus = new List<RaceAbilityScoreBonus>{
                        new RaceAbilityScoreBonus{Bonus = 2, AbilityScoreName="Intelligence"}
                    },
                    Traits = new List<Trait>{
                        new Trait{Name = "Darkvision", Description = "Accustomed to life underground, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray"},
                        new Trait{Name = "Gnome Cunning", Description = "You have advantage on all Intelligence, Wisdom, and Charisma saves against magic"}
                    },
                    Languages = new List<Language>{ new Language("Common"), new Language("Gnomish") },
                    Backstory = "A constant hum of busy activity pervades the warrens and neighborhoods where gnomes form their close-knit communities. Louder sounds punctuate the hum: a crunch of grinding gears here, a minor explosion there, a yelp of surprise or triumph, and especially bursts of laughter. Gnomes take delight in life, enjoying every moment of invention, exploration, investigation, creation, and play.",
                    SubRaces = new List<SubRace>{
                        new SubRace() {
                            Name = "Forest Gnome",
                            Backstory = "As a forest gnome, you have a natural knack for illusion and inherent quickness and stealth. In the worlds of D&D, forest gnomes are rare and secretive. They gather in hidden communities in sylvan forests, using illusions and trickery to conceal themselves from threats or to mask their escape should they be detected. Forest gnomes tend to be friendly with other good-spirited woodland folk, and they regard elves and good fey as their most important allies. These gnomes also befriend small forest animals and rely on them for information about threats that might prowl their lands",
                            Traits = new List<Trait>{
                                new Trait { Name = "Natural Illusionist", Description = "You know the Minor Illusion cantrip. Intelligence is your spellcasting modifier for it"},
                                new Trait {Name = "Speak with Small Beasts", Description = "Through sound and gestures, you may communicate simple ideas with Small or smaller beasts"}
                            },
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Minor Illusion",
                                    SpellLevel=0,
                                    Description = "You can use your action to exhale destructive energy. It deals damage in an area according to your ancestry. When you use your breath weapon, all creatures in the area must make a saving throw, the type of which is determined by your ancestry. The DC of this saving throw is 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increase to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th level. After using your breath weapon, you cannot use it again until you complete a short or long rest. HBInstead, you may use your breath weapon a number of times equal to your Constitution modifier. You regain expended uses on a short or long rest",
                                    Range = "5' by 30' line (DEX save)"
                                }
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>{new RaceAbilityScoreBonus { AbilityScoreName= "Dexterity", Bonus = 1} }
                        },
                        new SubRace() {
                            Name = "Rock Gnome",
                            Backstory = "As a rock gnome, you have a natural inventiveness and hardiness beyond that of other gnomes. Most gnomes in the worlds of D&D are rock gnomes, including the tinker gnomes of the Dragonlance setting",
                            Traits = new List<Trait>{
                                new Trait { Name = "Artificer's Lore", Description = "Whenever you make an Intelligence (History) check related to magical, alchemical, or technological items, you can add twice your proficiency bonus instead of any other proficiency bonus that may apply."},
                                new Trait {Name = "Tinker", Description = "You have proficiency with artisan tools (tinker's tools). Using those tools, you can spend 1 hour and 10 gp worth of materials to construct a Tiny clockwork device (AC 5, 1 hp). The device ceases to function after 24 hours (unless you spend 1 hour repairing it to keep the device functioning), or when you use your action to dismantle it; at that time, you can reclaim the materials used to create it. You can have up to three such devices active at a time. When you create a device, choose one of the following options:\r\nClockwork Toy. This toy is a clockwork animal, monster, or person, such as a frog, mouse, bird, dragon, or soldier. When placed on the ground, the toy moves 5 feet across the ground on each of your turns in a random direction. It makes noises as appropriate to the creature it represents.\r\nFire Starter. The device produces a miniature flame, which you can use to light a candle, torch, or campfire. Using the device requires your action.\r\nMusic Box. When opened, this music box plays a single song at a moderate volume. The box stops playing when it reaches the song's end or when it is closed.\r\nAt your DM's discretion, you may make other objects with effects similar in power to these. The Prestidigitation cantrip is a good baseline for such effects."}
                            },
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Acid Breath Weapon",
                                    SpellLevel=0,
                                    Description = "You can use your action to exhale destructive energy. It deals damage in an area according to your ancestry. When you use your breath weapon, all creatures in the area must make a saving throw, the type of which is determined by your ancestry. The DC of this saving throw is 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half as much damage on a successful one. The damage increase to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th level. After using your breath weapon, you cannot use it again until you complete a short or long rest. HBInstead, you may use your breath weapon a number of times equal to your Constitution modifier. You regain expended uses on a short or long rest",
                                    Range = "5' by 30' line (DEX save)"
                                }
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>()
                        }
                    }
               }

                //Halfling
                ,new Race(){
                    Name = "Halfling",
                    Backstory = "The comforts of home are the goals of most halflings' lives: a place to settle in peace and quiet, far from marauding monsters and clashing armies. Others form nomadic bands that travel constantly, lured by the open road and the wide horizon to discover the wonders of new lands and peoples. Halflings work readily with others, and they are loyal to their friends, whether halfling or otherwise. They can display remarkable ferocity when their friends, families, or communities are threatened",
                    AgeInfo = "A halfling reaches adulthood at the age of 20 and generally lives into the middle of his or her second century",
                    SizeInfo = "Halflings average about 3 feet tall and weigh about 40 pounds. Your size is small",
                    AlignmentInfo = "Most halflings are lawful good. As a rule, they are good-hearted and kind, hate to see others in pain, and have no tolerance for oppression. They are also very orderly and traditional, leaning heavily on the support of their community and the comfort of the old ways",
                    BaseWalkingSpeed = 25,
                    BaseFlyingSpeed = 0,
                    ASBonus = new List<RaceAbilityScoreBonus>
                    {
                        new RaceAbilityScoreBonus{Bonus = 2, AbilityScoreName = "Dexterity"}
                    },
                    Traits = new List<Trait>
                    {
                        new Trait{Name = "Lucky", Description = "When you roll a 1 on an attack roll, ability check, or saving throw, you can reroll the die. You must use the new result, even if it is a 1"},
                        new Trait{Name = "Brave", Description = "You have advantage on saving throws against being frightened"},
                        new Trait{Name = "Nimble", Description = "You can move through the space of any creature that is of a size larger than yours"},
                    },
                    Languages = new List<Language>{ new Language("Common"), new Language("Halfling") },
                    SubRaces = new List<SubRace>{
                        new SubRace() {
                            Name = "Lightfoot",
                            Backstory = "As a lightfoot halfling, you can easily hide from notice, even using other people as cover. You're inclined to be affable and get along well with others. In the Forgotten Realms, lightfoot halflings have spread the farthest and thus are the most common variety.\r\n\r\nLightfoots are more prone to wanderlust than other halflings, and often dwell alongside other races or take up a nomadic life. In the world of Grayhawk, these halflings are called hairfeet or tallfellows",
                            SpellsAndCantrips = new List<Spell>(),
                            Traits = new List<Trait>{ new Trait {Name = "Naturally Stealthy", Description = "You can attempt to hide even when you are only obscured by a creature that is at least one size larger than you" } },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>{ new RaceAbilityScoreBonus {AbilityScoreName = "Charisma", Bonus = 1 } }
                        },
                        new SubRace() {
                            Name = "Stout",
                            Backstory = "As a stout halfling, you're hardier than average and have some resistance to poison. Some say that stouts have dwarven blood. In the Forgotten Realms, these halflings are called stronghearts, and they're most common in the south",
                            SpellsAndCantrips = new List<Spell>(),
                            Traits = new List<Trait>{ new Trait {Name = "Stout Resilience", Description = "You have advantage on saving throws against poison, and you have resistance to poison damage" } },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>{ new RaceAbilityScoreBonus {AbilityScoreName = "Constitution ", Bonus = 1 } }
                        }
                    }
               }

                //Dwarf
                ,new Race(){
                    Name = "Dwarf",
                    Backstory = "Kingdoms rich in ancient grandeur, halls carved into the roots of mountains, the echoing of picks and hammers in deep mines and blazing forges, a commitment to clan and tradition, and a burning hatred of goblins and orcs – these common threads unite all dwarves",
                    AgeInfo = "Dwarves mature at the same rate as humans, but they're considered young until they reach the age of 50. On average, they live about 350 years",
                    SizeInfo = "Dwarves stand between 4 and 5 feet tall and average about 150 pounds. Your size is Medium",
                    AlignmentInfo = "Most dwarves are lawful, believing firmly in the benefits of a well-ordered society. They tend toward good as well, with a strong sense of fair play and a belief that everyone deserves to share in the benefits of a just order",
                    BaseWalkingSpeed = 25,
                    BaseFlyingSpeed = 0,
                    WeaponProficiencies = new List<string>{ "battleaxe", "handaxe", "light hammer", "warhammer" },
                    ItemProficiencies = new List<string>{"artisan's tools of choice: smith's tools, brewer's supplies, or mason's tools"},
                    ASBonus = new List<RaceAbilityScoreBonus>
                    {
                        new RaceAbilityScoreBonus{Bonus = 2, AbilityScoreName = "Dexterity"}
                    },
                    Traits = new List<Trait>
                    {
                        new Trait{Name = "Dwarven Legs", Description = "Your speed is not reduced by wearing heavy armor"},
                        new Trait{Name = "Darkvision", Description = "Accustomed to life underground, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray"},
                        new Trait{Name = "Dwarven Resilience", Description = "You have advantage on saving throws against poison, and you have resistance against poison damage"},
                        new Trait{Name = "Stonecunning", Description = "Whenever you make an Intelligence (History) check related to the origin of stonework, you are considered proficient in the History skill and add double your proficiency bonus to the check, instead of your normal proficiency bonus"},
                    },
                    Languages = new List<Language>{ new Language("Common"), new Language("Dwarvish") },
                    SubRaces = new List<SubRace>{
                        new SubRace() {
                            Name = "Hill Dwarf",
                            Backstory = "As a hill dwarf, you have keen senses, deep intuition, and remarkable resilience. The gold dwarves of Faerun in their mighty southern kingdom are hill dwarves, as are the exiled Neidar and the debased Klar of Krynn in the Dragonlance setting",
                            SpellsAndCantrips = new List<Spell>(),
                            Traits = new List<Trait>{ new Trait {Name = "Dwarven Toughness", Description = "Your hit point maximum increases by 1, and it increases by 1 every time you gain a level" } },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>{ new RaceAbilityScoreBonus {AbilityScoreName = "Wisdom", Bonus = 1 } }
                        },
                        new SubRace() {
                            Name = "Mountain Dwarf",
                            Backstory = "As a mountain dwarf, you're strong and hardy, accustomed to a difficult life in rugged terrain. You're probably on the tall side (for a dwarf), and tend toward lighter coloration, The shield dwarves of northern Faerun, as well as the ruling Hylar c1an and the noble Daewar c1an of Dragonlance, are mountain dwarves",
                            SpellsAndCantrips = new List<Spell>(),
                            Traits = new List<Trait>{ new Trait {Name = "Dwarven Armor Training", Description = "You have proficiency with light and medium armor" } },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>{ new RaceAbilityScoreBonus {AbilityScoreName = "Strength", Bonus = 2 } }
                        }
                    }
               }

                #region half elf
                //Half Elf
                 ,new Race(){
                     Name = "Half Elf",
                     Backstory = "Walking in two worlds but truly belonging to neither, half-elves combine what some say are the best qualities of their elf and human parents: human curiosity, inventiveness, and ambition tempered by the refined senses, love of nature, and artistic tastes of the elves",
                     ASBonus = new List<RaceAbilityScoreBonus>
                     {
                         new RaceAbilityScoreBonus{Bonus = 2, AbilityScoreName = "Charisma"},
                         new RaceAbilityScoreBonus{Bonus = 1, AbilityScoreName = "Choice"},
                         new RaceAbilityScoreBonus{Bonus = 1, AbilityScoreName = "Choice"}
                     },
                     AgeInfo = "Half-elves age at much the same rate as humans, reaching adulthood at the age of 20. They live much longer than humans, however, often exceeding 180 years",
                     AlignmentInfo = "Half-elves share the chaotic bent of their elven heritage. They both value personal freedom and creative expression, demonstrating neither love of leaders nor desire for followers. They chafe at rules, resent others' demands, and sometimes prove unreliable, or at least unpredictable. They are good and evil in equal numbers, a trait they share with their human parents",
                     SizeInfo = "Half-elves are more or less the same size as humans, ranging from 5 to 6 feet tall. Your size is Medium",
                     BaseWalkingSpeed = 30,
                     BaseFlyingSpeed = 0,
                     Traits = new List<Trait>
                     {
                         new Trait{Name = "Darkvision", Description = "Thanks to your elven heritage, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray"},
                         new Trait{Name = "Fey Ancestry", Description = "You have advantage on saving throws against being frightened"},
                         new Trait{Name = "Nimble", Description = "You have advantage on saving throws against being charmed, and magic can't put you to sleep"},
                     },
                     Languages = new List<Language>{ new Language("Common"), new Language("Elven"), new Language("Choice") },
                     SubRaces = new List<SubRace>{}
                }
                #endregion

                //Human
                ,new Race(){
                    Name = "Human",
                    Backstory = "In the reckonings of most worlds, humans are the youngest of the common races, late to arrive on the world scene and short-lived in comparison to dwarves, elves, and dragons. Perhaps it is because of their shorter lives that they strive to achieve as much as they can in the years they are given. Or maybe they feel they have something to prove to the elder races, and that's why they build their mighty empires on the foundation of conquest and trade. Whatever drives them, humans are the innovators, the achievers, and the pioneers of the worlds",
                    ASBonus = new List<RaceAbilityScoreBonus>
                    {
                        new RaceAbilityScoreBonus{Bonus = 1, AbilityScoreName = "Strength"},
                        new RaceAbilityScoreBonus{Bonus = 1, AbilityScoreName = "Dexterity"},
                        new RaceAbilityScoreBonus{Bonus = 1, AbilityScoreName = "Constitution"},
                        new RaceAbilityScoreBonus{Bonus = 1, AbilityScoreName = "Wisdom"},
                        new RaceAbilityScoreBonus{Bonus = 1, AbilityScoreName = "Intelligence"},
                        new RaceAbilityScoreBonus{Bonus = 1, AbilityScoreName = "Charisma"}
                    },
                    AgeInfo = "Humans reach adulthood in their late teens and live less than a century",
                    SizeInfo = "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium",
                    AlignmentInfo = "Humans tend toward no particular alignment. The best and the worst are found among them",
                    BaseWalkingSpeed = 30,
                    BaseFlyingSpeed = 0,
                    
                    Traits = new List<Trait>{},
                    Languages = new List<Language>{ new Language("Common"), new Language("Choice") },
                    SubRaces = new List<SubRace>{}
               }

                //Elf
                ,new Race(){
                    Name = "Elf",
                    Backstory = "Elves are a magical people of otherworldly grace, living in places of ethereal beauty, in the midst of ancient forests or in silvery spires glittering with faerie light, where soft music drifts through the air and gentle fragrances waft on the breeze. Elves love nature and magic, art and artistry, music and poetry",
                    ASBonus = new List<RaceAbilityScoreBonus>
                    {
                        new RaceAbilityScoreBonus{Bonus = 2, AbilityScoreName = "Dexterity"}
                    },
                    AgeInfo = "Although elves reach physical maturity at about the same age as humans, the elven understanding of adulthood goes beyond physical growth to encompass worldly experience. An elf typically claims adulthood and an adult name around the age of 100 and can live to be 750 years old",
                    AlignmentInfo = "Elves love freedom, variety, and self-expression, so they lean strongly towards the gentler aspects of chaos. They value and protect others' freedom as well as their own, and are good more often than not. Drow are an exception; their exile into the Underdark has made them vicious and dangerous. Drow are more often evil than not",
                    SizeInfo = "Elves range from under 5 to over 6 feet tall and have slender builds. Your size is Medium",
                    BaseWalkingSpeed = 30,
                    BaseFlyingSpeed = 0,
                    
                    Traits = new List<Trait>
                    {
                        new Trait{Name = "Darkvision", Description = "Accustomed to twilit forests and the night sky, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray"},
                        new Trait{Name = "Fey Ancestry", Description = "You have advantage on saving throws against being charmed, and magic can't put you to sleep"},
                        new Trait{Name = "Trance", Description = "Elves do not sleep. Instead they meditate deeply, remaining semi-conscious, for 4 hours a day. The Common word for this meditation is \"trance.\" While meditating, you dream after a fashion; such dreams are actually mental exercises that have become reflexive after years of practice. After resting in this way, you gain the same benefit a human would from 8 hours of sleep"},
                        new Trait{Name = "Keen Senses", Description = "You have proficiency in the Perception skill"},
                    },
                    Languages = new List<Language>{ new Language("Common"), new Language("Elven") },
                    SubRaces = new List<SubRace>{
                        new SubRace() {
                            Name = "Dark Elf",
                            Backstory = "Descended from an earlier subrace of dark-skinned elves, the drow were banished from the surface world for following the goddess Lolth down the path to evil and corruption. Now they have built their own civilization in the depths of the Underdark, patterned after the Way of Lolth. Also called dark elves. The drow have black skin that resembles polished obsidian and stark white or pale yellow hair. They commonly have very pale eyes (so pale as to be mistaken for while) in shades of lilac, silver, pink, red, and blue. They lend to be smaller and thinner than most elves.\r\n\r\nDrow adventurers are rare, and the race does not exist in all worlds. Check with your Dungeon Master to see if you can play a drow character",
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>{ new RaceAbilityScoreBonus {AbilityScoreName = "Charisma", Bonus = 1 } },
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{ 
                                    Name = "Dancing Lights",
                                    CastingTime = "1 action",
                                    Range = "120 feet",
                                    Duration = "Concentration, up to 1 minute",
                                    Description = "You create up to four torch-sized lights within range, making them appear as torches, lanterns, or glowing orbs that hover in the air for the duration. You can also combine the four lights into one glowing vaguely humanoid form of Medium size. Whichever form you choose, each light sheds dim light in a 10-foot radius.\r\n\r\nAs a bonus action on your turn, you can move the lights up to 60 feet to a new spot within range. A light must be within 20 feet of another light created by this spell, and a light winks out if it exceeds the spell’s range"
                                }
                            },
                            WeaponProficiencies = new List<string>{"rapiers", "shortswords", "hand crossbows"},
                            Traits = new List<Trait>{
                                new Trait {Name = "Superior Darkvision", Description = "Your darkvision has a range of 120 feet, instead of 60" },
                                new Trait {Name = "Sunlight Sensitivity", Description = "You have disadvantage on attack rolls and Wisdom (Perception) checks that rely on sight when you, the target of the attack, or whatever you are trying to perceive is in direct sunlight" },
                                new Trait {Name = "Drow Magic", Description = "You know the Dancing Lights cantrip. When you reach 3rd level, you can cast the Faerie Fire spell once with this trait and regain the ability to do so when you finish a long rest. When you reach 5th level, you can cast the Darkness spell onceand regain the ability to do so when you finish a long rest. Charisma is your spellcasting ability for these spells" },
                            }
                        },
                        new SubRace() {
                            Name = "High Elf",
                            Backstory = "As a high elf, you have a keen mind and a mastery of at least the basics of magic. In many of the worlds of D&D, there are two kinds of high elves. One type (which includes the gray elves and valley elves of Greyhawk, the Silvanesti of Dragonlance, and the sun elves of the Forgotten Realms) is haughty and reclusive, believing themselves to be superior to non-elves and even other elves. The other type (including the high elves of Greyhawk. the Qualinesti of Dragonlance, and the moon elves of the Forgotten Realms) are more common and more friendly, and often encountered among humans and other races.\r\n\r\nThe sun elves of Faerun (also called gold elves or sunrise elves) have bronze skin and hair of copper, black, or golden blood. Their eyes are golden, silver, or black. Moon elves (also called silver elves or gray elves) are much paler, with alabaster skin sometimes tinged with blue. They often have hair of silver-while, black, or blue, but various shades of blond, brown, and red are not uncommon. Their eyes are blue or green and flecked with gold",
                            SpellsAndCantrips = new List<Spell>(),
                            WeaponProficiencies = new List<string>{"longsword", "shortsword", "shortbow", "longbow"},
                            Traits = new List<Trait>
                            {
                                new Trait {Name = "High elf Cantrip", Description = "You know one cantrip of your choice from the Wizard spell list. Intelligence is your spellcasting ability for it" },
                            },
                            Languages = new List<Language>{ new Language { Name = "Choice"} },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>{ new RaceAbilityScoreBonus {AbilityScoreName = "Intelligence", Bonus = 1 } }
                        },
                        new SubRace() {
                            Name = "Wood Elf",
                            Backstory = "As a wood elf, you have keen senses and intuition, and your fleet feet carry you quickly and stealthily through your native forests. This category includes the wild elves (grugach) of Greyhawk and the Kagonesti of Dragonlance, as well as the races called wood elves in Greyhawk and the Forgotten Realms. In Faerun, wood elves (also called wild elves. green elves, or forest elves) are reclusive and distrusting of non-elves.\r\n\r\nWood elves' skin tends to be copperish in hue, sometimes with traces of green. Their hair tends toward browns and blacks, but it is occasionally blond or copper-colored. Their eyes are green, brown, or hazel",
                            WeaponProficiencies = new List<string>{"longsword", "shortsword", "shortbow", "longbow"},
                            SpellsAndCantrips = new List<Spell>(),
                            BaseWalkingSpeed = 35,
                            Traits = new List<Trait>
                            {
                                new Trait {Name = "Mask of the Wild", Description = "You can attempt to hide even when you are only lightly obscured by foliage, heavy rain, falling snow, mist, and other natural phenomena" },
                            },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>{ new RaceAbilityScoreBonus {AbilityScoreName = "Wisdom", Bonus = 1 } }
                        }
                    }
               }

                //Half Orc
                ,new Race(){
                    Name = "Half Orc",
                    Backstory = "When alliances between humans and orcs are sealed by marriages, half-orcs are born. Some half-orcs rise to become proud chiefs of orc tribes, their human blood giving them an edge over their full-blooded orc rivals. Some venture into the world to prove their worth among humans and other more civilized races. Many of these become adventurers, achieving greatness for their mighty deeds and notoriety for their barbaric customs and savage fury",
                    ASBonus = new List<RaceAbilityScoreBonus>
                    {
                        new RaceAbilityScoreBonus{Bonus = 2, AbilityScoreName = "Strength"},
                        new RaceAbilityScoreBonus{Bonus = 1, AbilityScoreName = "Constitution"}
                    },
                    AgeInfo = "Half-orcs mature a little faster than humans, reaching adulthood around age 14. They age noticeably faster and rarely live longer than 75 years",
                    AlignmentInfo = "Half-orcs inherit a tendency toward chaos from their orc parents and are not strongly inclined toward good. Half-orcs raised among orcs and willing to live out their lives among them are usually evil",
                    SizeInfo = "Half-orcs are somewhat larger and bulkier than humans, and they range from 5 to well over 6 feet tall. Your size is Medium",
                    BaseWalkingSpeed = 30,
                    BaseFlyingSpeed = 0,
                    Traits = new List<Trait>
                    {
                        new Trait{Name = "Darkvision", Description = "Thanks to your orc blood, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray"},
                        new Trait{Name = "Menacing", Description = "You gain proficiency in the Intimidation skill"},
                        new Trait{Name = "Relentless Endurance", Description = "When you are reduced to 0 hit points but not killed outright, you can drop to 1 hit point instead. You can't use this feature again until you finish a long rest"},
                        new Trait{Name = "Savage Attacks", Description = "When you score a critical hit with a melee weapon attack, you can roll one of the weapon's damage dice one additional time and add it to the extra damage of the critical hit"},
                    },
                    Languages = new List<Language>{ new Language("Common"), new Language("Orc") },
                    SubRaces = new List<SubRace>{}
               }

                //Tiefling
                ,new Race(){
                    Name = "Tiefling",
                    Backstory = "To be greeted with stares and whispers, to suffer violence and insult on the street, to see mistrust and fear in every eye: this is the lot of the tiefling. And to twist the knife, tieflings know that this is because a pact struck generations ago infused the essence of Asmodeus, overlord of the Nine Hells (and many of the other powerful devils serving under him) into their bloodline. Their appearance and their nature are not their fault but the result of an ancient sin, for which they and their children and their children's children will always be held accountable",
                    ASBonus = new List<RaceAbilityScoreBonus>
                    {
                        new RaceAbilityScoreBonus{Bonus = 2, AbilityScoreName = "Charisma"}
                    },
                    AgeInfo = "Tieflings mature at the same rate as humans but live a few years longer",
                    AlignmentInfo = "Tieflings might not have an innate tendency toward evil, but many of them end up there. Evil or not, an independent nature inclines many tieflings toward a chaotic alignment",
                    SizeInfo = "Tieflings are about the same size and build as humans. Your size is Medium",
                    BaseWalkingSpeed = 30,
                    BaseFlyingSpeed = 0,
                    Traits = new List<Trait>
                    {
                        new Trait{Name = "Darkvision", Description = "Thanks to your infernal heritage, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can’t discern color in darkness, only shades of gray"},
                        new Trait{Name = "Hellish Resistance", Description = "You have resistance to fire damage"},
                    },
                    Languages = new List<Language>{ new Language("Common"), new Language("Infernal")},
                    SubRaces = new List<SubRace>{
                        new SubRace() {
                            Name = "Default"
                        },
                        new SubRace() {
                            Name = "Bloodline of Asmodeus",
                            Backstory = "The tieflings connected to Nessus command the power of fire and darkness, guided by a keener than normal intellect, as befits those linked to Asmodeus himself",
                            SpellsAndCantrips = new List<Spell>
                            {
                                new Spell{
                                    Name = "Thaumaturgy",
                                    CastingTime = "1 action",
                                    Range = "30 feet",
                                    Duration = "Up to 1 minute",
                                    Description = "You manifest a minor wonder, a sign of supernatural power, within range. You create one of the following magical effects within range:\r\n\r\nYour voice booms up to three times as loud as normal for 1 minute.\r\nYou cause flames to flicker, brighten, dim, or change color for 1 minute.\r\nYou cause harmless tremors in the ground for 1 minute.\r\nYou create an instantaneous sound that originates from a point of your choice within range, such as a rumble of thunder, the cry of a raven, or ominous whispers.\r\nYou instantaneously cause an unlocked door or window to fly open or slam shut.\r\nYou alter the appearance of your eyes for 1 minute.\r\nIf you cast this spell multiple times, you can have up to three of its 1-minute effects active at a time, and you can dismiss such an effect as an action."
                                }
                            },
                            Traits = new List<Trait>{ new Trait {Name = "Infernal Legacy", Description = "You know the Thaumaturgy cantrip. Once you reach 3rd level, you can cast the Hellish Rebuke spell once as a 2nd-level spell. Once you reach 5th level, you can also cast the Darkness spell once. You must finish a long rest to cast these spells again with this trait. Charisma is your spellcasting ability for these spells" } },
                            AbilityScoreBonus = new List<RaceAbilityScoreBonus>{ new RaceAbilityScoreBonus {AbilityScoreName = "Intelligence", Bonus = 1 } }
                        }
                    }
               }
            };
        }

        public async Task<List<Race>> GetAllRaces()
        {
            List<Race> races = new List<Race>();
            var pathString = Path.Combine(basepath, "Data\\Races\\");

            var charactersPaths = System.IO.Directory.GetFiles(pathString);
            foreach (var path in charactersPaths)
            {
                Race race = new Race();
                string raceString = await File.ReadAllTextAsync(path);
                race = JsonConvert.DeserializeObject<Race>(raceString);
                races.Add(race);
            }
            return races;
        }
    }
}
