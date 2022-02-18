// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Main.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The main form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator;

/// <summary>
/// The main form.
/// </summary>
public partial class Main : Form
{
    /// <summary>
    /// The file and blacklist location.
    /// </summary>
    private readonly IFileBlackListLocation fileAndBlackList = new FileBlackListLocation();

    /// <summary>
    /// The language manager,
    /// </summary>
    private readonly ILanguageManager languageManager = new LanguageManager();

    /// <summary>
    /// The blacklist model.
    /// </summary>
    private BlacklistModel blacklistModel = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Main"/> class.
    /// </summary>
    public Main()
    {
        this.Initialize();
    }

    /// <summary>
    /// Gets the file list.
    /// </summary>
    /// <param name="fileNames">The file names.</param>
    /// <returns>a new <see cref="IEnumerable{T}"/> of <see cref="string"/>s.</returns>
    private static IEnumerable<string> GetFileList(IEnumerable<string> fileNames)
    {
        var fileFactory = new FileListFactory();
        return fileFactory.GetFileList(fileNames);
    }

    /// <summary>
    /// Initializes the data.
    /// </summary>
    private void Initialize()
    {
        this.InitializeComponent();
        this.InitializeCaption();
        this.LoadBlacklists();
        this.InitializeLanguageManager();
        this.LoadLanguagesToCombo();
    }

    /// <summary>
    /// Initializes the caption.
    /// </summary>
    private void InitializeCaption()
    {
        this.Text = $"{Application.ProductName} {Application.ProductVersion}";
    }

    /// <summary>
    /// Loads the blacklists.
    /// </summary>
    private void LoadBlacklists()
    {
        try
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Blacklist.xml")))
            {
                return;
            }

            var importExport = new ImportExport();
            this.blacklistModel = importExport.LoadConfigFromXmlFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Blacklist.xml")) ?? new();
            this.LoadDataToCombobox(this.blacklistModel);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Loads the data to the combo box.
    /// </summary>
    /// <param name="blacklistModelParam">The blacklist model.</param>
    private void LoadDataToCombobox(BlacklistModel blacklistModelParam)
    {
        this.comboBoxBlacklist.Items.Clear();

        foreach (var blacklist in blacklistModelParam.Blacklists)
        {
            this.comboBoxBlacklist.Items.Add(blacklist.Name);
        }
    }

    /// <summary>
    /// Handles the button click to choose the file.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void ButtonChooseFileClick(object sender, EventArgs e)
    {
        try
        {
            var dialog = new OpenFileDialog { Multiselect = true, Filter = this.languageManager.GetWord("FilterAllFiles") };
            var result = dialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            this.fileAndBlackList.Files = GetFileList(dialog.FileNames);
            this.richTextBoxFiles.Text = dialog.FileNames.Aggregate((current, next) => current + Environment.NewLine + next);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Handles the button click to generate the word cloud.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void ButtonGenerateClick(object sender, EventArgs e)
    {
        try
        {
            if (!this.CheckFilesSelected())
            {
                return;
            }

            var wordCloudGenerator = new TheWordCloudGenerator(this.languageManager)
            {
                FileBlackListLocation = this.fileAndBlackList,
                CompareType = StringCompareType.CaseSensitive
            };

            wordCloudGenerator.Generate();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Checks whether the files are selected or not.
    /// </summary>
    /// <returns><c>true</c> if the files are selected, <c>false</c> else.</returns>
    private bool CheckFilesSelected()
    {
        if (string.IsNullOrWhiteSpace(this.richTextBoxFiles.Text))
        {
            MessageBox.Show(this.languageManager.GetWord("NoFileSelectedText"), this.languageManager.GetWord("NoFileSelectedCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (!string.IsNullOrWhiteSpace(this.richTextBoxFileSaved.Text))
        {
            return true;
        }

        MessageBox.Show(this.languageManager.GetWord("NoImageSelectedText"), this.languageManager.GetWord("NoImageSelectedCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }

    /// <summary>
    /// Handles the button click to save the image.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void ButtonSaveImageClick(object sender, EventArgs e)
    {
        try
        {
            var dialog = new SaveFileDialog { Filter = this.languageManager.GetWord("FilterImageFiles") };
            var result = dialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            this.richTextBoxFileSaved.Text = dialog.FileName;
            this.fileAndBlackList.SaveImageLocation = dialog.FileName;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Handles the button click to select the blacklist.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void ButtonSelectBlacklistClick(object sender, EventArgs e)
    {
        try
        {
            new BlacklistDialog().ShowDialog();
            this.LoadBlacklists();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Handles the selected language changed event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void ComboBoxBlacklistSelectedIndexChanged(object sender, EventArgs e)
    {
        this.fileAndBlackList.Blacklist = this.GetFilterList();
    }

    /// <summary>
    /// Gets the filter list.
    /// </summary>
    /// <returns>A new <see cref="IEnumerable{T}"/> of <see cref="string"/>s.</returns>
    private IEnumerable<string> GetFilterList()
    {
        var filterList = new List<string>();
        var blacklist = this.blacklistModel.Blacklists.Find(x => x.Name.Equals(this.comboBoxBlacklist.SelectedItem.ToString()));

        if (blacklist == null)
        {
            return filterList;
        }

        filterList.AddRange(blacklist.FilterList.Select(filterListItem => filterListItem.Item));
        return filterList;
    }

    /// <summary>
    /// Initializes the language manager.
    /// </summary>
    private void InitializeLanguageManager()
    {
        this.languageManager.SetCurrentLanguage("de-DE");
        this.languageManager.OnLanguageChanged += this.OnLanguageChanged;
    }

    /// <summary>
    /// Loads the languages to the combo box.
    /// </summary>
    private void LoadLanguagesToCombo()
    {
        foreach (var lang in this.languageManager.GetLanguages())
        {
            this.comboBoxLanguage.Items.Add(lang.Name);
        }

        this.comboBoxLanguage.SelectedIndex = 0;
    }

    /// <summary>
    /// Handles the language selected event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void ComboBoxLanguageSelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedItem = this.comboBoxLanguage.SelectedItem.ToString();

        if (string.IsNullOrWhiteSpace(selectedItem))
        {
            return;
        }

        this.languageManager.SetCurrentLanguageFromName(selectedItem);
    }

    /// <summary>
    /// Handles the language changed event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void OnLanguageChanged(object sender, EventArgs e)
    {
        this.buttonChooseFile.Text = this.languageManager.GetCurrentLanguage().GetWord("ChooseFile");
        this.buttonGenerate.Text = this.languageManager.GetCurrentLanguage().GetWord("GenerateWordCloud");
        this.buttonSaveImage.Text = this.languageManager.GetCurrentLanguage().GetWord("SaveFileUnder");
        this.labelBlacklists.Text = this.languageManager.GetCurrentLanguage().GetWord("Blacklist");
        this.buttonSelectBlacklist.Text = this.languageManager.GetCurrentLanguage().GetWord("DefineBlacklists");
    }
}
