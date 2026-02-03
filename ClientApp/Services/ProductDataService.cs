using Shared.Models;
using System.Net.Http.Json;

public class ProductDataService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

public async Task<List<Product>> GetProductsAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/products") ?? new List<Product>();
        } catch (Exception ex)
        {
            Console.WriteLine($"Error fetching products: {ex.Message}");
            return new List<Product>();
        }
    }
}