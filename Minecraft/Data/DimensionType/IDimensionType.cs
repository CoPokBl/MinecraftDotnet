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
        List<INbtTag?> children = [
            new BooleanTag("has_fixed_time", HasFixedTime),
            new BooleanTag("has_skylight", HasSkyLight),
            new BooleanTag("has_ceiling", HasCeiling),
            new DoubleTag("coordinate_scale", CoordinateScale),
            new IntegerTag("min_y", MinY),
            new IntegerTag("height", Height),
            new IntegerTag("logical_height", LogicalHeight),
            new StringTag("infiniburn", InfiniBurn),
            new StringTag("skybox", Skybox.ToString().ToLower()),
            new StringTag("cardinal_light", CardinalLight.ToString().ToLower()),
            new FloatTag("ambient_light", AmbientLight)
        ];

        Or<int, CompoundTag> msll = MonsterSpawnLightLevel ?? new Or<int, CompoundTag>(0);
        if (msll.IsValue1) {
            children.Add(new IntegerTag("monster_spawn_light_level", msll.Value1));
        }
        else {
            children.Add(msll.Value2!.WithName("monster_spawn_light_level"));
        }
        
        children.Add(new IntegerTag("monster_spawn_block_light_limit", MonsterSpawnBlockLightLimit));
        
        if (Attributes != null) {
            children.Add(Attributes.WithName("attributes"));
        }

        if (Timelines != null) {
            children.Add(Timelines.WithName("timelines"));
        }
        
        return new CompoundTag(null, children.ToArray());
    }

    public static IDimensionType FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        bool hasFixedTime = tag["has_fixed_time"].GetBoolean();
        bool hasSkyLight = tag["has_skylight"].GetBoolean();
        bool hasCeiling = tag["has_ceiling"].GetBoolean();
        double coordinateScale = tag["coordinate_scale"].GetDouble();
        int minY = tag["min_y"].GetInteger();
        int height = tag["height"].GetInteger();
        int logicalHeight = tag["logical_height"].GetInteger();
        string infiniBurn = tag["infiniburn"].GetString();
        Skybox skybox = Enum.Parse<Skybox>(tag["skybox"].GetString(), true);
        CardinalLight cardinalLight = Enum.Parse<CardinalLight>(tag["cardinal_light"].GetString(), true);
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
