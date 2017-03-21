using System.Collections.Generic;
using System.Linq;
using Interfaces.TextOperations;
using Interfaces.WordCloud;

namespace Models.TextOperations
{
    public class Orderer : IOrderer
    {
        public IEnumerable<IWord> Order(IEnumerable<IWord> words)
        {
            return words.ToList().OrderByDescending(x => x.Occurrences);
        }
    }
}