using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>An entity started a swing, with the animation it swings with.</summary>
public class ClientBoundSwingAnimationPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:swing_animation";

    public required int EntityId { get; init; }
    public required Hand Hand { get; init; }
    public required SwingAnimation Animation { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return Animation.WriteData(w
            .WriteVarInt(EntityId)
            .WriteVarInt((int)Hand));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSwingAnimationPacket {
        EntityId = r.ReadVarInt(),
        Hand = (Hand)r.ReadVarInt(),
        Animation = SwingAnimation.ReadData(r)
    };
}
