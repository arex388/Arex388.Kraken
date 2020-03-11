namespace Arex388.Kraken {
	public static class ChromaSampling {
		/// <summary>
		/// Kraken.io's default for lossy JPEG compression. Suitable for most images - this sampling scheme will yield the smallest possible file size.
		/// </summary>
		public const string FourTwoZero = "4:2:0";

		/// <summary>
		/// The two colour (chroma) components are sampled at half the sample rate of brightness (luma), thereby halving the horizontal chroma resolution.
		/// </summary>
		public const string FourTwoTwo = "4:2:2";

		/// <summary>
		/// Each of the three colour components have the same sample rate as the luma channel, thus there is no chroma subsampling taking place. Use this scheme to disable chroma subsampling for the highest quality result, at the expense of a slightly larger file size.
		/// </summary>
		public const string FourFourFour = "4:4:4";
	}
}