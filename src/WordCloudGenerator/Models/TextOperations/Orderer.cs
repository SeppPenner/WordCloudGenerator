// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Orderer.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The orderer class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.TextOperations;

/// <inheritdoc cref="IOrderer"/>
/// <summary>
/// The orderer class.
/// </summary>
/// <seealso cref="IOrderer"/>
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
