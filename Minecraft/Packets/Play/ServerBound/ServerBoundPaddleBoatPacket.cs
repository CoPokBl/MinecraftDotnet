using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Tells the server which oars are turning, so other players see the animation.</summary>
public class ServerBoundPaddleBoatPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:paddle_boat";

    public required bool LeftPaddleTurning { get; init; }
    public required bool RightPaddleTurning { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteBoolean(LeftPaddleTurning)
            .WriteBoolean(RightPaddleTurning);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPaddleBoatPacket {
        LeftPaddleTurning = r.ReadBoolean(),
        RightPaddleTurning = r.ReadBoolean()
    };
}
