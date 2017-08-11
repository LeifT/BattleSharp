using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BattleSharp.Utilities;
using BattleSharp.Wow;
using Newtonsoft.Json.Linq;

namespace BattleSharp
{
    public class BattleClient {
        public string ApiKey { get; set; }

        public BattleClient(string apiKey) {
            ApiKey = apiKey;
        }

        public async Task<List<AuctionHouseFile>> GetAuctionHouseFiles(string realm) {
            var client = new HttpClient();
            var jsonstring = client.GetStringAsync($"https://eu.api.battle.net/wow/auction/data/{realm}?locale=en_GB&apikey={ApiKey}");
            return JObject.Parse(await jsonstring.ConfigureAwait(false)).SelectToken("files").ToObject<List<AuctionHouseFile>>();
        }

        public async Task<AuctionHouseData> GetAuctionHouseData(AuctionHouseFile auctionHouseFile) {
            return await JsonUtilities.DeserializeUrlAync<AuctionHouseData>(auctionHouseFile.Url);
        }

        public async Task<AuctionHouseData> GetAuctionHouseData(string realm) {
            var files = await GetAuctionHouseFiles(realm).ConfigureAwait(false);
            return await GetAuctionHouseData(files[0]).ConfigureAwait(false);
        }
    }
}
