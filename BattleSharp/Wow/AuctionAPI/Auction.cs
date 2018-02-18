using BattleSharp.Utilities;
using Newtonsoft.Json;

namespace BattleSharp.Wow.AuctionAPI {
    [JsonConverter(typeof(AuctionConverter))]
    public class Auction {
        public int Auc { get; set; }
        public int Item { get; set; }
        public string Owner { get; set; }
        public string OwnerRealm { get; set; }
        public long Bid { get; set; }
        public long Buyout { get; set; }
        public int Quantity { get; set; }
        public string TimeLeft { get; set; }
        public int Rand { get; set; }
        public long Seed { get; set; }
        public int Context { get; set; }
        public int[] BonusLists { get; set; }
        public int[,] Modifiers { get; set; }
        public int PetSpeciesId { get; set; }        // Pet
        public int PetBreedId { get; set; }          // Pet
        public int PetLevel { get; set; }           // Pet
        public int PetQualityId { get; set; }       // Pet

        public override string ToString() {
            return $"{Auc} {Item} {Owner}";
        }
    }
}