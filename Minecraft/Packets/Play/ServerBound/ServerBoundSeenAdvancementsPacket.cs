using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Tells the server which advancement tab the player is looking at.</summary>
public class ServerBoundSeenAdvancementsPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:seen_advancements";

    public required AdvancementAction Action { get; init; }

    /// <summary>The tab that was opened. Only sent with <see cref="AdvancementAction.OpenedTab"/>.</summary>
    public Identifier? Tab { get; init; }

    public static ServerBoundSeenAdvancementsPacket OpenedTab(Identifier tab) {
        return new ServerBoundSeenAdvancementsPacket { Action = AdvancementAction.OpenedTab, Tab = tab };
    }

    public static ServerBoundSeenAdvancementsPacket ClosedScreen() {
        return new ServerBoundSeenAdvancementsPacket { Action = AdvancementAction.ClosedScreen };
    }

    protected override DataWriter WriteData(DataWriter w) {
        w.WriteVarInt((int)Action);
        if (Action == AdvancementAction.OpenedTab) {
            w.Write(Tab.ThrowIfNull());
        }
        return w;
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => {
        AdvancementAction action = (AdvancementAction)r.ReadVarInt();
        return new ServerBoundSeenAdvancementsPacket {
            Action = action,
            Tab = action == AdvancementAction.OpenedTab ? (Identifier)r.ReadString() : null
        };
    };

    public enum AdvancementAction {
        OpenedTab = 0,
        ClosedScreen = 1
    }
}
