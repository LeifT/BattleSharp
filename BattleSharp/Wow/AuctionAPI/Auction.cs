namespace BattleSharp.Wow.AuctionAPI {
    public class Auction {
        public long Auc;
        public int Item;
        public string Owner;
        public string OwnerRealm;
        public long Bid;
        public long Buyout;
        public int Quantity;
        public string TimeLeft;
        public long Rand;
        public long Seed;
        public int Context;
        public BonusList[] BonusLists;
        public Modifier[] Modifiers { get; set; }
        public int PetSpeciesId;        // Pet
        public int PetBreedId;          // Pet
        public int PetLevel;            // Pet
        public int PetQualityId;        // Pet

        public override string ToString() {
            return $"{Item} {Owner}";
        }
    }
}