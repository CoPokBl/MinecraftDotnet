using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace ClientLib;

public record Dimension(
    bool HasFixedTime = false,
    bool HasSkyLight = true, 
    bool HasCeiling = false, 
    double CoordinateScale = 1.0,
    int MinY = -64,
    int Height = 384,
    int LogicalHeight = 256,
    string InfiniBurn = "#",
    string Skybox = "overworld",
    string CardinalLight = "default",
    float AmbientLight = 0.0f,
    Or<int, CompoundTag>? MonsterSpawnLightLevel = null,
    int MonsterSpawnBlockLightLimit = 0,
    CompoundTag? Attributes = null,
    INbtTag? Timelines = null) {

    public INbtTag ToNbt() {
        List<INbtTag?> children = [];
        
        children.Add(new BooleanTag("has_fixed_time", HasFixedTime));
        children.Add(new BooleanTag("has_skylight", HasSkyLight));
        children.Add(new BooleanTag("has_ceiling", HasCeiling));
        children.Add(new DoubleTag("coordinate_scale", CoordinateScale));
        children.Add(new IntegerTag("min_y", MinY));
        children.Add(new IntegerTag("height", Height));
        children.Add(new IntegerTag("logical_height", LogicalHeight));
        children.Add(new StringTag("infiniburn", InfiniBurn));
        children.Add(new StringTag("skybox", Skybox));
        children.Add(new StringTag("cardinal_light", CardinalLight));
        children.Add(new FloatTag("ambient_light", AmbientLight));
        
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
    
    public static Dimension FromNbt(INbtTag tag) {
        if (tag is not CompoundTag ct) {
            throw new ArgumentException("Expected a CompoundTag for Dimension");
        }
        
        ct.ChildrenMap.TryGetValue("has_fixed_time", out INbtTag? hasFixedTimeTag);
        bool hasFixedTime = hasFixedTimeTag?.GetBoolean() ?? false;
        
        ct.ChildrenMap.TryGetValue("has_skylight", out INbtTag? hasSkyLightTag);
        bool hasSkyLight = hasSkyLightTag?.GetBoolean() ?? true;
        
        ct.ChildrenMap.TryGetValue("has_ceiling", out INbtTag? hasCeilingTag);
        bool hasCeiling = hasCeilingTag?.GetBoolean() ?? false;
        
        ct.ChildrenMap.TryGetValue("coordinate_scale", out INbtTag? coordinateScaleTag);
        double coordinateScale = coordinateScaleTag?.GetDouble() ?? 1.0;
        
        ct.ChildrenMap.TryGetValue("min_y", out INbtTag? minYTag);
        int minY = minYTag?.GetInteger() ?? -64;
        
        ct.ChildrenMap.TryGetValue("height", out INbtTag? heightTag);
        int height = heightTag?.GetInteger() ?? 384;
        
        ct.ChildrenMap.TryGetValue("logical_height", out INbtTag? logicalHeightTag);
        int logicalHeight = logicalHeightTag?.GetInteger() ?? 256;
        
        ct.ChildrenMap.TryGetValue("infiniburn", out INbtTag? infiniburnTag);
        string infiniburn = infiniburnTag?.GetString() ?? "#";
        
        ct.ChildrenMap.TryGetValue("skybox", out INbtTag? skyboxTag);
        string skybox = skyboxTag?.GetString() ?? "overworld";
        
        ct.ChildrenMap.TryGetValue("cardinal_light", out INbtTag? cardinalLightTag);
        string cardinalLight = cardinalLightTag?.GetString() ?? "default";
        
        ct.ChildrenMap.TryGetValue("ambient_light", out INbtTag? ambientLightTag);
        float ambientLight = ambientLightTag?.GetFloat() ?? 0.0f;
        
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
        
        ct.ChildrenMap.TryGetValue("attributes", out INbtTag? attributesTag);
        CompoundTag? attributes = attributesTag as CompoundTag;
        
        ct.ChildrenMap.TryGetValue("timelines", out INbtTag? timelines);
        
        return new Dimension(
            hasFixedTime,
            hasSkyLight,
            hasCeiling,
            coordinateScale,
            minY,
            height,
            logicalHeight,
            infiniburn,
            skybox,
            cardinalLight,
            ambientLight,
            monsterSpawnLightLevel,
            monsterSpawnBlockLightLimit,
            attributes,
            timelines);
    }
}
