using LanguageExt.Common;

namespace ShouldDo.Contracts.Exceptions;

public class BadRequestException(string message, Error[]? errors) : Exception(message)
{
    public Error[] Errors { get; } = errors ?? [];
}