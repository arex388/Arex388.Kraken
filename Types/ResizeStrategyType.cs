namespace Arex388.Kraken {
	public static class ResizeStrategyType {
		//	The best strategy (portrait or landscape) will be selected according to its aspect ratio.
		public const string Auto = "auto";

		//	This option will crop an image to the exact size you specify. The resulting cropped image can
		//	optionally be scaled by inclusion of a scale, which accepts a number representing the percentage
		//	by which the image should be scaled
		public const string Crop = "crop";

		//	Resize to exact width and height. Aspect ratio will not be maintained.
		public const string Exact = "exact";

		//	This strategy allows you to resize the image to fit the specified bounds while preserving
		//	the aspect ratio. The optional background property allows you to specify a color which will be
		//	used to fill the unused portions of the previously specified bounds.
		public const string Fill = "fill";

		//	This option will crop and resize your images to fit the desired width and height.
		public const string Fit = "fit";

		//	Exact width will be set, height will be adjusted according to aspect ratio.
		public const string Landscape = "landscape";

		//	Exact height will be set, width will be adjusted according to aspect ratio.
		public const string Portrait = "protrait";

		//	This strategy will crop the image by its shorter dimension to make it a square, then resize it
		//	to the specified size
		public const string Square = "square";
	}
}