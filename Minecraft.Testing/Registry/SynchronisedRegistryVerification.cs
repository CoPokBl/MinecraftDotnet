using Minecraft.Data.Generated;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Testing.Registry;

/// <summary>
/// Checks the registries the client synchronises are all there and all populated.
/// </summary>
/// <remarks>
/// An empty one gets past everything else. The code compiles, the packet serialises, and the
/// conformance harness has no elements to disagree with, but the client throws
/// <c>Unbound values in registry ...</c> at the end of configuration as soon as anything
/// references an entry that never arrived. Dropping a <c>RunDynamicRegistry</c> line from
/// <c>CodeGen/Program.cs</c> is all it takes.
/// </remarks>
public class SynchronisedRegistryVerification {

    /// <summary>
    /// <c>RegistryDataLoader.SYNCHRONIZED_REGISTRIES</c> in the server jar. Re-check it on every
    /// version bump:
    /// <code>
    /// javap -p -c -constants -cp versions/&lt;version&gt;/server-&lt;version&gt;.jar \
    ///     net.minecraft.resources.RegistryDataLoader
    /// </code>
    /// </summary>
    private static readonly Identifier[] SynchronisedRegistries = [
        "minecraft:worldgen/biome",
        "minecraft:chat_type",
        "minecraft:trim_pattern",
        "minecraft:trim_material",
        "minecraft:wolf_variant",
        "minecraft:wolf_sound_variant",
        "minecraft:pig_variant",
        "minecraft:pig_sound_variant",
        "minecraft:frog_variant",
        "minecraft:cat_variant",
        "minecraft:cat_sound_variant",
        "minecraft:cow_variant",
        "minecraft:cow_sound_variant",
        "minecraft:chicken_variant",
        "minecraft:chicken_sound_variant",
        "minecraft:zombie_nautilus_variant",
        "minecraft:painting_variant",
        "minecraft:sulfur_cube_archetype",
        "minecraft:dimension_type",
        "minecraft:damage_type",
        "minecraft:banner_pattern",
        "minecraft:enchantment",
        "minecraft:jukebox_song",
        "minecraft:instrument",
        "minecraft:test_environment",
        "minecraft:test_instance",
        "minecraft:dialog",
        "minecraft:world_clock",
        "minecraft:timeline",
        "minecraft:decorated_pot_pattern",
        "minecraft:block_transformer",
        "minecraft:worldgen/block_state_provider"
    ];

    [Test]
    public void EverySynchronisedRegistryIsPopulated() {
        Assert.Multiple(() => {
            foreach (Identifier id in SynchronisedRegistries) {
                ISubRegistry registry;
                try {
                    registry = VanillaRegistry.Data[id];
                }
                catch (KeyNotFoundException) {
                    Assert.Fail($"No registry for {id}, which the client synchronises");
                    continue;
                }

                Assert.That(registry, Is.InstanceOf<INbtSerialisableRegistry>(),
                    $"{id} is synchronised, so it has to be able to write itself as NBT");
                Assert.That(((IProtocolTypeRegistry)registry).Count, Is.GreaterThan(0),
                    $"{id} is empty, so the client would reject the connection. Check it still has " +
                    "a RunDynamicRegistry line in CodeGen/Program.cs.");
            }
        });
    }

    /// <summary>
    /// The client throws away element data for a registry it doesn't synchronise, then fails to
    /// bind the tags that travelled with it, so sending a spare one isn't harmless.
    /// </summary>
    [Test]
    public void NothingElseIsSentAsNbt() {
        HashSet<string> expected = SynchronisedRegistries.Select(id => id.ToString()).ToHashSet();

        Assert.Multiple(() => {
            foreach (ISubRegistry registry in VanillaRegistry.Data.SubRegistries) {
                if (registry is INbtSerialisableRegistry) {
                    Assert.That(expected, Does.Contain(registry.RegistryId.ToString()),
                        $"{registry.RegistryId} would be sent during configuration, but the client " +
                        "doesn't synchronise it");
                }
            }
        });
    }
}
