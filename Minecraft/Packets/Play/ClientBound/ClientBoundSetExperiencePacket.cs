using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSetExperiencePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_experience";
    
    public required float ExperienceProgress { get; init; } // 0.0 to 1.0
    public required int Level { get; init; }
    public required int TotalExperience { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteFloat(ExperienceProgress)
            .WriteVarInt(Level)
            .WriteVarInt(TotalExperience);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundSetExperiencePacket {
        ExperienceProgress = r.ReadFloat(),
        Level = r.ReadVarInt(),
        TotalExperience = r.ReadVarInt()
    };
}
