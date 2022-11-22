using System;
using System.IO;

namespace IndividualTask2.Constants
{
    public static class PathInfo
    {
        private static readonly string WorkingDirectory;
        private static readonly string ProjectDirectory;

        public static readonly string ResultDocumentPath;

        public static readonly string DataDocumentPath;

        static PathInfo()
        {
            WorkingDirectory = Environment.CurrentDirectory;
            ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            ResultDocumentPath = Path.Combine(ProjectDirectory, "Documents/Result.docx");
            DataDocumentPath = Path.Combine(ProjectDirectory, "Documents/Data.docx");
        }
    }
}