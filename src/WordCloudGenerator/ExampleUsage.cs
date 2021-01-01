// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExampleUsage.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The example usage class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator
{
    using System.Collections.Generic;

    using Interfaces.TransferObjects;
    using Interfaces.WordCloud;

    using Languages.Implementation;

    using Models.TransferObjects;

    /// <summary>
    /// The example usage class.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public class ExampleUsage
    {
        /// <summary>
        /// A test method.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public void Test()
        {
            // ReSharper disable once UnusedVariable
            IFileBlackListLocation fileAndBlackList = new FileBlackListLocation
            {
                Blacklist = new List<string> { "Test", "Test2" }, // Specify which words should be excluded
                Files = new List<string> { "C:\\Test\\Test.txt" }, // All text file types are allowed here
                SaveImageLocation = "C:\\Test\\Test.png" // Only .png, .bmp, .jpg and .jpeg are allowed here
            };

            IWordCloudGenerator wordCloudGenerator = new Models.WordCloud.WordCloudGenerator(new LanguageManager());
            wordCloudGenerator.Generate(); // Basic operation without any specification
        }
    }
}