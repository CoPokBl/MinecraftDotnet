using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.DimensionType;

public record SimpleDimensionType(
    Identifier Identifier,
    bool HasFixedTime,
    bool HasSkyLight,
    bool HasCeiling,
    double CoordinateScale,
    int MinY,
    int Height,
    int LogicalHeight,
    string InfiniBurn,
    Skybox Skybox,
    CardinalLight CardinalLight,
    float AmbientLight,
    Or<int, CompoundTag>? MonsterSpawnLightLevel,
    int MonsterSpawnBlockLightLimit,
    CompoundTag? Attributes,
    INbtTag? Timelines) : IDimensionType;
