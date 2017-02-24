using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Interfaces.FileOperations;
using Interfaces.TransferObjects;
using Interfaces.WordCloud;
using Languages.Implementation;
using Languages.Interfaces;
using Models.Enumerations;
using Models.FileOperations;
using Models.ImportExport;
using Models.TransferObjects;
using Models.WordCloud;
using Properties;
using IImportExport = Interfaces.ImportExport.IImportExport;
using ImportExport = Models.ImportExport.ImportExport;

public partial class Main : Form
{
    private readonly IFileBlackListLocation _fileAndBlackList = new FileBlackListLocation();

    private readonly ILanguageManager _lm = new LanguageManager();
    private BlacklistModel _blacklistModel = new BlacklistModel();

    public Main()
    {
        Initialize();
    }

    private void Initialize()
    {
        InitializeComponent();
        InitializeCaption();
        LoadBlacklists();
        InitializeLanguageManager();
        LoadLanguagesToCombo();
    }

    private void InitializeCaption()
    {
        Text = Application.ProductName + @" " + Application.ProductVersion;
    }

    private void LoadBlacklists()
    {
        try
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Blacklist.xml"))) return;
            IImportExport importExport = new ImportExport();
            _blacklistModel =
                importExport.LoadConfigFromXmlFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Blacklist.xml"));
            LoadDataToCombobox(_blacklistModel);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadDataToCombobox(BlacklistModel blacklistModel)
    {
        comboBoxBlacklist.Items.Clear();
        foreach (var blacklist in blacklistModel.Blacklists)
            comboBoxBlacklist.Items.Add(blacklist.Name);
    }

    private void buttonChooseFile_Click(object sender, EventArgs e)
    {
        try
        {
            var dialog = new OpenFileDialog {Multiselect = true, Filter = Resources.FilterAllFiles};
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;
            _fileAndBlackList.Files = GetFileList(dialog.FileNames);
            richTextBoxFiles.Text = dialog.FileNames.Aggregate((current, next) => current + Environment.NewLine + next);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private IEnumerable<string> GetFileList(string[] fileNames)
    {
        IFileListFactory fileFactory = new FileListFactory();
        return fileFactory.GetFileList(fileNames);
    }

    private void buttonGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            if (!CheckFilesSelected()) return;
            IWordCloudGenerator wordCloudGenerator = new WordCloudGenerator
            {
                FileBlackListLocation = _fileAndBlackList,
                CompareType = StringCompareType.CaseSensitive
            };
            wordCloudGenerator.Generate();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool CheckFilesSelected()
    {
        if (string.IsNullOrWhiteSpace(richTextBoxFiles.Text))
        {
            MessageBox.Show(Resources.NoFileSelectedText, Resources.NoFileSelectedCaption, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return false;
        }
        if (!string.IsNullOrWhiteSpace(richTextBoxFileSaved.Text)) return true;
        MessageBox.Show(Resources.NoImageSelectedText, Resources.NoImageSelectedCaption, MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        return false;
    }

    private void buttonSaveImage_Click(object sender, EventArgs e)
    {
        try
        {
            var dialog = new SaveFileDialog {Filter = Resources.FilterImageFiles};
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;
            richTextBoxFileSaved.Text = dialog.FileName;
            _fileAndBlackList.SaveImageLocation = dialog.FileName;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void buttonSelectBlacklist_Click(object sender, EventArgs e)
    {
        try
        {
            new BlacklistDialog().ShowDialog();
            LoadBlacklists();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void comboBoxBlacklist_SelectedIndexChanged(object sender, EventArgs e)
    {
        _fileAndBlackList.Blacklist = GetFilterList();
    }

    private IEnumerable<string> GetFilterList()
    {
        var filterList = new List<string>();
        var blacklist = _blacklistModel.Blacklists.Find(x => x.Name.Equals(comboBoxBlacklist.SelectedItem.ToString()));
        foreach (var filterListItem in blacklist.FilterList)
            filterList.Add(filterListItem.Item);
        return filterList;
    }

    private void InitializeLanguageManager()
    {
        _lm.SetCurrentLanguage("de-DE");
        _lm.OnLanguageChanged += OnLanguageChanged;
    }

    private void LoadLanguagesToCombo()
    {
        foreach (var lang in _lm.GetLanguages())
            comboBoxLanguage.Items.Add(lang.Name);
        comboBoxLanguage.SelectedIndex = 0;
    }

    private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (comboBoxLanguage.SelectedItem.ToString())
        {
            case "Deutsch":
                _lm.SetCurrentLanguage("de-DE");
                break;
            case "English (US)":
                _lm.SetCurrentLanguage("en-US");
                break;
        }
    }

    private void OnLanguageChanged(object sender, EventArgs eventArgs)
    {
        buttonChooseFile.Text = _lm.GetCurrentLanguage().GetWord("ChooseFile");
        buttonGenerate.Text = _lm.GetCurrentLanguage().GetWord("GenerateWordcloud");
        buttonSaveImage.Text = _lm.GetCurrentLanguage().GetWord("SaveFileUnder");
        labelBlacklists.Text = _lm.GetCurrentLanguage().GetWord("Blacklist");
        buttonSelectBlacklist.Text = _lm.GetCurrentLanguage().GetWord("DefineBlacklists");
    }
}