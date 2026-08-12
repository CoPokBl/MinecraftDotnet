using Minecraft.Data.MapDecorationTypes;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Updates a filled map: its markers, and a rectangular patch of its pixels. Either part can be
/// left out when only the other changed.
/// </summary>
public class ClientBoundMapDataPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:map_item_data";

    public required int MapId { get; init; }

    /// <summary>Zoom level, from 0 (1 block per pixel) to 4 (16 blocks per pixel).</summary>
    public required byte Scale { get; init; }

    /// <summary>Whether the map has been locked in a cartography table.</summary>
    public required bool Locked { get; init; }

    /// <summary>The markers on the map, or null to leave the existing ones alone.</summary>
    public Decoration[]? Decorations { get; init; }

    /// <summary>The changed pixels, or null when only the decorations changed.</summary>
    public ColorPatch? Patch { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        w.WriteVarInt(MapId)
            .WriteUnsignedByte(Scale)
            .WriteBoolean(Locked)
            .WritePrefixedOptional(Decorations, (decorations, writer) =>
                writer.WritePrefixedArray(decorations, (decoration, dw) => dw
                    .WriteVarInt(reg.MapDecorationTypes.GetProtocolId(decoration.Type))
                    .WriteByte(decoration.X)
                    .WriteByte(decoration.Z)
                    .WriteUnsignedByte((byte)(decoration.Rotation & 15))
                    .WritePrefixedOptional(decoration.Name, (name, nw) => nw.WriteNbt(name))));

        // A patch is marked absent by a zero width rather than by a boolean, so a zero width
        // patch has to go out the same way: it covers no pixels either.
        if (Patch == null || Patch.Width == 0) {
            return w.WriteUnsignedByte(0);
        }

        return w
            .WriteUnsignedByte(Patch.Width)
            .WriteUnsignedByte(Patch.Height)
            .WriteUnsignedByte(Patch.StartX)
            .WriteUnsignedByte(Patch.StartZ)
            .WriteVarInt(Patch.Colors.Length)
            .Write(Patch.Colors);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => {
        int mapId = r.ReadVarInt();
        byte scale = (byte)r.Read();
        bool locked = r.ReadBoolean();
        Decoration[]? decorations = r.ReadPrefixedOptional(reader =>
            reader.ReadPrefixedArray(dr => new Decoration(
                reg.MapDecorationTypes[dr.ReadVarInt()],
                dr.ReadByte(),
                dr.ReadByte(),
                (byte)dr.Read(),
                dr.ReadPrefixedOptional(nr => nr.ReadText()))));

        byte width = (byte)r.Read();
        ColorPatch? patch = null;
        if (width > 0) {
            byte height = (byte)r.Read();
            byte startX = (byte)r.Read();
            byte startZ = (byte)r.Read();
            patch = new ColorPatch(startX, startZ, width, height, r.Read(r.ReadVarInt()));
        }

        return new ClientBoundMapDataPacket {
            MapId = mapId,
            Scale = scale,
            Locked = locked,
            Decorations = decorations,
            Patch = patch
        };
    };

    /// <param name="Type">Which marker sprite to draw.</param>
    /// <param name="X">Horizontal position on the map, from -128 to 127.</param>
    /// <param name="Z">Vertical position on the map, from -128 to 127.</param>
    /// <param name="Rotation">Direction the marker points, in sixteenths of a turn.</param>
    /// <param name="Name">Label drawn under the marker, if any.</param>
    public record Decoration(
        IMapDecorationType Type,
        sbyte X,
        sbyte Z,
        byte Rotation,
        TextComponent? Name = null);

    /// <param name="StartX">Left edge of the changed area.</param>
    /// <param name="StartZ">Top edge of the changed area.</param>
    /// <param name="Width">Width of the changed area.</param>
    /// <param name="Height">Height of the changed area.</param>
    /// <param name="Colors">One map colour index per pixel, in rows.</param>
    public record ColorPatch(byte StartX, byte StartZ, byte Width, byte Height, byte[] Colors);
}
