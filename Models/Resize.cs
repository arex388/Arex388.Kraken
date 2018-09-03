using Newtonsoft.Json;

namespace Arex388.Kraken {
	public sealed class Resize {
		[JsonProperty("background")]
		public string BackgroundColor { get; set; }
		[JsonProperty("crop_mode")]
		public string Crop { get; set; }
		public bool Enhance { get; set; }
		public int Height { get; set; }
		public string Id { get; set; }
		public int Scale { get; set; }
		public string Strategy { get; set; }
		public int Width { get; set; }
		public int X { get; set; }
		public int Y { get; set; }

		public Resize() {
			Crop = CropType.Center;
			Strategy = ResizeStrategyType.Auto;
		}
	}
}
