using System.Collections.Generic;
using Interfaces.FileOperations;

namespace Models.FileOperations
{
    public class FileListFactory : IFileListFactory
    {
        public IEnumerable<string> GetFileList(IEnumerable<string> files)
        {
            var fileList = new List<string>();
            fileList.AddRange(files);
            return fileList;
        }
    }
}