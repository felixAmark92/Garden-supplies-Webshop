namespace Labb2WebbTemplate.Shared.Dtos.ErrorsDto;

public record ErrorDto(
    int StatusCode,
    string Message,
    Errors Errors
);
public record Errors(string[] GeneralErrors);