using System.Collections.Generic;
using Avalonia.Controls;
using OxyPlot;

namespace Names.UI;

public partial class MainWindow : Window
{
	public static List<TabItemModel> Tabs = new();
	public static MainWindow w;
            
	public MainWindow()
	{
		DataContext = Tabs;
		InitializeComponent();
		w = this;
	}
        
	public void InitializeComponent()
	{
		Avalonia.Markup.Xaml.AvaloniaXamlLoader.Load(this);
	}
}
    
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