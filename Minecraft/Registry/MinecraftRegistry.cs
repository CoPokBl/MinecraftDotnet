namespace Minecraft.Registry;

public class MinecraftRegistry {
    public ParticleRegistry Particles { get; init; } = new();
    public BlockRegistry Blocks { get; init; } = new();
    public PacketRegistry Packets { get; init; } = new();
    public ItemRegistry Items { get; init; } = new();
    public DataComponentRegistry DataComponents { get; } = new();
    public EntityTypeRegistry EntityTypes { get; init; } = new();
    public SoundTypeRegistry SoundTypes { get; init; } = new();
    public InventoryTypeRegistry InventoryTypes { get; init; } = new();
    public PotionEffectTypeRegistry PotionEffectTypes { get; init; } = new();
    public ConsumeEffectRegistry ConsumeEffects { get; init; } = new();
    public BlockEntityTypeRegistry BlockEntityTypes { get; init; } = new();
    public AttributeRegistry Attributes { get; init; } = new();
    public CommandArgumentTypeRegistry CommandArgumentTypes { get; init; } = new();
}
