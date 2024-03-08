using System.ComponentModel.DataAnnotations;

namespace Payment.Api.Dtos;

public record class CardDto(
    [Required][StringLength(16)] string CardNumber
);