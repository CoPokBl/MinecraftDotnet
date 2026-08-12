using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Advancements;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Adds, removes and updates the progress of the player's advancements.</summary>
public class ClientBoundUpdateAdvancementsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:update_advancements";

    /// <summary>Whether the client should throw away the advancements it already has.</summary>
    public required bool Reset { get; init; }

    public Dictionary<Identifier, Advancement> Added { get; init; } = [];

    public Identifier[] Removed { get; init; } = [];

    /// <summary>Progress per advancement, keyed by criterion name within each one.</summary>
    public Dictionary<Identifier, Dictionary<string, DateTimeOffset?>> Progress { get; init; } = [];

    /// <summary>Whether the advancement screen is reachable at all.</summary>
    public required bool ShowAdvancements { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        w.WriteBoolean(Reset)
            .WriteVarInt(Added.Count);
        foreach ((Identifier id, Advancement advancement) in Added) {
            w.Write(id).Write(advancement, reg);
        }

        w.WritePrefixedArray(Removed, (id, writer) => writer.Write(id))
            .WriteVarInt(Progress.Count);
        foreach ((Identifier id, Dictionary<string, DateTimeOffset?> criteria) in Progress) {
            w.Write(id).WriteVarInt(criteria.Count);
            foreach ((string name, DateTimeOffset? obtained) in criteria) {
                w.WriteString(name)
                    .WritePrefixedOptional(obtained, (time, writer) => writer.WriteLong(time.ToUnixTimeMilliseconds()));
            }
        }

        return w.WriteBoolean(ShowAdvancements);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => {
        bool reset = r.ReadBoolean();

        int addedCount = r.ReadVarInt();
        Dictionary<Identifier, Advancement> added = new(addedCount);
        for (int i = 0; i < addedCount; i++) {
            Identifier id = r.ReadString();
            added.Add(id, r.Read<Advancement>(reg));
        }

        Identifier[] removed = r.ReadPrefixedArray<Identifier>(reader => reader.ReadString());

        int progressCount = r.ReadVarInt();
        Dictionary<Identifier, Dictionary<string, DateTimeOffset?>> progress = new(progressCount);
        for (int i = 0; i < progressCount; i++) {
            Identifier id = r.ReadString();
            int criteriaCount = r.ReadVarInt();
            Dictionary<string, DateTimeOffset?> criteria = new(criteriaCount);
            for (int j = 0; j < criteriaCount; j++) {
                string name = r.ReadString();
                criteria.Add(name, r.ReadPrefixedOptional<DateTimeOffset>(
                    reader => DateTimeOffset.FromUnixTimeMilliseconds(reader.ReadLong())));
            }
            progress.Add(id, criteria);
        }

        return new ClientBoundUpdateAdvancementsPacket {
            Reset = reset,
            Added = added,
            Removed = removed,
            Progress = progress,
            ShowAdvancements = r.ReadBoolean()
        };
    };
}
