using System.Threading.Tasks;
using BattleSharp.Utilities;

namespace BattleSharp
{
    public class BattleOAuth2 {
        private string _client_id;
        private string _client_secret;

        public BattleOAuth2(string client_id, string client_secret) {
            _client_id = client_id;
            _client_secret = client_secret;
        }

        public async Task<Token> GetAccessToken() {
            return await JsonUtilities.DeserializeUrlAync<Token>($"https://eu.battle.net/oauth/token?grant_type=client_credentials&client_id={_client_id}&client_secret={_client_secret}");
        }
    }

    public class Token {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}
