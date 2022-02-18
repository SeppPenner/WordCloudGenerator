// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUpperFirst.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   An interface to convert the <see cref="string" /> to a <see cref="string" /> with starting upper case.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.TextOperations;

/// <summary>
/// An interface to convert the <see cref="string"/> to a <see cref="string"/> with starting upper case.
/// </summary>
public interface IUpperFirst
{
    /// <summary>
    /// Converts the <see cref="string"/> to a <see cref="string"/> with starting upper case.
    /// </summary>
    /// <param name="s">The <see cref="string"/>.</param>
    /// <returns>The <see cref="string"/> as upper case.</returns>
    string UpperCaseFirst(string s);
}
