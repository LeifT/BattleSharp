using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleSharp.Wow.RealmStatus   {
    [JsonObject]
    public class RealmList : IEnumerable<Realm> {
        [JsonProperty(PropertyName = "realms")]
        public ICollection<Realm> Realms { get; private set; }

        public IEnumerator<Realm> GetEnumerator() {
            return Realms.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}