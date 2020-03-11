namespace Arex388.Kraken {
    public static class ResizeStrategy {
        /// <summary>
        /// The best strategy (portrait or landscape) will be selected according to its aspect ratio.
        /// </summary>
        public const string Auto = "auto";

        /// <summary>
        /// This option will crop an image to the exact size you specify. The resulting cropped image can optionally be scaled by inclusion of a scale, which accepts a number representing the percentage by which the image should be scaled.
        /// </summary>
        public const string Crop = "crop";

        /// <summary>
        /// Resize to exact width and height. Aspect ratio will not be maintained.
        /// </summary>
        public const string Exact = "exact";

        /// <summary>
        /// This strategy allows you to resize the image to fit the specified bounds while preserving the aspect ratio. The optional background property allows you to specify a color which will be used to fill the unused portions of the previously specified bounds.
        /// </summary>
        public const string Fill = "fill";

        /// <summary>
        /// This option will crop and resize your images to fit the desired width and height.
        /// </summary>
        public const string Fit = "fit";

        /// <summary>
        /// Exact width will be set, height will be adjusted according to aspect ratio.
        /// </summary>
        public const string Landscape = "landscape";

        /// <summary>
        /// Exact height will be set, width will be adjusted according to aspect ratio.
        /// </summary>
        public const string Portrait = "protrait";

        /// <summary>
        /// This strategy will crop the image by its shorter dimension to make it a square, then resize it to the specified size.
        /// </summary>
        public const string Square = "square";
    }
}