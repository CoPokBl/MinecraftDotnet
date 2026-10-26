using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when an operator saves, loads or detects with a structure block.</summary>
public class ServerBoundProgramStructureBlockPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:set_structure_block";

    private const byte IgnoreEntitiesFlag = 0x01;
    private const byte ShowAirFlag = 0x02;
    private const byte ShowBoundingBoxFlag = 0x04;
    private const byte StrictFlag = 0x08;

    public required Vec3<int> Location { get; init; }
    public required StructureUpdateType UpdateType { get; init; }
    public required StructureBlockMode Mode { get; init; }
    public required string Name { get; init; }

    /// <summary>Corner of the structure relative to the block, each axis from -48 to 48.</summary>
    public required Vec3<int> Offset { get; init; }

    /// <summary>Size of the structure, each axis from 0 to 48.</summary>
    public required Vec3<int> Size { get; init; }

    public required BlockMirror Mirror { get; init; }
    public required BlockRotation Rotation { get; init; }

    /// <summary>Custom data string, only meaningful in data mode.</summary>
    public required string Metadata { get; init; }

    /// <summary>Fraction of the blocks that are placed, from 0 to 1.</summary>
    public required float Integrity { get; init; }

    /// <summary>Seed for the integrity roll, or 0 to pick one at random.</summary>
    public required long Seed { get; init; }

    public required bool IgnoreEntities { get; init; }
    public required bool ShowAir { get; init; }
    public required bool ShowBoundingBox { get; init; }

    /// <summary>Whether loading refuses to place a structure that doesn't fit exactly.</summary>
    public required bool Strict { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        byte flags = 0;
        if (IgnoreEntities) {
            flags |= IgnoreEntitiesFlag;
        }
        if (ShowAir) {
            flags |= ShowAirFlag;
        }
        if (ShowBoundingBox) {
            flags |= ShowBoundingBoxFlag;
        }
        if (Strict) {
            flags |= StrictFlag;
        }

        return w
            .WritePosition(Location)
            .WriteVarInt((int)UpdateType)
            .WriteVarInt((int)Mode)
            .WriteString(Name)
            .WriteByte(Offset.X)
            .WriteByte(Offset.Y)
            .WriteByte(Offset.Z)
            .WriteByte(Size.X)
            .WriteByte(Size.Y)
            .WriteByte(Size.Z)
            .WriteVarInt((int)Mirror)
            .WriteVarInt((int)Rotation)
            .WriteString(Metadata)
            .WriteFloat(Integrity)
            .WriteVarLong(Seed)
            .WriteUnsignedByte(flags);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        Vec3<int> location = r.ReadPosition();
        StructureUpdateType updateType = (StructureUpdateType)r.ReadVarInt();
        StructureBlockMode mode = (StructureBlockMode)r.ReadVarInt();
        string name = r.ReadString();
        Vec3<int> offset = new(r.ReadByte(), r.ReadByte(), r.ReadByte());
        Vec3<int> size = new(r.ReadByte(), r.ReadByte(), r.ReadByte());
        BlockMirror mirror = (BlockMirror)r.ReadVarInt();
        BlockRotation rotation = (BlockRotation)r.ReadVarInt();
        string metadata = r.ReadString();
        float integrity = r.ReadFloat();
        long seed = r.ReadVarLong();
        byte flags = (byte)r.Read();

        return new ServerBoundProgramStructureBlockPacket {
            Location = location,
            UpdateType = updateType,
            Mode = mode,
            Name = name,
            Offset = offset,
            Size = size,
            Mirror = mirror,
            Rotation = rotation,
            Metadata = metadata,
            Integrity = integrity,
            Seed = seed,
            IgnoreEntities = (flags & IgnoreEntitiesFlag) != 0,
            ShowAir = (flags & ShowAirFlag) != 0,
            ShowBoundingBox = (flags & ShowBoundingBoxFlag) != 0,
            Strict = (flags & StrictFlag) != 0
        };
    };

    public enum StructureUpdateType {
        UpdateData = 0,
        SaveArea = 1,
        LoadArea = 2,
        ScanArea = 3
    }

    public enum StructureBlockMode {
        Save = 0,
        Load = 1,
        Corner = 2,
        Data = 3
    }
}
