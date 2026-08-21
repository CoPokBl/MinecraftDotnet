using Minecraft.Data.Components.Codecs;
using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>Played when the item runs out of durability.</summary>
public record BreakSoundComponent() : IDataComponent<Or<ISoundType, SoundEvent>> {
    public override Identifier Identifier => "minecraft:break_sound";

    public override NbtCodec<Or<ISoundType, SoundEvent>>? Codec => Persistent;
    private static readonly NbtCodec<Or<ISoundType, SoundEvent>> Persistent = new(
        (val, _) => val.IsValue1
            ? new StringTag(val.Value1!.Identifier.ToString())
            : val.Value2!.ToNbt(),
        (tag, registry) => tag is CompoundTag
            ? Or<ISoundType, SoundEvent>.FromValue2(SoundEvent.FromNbt(tag, registry))
            : Or<ISoundType, SoundEvent>.FromValue1(registry.SoundTypes[(Identifier)tag.GetString()]));

    public override DataWriter WriteData(Or<ISoundType, SoundEvent> val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteIdOr(val, registry.SoundTypes.GetProtocolId, (inline, w) => w.Write(inline, registry));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadIdOr(id => registry.SoundTypes[id], r => r.Read<SoundEvent>(registry));
    }

    public override bool ValuesEqual(Or<ISoundType, SoundEvent> val1, Or<ISoundType, SoundEvent> val2) {
        return val1.Equals(val2);
    }
}
