namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetExperiencePacket : ClientBoundPacket {
    public required float ExperienceProgress; // 0.0 to 1.0
    public required int Level;
    public required int TotalExperience;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteFloat(ExperienceProgress)
            .WriteVarInt(Level)
            .WriteVarInt(TotalExperience)
            .ToArray();
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetExperiencePacket {
        ExperienceProgress = r.ReadFloat(),
        Level = r.ReadVarInt(),
        TotalExperience = r.ReadVarInt()
    };
}
