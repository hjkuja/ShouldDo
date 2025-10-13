using LanguageExt.Common;
using ShouldDo.Contracts.Exceptions;

namespace ShouldDo.Api;

public static class ApiResults
{
    /// <summary>
    /// Converts the specified <see cref="Exception"/> to an HTTP problem result.
    /// </summary>
    /// <remarks>This method extracts relevant information from a <see cref="CustomException"/> to create a
    /// standardized HTTP problem response. The response includes the exception's title, message, status code, type, and
    /// any additional error details.</remarks>
    /// <param name="e">The exception to convert. Must be of type <see cref="CustomException"/>.</param>
    /// <returns>An <see cref="IResult"/> representing the HTTP problem result, including details from the <see
    /// cref="CustomException"/>.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the provided exception is not of type <see cref="CustomException"/>.</exception>
    public static IResult ToProblemResult(this Exception e)
    {
        if (e is not CustomException ex)
        {
            throw new InvalidOperationException("Only custom errors can be converted to problem results!");
        }

        return Microsoft.AspNetCore.Http.Results.Problem(
            title: ex.GetTitle(),
            detail: ex.Message,
            statusCode: ex.StatusCode,
            type: ex.Type,
            extensions: new Dictionary<string, object?> { {"errors", ex.Errors} });

    }

    private static string GetTitle(this CustomException ex)
    {
        return ex switch
        {
            BadRequestException => "Bad request",
            _ => "Internal server error",
        };
    }
}
