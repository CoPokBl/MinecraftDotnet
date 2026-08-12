using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Biomes;

/// <remarks>
/// Terrain generation (carvers, features, mob spawners, spawn costs) is server side and vanilla's
/// network codec leaves it out, so it isn't part of this type. What's left is the climate, the
/// colours and the environment attributes, which is everything the client needs.
/// </remarks>
public interface IBiome : IProtocolType {
    /// <summary>Whether it rains or snows here, depending on <see cref="Temperature"/>.</summary>
    public bool HasPrecipitation { get; }

    public float Temperature { get; }

    /// <summary>Adjusts the temperature per position, rather than using it flat.</summary>
    public TemperatureModifier TemperatureModifier { get; }

    public float Downfall { get; }

    public BiomeSpecialEffects Effects { get; }

    /// <summary>What this biome says about the world around it: sky colour, music, and so on.</summary>
    public EnvironmentAttributeMap Attributes { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("has_precipitation", new BooleanTag(HasPrecipitation)),
            ("temperature", new FloatTag(Temperature)),
            ("downfall", new FloatTag(Downfall)),
            ("effects", Effects.ToNbt())
        ];

        if (TemperatureModifier != TemperatureModifier.None) {
            children.Add(("temperature_modifier", new StringTag(TemperatureModifier.ToProtocolString())));
        }

        // Server side attributes are dropped: this is what gets sent to the client, and vanilla's
        // network codec filters them out the same way
        if (Attributes.Entries.Any(e => e.Key.Syncable)) {
            children.Add(("attributes", Attributes.ToNbt(true)));
        }

        return new CompoundTag(children.ToArray());
    }

    public static IBiome FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleBiome(
            ident,
            tag["has_precipitation"]!.GetBoolean(),
            tag["temperature"]!.GetFloat(),
            tag.Contains("temperature_modifier")
                ? TemperatureModifierExtensions.ParseTemperatureModifier(tag["temperature_modifier"]!.GetString())
                : TemperatureModifier.None,
            tag["downfall"]!.GetFloat(),
            BiomeSpecialEffects.FromNbt(tag["effects"]!),
            tag.Contains("attributes")
                ? EnvironmentAttributeMap.FromNbt(tag["attributes"]!, reg)
                : EnvironmentAttributeMap.Empty);
    }
}

public enum TemperatureModifier {
    None,

    /// <summary>Makes patches of the biome cold enough to freeze.</summary>
    Frozen
}

public static class TemperatureModifierExtensions {
    public static string ToProtocolString(this TemperatureModifier modifier) => modifier switch {
        TemperatureModifier.None => "none",
        TemperatureModifier.Frozen => "frozen",
        _ => throw new ArgumentOutOfRangeException(nameof(modifier), modifier, null)
    };

    public static TemperatureModifier ParseTemperatureModifier(string value) => value switch {
        "none" => TemperatureModifier.None,
        "frozen" => TemperatureModifier.Frozen,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown temperature modifier")
    };
}
