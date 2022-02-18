// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordCloudGenerator.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The word cloud generator class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.WordCloud;

/// <inheritdoc cref="IWordCloudGenerator"/>
/// <summary>
/// The word cloud generator class.
/// </summary>
/// <seealso cref="IWordCloudGenerator"/>
public class WordCloudGenerator : IWordCloudGenerator
{
    /// <summary>
    /// The language manager.
    /// </summary>
    private readonly ILanguageManager languageManager;

    /// <summary>
    /// The worker.
    /// </summary>
    private BackgroundWorker worker = new();

    /// <summary>
    /// Gets or sets the background color.
    /// </summary>
    public Color BackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets the color palette.
    /// </summary>
    public Color[] ColorPalette { get; set; } = { Color.DarkRed, Color.DarkBlue, Color.DarkGreen, Color.Navy, Color.DarkCyan, Color.DarkOrange, Color.DarkGoldenrod, Color.DarkKhaki, Color.Blue, Color.Red, Color.Green };

    /// <summary>
    /// Gets or sets the font family.
    /// </summary>
    public FontFamily FontFamily { get; set; } = new FontFamily("Microsoft Sans Serif");

    /// <summary>
    /// Gets or sets the font style.
    /// </summary>
    public FontStyle FontStyle { get; set; } = FontStyle.Regular;

    /// <summary>
    /// Gets or sets the size.
    /// </summary>
    public Size Size { get; set; } = new Size(1700, 1700);

    /// <summary>
    /// Gets or sets the minimum font size.
    /// </summary>
    public int MinimumFontSize { get; set; } = 8;

    /// <summary>
    /// Gets or sets the maximum font size.
    /// </summary>
    public int MaxFontSize { get; set; } = 15;

    /// <summary>
    /// Gets or sets the compare type.
    /// </summary>
    public StringCompareType CompareType { get; set; } = StringCompareType.IgnoreCase;

    /// <summary>
    /// Gets or sets the file blacklist location.
    /// </summary>
    public IFileBlackListLocation FileBlackListLocation { get; set; } = new FileBlackListLocation();

    /// <summary>
    /// Gets or sets the layout type.
    /// </summary>
    public LayoutType LayoutType { get; set; } = LayoutType.Spiral;

    /// <summary>
    /// Initializes a new instance of the <see cref="WordCloudGenerator"/> class.
    /// </summary>
    /// <param name="languageManager">The language manager.</param>
    public WordCloudGenerator(ILanguageManager languageManager)
    {
        this.languageManager = languageManager;
    }

    /// <inheritdoc cref="IWordCloudGenerator"/>
    /// <summary>
    /// Generates the word cloud.
    /// </summary>
    /// <seealso cref="IWordCloudGenerator"/>
    public void Generate()
    {
        this.InitializeBackgroundWorker();
        this.worker.RunWorkerAsync();
    }

    /// <summary>
    /// Filters from the filter list.
    /// </summary>
    /// <param name="files">The files.</param>
    /// <param name="blacklist">The blacklist.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="Interfaces.WordCloud.IWord"/>s.</returns>
    private static IEnumerable<global::WordCloudGenerator.Interfaces.WordCloud.IWord> FilterFromFilterList(IEnumerable<global::WordCloudGenerator.Interfaces.WordCloud.IWord> files, IEnumerable<string> blacklist)
    {
        var filter = new TextFilter();
        return filter.Filter(files, blacklist);
    }

    /// <summary>
    /// Filters from the filter list with case ignore.
    /// </summary>
    /// <param name="files">The files.</param>
    /// <param name="blacklist">The blacklist.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="Interfaces.WordCloud.IWord"/>s.</returns>
    private static IEnumerable<global::WordCloudGenerator.Interfaces.WordCloud.IWord> FilterFromFilterListIgnoreCase(IEnumerable<global::WordCloudGenerator.Interfaces.WordCloud.IWord> files, IEnumerable<string> blacklist)
    {
        var filter = new TextFilter();
        return filter.FilterIgnoreCase(files, blacklist);
    }

    /// <summary>
    /// Checks whether a single file is selected or not.
    /// </summary>
    /// <param name="files">The files.</param>
    /// <returns><c>true</c> if there is a single file selected, <c>false</c> else.</returns>
    private static bool CheckSingleFile(ICollection files)
    {
        return files?.Count == 1;
    }

    /// <summary>
    /// Saves the file.
    /// </summary>
    /// <param name="bitmap">The bitmap.</param>
    /// <param name="saveImageLocation">The save image location.</param>
    private static void SaveFile(Image bitmap, string saveImageLocation)
    {
        var extension = Path.GetExtension(saveImageLocation);

        if (extension != null && extension.Equals(".png"))
        {
            bitmap.Save(saveImageLocation, ImageFormat.Png);
        }
        else if (extension != null && extension.Equals(".bmp"))
        {
            bitmap.Save(saveImageLocation, ImageFormat.Bmp);
        }
        else if ((extension != null && extension.Equals(".jpeg")) || (extension != null && extension.Equals(".jpg")))
        {
            bitmap.Save(saveImageLocation, ImageFormat.Jpeg);
        }
    }

    /// <summary>
    /// Calculates the minimum and maximum weights.
    /// </summary>
    /// <param name="words">The words.</param>
    /// <returns>A new <see cref="IMinMax"/>.</returns>
    private static IMinMax? CalculateMinMaxWordWeights(IEnumerable<global::WordCloudGenerator.Interfaces.WordCloud.IWord> words)
    {
        var words2 = words.ToList();
        var first = words2[0];

        if (first is null)
        {
            return null;
        }

        const int MaxValuesInControl = 400;

        var lastVisible = words2.Count >= MaxValuesInControl
                              ? words2[MaxValuesInControl]
                              : words2[^1];
        return new MinMax
        {
            Min = lastVisible.Occurrences,
            Max = first.Occurrences
        };
    }

    /// <summary>
    /// Checks whether the file and blacklist location is null or not.
    /// </summary>
    /// <param name="fileAndBlacklistLocation">The file and blacklist location.</param>
    /// <returns><c>true</c> if the file and blacklist location is null, <c>false</c> else.</returns>
    private static bool CheckFileAndBlackListIsNull(IFileBlackListLocation fileAndBlacklistLocation)
    {
        return fileAndBlacklistLocation.Files == null ||
               fileAndBlacklistLocation.SaveImageLocation == null;
    }

    /// <summary>
    /// Gets the grouped files with case ignore.
    /// </summary>
    /// <param name="files">The files.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="IWord"/>s.</returns>
    private static IEnumerable<global::WordCloudGenerator.Interfaces.WordCloud.IWord> GetGroupedFilesIgnoreCase(IEnumerable<string> files)
    {
        IFileReader reader = new FileReader();
        var filesList = files as IList<string> ?? files.ToList();
        return CheckSingleFile(filesList.ToList())
                   ? reader.GetWordsFromFileIgnoreCase(filesList.First())
                   : reader.GetWordsFromFilesIgnoreCase(filesList);
    }

    /// <summary>
    /// Gets the grouped files.
    /// </summary>
    /// <param name="files">The files.</param>
    /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="Interfaces.WordCloud.IWord"/>s.</returns>
    private static IEnumerable<global::WordCloudGenerator.Interfaces.WordCloud.IWord> GetGroupedFiles(IEnumerable<string> files)
    {
        IFileReader reader = new FileReader();
        var filesList = files as IList<string> ?? files.ToList();
        return CheckSingleFile(filesList.ToList())
                   ? reader.GetWordsFromFile(filesList.First())
                   : reader.GetWordsFromFiles(filesList);
    }

    /// <summary>
    /// Initializes the background worker.
    /// </summary>
    private void InitializeBackgroundWorker()
    {
        this.worker = new BackgroundWorker();
        this.worker.DoWork += this.GenerateCloud;
        this.worker.RunWorkerCompleted += this.GenerateCloudDone;
    }

    /// <summary>
    /// Handles the cloud generation done event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void GenerateCloudDone(object sender, RunWorkerCompletedEventArgs e)
    {
        MessageBox.Show(this.languageManager.GetWord("WordCloudGeneratedText"), this.languageManager.GetWord("WordCloudGeneratedCaption"), MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// Generates the cloud.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void GenerateCloud(object sender, DoWorkEventArgs e)
    {
        switch (this.CompareType)
        {
            case StringCompareType.IgnoreCase:
                this.GenerateCloudIgnoreCase();
                break;
            case StringCompareType.CaseSensitive:
                this.GenerateCloudCaseSensitive();
                break;
        }
    }

    /// <summary>
    /// Generates the cloud with case ignore.
    /// </summary>
    private void GenerateCloudIgnoreCase()
    {
        if (CheckFileAndBlackListIsNull(this.FileBlackListLocation))
        {
            return;
        }

        var files = this.FileBlackListLocation.Files;
        var filesList = files as IList<string> ?? files.ToList();
        var saveImageLocation = this.FileBlackListLocation.SaveImageLocation;
        var groupedWords = GetGroupedFilesIgnoreCase(filesList).ToList();
        var filteredWords = this.FileBlackListLocation.Blacklist != null
                                ? FilterFromFilterListIgnoreCase(groupedWords, this.FileBlackListLocation.Blacklist)
                                : groupedWords;
        var orderedWords = new Orderer().Order(filteredWords);
        this.Paint(orderedWords, saveImageLocation);
    }

    /// <summary>
    /// Generates the cloud case sensitive.
    /// </summary>
    private void GenerateCloudCaseSensitive()
    {
        if (CheckFileAndBlackListIsNull(this.FileBlackListLocation))
        {
            return;
        }

        var files = this.FileBlackListLocation.Files;
        var filesList = files as IList<string> ?? files.ToList();
        var saveImageLocation = this.FileBlackListLocation.SaveImageLocation;
        var groupedWords = GetGroupedFiles(filesList).ToList();
        var filteredWords = this.FileBlackListLocation.Blacklist != null
                                ? FilterFromFilterList(groupedWords, this.FileBlackListLocation.Blacklist)
                                : groupedWords;
        var orderedWords = new Orderer().Order(filteredWords);
        this.Paint(orderedWords, saveImageLocation);
    }

    /// <summary>
    /// Paints the words.
    /// </summary>
    /// <param name="wordsToDraw">The words to draw.</param>
    /// <param name="saveImageLocation">The save image location.</param>
    private void Paint(IEnumerable<global::WordCloudGenerator.Interfaces.WordCloud.IWord> wordsToDraw, string saveImageLocation)
    {
        var layout = new LayoutFactory().CreateLayout(this.Size, this.LayoutType);
        var toDraw = wordsToDraw as IList<global::WordCloudGenerator.Interfaces.WordCloud.IWord> ?? wordsToDraw.ToList();
        var minMax = CalculateMinMaxWordWeights(toDraw);
        var bitmap = new Bitmap(this.Size.Width, this.Size.Height);
        bitmap.SetResolution(Convert.ToInt32(this.Size.Width / 6), Convert.ToInt32(this.Size.Height / 6));
        var graphics = Graphics.FromImage(bitmap);
        graphics.Clear(this.GetRandomBackgroundColor());
        var graphicEngine = new GdiGraphicEngine(
            graphics,
            this.FontFamily,
            this.FontStyle,
            this.ColorPalette,
            this.MinimumFontSize,
            this.MaxFontSize,
            minMax?.Min ?? 0,
            minMax?.Max ?? 0);
        layout.Arrange(toDraw, graphicEngine);
        SaveFile(bitmap, saveImageLocation);
    }

    /// <summary>
    /// Gets a random background color.
    /// </summary>
    /// <returns>A new <see cref="Color"/>.</returns>
    private Color GetRandomBackgroundColor()
    {
        if (this.BackgroundColor != Color.Empty)
        {
            return this.BackgroundColor;
        }

        return new Random().Next(0, 2) switch
        {
            0 => Color.Black,
            1 => Color.White,
            _ => Color.Transparent
        };
    }
}
