using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using FermatCalc.ViewModels;
using FermatCalc.ViewModels.Pages;

namespace FermatCalc.Views.Pages;

public partial class CalculatorPage : UserControl
{
    public CalculatorPage()
    {
        InitializeComponent();

        DataContext = new CalculatorPageViewModel();
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        ((ViewModelBase)DataContext).OnLoad();

        base.OnApplyTemplate(e);
    }
}