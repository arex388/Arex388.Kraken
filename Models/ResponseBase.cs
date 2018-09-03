using System.Collections.Generic;
using Newtonsoft.Json;

namespace Arex388.Kraken {
	public abstract class ResponseBase {
		[JsonProperty("saved_bytes")]
		public int BytesSaved { get; set; }
		[JsonProperty("file_name")]
		public string FileName { get; set; }
		[JsonProperty("kraked_size")]
		public int KrakedSize { get; set; }
		[JsonProperty("kraked_url")]
		public string KrakedUrl { get; set; }
		public string Message { get; set; }
		[JsonProperty("original_height")]
		public int OriginalHeight { get; set; }
		[JsonProperty("original_size")]
		public int OriginalSize { get; set; }
		[JsonProperty("original_width")]
		public int OriginalWidth { get; set; }
		public IEnumerable<ResponseBase> Results { get; set; }
		public bool Success { get; set; }
	}
}