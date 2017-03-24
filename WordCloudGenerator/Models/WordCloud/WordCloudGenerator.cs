using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Interfaces.FileOperations;
using Interfaces.TextOperations;
using Interfaces.TransferObjects;
using Interfaces.WordCloud;
using Models.Enumerations;
using Models.FileOperations;
using Models.Graphical;
using Models.Layout;
using Models.TextOperations;
using Models.TransferObjects;
using Properties;

namespace Models.WordCloud
{
    public class WordCloudGenerator : IWordCloudGenerator
    {
        private BackgroundWorker _worker;

        public Color BackgroundColor { get; set; }

        public Color[] ColorPalette { get; set; } = {
            Color.DarkRed, Color.DarkBlue, Color.DarkGreen, Color.Navy, Color.DarkCyan, Color.DarkOrange,
            Color.DarkGoldenrod, Color.DarkKhaki, Color.Blue, Color.Red, Color.Green
        };

        public FontFamily FontFamily { get; set; } = new FontFamily("Microsoft Sans Serif");

        public FontStyle FontStyle { get; set; } = FontStyle.Regular;

        public Size Size { get; set; } = new Size(1700, 1700);

        public int MinFontSize { get; set; } = 8;

        public int MaxFontSize { get; set; } = 15;

        public StringCompareType CompareType { get; set; } = StringCompareType.IgnoreCase;

        public IFileBlackListLocation FileBlackListLocation { get; set; }

        public LayoutType LayoutType { get; set; } = LayoutType.Spiral;

        public void Generate()
        {
            InitializeBackgroundWorker();
            _worker.RunWorkerAsync();
        }

        private void InitializeBackgroundWorker()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += GenerateCloud;
            _worker.RunWorkerCompleted += GenerateCloudDone;
        }

        private void GenerateCloudDone(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(Resources.WordCloudGeneratedText, Resources.WordCloudGeneratedCaption, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void GenerateCloud(object sender, DoWorkEventArgs e)
        {
            switch (CompareType)
            {
                case StringCompareType.IgnoreCase:
                    GenerateCloudIgnoreCase();
                    break;
                case StringCompareType.CaseSensitive:
                    GenerateCloudCaseSensitive();
                    break;
            }
        }

        private void GenerateCloudIgnoreCase()
        {
            if (CheckFileAndBlackListIsNull(FileBlackListLocation)) return;
            var files = FileBlackListLocation.Files;
            var filesList = files as IList<string> ?? files.ToList();
            var saveImageLocation = FileBlackListLocation.SaveImageLocation;
            var groupedWords = GetGroupedFilesIgnoreCase(filesList).ToList();
            var filteredWords = FileBlackListLocation.Blacklist != null
                ? FilterFromFilterListIgnoreCase(groupedWords, FileBlackListLocation.Blacklist)
                : groupedWords;
            var orderedWords = new Orderer().Order(filteredWords);
            Paint(orderedWords, saveImageLocation);
        }

        private void GenerateCloudCaseSensitive()
        {
            if (CheckFileAndBlackListIsNull(FileBlackListLocation)) return;
            var files = FileBlackListLocation.Files;
            var filesList = files as IList<string> ?? files.ToList();
            var saveImageLocation = FileBlackListLocation.SaveImageLocation;
            var groupedWords = GetGroupedFiles(filesList).ToList();
            var filteredWords = FileBlackListLocation.Blacklist != null
                ? FilterFromFilterList(groupedWords, FileBlackListLocation.Blacklist)
                : groupedWords;
            var orderedWords = new Orderer().Order(filteredWords);
            Paint(orderedWords, saveImageLocation);
        }

        private void Paint(IEnumerable<IWord> wordsToDraw, string saveImageLocation)
        {
            var layout = new LayoutFactory().CreateLayout(Size, LayoutType);
            var toDraw = wordsToDraw as IList<IWord> ?? wordsToDraw.ToList();
            var minMax = CaclulateMinMaxWordWeights(toDraw);
            var bitmap = new Bitmap(Size.Width, Size.Height);
            bitmap.SetResolution(Convert.ToInt32(Size.Width / 6), Convert.ToInt32(Size.Height / 6));
            var graphics = Graphics.FromImage(bitmap);
            graphics.Clear(GetRandomBackgroundColor());
            var graphicEngine = new GdiGraphicEngine(graphics, FontFamily, FontStyle,
                ColorPalette, MinFontSize, MaxFontSize, minMax.Min, minMax.Max);
            layout.Arrange(toDraw, graphicEngine);
            SaveFile(bitmap, saveImageLocation);
        }

        private void SaveFile(Bitmap bitmap, string saveImageLocation)
        {
            var extension = Path.GetExtension(saveImageLocation);
            if (extension != null && extension.Equals(".png"))
                bitmap.Save(saveImageLocation, ImageFormat.Png);
            else if (extension != null && extension.Equals(".bmp"))
                bitmap.Save(saveImageLocation, ImageFormat.Bmp);
            else if (extension != null && extension.Equals(".jpeg") ||
                     extension != null && extension.Equals(".jpg"))
                bitmap.Save(saveImageLocation, ImageFormat.Jpeg);
        }

        private Color GetRandomBackgroundColor()
        {
            if (BackgroundColor != Color.Empty) return BackgroundColor;
            switch (new Random().Next(0, 2))
            {
                case 0:
                    return Color.Black;
                case 1:
                    return Color.White;

                default:
                    return Color.Transparent;
            }
        }

        private IMinMax CaclulateMinMaxWordWeights(IEnumerable<IWord> words)
        {
            var words2 = words.ToList();
            var first = words2[0];
            if (first == null) return null;
            const int maxValuesInControl = 400;
            var lastVisible = words2.Count >= maxValuesInControl
                ? words2[maxValuesInControl]
                : words2[words2.Count - 1];
            return new MinMax
            {
                Min = lastVisible.Occurrences,
                Max = first.Occurrences
            };
        }

        private bool CheckFileAndBlackListIsNull(IFileBlackListLocation fileAndBlacklistLocation)
        {
            return fileAndBlacklistLocation.Files == null ||
                   fileAndBlacklistLocation.SaveImageLocation == null;
        }

        private bool CheckSingleFile(List<string> files)
        {
            return files?.Count == 1;
        }

        private IEnumerable<IWord> GetGroupedFilesIgnoreCase(IEnumerable<string> files)
        {
            IFileReader reader = new FileReader();
            var filesList = files as IList<string> ?? files.ToList();
            return CheckSingleFile(filesList.ToList())
                ? reader.GetWordsFromFileIgnoreCase(filesList.First())
                : reader.GetWordsFromFilesIgnoreCase(filesList);
        }

        private IEnumerable<IWord> FilterFromFilterListIgnoreCase(IEnumerable<IWord> files,
            IEnumerable<string> blacklist)
        {
            ITextFilter filter = new TextFilter();
            return filter.FilterIgnoreCase(files, blacklist);
        }

        private IEnumerable<IWord> GetGroupedFiles(IEnumerable<string> files)
        {
            IFileReader reader = new FileReader();
            var filesList = files as IList<string> ?? files.ToList();
            return CheckSingleFile(filesList.ToList())
                ? reader.GetWordsFromFile(filesList.First())
                : reader.GetWordsFromFiles(filesList);
        }

        private IEnumerable<IWord> FilterFromFilterList(IEnumerable<IWord> files, IEnumerable<string> blacklist)
        {
            ITextFilter filter = new TextFilter();
            return filter.Filter(files, blacklist);
        }
    }
}