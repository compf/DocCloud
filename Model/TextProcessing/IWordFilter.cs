namespace DocCloud.Model.TextProcessing
{
    public interface IWordFilter
    {
        public bool ShallRemain(string word,  TextCorpus currCorpus, TextCorpus archiveCorpus);
   
    }

    public class SmallOrFrequentWordFilter : IWordFilter
    {
        public bool ShallRemain(string word,  TextCorpus currCorpus, TextCorpus archiveCorpus)
        {
            if (word.Length <= 3)
            {
                return false;
            }
           if(archiveCorpus.GetRelativeFrequency(word)>0.2){
            return false;
           }
            return true;
        }
    }
}