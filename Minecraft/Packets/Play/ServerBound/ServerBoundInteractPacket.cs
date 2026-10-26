using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundInteractPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:interact";

    public required int EntityId { get; init; }
    public required Hand UsedHand { get; init; }

    /// <summary>
    /// Where on the target the player interacted, relative to the target's position.
    /// This is sent in a low precision format, so it won't match the client's value exactly.
    /// </summary>
    public required Vec3<double> Target { get; init; }
    public required bool SneakPressed { get; init; }

    public static ServerBoundInteractPacket Interact(int entityId, Hand hand, bool sneakPressed) {
        return new ServerBoundInteractPacket {
            EntityId = entityId,
            UsedHand = hand,
            Target = new Vec3<double>(0, 0, 0),
            SneakPressed = sneakPressed
        };
    }

    public static ServerBoundInteractPacket InteractAt(int entityId, Vec3<double> target, Hand hand, bool sneakPressed) {
        return new ServerBoundInteractPacket {
            EntityId = entityId,
            UsedHand = hand,
            Target = target,
            SneakPressed = sneakPressed
        };
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(EntityId)
            .WriteVarInt((int)UsedHand)
            .WriteLpVec3(Target)
            .WriteBoolean(SneakPressed);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundInteractPacket {
        EntityId = r.ReadVarInt(),
        UsedHand = (Hand)r.ReadVarInt(),
        Target = r.ReadLpVec3(),
        SneakPressed = r.ReadBoolean()
    };
}
