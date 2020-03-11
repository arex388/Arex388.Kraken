using Newtonsoft.Json;

namespace Arex388.Kraken {
    public sealed class Convert {
        /// <summary>
        /// Background image when converting from transparent file formats like PNG or GIF into fully opaque format like JPEG. The background property can be passed in HEX notation "#f60" or "#ff6600", RGB "rgb(255, 0, 0)" or RGBA "rgba(91, 126, 156, 0.7)". The default background color is white.
        /// </summary>
        [JsonProperty("background")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// The image format you wish to convert your image into. This can accept one of the following values:
        ///
        /// - jpeg
        /// - png
        /// - gif
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// A boolean value (true or false) instructing Kraken API whether or not the original extension should be kept in the output filename. For example when converting "image.jpg" into PNG format with this flag turned on the output image name will still be "image.jpg" even though the image has been converted into a PNG. The default value is false meaning the correct extension will always be set.
        /// </summary>
        [JsonProperty("keep_extension")]
        public bool PreserveExtension { get; set; }
    }
}