# WordCloudGenerator
WordCloudGenerator implementation in C#.

[![Build status](https://ci.appveyor.com/api/projects/status/r8r6j98kri947g09?svg=true)](https://ci.appveyor.com/project/SeppPenner/wordcloudgenerator)
[![GitHub issues](https://img.shields.io/github/issues/SeppPenner/WordCloudGenerator.svg)](https://github.com/SeppPenner/WordCloudGenerator/issues)
[![GitHub forks](https://img.shields.io/github/forks/SeppPenner/WordCloudGenerator.svg)](https://github.com/SeppPenner/WordCloudGenerator/network)
[![GitHub stars](https://img.shields.io/github/stars/SeppPenner/WordCloudGenerator.svg)](https://github.com/SeppPenner/WordCloudGenerator/stargazers)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://raw.githubusercontent.com/SeppPenner/WordCloudGenerator/master/License.txt)
[![Known Vulnerabilities](https://snyk.io/test/github/SeppPenner/WordCloudGenerator/badge.svg)](https://snyk.io/test/github/SeppPenner/WordCloudGenerator)
[![Blogger](https://img.shields.io/badge/Follow_me_on-blogger-orange)](https://franzhuber23.blogspot.de/)
[![Patreon](https://img.shields.io/badge/Patreon-F96854?logo=patreon&logoColor=white)](https://patreon.com/SeppPennerOpenSourceDevelopment)
[![PayPal](https://img.shields.io/badge/PayPal-00457C?logo=paypal&logoColor=white)](https://paypal.me/th070795)

## Basic usage
```csharp
IFileBlackListLocation fileAndBlackList = new FileBlackListLocation
{
    Blacklist = new List<string> {"Test", "Test2"}, // Specify which words should be excluded
    Files = new List<string> {"C:\\Test\\Test.txt"}, // All text file types are allowed here
    SaveImageLocation = "C:\\Test\\Test.png" // Only .png, .bmp, .jpg and .jpeg are allowed here
};
IWordCloudGenerator wordCloudGenerator = new WordCloudGenerator();
wordCloudGenerator.Generate(); // Basic operation without any specification
```

## What can you specify for the WordCloudGenerator?
```csharp
Color BackgroundColor // The image's background color can be set.

Color[] ColorPalette { get; set; } // The colors for the fonts can be set. Default values are Color.DarkRed,
								   // Color.DarkBlue, Color.DarkGreen, Color.Navy, Color.DarkCyan, Color.DarkOrange,
								   // Color.DarkGoldenrod, Color.DarkKhaki, Color.Blue, Color.Red, Color.Green

FontFamily FontFamily // The FontFamily can be set. Default is Microsoft Sans Serif.

FontStyle FontStyle // The FontStyle can be set. Default is FontStyle.Regular.

Size Size // The Size can be set. Default is Size(1700, 1700).

int MinFontSize // The MinFontSize can be set. Default is 8.

int MaxFontSize // The MaxFontSize can be set. Default is 15.

StringCompareType CompareType // The CompareType can be set. Default is StringCompareType.IgnoreCase.
							  // IgnoreCase here means that the words "Test" and "test" are handled as different words
							  // CaseSensitive here means that the words "Test" and "test" are handled as the same words

LayoutType LayoutType // The LayoutType can be set. Default is LayoutType.Spiral.

IFileBlackListLocation IFileBlackListLocation --> See basic usage
```

## Structure of the blacklists in the table
a;b;c

![The dialog for changing blacklists](https://github.com/SeppPenner/WordCloudGenerator/blob/master/ExampleImageBlacklist.png "The dialog for changing blacklists")


Stores the values a, b and c in the XML-Blacklist file.

## One image from the generator
![Image from the generator](https://github.com/SeppPenner/WordCloudGenerator/blob/master/ExampleImage.png "Image from the generator")

## Screenshot from the executable
![Screenshot from the executable](https://github.com/SeppPenner/WordCloudGenerator/blob/master/ExampleImageSoftware.png "Screenshot from the executable")

The project is licensed under the "I don't care what you do with this sh*t"-license

Thanks go to George Mamaladze from http://sourcecodecloud.codeplex.com/ for the inspiration and code.

Change history
--------------

See the [Changelog](https://github.com/SeppPenner/WordCloudGenerator/blob/master/Changelog.md).