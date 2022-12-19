using System;
using System.IO;

namespace Common.Constants
{
    public static class PathInfo
    {
        private static readonly string WorkingDirectory;
        public static readonly string ProjectDirectory;
        public static readonly string SolutionDirectory;

        public static readonly string ResultDocumentPath;

        public static readonly string DataDocumentPath;

        static PathInfo()
        {
            WorkingDirectory = Environment.CurrentDirectory;
            ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            SolutionDirectory = Directory.GetParent(ProjectDirectory).FullName;
            ResultDocumentPath = Path.Combine(ProjectDirectory, "Documents/Result.docx");
            DataDocumentPath = Path.Combine(ProjectDirectory, "Documents/Data.docx");
        }
    }
}