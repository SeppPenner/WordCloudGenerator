namespace Interfaces.WordCloud
{
    public interface IWord
    {
        string Text { get; }
        int Occurrences { get; }
    }
}