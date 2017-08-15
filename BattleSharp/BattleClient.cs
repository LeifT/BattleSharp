using System.Threading.Tasks;
using BattleSharp.Utilities;
using BattleSharp.Wow.Auction;
using BattleSharp.Wow.Item;

namespace BattleSharp {
    public class BattleClient {
        public  string  ApiKey { get; }

        public BattleClient(string apiKey) {
            ApiKey = apiKey;
        }

        #region Auction House

        public async Task<AuctionDataStatus> GetAuctionHouseFiles(string realm) {
            return await JsonUtilities.DeserializeUrlAync<AuctionDataStatus>($"https://eu.api.battle.net/wow/auction/data/{realm}?locale=en_GB&apikey={ApiKey}");
        }

        public async Task<AuctionDataDump> GetAuctionHouseData(AuctionFile auctionHouseFile) {
            return await JsonUtilities.DeserializeUrlAync<AuctionDataDump>(auctionHouseFile.Url);
        }

        public async Task<AuctionDataDump> GetAuctionHouseData(string realm) {
            var files = await GetAuctionHouseFiles(realm).ConfigureAwait(false);
            return await GetAuctionHouseData(files.Files[0]).ConfigureAwait(false);
        }

        #endregion

        #region Item

        public async Task<Item> GetItem(int itemId) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://us.api.battle.net/wow/item/{itemId}?locale=en_GB&apikey={ApiKey}");
        }

        #endregion
    }
}
