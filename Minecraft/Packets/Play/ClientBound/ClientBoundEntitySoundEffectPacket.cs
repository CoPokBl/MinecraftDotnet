using System.Diagnostics.CodeAnalysis;
using Minecraft.Data.Sounds;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundEntitySoundEffectPacket() : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:sound_entity";
    
    /// <summary>
    /// The numerical sound ID. This value is ignored if <see cref="Event"/> is not null.
    /// This should be the actually sound ID, it is encoded (has 1 added to it) automatically
    /// to handle the transmission format.
    /// </summary>
    public ISoundType? Type;
    public SoundEvent? Event;
    public required SoundCategory Category;
    public required int EntityId;
    public required float Volume;
    public required float Pitch;
    public required long Seed;

    /// <summary>
    /// Initialise a new instance of the packet with a <see cref="SoundEvent"/>.
    /// <p/>
    /// To use a numerical ID instead of a <see cref="SoundEvent"/> see
    /// <see cref="ClientBoundEntitySoundEffectPacket(ISoundType, SoundCategory, int, float, float, long)"/>.
    /// </summary>
    /// <param name="soundEvent">The sound event.</param>
    /// <param name="category">The category.</param>
    /// <param name="entityId">The network ID of the entity that plays the sound.</param>
    /// <param name="volume">The volume, from 0.0 to 1.0.</param>
    /// <param name="pitch">The pitch.</param>
    /// <param name="seed">Seed to use for random effects by the Notchian client.</param>
    [SetsRequiredMembers]
    public ClientBoundEntitySoundEffectPacket(SoundEvent soundEvent, SoundCategory category, int entityId, float volume, float pitch, long seed) : this() {
        Event = soundEvent;
        EntityId = entityId;
        Category = category;
        Volume = volume;
        Pitch = pitch;
        Seed = seed;
    }

    /// <summary>
    /// Initialise a new instance of the packet with a numerical sound ID.
    /// <p/>
    /// To use a <see cref="SoundEvent"/> instead of a numerical ID see
    /// <see cref="ClientBoundEntitySoundEffectPacket(SoundEvent, SoundCategory, int, float, float, long)"/>.
    /// </summary>
    /// <param name="type">The sound type.</param>
    /// <param name="category">The category.</param>
    /// <param name="entityId">The network ID of the entity that plays the sound.</param>
    /// <param name="volume">The volume, from 0.0 to 1.0.</param>
    /// <param name="pitch">The pitch.</param>
    /// <param name="seed">Seed to use for random effects by the Notchian client.</param>
    [SetsRequiredMembers]
    public ClientBoundEntitySoundEffectPacket(ISoundType type, SoundCategory category, int entityId, float volume, float pitch, long seed) : this() {
        Type = type;
        EntityId = entityId;
        Category = category;
        Volume = volume;
        Pitch = pitch;
        Seed = seed;
    }

    protected override DataWriter WriteData(DataWriter w) {
        if (Event != null) {
            w.WriteVarInt(0)
                .WriteString(Event.Type.Identifier)
                .WritePrefixedOptional(Event.FixedRange, (f, writer) => writer.WriteFloat(f));
        }
        else w.WriteVarInt(Event!.Type.ProtocolId + 1);

        return w.WriteVarInt((int)Category)
            .WriteVarInt(EntityId)
            .WriteFloat(Volume)
            .WriteFloat(Pitch)
            .WriteLong(Seed);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => {
        int id = r.ReadVarInt();
        SoundEvent? ev = null;
        if (id == 0) {
            ev = SoundEvent.Deserialise(r, reg);
        }
        else id--;

        return new ClientBoundEntitySoundEffectPacket {
            Type = reg.SoundTypes[id],
            Event = ev,
            Category = (SoundCategory)r.ReadVarInt(),
            EntityId = r.ReadVarInt(),
            Volume = r.ReadFloat(),
            Pitch = r.ReadFloat(),
            Seed = r.ReadLong()
        };
    };
}
