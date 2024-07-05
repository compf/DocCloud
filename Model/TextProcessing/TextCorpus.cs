using UglyToad.PdfPig.Graphics.Operations.TextState;

namespace DocCloud.Model.TextProcessing
{
    public class TextCorpus
    {
        public Dictionary<string, int> WordFrequency { get; set; }
        public TextCorpus(string text)
        {
            WordFrequency = new();
            foreach (var word in text.Split(' '))
            {
                if (WordFrequency.ContainsKey(word))
                {
                    WordFrequency[word]++;
                }
                else
                {
                    WordFrequency[word] = 1;
                }
            }
        }

        public double GetRelativeFrequency(string word)
        {
            if (WordFrequency.ContainsKey(word))
            {
                return WordFrequency[word] / (double)WordFrequency.Values.Sum();
            }
            return 0;
        }
        public double GetRelativeFrequencyInverse(string word)
        {
            if (WordFrequency.ContainsKey(word))
            {
                return 1 / GetRelativeFrequency(word);
            }
            return 0;
        }

        public int GetFrequency(string word)
        {
            if (WordFrequency.ContainsKey(word))
            {
                return WordFrequency[word];
            }
            return 0;
        }


        public HashSet<string> GetMostImportantWords( int numberWords,IWordFilter filter, IWordMetric metric, TextCorpus archiveCorpus)
        {
            HashSet<string> result = new();
            foreach (var word in WordFrequency.Keys)
            {
                if (filter.ShallRemain(word, this, archiveCorpus))
                {
                    result.Add(word);
                }
            }

            return result.OrderByDescending(word => metric.Evaluate(word, this, archiveCorpus)).Take(numberWords).ToHashSet();
        }

    }
}