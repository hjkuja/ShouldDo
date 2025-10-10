using LanguageExt.Common;

namespace ShouldDo.Contracts.Exceptions.ValidationExceptions;

public class TodoValidationException(string message, Error[]? errors) : BadRequestException(message, errors)
{
}