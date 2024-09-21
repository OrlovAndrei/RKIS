using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using RefactorMe.Common;

namespace RefactorMe.UI;

public partial class MainWindow : Window
{
	private int time;
	private Canvas canvas;
	private readonly DispatcherTimer timer;
	private readonly CanvasGraphics canvasGraphics;

	public MainWindow()
	{
		InitializeComponent();

		canvasGraphics = new CanvasGraphics(canvas);
		Width = WindowSettings.Width;
		Height = WindowSettings.Height;

		timer = new DispatcherTimer
		{
			Interval = TimeSpan.FromMilliseconds(50)
		};
		timer.Tick += (_, _) => TimerTick();

		canvas.Tapped += (_, _) =>
		{
			if (timer.IsEnabled)
				timer.Stop();
			else
				timer.Start();
		};

		Opened += (_, __) => Draw();

		CanResize = false;
	}

	private void TimerTick()
	{
		time++;
		Draw();
	}

	private void Draw()
	{
		var angularVelocity = Math.PI / 8;
		var angle = angularVelocity * (time * timer.Interval.Milliseconds / 1000d);
		ImpossibleSquare.Draw((int)Width, (int)Height, angle, canvasGraphics);
		InvalidateVisual();
	}

	public void InitializeComponent()
	{
		AvaloniaXamlLoader.Load(this);
		canvas = this.FindControl<Canvas>("Canvas");
	}
}