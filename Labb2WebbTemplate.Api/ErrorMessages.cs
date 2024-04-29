using FluentValidation.Results;

namespace Labb2WebbTemplate.Api;

public static class ErrorMessages
{
    public static string NotFound(string key, int value)
    {
        return $"{key} with value:{value} did not return anything";
    }

    public static string WrongEmailOrPassword = "The provided email or password was wrong";

    public static string UnsupportedFileFormat(string imageContentType)
    {
        return $"the file type: {imageContentType} is not supported";
    }
}