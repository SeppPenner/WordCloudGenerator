using System.Collections.Generic;

namespace Interfaces.TransferObjects
{
    public interface IFileBlackListLocation
    {
        IEnumerable<string> Files { get; set; }
        IEnumerable<string> Blacklist { get; set; }
        string SaveImageLocation { get; set; }
    }
}