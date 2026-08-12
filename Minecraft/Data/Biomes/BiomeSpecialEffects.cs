using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Biomes;

/// <summary>
/// The colours a biome tints things with. Anything left null is worked out by the client from the
/// biome's climate instead of being sent.
/// </summary>
public record BiomeSpecialEffects(
    int WaterColor,
    int? FoliageColor = null,
    int? DryFoliageColor = null,
    int? GrassColor = null,
    GrassColorModifier GrassColorModifier = GrassColorModifier.None) {

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("water_color", new StringTag(PackedColor.ToRgbString(WaterColor)))
        ];

        if (FoliageColor != null) {
            children.Add(("foliage_color", new StringTag(PackedColor.ToRgbString(FoliageColor.Value))));
        }

        if (DryFoliageColor != null) {
            children.Add(("dry_foliage_color", new StringTag(PackedColor.ToRgbString(DryFoliageColor.Value))));
        }

        if (GrassColor != null) {
            children.Add(("grass_color", new StringTag(PackedColor.ToRgbString(GrassColor.Value))));
        }

        if (GrassColorModifier != GrassColorModifier.None) {
            children.Add(("grass_color_modifier", new StringTag(GrassColorModifier.ToProtocolString())));
        }

        return new CompoundTag(children.ToArray());
    }

    public static BiomeSpecialEffects FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new BiomeSpecialEffects(
            PackedColor.Parse(compound["water_color"]!.GetString()),
            compound.Contains("foliage_color") ? PackedColor.Parse(compound["foliage_color"]!.GetString()) : null,
            compound.Contains("dry_foliage_color")
                ? PackedColor.Parse(compound["dry_foliage_color"]!.GetString())
                : null,
            compound.Contains("grass_color") ? PackedColor.Parse(compound["grass_color"]!.GetString()) : null,
            compound.Contains("grass_color_modifier")
                ? GrassColorModifierExtensions.ParseGrassColorModifier(compound["grass_color_modifier"]!.GetString())
                : GrassColorModifier.None);
    }
}

/// <summary>A per block twist on the grass colour, on top of whatever the biome resolves to.</summary>
public enum GrassColorModifier {
    None,
    DarkForest,
    Swamp
}

public static class GrassColorModifierExtensions {
    public static string ToProtocolString(this GrassColorModifier modifier) => modifier switch {
        GrassColorModifier.None => "none",
        GrassColorModifier.DarkForest => "dark_forest",
        GrassColorModifier.Swamp => "swamp",
        _ => throw new ArgumentOutOfRangeException(nameof(modifier), modifier, null)
    };

    public static GrassColorModifier ParseGrassColorModifier(string value) => value switch {
        "none" => GrassColorModifier.None,
        "dark_forest" => GrassColorModifier.DarkForest,
        "swamp" => GrassColorModifier.Swamp,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown grass color modifier")
    };
}
