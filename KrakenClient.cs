using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Arex388.Kraken {
	public sealed class KrakenClient {
		private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings {
			ContractResolver = new CamelCasePropertyNamesContractResolver(),
			NullValueHandling = NullValueHandling.Ignore
		};

		private HttpClient Client { get; }
		private string AccessKey { get; }
		private string SecretKey { get; }

		public KrakenClient(
			HttpClient client,
			string accessKey,
			string secretKey) {
			Client = client ?? throw new ArgumentNullException(nameof(client));
			AccessKey = accessKey ?? throw new ArgumentNullException(nameof(accessKey));
			SecretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
		}

		public async Task<byte[]> DownloadAsync(
			string url) {
			if (string.IsNullOrEmpty(url)) {
				return null;
			}

			try {
				return await Client.GetByteArrayAsync(url);
			} catch (HttpRequestException) {
				return null;
			}
		}

		public async Task<OptimizeResponse> GetOptimizeAsync(
			string filePath,
			int? width = null,
			int? height = null) {
			var request = new OptimizeRequest {
				FilePath = filePath
			};

			if (width.HasValue
				&& height.HasValue) {
				request.Resize = new Resize {
					Height = height.Value,
					Width = width.Value
				};
			}

			return await GetOptimizeAsync(request);
		}

		public async Task<OptimizeResponse> GetOptimizeAsync(
			byte[] fileBlob,
			string fileName,
			int? width = null,
			int? height = null) {
			var request = new OptimizeRequest {
				FileBlob = fileBlob,
				FileName = fileName
			};

			if (width.HasValue
				&& height.HasValue) {
				request.Resize = new Resize {
					Height = height.Value,
					Width = width.Value
				};
			}

			return await GetOptimizeAsync(request);
		}

		public async Task<OptimizeResponse> GetOptimizeAsync(
			OptimizeRequest request) {
			if (request == null) {
				return null;
			}

			var response = await GetResponseAsync(request);

			return JsonConvert.DeserializeObject<OptimizeResponse>(response);
		}

		public async Task<OptimizeWaitResponse> GetOptimizeWaitAsync(
			string filePath,
			int? width = null,
			int? height = null) {
			var request = new OptimizeWaitRequest {
				FilePath = filePath
			};

			if (width.HasValue
				&& height.HasValue) {
				request.Resize = new Resize {
					Height = height.Value,
					Width = width.Value
				};
			}

			return await GetOptimizeWaitAsync(request);
		}

		public async Task<OptimizeWaitResponse> GetOptimizeWaitAsync(
			byte[] fileBlob,
			string fileName,
			int? width = null,
			int? height = null) {
			var request = new OptimizeWaitRequest {
				FileBlob = fileBlob,
				FileName = fileName
			};

			if (width.HasValue
				&& height.HasValue) {
				request.Resize = new Resize {
					Height = height.Value,
					Width = width.Value
				};
			}

			return await GetOptimizeWaitAsync(request);
		}

		public async Task<OptimizeWaitResponse> GetOptimizeWaitAsync(
			OptimizeWaitRequest request) {
			if (request == null) {
				return null;
			}

			var response = await GetResponseAsync(request);

			return JsonConvert.DeserializeObject<OptimizeWaitResponse>(response);
		}

		private async Task<string> GetResponseAsync(
			RequestBase request) {
			request.Authorization = new Authorization {
				Access = AccessKey,
				Secret = SecretKey
			};

			try {
				if (request.Method == HttpMethod.Get) {
					return await Client.GetStringAsync(request.Endpoint);
				}

				var body = JsonConvert.SerializeObject(request, JsonSerializerSettings);

				using (var content = new MultipartFormDataContent())
				using (var stringContent = new StringContent(body))
				using (var byteContent = new ByteArrayContent(request.FileBlob)) {
					content.Add(stringContent, "json");
					content.Add(byteContent, "file", request.FileName);

					using (var message = await Client.PostAsync(request.Endpoint, content)) {
						return await message.Content.ReadAsStringAsync();
					}
				}
			} catch (HttpRequestException) {
				return null;
			}
		}
	}
}