// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpperFirst.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   A class to convert the <see cref="string" /> to a <see cref="string" /> with starting upper case.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.TextOperations
{
    using System;
    using System.Linq;

    using WordCloudGenerator.Interfaces.TextOperations;

    /// <inheritdoc cref="IUpperFirst"/>
    /// <summary>
    /// A class to convert the <see cref="string"/> to a <see cref="string"/> with starting upper case.
    /// </summary>
    /// <seealso cref="IUpperFirst"/>
    // ReSharper disable once UnusedMember.Global
    public class UpperFirst : IUpperFirst
    {
        /// <inheritdoc cref="IUpperFirst"/>
        /// <summary>
        /// Converts the <see cref="string"/> to a <see cref="string"/> with starting upper case.
        /// </summary>
        /// <param name="s">The <see cref="string"/>.</param>
        /// <returns>The <see cref="string"/> as upper case.</returns>
        /// <seealso cref="IUpperFirst"/>
        public string UpperCaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentException("String is empty");
            }

            return s.ToLower().First().ToString().ToUpper() + s.ToLower().Substring(1);
        }
    }
}