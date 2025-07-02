namespace Minecraft.Registry;

public class MinecraftRegistry {
    public ParticleRegistry Particles { get; init; } = new();
    public BlockRegistry Blocks { get; init; } = new();
}
