using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace ManagedServer.Worlds;

public enum CardinalLight {
    Default,
    Nether,
}

public enum Skybox {
    None,
    Overworld,
    End
}

public record Dimension(
    bool HasFixedTime = false, 
    bool HasSkyLight = true, 
    bool HasCeiling = false,
    double CoordinateScale = 1.0,
    int MinY = -64,
    int Height = 384,
    int LogicalHeight = 256,
    string InfiniBurn = "#",
    Skybox Skybox = Skybox.Overworld,
    CardinalLight CardinalLight = CardinalLight.Default,
    float AmbientLight = 0.0f, 
    Or<int, CompoundTag>? MonsterSpawnLightLevel = null, 
    int MonsterSpawnBlockLightLimit = 0,
    CompoundTag? Attributes = null,
    INbtTag? Timelines = null
) {

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
}