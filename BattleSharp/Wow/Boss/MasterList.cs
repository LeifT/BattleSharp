using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleSharp.Wow.Boss {
    [JsonObject]
    public class MasterList : IEnumerable<Boss> {
        public ICollection<Boss> Bosses { get; set; }

        public IEnumerator<Boss> GetEnumerator() {
            return Bosses.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}