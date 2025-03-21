using System.Text.Json;
using Common;

namespace GuardiansOfTheCode;

public class CardService(HttpClient httpClient) : ICardService
{
    private const string ApiUrl = "https://localhost:7241";
    private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    public async Task<IEnumerable<Card>> GetCards()
    {
        var response = await httpClient.GetAsync($"{ApiUrl}/cards");
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Unable to get cards from {ApiUrl}");
        }

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<Card>>(content, JsonOptions) ?? [];
    }
}
