using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Instrument;

public interface IInstrument : IProtocolType {
    public SoundEvent SoundEvent { get; }
    public float UseDuration { get; }
    public float Range { get; }
    public TextComponent Description { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("sound_event", SoundEvent.ToNbt()),
            ("use_duration", new FloatTag(UseDuration)),
            ("range", new FloatTag(Range)),
            ("description", Description.SerialiseToTag()));
    }

    public static IInstrument FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleInstrument(
            ident,
            SoundEvent.FromNbt(tag["sound_event"], reg),
            tag["use_duration"].GetFloat(),
            tag["range"].GetFloat(),
            TextComponent.FromTag(tag["description"]));
    }
}
