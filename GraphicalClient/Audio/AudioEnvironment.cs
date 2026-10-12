using System.Runtime.CompilerServices;
using ClientLib.World;
using Minecraft;
using Minecraft.Data.Biomes;
using Minecraft.Data.DimensionType;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Generated;
using NBT;
using NBT.Tags;

namespace GraphicalClient.Audio;

/// <summary>
/// <c>EnvironmentAttributeSystem.getValue</c> for the three audio attributes the client reads. None of them is
/// spatially interpolated, so the layers are the dimension's value and then the biome of the quart cell the
/// point is in.
/// </summary>
/// <remarks>
/// Timeline and weather layers are not applied: no vanilla timeline or weather layer sets an audio attribute,
/// so this differs only for a datapack timeline that does.
/// </remarks>
public static class AudioEnvironment {
    private static readonly ConditionalWeakTable<IDimensionType, Dictionary<IEnvironmentAttribute, EnvironmentAttributeEntry?>> DimensionEntries = new();

    public static BackgroundMusic BackgroundMusic(ClientLevel level, double x, double y, double z) =>
        GetValue(level, EnvironmentAttribute.AudioBackgroundMusic, x, y, z) is EnvironmentAttributeValue.Music music ? music.Value : Minecraft.Data.EnvironmentAttributes.BackgroundMusic.Silent;

    public static AmbientSounds AmbientSounds(ClientLevel level, double x, double y, double z) =>
        GetValue(level, EnvironmentAttribute.AudioAmbientSounds, x, y, z) is EnvironmentAttributeValue.Sounds sounds ? sounds.Value : Minecraft.Data.EnvironmentAttributes.AmbientSounds.None;

    /// <summary>Sanitised into <c>AttributeRange.UNIT_FLOAT</c>, as the attribute declares.</summary>
    public static float MusicVolume(ClientLevel level, double x, double y, double z) =>
        GetValue(level, EnvironmentAttribute.AudioMusicVolume, x, y, z) is EnvironmentAttributeValue.Float volume ? Math.Clamp(volume.Value, 0.0F, 1.0F) : 1.0F;

    /// <returns>Null for the attribute's default value.</returns>
    private static EnvironmentAttributeValue? GetValue(ClientLevel level, IEnvironmentAttribute attribute, double x, double y, double z) {
        EnvironmentAttributeValue? value = null;
        if (DimensionEntry(level, attribute) is { } dimension) {
            value = Apply(level, attribute, dimension, value);
        }
        IBiome biome = BiomeClimate.NoiseBiomeAtPosition(level, x, y, z);
        if (biome.Attributes[attribute] is { } fromBiome) {
            value = Apply(level, attribute, fromBiome, value);
        }
        return value;
    }

    private static EnvironmentAttributeEntry? DimensionEntry(ClientLevel level, IEnvironmentAttribute attribute) {
        Dictionary<IEnvironmentAttribute, EnvironmentAttributeEntry?> entries = DimensionEntries.GetValue(level.DimensionType, _ => new Dictionary<IEnvironmentAttribute, EnvironmentAttributeEntry?>());
        if (!entries.TryGetValue(attribute, out EnvironmentAttributeEntry? entry)) {
            INbtTag? tag = level.DimensionType.Attributes?[attribute.Identifier.ToString()];
            entry = tag == null ? null : EnvironmentAttributeEntry.FromNbt(attribute, tag, level.Registry);
            entries[attribute] = entry;
        }
        return entry;
    }

    /// <summary><c>EnvironmentAttributeMap.Entry.applyModifier</c>, for the operations these attributes' types allow.</summary>
    private static EnvironmentAttributeValue? Apply(ClientLevel level, IEnvironmentAttribute attribute, EnvironmentAttributeEntry entry, EnvironmentAttributeValue? subject) {
        switch (entry) {
            case EnvironmentAttributeEntry.Constant constant:
                return constant.Value;
            case EnvironmentAttributeEntry.Modified { Operation: EnvironmentAttributeOperation.Override } overridden:
                return EnvironmentAttributeValue.FromNbt(attribute.ValueKind, overridden.Argument, level.Registry);
            case EnvironmentAttributeEntry.Modified modified when attribute.ValueKind == EnvironmentAttributeValueKind.Float:
                // The one float read here is music_volume, whose default is one.
                float value = subject is EnvironmentAttributeValue.Float f ? f.Value : 1.0F;
                return new EnvironmentAttributeValue.Float(ApplyFloat(modified.Operation, value, modified.Argument));
            default:
                // BackgroundMusic and AmbientSounds are ofNotInterpolated with no library, so override is all their codec reads.
                return subject;
        }
    }

    /// <summary><c>FloatModifier</c>.</summary>
    private static float ApplyFloat(EnvironmentAttributeOperation operation, float subject, INbtTag argument) {
        switch (operation) {
            case EnvironmentAttributeOperation.AlphaBlend:
                // FloatWithAlpha.CODEC: a bare float, or {value, alpha} with alpha defaulting to one.
                (float target, float alpha) = argument is CompoundTag compound
                    ? (compound["value"]!.AsFloat(), compound.Contains("alpha") ? compound["alpha"]!.AsFloat() : 1.0F)
                    : (argument.AsFloat(), 1.0F);
                return subject + alpha * (target - subject);
            case EnvironmentAttributeOperation.Add:
                return subject + argument.AsFloat();
            case EnvironmentAttributeOperation.Subtract:
                return subject - argument.AsFloat();
            case EnvironmentAttributeOperation.Multiply:
                return subject * argument.AsFloat();
            case EnvironmentAttributeOperation.Minimum:
                return Math.Min(subject, argument.AsFloat());
            case EnvironmentAttributeOperation.Maximum:
                return Math.Max(subject, argument.AsFloat());
            default:
                return subject;
        }
    }
}
