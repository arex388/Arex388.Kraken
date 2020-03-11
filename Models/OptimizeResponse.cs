using Newtonsoft.Json;
using System.Collections.Generic;

namespace Arex388.Kraken {
    public sealed class OptimizeResponse :
        ResponseBase {
        /// <summary>
        /// The kraked image's id.
        /// </summary>
        [JsonProperty("id")]
        public string KrakedId { get; set; }

        /// <summary>
        /// The kraked image's bytes saved vs the source image.
        /// </summary>
        [JsonProperty("saved_bytes")]
        public int KrakedSavings { get; set; }

        /// <summary>
        /// The kraked image's file size.
        /// </summary>
        [JsonProperty("kraked_size")]
        public int KrakedSize { get; set; }

        /// <summary>
        /// The kraked image's url.
        /// </summary>
        [JsonProperty("kraked_url")]
        public string KrakedUrl { get; set; }

        /// <summary>
        /// A collection of resized kraked images.
        /// </summary>
        [JsonProperty("results")]
        public IDictionary<string, OptimizeResponse> Resizes { get; set; }

        /// <summary>
        /// The source image's file name.
        /// </summary>
        [JsonProperty("file_name")]
        public string SourceFileName { get; set; }

        /// <summary>
        /// The source image's height.
        /// </summary>
        [JsonProperty("original_height")]
        public int SourceHeight { get; set; }

        /// <summary>
        /// The source image's file size.
        /// </summary>
        [JsonProperty("original_size")]
        public int SourceSize { get; set; }

        /// <summary>
        /// The source image's width.
        /// </summary>
        [JsonProperty("original_width")]
        public int SourceWidth { get; set; }
    }
}