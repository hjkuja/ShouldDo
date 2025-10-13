using LanguageExt.Common;
using System.Net;

namespace ShouldDo.Contracts.Exceptions;

public class CustomException(string message, Error[]? errors, int? statusCode = null, string? type = null) : Exception(message)
{
    public Error[] Errors { get; } = errors ?? [];
    public int StatusCode { get; } = statusCode ?? (int)HttpStatusCode.InternalServerError;
    public string Type { get; } = type ?? "https://www.rfc-editor.org/rfc/rfc7231#section-6.6.1";
}
