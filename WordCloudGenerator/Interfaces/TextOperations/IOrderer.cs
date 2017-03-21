using System.Collections.Generic;
using Interfaces.WordCloud;

namespace Interfaces.TextOperations
{
    public interface IOrderer
    {
        IEnumerable<IWord> Order(IEnumerable<IWord> words);
    }
}