using System.Collections.Generic;

namespace BattleSharp.Wow.Item {
    public class ItemSet {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SetBonus> SetBonuses { get; set; }
        public ICollection<int> Items { get; set; }
    }
}