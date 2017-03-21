using System.Collections.Generic;
using Interfaces.TransferObjects;
using Interfaces.WordCloud;
using Models.TransferObjects;
using Models.WordCloud;

public class ExampleUsage
{
    public void Test()
    {
        IFileBlackListLocation fileAndBlackList = new FileBlackListLocation
        {
            Blacklist = new List<string> {"Test", "Test2"}, // Specify which words should be excluded
            Files = new List<string> {"C:\\Test\\Test.txt"}, // All text file types are allowed here
            SaveImageLocation = "C:\\Test\\Test.png" // Only .png, .bmp, .jpg and .jpeg are allowed here
        };
        IWordCloudGenerator wordCloudGenerator = new WordCloudGenerator();
        wordCloudGenerator.Generate(); // Basic operation without any specification
    }
}