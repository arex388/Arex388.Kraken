using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Arex388.Kraken {
    public sealed class KrakenClient {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        /// <summary>
        /// The maximum number of resizes allowed for an optimization.
        /// </summary>
        private const byte MaxResizeCount = 10;

        /// <summary>
        /// An instance of Authorization containing the access and secret keys for the Kraken.io API.
        /// </summary>
        private Authorization Authorization { get; }

        /// <summary>
        /// Is debugging enabled.
        /// </summary>
        private bool Debug { get; }

        /// <summary>
        /// An instance of HttpClient.
        /// </summary>
        private HttpClient HttpClient { get; }

        /// <summary>
        /// Kraken.io API client.
        /// </summary>
        /// <param name="httpClient">An instance of HttpClient.</param>
        /// <param name="accessKey">Your Kraken.io API access key.</param>
        /// <param name="secretKey">Your Kraken.io API secret key.</param>
        /// <param name="debug">Toggle capturing the raw JSON response from Kraken.io and returning it as part of the deserialized response object.</param>
        public KrakenClient(
            HttpClient httpClient,
            string accessKey,
            string secretKey,
            bool debug = false) {
            if (!accessKey.HasValue()) {
                throw new ArgumentNullException(nameof(accessKey));
            }

            if (!secretKey.HasValue()) {
                throw new ArgumentNullException(nameof(secretKey));
            }

            Authorization = new Authorization {
                Access = accessKey,
                Secret = secretKey
            };
            Debug = debug;
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Download the kraked image.
        /// </summary>
        /// <param name="url">The kraked image's URL.</param>
        /// <returns>A byte array.</returns>
        public async Task<byte[]> DownloadAsync(
            string url) {
            if (url is null) {
                return null;
            }

            try {
                return await HttpClient.GetByteArrayAsync(url);
            } catch (HttpRequestException) {
                return null;
            }
        }

        /// <summary>
        /// Optimize a source image using a file path using the default optimization settings.
        /// </summary>
        /// <param name="filePath">The source image's file path.</param>
        /// <returns>An OptimizeResponse.</returns>
        public Task<OptimizeResponse> OptimizeAsync(
            string filePath) {
            var fileBlob = File.ReadAllBytes(filePath);
            var fileName = Path.GetFileName(filePath);

            return OptimizeAsync(fileBlob, fileName);
        }

        /// <summary>
        /// Optimize a source image using a byte array using the default optimization settings.
        /// </summary>
        /// <param name="fileBlob">The source image's byte array.</param>
        /// <param name="fileName">The source image's file name.</param>
        /// <returns>An OptimizeResponse.</returns>
        public Task<OptimizeResponse> OptimizeAsync(
            byte[] fileBlob,
            string fileName) => OptimizeAsync(new OptimizeRequest {
                FileBlob = fileBlob,
                FileName = fileName
            });

        /// <summary>
        /// Optimize a source image using a custom request.
        /// </summary>
        /// <param name="request">An OptimizeRequest instance.</param>
        /// <returns>An OptimizeResponse.</returns>
        public async Task<OptimizeResponse> OptimizeAsync(
            OptimizeRequest request) {
            //  Check if the request is null and return an invalid response if it is.

            if (request is null) {
                return InvalidRequestResponse;
            }

            if (request.Resize.HasItems()) {
                //  Check if the resize count is more than the max allowed.

                if (request.Resize.Count() > MaxResizeCount) {
                    return InvalidResizeCountResponse;
                }

                //  Validate if the resize dimensions are correct.

                var validResizeDimensions = ValidateResizeDimensions(request.Resize);

                if (!validResizeDimensions) {
                    return InvalidResizeDimensionsResponse;
                }
            }

            //  Get the request's response and deserialize it into an OptimizeResponse instance.

            var response = await GetResponseAsync(request);
            var optimizeResponse = JsonConvert.DeserializeObject<OptimizeResponse>(response);

            if (Debug) {
                optimizeResponse.Json = response;
            }

            return optimizeResponse;
        }

        /// <summary>
        /// Optimize a source image using a file path and wait for the optimization to complete using the default optimization settings.
        /// </summary>
        /// <param name="filePath">The source image's file path.</param>
        /// <returns>An OptimizeResponse.</returns>
        public Task<OptimizeResponse> OptimizeWaitAsync(
            string filePath) {
            var fileBlob = File.ReadAllBytes(filePath);
            var fileName = Path.GetFileName(filePath);

            return OptimizeWaitAsync(fileBlob, fileName);
        }

        /// <summary>
        /// Optimize a source image using a byte array and wait for the optimization to complete using the default optimization settings.
        /// </summary>
        /// <param name="fileBlob">The source image's byte array.</param>
        /// <param name="fileName">The source image's file name.</param>
        /// <returns>An OptimizeResponse.</returns>
        public Task<OptimizeResponse> OptimizeWaitAsync(
            byte[] fileBlob,
            string fileName) => OptimizeWaitAsync(new OptimizeRequest {
                FileBlob = fileBlob,
                FileName = fileName
            });

        /// <summary>
        /// Optimize a source image using a custom request and wait for the optimization to complete.
        /// </summary>
        /// <param name="request">An OptimizeRequest instance.</param>
        /// <returns>An OptimizeResponse.</returns>
        public async Task<OptimizeResponse> OptimizeWaitAsync(
            OptimizeRequest request) {
            //  Check if the request is null and return an invalid response if it is.

            if (request is null) {
                return InvalidRequestResponse;
            }

            //  Check if a file name was provided.

            if (!request.FileName.HasValue()) {
                return InvalidFileNameResponse;
            }

            if (request.Resize.HasItems()) {
                //  Check if the resize count is more than the max allowed.

                if (request.Resize.Count() > MaxResizeCount) {
                    return InvalidResizeCountResponse;
                }

                //  Validate if the resize dimensions are correct.

                var validResizeDimensions = ValidateResizeDimensions(request.Resize);

                if (!validResizeDimensions) {
                    return InvalidResizeDimensionsResponse;
                }
            }

            //  Make sure to update the request to be synchronous.

            request.Wait = true;

            //  Get the request's response and deserialize it into an OptimizeResponse instance.

            var response = await GetResponseAsync(request);
            var optimizeWaitResponse = JsonConvert.DeserializeObject<OptimizeResponse>(response);

            if (Debug) {
                optimizeWaitResponse.Json = response;
            }

            return optimizeWaitResponse;
        }

        /// <summary>
        /// Get the account's status and usage for the current billing period.
        /// </summary>
        /// <returns>A StatusResponse.</returns>
        public async Task<StatusResponse> StatusAsync() {
            var response = await GetResponseAsync(new StatusRequest());
            var statusResponse = JsonConvert.DeserializeObject<StatusResponse>(response);

            if (Debug) {
                statusResponse.Json = response;
            }

            return statusResponse;
        }

        //  ========================================================================
        //  Response
        //  ========================================================================

        private static ByteArrayContent GetByteContent(
            OptimizeRequest request) => request is null ? null : new ByteArrayContent(request.FileBlob);

        private async Task<string> GetResponseAsync(
            RequestBase request) {
            request.Authorization = Authorization;

            try {
                return await GetPostResponseAsync(request);
            } catch (HttpRequestException e) {
                var message = $"{e.Message}\n{e.InnerException?.Message}".Trim();

                return $"{{\"message\":\"{message}\",\"success\":false}}";
            }
        }

        private async Task<string> GetPostResponseAsync(
            RequestBase request) {
            var optimizeRequest = request as OptimizeRequest;

            var body = JsonConvert.SerializeObject(request, JsonSerializerSettings);

            using var content = new MultipartFormDataContent();
            using var stringContent = new StringContent(body);
            using var byteContent = GetByteContent(optimizeRequest);

            content.Add(stringContent, "json");

            if (optimizeRequest != null
                && byteContent != null) {
                content.Add(byteContent, "file", optimizeRequest.FileName);
            }

            using var message = await HttpClient.PostAsync(request.Endpoint, content);

            var messageContent = await message.Content.ReadAsStringAsync();

            return messageContent;
        }

        //  ========================================================================
        //  Utilities
        //  ========================================================================

        /// <summary>
        /// A failure due to no file name provided.
        /// </summary>
        private static OptimizeResponse InvalidFileNameResponse => ResponseBase.Invalid<OptimizeResponse>("No file name was provided.");

        /// <summary>
        /// A failure due to over max number of allowed resize per optimization.
        /// </summary>
        private static OptimizeResponse InvalidResizeCountResponse => ResponseBase.Invalid<OptimizeResponse>($"You can only have {MaxResizeCount} resizes per optimization.");

        /// <summary>
        /// A failure due to invalid resizing dimensions.
        /// </summary>
        private static OptimizeResponse InvalidResizeDimensionsResponse => ResponseBase.Invalid<OptimizeResponse>("One or more resizes have invalid dimensions.");

        /// <summary>
        /// A failure due to a null request.
        /// </summary>
        private static OptimizeResponse InvalidRequestResponse => ResponseBase.Invalid<OptimizeResponse>("The request is invalid.");

        /// <summary>
        /// Validate if the resize dimensions are correct.
        /// </summary>
        /// <param name="resizes">A collection of resizes.</param>
        /// <returns>A boolean.</returns>
        private static bool ValidateResizeDimensions(
            IEnumerable<Resize> resizes) => resizes.All(
            r =>
                r.Height > 0
                && r.Width > 0);
    }
}