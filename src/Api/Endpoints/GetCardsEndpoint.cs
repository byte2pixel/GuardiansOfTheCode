using Api.Services;
using Common;
using FastEndpoints;

namespace Api.Endpoints;

public class GetCardsEndpoint(ICardService cardService) : EndpointWithoutRequest<IEnumerable<Card>>
{
    public override void Configure()
    {
        Get("/cards");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(cardService.GetCards(), 200, ct);
    }
}
