namespace DocCloud.Model.TextProcessing;


public interface IWordMetric
{
    double Evaluate(string word,  TextCorpus currCorpus, TextCorpus archiveCorpus);
}

public class WordLengthImportanceMetric : IWordMetric
{
    public double Evaluate(string word,  TextCorpus currCorpus, TextCorpus archiveCorpus)
    {
        return word.Length *currCorpus.GetRelativeFrequency(word) +(archiveCorpus.GetRelativeFrequencyInverse(word));
    }
}