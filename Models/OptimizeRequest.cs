using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Arex388.Kraken {
    public sealed class OptimizeRequest :
        RequestBase {
        /// <summary>
        /// Flag indicating if the source image should be auto-oriented. True by default.
        /// </summary>
        [JsonProperty("auto_orient")]
        public bool AutoOrient { get; set; } = true;

        /// <summary>
        /// The callback url that will be notified when the optimization is complete.
        /// </summary>
        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        /// <summary>
        /// The chroma sampling to apply during resize. 4:2:0 by default.
        /// </summary>
        [JsonProperty("sampling_scheme")]
        public string ChromaSampling { get; set; } = Kraken.ChromaSampling.FourTwoZero;

        /// <summary>
        /// The kraked image's target format.
        /// </summary>
        public Convert Convert { get; set; }

        ///// <summary>
        ///// Flag indicating if the request should be sandboxed for testing. False by default.
        ///// </summary>
        //public bool Dev { get; set; }

        /// <summary>
        /// Flag indicating if lossy optimization should be used. True by default.
        /// </summary>
        public bool Lossy { get; set; } = true;

        /// <summary>
        /// A collection indicating which metadata to preserve from the source image.
        /// </summary>
        [JsonProperty("preserve_meta")]
        public IEnumerable<string> MetadataToPreserve { get; set; }

        /// <summary>
        /// The quality (0-100) to apply during resize (optional).
        /// </summary>
        public int? Quality { get; set; }

        /// <summary>
        /// A collection of resize targets to apply during optimization.
        /// </summary>
        public IEnumerable<Resize> Resize { get; set; }

        /// <summary>
        /// The source image's URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Flag indicating if the request is synchronous or asynchronous.
        /// </summary>
        public bool Wait { get; set; }

        /// <summary>
        /// Flag indicating if the kraked image should be in the WebP format. False by default.
        /// </summary>
        public bool WebP { get; set; }

        //  ========================================================================
        //  Request
        //  ========================================================================

        private byte[] _fileBlob;
        private string _fileName;

        internal override string Endpoint => Url.HasValue() ? "https://api.kraken.io/v1/url" : "https://api.kraken.io/v1/upload";

        [JsonIgnore]
        public byte[] FileBlob {
            get => _fileBlob ?? File.ReadAllBytes(FilePath);
            set => _fileBlob = value;
        }

        [JsonIgnore]
        public string FileName {
            get => _fileName ?? Path.GetFileName(FilePath);
            set => _fileName = value;
        }

        [JsonIgnore]
        public string FilePath { get; set; }
    }
}