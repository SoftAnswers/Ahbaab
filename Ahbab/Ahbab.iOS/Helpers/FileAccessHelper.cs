using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Asawer.iOS.Helpers
{
    public class FileAccessHelper
    {

        public static string GetLocalFilePath(string filename)
        {
            var doumentcFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var libraryFolder = System.IO.Path.Combine(doumentcFolder, "..", "Library");

            if (!System.IO.Directory.Exists(libraryFolder))
            {
                System.IO.Directory.CreateDirectory(libraryFolder);
            }

            return System.IO.Path.Combine(libraryFolder, filename);
        }
    }
}