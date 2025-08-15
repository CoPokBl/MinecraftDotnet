using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundStopSoundPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:stop_sound";

    public int? SourceEntityId { get; init; }
    public Identifier? Sound { get; init; }
    
    protected override DataWriter WriteData(DataWriter w) {
        return w.Write((byte)((SourceEntityId.HasValue ? 0x01 : 0x00) | (Sound.HasValue ? 0x02 : 0x00)))
                 .WriteIfPresent(SourceEntityId, (v, wr) => wr.WriteVarInt(v))
                 .WriteIfPresent(Sound, (v, wr) => wr.WriteString(v));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => {
        byte flags = r.Read();
        
        int? sourceEntityId = (flags & 0x01) != 0 ? r.ReadVarInt() : null;
        Identifier? sound = (flags & 0x02) != 0 ? r.Read<Identifier>(reg) : null!;
        return new ClientBoundStopSoundPacket {
            SourceEntityId = sourceEntityId,
            Sound = sound
        };
    };
}
