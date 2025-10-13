using LanguageExt.Common;
using System.Net;

namespace ShouldDo.Contracts.Exceptions;

public class BadRequestException(string message, Error[]? errors) : 
    CustomException(message, errors, (int)HttpStatusCode.BadRequest, "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1")
{
}