using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleSharp.Wow.RealmStatus   {
    [JsonObject]
    public class Realms : IEnumerable<Realm> {
        [JsonProperty(PropertyName = "realms")]
        public ICollection<Realm> RealmList { get; set; }

        public IEnumerator<Realm> GetEnumerator() {
            return RealmList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}