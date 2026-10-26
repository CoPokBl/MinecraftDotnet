using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetRenderDistancePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_chunk_cache_radius";

    /// <summary>Render distance in chunks.</summary>
    public required int ViewDistance { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(ViewDistance);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetRenderDistancePacket {
        ViewDistance = r.ReadVarInt()
    };
}
