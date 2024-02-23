var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddNorthWindSalesServices(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["WebApiAddress"]);
    //Polly
    //Security here
});

await builder.Build().RunAsync();