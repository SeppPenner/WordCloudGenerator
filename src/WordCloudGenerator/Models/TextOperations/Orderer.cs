// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Orderer.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The orderer class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.TextOperations
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using WordCloudGenerator.Interfaces.TextOperations;
    using WordCloudGenerator.Interfaces.WordCloud;

    /// <inheritdoc cref="IOrderer"/>
    /// <summary>
    /// The orderer class.
    /// </summary>
    /// <seealso cref="IOrderer"/>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class Orderer : IOrderer
    {
        /// <inheritdoc cref="IOrderer"/>
        /// <summary>
        /// Orders the words descending.
        /// </summary>
        /// <param name="words">The words.</param>
        /// <returns>A new <seealso cref="IEnumerable{T}"/> of <seealso cref="IWord"/>s.</returns>
        /// <seealso cref="IOrderer"/>
        public IEnumerable<IWord> Order(IEnumerable<IWord> words)
        {
            return words.ToList().OrderByDescending(x => x.Occurrences);
        }
    }
}