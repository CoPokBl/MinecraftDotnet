using ClientLib.World;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft;
using Minecraft.Data.Biomes;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace GraphicalClient.Rendering;

/// <summary>
/// The colours a biome paints things: grass, foliage and water tints for the blocks, sky and fog for
/// the frame. Explicit colours in the biome's effects and attributes win; grass and foliage otherwise
/// come from a resource pack's colour maps by temperature and rainfall, or without a pack from a
/// gradient of this client's own choosing.
/// </summary>
public static class BiomeColours {
    public readonly record struct Tints(uint Grass, uint Foliage, uint Water, uint DryFoliage);

    /// <summary>A pack's <c>textures/colormap</c> images, any of which may be missing.</summary>
    public sealed record ColourMaps(TextureImage? Grass, TextureImage? Foliage, TextureImage? DryFoliage);

    private const uint GrassLush = 0x47CD33, GrassDry = 0xBFB755, GrassCold = 0x80B497;
    private const uint FoliageLush = 0x30BB0B, FoliageDry = 0xAEA42A, FoliageCold = 0x60A17B;

    /// <summary>One entry per biome protocol id, for the mesher to index without touching the registry.</summary>
    public static Tints[] Table(ClientLevel level, ColourMaps? maps) {
        Tints[] table = new Tints[level.Registry.Biomes.Count];
        for (int id = 0; id < table.Length; id++) {
            table[id] = Of(level.Registry.Biomes[id], maps);
        }
        return table;
    }

    public static Tints Of(IBiome biome, ColourMaps? maps) {
        float temperature = Math.Clamp(biome.Temperature, 0.0F, 1.0F);
        float rain = Math.Clamp(biome.Downfall, 0.0F, 1.0F);
        float downfall = rain * temperature;
        BiomeSpecialEffects effects = biome.Effects;

        uint FromMap(TextureImage? map, uint lush, uint dry, uint cold) =>
            map != null ? Lookup(map, temperature, rain) : Gradient(temperature, downfall, lush, dry, cold);

        uint grass = effects.GrassColor is { } fixedGrass ? (uint)fixedGrass : FromMap(maps?.Grass, GrassLush, GrassDry, GrassCold);
        grass = effects.GrassColorModifier switch {
            GrassColorModifier.Swamp => 0x6A7039,
            // GrassColorModifier.DARK_FOREST: halfway to a fixed dark green.
            GrassColorModifier.DarkForest => ((grass & 0xFEFEFE) + 0x28340A) >> 1,
            _ => grass
        };
        uint foliage = effects.FoliageColor is { } fixedFoliage ? (uint)fixedFoliage : FromMap(maps?.Foliage, FoliageLush, FoliageDry, FoliageCold);
        uint dryFoliage = effects.DryFoliageColor is { } fixedDry ? (uint)fixedDry
            : FromMap(maps?.DryFoliage, FoliageDry, 0x8B6B3A, 0x7A6F57);
        return new Tints(grass & 0xFFFFFF, foliage & 0xFFFFFF, (uint)effects.WaterColor & 0xFFFFFF, dryFoliage & 0xFFFFFF);
    }

    /// <summary><c>ColorMapColorUtil.get</c>, which reads the map as if it were 256 wide whatever its size.</summary>
    private static uint Lookup(TextureImage map, float temperature, float rain) {
        rain *= temperature;
        int x = (int)((1.0 - temperature) * 255.0);
        int y = (int)((1.0 - rain) * 255.0);
        int index = y << 8 | x;
        if (index >= map.Width * map.Height) {
            return 0xFF00FF;
        }
        int o = index * 4;
        return (uint)(map.Rgba[o] << 16 | map.Rgba[o + 1] << 8 | map.Rgba[o + 2]);
    }

    /// <summary>Downfall never exceeds temperature, so the three corners span every biome.</summary>
    private static uint Gradient(float temperature, float downfall, uint lush, uint dry, uint cold) {
        float wLush = downfall, wDry = temperature - downfall, wCold = 1.0F - temperature;
        uint Channel(int shift) => (uint)Math.Clamp(
            ((lush >> shift) & 0xFF) * wLush + ((dry >> shift) & 0xFF) * wDry + ((cold >> shift) & 0xFF) * wCold, 0, 255);
        return Channel(16) << 16 | Channel(8) << 8 | Channel(0);
    }

    /// <summary>A colour environment attribute from the biome, else the dimension, else the fallback.</summary>
    public static uint Environment(ClientLevel level, IBiome biome, Minecraft.Data.EnvironmentAttributes.IEnvironmentAttribute attribute, uint fallback) {
        if (biome.Attributes[attribute] is EnvironmentAttributeEntry.Constant constant && Parse(constant.Value.ToNbt()) is { } fromBiome) {
            return fromBiome;
        }
        if (level.DimensionType.Attributes?[attribute.Identifier.ToString()] is { } tag && Parse(tag) is { } fromDimension) {
            return fromDimension;
        }
        return fallback;
    }

    /// <summary>A colour in any form <c>ExtraCodecs.STRING_RGB_COLOR</c> reads, or null for anything else.</summary>
    private static uint? Parse(INbtTag tag) {
        return tag switch {
            StringTag s when !s.Value.StartsWith('#') => null,
            StringTag or ListTag => (uint)PackedColor.StringRgbFromNbt(tag) & 0xFFFFFF,
            _ when tag.IsNumber() => (uint)PackedColor.StringRgbFromNbt(tag) & 0xFFFFFF,
            _ => null
        };
    }
}
