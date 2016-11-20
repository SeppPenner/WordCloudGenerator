using System.Collections.Generic;

namespace Interfaces.FileOperations
{
    public interface IFileListFactory
    {
        IEnumerable<string> GetFileList(IEnumerable<string> files);
    }
}