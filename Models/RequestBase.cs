using Newtonsoft.Json;

namespace Arex388.Kraken {
    public abstract class RequestBase {
        [JsonProperty("auth")]
        internal Authorization Authorization { get; set; }

        [JsonIgnore]
        internal abstract string Endpoint { get; }
    }
}