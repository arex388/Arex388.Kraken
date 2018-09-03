using Newtonsoft.Json;

namespace Arex388.Kraken {
	public sealed class Authorization {
		[JsonProperty("api_key")]
		public string Access { get; set; }
		[JsonProperty("api_secret")]
		public string Secret { get; set; }
	}
}