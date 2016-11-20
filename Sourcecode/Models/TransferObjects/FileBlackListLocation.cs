using System.Collections.Generic;
using Interfaces.TransferObjects;

namespace Models.TransferObjects
{
    public class FileBlackListLocation : IFileBlackListLocation
    {
        public IEnumerable<string> Files { get; set; }
        public IEnumerable<string> Blacklist { get; set; }
        public string SaveImageLocation { get; set; }
    }
}