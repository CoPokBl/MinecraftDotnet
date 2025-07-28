using System.Diagnostics.CodeAnalysis;
using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Vec;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSoundEffectPacket() : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:sound";

    /// <summary>
    /// The numerical sound ID. This value is ignored if <see cref="Event"/> is not null.
    /// This should be the actually sound ID, it is encoded (has 1 added to it) automatically
    /// to handle the transmission format.
    /// </summary>
    public ISoundType? Type;
    public SoundEvent? Event;
    public required SoundCategory Category;
    public required Vec3<double> Pos;
    public required float Volume;
    public required float Pitch;
    public required long Seed;

    /// <summary>
    /// Initialise a new instance of the packet with a <see cref="SoundEvent"/>.
    /// <p/>
    /// To use a numerical ID instead of a <see cref="SoundEvent"/> see
    /// <see cref="ClientBoundSoundEffectPacket(ISoundType, SoundCategory, Vec3, float, float, long)"/>.
    /// </summary>
    /// <param name="soundEvent">The sound event.</param>
    /// <param name="category">The category.</param>
    /// <param name="pos">The position to play the sound at.</param>
    /// <param name="volume">The volume, from 0.0 to 1.0.</param>
    /// <param name="pitch">The pitch.</param>
    /// <param name="seed">Seed to use for random effects by the Notchian client.</param>
    [SetsRequiredMembers]
    public ClientBoundSoundEffectPacket(SoundEvent soundEvent, SoundCategory category, Vec3<double> pos, float volume, float pitch, long seed) : this() {
        Event = soundEvent;
        Category = category;
        Pos = pos;
        Volume = volume;
        Pitch = pitch;
        Seed = seed;
    }

    /// <summary>
    /// Initialise a new instance of the packet with a sound type.
    /// <p/>
    /// To use a <see cref="SoundEvent"/> instead of a numerical ID see
    /// <see cref="ClientBoundSoundEffectPacket(SoundEvent, SoundCategory, Vec3, float, float, long)"/>.
    /// </summary>
    /// <param name="type">The type of the sound.</param>
    /// <param name="category">The category.</param>
    /// <param name="pos">The position to play the sound at.</param>
    /// <param name="volume">The volume, from 0.0 to 1.0.</param>
    /// <param name="pitch">The pitch.</param>
    /// <param name="seed">Seed to use for random effects by the Notchian client.</param>
    [SetsRequiredMembers]
    public ClientBoundSoundEffectPacket(ISoundType type, SoundCategory category, Vec3<double> pos, float volume, float pitch, long seed) : this() {
        Type = type;
        Category = category;
        Pos = pos;
        Volume = volume;
        Pitch = pitch;
        Seed = seed;
    }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        if (Event != null) {
            w.WriteVarInt(0)
                .Write(Event, reg);
        }
        else w.WriteVarInt(Type.ThrowIfNull().ProtocolId + 1);

        int x = (int) Pos.X * (1 << 3);
        int y = (int) Pos.Y * (1 << 3);
        int z = (int) Pos.Z * (1 << 3);

        return w.WriteVarInt((int)Category)
            .WriteInteger(x)
            .WriteInteger(y)
            .WriteInteger(z)
            .WriteFloat(Volume)
            .WriteFloat(Pitch)
            .WriteLong(Seed);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => {
        int id = r.ReadVarInt();
        SoundEvent? ev = null;
        if (id == 0) {
            ev = r.Read<SoundEvent>(reg);
        }
        else id--;
        
        return new ClientBoundSoundEffectPacket {
            Type = reg.SoundTypes[id],
            Event = ev,
            Category = (SoundCategory)r.ReadVarInt(),
            Pos = new Vec3<double>(
                (double)r.ReadInteger() / (1 << 3),
                (double)r.ReadInteger() / (1 << 3),
                (double)r.ReadInteger() / (1 << 3)),
            Volume = r.ReadFloat(),
            Pitch = r.ReadFloat(),
            Seed = r.ReadLong()
        };
    };
}
