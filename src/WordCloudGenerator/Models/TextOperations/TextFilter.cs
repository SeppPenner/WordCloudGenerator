// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextFilter.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The text filter class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.TextOperations
{
    using System.Collections.Generic;
    using System.Linq;

    using WordCloudGenerator.Interfaces.TextOperations;
    using WordCloudGenerator.Interfaces.WordCloud;
    using WordCloudGenerator.Models.WordCloud;

    /// <inheritdoc cref="ITextFilter"/>
    /// <summary>
    /// The text filter class.
    /// </summary>
    /// <seealso cref="ITextFilter"/>
    public class TextFilter : ITextFilter
    {
        /// <inheritdoc cref="ITextFilter"/>
        /// <summary>
        /// Filters the word list with case ignore.
        /// </summary>
        /// <param name="wordList">The word list.</param>
        /// <param name="filterList">The filter list.</param>
        /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
        /// <seealso cref="ITextFilter"/>
        public IEnumerable<IWord> FilterIgnoreCase(IEnumerable<IWord> wordList, IEnumerable<string> filterList)
        {
            var filterList2 = filterList.ToList().ConvertAll(d => d.ToUpper());

            var wordList2 = AllToUpper(wordList).ToList();

            for (var i = 0; i < wordList2.ToList().Count; i++)
            {
                if (filterList2.Contains(wordList2.ElementAt(i).Text))
                {
                    wordList2.RemoveAt(i);
                }
            }

            return wordList2;
        }

        /// <inheritdoc cref="ITextFilter"/>
        /// <summary>
        /// Filters the word list.
        /// </summary>
        /// <param name="wordList">The word list.</param>
        /// <param name="filterList">The filter list.</param>
        /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
        /// <seealso cref="ITextFilter"/>
        public IEnumerable<IWord> Filter(IEnumerable<IWord> wordList, IEnumerable<string> filterList)
        {
            var filterList2 = filterList.ToList();
            var wordList2 = wordList.ToList();

            for (var i = 0; i < wordList2.ToList().Count; i++)
            {
                if (filterList2.Contains(wordList2.ElementAt(i).Text))
                {
                    wordList2.RemoveAt(i);
                }
            }

            return wordList2;
        }

        /// <summary>
        /// Converts all <seealso cref="IWord"/>s to upper case.
        /// </summary>
        /// <param name="wordList">The word list.</param>
        /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
        private static IEnumerable<IWord> AllToUpper(IEnumerable<IWord> wordList)
        {
            var wordList2 = wordList.ToList();

            for (var i = 0; i < wordList2.Count; i++)
            {
                wordList2[i] = new Word(wordList2[i].Text.ToUpper(), wordList2[i].Occurrences);
            }

            return wordList2;
        }
    }
}