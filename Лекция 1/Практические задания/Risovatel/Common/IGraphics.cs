using Color = Avalonia.Media.Color;
using Pen = Avalonia.Media.Pen;

namespace RefactorMe.Common;

public interface IGraphics
{
	void Clear(Color color);
	void DrawLine(Pen pen, float x, float y, float x1, float y1);
}