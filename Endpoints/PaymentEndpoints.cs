using Payment.Api.Dtos;
using Payment.Api.Helpers;

namespace Payment.Api.Endpoints;

public static class PaymentEndpoints
{
    public static RouteGroupBuilder MapPaymentEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("payments")
                       .WithParameterValidation();

        // POST /cards/validate
        group.MapPost("/cards/validate", (CardDto card) =>
        {
            Console.WriteLine(card);
            return Results.Ok(LuhnAlgorithm.Validate(card.CardNumber));
        });


        return group;
    }
}
