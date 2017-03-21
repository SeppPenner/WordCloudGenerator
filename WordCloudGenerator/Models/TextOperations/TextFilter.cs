using System.Collections.Generic;
using System.Linq;
using Interfaces.TextOperations;
using Interfaces.WordCloud;
using Models.WordCloud;

namespace Models.TextOperations
{
    public class TextFilter : ITextFilter
    {
        public IEnumerable<IWord> FilterIgnoreCase(IEnumerable<IWord> wordList, IEnumerable<string> filterList)
        {
            var filterList2 = filterList.ToList().ConvertAll(d => d.ToUpper());

            var wordList2 = AllToUpper(wordList).ToList();

            for (var i = 0; i < wordList2.ToList().Count; i++)
            {
                if (filterList2.Contains(wordList2.ElementAt(i).Text))
                {
                    wordList2.RemoveAt(i);
                }
            }
            return wordList2;
        }

        public IEnumerable<IWord> Filter(IEnumerable<IWord> wordList, IEnumerable<string> filterList)
        {
            var filterList2 = filterList.ToList();
            var wordList2 = wordList.ToList();

            for (var i = 0; i < wordList2.ToList().Count; i++)
            {
                if (filterList2.Contains(wordList2.ElementAt(i).Text))
                {
                    wordList2.RemoveAt(i);
                }
            }
            return wordList2;
        }

        private IEnumerable<IWord> AllToUpper(IEnumerable<IWord> wordList)
        {
            var wordList2 = wordList.ToList();
            for (var i = 0; i < wordList2.Count; i++)
            {
                wordList2[i] = new Word(wordList2[i].Text.ToUpper(), wordList2[i].Occurrences);
            }
            return wordList2;
        }
    }
}