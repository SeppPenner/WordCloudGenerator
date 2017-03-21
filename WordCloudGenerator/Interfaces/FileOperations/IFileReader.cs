using System.Collections.Generic;
using Interfaces.WordCloud;

namespace Interfaces.FileOperations
{
    public interface IFileReader
    {
        IEnumerable<IWord> GetWordsFromFile(string file);

        IEnumerable<IWord> GetWordsFromFiles(IEnumerable<string> files);

        IEnumerable<IWord> GetWordsFromFileIgnoreCase(string file);

        IEnumerable<IWord> GetWordsFromFilesIgnoreCase(IEnumerable<string> files);
    }
}