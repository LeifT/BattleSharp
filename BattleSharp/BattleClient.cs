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

namespace BattleSharp
{
    public class BattleClient {
        public string APIKey { get; set; }

        public BattleClient(string apiKey) {
            APIKey = apiKey;
        }

        //internal T DeserializeData<T>(string url) {
        //    var client = new HttpClient();
        //    JsonSerializer serializer = new JsonSerializer();

        //    using (var s = client.GetStreamAsync(url).Result)
        //    using (StreamReader reader = new StreamReader(s))
        //    using (JsonTextReader jsonReader = new JsonTextReader(reader)) {
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

        public async Task <Auctions> GetAuctions(string realm) {

            var files = JsonUtilities.DeserializeStreamFromUrl<AuctionFiles>($"https://eu.api.battle.net/wow/auction/data/{realm}?locale=en_GB&apikey={APIKey}");
            
            HashSet<string> urlSet = new HashSet<string>();
            List<string> urlList = new List<string>();

            foreach (var auctionFile in await files) {
                if (urlSet.Add(auctionFile.Url)) {
                    urlList.Add(auctionFile.Url); 
                }
            }

             var hello = JsonUtilities.DeserializeStreamFromUrl<Auctions>(urlList[0]);

            foreach (var auction in await hello) {
                Console.WriteLine(auction.item);
            }

            var auctions = JsonUtilities.DeserializeStreamFromUrl<Auctions>(urlList[0]);

      
            //for (int i = 1; i < auctions.Count(); i++) {
            //    auctions (JsonUtilities.DeserializeStreamFromUrl<Auctions>(urlList[i]));

            //}
            

            return null;
        }
        
        //public async Task<T> DeserializeData2<T>(string url) {
        //    var client = new HttpClient();
        //    var stringTask = client.GetStringAsync(url);
            
        //    return JsonConvert.DeserializeObject<T>(await stringTask);
        //}
    }
}
