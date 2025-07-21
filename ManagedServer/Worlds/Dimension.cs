using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace ManagedServer.Worlds;

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
}
