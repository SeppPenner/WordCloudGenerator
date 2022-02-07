// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Word.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The word class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.WordCloud
{
    using Interfaces.WordCloud;

    /// <inheritdoc cref="IWord"/>
    /// <summary>
    /// The word class.
    /// </summary>
    /// <seealso cref="IWord"/>
    public class Word : IWord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Word"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="occurrences">The occurrences.</param>
        public Word(string text, int occurrences)
        {
            this.Text = text;
            this.Occurrences = occurrences;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Word"/> class.
        /// </summary>
        public Word()
        {
        }

        /// <inheritdoc cref="IWord"/>
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <seealso cref="IWord"/>
        public string Text { get; set; } = string.Empty;

        /// <inheritdoc cref="IWord"/>
        /// <summary>
        /// Gets or sets the occurrences.
        /// </summary>
        /// <seealso cref="IWord"/>
        public int Occurrences { get; set; }
    }
}