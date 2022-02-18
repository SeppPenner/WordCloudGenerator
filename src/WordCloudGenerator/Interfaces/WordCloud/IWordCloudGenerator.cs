// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWordCloudGenerator.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The word cloud generator interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.WordCloud;

/// <summary>
/// The word cloud generator interface.
/// </summary>
public interface IWordCloudGenerator
{
    /// <summary>
    /// Generates the word cloud.
    /// </summary>
    void Generate();
}
