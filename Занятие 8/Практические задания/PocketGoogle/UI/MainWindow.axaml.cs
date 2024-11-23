using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Avalonia.Controls;
using Avalonia.Media;

namespace PocketGoogle.UI;

public partial class MainWindow : Window
{
	private readonly IIndexer indexer;
	public ObservableCollection<TextBox> Items { get; }

	private readonly Dictionary<int, string> texts;

	public MainWindow()
	{
		Items = new ObservableCollection<TextBox>();
		texts = new Dictionary<int, string>();
		indexer = new Indexer();

		var directoryInfo = new DirectoryInfo("Texts");
		foreach (var file in directoryInfo.GetFiles("*.txt"))
		{
			var parts = file.Name.Split('.');
			var id = int.Parse(parts[0]);
			var text = File.ReadAllText(file.FullName).Replace("\r", "");

			texts[id] = text;
			indexer.Add(id, text);
		}

		InitializeComponent();
		Run.Click += (_, __) => { PerformSearch(); };
		Results.Items = Items;
	}

	private void PerformSearch()
	{
		var text = Request.Text;
		var ids = indexer.GetIds(text);
		Items.Clear();
		var brush = new SolidColorBrush
		{
			Color = Colors.LightBlue
		};
		foreach (var id in ids)
		{
			var textBox = new TextBox();
			foreach (var position in indexer.GetPositions(id, text))
			{
				textBox.Text = texts[id];
				textBox.SelectionStart = position;
				textBox.SelectionEnd = position + text.Length;
				textBox.SelectionBrush = brush;
			}
			Items.Add(textBox);
		}
	}
}