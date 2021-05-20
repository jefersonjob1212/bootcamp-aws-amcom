using System;
using System.Linq;

namespace Bootcamp.Servless.Services.Utils
{
    static class FileExtensionsUtils
    {
        private static string[] EXTENSIONS_FILES =
        { 
            ".jpeg", ".jpg", ".png", ".doc", ".docx",
            ".xls",".xlsx",".ppt",".pptx",".pps",
            ".ppsx",".pdf",".odt",".odp",".ods",".txt",
            ".java",".json",".js",".py",".ts",".cs",".css",
            ".html",".cpp",".scss",".sass",".less"
        };

        public static bool IsFile(this string key)
        {
            var count = 0;
            Array.ForEach(EXTENSIONS_FILES, ext =>
            {
                if (key.EndsWith(ext)) count++;
            });
            return count > 0;
        }
    }
}