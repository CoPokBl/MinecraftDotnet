using Minecraft.Data.Components;
using Minecraft.Data.Generated;
using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;

namespace Minecraft.Testing.Data.Components;

/// <summary>
/// Which components cannot be read or written as data, by name.
/// </summary>
/// <remarks>
/// Asserted as a set rather than a count, so a codec that stops being reachable is a failure here
/// rather than a component a datapack silently loses. Landing one means editing this list.
/// </remarks>
[TestFixture]
public class ComponentCodecCoverageTest {
    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    /// <summary>
    /// The three vanilla marks transient. Each is consumed where it is set and never written down,
    /// so there is nothing upstream to port rather than something missing here.
    /// </summary>
    [Test]
    public void OnlyTheTransientOnesHaveNoPersistentForm() {
        string[] absent = Registry.DataComponents.All
            .Where(component => !component.HasNbtForm)
            .Select(component => component.Identifier.ToString())
            .Order(StringComparer.Ordinal)
            .ToArray();

        Assert.That(absent, Is.EqualTo(new[] {
            "minecraft:additional_trade_cost",
            "minecraft:creative_slot_lock",
            "minecraft:map_post_processing"
        }));
    }

    /// <summary>Asking one for a value it has no form for names it rather than returning nothing.</summary>
    [Test]
    public void ATransientComponentRefusesByName() {
        IDataComponent component = Registry.DataComponents[(Minecraft.Schemas.Identifier)"minecraft:creative_slot_lock"];

        UnportedComponentException thrown = Assert.Throws<UnportedComponentException>(
            () => component.ToNbt(Minecraft.Schemas.None.Value, Registry))!;

        Assert.That(thrown.Component.ToString(), Is.EqualTo("minecraft:creative_slot_lock"));
    }
}
