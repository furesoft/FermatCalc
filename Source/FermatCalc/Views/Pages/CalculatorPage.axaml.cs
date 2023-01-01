using Avalonia.Controls;
using FermatCalc.ViewModels.Pages;

namespace FermatCalc.Views.Pages;

public partial class CalculatorPage : UserControl
{
    public CalculatorPage()
    {
        InitializeComponent();

        DataContext = new CalculatorPageViewModel();
    }
}