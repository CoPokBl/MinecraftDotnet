using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace ClientLib;

public record Dimension(
    long? FixedTime = null, 
    bool HasSkyLight = true, 
    bool HasCeiling = false, 
    bool UltraWarm = false,
    bool IsNatural = true,
    double CoordinateScale = 1.0,
    bool BedWorks = true,
    bool RespawnAnchorWorks = true,
    int MinY = -64,
    int Height = 384,
    int LogicalHeight = 256,
    string InfiniBurn = "#",
    string Effects = "minecraft:overworld",
    float AmbientLight = 0.0f,
    bool PiglinSafe = true,
    bool HasRaids = true,
    Or<int, CompoundTag>? MonsterSpawnLightLevel = null,
    int MonsterSpawnBlockLightLimit = 0) {

    public INbtTag ToNbt() {
        List<(string, INbtTag?)> children = [];
        
        if (FixedTime.HasValue) {
            children.Add(("fixed_time", new LongTag(FixedTime.Value)));
        }
        
        children.Add(("has_skylight", new BooleanTag(HasSkyLight)));
        children.Add(("has_ceiling", new BooleanTag(HasCeiling)));
        children.Add(("ultrawarm", new BooleanTag(UltraWarm)));
        children.Add(("natural", new BooleanTag(IsNatural)));
        children.Add(("coordinate_scale", new DoubleTag(CoordinateScale)));
        children.Add(("bed_works", new BooleanTag(BedWorks)));
        children.Add(("respawn_anchor_works", new BooleanTag(RespawnAnchorWorks)));
        children.Add(("min_y", new IntegerTag(MinY)));
        children.Add(("height", new IntegerTag(Height)));
        children.Add(("logical_height", new IntegerTag(LogicalHeight)));
        children.Add(("infiniburn", new StringTag(InfiniBurn)));
        children.Add(("effects", new StringTag(Effects)));
        children.Add(("ambient_light", new FloatTag(AmbientLight)));
        children.Add(("piglin_safe", new BooleanTag(PiglinSafe)));
        children.Add(("has_raids", new BooleanTag(HasRaids)));
        
        Or<int, CompoundTag> msll = MonsterSpawnLightLevel ?? new Or<int, CompoundTag>(0);
        if (msll.IsValue1) {
            children.Add(("monster_spawn_light_level", new IntegerTag(msll.Value1)));
        }
        else {
            children.Add(("monster_spawn_light_level", msll.Value2!));
        }
        
        children.Add(("monster_spawn_block_light_limit", new IntegerTag(MonsterSpawnBlockLightLimit)));
        return new CompoundTag(children.ToArray());
    }
    
    public static Dimension FromNbt(INbtTag tag) {
        if (tag is not CompoundTag ct) {
            throw new ArgumentException("Expected a CompoundTag for Dimension");
        }
        
        long? fixedTime = ct["fixed_time"]?.GetLong();
        bool hasSkyLight = ct["has_skylight"]?.GetBoolean() ?? true;
        bool hasCeiling = ct["has_ceiling"]?.GetBoolean() ?? false;
        bool ultraWarm = ct["ultrawarm"]?.GetBoolean() ?? false;
        bool isNatural = ct["natural"]?.GetBoolean() ?? true;
        double coordinateScale = ct["coordinate_scale"]?.GetDouble() ?? 1.0;
        bool bedWorks = ct["bed_works"]?.GetBoolean() ?? true;
        bool respawnAnchorWorks = ct["respawn_anchor_works"]?.GetBoolean() ?? true;
        int minY = ct["min_y"]?.GetInteger() ?? -64;
        int height = ct["height"]?.GetInteger() ?? 384;
        int logicalHeight = ct["logical_height"]?.GetInteger() ?? 256;
        string infiniburn = ct["infiniburn"]?.GetString() ?? "#";
        string effects = ct["effects"]?.GetString() ?? "minecraft:overworld";
        float ambientLight = ct["ambient_light"]?.GetFloat() ?? 0.0f;
        bool piglinSafe = ct["piglin_safe"]?.GetBoolean() ?? true;
        bool hasRaids = ct["has_raids"]?.GetBoolean() ?? true;
        
        INbtTag? monsterSpawnLightLevelTag = ct["monster_spawn_light_level"];
        Or<int, CompoundTag>? monsterSpawnLightLevel = null;
        
        if (monsterSpawnLightLevelTag is IntegerTag intTag) {
            monsterSpawnLightLevel = new Or<int, CompoundTag>(intTag.GetInteger());
        }
        else if (monsterSpawnLightLevelTag is CompoundTag compoundTag) {
            monsterSpawnLightLevel = new Or<int, CompoundTag>(compoundTag);
        }
        
        int monsterSpawnBlockLightLimit = ct["monster_spawn_block_light_limit"]?.GetInteger() ?? 0;
        
        return new Dimension(
            fixedTime,
            hasSkyLight,
            hasCeiling,
            ultraWarm,
            isNatural,
            coordinateScale,
            bedWorks,
            respawnAnchorWorks,
            minY,
            height,
            logicalHeight,
            infiniburn,
            effects,
            ambientLight,
            piglinSafe,
            hasRaids,
            monsterSpawnLightLevel,
            monsterSpawnBlockLightLimit);
    }
}
