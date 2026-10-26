using ClientLib;
using ClientLib.Particles;
using ClientLib.World;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Data.Blocks;

namespace GraphicalClient.Rendering.Particles;

/// <summary>
/// The block colours particles take: <c>BlockTintSource.colorAsTerrainParticle</c> from the tints the meshes use,
/// and the map colour for falling dust.
/// </summary>
public sealed class ParticleColours(Func<MinecraftClient> client, BiomeColours.ColourMaps? maps) : IParticleColours {
    public int TerrainTint(uint state, int x, int y, int z) {
        if (client().Level is not { } level) {
            return -1;
        }
        IBlock block = level.Registry.Blocks.GetByStateId(state);
        // BlockTintSources.grassBlock and waterParticles: the grass block's particles are its dirt, and water's are tinted.
        if (block.Identifier == Minecraft.Data.Generated.Block.GrassBlock.Identifier) {
            return -1;
        }
        if (block.Identifier == Minecraft.Data.Generated.Block.Water.Identifier) {
            return (int)Biome(level, x, y, z).Water;
        }
        TintSource[] tints = BlockTints.For(block);
        if (tints.Length == 0) {
            return -1;
        }
        return tints[0].Kind switch {
            TintKind.Grass => (int)Biome(level, x, y, z).Grass,
            TintKind.Foliage => (int)Biome(level, x, y, z).Foliage,
            TintKind.DryFoliage => (int)Biome(level, x, y, z).DryFoliage,
            TintKind.Water => (int)Biome(level, x, y, z).Water,
            _ => (int)tints[0].Rgb
        };
    }

    /// <summary>
    /// The tint, else the map colour. A falling block's own dust colour is approximated by its map colour,
    /// which differs only for sand, red sand, gravel and suspicious sand and gravel.
    /// </summary>
    public int DustColour(uint state, int x, int y, int z) {
        if (client().Level is not { } level) {
            return 0xFFFFFF;
        }
        IBlock block = level.Registry.Blocks.GetByStateId(state);
        if (!block.Gravity && TerrainTint(state, x, y, z) is var tint and not -1) {
            return tint;
        }
        return (int)(MapColors.Base[Math.Clamp(block.MapColorId, 0, MapColors.Base.Length - 1)] & 0xFFFFFF);
    }

    private BiomeColours.Tints Biome(ClientLevel level, int x, int y, int z) =>
        BiomeColours.Of(level.Registry.Biomes[Math.Min(level.GetBiome(x, y, z), (int)level.Registry.Biomes.Count - 1)], maps);
}
