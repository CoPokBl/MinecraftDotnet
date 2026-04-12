using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace ManagedServer.Worlds;

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
}
