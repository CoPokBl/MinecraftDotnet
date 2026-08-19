using Minecraft.Schemas;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// <c>ConfiguredWorldCarver</c>: a carver bound to the settings one file gives it.
/// </summary>
/// <remarks>
/// The non generic half exists so a biome's carver list is one list. Nothing outside the pair needs to
/// know which configuration type a carver takes, and the type parameter is what stops a cave's settings
/// reaching a ravine.
/// </remarks>
public abstract class ConfiguredWorldCarver {
    public abstract bool IsStartChunk(RandomSource random);

    public abstract void Carve(CarvingContext context, RandomSource random, int sourceChunkX,
        int sourceChunkZ);
}

/// <inheritdoc cref="ConfiguredWorldCarver"/>
public sealed class ConfiguredWorldCarver<TConfig>(WorldCarver<TConfig> carver, TConfig config)
    : ConfiguredWorldCarver where TConfig : CarverConfiguration {

    public WorldCarver<TConfig> Carver => carver;

    public TConfig Config => config;

    public override bool IsStartChunk(RandomSource random) => carver.IsStartChunk(config, random);

    public override void Carve(CarvingContext context, RandomSource random, int sourceChunkX,
        int sourceChunkZ) {

        carver.Carve(context, config, random, sourceChunkX, sourceChunkZ);
    }
}
