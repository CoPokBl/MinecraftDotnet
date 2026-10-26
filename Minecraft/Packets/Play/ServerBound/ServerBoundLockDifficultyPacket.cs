using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Only sent by single player worlds opened to LAN; a server ignores it.</summary>
public class ServerBoundLockDifficultyPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:lock_difficulty";

    public required bool Locked { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteBoolean(Locked);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundLockDifficultyPacket {
        Locked = r.ReadBoolean()
    };
}
