using System;
using System.IO;
using System.Linq;
using Avalonia;

namespace Names.UI;

public static class Program
{
	private static readonly string dataFilePath = "names.txt";


	[STAThread]
	public static void Main(string[] args)
	{
		BuildAvaloniaApp()
			.StartWithClassicDesktopLifetime(args);
	}

	public static AppBuilder BuildAvaloniaApp()
		=> AppBuilder.Configure<App>()
			.UsePlatformDetect()
			.LogToTrace();

	public static void ShowPlots()
	{
		var namesData = ReadData();
		Charts.ShowHeatmap(HeatmapTask.GetBirthsPerDateHeatmap(namesData), "Тепловая карта рождаемости в течение года");
		Charts.ShowHistogram(HistogramTask.GetBirthsPerDayHistogram(namesData, "юрий"),
			"Рождаемость людей с именем Юрий");
		Charts.ShowHistogram(HistogramTask.GetBirthsPerDayHistogram(namesData, "владимир"),
			"Рождаемость людей с именем Владимир");
		//CreativityTask.ShowYourStatistics(namesData);
	}


	private static NameData[] ReadData()
	{
		var lines = File.ReadAllLines(dataFilePath);
		var names = new NameData[lines.Length];
		for (var i = 0; i < lines.Length; i++)
			names[i] = NameData.ParseFrom(lines[i]);
		return names;
	}

	// А это более короткая версия ReadData(). Она использует механизм языка под названием Linq
	// Вы можете познакомиться с ней самостоятельно: https://ulearn.azurewebsites.net/Course/Linq
	// Освоив LINQ решать задачи подобные NamesTask становится гораздо проще и приятнее.
	// Но это уже совсем другая история.
	private static NameData[] ReadData2()
	{
		return File
			.ReadLines(dataFilePath)
			.Select(NameData.ParseFrom)
			.ToArray();
	}
}