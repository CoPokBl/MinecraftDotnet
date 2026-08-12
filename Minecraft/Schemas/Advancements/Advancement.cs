using Minecraft.Data;
using Minecraft.Registry;

namespace Minecraft.Schemas.Advancements;

/// <summary>
/// One node of the advancement tree as the client needs it. The criteria themselves stay on the
/// server; the client only learns their names, through <see cref="Requirements"/>.
/// </summary>
public class Advancement : INetworkType<Advancement> {
    /// <summary>The advancement this one hangs off, or null when it is the root of a tab.</summary>
    public Identifier? Parent { get; init; }

    /// <summary>How the advancement is drawn, or null when it is invisible scaffolding.</summary>
    public AdvancementDisplay? Display { get; init; }

    /// <summary>
    /// Criteria names grouped into an and-of-ors: every group has to have one of its names
    /// completed for the advancement to be granted.
    /// </summary>
    public string[][] Requirements { get; init; } = [];

    public bool SendsTelemetryEvent { get; init; }

    public DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WritePrefixedOptional(Parent, (parent, writer) => writer.Write(parent))
            .WritePrefixedOptional(Display, (display, writer) => display.Write(writer, reg))
            .WritePrefixedArray(Requirements, (group, writer) =>
                writer.WritePrefixedArray(group, (name, nw) => nw.WriteString(name)))
            .WriteBoolean(SendsTelemetryEvent);
    }

    public static Advancement ReadData(DataReader r, MinecraftRegistry reg) {
        return new Advancement {
            Parent = r.ReadPrefixedOptional<Identifier>(reader => reader.ReadString()),
            Display = r.ReadPrefixedOptional(reader => AdvancementDisplay.Read(reader, reg)),
            Requirements = r.ReadPrefixedArray(reader =>
                reader.ReadPrefixedArray(gr => gr.ReadString())),
            SendsTelemetryEvent = r.ReadBoolean()
        };
    }
}
