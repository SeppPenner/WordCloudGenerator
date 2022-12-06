// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlacklistDialog.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The blacklist dialog form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator;

/// <summary>
/// The blacklist dialog form.
/// </summary>
public partial class BlacklistDialog : Form
{
    /// <summary>
    /// The language manager.
    /// </summary>
    private readonly ILanguageManager languageManager = new LanguageManager();

    /// <summary>
    /// Initializes a new instance of the <see cref="BlacklistDialog"/> class.
    /// </summary>
    public BlacklistDialog()
    {
        this.InitializeComponent();
        this.InitializeLanguageManager();
        this.LoadLanguagesToCombo();
    }

    /// <summary>
    /// Gets a <see cref="string"/> from the filter list.
    /// </summary>
    /// <param name="filterList">The filter list.</param>
    /// <returns>A <see cref="string"/>.</returns>
    private static string GetStringFromList(IList<BlacklistItem> filterList)
    {
        var toReturn = string.Empty;

        foreach (var item in filterList)
        {
            if (filterList.IndexOf(item) == filterList.Count)
            {
                continue;
            }

            if (filterList.IndexOf(item) != 0)
            {
                toReturn = toReturn + ";" + item.Item;
            }
            else
            {
                toReturn = item.Item;
            }
        }

        return toReturn;
    }

    /// <summary>
    /// Adds items to the list.
    /// </summary>
    /// <param name="strings">The <see cref="string"/>s.</param>
    /// <param name="list">The list.</param>
    private static void AddItemsToList(IEnumerable<string> strings, List<BlacklistItem> list)
    {
        list.AddRange(strings.Select(item => new BlacklistItem { Item = item }));
    }

    /// <summary>
    /// Gets a list of the <see cref="string"/>.
    /// </summary>
    /// <param name="s">The <see cref="string"/>.</param>
    /// <returns>A new <see cref="List{T}"/> of <see cref="BlacklistItem"/>s.</returns>
    private static List<BlacklistItem> GetListFromString(string s)
    {
        var list = new List<BlacklistItem>();
        var strings = s.Split(';');
        AddItemsToList(strings, list);
        return list;
    }

    /// <summary>
    /// Adds items to the blacklist.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="row">The row.</param>
    private static void AddItemsToBlacklist(BlacklistModel model, DataGridViewRow row)
    {
        if (row.Cells[0].Value is null)
        {
            return;
        }

        if (model.Blacklists is null)
        {
            model.Blacklists = new List<Blacklist>();
        }

        var list = new Blacklist
        {
            Name = row.Cells[0].Value.ToString() ?? string.Empty,
            FilterList = GetListFromString(row.Cells[1].Value.ToString() ?? string.Empty)
        };

        model.Blacklists.Add(list);
    }

    /// <summary>
    /// Initializes the language manager.
    /// </summary>
    private void InitializeLanguageManager()
    {
        this.languageManager.SetCurrentLanguage("de-DE");
        this.languageManager.OnLanguageChanged += this.OnLanguageChanged!;
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
    /// Handles the language changed event.
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
        this.buttonSubmit.Text = this.languageManager.GetCurrentLanguage().GetWord("SaveBlacklists");
        this.Text = this.languageManager.GetCurrentLanguage().GetWord("BlacklistTitle");
    }

    /// <summary>
    /// Handles the button click for submitting.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void ButtonSubmitClick(object sender, EventArgs e)
    {
        try
        {
            this.ExportBlacklists(this.GetDataFromTable());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Gets the data form the table.
    /// </summary>
    /// <returns>A new <see cref="BlacklistModel"/>.</returns>
    private BlacklistModel GetDataFromTable()
    {
        var model = new BlacklistModel();

        foreach (DataGridViewRow row in this.dataGridViewBlacklist.Rows)
        {
            AddItemsToBlacklist(model, row);
        }

        return model;
    }

    /// <summary>
    /// Exports the blacklists.
    /// </summary>
    /// <param name="blacklistModel">The blacklists model.s</param>
    private void ExportBlacklists(BlacklistModel blacklistModel)
    {
        var importExport = new ImportExport();
        importExport.WriteDataToXmlFile(blacklistModel, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Blacklist.xml"));
        MessageBox.Show(this.languageManager.GetWord("BlacklistSavedTest"), this.languageManager.GetWord("BlacklistSavedCaption"), MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// Handles the blacklist dialog load event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event args.</param>
    private void BlacklistDialogLoad(object sender, EventArgs e)
    {
        try
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Blacklist.xml")))
            {
                return;
            }

            var importExport = new ImportExport();
            var blacklistModel = importExport.LoadConfigFromXmlFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Blacklist.xml")) ?? new();
            this.LoadDataToTable(blacklistModel);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Loads the data to the table.
    /// </summary>
    /// <param name="blacklistModel">The blacklist model.</param>
    private void LoadDataToTable(BlacklistModel blacklistModel)
    {
        foreach (var blacklist in blacklistModel.Blacklists)
        {
            this.LoadDataRow(blacklist);
        }
    }

    /// <summary>
    /// Loads the data row.
    /// </summary>
    /// <param name="blacklist">The blacklist.</param>
    private void LoadDataRow(Blacklist blacklist)
    {
        var row = new DataGridViewRow();
        row.Cells.Add(new DataGridViewTextBoxCell());
        row.Cells.Add(new DataGridViewTextBoxCell());
        row.Cells[0].Value = blacklist.Name;
        row.Cells[1].Value = GetStringFromList(blacklist.FilterList);
        this.dataGridViewBlacklist.Rows.Add(row);
    }
}
