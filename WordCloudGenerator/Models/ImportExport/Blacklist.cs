using System;
using System.Collections.Generic;

namespace Models.ImportExport
{
    [Serializable]
    public class Blacklist
    {
        public string Name { get; set; }
        public List<BlacklistItem> FilterList { get; set; }
    }
}