using OxyPlot;

namespace StructBenchmarking.UI;

public class TabItemModel
{
	public string Header { get; }
	public PlotModel Model { get; }
	public PlotController Controller { get; } = new();

	public TabItemModel(string header, PlotModel model)
	{
		Header = header;
		Model = model;
		Controller.UnbindAll();
		Controller.BindMouseDown(OxyMouseButton.Left, PlotCommands.Track);
	}
}