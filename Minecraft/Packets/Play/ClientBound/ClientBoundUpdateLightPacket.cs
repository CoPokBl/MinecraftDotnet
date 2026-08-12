using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Updates the light in a chunk that the client already has. Chunks sent for the first time carry
/// their light in <see cref="ClientBoundChunkDataAndUpdateLightPacket"/> instead.
/// </summary>
public class ClientBoundUpdateLightPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:light_update";

    public required int ChunkX { get; init; }
    public required int ChunkZ { get; init; }
    public required LightData Light { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(ChunkX)
            .WriteVarInt(ChunkZ)
            .Write(Light);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundUpdateLightPacket {
        ChunkX = r.ReadVarInt(),
        ChunkZ = r.ReadVarInt(),
        Light = LightData.Read(r)
    };
}
