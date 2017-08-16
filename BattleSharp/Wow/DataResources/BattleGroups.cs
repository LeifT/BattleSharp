using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleSharp.Wow.DataResources {
    public class BattleGroups : IEnumerable<BattleGroup> {
        [JsonProperty(PropertyName = "battlegroups")]
        private ICollection<BattleGroup> Groups { get; }

        public IEnumerator<BattleGroup> GetEnumerator() {
            return Groups.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}