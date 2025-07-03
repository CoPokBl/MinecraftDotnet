using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundChangeDifficultyPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:change_difficulty";
    
    public required DifficultySetting Difficulty;
    public required bool Locked;
    
    public enum DifficultySetting {
        Peaceful = 0,
        Easy = 1,
        Normal = 2,
        Hard = 3
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .Write((byte)Difficulty)
            .WriteBoolean(Locked)
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundChangeDifficultyPacket {
        Difficulty = (DifficultySetting)r.Read(),
        Locked = r.ReadBoolean()
    };
}
