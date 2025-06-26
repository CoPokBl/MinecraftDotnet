namespace Minecraft.Schemas;

public enum ConnectionState {
    None,  // before handshake
    Status,
    Login,
    Configuration,
    Play
}
