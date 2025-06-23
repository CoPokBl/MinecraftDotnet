using Minecraft.Schemas.Sound;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundEntitySoundEffectPacket(int id, SoundCategory category, int entityId, float volume, float pitch, long seed) : MinecraftPacket {
    public int Id = id;
    public SoundEvent? Event;
    public SoundCategory Category = category;
    public int EntityId = entityId;
    public float Volume = volume;
    public float Pitch = pitch;
    public long Seed = seed;
    
    public ClientBoundEntitySoundEffectPacket() : this(0, SoundCategory.Master, 0, 0, 0, 0) { }

    public ClientBoundEntitySoundEffectPacket(SoundEvent e, SoundCategory category, int entityId, float volume, float pitch,
        long seed) :
        this(0, category, entityId, volume, pitch, seed) {
        Event = e;
    }

    public override int GetPacketId() {
        return 0x6D;
    }

    protected override byte[] GetData() {
        DataWriter w = new();

        if (Event != null) {
            w.WriteVarInt(0)
                .WriteString(Event.Identifier)
                .WritePrefixedOptional(Event.FixedRange, (f, writer) => writer.WriteFloat(f));
        }
        else w.WriteVarInt(Id + 1);

        return w.WriteVarInt((int)Category)
            .WriteVarInt(EntityId)
            .WriteFloat(Volume)
            .WriteFloat(Pitch)
            .WriteLong(Seed)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader reader = new(data);
        Id = reader.ReadVarInt();
        if (Id == 0) {  // it's a sound event
            Event = new SoundEvent(
                reader.ReadString(), 
                reader.ReadPrefixedOptional(re => re.ReadFloat()));
        }
        else Id--;
        
        Category = (SoundCategory)reader.ReadVarInt();
        EntityId = reader.ReadVarInt();
        Volume = reader.ReadFloat();
        Pitch = reader.ReadFloat();
        Seed = reader.ReadLong();
        return this;
    }
}