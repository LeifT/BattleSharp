using System.Collections.Generic;

namespace BattleSharp.Wow.Item {
    public class BonusChance {
        public string ChanceType { get; set; }
        public Upgrade Upgrade { get; set; }
        public ICollection<Stat> Stats { get; set; }
        public ICollection<Socket> Sockets { get; set; }

        public class Stat {
            private Stat() {
                
            }

            public string StatId { get; set; }
            public int Delta { get; set; }
            public int MaxDelta { get; set; }
        }
    }
}