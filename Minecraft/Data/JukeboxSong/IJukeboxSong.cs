using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.JukeboxSong;

public interface IJukeboxSong : IProtocolType {
    public SoundEvent SoundEvent { get; }
    public TextComponent Description { get; }
    public float LengthInSeconds { get; }
    public int ComparatorOutput { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("sound_event", SoundEvent.ToNbt()),
            ("description", Description.SerialiseToTag()),
            ("length_in_seconds", new FloatTag(LengthInSeconds)),
            ("comparator_output", new IntegerTag(ComparatorOutput)));
    }

    public static IJukeboxSong FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleJukeboxSong(
            ident,
            SoundEvent.FromNbt(tag["sound_event"]!, reg),
            TextComponent.FromTag(tag["description"]!),
            tag["length_in_seconds"]!.GetFloat(),
            tag["comparator_output"]!.GetInteger());
    }
}
