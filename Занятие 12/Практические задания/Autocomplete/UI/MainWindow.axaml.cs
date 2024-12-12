using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia.Controls;
using DynamicData.Binding;

namespace Autocomplete.UI;

public partial class MainWindow : Window
{
	public ObservableCollection<string> FoundedItems { get; }

	private long count;
	private Phrases phrases;
	private long sumMs;

	public MainWindow()
	{
		InitializeComponent();
		//list
		FoundedItems = new ObservableCollection<string> { "start typing" };
		AutocompleteList.Items = FoundedItems;
		//phrases
		phrases = CreatePhrases();
		if (phrases == null)
			Environment.Exit(-1);
		//input
		InputBox
			.WhenPropertyChanged(box => box.Text, false)
			.Subscribe(value => InputBox_TextChanged(value.Value));
		//ValidatePhrases();
		Opened += (_, __) => InputBox.Focus();
	}

	private (TimeSpan Elapsed, string[] FoundItems, int Count) FindItems(string prefix)
	{
		var sw = Stopwatch.StartNew();
		var foundItems = AutocompleteTask.GetTopByPrefix(phrases, prefix, 10);
		var foundItemsCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);
		if (foundItems != null) return (sw.Elapsed, foundItems, foundItemsCount);
		var oneItem = AutocompleteTask.FindFirstByPrefix(phrases, prefix);
		foundItems = oneItem != null ? new[] { oneItem } : Array.Empty<string>();

		return (sw.Elapsed, foundItems, foundItemsCount);
	}

	private async void InputBox_TextChanged(string? text)
	{
		if (InputBox.IsReadOnly) return;
		var prefix = text ?? "";
		FoundedItems.Clear();
		FoundedItems.Add("...searching...");
		InputBox.IsReadOnly = true;
		var task = Task.Run(() => FindItems(prefix));
		await task
			.TimeoutAfter(TimeSpan.FromSeconds(2))
			.ContinueWith(UpdateUi, TaskScheduler.FromCurrentSynchronizationContext());
	}

	private void UpdateUi(Task<(TimeSpan, string[], int)> prevTask)
	{
		FoundedItems.Clear();
		InputBox.IsReadOnly = false;
		var tuple = prevTask.IsFaulted
			? (TimeSpan.FromSeconds(2), new[] { "... search timeout :(" }, -1)
			: prevTask.Result;
		var timeTaken = (int)tuple.Item1.TotalMilliseconds;
		var foundItems = tuple.Item2;
		var foundItemsCount = tuple.Item3;
		sumMs += timeTaken;
		count++;
		Title = $"Found: {foundItemsCount}; Last time: {timeTaken} ms; Average time: {sumMs / count} ms";
		foreach (var foundItem in foundItems)
			FoundedItems.Add(foundItem);
	}

	private void ValidatePhrases()
	{
		for (var i = 0; i < phrases.Length; i++)
			if (string.Compare(phrases[i], phrases[i + 1], StringComparison.InvariantCultureIgnoreCase) >= 0)
				throw new Exception(phrases[i] + " >= " + phrases[i + 1]);
	}

	private static Phrases? CreatePhrases()
	{
		try
		{
			return PhrasesLoader.CreateFromFiles("dic");
		}
		catch (Exception e)
		{
			return null;
		}
	}
}