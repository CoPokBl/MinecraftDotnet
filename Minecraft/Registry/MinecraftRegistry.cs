using Minecraft.Data;
using Minecraft.Data.ArgumentParsers;
using Minecraft.Data.Attributes;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Components;
using Minecraft.Data.ConsumeEffects;
using Minecraft.Data.CustomStatistics;
using Minecraft.Data.Entities;
using Minecraft.Data.Inventories;
using Minecraft.Data.Items;
using Minecraft.Data.Particles;
using Minecraft.Data.PotionEffectTypes;
using Minecraft.Data.Sounds;
using Minecraft.Data.StatisticTypes;

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
    public StatisticTypeRegistry StatisticTypes { get; init; } = new();
    public CustomStatisticRegistry CustomStatistics { get; init; } = new();

    public MinecraftRegistry Clone() {
        Get<IBlock>(1);
        
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
            CustomStatistics = CustomStatistics.Clone()
        };
    }

    public T Get<T>(int id) where T : IProtocolType {
        return typeof(T) switch {
            { } t when t == typeof(IParticle) => (T)Particles[id],
            { } t when t == typeof(IBlock) => (T)Blocks[id],
            { } t when t == typeof(IItem) => (T)Items[id],
            { } t when t == typeof(IDataComponent) => (T)DataComponents[id],
            { } t when t == typeof(IEntityType) => (T)EntityTypes[id],
            { } t when t == typeof(ISoundType) => (T)SoundTypes[id],
            { } t when t == typeof(IInventoryType) => (T)InventoryTypes[id],
            { } t when t == typeof(IPotionEffectType) => (T)PotionEffectTypes[id],
            { } t when t == typeof(IConsumeEffect) => (T)ConsumeEffects[id],
            { } t when t == typeof(IBlockEntityType) => (T)BlockEntityTypes[id],
            { } t when t == typeof(IAttribute) => (T)Attributes[id],
            { } t when t == typeof(IArgumentParser) => (T)CommandArgumentTypes[id],
            { } t when t == typeof(IStatisticType) => (T)StatisticTypes[id],
            { } t when t == typeof(ICustomStatistic) => (T)CustomStatistics[id],
            
            _ => throw new ArgumentException($"Registry lookup for type {typeof(T)} is not implemented.")
        };
    }
}
