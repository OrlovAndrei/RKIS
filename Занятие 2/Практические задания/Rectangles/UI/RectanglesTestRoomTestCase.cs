using Avalonia.Media;
using Rectangles.TestCases;

namespace Rectangles.UI;

public class RectanglesTestRoomTestCase : TestCase
{
    private readonly int indexOfInnerRectangle;
    private readonly bool intersected;
    private readonly int intersectionSquare;
    private readonly Rectangle r1;
    private readonly Rectangle r2;
    private int indexOfInnerRectAnswer;
    private bool intersectedAnswer;
    private int intersectionSquareAnswer;

    public RectanglesTestRoomTestCase(
        Rectangle r1,
        Rectangle r2, 
        bool intersected,
        int intersectionSquare,
        int indexOfInnerRectangle) : base("Rectangles")
    {
        this.r1 = r1;
        this.r2 = r2;
        this.intersected = intersected;
        this.intersectionSquare = intersectionSquare;
        this.indexOfInnerRectangle = indexOfInnerRectangle;
    }

    protected override void InternalVisualize(TestCaseUI ui)
    {
        ui.Rect(r1.Left, r1.Top, r1.Width, r1.Height, Brushes.Black);
        ui.Rect(r2.Left, r2.Top, r2.Width, r2.Height, Brushes.Black);
        ui.Log($"r1: {r1}");
        ui.Log($"r2: {r2}");
        ui.Log("Solution: ");
        var intersectedAsString = intersected != intersectedAnswer ? "wrong!" : "";
        ui.Log($"  intersected: {intersectedAnswer} {intersectedAsString}");
        var intersectionAsString = intersectionSquare != intersectionSquareAnswer ? "wrong!" : "";
        ui.Log($"  intersection square: {intersectionSquareAnswer} {intersectionAsString}");
        var indexOfInnerRectAnswerAsString = indexOfInnerRectangle != indexOfInnerRectAnswer ? "wrong!" : "";
        ui.Log($"  index of inner rectangle: {indexOfInnerRectAnswer} {indexOfInnerRectAnswerAsString}");
    }

    protected override bool InternalRun()
    {
        intersectedAnswer = RectanglesTask.AreIntersected(r1, r2);
        intersectionSquareAnswer = RectanglesTask.IntersectionSquare(r1, r2);
        indexOfInnerRectAnswer = RectanglesTask.IndexOfInnerRectangle(r1, r2);
        return intersected == intersectedAnswer && intersectionSquare == intersectionSquareAnswer &&
               indexOfInnerRectangle == indexOfInnerRectAnswer;
    }
}