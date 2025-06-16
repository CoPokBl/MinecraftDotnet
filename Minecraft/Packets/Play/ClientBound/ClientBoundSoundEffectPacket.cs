using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundSoundEffectPacket(int id, SoundCategory category, Vec3 pos, float volume, float pitch, long seed) : MinecraftPacket {
    public int Id = id;
    public SoundEvent? Event;
    public SoundCategory Category = category;
    public Vec3 Pos = pos;
    public float Volume = volume;
    public float Pitch = pitch;
    public long Seed = seed;
    
    public ClientBoundSoundEffectPacket() : this(0, SoundCategory.Master, Vec3.Zero, 0, 0, 0) { }

    public ClientBoundSoundEffectPacket(SoundEvent e, SoundCategory category, Vec3 pos, float volume, float pitch,
        long seed) :
        this(0, category, pos, volume, pitch, seed) {
        Event = e;
    }

    public override int GetPacketId() {
        return 0x6E;
    }

    protected override byte[] GetData() {
        DataWriter w = new();

        if (Event != null) {
            w.WriteVarInt(0)
                .WriteString(Event.Identifier)
                .WritePrefixedOptional(Event.FixedRange, (f, writer) => writer.WriteFloat(f));
        }
        else w.WriteVarInt(Id + 1);

        int x = (int) Pos.X * (1 << 3);
        int y = (int) Pos.Y * (1 << 3);
        int z = (int) Pos.Z * (1 << 3);

        return w.WriteVarInt((int)Category)
            .WriteInteger(x)
            .WriteInteger(y)
            .WriteInteger(z)
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
        
        int x = reader.ReadVarInt();
        int y = reader.ReadVarInt();
        int z = reader.ReadVarInt();

        Pos = new Vec3((double)x / (1 << 3), (double)y / (1 << 3), (double)z / (1 << 3));
        
        Volume = reader.ReadFloat();
        Pitch = reader.ReadFloat();
        Seed = reader.ReadLong();
        return this;
    }
}