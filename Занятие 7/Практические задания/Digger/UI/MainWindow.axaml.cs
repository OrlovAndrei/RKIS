using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Digger.Architecture;

namespace Digger.UI;

public partial class MainWindow : Window
{
	private readonly HashSet<Key> pressedKeys = new();

	public MainWindow()
	{
		ClientSize = new Size(Game.MapWidth * GameState.ElementSize, 
			(Game.MapHeight + 1) * GameState.ElementSize);
		InitializeComponent();
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		pressedKeys.Add(e.Key);
		Game.KeyPressed = e.Key;
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		pressedKeys.Remove(e.Key);
		Game.KeyPressed = pressedKeys.Any() ? pressedKeys.Min() : Key.None;
	}
}