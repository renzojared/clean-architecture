namespace NorthWind.Sales.Frontend.WebApiGateways;

internal class CreateOrderGateway(HttpClient client) : ICreateOrderGateway
{
    public async Task<int> CreateOrderAsync(CreateOrderDto orderDto)
    {
        var orderId = 0;

        var response = await client.PostAsJsonAsync(Endpoints.CreateOrder, orderDto);

        if (response.IsSuccessStatusCode)
            orderId = await response.Content.ReadFromJsonAsync<int>();
        else
            throw new HttpRequestException(await response.Content.ReadAsStringAsync());

        return orderId;
    }
}