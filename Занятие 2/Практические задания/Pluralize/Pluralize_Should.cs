using NUnit.Framework;

namespace Pluralize;

[TestFixture]
public class Pluralize_Should
{
    [Test]
    public void BeCorrect()
    {
        // Это пример ввода сложных данных из файла.
        // Циклы, строки, массивы будут рассмотрены на лекциях чуть позже, но это не должно быть препятствием вашему любопытству! :)
        var lines = File.ReadAllLines("rubles.txt");

        foreach (var line in lines)
        {
            var words = line.Split(' ');
            var count = int.Parse(words[0]);
            var rightAnswer = words[1];
            var pluralizedRubles = PluralizeTask.PluralizeRubles(count);
            if (pluralizedRubles != rightAnswer)
            {
                //сравниваем полученный результат с ожидаемым
                Assert.AreEqual(rightAnswer, pluralizedRubles);
            }
        }
    }
}