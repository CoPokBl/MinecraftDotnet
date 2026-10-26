using Minecraft.Data;
using Minecraft.Data.Sounds;
using Minecraft.Registry;
using NBT;
using NBT.Tags;

namespace Minecraft.Schemas.Sound;

public record SoundEvent(ISoundType Type, float? FixedRange) : INetworkType<SoundEvent> {

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry reg) {
        return writer
            .Write(Type.Identifier)
            .WritePrefixedOptional(FixedRange, (f, wr) => wr.WriteFloat(f));
    }

    public static SoundEvent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new SoundEvent(
            registry.SoundTypes[reader.ReadString()],
            reader.ReadPrefixedOptionalValue(re => re.ReadFloat()));
    }

    /// <summary>
    /// Writes the sound as a <c>Holder&lt;SoundEvent&gt;</c>: the registry id plus one for a plain
    /// entry, and a zero followed by the inline form for a sound carrying a fixed range or one the
    /// registry does not hold.
    /// </summary>
    public DataWriter WriteHolder(DataWriter writer, MinecraftRegistry registry) {
        if (FixedRange == null && registry.SoundTypes.Contains(Type.Identifier)) {
            return writer.WriteVarInt(registry.SoundTypes.GetProtocolId(Type) + 1);
        }

        return WriteData(writer.WriteVarInt(0), registry);
    }

    public static SoundEvent ReadHolder(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadHolder(id => new SoundEvent(registry.SoundTypes[id], null), r => ReadData(r, registry));
    }

    /// <summary>
    /// Writes the sound the way the registries that hold one do: a bare string when it's an
    /// entry of the sound registry, and the inline form otherwise. This is a
    /// <c>Holder&lt;SoundEvent&gt;</c> on the vanilla side, so both shapes are accepted
    /// wherever one appears.
    /// </summary>
    public INbtTag ToNbt() {
        if (FixedRange == null) {
            return new StringTag(Type.Identifier.ToString());
        }

        return new CompoundTag(
            ("sound_id", new StringTag(Type.Identifier.ToString())),
            ("range", new FloatTag(FixedRange.Value)));
    }

    public static SoundEvent FromNbt(INbtTag tag, MinecraftRegistry registry) {
        if (tag is CompoundTag compound) {
            return new SoundEvent(
                GetSoundType(compound["sound_id"].GetString(), registry),
                // lenientOptionalFieldOf: a range that does not read as a number is no range.
                compound["range"] is { } range && range.IsNumber() ? range.AsFloat() : null);
        }

        return new SoundEvent(GetSoundType(tag.GetString(), registry), null);
    }

    /// <remarks>
    /// A datapack can name a sound the client knows about that isn't in the vanilla registry,
    /// and the id is all that travels, so an unknown one becomes a bare sound type rather than
    /// taking the whole registry entry down with it.
    /// </remarks>
    private static ISoundType GetSoundType(Identifier id, MinecraftRegistry registry) {
        return registry.SoundTypes.Contains(id) ? registry.SoundTypes[id] : new SimpleSoundType(id);
    }
}
