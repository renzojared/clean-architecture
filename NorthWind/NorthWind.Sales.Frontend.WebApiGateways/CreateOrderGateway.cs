namespace NorthWind.Sales.Frontend.WebApiGateways;

internal class CreateOrderGateway(HttpClient client) : ICreateOrderGateway
{
    public async Task<int> CreateOrderAsync(CreateOrderDto orderDto)
    {
        var response = await client.PostAsJsonAsync(Endpoints.CreateOrder, orderDto);

        return await response.Content.ReadFromJsonAsync<int>();
    }
}