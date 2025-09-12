namespace FitFalTracker.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string entityName, params (string keyName,object keyValue)[]keys)
        : base($"Entity {entityName} not found. " +
               $"Keys:{string.Join(", ", keys.Select(x=>$" {x.keyName} id:{x.keyValue}"))}")
    {

    }
}