namespace Minecraft.Schemas;

public enum PlayerConnectionState {
    None,  // before handshake
    Status,
    Login,
    Configuration,
    Play
}