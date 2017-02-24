using Interfaces.TransferObjects;

namespace Models.TransferObjects
{
    public class MinMax : IMinMax
    {
        public int Min { get; set; }

        public int Max { get; set; }
    }
}