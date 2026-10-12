using Minecraft.Schemas;

namespace ClientLib;

public record GameProfile(string Username, Guid Uuid) {
    public ProfileProperty[] Properties { get; init; } = [];
}
