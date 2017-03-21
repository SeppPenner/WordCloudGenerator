using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Languages.Implementation;
using Languages.Interfaces;
using Models.ImportExport;
using Properties;
using IImportExport = Interfaces.ImportExport.IImportExport;
using ImportExport = Models.ImportExport.ImportExport;

public partial class BlacklistDialog : Form
{
    private readonly ILanguageManager _lm = new LanguageManager();

    public BlacklistDialog()
    {
        InitializeComponent();
        InitializeLanguageManager();
        LoadLanguagesToCombo();
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
        buttonSubmit.Text = _lm.GetCurrentLanguage().GetWord("SaveBlacklists");
        Text = _lm.GetCurrentLanguage().GetWord("BlacklistTitle");
    }

    private void buttonSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ExportBlacklists(GetDataFromTable());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private BlacklistModel GetDataFromTable()
    {
        var model = new BlacklistModel();

        foreach (DataGridViewRow row in dataGridViewBlacklist.Rows)
            AddItemsToBlacklist(model, row);
        return model;
    }

    private void AddItemsToBlacklist(BlacklistModel model, DataGridViewRow row)
    {
        if (row.Cells[0].Value == null) return;
        if (model.Blacklists == null)
            model.Blacklists = new List<Blacklist>();

        var list = new Blacklist
        {
            Name = row.Cells[0].Value.ToString(),
            FilterList = GetListFromString(row.Cells[1].Value.ToString())
        };
        model.Blacklists.Add(list);
    }

    private List<BlacklistItem> GetListFromString(string s)
    {
        var list = new List<BlacklistItem>();
        var strings = s.Split(';');
        AddItemsToList(strings, list);
        return list;
    }

    private void AddItemsToList(string[] strings, List<BlacklistItem> list)
    {
        foreach (var item in strings)
            list.Add(new BlacklistItem {Item = item});
    }

    private void ExportBlacklists(BlacklistModel blacklistModel)
    {
        IImportExport importExport = new ImportExport();
        importExport.WriteDataToXmlFile(blacklistModel,
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Blacklist.xml"));
        MessageBox.Show(Resources.BlacklistSavedTest, Resources.BlacklistSavedCaption, MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void BlacklistDialog_Load(object sender, EventArgs e)
    {
        try
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Blacklist.xml"))) return;
            IImportExport importExport = new ImportExport();
            var blacklistModel =
                importExport.LoadConfigFromXmlFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Blacklist.xml"));
            LoadDataToTable(blacklistModel);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadDataToTable(BlacklistModel blacklistModel)
    {
        foreach (var blacklist in blacklistModel.Blacklists)
            LoadDataRow(blacklist);
    }

    private void LoadDataRow(Blacklist blacklist)
    {
        var row = new DataGridViewRow();
        row.Cells.Add(new DataGridViewTextBoxCell());
        row.Cells.Add(new DataGridViewTextBoxCell());
        row.Cells[0].Value = blacklist.Name;
        row.Cells[1].Value = GetStringFromList(blacklist.FilterList);
        dataGridViewBlacklist.Rows.Add(row);
    }

    private string GetStringFromList(IList<BlacklistItem> filterList)
    {
        var toReturn = "";
        foreach (var item in filterList)
        {
            if (filterList.IndexOf(item) == filterList.Count) continue;
            if (filterList.IndexOf(item) != 0)
                toReturn = toReturn + ";" + item.Item;
            else
                toReturn = item.Item;
        }
        return toReturn;
    }
}