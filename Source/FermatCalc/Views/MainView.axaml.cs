using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Material.Styles.Controls;

namespace FermatCalc.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        this.FindControl<Carousel>("PageCarousel").SelectionChanged += CalculatorPage_SelectionChanged;
        base.OnApplyTemplate(e);
    }

    private void CalculatorPage_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        this.FindControl<NavigationDrawer>("drawer").LeftDrawerOpened = false;
    }
}