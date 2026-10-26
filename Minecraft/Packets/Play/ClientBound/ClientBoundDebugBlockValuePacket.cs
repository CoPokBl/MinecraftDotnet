using Minecraft.Data.DebugSubscriptions;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Sends a debug value attached to a block, for one of the client's debug overlays.</summary>
public class ClientBoundDebugBlockValuePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:debug/block_value";

    public required Vec3<int> Location { get; init; }
    public required DebugSubscriptionUpdate Update { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WritePosition(Location)
            .Write(Update, reg);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundDebugBlockValuePacket {
        Location = r.ReadPosition(),
        Update = r.Read<DebugSubscriptionUpdate>(reg)
    };
}
