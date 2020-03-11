using Newtonsoft.Json;

namespace Arex388.Kraken {
    public sealed class Authorization {
        /// <summary>
        /// Your Kraken.io API access key.
        /// </summary>
        [JsonProperty("api_key")]
        public string Access { get; set; }

        /// <summary>
        /// Your Kraken.io API secret key.
        /// </summary>
        [JsonProperty("api_secret")]
        public string Secret { get; set; }
    }
}