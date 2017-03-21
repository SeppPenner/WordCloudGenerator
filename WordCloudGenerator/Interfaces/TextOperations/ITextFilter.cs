using System.Collections.Generic;
using Interfaces.WordCloud;

namespace Interfaces.TextOperations
{
    public interface ITextFilter
    {
        IEnumerable<IWord> Filter(IEnumerable<IWord> wordList, IEnumerable<string> filterList);

        IEnumerable<IWord> FilterIgnoreCase(IEnumerable<IWord> wordList, IEnumerable<string> filterList);
    }
}