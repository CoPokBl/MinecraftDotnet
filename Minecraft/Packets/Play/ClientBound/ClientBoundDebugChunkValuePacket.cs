using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Sends a debug value attached to a chunk, for one of the client's debug overlays.</summary>
public class ClientBoundDebugChunkValuePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:debug/chunk_value";

    public required int ChunkX { get; init; }
    public required int ChunkZ { get; init; }
    public required DebugSubscriptionUpdate Update { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        // Chunk positions travel as the two ints packed into one long, z in the high half.
        return w
            .WriteLong(((long)ChunkZ << 32) | (uint)ChunkX)
            .Write(Update, reg);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => {
        long packed = r.ReadLong();
        return new ClientBoundDebugChunkValuePacket {
            ChunkX = (int)packed,
            ChunkZ = (int)(packed >> 32),
            Update = r.Read<DebugSubscriptionUpdate>(reg)
        };
    };
}
