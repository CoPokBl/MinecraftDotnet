using Minecraft.Registry;
using Minecraft.Schemas;
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
    public string InfiniBurn { get; }
    public Skybox Skybox { get; }
    public CardinalLight CardinalLight { get; }
    public float AmbientLight { get; }
    public Or<int, CompoundTag>? MonsterSpawnLightLevel { get; }
    public int MonsterSpawnBlockLightLimit { get; }
    public CompoundTag? Attributes { get; }
    public INbtTag? Timelines { get; }
    
    public INbtTag ToNbt() {
        List<(string, INbtTag?)> children = [
            ("has_fixed_time", new BooleanTag(HasFixedTime)),
            ("has_skylight", new BooleanTag(HasSkyLight)),
            ("has_ceiling", new BooleanTag(HasCeiling)),
            ("coordinate_scale", new DoubleTag(CoordinateScale)),
            ("min_y", new IntegerTag(MinY)),
            ("height", new IntegerTag(Height)),
            ("logical_height", new IntegerTag(LogicalHeight)),
            ("infiniburn", new StringTag(InfiniBurn)),
            ("skybox", new StringTag(Skybox.ToString().ToLower())),
            ("cardinal_light", new StringTag(CardinalLight.ToString().ToLower())),
            ("ambient_light", new FloatTag(AmbientLight))
        ];

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
        bool hasFixedTime = tag.Contains("has_fixed_time") && tag["has_fixed_time"].GetBoolean();
        bool hasSkyLight = tag["has_skylight"].GetBoolean();
        bool hasCeiling = tag["has_ceiling"].GetBoolean();
        double coordinateScale = tag["coordinate_scale"].GetDouble();
        int minY = tag["min_y"].GetInteger();
        int height = tag["height"].GetInteger();
        int logicalHeight = tag["logical_height"].GetInteger();
        string infiniBurn = tag["infiniburn"].GetString();
        Skybox skybox = tag.Contains("skybox") ? Enum.Parse<Skybox>(tag["skybox"].GetString(), true) : Skybox.Overworld;
        CardinalLight cardinalLight = tag.Contains("cardinal_light") ? Enum.Parse<CardinalLight>(tag["cardinal_light"].GetString(), true) : CardinalLight.Default;
        float ambientLight = tag["ambient_light"].GetFloat();

        Or<int, CompoundTag>? monsterSpawnLightLevel = null;
        if (tag.Contains("monster_spawn_light_level")) {
            INbtTag msllTag = tag["monster_spawn_light_level"]!;
            if (msllTag is IntegerTag intTag) {
                monsterSpawnLightLevel = new Or<int, CompoundTag>(intTag.Value);
            }
            else if (msllTag is CompoundTag compoundTag) {
                monsterSpawnLightLevel = new Or<int, CompoundTag>(compoundTag);
            }
        }

        int monsterSpawnBlockLightLimit = tag["monster_spawn_block_light_limit"].GetInteger();
        
        CompoundTag? attributes = tag.Contains("attributes") ? tag["attributes"].GetCompound() : null;
        INbtTag? timelines = tag.Contains("timelines") ? tag["timelines"] : null;

        return new SimpleDimensionType(ident, hasFixedTime, hasSkyLight, hasCeiling, coordinateScale, minY,
            height, logicalHeight, infiniBurn, skybox, cardinalLight, ambientLight, monsterSpawnLightLevel,
            monsterSpawnBlockLightLimit, attributes, timelines);
    }
}
