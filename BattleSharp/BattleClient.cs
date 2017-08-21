using System.Threading.Tasks;
using BattleSharp.Utilities;
using BattleSharp.Wow.AuctionAPI;
using BattleSharp.Wow.BossAPI;
using BattleSharp.Wow.DataResources;
using BattleSharp.Wow.Item;
using BattleSharp.Wow.RealmStatus;
using BattleSharp.Wow.SpellAPI;

namespace BattleSharp {
    public class BattleClient {
        public  string  ApiKey { get; }

        public BattleClient(string apiKey) {
            ApiKey = apiKey;
        }

        #region Auction API 

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

        #region Boss API

        public async Task<MasterList> GetMasterList() {
            return await JsonUtilities.DeserializeUrlAync<MasterList>($"https://eu.api.battle.net/wow/boss/?locale=en_GB&apikey={ApiKey}");
        }

        public async Task<Boss> GetBoss(int bossId) {
            return await JsonUtilities.DeserializeUrlAync<Boss>($"https://eu.api.battle.net/wow/boss/{bossId}?locale=en_GB&apikey={ApiKey}");
        }

        #endregion

        #region Item API

        public async Task<Item> GetItem(int itemId) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://us.api.battle.net/wow/item/{itemId}?locale=en_GB&apikey={ApiKey}");
        }

        public async Task<Item> GetItem(int itemId, params int[] bonusList) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://us.api.battle.net/wow/item/{itemId}?bl={string.Join(",", bonusList)}&locale=en_GB&apikey={ApiKey}");
        }

        public async Task<Item> GetItem(int itemId, string context) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://us.api.battle.net/wow/item/{itemId}/{context}?locale=en_GB&apikey={ApiKey}");
        }

        public async Task<Item> GetItem(int itemId, string context, params int[] bonusList) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://us.api.battle.net/wow/item/{itemId}/{context}?bl={string.Join(",", bonusList)}&locale=en_GB&apikey={ApiKey}");
        }

        public async Task<ItemClasses> GetItemClasses() {
            return await JsonUtilities.DeserializeUrlAync<ItemClasses>($"https://us.api.battle.net/wow/data/item/classes?locale=en_GB&apikey={ApiKey}");
        }

        #endregion

        #region Spell API

        public async Task<Spell> GetSpell(int spellId) {
            return await JsonUtilities.DeserializeUrlAync<Spell>($"https://eu.api.battle.net/wow/spell/{spellId}?locale=en_GB&apikey={ApiKey}");
        }

        #endregion

        #region Realm API

        public async Task<Realms> GetRealms() {
            return await JsonUtilities.DeserializeUrlAync<Realms>($"https://eu.api.battle.net/wow/realm/status?locale=en_GB&apikey={ApiKey}");
        }

        public async Task<Realms> GetRealms(params string[] realms) {
            return await JsonUtilities.DeserializeUrlAync<Realms>($"https://eu.api.battle.net/wow/realm/status?realms={string.Join(",", realms)}&locale=en_GB&apikey={ApiKey}");
        }

        #endregion
    }
}
