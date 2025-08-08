namespace ManagedServer.Commands;

public record CommandContext(
    string RawCommand,
    string CommandName,
    Dictionary<string, string> RawArguments);
