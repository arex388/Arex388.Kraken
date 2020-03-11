using Newtonsoft.Json;

namespace Arex388.Kraken {
    public abstract class RequestBase {
        [JsonProperty("auth")]
        public Authorization Authorization { get; set; }

        [JsonIgnore]
        internal abstract string Endpoint { get; }
    }
}