using System.Collections.Generic;

namespace BattleSharp.Wow.Item {
    public class BonusChance {
        public string ChanceType { get; set; }
        public ICollection<Stat> Stats { get; set; }
        public ICollection<Socket> Sockets { get; set; }
    }
}