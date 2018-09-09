using System.Collections.Generic;
using Newtonsoft.Json;

namespace Arex388.Kraken {
	public sealed class OptimizeWaitRequest :
		RequestBase {
		[JsonProperty("auto_orient")]
		public bool AutoOrient { get; set; }
		[JsonProperty("callback_url")]
		public string CallbackUrl { get; set; }
		[JsonProperty("sampling_scheme")]
		public string ChromaSampling { get; set; } = ChromaSamplingType.FourFourFour;
		public Convert Convert { get; set; }
		public bool Lossy { get; set; }
		[JsonProperty("preserve_meta")]
		public IEnumerable<string> MetadataToPreserve { get; set; }
		[JsonIgnore]
		public int? Quality { get; set; }
		public object Resize { get; set; }
		public bool Wait { get; } = true;
		public bool WebP { get; set; }
	}
}