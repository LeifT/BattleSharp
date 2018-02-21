using System.Threading.Tasks;
using BattleSharp.Utilities;
using BattleSharp.Wow.Achievement;
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

        #region Achievement API 

        public async Task<Achievement> GeAchievement(int achievementId) {
            return await JsonUtilities.DeserializeUrlAync<Achievement>($"https://eu.api.battle.net/wow/achievement/{achievementId}?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        #endregion

        #region Auction API

        public async Task<AuctionDataStatus> GetAuctionDataStatus(string realm) {
            return await JsonUtilities.DeserializeUrlAync<AuctionDataStatus>($"https://eu.api.battle.net/wow/auction/data/{realm}?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        public async Task<AuctionDataDump> GetAuctionDataDump(AuctionFile auctionHouseFile) {
            return await JsonUtilities.DeserializeUrlAync<AuctionDataDump>(auctionHouseFile.Url).ConfigureAwait(false);
        }

        public async Task<AuctionDataDump> GetAuctionDataDump(string realm) {
            var files = await GetAuctionDataStatus(realm);
            return await GetAuctionDataDump(files.Files[0]).ConfigureAwait(false);
        }

        #endregion

        #region Boss API

        public async Task<MasterList> GetMasterList() {
            return await JsonUtilities.DeserializeUrlAync<MasterList>($"https://eu.api.battle.net/wow/boss/?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        public async Task<Boss> GetBoss(int bossId) {
            return await JsonUtilities.DeserializeUrlAync<Boss>($"https://eu.api.battle.net/wow/boss/{bossId}?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        #endregion

        #region Item API

        public async Task<Item> GetItem(int itemId) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://us.api.battle.net/wow/item/{itemId}?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        public async Task<Item> GetItem(int itemId, params int[] bonusList) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://us.api.battle.net/wow/item/{itemId}?bl={string.Join(",", bonusList)}&locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        public async Task<Item> GetItem(int itemId, string context) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://us.api.battle.net/wow/item/{itemId}/{context}?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        public async Task<Item> GetItem(int itemId, string context, params int[] bonusList) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://us.api.battle.net/wow/item/{itemId}/{context}?bl={string.Join(",", bonusList)}&locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        // TODO Get item set

        public async Task<ItemClasses> GetItemClasses() {
            return await JsonUtilities.DeserializeUrlAync<ItemClasses>($"https://us.api.battle.net/wow/data/item/classes?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        #endregion

        #region Realm Status API 

        public async Task<RealmList> GetRealmStatus() {
            return await JsonUtilities.DeserializeUrlAync<RealmList>($"https://eu.api.battle.net/wow/realm/status?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        public async Task<RealmList> GetRealmStatus(params string[] realms) {
            return await JsonUtilities.DeserializeUrlAync<RealmList>($"https://eu.api.battle.net/wow/realm/status?realms={string.Join(",", realms)}&locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        #endregion

        #region Spell API

        public async Task<Spell> GetSpell(int spellId) {
            return await JsonUtilities.DeserializeUrlAync<Spell>($"https://eu.api.battle.net/wow/spell/{spellId}?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        #endregion
    }
}
