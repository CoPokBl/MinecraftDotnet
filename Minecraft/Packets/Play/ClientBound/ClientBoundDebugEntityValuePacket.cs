using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Sends a debug value attached to an entity, for one of the client's debug overlays.</summary>
public class ClientBoundDebugEntityValuePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:debug/entity_value";

    public required int EntityId { get; init; }
    public required DebugSubscriptionUpdate Update { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteVarInt(EntityId)
            .Write(Update, reg);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundDebugEntityValuePacket {
        EntityId = r.ReadVarInt(),
        Update = r.Read<DebugSubscriptionUpdate>(reg)
    };
}
