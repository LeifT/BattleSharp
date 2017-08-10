using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BattleSharp.Utilities;
using BattleSharp.Wow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BattleSharp
{
    public class BattleClient {
        public string APIKey { get; set; }

        public BattleClient(string apiKey) {
            APIKey = apiKey;
        }

        //internal T DeserializeData<T>(string url)
        //{
        //    var client = new HttpClient();
        //    JsonSerializer serializer = new JsonSerializer();

        //    using (var s = client.GetStreamAsync(url).Result)
        //    using (StreamReader reader = new StreamReader(s))
        //    using (JsonTextReader jsonReader = new JsonTextReader(reader))
        //    {
        //        return serializer.Deserialize<T>(jsonReader);
        //    }
        //}

        //internal void PopulateData<T>(string url, out T asd) {

        //    var client = new HttpClient();
        //    JsonSerializer serializer = new JsonSerializer();

        //    using (var s = client.GetStreamAsync(url).Result)
        //    using (StreamReader reader = new StreamReader(s))
        //    using (JsonTextReader jsonReader = new JsonTextReader(reader)) {
        //        serializer.Populate(jsonReader, asd);
        //    }
        //}

        public IList<Auction> GetAuctionsNew(string realm) {
            var client = new HttpClient();
            var jsonstring = client.GetStringAsync($"http://auction-api-us.worldofwarcraft.com/auction-data/ab1239c3bc437d48321a64e6b5e5ab7f/auctions.json").GetAwaiter().GetResult();
            
            JObject googleSearch = JObject.Parse(jsonstring);

            var results = googleSearch["auctions"].Children();
            IList<Auction> searchResults = new List<Auction>();

            foreach (JToken result in results) {
                Auction searchResult = result.ToObject<Auction>();
                searchResults.Add(searchResult);
            }

            return searchResults;
        }

        public async Task<IList<Auction>> GetAuctionsNewAsync(string realm) {
            var client = new HttpClient();
            var task = client.GetStreamAsync("http://auction-api-us.worldofwarcraft.com/auction-data/ab1239c3bc437d48321a64e6b5e5ab7f/auctions.json");

            JObject googleSearch;
   
            using (StreamReader streamReader = new StreamReader(await task.ConfigureAwait(false))) {
                using (JsonTextReader jsonReader = new JsonTextReader(streamReader)) {
                    googleSearch = await JObject.LoadAsync(jsonReader);
                }
            }

            var results = googleSearch["auctions"].Children();
            IList<Auction> searchResults = new List<Auction>();

            foreach (JToken result in results) {
                Auction searchResult = result.ToObject<Auction>();
                searchResults.Add(searchResult);
            }

            return searchResults;
        }

        public Auctions GetAuctions2(string realm) {
            var client = new HttpClient();
            var jsonstring = client.GetStringAsync($"https://eu.api.battle.net/wow/auction/data/{realm}?locale=en_GB&apikey={APIKey}").GetAwaiter().GetResult();
            var files = JsonConvert.DeserializeObject<AuctionFiles>(jsonstring, new AuctionFileConverter());

            HashSet<string> urlSet = new HashSet<string>();
            List<string> urlList = new List<string>();

            foreach (var auctionFile in files) {
                if (urlSet.Add(auctionFile.Url)) {
                    urlList.Add(auctionFile.Url);
                }
            }

            return JsonConvert.DeserializeObject<Auctions>(client.GetStringAsync(urlList[0]).GetAwaiter().GetResult(), new AuctionConverter());
        }

        public Auctions GetAuctions(string realm) {
            var files = JsonUtilities.DeserializeStreamFromUrl<AuctionFiles>($"https://eu.api.battle.net/wow/auction/data/{realm}?locale=en_GB&apikey={APIKey}");

            HashSet<string> urlSet = new HashSet<string>();
            List<string> urlList = new List<string>();

            foreach (var auctionFile in files) {
                if (urlSet.Add(auctionFile.Url)) {
                    urlList.Add(auctionFile.Url);
                }
            }

            return JsonUtilities.DeserializeStreamFromUrl<Auctions>(urlList[0]);
        }

        public async Task <Auctions> GetAuctionsAsync(string realm) {
            var files = JsonUtilities.DeserializeStreamFromUrlAync<AuctionFiles>($"https://eu.api.battle.net/wow/auction/data/{realm}?locale=en_GB&apikey={APIKey}");
            
            HashSet<string> urlSet = new HashSet<string>();
            List<string> urlList = new List<string>();

            foreach (var auctionFile in await files) {
                if (urlSet.Add(auctionFile.Url)) {
                    urlList.Add(auctionFile.Url); 
                }
            }
            
            return await JsonUtilities.DeserializeStreamFromUrlAync<Auctions>(urlList[0]);
        }
        
        //public async Task<T> DeserializeData2<T>(string url) {
        //    var client = new HttpClient();
        //    var stringTask = client.GetStringAsync(url);
            
        //    return JsonConvert.DeserializeObject<T>(await stringTask);
        //}
    }
}
