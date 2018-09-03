using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace Arex388.Kraken {
	public abstract class RequestBase {
		private byte[] _fileBlob;
		private string _fileName;

		[JsonProperty("auth")]
		public Authorization Authorization { get; set; }
		[JsonProperty("auto_orient")]
		public bool AutoOrient { get; set; }
		[JsonProperty("callback_url")]
		public string CallbackUrl { get; set; }
		[JsonProperty("sampling_scheme")]
		public string ChromaSampling { get; set; } = ChromaSamplingType.FourFourFour;
		public Convert Convert { get; set; }
		public bool Dev { get; set; }
		[JsonIgnore]
		public string Endpoint {
			get {
				if (string.IsNullOrEmpty(Url)) {
					return "https://api.kraken.io/v1/upload";
				}

				return "https://api.kraken.io/v1/url";
			}
		}
		[JsonIgnore]
		public byte[] FileBlob {
			get => _fileBlob ?? File.ReadAllBytes(FilePath);
			set => _fileBlob = value;
		}
		[JsonIgnore]
		public string FileExtension {
			get {
				if (string.IsNullOrEmpty(FileName)) {
					return Path.GetExtension(FilePath).ToLower();
				}

				return Path.GetExtension(FileName).ToLower();
			}
		}
		[JsonIgnore]
		public string FileName {
			get => _fileName ?? Path.GetFileName(FilePath);
			set => _fileName = value;
		}
		[JsonIgnore]
		public string FilePath { get; set; }
		public bool Lossy { get; set; }
		[JsonProperty("preserve_meta")]
		public IEnumerable<string> MetadataToPreserve { get; set; }
		[JsonIgnore]
		public virtual HttpMethod Method { get; } = HttpMethod.Post;
		public int? Quality { get; set; }
		public object Resize { get; set; }
		public string Url { get; set; }
		public virtual bool Wait { get; }
		public bool WebP { get; set; }
	}
}