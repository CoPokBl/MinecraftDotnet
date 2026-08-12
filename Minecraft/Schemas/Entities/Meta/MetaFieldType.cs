namespace Minecraft.Schemas.Entities.Meta;

/// <summary>
/// Ids are positions in vanilla's <c>EntityDataSerializers</c> registry, which is filled in
/// the order its <c>registerSerializer</c> calls run:
/// <code>
/// javap -p -c -constants -cp versions/&lt;version&gt;/server-&lt;version&gt;.jar \
///     net.minecraft.network.syncher.EntityDataSerializers
/// </code>
/// A serializer added in the middle shifts everything after it, so re-derive the whole list on
/// a version bump rather than appending.
/// </summary>
public enum MetaFieldType {
    Byte = 0,
    VarInt = 1,
    VarLong = 2,
    Float = 3,
    String = 4,
    TextComponent = 5,
    OptionalTextComponent = 6,
    Slot = 7,
    Boolean = 8,
    Rotations = 9,
    Position = 10,
    OptionalPosition = 11,
    Direction = 12,
    OptionalLivingEntityReference = 13,
    BlockState = 14,
    OptionalBlockState = 15,
    Particle = 16,
    Particles = 17,
    VillagerData = 18,
    OptionalVarInt = 19,
    Pose = 20,
    CatVariant = 21,
    CatSoundVariant = 22,
    CowVariant = 23,
    CowSoundVariant = 24,
    WolfVariant = 25,
    WolfSoundVariant = 26,
    FrogVariant = 27,
    PigVariant = 28,
    PigSoundVariant = 29,
    ChickenVariant = 30,
    ChickenSoundVariant = 31,
    ZombieNautilusVariant = 32,
    OptionalGlobalPosition = 33,
    PaintingVariant = 34,
    SnifferState = 35,
    ArmadilloState = 36,
    CopperGolemState = 37,
    WeatheringCopperState = 38,
    Vector3 = 39,
    Quaternion = 40,
    ResolvableProfile = 41,
    HumanoidArm = 42
}
