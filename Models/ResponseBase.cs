using Newtonsoft.Json;

namespace Arex388.Kraken {
    public class ResponseBase {
        /// <summary>
        /// The error message if the response failed.
        /// </summary>
        [JsonProperty("message")]
        public string Error { get; set; }

        /// <summary>
        /// The raw JSON of the response for debugging.
        /// </summary>
        [JsonIgnore]
        public string Json { get; set; }

        /// <summary>
        /// Was the request successful or not.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// An invalid response instance with an optional error message.
        /// </summary>
        /// <typeparam name="T">The response type.</typeparam>
        /// <param name="error">The error message (optional).</param>
        /// <returns>T</returns>
        internal static T Invalid<T>(
            string error = null)
            where T : ResponseBase, new() => new T {
                Error = error ?? "The request is invalid."
            };
    }
}