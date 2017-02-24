using Interfaces.WordCloud;

namespace Models.WordCloud
{
    public class Word : IWord
    {
        public Word(string text, int occurrences)
        {
            Text = text;
            Occurrences = occurrences;
        }

        public Word()
        {
        }

        public string Text { get; set; }
        public int Occurrences { get; set; }
    }
}