using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BattleSharp.Wow.DataResources {
    [JsonObject]
    public class ItemClasses : IEnumerable<ItemClass> {
        public IList<ItemClass> Classes { get; set; }

        public IEnumerator<ItemClass> GetEnumerator() {
            return Classes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}