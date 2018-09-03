namespace Arex388.Kraken {
	public static class MetadataType {
		//	Will preserve copyright entries. The following tags will be preserved (if present):
		//	- Exif.Image.Copyright
		//	- Iptc.Application2.Copyright
		//	- Xmp.dc.creator
		//	- Xmp.dc.rights
		//	- Xmp.photoshop.Credit
		public const string Copyright = "copyright";

		//	Will preserve image creation date. The following tags will be preserved (if present):
		//	- Exif.Photo.DateTimeDigitized
		//	- Exif.Photo.DateTimeOriginal
		//	- Xmp.photoshop.DateCreated
		public const string Date = "date";

		//	Will preserve location-specific information. The following tags will be preserved (if present):
		//	- Exif.GPSInfo.GPSLatitude
		//	- Exif.GPSInfo.GPSLatitudeRef
		//	- Exif.GPSInfo.GPSLongitude
		//	- Exif.GPSInfo.GPSLongitudeRef
		//	- Exif.GPSInfo.GPSVersionID
		public const string Geotag = "geotag";

		//	Will preserve the orientation (rotation) mark. The following tag will be preserved (if present):
		//	- Exif.Image.Orientation
		public const string Orientation = "orientation";

		//	Will preserve the ICC colour profile. ICC colour profile information adds unnecessary bloat to images.
		//	However, preserving it can be necessary in extremely rare cases where removing this information could
		//	lead to a change in brightness and/or saturation of the resulting file.
		public const string Profile = "profile";
	}
}