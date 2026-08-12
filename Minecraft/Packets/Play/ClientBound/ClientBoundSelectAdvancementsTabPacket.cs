using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSelectAdvancementsTabPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:select_advancements_tab";

    /// <summary>The advancement tab to open, or null to close the screen.</summary>
    public Identifier? Tab { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WritePrefixedOptional(Tab, (tab, writer) => writer.Write(tab));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSelectAdvancementsTabPacket {
        Tab = r.ReadPrefixedOptional<Identifier>(reader => reader.ReadString())
    };
}
