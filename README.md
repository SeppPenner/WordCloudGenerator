# WordCloudGenerator
WordCloudGenerator implementation in C#.
The executable was written and tested in .Net 4.7.

[![Build status](https://ci.appveyor.com/api/projects/status/r8r6j98kri947g09?svg=true)](https://ci.appveyor.com/project/SeppPenner/wordcloudgenerator)

## Basic usage:
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

## Structure of the blacklists in the table:
a;b;c

![The dialog for changing blacklists](https://github.com/SeppPenner/WordCloudGenerator/blob/master/ExampleImageBlacklist.png "The dialog for changing blacklists")


Stores the values a, b and c in the XML-Blacklist file.

## One image from the generator:
![Image from the generator](https://github.com/SeppPenner/WordCloudGenerator/blob/master/ExampleImage.png "Image from the generator")

## Screenshot from the executable:
![Screenshot from the executable](https://github.com/SeppPenner/WordCloudGenerator/blob/master/ExampleImageSoftware.png "Screenshot from the executable")

The project is licensed under the "I don't care what you do with this sh*t"-license

Thanks go to George Mamaladze from http://sourcecodecloud.codeplex.com/ for the inspiration and code.

Change history
--------------

* **Version 1.0.0.4 (2017-03-24)** : Updated Languages.dll to version 1.0.0.4.
* **Version 1.0.0.3 (2017-03-21)** : Updated Languages.dll.
* **Version 1.0.0.2 (2017-02-24)** : Adjusted code and added languages.dll.
* **Version 1.0.0.1 (2016-11-21)** : Added try-catchs to user inputs.
* **Version 1.0.0.0 (2016-11-20)** : 1.0 release.
