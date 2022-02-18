// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOrderer.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The orderer interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WordCloudGenerator.Interfaces.TextOperations;

/// <summary>
/// The orderer interface.
/// </summary>
public interface IOrderer
{
    /// <summary>
    /// Orders the words descending.
    /// </summary>
    /// <param name="words">The words.</param>
    /// <returns>A new <seealso cref="IEnumerable{T}"/> of <seealso cref="IWord"/>s.</returns>
    IEnumerable<IWord> Order(IEnumerable<IWord> words);
}
