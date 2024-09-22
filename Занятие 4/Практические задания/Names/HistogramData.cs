using System.Linq;

namespace Names;

public class HistogramData
{
	public HistogramData(string title, string[] xLabels, double[] yValues)
	{
		Title = title;
		XLabels = xLabels;
		YValues = yValues;
	}

	public string Title { get; }
	public string[] XLabels { get; }
	public double[] YValues { get; }

	public bool Equals(HistogramData other)
	{
		return other.XLabels.SequenceEqual(XLabels) && other.YValues.SequenceEqual(YValues);
	}
}