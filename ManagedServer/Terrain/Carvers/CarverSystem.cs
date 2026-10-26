using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// The carving pass, vanilla's <c>NoiseBasedChunkGenerator.generateCarvers</c> and
/// <c>applyCarvingMask</c>.
/// </summary>
/// <remarks>
/// One per world, stateless per chunk. <b>Every chunk within eight is replayed over this one</b>,
/// because a carver that started there may reach here, and each source chunk's carver is seeded from
/// the world seed, its index in that biome's list and the source position alone, so the replay agrees
/// with the chunk it started in whatever order the two were generated in.
/// <p/>
/// The carvers only mark a mask. Once all of them have run the mask is applied: every marked block
/// that is not <c>#uncarvable</c> becomes what the chunk's aquifer says is there at zero density, so
/// the overworld fills below y -54 with lava and the nether, whose aquifer is the disabled one, below
/// y 32. Within a run of a column, once a grass block or mycelium has been carved the dirt under each
/// later carved block gets the material rule's top material.
/// </remarks>
public sealed class CarverSystem(VanillaCarverData data, MinecraftRegistry registry, long seed) {
    private const int Range = 8;

    /// <summary>How far below the top of the generation range a carver may not reach.</summary>
    private const int ProtectedBlocksOnTop = 7;

    private static readonly Identifier Uncarvable = "minecraft:uncarvable";

    /// <summary><c>MaterialSystem.topMaterial</c> at one position, for the dirt a carve exposes. Null where no rule matches.</summary>
    public delegate uint? TopMaterialGetter(int blockX, int blockY, int blockZ, bool underFluid);

    /// <param name="carverBiomeAt">
    /// The biome whose carver list a source chunk uses, an uncached point sample at that chunk's
    /// minimum corner at y zero.
    /// </param>
    public void Carve(ChunkColumn chunk, IAquifer aquifer, int chunkX, int chunkZ, GenerationHeightContext context,
        Func<int, int, Identifier> carverBiomeAt, TopMaterialGetter topMaterial) {

        int maxY = context.MinGenY + context.GenDepth - 1 - ProtectedBlocksOnTop;
        CarvingMask mask = new(context.MinGenY + 1, maxY);

        // Reseeded before every carver it considers, so its own seed never reaches anything, which is
        // why upstream starts it from a genuinely random number.
        WorldgenRandom random = new(new LegacyRandomSource(0L));

        for (int dx = -Range; dx <= Range; dx++) {
            for (int dz = -Range; dz <= Range; dz++) {
                int sourceChunkX = chunkX + dx;
                int sourceChunkZ = chunkZ + dz;
                IReadOnlyList<IWorldCarver> carvers = data.For(carverBiomeAt(sourceChunkX, sourceChunkZ));
                for (int index = 0; index < carvers.Count; index++) {
                    random.SetLargeFeatureSeed(seed + index, sourceChunkX, sourceChunkZ);
                    if (carvers[index].IsStartChunk(random)) {
                        carvers[index].Carve(context, random, chunkX, chunkZ, sourceChunkX, sourceChunkZ, mask);
                    }
                }
            }
        }

        if (!mask.IsEmpty) {
            ApplyCarvingMask(chunk, mask, aquifer, chunkX, chunkZ, topMaterial);
        }
    }

    /// <remarks>
    /// A carved fluid is marked for post processing upstream, which asks the fluid simulation to flow
    /// from it. There is no tick scheduler in the generator, so a carved aquifer stays as the mask left it.
    /// </remarks>
    private void ApplyCarvingMask(ChunkColumn chunk, CarvingMask mask, IAquifer aquifer, int chunkX, int chunkZ,
        TopMaterialGetter topMaterial) {

        FeatureBlockData blockData = FeatureBlockData.For(registry);
        mask.Visit((x, z, bottomY, topY) => {
            bool hasGrass = false;
            int worldX = (chunkX << 4) + x;
            int worldZ = (chunkZ << 4) + z;
            for (int worldY = topY; worldY >= bottomY; worldY--) {
                uint existing = chunk.Read(x, worldY, z);
                if (blockData.IsIn(Uncarvable, existing)) {
                    continue;
                }

                Identifier block = registry.Blocks.GetByStateId(existing).Identifier;
                if (block == Block.GrassBlock.Identifier || block == Block.Mycelium.Identifier) {
                    hasGrass = true;
                }

                if (aquifer.ComputeSubstance(worldX, worldY, worldZ, 0.0) is not { } state) {
                    continue;
                }

                chunk.Write(x, worldY, z, state);
                if (!hasGrass || registry.Blocks.GetByStateId(chunk.Read(x, worldY - 1, z)).Identifier != Block.Dirt.Identifier) {
                    continue;
                }

                bool underFluid = blockData.HasFluidAt(state);
                if (topMaterial(worldX, worldY - 1, worldZ, underFluid) is { } top) {
                    chunk.Write(x, worldY - 1, z, top);
                }
            }
        });
    }
}
