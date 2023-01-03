using Avalonia.Controls;
using FermatCalc.ViewModels;
using FermatCalc.ViewModels.Pages;

namespace FermatCalc.Views.Pages;

public partial class CalculatorPage : UserControl
{
    public CalculatorPage()
    {
        InitializeComponent();

        DataContext = new CalculatorPageViewModel();
        ((ViewModelBase)DataContext).OnLoad();
    }
}