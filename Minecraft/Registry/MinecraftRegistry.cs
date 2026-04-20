using Minecraft.Data;
using Minecraft.Registry.SubRegistries;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry;

public class MinecraftRegistry {
    public ParticleRegistry Particles { get; set; } = new();
    public BlockRegistry Blocks { get; set; } = new();
    public PacketRegistry Packets { get; set; } = new();
    public ItemRegistry Items { get; set; } = new();
    public DataComponentRegistry DataComponents { get; set; } = new();
    public EntityTypeRegistry EntityTypes { get; set; } = new();
    public SoundTypeRegistry SoundTypes { get; set; } = new();
    public InventoryTypeRegistry InventoryTypes { get; set; } = new();
    public PotionEffectTypeRegistry PotionEffectTypes { get; set; } = new();
    public ConsumeEffectRegistry ConsumeEffects { get; set; } = new();
    public BlockEntityTypeRegistry BlockEntityTypes { get; set; } = new();
    public AttributeRegistry Attributes { get; set; } = new();
    public CommandArgumentTypeRegistry CommandArgumentTypes { get; set; } = new();
    public StatisticTypeRegistry StatisticTypes { get; set; } = new();
    public CustomStatisticRegistry CustomStatistics { get; set; } = new();
    public EnchantmentRegistry Enchantments { get; set; } = new();
    public DimensionTypeRegistry DimensionTypes { get; set; } = new();
    public TimelineRegistry Timelines { get; set; } = new();
    public DamageTypeRegistry DamageTypes { get; set; } = new();
    public PaintingVariantRegistry PaintingVariants { get; set; } = new();

    public ISubRegistry this[Identifier id] {
        get {
            foreach (ISubRegistry reg in SubRegistries) {
                if (reg.RegistryId == id) {
                    return reg;
                }
            }
            
            throw new KeyNotFoundException($"No registry found for ID {id}");
        }
    }

    public ISubRegistry[] SubRegistries => [
        Particles,
        Blocks,
        Packets,
        Items,
        DataComponents,
        EntityTypes,
        SoundTypes,
        InventoryTypes,
        PotionEffectTypes,
        ConsumeEffects,
        BlockEntityTypes,
        Attributes,
        CommandArgumentTypes,
        StatisticTypes,
        CustomStatistics,
        Enchantments,
        DimensionTypes,
        Timelines,
        DamageTypes,
        PaintingVariants
    ];

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
            CommandArgumentTypes = CommandArgumentTypes.Clone(),
            StatisticTypes = StatisticTypes.Clone(),
            CustomStatistics = CustomStatistics.Clone(),
            Enchantments = Enchantments.Clone(),
            DimensionTypes = DimensionTypes.Clone(),
            Timelines = Timelines.Clone(),
            DamageTypes = DamageTypes.Clone(),
            PaintingVariants = PaintingVariants.Clone()
        };
    }
    
    public MinecraftRegistry ShallowClone() {
        return (MinecraftRegistry)MemberwiseClone();
    }

    public T Get<T>(int id) where T : IProtocolType {
        foreach (ISubRegistry subReg in SubRegistries) {
            if (subReg is MappedRegistry<T> mappedReg) {
                return mappedReg[id];
            }
            if (subReg is SequentialRegistry<T> seqReg) {
                return seqReg[id];
            }
        }
        
        throw new KeyNotFoundException($"No registry found for type {typeof(T).Name}");
    }
}
