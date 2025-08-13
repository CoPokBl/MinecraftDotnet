namespace ManagedServer.Commands;

public record CommandContext(
    string RawCommand,
    string CommandName,
    Dictionary<string, object> Arguments) {
    
    public T GetArgument<T>(string name) {
        if (!Arguments.TryGetValue(name, out object? value)) throw new KeyNotFoundException($"Argument '{name}' not found in command context.");
        
        if (value is not T && value != null) {
            throw new InvalidCastException($"Argument '{name}' is not of type {typeof(T).Name}, it's of type {(value == null! ? "null" : value.GetType().Name)}.");
        }
        return (T)value!;
    }
}
