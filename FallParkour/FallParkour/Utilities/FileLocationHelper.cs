using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.Utilities
{
    class FileLocationHelper
    {
        public static string GetFileName(string fullPathToFile)
        {
            if (fullPathToFile.Contains('\\'))
            {
                return fullPathToFile.Substring(fullPathToFile.LastIndexOf('\\') + 1, fullPathToFile.Length - (fullPathToFile.LastIndexOf('\\') + 1));
            }
            else if (fullPathToFile.Contains('/'))
            {
                return fullPathToFile.Substring(fullPathToFile.LastIndexOf('/') + 1, fullPathToFile.Length - (fullPathToFile.LastIndexOf('/') + 1));
            }
            else
            {
                return fullPathToFile;
            }
        }

        public static string GetPathToFile(string fullPathToFile)
        {
            if (fullPathToFile.Contains('\\'))
            {
                return fullPathToFile.Substring(0, fullPathToFile.LastIndexOf('\\') + 1);
            }
            else if (fullPathToFile.Contains('/'))
            {
                return fullPathToFile.Substring(0, fullPathToFile.LastIndexOf('/') + 1);
            }
            else
            {
                return fullPathToFile;
            }
        }

        public static string RemoveFileExtension(string filename)
        {
            return filename.Remove(filename.LastIndexOf(','));
        }
    }
}
