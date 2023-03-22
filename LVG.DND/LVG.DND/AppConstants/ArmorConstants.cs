using LVG.DND.Models;

namespace LVG.DND.AppConstants
{
    public class ArmorConstants
    {
        public static string LIGHT_ARMOR = "Light armor";
        public static string MEDIUM_ARMOR = "Medium armor";
        public static string HEAVY_ARMOR = "Heavy armor";
        public static string SHIELD_TYPE = "Shield";

        public List<Armor> GetAll(string type = "")
        {
            var list = new List<Armor>();
            if (type == LIGHT_ARMOR || type == "")
            {
                list.Add(PADDED);
                list.Add(LEATHER);
                list.Add(STUDDED_LEATHER);
            }
            if (type == MEDIUM_ARMOR || type == "")
            {
                list.Add(HIDE);
                list.Add(CHAIN_SHIRT);
                list.Add(SCALE_MAIL);
                list.Add(SPIKED_ARMOR);
                list.Add(BREASTPLATE);
                list.Add(HALFPLATE);
            }
            if (type == HEAVY_ARMOR || type == "")
            {
                list.Add(RING_MAIL);
                list.Add(CHAIN_MAIL);
                list.Add(SPLINT);
                list.Add(PLATE);
            }
            if (type == SHIELD_TYPE || type == "")
            {
                list.Add(SHIELD);
            }
            return list;
        }

        #region light armor
        public static Armor PADDED = new Armor {Name = "Padded", ArmorClass = 11, HasStealthDisadvantage = true, Weight = 8, Value = new MoneyBag { Gold = 5 }, IsLight = true };
        public static Armor LEATHER = new Armor
        {
            Name = "Leather",
            ArmorClass = 11,
            HasStealthDisadvantage = false,
            Weight = 10,
            Value = new MoneyBag { Gold = 10 },
            IsLight = true
        };
        public static Armor STUDDED_LEATHER = new Armor
        {
            Name = "Studded Leather",
            ArmorClass = 12,
            HasStealthDisadvantage = false,
            Weight = 13,
            Value = new MoneyBag { Gold = 45 },
            IsLight = true
        };
        #endregion

        #region medium armor
        public static Armor HIDE = new Armor
        {
            Name = "Hide",
            ArmorClass = 12,
            HasStealthDisadvantage = false,
            Weight = 12,
            Value = new MoneyBag { Gold = 10 },
            IsMedium = true
        };
        public static Armor CHAIN_SHIRT = new Armor
        {
            Name = "Chain Shirt",
            ArmorClass = 13,
            HasStealthDisadvantage = false,
            Weight = 20,
            Value = new MoneyBag { Gold = 50 },
            IsMedium = true
        };
        public static Armor SCALE_MAIL = new Armor
        {
            Name = "Scale Mail",
            ArmorClass = 14,
            HasStealthDisadvantage = true,
            Weight = 45,
            Value = new MoneyBag { Gold = 50 },
            IsMedium = true
        };
        public static Armor SPIKED_ARMOR = new Armor
        {
            Name = "Spiked Armor",
            ArmorClass = 14,
            HasStealthDisadvantage = true,
            Weight = 45,
            Value = new MoneyBag { Gold = 75 },
            IsMedium = true
        };
        public static Armor BREASTPLATE = new Armor
        {
            Name = "Breastplate",
            ArmorClass = 14,
            HasStealthDisadvantage = false,
            Weight = 20,
            Value = new MoneyBag { Gold = 400 },
            IsMedium = true
        };
        public static Armor HALFPLATE = new Armor
        {
            Name = "Halfplate",
            ArmorClass = 15,
            HasStealthDisadvantage = true,
            Weight = 40,
            Value = new MoneyBag { Gold = 750 },
            IsMedium = true
        };
        #endregion

        #region heavy armor
        public static Armor RING_MAIL = new Armor
        {
            Name = "Ring Mail",
            ArmorClass = 14,
            HasStealthDisadvantage = true,
            Weight = 40,
            Value = new MoneyBag { Gold = 30 },
            IsHeavy = true
        };
        public static Armor CHAIN_MAIL = new Armor
        {
            Name = "Chain Mail",
            ArmorClass = 16,
            HasStealthDisadvantage = true,
            Weight = 55,
            Value = new MoneyBag { Gold = 75 },
            IsHeavy = true,
            StrengthRequirement = 13
        };
        public static Armor SPLINT = new Armor
        {
            Name = "Splint",
            ArmorClass = 17,
            HasStealthDisadvantage = true,
            Weight = 60,
            Value = new MoneyBag { Gold = 200 },
            IsHeavy = true,
            StrengthRequirement = 15
        };
        public static Armor PLATE = new Armor
        {
            Name = "Plate",
            ArmorClass = 18,
            HasStealthDisadvantage = true,
            Weight = 65,
            Value = new MoneyBag { Gold = 1500 },
            IsHeavy = true,
            StrengthRequirement = 15
        };
        #endregion

        #region Shield
        public static Armor SHIELD = new Armor
        {
            Name = "Shield",
            ArmorClass = 2,
            HasStealthDisadvantage = false,
            Weight = 6,
            Value = new MoneyBag { Gold = 10 },
            IsShield = true
        };
        #endregion
    }
}
