namespace Arex388.Kraken {
	public static class ChromaSamplingType {
		//	Kraken.io's default for lossy JPEG compression. Suitable for most images - this sampling
		//	scheme will yield the smallest possible file size.
		public const string FourTwoZero = "4:2:0";

		//	The two colour (chroma) components are sampled at half the sample rate of brightness (luma),
		//	thereby halving the horizontal chroma resolution.
		public const string FourTwoTwo = "4:2:2";

		//	Each of the three colour components have the same sample rate as the luma channel, thus
		//	there is no chroma subsampling taking place. Use this scheme to disable chroma subsampling
		//	for the highest quality result, at the expense of a slightly larger file size.
		public const string FourFourFour = "4:4:4";
	}
}