namespace Domain.Exceptions
{
    public sealed class NotFoundException(string name, object key) : Exception($"{name} ({key}) was not found.")
    {
    }
}
