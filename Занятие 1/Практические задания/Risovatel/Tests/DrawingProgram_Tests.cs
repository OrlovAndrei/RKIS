using Avalonia.Media;
using NUnit.Framework;
using RefactorMe.Common;

namespace RefactorMe.Tests;

[TestFixture]
public class DrawingProgram_Tests
{
	[Test]
	public void DrawExpectedImage()
	{
		//Вы можете посмотреть expected.bmp для визуального представления результата
		var expected = GetCorrectGraphics();
		var actual = new MockedGraphics();

		ImpossibleSquare.Draw(WindowSettings.Width, WindowSettings.Height, 0, actual);
		var comparison = actual.CompareTo(expected);

		if (comparison is not null)
			Assert.Fail(comparison);
	}

	//Mocked graphics which contains all correct lines
	private MockedGraphics GetCorrectGraphics()
	{
		var correct = new MockedGraphics();
		correct.Clear(Colors.Black);
		var yellowPen = new Pen(Brushes.Yellow);
		correct.DrawLine(yellowPen, 275.5f, 175.5f, 500.5f, 175.5f);
		correct.DrawLine(yellowPen, 500.5f, 175.5f, 524.5f, 199.5f);
		correct.DrawLine(yellowPen, 524.5f, 199.5f, 299.5f, 199.5f);
		correct.DrawLine(yellowPen, 299.5f, 199.5f, 299.5f, 400.5f);
		correct.DrawLine(yellowPen, 251.5f, 424.5f, 251.5f, 199.5f);
		correct.DrawLine(yellowPen, 251.5f, 199.5f, 275.5f, 175.5f);
		correct.DrawLine(yellowPen, 275.5f, 175.5f, 275.5f, 400.5f);
		correct.DrawLine(yellowPen, 275.5f, 400.5f, 476.5f, 400.5f);
		correct.DrawLine(yellowPen, 500.5f, 448.5f, 275.5f, 448.5f);
		correct.DrawLine(yellowPen, 275.5f, 448.5f, 251.5f, 424.5f);
		correct.DrawLine(yellowPen, 251.5f, 424.5f, 476.5f, 424.5f);
		correct.DrawLine(yellowPen, 476.5f, 424.5f, 476.5f, 223.5f);
		correct.DrawLine(yellowPen, 524.5f, 199.5f, 524.5f, 424.5f);
		correct.DrawLine(yellowPen, 524.5f, 424.5f, 500.5f, 448.5f);
		correct.DrawLine(yellowPen, 500.5f, 448.5f, 500.5f, 223.5f);
		correct.DrawLine(yellowPen, 500.5f, 223.5f, 299.5f, 223.5f);
		return correct;
	}
}