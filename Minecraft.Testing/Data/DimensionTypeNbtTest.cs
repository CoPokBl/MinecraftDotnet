using Minecraft.Data.DimensionType;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Testing.Data;

public class DimensionTypeNbtTest {

    // The client refuses to load the registry if any of these are missing, and it fails
    // during configuration with a registry error rather than anything obviously protocol
    // related, so it is worth pinning them down.
    private static readonly string[] RequiredKeys = [
        "has_skylight", "has_ceiling", "coordinate_scale", "min_y", "height", "logical_height",
        "infiniburn", "ambient_light", "monster_spawn_light_level", "monster_spawn_block_light_limit",
        "has_ender_dragon_fight"
    ];

    // VanillaRegistry and the generated data classes initialise each other, so whichever one
    // is touched first decides whether initialisation succeeds. Touching the registry up front
    // keeps these tests independent of the order NUnit happens to run them in.
    [OneTimeSetUp]
    public void InitialiseRegistry() {
        _ = VanillaRegistry.Data;
    }

    [Test]
    public void TestVanillaDimensionTypesHaveRequiredKeys() {
        foreach (Identifier id in VanillaRegistry.Data.DimensionTypes.Identifiers) {
            IDimensionType dimension = VanillaRegistry.Data.DimensionTypes[id];
            CompoundTag nbt = (CompoundTag)dimension.ToNbt();
            foreach (string key in RequiredKeys) {
                Assert.That(nbt.Contains(key), Is.True,
                    $"Dimension type {dimension.Identifier} is missing required key '{key}'");
            }
        }
    }

    [Test]
    public void TestEnderDragonFightRoundTrips() {
        CompoundTag end = (CompoundTag)DimensionType.TheEnd.ToNbt();
        CompoundTag overworld = (CompoundTag)DimensionType.Overworld.ToNbt();

        Assert.Multiple(() => {
            Assert.That(end["has_ender_dragon_fight"].GetBoolean(), Is.True);
            Assert.That(overworld["has_ender_dragon_fight"].GetBoolean(), Is.False);
        });
    }

    [Test]
    public void TestDefaultClockIsWrittenWhenPresent() {
        CompoundTag overworld = (CompoundTag)DimensionType.Overworld.ToNbt();

        Assert.That(overworld.Contains("default_clock"), Is.True);
        Assert.That(overworld["default_clock"].GetString(), Is.EqualTo("minecraft:overworld"));
    }
}
