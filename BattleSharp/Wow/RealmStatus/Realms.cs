using System.Collections;
using System.Collections.Generic;

namespace BattleSharp.Wow.RealmStatus   {
    public class Realms : IEnumerable<Realm> {
        public ICollection<Realm> RealmList { get; set; }

        public IEnumerator<Realm> GetEnumerator() {
            return RealmList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}