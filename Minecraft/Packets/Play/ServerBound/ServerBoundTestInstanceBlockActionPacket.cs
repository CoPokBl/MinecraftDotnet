using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when an operator uses one of the buttons on a test instance block.</summary>
public class ServerBoundTestInstanceBlockActionPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:test_instance_block_action";

    public required Vec3<int> Location { get; init; }
    public required TestInstanceAction Action { get; init; }

    /// <summary>The test instance to run, or null when the block has none selected.</summary>
    public Identifier? Test { get; init; }

    /// <summary>Size of the area the test runs in.</summary>
    public required Vec3<int> Size { get; init; }

    public required BlockRotation Rotation { get; init; }

    /// <summary>Whether entities inside the area are left out of the test.</summary>
    public required bool IgnoreEntities { get; init; }

    public required TestInstanceStatus Status { get; init; }

    /// <summary>Why the test failed, when it has.</summary>
    public TextComponent? ErrorMessage { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WritePosition(Location)
            .WriteVarInt((int)Action)
            .WritePrefixedOptional(Test, (test, writer) => writer.Write(test))
            .WriteVarInt(Size.X)
            .WriteVarInt(Size.Y)
            .WriteVarInt(Size.Z)
            .WriteVarInt((int)Rotation)
            .WriteBoolean(IgnoreEntities)
            .WriteVarInt((int)Status)
            .WritePrefixedOptional(ErrorMessage, (message, writer) => writer.WriteNbt(message));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundTestInstanceBlockActionPacket {
        Location = r.ReadPosition(),
        Action = (TestInstanceAction)r.ReadVarInt(),
        Test = r.ReadPrefixedOptionalValue<Identifier>(reader => reader.ReadString()),
        Size = new Vec3<int>(r.ReadVarInt(), r.ReadVarInt(), r.ReadVarInt()),
        Rotation = (BlockRotation)r.ReadVarInt(),
        IgnoreEntities = r.ReadBoolean(),
        Status = (TestInstanceStatus)r.ReadVarInt(),
        ErrorMessage = r.ReadPrefixedOptional(reader => reader.ReadText())
    };

    public enum TestInstanceAction {
        Init = 0,
        Query = 1,
        Set = 2,
        Reset = 3,
        Save = 4,
        Export = 5,
        Run = 6
    }

    public enum TestInstanceStatus {
        Cleared = 0,
        Running = 1,
        Finished = 2
    }
}
