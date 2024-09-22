using System.Collections.Generic;
using Mazes.TestCases;

namespace Mazes.UI;

public partial class App
{
    private IEnumerable<TestCase> TestCases => CreateTestCases();

    private static IEnumerable<TestCase> CreateTestCases()
    {
        yield return new MazeTestCase("empty1", EmptyMazeTask.MoveOut);
        yield return new MazeTestCase("empty2", EmptyMazeTask.MoveOut);
        yield return new MazeTestCase("empty3", EmptyMazeTask.MoveOut);
        yield return new MazeTestCase("empty4", EmptyMazeTask.MoveOut);
        yield return new MazeTestCase("empty5", EmptyMazeTask.MoveOut);
        yield return new MazeTestCase("snake1", SnakeMazeTask.MoveOut);
        yield return new MazeTestCase("snake2", SnakeMazeTask.MoveOut);
        yield return new MazeTestCase("snake3", SnakeMazeTask.MoveOut);
        /*
        yield return new MazeTestCase("pyramid1", PyramidMazeTask.MoveOut);
        yield return new MazeTestCase("pyramid2", PyramidMazeTask.MoveOut);
        yield return new MazeTestCase("pyramid3", PyramidMazeTask.MoveOut);
        yield return new MazeTestCase("pyramid4", PyramidMazeTask.MoveOut);
        */
        yield return new MazeTestCase("diagonal1", DiagonalMazeTask.MoveOut);
        yield return new MazeTestCase("diagonal2", DiagonalMazeTask.MoveOut);
        yield return new MazeTestCase("diagonal3", DiagonalMazeTask.MoveOut);
    }
}