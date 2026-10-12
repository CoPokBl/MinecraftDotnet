using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.DimensionType;

public interface IDimensionType : IProtocolType {
    public bool HasFixedTime { get; }
    public bool HasSkyLight { get; }
    public bool HasCeiling { get; }
    public double CoordinateScale { get; }
    public int MinY { get; }
    public int Height { get; }
    public int LogicalHeight { get; }
    public HolderSet InfiniBurn { get; }
    public Skybox Skybox { get; }
    public CardinalLight CardinalLight { get; }
    public float AmbientLight { get; }
    public Or<int, CompoundTag>? MonsterSpawnLightLevel { get; }
    public int MonsterSpawnBlockLightLimit { get; }
    public CompoundTag? Attributes { get; }
    public INbtTag? Timelines { get; }
    public bool HasEnderDragonFight { get; }
    public Identifier? DefaultClock { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("has_fixed_time", new BooleanTag(HasFixedTime)),
            ("has_skylight", new BooleanTag(HasSkyLight)),
            ("has_ceiling", new BooleanTag(HasCeiling)),
            ("coordinate_scale", new DoubleTag(CoordinateScale)),
            ("min_y", new IntegerTag(MinY)),
            ("height", new IntegerTag(Height)),
            ("logical_height", new IntegerTag(LogicalHeight)),
            ("infiniburn", InfiniBurn.ToNbt()),
            ("skybox", new StringTag(Skybox.ToString().ToLower())),
            ("cardinal_light", new StringTag(CardinalLight.ToString().ToLower())),
            ("ambient_light", new FloatTag(AmbientLight)),
            ("has_ender_dragon_fight", new BooleanTag(HasEnderDragonFight))
        ];

        if (DefaultClock.HasValue) {
            children.Add(("default_clock", new StringTag(DefaultClock.Value)));
        }

        Or<int, CompoundTag> msll = MonsterSpawnLightLevel ?? new Or<int, CompoundTag>(0);
        if (msll.IsValue1) {
            children.Add(("monster_spawn_light_level", new IntegerTag(msll.Value1)));
        }
        else {
            children.Add(("monster_spawn_light_level", msll.Value2!));
        }
        
        children.Add(("monster_spawn_block_light_limit", new IntegerTag(MonsterSpawnBlockLightLimit)));
        
        if (Attributes != null) {
            children.Add(("attributes", Attributes));
        }

        if (Timelines != null) {
            children.Add(("timelines", Timelines));
        }
        
        return new CompoundTag(children.ToArray());
    }

    public static IDimensionType FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        bool hasFixedTime = tag.Contains("has_fixed_time") && tag["has_fixed_time"].AsBool();
        bool hasSkyLight = tag["has_skylight"].AsBool();
        bool hasCeiling = tag["has_ceiling"].AsBool();
        double coordinateScale = tag["coordinate_scale"].AsDouble();
        int minY = tag["min_y"].AsInt();
        int height = tag["height"].AsInt();
        int logicalHeight = tag["logical_height"].AsInt();
        HolderSet infiniBurn = HolderSet.FromNbt(tag["infiniburn"]!);
        Skybox skybox = tag.Contains("skybox") ? Enum.Parse<Skybox>(tag["skybox"].GetString(), true) : Skybox.Overworld;
        CardinalLight cardinalLight = tag.Contains("cardinal_light") ? Enum.Parse<CardinalLight>(tag["cardinal_light"].GetString(), true) : CardinalLight.Default;
        float ambientLight = tag["ambient_light"].AsFloat();

        Or<int, CompoundTag>? monsterSpawnLightLevel = null;
        if (tag.Contains("monster_spawn_light_level")) {
            INbtTag msllTag = tag["monster_spawn_light_level"]!;
            if (msllTag.IsNumber()) {
                monsterSpawnLightLevel = new Or<int, CompoundTag>(msllTag.AsInt());
            }
            else if (msllTag is CompoundTag compoundTag) {
                monsterSpawnLightLevel = new Or<int, CompoundTag>(compoundTag);
            }
        }

        int monsterSpawnBlockLightLimit = tag["monster_spawn_block_light_limit"].AsInt();
        
        CompoundTag? attributes = tag.Contains("attributes") ? tag["attributes"].GetCompound() : null;
        INbtTag? timelines = tag.Contains("timelines") ? tag["timelines"] : null;
        bool hasEnderDragonFight = tag.Contains("has_ender_dragon_fight") && tag["has_ender_dragon_fight"].AsBool();
        // Assigned separately because a null string would otherwise be converted into an
        // Identifier rather than staying null
        Identifier? defaultClock = null;
        if (tag.Contains("default_clock")) {
            defaultClock = tag["default_clock"].GetString();
        }

        return new SimpleDimensionType(ident, hasFixedTime, hasSkyLight, hasCeiling, coordinateScale, minY,
            height, logicalHeight, infiniBurn, skybox, cardinalLight, ambientLight, monsterSpawnLightLevel,
            monsterSpawnBlockLightLimit, attributes, timelines, hasEnderDragonFight, defaultClock);
    }
}
