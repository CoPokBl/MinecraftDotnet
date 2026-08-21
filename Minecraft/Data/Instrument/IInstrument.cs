using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Instrument;

public interface IInstrument : IProtocolType, INetworkType<IInstrument> {
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
            SoundEvent.FromNbt(tag["sound_event"]!, reg),
            tag["use_duration"]!.GetFloat(),
            tag["range"]!.GetFloat(),
            TextComponent.FromTag(tag["description"]!));
    }

    DataWriter INetworkType<IInstrument>.WriteData(DataWriter writer, MinecraftRegistry registry) {
        return SoundEvent.WriteHolder(writer, registry)
            .WriteFloat(UseDuration)
            .WriteFloat(Range)
            .WriteNbt(Description);
    }

    static IInstrument INetworkType<IInstrument>.ReadData(DataReader reader, MinecraftRegistry registry) {
        return ReadData(reader, registry);
    }

    /// <remarks>
    /// An inline instrument has no registry name, so the sound it plays stands in as its identifier.
    /// </remarks>
    public new static IInstrument ReadData(DataReader reader, MinecraftRegistry registry) {
        SoundEvent sound = SoundEvent.ReadHolder(reader, registry);
        return new SimpleInstrument(sound.Type.Identifier, sound, reader.ReadFloat(), reader.ReadFloat(), reader.ReadText());
    }
}
