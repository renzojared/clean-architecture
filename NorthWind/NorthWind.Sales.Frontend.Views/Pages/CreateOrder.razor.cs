using NorthWind.Sales.Frontend.Views.ViewModels.CreateOrder;

namespace NorthWind.Sales.Frontend.Views.Pages;

public partial class CreateOrder
{
    [Inject]
    private CreateOrderViewModel ViewModel { get; set; }

    private ErrorBoundary ErrorBoundaryRef;

    void Recover()
    {
        ErrorBoundaryRef?.Recover();
    }
}