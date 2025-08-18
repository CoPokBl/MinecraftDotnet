namespace Minecraft.Registry;

public class MinecraftRegistry {
    public ParticleRegistry Particles { get; init; } = new();
    public BlockRegistry Blocks { get; init; } = new();
    public PacketRegistry Packets { get; init; } = new();
    public ItemRegistry Items { get; init; } = new();
    public DataComponentRegistry DataComponents { get; init; } = new();
    public EntityTypeRegistry EntityTypes { get; init; } = new();
    public SoundTypeRegistry SoundTypes { get; init; } = new();
    public InventoryTypeRegistry InventoryTypes { get; init; } = new();
    public PotionEffectTypeRegistry PotionEffectTypes { get; init; } = new();
    public ConsumeEffectRegistry ConsumeEffects { get; init; } = new();
    public BlockEntityTypeRegistry BlockEntityTypes { get; init; } = new();
    public AttributeRegistry Attributes { get; init; } = new();
    public CommandArgumentTypeRegistry CommandArgumentTypes { get; init; } = new();

    public MinecraftRegistry Clone() {
        return new MinecraftRegistry {
            Particles = Particles.Clone(),
            Blocks = Blocks.Clone(),
            Packets = Packets.Clone(),
            Items = Items.Clone(),
            DataComponents = DataComponents.Clone(),
            EntityTypes = EntityTypes.Clone(),
            SoundTypes = SoundTypes.Clone(),
            InventoryTypes = InventoryTypes.Clone(),
            PotionEffectTypes = PotionEffectTypes.Clone(),
            ConsumeEffects = ConsumeEffects.Clone(),
            BlockEntityTypes = BlockEntityTypes.Clone(),
            Attributes = Attributes.Clone(),
            CommandArgumentTypes = CommandArgumentTypes.Clone()
        };
    }
}
