namespace Arex388.Kraken {
	public static class Metadata {
		/// <summary>
		/// Will preserve copyright entries. The following tags will be preserved (if present):
		///
		/// - Exif.Image.Copyright
		/// - Iptc.Application2.Copyright
		/// - Xmp.dc.creator
		/// - Xmp.dc.rights
		/// - Xmp.photoshop.Credit
		/// </summary>
		public static readonly string Copyright = "copyright";

		/// <summary>
		/// Will preserve image creation date. The following tags will be preserved (if present):
		///
		/// - Exif.Photo.DateTimeDigitized
		/// - Exif.Photo.DateTimeOriginal
		/// - Xmp.photoshop.DateCreated
		/// </summary>
		public static readonly string Date = "date";

		/// <summary>
		/// Will preserve location-specific information. The following tags will be preserved (if present):
		/// 
		/// - Exif.GPSInfo.GPSLatitude
		/// - Exif.GPSInfo.GPSLatitudeRef
		/// - Exif.GPSInfo.GPSLongitude
		/// - Exif.GPSInfo.GPSLongitudeRef
		/// - Exif.GPSInfo.GPSVersionID
		/// </summary>
		public static readonly string Geotag = "geotag";

		/// <summary>
		/// Will preserve the orientation (rotation) mark. The following tag will be preserved (if present):
		/// 
		/// - Exif.Image.Orientation
		/// </summary>
		public static readonly string Orientation = "orientation";

		/// <summary>
		/// Will preserve the ICC colour profile. ICC colour profile information adds unnecessary bloat to images. However, preserving it can be necessary in extremely rare cases where removing this information could lead to a change in brightness and/or saturation of the resulting file.
		/// </summary>
		public static readonly string Profile = "profile";
	}
}