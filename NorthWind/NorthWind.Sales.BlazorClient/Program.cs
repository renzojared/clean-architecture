using NorthWind.Membership.Frontend.RazorViews;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddNorthWindSalesServices(
    client =>
    {
        client.BaseAddress = new Uri(builder.Configuration["WebApiAddress"]);
        //Polly
        //Security here
    },
    clientMembership =>
    {
        clientMembership.BaseAddress = new Uri(builder.Configuration["WebApiAddress"]);
    },
    httpClientBuilder => httpClientBuilder.AddMembershipBearerTokenHandler());

await builder.Build().RunAsync();