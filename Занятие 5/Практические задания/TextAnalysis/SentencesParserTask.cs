using System.Collections.Generic;
using System.Linq;
using System.Text;
 
 
namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var stopWords =new string[]{"Mr.","Mrs."};
            var sentencesList = new List<List<string>>();
            var punctuation = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            var sentences = text
                .Split(punctuation).Except(stopWords)
                .Select(a => a.Split(' ',',','"',)
                .Where(b => b.Any(c=> char.IsLetter(c)&&char.IsLower(b[0])
                || c=='`'&& char.IsLetter(c) && char.IsLower(b[0])))
                .Select(b => b).ToList())
                .Where(z=> z.Count!=0).Select(z=>z).ToList();
 
 
            return sentences;
        }
    }
}
