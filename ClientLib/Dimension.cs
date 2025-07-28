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
        List<INbtTag?> children = [];
        
        if (FixedTime.HasValue) {
            children.Add(new LongTag("fixed_time", FixedTime.Value));
        }
        
        children.Add(new BooleanTag("has_skylight", HasSkyLight));
        children.Add(new BooleanTag("has_ceiling", HasCeiling));
        children.Add(new BooleanTag("ultrawarm", UltraWarm));
        children.Add(new BooleanTag("natural", IsNatural));
        children.Add(new DoubleTag("coordinate_scale", CoordinateScale));
        children.Add(new BooleanTag("bed_works", BedWorks));
        children.Add(new BooleanTag("respawn_anchor_works", RespawnAnchorWorks));
        children.Add(new IntegerTag("min_y", MinY));
        children.Add(new IntegerTag("height", Height));
        children.Add(new IntegerTag("logical_height", LogicalHeight));
        children.Add(new StringTag("infiniburn", InfiniBurn));
        children.Add(new StringTag("effects", Effects));
        children.Add(new FloatTag("ambient_light", AmbientLight));
        children.Add(new BooleanTag("piglin_safe", PiglinSafe));
        children.Add(new BooleanTag("has_raids", HasRaids));
        
        Or<int, CompoundTag> msll = MonsterSpawnLightLevel ?? new Or<int, CompoundTag>(0);
        if (msll.IsValue1) {
            children.Add(new IntegerTag("monster_spawn_light_level", msll.Value1));
        }
        else {
            children.Add(msll.Value2!.WithName("monster_spawn_light_level"));
        }
        
        children.Add(new IntegerTag("monster_spawn_block_light_limit", MonsterSpawnBlockLightLimit));
        return new CompoundTag(null, children.ToArray());
    }
    
    public static Dimension FromNbt(INbtTag tag) {
        if (tag is not CompoundTag ct) {
            throw new ArgumentException("Expected a CompoundTag for Dimension");
        }
        
        ct.ChildrenMap.TryGetValue("fixed_time", out INbtTag? fixedTimeTag);
        long? fixedTime = fixedTimeTag?.GetLong();
        
        ct.ChildrenMap.TryGetValue("has_skylight", out INbtTag? hasSkyLightTag);
        bool hasSkyLight = hasSkyLightTag?.GetBoolean() ?? true;
        
        ct.ChildrenMap.TryGetValue("has_ceiling", out INbtTag? hasCeilingTag);
        bool hasCeiling = hasCeilingTag?.GetBoolean() ?? false;
        
        ct.ChildrenMap.TryGetValue("ultrawarm", out INbtTag? ultraWarmTag);
        bool ultraWarm = ultraWarmTag?.GetBoolean() ?? false;
        
        ct.ChildrenMap.TryGetValue("natural", out INbtTag? isNaturalTag);
        bool isNatural = isNaturalTag?.GetBoolean() ?? true;
        
        ct.ChildrenMap.TryGetValue("coordinate_scale", out INbtTag? coordinateScaleTag);
        double coordinateScale = coordinateScaleTag?.GetDouble() ?? 1.0;
        
        ct.ChildrenMap.TryGetValue("bed_works", out INbtTag? bedWorksTag);
        bool bedWorks = bedWorksTag?.GetBoolean() ?? true;
        
        ct.ChildrenMap.TryGetValue("respawn_anchor_works", out INbtTag? respawnAnchorWorksTag);
        bool respawnAnchorWorks = respawnAnchorWorksTag?.GetBoolean() ?? true;
        
        ct.ChildrenMap.TryGetValue("min_y", out INbtTag? minYTag);
        int minY = minYTag?.GetInteger() ?? -64;
        
        ct.ChildrenMap.TryGetValue("height", out INbtTag? heightTag);
        int height = heightTag?.GetInteger() ?? 384;
        
        ct.ChildrenMap.TryGetValue("logical_height", out INbtTag? logicalHeightTag);
        int logicalHeight = logicalHeightTag?.GetInteger() ?? 256;
        
        ct.ChildrenMap.TryGetValue("infiniburn", out INbtTag? infiniburnTag);
        string infiniburn = infiniburnTag?.GetString() ?? "#";
        
        ct.ChildrenMap.TryGetValue("effects", out INbtTag? effectsTag);
        string effects = effectsTag?.GetString() ?? "minecraft:overworld";
        
        ct.ChildrenMap.TryGetValue("ambient_light", out INbtTag? ambientLightTag);
        float ambientLight = ambientLightTag?.GetFloat() ?? 0.0f;
        
        ct.ChildrenMap.TryGetValue("piglin_safe", out INbtTag? piglinSafeTag);
        bool piglinSafe = piglinSafeTag?.GetBoolean() ?? true;
        
        ct.ChildrenMap.TryGetValue("has_raids", out INbtTag? hasRaidsTag);
        bool hasRaids = hasRaidsTag?.GetBoolean() ?? true;
        
        ct.ChildrenMap.TryGetValue("monster_spawn_light_level", out INbtTag? monsterSpawnLightLevelTag);
        Or<int, CompoundTag>? monsterSpawnLightLevel = null;
        
        if (monsterSpawnLightLevelTag is IntegerTag intTag) {
            monsterSpawnLightLevel = new Or<int, CompoundTag>(intTag.GetInteger());
        }
        else if (monsterSpawnLightLevelTag is CompoundTag compoundTag) {
            monsterSpawnLightLevel = new Or<int, CompoundTag>(compoundTag);
        }
        
        ct.ChildrenMap.TryGetValue("monster_spawn_block_light_limit", out INbtTag? monsterSpawnBlockLightLimitTag);
        int monsterSpawnBlockLightLimit = monsterSpawnBlockLightLimitTag?.GetInteger() ?? 0;
        
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
