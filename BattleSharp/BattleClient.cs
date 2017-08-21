using System.Threading.Tasks;
using BattleSharp.Utilities;
using BattleSharp.Wow.Auction;
using BattleSharp.Wow.DataResources;
using BattleSharp.Wow.Item;
using BattleSharp.Wow.RealmStatus;

namespace BattleSharp {
    public class BattleClient {
        public  string  ApiKey { get; }

        public BattleClient(string apiKey) {
            ApiKey = apiKey;
        }

        #region Auction House

        public async Task<AuctionDataStatus> GetAuctionFiles(string realm) {
            return await JsonUtilities.DeserializeUrlAync<AuctionDataStatus>($"https://eu.api.battle.net/wow/auction/data/{realm}?locale=en_GB&apikey={ApiKey}");
        }

        public async Task<AuctionDataDump> GetAuctionData(AuctionFile auctionHouseFile) {
            return await JsonUtilities.DeserializeUrlAync<AuctionDataDump>(auctionHouseFile.Url);
        }

        public async Task<AuctionDataDump> GetAuctionData(string realm) {
            var files = await GetAuctionFiles(realm);
            return await GetAuctionData(files.Files[0]);
        }

        #endregion

        #region Item

        public async Task<Item> GetItem(int itemId) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://us.api.battle.net/wow/item/{itemId}?locale=en_GB&apikey={ApiKey}");
        }

        public async Task<ItemClasses> GetItemClasses() {
            return await JsonUtilities.DeserializeUrlAync<ItemClasses>($"https://us.api.battle.net/wow/data/item/classes?locale=en_GB&apikey={ApiKey}");
        }

        #endregion

        #region Realm

        public async Task<Realms> GetRealms() {
            return await JsonUtilities.DeserializeUrlAync<Realms>($"https://eu.api.battle.net/wow/realm/status?locale=en_GB&apikey={ApiKey}");
        }

        public async Task<Realms> GetRealms(params string[] realms) {
            return await JsonUtilities.DeserializeUrlAync<Realms>($"https://eu.api.battle.net/wow/realm/status?realms={string.Join(",", realms)}&locale=en_GB&apikey={ApiKey}");
        }

        #endregion
    }
}
