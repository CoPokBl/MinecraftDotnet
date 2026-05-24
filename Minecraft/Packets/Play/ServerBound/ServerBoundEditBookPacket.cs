using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundEditBookPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:edit_book";

    public required int Slot { get; init; }
    public required string[] Entries { get; init; }
    public required string? Title { get; init; }

    protected override DataWriter WriteData(DataWriter w) {

        return w.WriteVarInt(Slot)
            .WritePrefixedArray(Entries, (s, w) => w.WriteString(s))
            .WritePrefixedOptional(Title, (s, w) => w.WriteString(s));

    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        int slot = r.ReadVarInt();
        string[] entries = r.ReadPrefixedArray(r2 => r2.ReadString());
        string? title = r.ReadPrefixedOptional(re => re.ReadString());
        return new ServerBoundEditBookPacket {
            Slot = slot,
            Entries = entries,
            Title = title
        };
    };
}

