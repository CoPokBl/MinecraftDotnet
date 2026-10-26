using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundStopSoundPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:stop_sound";

    /// <summary>Only sounds of this category; every category when null.</summary>
    public SoundCategory? Category { get; init; }

    /// <summary>Only this sound event; every sound when null.</summary>
    public Identifier? Sound { get; init; }
    
    protected override DataWriter WriteData(DataWriter w) {
        return w.Write((byte)((Category.HasValue ? 0x01 : 0x00) | (Sound.HasValue ? 0x02 : 0x00)))
                 .WriteIfPresent(Category, (v, wr) => wr.WriteVarInt((int)v))
                 .WriteIfPresent(Sound, (v, wr) => wr.WriteString(v));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => {
        byte flags = r.Read();
        
        SoundCategory? category = (flags & 0x01) != 0 ? (SoundCategory)r.ReadVarInt() : null;
        Identifier? sound = (flags & 0x02) != 0 ? (Identifier?)r.Read<Identifier>(reg) : null;
        return new ClientBoundStopSoundPacket {
            Category = category,
            Sound = sound
        };
    };
}
