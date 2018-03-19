using System.Collections.Generic;

namespace BattleSharp.Wow.DataResources {
    public class ItemClass {
        public int Class { get; set; }
        public string Name { get; set; }
        public ICollection<ItemSubclass> Subclasses { get; set; }
    } 
}