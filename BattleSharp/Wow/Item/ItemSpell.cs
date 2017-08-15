using System.Runtime.Serialization;
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
        Equip,
        [EnumMember(Value = "ON_USE")]
        Use,
        [EnumMember(Value = "ON_PROC")]
        Proc,
        [EnumMember(Value = "ON_PICKUP")]
        Pickup,
        [EnumMember(Value = "ON_LEARN")]
        Learn
    }
}