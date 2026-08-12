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
    public BannerPatternRegistry BannerPatterns { get; set; } = new();
    public TrimPatternRegistry TrimPatterns { get; set; } = new();
    public JukeboxSongRegistry JukeboxSongs { get; set; } = new();
    public InstrumentRegistry Instruments { get; set; } = new();
    public CowSoundVariantRegistry CowSoundVariants { get; set; } = new();
    public WorldClockRegistry WorldClocks { get; set; } = new();
    public EnvironmentAttributeRegistry EnvironmentAttributes { get; set; } = new();
    public BiomeRegistry Biomes { get; set; } = new();
    public ChatTypeRegistry ChatTypes { get; set; } = new();
    public TrimMaterialRegistry TrimMaterials { get; set; } = new();
    public WolfVariantRegistry WolfVariants { get; set; } = new();
    public WolfSoundVariantRegistry WolfSoundVariants { get; set; } = new();
    public PigVariantRegistry PigVariants { get; set; } = new();
    public PigSoundVariantRegistry PigSoundVariants { get; set; } = new();
    public FrogVariantRegistry FrogVariants { get; set; } = new();
    public CatVariantRegistry CatVariants { get; set; } = new();
    public CatSoundVariantRegistry CatSoundVariants { get; set; } = new();
    public CowVariantRegistry CowVariants { get; set; } = new();
    public ChickenVariantRegistry ChickenVariants { get; set; } = new();
    public ChickenSoundVariantRegistry ChickenSoundVariants { get; set; } = new();
    public ZombieNautilusVariantRegistry ZombieNautilusVariants { get; set; } = new();
    public SulfurCubeArchetypeRegistry SulfurCubeArchetypes { get; set; } = new();
    public TestEnvironmentRegistry TestEnvironments { get; set; } = new();
    public TestInstanceRegistry TestInstances { get; set; } = new();
    public DialogRegistry Dialogs { get; set; } = new();

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
        PaintingVariants,
        BannerPatterns,
        TrimPatterns,
        JukeboxSongs,
        Instruments,
        CowSoundVariants,
        WorldClocks,
        EnvironmentAttributes,
        Biomes,
        ChatTypes,
        TrimMaterials,
        WolfVariants,
        WolfSoundVariants,
        PigVariants,
        PigSoundVariants,
        FrogVariants,
        CatVariants,
        CatSoundVariants,
        CowVariants,
        ChickenVariants,
        ChickenSoundVariants,
        ZombieNautilusVariants,
        SulfurCubeArchetypes,
        TestEnvironments,
        TestInstances,
        Dialogs
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
            PaintingVariants = PaintingVariants.Clone(),
            BannerPatterns = BannerPatterns.Clone(),
            TrimPatterns = TrimPatterns.Clone(),
            JukeboxSongs = JukeboxSongs.Clone(),
            Instruments = Instruments.Clone(),
            CowSoundVariants = CowSoundVariants.Clone(),
            WorldClocks = WorldClocks.Clone(),
            EnvironmentAttributes = EnvironmentAttributes.Clone(),
            Biomes = Biomes.Clone(),
            ChatTypes = ChatTypes.Clone(),
            TrimMaterials = TrimMaterials.Clone(),
            WolfVariants = WolfVariants.Clone(),
            WolfSoundVariants = WolfSoundVariants.Clone(),
            PigVariants = PigVariants.Clone(),
            PigSoundVariants = PigSoundVariants.Clone(),
            FrogVariants = FrogVariants.Clone(),
            CatVariants = CatVariants.Clone(),
            CatSoundVariants = CatSoundVariants.Clone(),
            CowVariants = CowVariants.Clone(),
            ChickenVariants = ChickenVariants.Clone(),
            ChickenSoundVariants = ChickenSoundVariants.Clone(),
            ZombieNautilusVariants = ZombieNautilusVariants.Clone(),
            SulfurCubeArchetypes = SulfurCubeArchetypes.Clone(),
            TestEnvironments = TestEnvironments.Clone(),
            TestInstances = TestInstances.Clone(),
            Dialogs = Dialogs.Clone()
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
