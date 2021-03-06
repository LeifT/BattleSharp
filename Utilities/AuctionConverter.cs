﻿using System;
using System.Linq;
using Newtonsoft.Json;
using BattleSharp.Wow.AuctionAPI;
using Newtonsoft.Json.Linq;

namespace BattleSharp.Utilities
{
    public class AuctionConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            Console.WriteLine("Auction converter");

            if (reader.TokenType == JsonToken.Null) {
                return string.Empty;
            }
            
            JObject item = JObject.Load(reader);

            var auction = new Auction {
                Auc = item["auc"].Value<int>(),
                Item = item["item"].Value<int>(),
                Owner = item["owner"].Value<string>(),
                OwnerRealm = item["ownerRealm"].Value<string>(),
                Bid = item["bid"].Value<long>(),
                Buyout = item["buyout"].Value<long>(),
                Quantity = item["quantity"].Value<int>(),
                TimeLeft = item["timeLeft"].Value<string>(),
                Rand = item["rand"].Value<int>(),
                Seed = item["seed"].Value<long>(),
                Context = item["context"].Value<int>()
            };

            var bonusLists = item["bonusLists"];
            if (bonusLists != null && bonusLists.HasValues) {
                int[] bonus = new int[bonusLists.Children<JObject>().Count()];
                int index = 0;

                foreach (var child in bonusLists.Children<JObject>()) {
                    bonus[index] = child["bonusListId"].Value<int>();
                    index++;
                }
                auction.BonusLists = bonus;
            }

            var modifiers = item["modifiers"];
            if (modifiers != null && modifiers.HasValues) {
                int[,] temp = new int[modifiers.Children<JObject>().Count(), 2];
                int index = 0;

                foreach (var child in modifiers.Children<JObject>()) {
                    temp[index, 0] = child["type"].Value<int>();
                    temp[index, 1] = child["value"].Value<int>();
                    index++;
                }
                auction.Modifiers = temp;
            } 

            return auction;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
