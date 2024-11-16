using Avalonia.Controls;

namespace HotelAccounting.UI;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		DataContext = new AccountingModel();
		InitializeComponent();
	}
}