using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Interfaces.FileOperations;
using Interfaces.WordCloud;
using Models.WordCloud;

namespace Models.FileOperations
{
    public class FileReader : IFileReader
    {
        public IEnumerable<IWord> GetWordsFromFile(string file)
        {
            return File.ReadAllText(file)
                .Replace(Environment.NewLine, " ")
                .Split(' ', ',', '.', '!', ':')
                .ToList()
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .GroupBy(c => c)
                .Select(g => new Word {Text = g.Key, Occurrences = g.Count()});
        }

        public IEnumerable<IWord> GetWordsFromFiles(IEnumerable<string> files)
        {
            var completeWordList = new List<string>();
            foreach (var file in files)
                completeWordList.AddRange(File.ReadAllText(file)
                    .Replace(Environment.NewLine, " ")
                    .Split(' ', ',', '.', '!', ':')
                    .ToList());
            return completeWordList.Where(s => !string.IsNullOrWhiteSpace(s))
                .GroupBy(c => c)
                .Select(g => new Word {Text = g.Key, Occurrences = g.Count()});
        }

        public IEnumerable<IWord> GetWordsFromFileIgnoreCase(string file)
        {
            return File.ReadAllText(file)
                .ToUpper()
                .Replace(Environment.NewLine, " ")
                .Split(' ', ',', '.', '!', ':')
                .ToList()
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .GroupBy(c => c)
                .Select(g => new Word {Text = g.Key, Occurrences = g.Count()});
        }

        public IEnumerable<IWord> GetWordsFromFilesIgnoreCase(IEnumerable<string> files)
        {
            var completeWordList = new List<string>();
            foreach (var file in files)
                completeWordList.AddRange(File.ReadAllText(file)
                    .ToUpper()
                    .Replace(Environment.NewLine, " ")
                    .Split(' ', ',', '.', '!', ':')
                    .ToList());
            return completeWordList.Where(s => !string.IsNullOrWhiteSpace(s))
                .GroupBy(c => c)
                .Select(g => new Word {Text = g.Key, Occurrences = g.Count()});
        }
    }
}