using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace Arex388.Kraken {
	public abstract class RequestBase {
		private byte[] _fileBlob;
		private string _fileName;

		[JsonProperty("auth")]
		public Authorization Authorization { get; set; }
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
		[JsonIgnore]
		public virtual HttpMethod Method { get; } = HttpMethod.Post;
		public string Url { get; set; }
	}
}