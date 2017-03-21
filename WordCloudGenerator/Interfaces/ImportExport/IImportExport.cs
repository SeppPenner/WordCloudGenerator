using Models.ImportExport;

namespace Interfaces.ImportExport
{
    public interface IImportExport
    {
        void WriteDataToXmlFile<T>(T items, string fileName);

        BlacklistModel LoadConfigFromXmlFile(string filename);
    }
}