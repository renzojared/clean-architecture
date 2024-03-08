namespace NorthWind.Sales.Frontend.Views.Pages;
public partial class CreateOrder
{
    [Inject]
    CreateOrderViewModel ViewModel { get; set; }

    ErrorBoundary ErrorBoundaryRef;

    void Recover()
    {
        ErrorBoundaryRef?.Recover();
    }
}