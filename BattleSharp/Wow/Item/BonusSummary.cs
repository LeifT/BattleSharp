using System.Collections.Generic;

namespace BattleSharp.Wow.Item {
    public class BonusSummary {
        public ICollection<int> DefaultBonusLists { get; set; }
        public ICollection<int> ChanceBonusLists { get; set; }
        public ICollection<int> BonusChances { get; set; }
    }
}