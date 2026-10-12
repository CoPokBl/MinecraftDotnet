using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Reports the result of a game test back to the test instance block's screen.</summary>
public class ClientBoundTestInstanceBlockStatusPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:test_instance_block_status";

    public required TextComponent Status { get; init; }

    /// <summary>Size of the test's bounding box, or null when it has no known size.</summary>
    public Vec3<int>? Size { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteNbt(Status)
            .WritePrefixedOptional(Size, (size, writer) => writer
                .WriteVarInt(size.X)
                .WriteVarInt(size.Y)
                .WriteVarInt(size.Z));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundTestInstanceBlockStatusPacket {
        Status = r.ReadText(),
        Size = r.ReadPrefixedOptionalValue(reader =>
            new Vec3<int>(reader.ReadVarInt(), reader.ReadVarInt(), reader.ReadVarInt()))
    };
}
