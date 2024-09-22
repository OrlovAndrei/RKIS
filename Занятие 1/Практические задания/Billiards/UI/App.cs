using System.Collections.Generic;
using Billiards.TestCases;

namespace Billiards.UI;

public partial class App
{
    private IEnumerable<TestCase> TestCases => CreateTestCases();

    private static IEnumerable<TestCase> CreateTestCases()
    {
        yield return new BilliardTestCase(45, 90, 135);
        yield return new BilliardTestCase(10, 90, 170);
        yield return new BilliardTestCase(171, 90, 9);
        yield return new BilliardTestCase(90, 90, 90);
        yield return new BilliardTestCase(91, 90, 89);
        yield return new BilliardTestCase(90, 0, 270);
        yield return new BilliardTestCase(270, 0, 90);
        yield return new BilliardTestCase(-95, 0, 95);
        yield return new BilliardTestCase(10, 0, 350);
        yield return new BilliardTestCase(40, 0, 320);
        yield return new BilliardTestCase(0, 45, 90);
        yield return new BilliardTestCase(45, 45, 45);
        yield return new BilliardTestCase(44, 45, 46);
        yield return new BilliardTestCase(-44, -45, -46);
        yield return new BilliardTestCase(44, -45, -134);
        yield return new BilliardTestCase(0, 10, 20);
        yield return new BilliardTestCase(0, -10, -20);
    }
}