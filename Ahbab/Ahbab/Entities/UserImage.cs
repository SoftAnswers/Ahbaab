using System;
namespace Ahbab
{
	public class UserImage
	{
		public UserImage(byte[] imageBytes, string fileName, string fileExtension)
		{
			this.ImageBytes = imageBytes;
			this.FileName = fileName;
			this.FileExtension = fileExtension;
		}

		public byte[] ImageBytes
		{
			get;
			set;
		}

		public string FileName
		{
			get;
			set;
		}

		public string FileExtension
		{
			get;
			set;
		}
	}
}
