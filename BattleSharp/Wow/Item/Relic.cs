using System.Collections.Generic;

namespace BattleSharp.Wow.Item {
    public class Relic {
        public int Socket { get; set; }
        public int ItemId { get; set; }
        public int Context { get; set; }
        public ICollection<int> BonusLists { get; set; }
    }
}