using Domain.Primitives;

namespace Domain.Exceptions
{
    public static class ApiError
    {
        public static Error BadRequest(string name, string message) => new($"{name}.BadRequest", $"{message}");
        public static Error NotFound(string name, string message) => new($"{name}.NotFound", $"{message}");
    }
}
