using System.Runtime.Serialization;
using BattleSharp.Wow.SpellAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BattleSharp.Wow.Item {
    public class ItemSpell {
        public int SpellId { get; set; }
        public Spell Spell { get; set; }
        public int NCharges { get; set; }
        public bool Consumable { get; set; }
        public int CategoryId { get; set; }
        public Trigger Trigger { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Trigger {
        [EnumMember(Value = "NONE")]
        None,
        [EnumMember(Value = "ON_EQUIP")]
        OnEquip,
        [EnumMember(Value = "ON_USE")]
        OnUse,
        [EnumMember(Value = "ON_PROC")]
        OnProc,
        [EnumMember(Value = "ON_PICKUP")]
        OnPickup,
        [EnumMember(Value = "ON_LEARN")]
        OnLearn
    }
}