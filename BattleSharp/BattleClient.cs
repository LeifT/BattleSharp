using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BattleSharp.Utilities;
using BattleSharp.Wow.Achievement;
using BattleSharp.Wow.AuctionAPI;
using BattleSharp.Wow.BossAPI;
using BattleSharp.Wow.DataResources;
using BattleSharp.Wow.Item;
using BattleSharp.Wow.Mount;
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

        // TODO: Challenge Mode API 

        // TODO: Character Profile API 

        // TODO: Guild Profile API

        #region Item API

        public async Task<Item> GetItem(int itemId) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://eu.api.battle.net/wow/item/{itemId}?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        public async Task<Item> GetItem(int itemId, params int[] bonusList) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://eu.api.battle.net/wow/item/{itemId}?bl={string.Join(",", bonusList)}&locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        public async Task<Item> GetItem(int itemId, string context) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://eu.api.battle.net/wow/item/{itemId}/{context}?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        public async Task<Item> GetItem(int itemId, string context, params int[] bonusList) {
            return await JsonUtilities.DeserializeUrlAync<Item>($"https://eu.api.battle.net/wow/item/{itemId}/{context}?bl={string.Join(",", bonusList)}&locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        public async Task<ItemSet> GetItemSet(int setId) {
            return await JsonUtilities.DeserializeUrlAync<ItemSet>($"https://eu.api.battle.net/wow/item/set/{setId}?apikey={ApiKey}").ConfigureAwait(false);
        }

        #endregion

        public async Task<ICollection<Mount>> GetMounts() {
            return await JsonUtilities.DeserializeUrlAync<ICollection<Mount>>($"https://eu.api.battle.net/wow/mount/?apikey={ApiKey}").ConfigureAwait(false);
        }

        // TODO: Pet API 

        // TODO: PVP API 

        // TODO: Quest API 

        #region Realm Status API 

        public async Task<RealmList> GetRealmStatus() {
            return await JsonUtilities.DeserializeUrlAync<RealmList>($"https://eu.api.battle.net/wow/realm/status?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        public async Task<RealmList> GetRealmStatus(params string[] realms) {
            return await JsonUtilities.DeserializeUrlAync<RealmList>($"https://eu.api.battle.net/wow/realm/status?realms={string.Join(",", realms)}&locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        #endregion

        // TODO: Recipe API 

        #region Spell API

        public async Task<Spell> GetSpell(int spellId) {
            return await JsonUtilities.DeserializeUrlAync<Spell>($"https://eu.api.battle.net/wow/spell/{spellId}?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        #endregion

        // TODO: Zone API 

        // TODO: Data Resources 

        #region Data Resources 

        public async Task<ItemClasses> GetItemClasses() {
            return await JsonUtilities.DeserializeUrlAync<ItemClasses>($"https://us.api.battle.net/wow/data/item/classes?locale=en_GB&apikey={ApiKey}").ConfigureAwait(false);
        }

        #endregion
    }
}
