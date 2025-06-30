namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundChangeDifficultyPacket : ClientBoundPacket {
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
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundChangeDifficultyPacket {
        Difficulty = (DifficultySetting)r.Read(),
        Locked = r.ReadBoolean()
    };
}
