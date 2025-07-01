using Minecraft.Schemas;

namespace Minecraft.Implementations.Exceptions;

public class ConnectionStateException(ConnectionState[] expected, ConnectionState reality, string msg = "Invalid connection state") : Exception {
    public override string Message => $"{msg} (Expected: {expected}, Reality: {reality})";

    public ConnectionStateException(ConnectionState expected, ConnectionState reality,
        string msg = "Invalid connection state")
        : this([expected], reality, msg) {
    }
}
