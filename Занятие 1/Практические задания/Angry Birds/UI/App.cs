using System.Collections.Generic;
using AngryBirds.TestCases;

namespace AngryBirds.UI;

public partial class App
{
    private IEnumerable<TestCase> TestCases => CreateTestCases();

    private static IEnumerable<TestCase> CreateTestCases()
    {
        yield return new AngryBirdsTestCase(100, 1000);
        yield return new AngryBirdsTestCase(10, 0);
        yield return new AngryBirdsTestCase(99.1, 1000);
        yield return new AngryBirdsTestCase(450, 20000);
        yield return new AngryBirdsTestCase(450, 1000);
        yield return new AngryBirdsTestCase(450, 200);
        yield return new AngryBirdsTestCase(10, 1);
        yield return new AngryBirdsTestCase(9, 1);
        yield return new AngryBirdsTestCase(8, 1);
        yield return new AngryBirdsTestCase(7, 1);
        yield return new AngryBirdsTestCase(6, 1);
        yield return new AngryBirdsTestCase(5, 1);
        yield return new AngryBirdsTestCase(4, 1);
        yield return new AngryBirdsTestCase(3.5, 1);
        yield return new AngryBirdsTestCase(3.2, 1);
        yield return new AngryBirdsTestCase(3.15, 1);
        yield return new AngryBirdsTestCase(3.14, 1);
        yield return new AngryBirdsTestCase(1, 1000, hasSolution:false);
    }
}