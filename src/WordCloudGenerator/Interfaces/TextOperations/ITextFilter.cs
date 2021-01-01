// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITextFilter.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The text filter interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.TextOperations
{
    using System.Collections.Generic;

    using WordCloudGenerator.Interfaces.WordCloud;

    /// <summary>
    /// The text filter interface.
    /// </summary>
    public interface ITextFilter
    {
        /// <summary>
        /// Filters the word list.
        /// </summary>
        /// <param name="wordList">The word list.</param>
        /// <param name="filterList">The filter list.</param>
        /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
        // ReSharper disable once UnusedMemberInSuper.Global
        IEnumerable<IWord> Filter(IEnumerable<IWord> wordList, IEnumerable<string> filterList);

        /// <summary>
        /// Filters the word list with case ignore.
        /// </summary>
        /// <param name="wordList">The word list.</param>
        /// <param name="filterList">The filter list.</param>
        /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
        // ReSharper disable once UnusedMemberInSuper.Global
        IEnumerable<IWord> FilterIgnoreCase(IEnumerable<IWord> wordList, IEnumerable<string> filterList);
    }
}