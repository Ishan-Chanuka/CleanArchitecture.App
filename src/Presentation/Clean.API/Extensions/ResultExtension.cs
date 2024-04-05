using Domain.Exceptions;
using Domain.Primitives;

namespace Clean.API.Extensions
{
    public static class ResultExtension
    {
        public static IResult ToProblemDetails(this Result result)
        {
            if (result.IsSuccess)
            {
                throw new InvalidOperationException("Can't convert success result to problem");
            }

            if (result.Error.Code.EndsWith(nameof(ApiError.NotFound)))
            {
                return Results.Problem(
                statusCode: StatusCodes.Status404NotFound,
                title: "Not Found",
                type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                extensions: new Dictionary<string, object?>
                {
                    { "errors", new[] { result.Error } }
                });
            }

            return Results.Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: "Bad Request",
                type: "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                extensions: new Dictionary<string, object?>
                {
                    { "errors", new[] { result.Error } }
                });
        }
    }
}
