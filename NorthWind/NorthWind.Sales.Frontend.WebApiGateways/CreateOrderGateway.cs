namespace NorthWind.Sales.Frontend.WebApiGateways;

internal class CreateOrderGateway(HttpClient client) : ICreateOrderGateway
{
    public async Task<int> CreateOrderAsyc(CreateOrderDto orderDto)
    {
        int orderId = 0;

        var response = await client.PostAsJsonAsync(Endpoints.CreateOrder, orderDto);

        if (response.IsSuccessStatusCode)
            orderId = await response.Content.ReadFromJsonAsync<int>();

        return orderId;
    }
}