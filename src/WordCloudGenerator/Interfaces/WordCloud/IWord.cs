// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWord.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The word interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.WordCloud
{
    /// <summary>
    /// The word interface.
    /// </summary>
    public interface IWord
    {
        /// <summary>
        /// Gets the text.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Gets the occurrences.
        /// </summary>
        int Occurrences { get; }
    }
}