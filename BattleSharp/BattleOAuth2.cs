using System.Collections.Generic;
using System.Threading.Tasks;
using BattleSharp.Utilities;

namespace BattleSharp
{
    public class BattleOAuth2 {
        private string _client_id;
        private string _client_secret;

        public BattleOAuth2(string clientId, string clientSecret) {
            _client_id = clientId;
            _client_secret = clientSecret;
        }

        public async Task<Token> GetAccessToken() {
            return await JsonUtilities.DeserializeUrlAync<Token>($"https://eu.battle.net/oauth/token?grant_type=client_credentials&client_id={_client_id}&client_secret={_client_secret}").ConfigureAwait(false);
        }

        public async Task<Token> GetTokenDetails(string accessToken) {
            return await JsonUtilities.DeserializeUrlAync<Token>($"https://eu.battle.net/oauth/token?grant_type=client_credentials&client_id={_client_id}&client_secret={_client_secret}").ConfigureAwait(false);
        }
    }

    public class Token {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }

    //public class Authority {
    //    public string authority { get; set; }
    //}

    public class TokenDetails {
        public int Exp { get; set; }
        public List<string> Authorities { get; set; }
        public string ClientId { get; set; }
    }
}
