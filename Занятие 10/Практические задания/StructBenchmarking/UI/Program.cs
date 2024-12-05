using System;
using Avalonia;

namespace StructBenchmarking.UI;

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
}