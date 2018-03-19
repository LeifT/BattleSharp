using System.Collections.Generic;

namespace BattleSharp.Wow.Achievement {
    public class Achievement {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
        public ICollection<Item.Item> RewardItems { get; set; }
        public string Icon { get; set; }
        public ICollection<Criteria> Criteria { get; set; }
        public bool AccountWide { get; set; }
        public int FactionId { get; set; }
    }
}