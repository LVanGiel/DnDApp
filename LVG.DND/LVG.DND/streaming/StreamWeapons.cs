using LVG.DND.AppConstants;
using LVG.DND.Models;
using Newtonsoft.Json;

namespace LVG.DND.streaming
{
    public class StreamWeapons
    {
        List<Weapon> weapons = new List<Weapon>();
        string basepath = FileSystem.Current.AppDataDirectory;
        public StreamWeapons()
        {
            PushWeapons();
        }
        private void PushWeapons()
        {
            var pathRaces = Path.Combine(basepath, @"Data\Weapons\");
            var pathString = Path.Combine(basepath, @"Data\");
            AddWeapons();

            System.IO.Directory.CreateDirectory(pathString);
            System.IO.Directory.CreateDirectory(pathRaces);

            foreach (Weapon weapon in weapons)
            {
                CreateWeaponsFile(weapon, pathRaces);
            }

        }
        private void CreateWeaponsFile(Weapon weapon, string basepath)
        {
            var txtName = weapon.Name.Replace(" ", "") + ".txt";
            var path = Path.Combine(basepath, txtName);

            CreateFileCheck(path);
            File.WriteAllText(path, JsonConvert.SerializeObject(weapon));
        }
        internal void CreateFileCheck(string path)
        {
            if (!File.Exists(path))
            {
                using (File.Create(path))
                {

                }
            }
        }

        public void AddWeapons()
        {

            weapons = new List<Weapon>
            {
                #region Simple weapons
                new Weapon
                {
                    Name="Club",
                    Value = new MoneyBag{Silver = 1 },
                    DamageType = WeaponsConstants.BLUDGEONING,
                    DiceSize= 4,
                    DiceCount = 1,
                    Weight = 2
                },
                new Weapon
                {
                    Name="Dagger",
                    Value = new MoneyBag{Gold = 2 },
                    DamageType = WeaponsConstants.PIERCING,
                    DiceSize= 4,
                    DiceCount = 1,
                    Weight = 1,
                    IsThrown = true,
                    Range = "(20/60)"
                },
                new Weapon
                {
                    Name="Greatclub",
                    Value = new MoneyBag{Silver = 2 },
                    DamageType = WeaponsConstants.BLUDGEONING,
                    DiceSize= 8,
                    DiceCount = 1,
                    Weight = 10,
                    IsTwohanded = true
                },
                new Weapon
                {
                    Name="Handaxe",
                    Value = new MoneyBag{Gold = 5 },
                    DamageType = WeaponsConstants.SLASHING,
                    DiceSize= 6,
                    DiceCount = 1,
                    Weight = 2,
                    IsThrown = true,
                    Range = "(20/60)"
                },
                new Weapon
                {
                    Name="Javelin",
                    Value = new MoneyBag{Silver = 5 },
                    DamageType = WeaponsConstants.PIERCING,
                    DiceSize= 6,
                    DiceCount = 1,
                    Weight = 2,
                    IsThrown = true,
                    Range = "(30/120)"
                },
                new Weapon
                {
                    Name="Light hammer",
                    Value = new MoneyBag{Gold = 2 },
                    DamageType = WeaponsConstants.BLUDGEONING,
                    DiceSize= 4,
                    DiceCount = 1,
                    Weight = 2,
                    IsThrown = true,
                    Range = "(20/60)"
                },
                new Weapon
                {
                    Name="Mace",
                    Value = new MoneyBag{Gold = 5 },
                    DiceCount = 1,
                    DiceSize= 6,
                    DamageType = WeaponsConstants.BLUDGEONING,
                    Weight = 4
                },
                new Weapon
                {
                    Name="Quarterstaff",
                    Value = new MoneyBag{Silver = 2 },
                    DiceCount = 1,
                    DiceSize= 6,
                    DamageType = WeaponsConstants.BLUDGEONING,
                    Weight = 4,
                    IsVersatile = true,
                    VersatileDice = 8
                },
                new Weapon
                {
                    Name="Sickle",
                    Value = new MoneyBag{Gold = 1 },
                    DiceCount = 1,
                    DiceSize= 4,
                    DamageType = WeaponsConstants.SLASHING,
                    Weight = 2
                },
                new Weapon
                {
                    Name="Spear",
                    Value = new MoneyBag{Gold = 1 },
                    DiceCount = 1,
                    DiceSize= 6,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 3,
                    IsThrown = true,
                    Range = "(20/60)",
                    IsVersatile = true,
                    VersatileDice = 8
                },
                new Weapon
                {
                    Name="Light crossbow",
                    Value = new MoneyBag{Gold = 25},
                    DiceCount = 1,
                    DiceSize= 8,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 5,
                    IsRanged = true,
                    Range = "(80/320)",
                    IsVersatile = true,
                    VersatileDice = 8,
                    AmmoType = WeaponsConstants.CROSSBOW_BOLTS,
                    IsTwohanded = true
                },
                new Weapon
                {
                    Name="Dart",
                    Value = new MoneyBag{Copper = 5},
                    DiceCount = 1,
                    DiceSize= 4,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 1/4,
                    IsThrown = true,
                    Range = "(20/60)"
                },
                new Weapon
                {
                    Name="Shortbow",
                    Value = new MoneyBag{Gold = 25},
                    DiceCount = 1,
                    DiceSize= 6,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 2,
                    IsRanged = true,
                    Range = "(80/320)",
                    AmmoType = WeaponsConstants.ARROWS,
                    IsTwohanded = true
                },
                new Weapon
                {
                    Name="Sling",
                    Value = new MoneyBag{Silver = 1},
                    DiceCount = 1,
                    DiceSize= 4,
                    DamageType = WeaponsConstants.PIERCING,
                    IsRanged = true,
                    Range = "(30/120)",
                    AmmoType = WeaponsConstants.SLING_BULLETS,
                }
                #endregion

                #region Martial weapons
                ,new Weapon
                {
                    IsMartial= true,
                    Name="Battleaxe",
                    Value = new MoneyBag{Gold = 10 },
                    DiceCount = 1,
                    DiceSize= 8,
                    DamageType = WeaponsConstants.SLASHING,
                    Weight = 4,
                    IsVersatile = true,
                    VersatileDice = 10
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Flail",
                    Value = new MoneyBag{Gold = 10 },
                    DiceCount = 1,
                    DiceSize= 8,
                    DamageType = WeaponsConstants.BLUDGEONING,
                    Weight = 2
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Glaive",
                    Value = new MoneyBag{Gold = 20 },
                    DiceCount = 1,
                    DiceSize= 10,
                    DamageType = WeaponsConstants.SLASHING,
                    Weight = 6,
                    IsTwohanded= true,
                    HasReach = true,
                    Range = "5 feet"
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Greataxe",
                    Value = new MoneyBag{Gold = 30 },
                    DiceCount = 1,
                    DiceSize= 12,
                    DamageType = WeaponsConstants.SLASHING,
                    Weight = 7,
                    IsTwohanded= true
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Greatsword",
                    Value = new MoneyBag{Gold = 50 },
                    DiceCount = 2,
                    DiceSize= 6,
                    DamageType = WeaponsConstants.SLASHING,
                    Weight = 6,
                    IsTwohanded= true,
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Halberd",
                    Value = new MoneyBag{Gold = 20 },
                    DiceCount = 1,
                    DiceSize= 10,
                    DamageType = WeaponsConstants.SLASHING,
                    Weight = 6,
                    IsTwohanded= true,
                    HasReach = true,
                    Range = "5 feet"
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Lance",
                    Value = new MoneyBag{Gold = 10 },
                    DiceCount = 1,
                    DiceSize= 12,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 6,
                    HasReach = true,
                    Range = "5 feet",
                    ExtraInfo = "You have disadvantage when you use a lance to attack a target within 5 feet of you. Also, a lance requires two hands to wield when you aren’t mounted"
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Longsword",
                    Value = new MoneyBag{Gold = 15},
                    DiceCount = 1,
                    DiceSize= 8,
                    DamageType = WeaponsConstants.SLASHING,
                    Weight = 3,
                    IsVersatile = true,
                    VersatileDice = 10
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Maul",
                    Value = new MoneyBag{Gold = 10},
                    DiceCount = 2,
                    DiceSize= 6,
                    DamageType = WeaponsConstants.BLUDGEONING,
                    Weight = 10,
                    IsTwohanded = true
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Morningstar",
                    Value = new MoneyBag{Gold = 15},
                    DiceCount = 1,
                    DiceSize= 8,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 4
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Pike",
                    Value = new MoneyBag{Gold = 5},
                    DiceCount = 1,
                    DiceSize= 10,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 18,
                    HasReach = true,
                    Range = "5 feet",
                    IsTwohanded = true
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Rapier",
                    Value = new MoneyBag{Gold = 25},
                    DiceCount = 1,
                    DiceSize= 8,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 2
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Scimitar",
                    Value = new MoneyBag{Gold = 25},
                    DiceCount = 1,
                    DiceSize= 6,
                    DamageType = WeaponsConstants.SLASHING,
                    Weight = 3
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Shortsword",
                    Value = new MoneyBag{Gold = 10},
                    DiceCount = 1,
                    DiceSize= 6,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 2
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Trident",
                    Value = new MoneyBag{Gold = 5},
                    DiceCount = 1,
                    DiceSize= 6,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 4,
                    IsThrown=true,
                    Range = "(20/60)",
                    IsVersatile =true,
                    VersatileDice = 8
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="War pick",
                    Value = new MoneyBag{Gold = 5},
                    DiceCount = 1,
                    DiceSize= 8,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 2
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Warhammer",
                    Value = new MoneyBag{Gold = 15},
                    DiceCount = 1,
                    DiceSize= 8,
                    DamageType = WeaponsConstants.BLUDGEONING,
                    Weight = 2,
                    IsVersatile=true,
                    VersatileDice= 10
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Whip",
                    Value = new MoneyBag{Gold = 2},
                    DiceCount = 1,
                    DiceSize= 4,
                    DamageType = WeaponsConstants.SLASHING,
                    Weight = 3,
                    HasReach=true,
                    Range = "5 feet"
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Blowgun",
                    Value = new MoneyBag{Gold = 10},
                    DiceCount = 0,
                    DiceSize= 1,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 1,
                    IsRanged=true,
                    Range = "(25/100)",
                    AmmoType = WeaponsConstants.BLOWGUN_NEEDLES
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Hand crossbow",
                    Value = new MoneyBag{Gold = 50},
                    DiceCount = 1,
                    DiceSize= 6,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 3,
                    IsRanged=true,
                    Range = "(30/120)",
                    AmmoType = WeaponsConstants.CROSSBOW_BOLTS
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Heavy crossbow",
                    Value = new MoneyBag{Gold = 50},
                    DiceCount = 1,
                    DiceSize= 10,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 18,
                    IsRanged=true,
                    Range = "(100/400)",
                    AmmoType = WeaponsConstants.CROSSBOW_BOLTS,
                    IsTwohanded =true
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Longbow",
                    Value = new MoneyBag{Gold = 50},
                    DiceCount = 1,
                    DiceSize= 8,
                    DamageType = WeaponsConstants.PIERCING,
                    Weight = 2,
                    IsRanged=true,
                    Range = "(150/600)",
                    AmmoType = WeaponsConstants.ARROWS,
                    IsTwohanded =true
                },
                new Weapon
                {
                    IsMartial= true,
                    Name="Net",
                    Value = new MoneyBag{Gold = 1},
                    DiceCount = 0,
                    DiceSize= 0,
                    Weight = 3,
                    IsThrown=true,
                    Range = "(5/15)",
                    ExtraInfo = "A Large or smaller creature hit by a net is restrained until it is freed. A net has no effect on creatures that are formless, or creatures that are Huge or larger. A creature can use its action to make a DC 10 Strength check, freeing itself or another creature within its reach on a success. Dealing 5 slashing damage to the net (AC 10) also frees the creature without harming it, ending the effect and destroying the net. When you use an action, bonus action, or reaction to attack with a net, you can make only one attack regardless of the number of attacks you can normally make"
                }
                #endregion
            };
            
        }

    }
}
