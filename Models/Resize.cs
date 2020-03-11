using Newtonsoft.Json;

namespace Arex388.Kraken {
    public sealed class Resize {
        /// <summary>
        /// The background color to apply if the source image has transparency.
        /// </summary>
        [JsonProperty("background")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// The chroma sampling to apply during resize. 4:2:0 by default.
        /// </summary>
        [JsonProperty("sampling_scheme")]
        public string ChromaSampling { get; set; } = Kraken.ChromaSampling.FourTwoZero;

        /// <summary>
        /// The resize crop mode.
        /// </summary>
        [JsonProperty("crop_mode")]
        public string Crop { get; set; } = CropMode.Center;

        /// <summary>
        /// Flag indicating if enhancements should be applied during resize. False by default.
        /// </summary>
        public bool Enhance { get; set; }

        /// <summary>
        /// The resize height.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The resize id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Flag indicating if lossy optimization should be used. True by default.
        /// </summary>
        public bool Lossy { get; set; } = true;

        /// <summary>
        /// The quality (0-100) to apply during resize (optional).
        /// </summary>
        public int? Quality { get; set; }

        /// <summary>
        /// The resizing scale (0-100).
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// The resize strategy to apply.
        /// </summary>
        public string Strategy { get; set; } = ResizeStrategy.Auto;

        /// <summary>
        /// The resize width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The resize X offset.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The resize Y offset.
        /// </summary>
        public int Y { get; set; }
    }
}
