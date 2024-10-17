using NUnit.Framework;

namespace TextAnalysis;

[TestFixture]
public class TextGenerator_Tests
{
    [TestCase("x", 10)]
    [TestCase("a b c", 1)]
    [Order(00)]
    public void ContinuePhrase_DoNothing_OnEmptyDictionary(string phraseStart, int phraseWordsCount)
    {
        var actual = TextGeneratorTask.ContinuePhrase(
            new Dictionary<string, string>(),
            phraseStart,
            phraseWordsCount);
        Assert.AreEqual(phraseStart, actual);
    }

    [Test]
    [Order(05)]
    public void ContinuePhrase_DoNothing_WhenWordsCountIsZero()
    {
        var mostFrequentNextWords = new Dictionary<string, string>
        {
            {"x", "y"}
        };

        var actual =
            TextGeneratorTask.ContinuePhrase(mostFrequentNextWords, "x", 0);
        Assert.AreEqual("x", actual);
    }

    [TestCase("x", "y z")]
    [TestCase("y", "z x")]
    [TestCase("y", "z x")]
    [TestCase("a", "b")]
    [TestCase("z", "x y")]
    [TestCase("a x", "y z")]
    [TestCase("a b x", "y z")]
    [TestCase("y z x", "y z")]
    [TestCase("w x", "y z")]
    [Order(10)]
    public void ContinuePhrase_WhenNoTrigrams(string phraseBeginning, string expectedNextWord)
    {
        var mostFrequentNextWords = new Dictionary<string, string>
        {
            {"x", "y"},
            {"y", "z"},
            {"z", "x"},
            {"a", "b" }
        };

        var actual =
            TextGeneratorTask.ContinuePhrase(mostFrequentNextWords, phraseBeginning, 2);
        Assert.AreEqual(phraseBeginning + " " + expectedNextWord, actual);
    }

    [TestCase("x", 1, "x y")]
    [TestCase("x", 2, "x y z")]
    [TestCase("x", 3, "x y z")]
    [TestCase("x", 100, "x y z")]
    [TestCase("x y", 100, "x y z")]
    [TestCase("x x", 2, "x x y z")]
    [TestCase("y x", 1, "y x y")]
    [TestCase("y y", 1, "y y q")]
    [TestCase("y z", 1, "y z")]
    [TestCase("a b x y", 1, "a b x y z")]
    [TestCase("a b y", 1, "a b y q")]
    [TestCase("y", 100, "y q")]
    [Order(10)]
    public void ContinuePhrase(string phraseBeginning, int wordsCount, string expectedResult)
    {
        var mostFrequentNextWords = new Dictionary<string, string>
        {
            {"x", "y"},
            {"x y", "z"},
            {"y", "q"}
        };

        var actual =
            TextGeneratorTask.ContinuePhrase(mostFrequentNextWords, phraseBeginning, wordsCount);
        Assert.AreEqual(expectedResult, actual);
    }

    [TestCase("x y", "z")]
    [TestCase("x y z", "w")]
    [TestCase("y z", "w")]
    [TestCase("x y z w", "v")]
    [TestCase("y z w", "v")]
    [TestCase("z w", "v")]
    [Order(15)]
    public void ContinuePhraseWithTrigrams(string phraseBeginning, string expectedNextWord)
    {
        var mostFrequentNextWords = new Dictionary<string, string>
        {
            {"x", "y"},
            {"x y", "z"},
            {"y z", "w"},
            {"z w", "v"},
            {"y", "a"},
            {"z", "b"}
        };

        var actual =
            TextGeneratorTask.ContinuePhrase(mostFrequentNextWords, phraseBeginning, 1);
        Assert.AreEqual(phraseBeginning + " " + expectedNextWord, actual);
    }

    [Test]
    [Order(10)]
    public void ContinuePhrase_StopWhenNoBigrammsAndTrigramms()
    {
        var mostFrequentNextWords = new Dictionary<string, string>
        {
            {"x", "y"},
            {"x y", "z"},
            {"y", "q"}
        };

        var actual =
            TextGeneratorTask.ContinuePhrase(mostFrequentNextWords, "x", 4);
        Assert.AreEqual("x y z", actual);
    }

    [TestCase("x", "")]
    [TestCase("hello", "everybody")]
    [TestCase("hello everybody", "be")]
    [TestCase("hello everybody be", "cool")]
    [TestCase("everybody be", "cool")]
    [TestCase("be", "")]
    [TestCase("goodbye", "")]
    [TestCase("be cool", "")]
    [Order(20)]
    public void ContinuePhrase_WithMultiletterWords(string phraseBeginning, string expectedNextWord)
    {
        var mostFrequentNextWords = new Dictionary<string, string>
        {
            {"hello", "everybody"},
            {"everybody be", "cool"},
            {"everybody", "be"}
        };

        var actual =
            TextGeneratorTask.ContinuePhrase(mostFrequentNextWords, phraseBeginning, 1);
        var expected = string.IsNullOrEmpty(expectedNextWord) ? phraseBeginning : phraseBeginning + " " + expectedNextWord;
        Assert.AreEqual(expected, actual);
    }

    [Order(50)]
    [TestCase("x", 2, "x x x")]
    [TestCase("x", 5, "x x x x x x")]
    [TestCase("y", 3, "y x x x")]
    [TestCase("z", 3, "z y x x")]
    [TestCase("a", 3, "a b c a")]
    [TestCase("a", 7, "a b c a b c a b")]
    [TestCase("b b", 7, "b b c a b c a b c")]
    public void ContinuePhrase_WhenCycleInDictionary(string phraseBeginning, int wordsCount, string expectedResult)
    {
        var mostFrequentNextWords = new Dictionary<string, string>
        {
            {"x", "x"},
            {"a", "b"},
            {"b", "c"},
            {"c", "a"},
            {"y", "x"},
            {"z", "y"},
        };
        var actual =
            TextGeneratorTask.ContinuePhrase(mostFrequentNextWords, phraseBeginning, wordsCount);

        Assert.AreEqual(expectedResult, actual);
    }
}