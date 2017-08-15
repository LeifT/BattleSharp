using System.Collections.Generic;

namespace BattleSharp.Wow.Item {

    // TODO: Fix this monster

    public class Item {
        public int Id { get; set; }
        public int DisenchantingSkillRank { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Stackable { get; set; }
        public ICollection<int> AllowableClasses { get; set; }
        public ICollection<int> AllowableRaces { get; set; }
        public int ItemBind { get; set; }
        public ICollection<BonusStats> BonusStats { get; set; }
        public ICollection<ItemSpell> ItemSpells { get; set; }
        public int BuyPrice { get; set; }
        public int ItemClass { get; set; }
        public int ItemSubClass { get; set; }
        public int ContainerSlots { get; set; }
        public WeaponInfo WeaponInfo { get; set; }
        public int InventoryType { get; set; }
        public bool Equippable { get; set; }
        public int ItemLevel { get; set; }
        public TooltipParams TooltipParams { get; set; }    //
        public ICollection<Stat> Stats { get; set; } // 
        public int MaxCount { get; set; }
        public int MaxDurability { get; set; }
        public int MinFactionId { get; set; }
        public int MinReputation { get; set; }
        public int Quality { get; set; }
        public int SellPrice { get; set; }
        public int RequiredSkill { get; set; }
        public int RequiredLevel { get; set; }
        public int RequiredSkillRank { get; set; }
        public ItemSource ItemSource { get; set; }
        public int BaseArmor { get; set; }
        public bool HasSockets { get; set; }
        public bool IsAuctionable { get; set; }
        public int Armor { get; set; }
        public int DisplayInfoId { get; set; }
        public string NameDescription { get; set; }
        public string NameDescriptionColor { get; set; }
        public bool Upgradable { get; set; }
        public bool HeroicTooltip { get; set; }
        public string Context { get; set; }
        public ICollection<int> BonusLists { get; set; }
        public ICollection<string> AvailableContexts { get; set; }
        public BonusSummary BonusSummary { get; set; }
        public int ArtifactId { get; set; }
        public int ArtifactAppearanceId { get; set; } //
        public ICollection<ArtifactTrait> ArtifactTraits { get; set; } //
        public ICollection<Relic> Relics { get; set; }      //
        public Appearance Appearance { get; set; }          // 

        public override string ToString() {
            return Name;
        }
    }

    //public enum Quality {
    //    Poor,
    //    Common,
    //    Uncommon,
    //    Rare,
    //    Epic,
    //    Legendary,
    //    Artifact,
    //    Heirloom
    //}
}