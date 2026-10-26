using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Sends the server's MOTD and icon so the client can add it to its server list.</summary>
public class ClientBoundServerDataPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:server_data";

    public required TextComponent Motd { get; init; }

    /// <summary>The raw bytes of a PNG icon, or null when the server has none.</summary>
    public byte[]? Icon { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteNbt(Motd)
            .WritePrefixedOptional(Icon, (icon, writer) => writer.WriteVarInt(icon.Length).Write(icon));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundServerDataPacket {
        Motd = r.ReadText(),
        Icon = r.ReadPrefixedOptional(reader => reader.Read(reader.ReadVarInt()))
    };
}
