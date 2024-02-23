namespace NorthWind.RazorComponents.NavBars;

public partial class NavMenu
{
    [Parameter]
    public RenderFragment NavBarBrand { get; set; }
    [Parameter]
    public RenderFragment NavBarItems { get; set; }

    private bool CollapseNavMenu = true;

    private string NavMenuCssClass => CollapseNavMenu ? "collapse" : null;

    void ToggleNavMenu() => CollapseNavMenu = !CollapseNavMenu;
}