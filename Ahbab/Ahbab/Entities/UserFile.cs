using System;
namespace Asawer
{
	public class UserFile
	{
		public UserFile(byte[] fileBytes, string fileName, string fileExtension)
		{
			this.FileBytes = fileBytes;
			this.FileName = fileName;
			this.FileExtension = fileExtension;
		}

		public byte[] FileBytes
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
