[TestFixture]
public class AutocompleteTests
{
    private readonly IReadOnlyList<string> _testPhrases = new[]
    {
        "apple",
        "application",
        "banana",
        "carrot",
        "cat",
        "dog",
        "elephant",
        "fox",
        "goat",
        "horse",
        "icecream",
        "juice",
        "kiwi",
        "lemon",
        "mango",
        "orange",
        "pineapple",
        "queen",
        "rabbit",
        "snake",
        "tomato",
        "umbrella",
        "vanilla",
        "watermelon",
        "xylophone",
        "yak",
        "zebra"
    };

    [Test]
    public void TopByPrefix_IsEmpty_WhenNoPhrases()
    {
        var topWords = AutocompleteTask.GetTopByPrefix(new List<string>(), "ap", 10);
        CollectionAssert.IsEmpty(topWords);
    }

    [Test]
    public void TopByPrefix_ReturnsCorrectResults_ForValidPrefix()
    {
        var expectedTopWords = new[] { "apple", "application" };
        var actualTopWords = AutocompleteTask.GetTopByPrefix(_testPhrases, "ap", 2);
        CollectionAssert.AreEquivalent(expectedTopWords, actualTopWords);
    }

    [Test]
    public void CountByPrefix_IsZero_WhenNoMatches()
    {
        var actualCount = AutocompleteTask.GetCountByPrefix(_testPhrases, "xyz");
        Assert.AreEqual(0, actualCount);
    }

    [Test]
    public void CountByPrefix_IsCorrect_ForValidPrefix()
    {
        var expectedCount = 2;
        var actualCount = AutocompleteTask.GetCountByPrefix(_testPhrases, "ap");
        Assert.AreEqual(expectedCount, actualCount);
    }
}
