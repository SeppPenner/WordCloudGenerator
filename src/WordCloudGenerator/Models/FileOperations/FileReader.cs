// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileReader.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The file reader class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.FileOperations;

/// <inheritdoc cref="IFileReader"/>
/// <summary>
/// The file reader class.
/// </summary>
/// <seealso cref="IFileReader"/>
public class FileReader : IFileReader
{
    /// <inheritdoc cref="IFileReader"/>
    /// <summary>
    /// Gets the words from a file.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
    /// <seealso cref="IFileReader"/>
    public IEnumerable<IWord> GetWordsFromFile(string file)
    {
        return File.ReadAllText(file).Replace(Environment.NewLine, " ").Split(' ', ',', '.', '!', ':').ToList()
            .Where(s => !string.IsNullOrWhiteSpace(s)).GroupBy(c => c)
            .Select(g => new Word { Text = g.Key, Occurrences = g.Count() });
    }

    /// <inheritdoc cref="IFileReader"/>
    /// <summary>
    /// Gets the words from a file.
    /// </summary>
    /// <param name="files">The files.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
    /// <seealso cref="IFileReader"/>
    public IEnumerable<IWord> GetWordsFromFiles(IEnumerable<string> files)
    {
        var completeWordList = new List<string>();

        foreach (var file in files)
        {
            completeWordList.AddRange(
                File.ReadAllText(file).Replace(Environment.NewLine, " ").Split(' ', ',', '.', '!', ':').ToList());
        }

        return completeWordList.Where(s => !string.IsNullOrWhiteSpace(s)).GroupBy(c => c)
            .Select(g => new Word { Text = g.Key, Occurrences = g.Count() });
    }

    /// <inheritdoc cref="IFileReader"/>
    /// <summary>
    /// Gets the words from a file with case ignore.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
    /// <seealso cref="IFileReader"/>
    public IEnumerable<IWord> GetWordsFromFileIgnoreCase(string file)
    {
        return File.ReadAllText(file).ToUpper().Replace(Environment.NewLine, " ").Split(' ', ',', '.', '!', ':')
            .ToList().Where(s => !string.IsNullOrWhiteSpace(s)).GroupBy(c => c)
            .Select(g => new Word { Text = g.Key, Occurrences = g.Count() });
    }

    /// <inheritdoc cref="IFileReader"/>
    /// <summary>
    /// Gets the words from a file with case ignore.
    /// </summary>
    /// <param name="files">The files.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
    /// <seealso cref="IFileReader"/>
    public IEnumerable<IWord> GetWordsFromFilesIgnoreCase(IEnumerable<string> files)
    {
        var completeWordList = new List<string>();
        foreach (var file in files)
        {
            completeWordList.AddRange(
                File.ReadAllText(file).ToUpper().Replace(Environment.NewLine, " ").Split(' ', ',', '.', '!', ':')
                    .ToList());
        }

        return completeWordList.Where(s => !string.IsNullOrWhiteSpace(s)).GroupBy(c => c)
            .Select(g => new Word { Text = g.Key, Occurrences = g.Count() });
    }
}
