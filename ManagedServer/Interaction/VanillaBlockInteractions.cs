using ManagedServer.Interaction.Rules;
using Minecraft.Data.Generated;

namespace ManagedServer.Interaction;

/// <summary>
/// Every block interaction rule that comes with the game, one per vanilla block class that overrides
/// <c>useItemOn</c> or <c>useWithoutItem</c>.
/// <p/>
/// A block whose class is not here does nothing when it is clicked and the click falls through to
/// the held item, which is exactly what <c>BlockBehaviour</c>'s two default bodies do, so an unlisted
/// block is correct rather than merely unimplemented.
/// <p/>
/// Coverage is measured against the jar: <b>64</b> block classes override at least one of the two
/// hooks (18 override <c>useItemOn</c>, 55 override <c>useWithoutItem</c>, 9 override both). Every
/// one of them is either in this list or in the list below.
/// <p/>
/// The seven transcribed here are the whole of what is reachable without a subsystem that does not
/// exist yet, and between them they cover 76 blocks. The rest are grouped by what they are waiting
/// for, so the list shortens as those land rather than needing to be re-derived.
/// <p/>
/// <b>Deliberately not transcribed</b>, with the reason each time:
/// <list type="bullet">
/// <item><b>Needs block entity behaviour</b> (28 classes): <c>ChestBlock</c>, <c>EnderChestBlock</c>,
/// <c>BarrelBlock</c>, <c>ShulkerBoxBlock</c>, <c>HopperBlock</c>, <c>DispenserBlock</c>,
/// <c>CrafterBlock</c>, <c>AbstractFurnaceBlock</c>, <c>BrewingStandBlock</c>, <c>LecternBlock</c>,
/// <c>JukeboxBlock</c>, <c>BeehiveBlock</c>, <c>DecoratedPotBlock</c>, <c>ChiseledBookShelfBlock</c>,
/// <c>SignBlock</c>, <c>CeilingHangingSignBlock</c>, <c>WallHangingSignBlock</c>,
/// <c>CampfireBlock</c>, <c>BellBlock</c>, <c>VaultBlock</c>, <c>ShelfBlock</c>,
/// <c>CopperGolemStatueBlock</c>, <c>WeatheringCopperGolemStatueBlock</c>, <c>CommandBlock</c>,
/// <c>StructureBlock</c>, <c>JigsawBlock</c>, <c>TestBlock</c>, <c>TestInstanceBlock</c>. Almost all
/// of them are <c>getMenuProvider</c> then <c>openMenu</c>. <c>Minecraft/Schemas/Chunks/BlockEntity.cs</c>
/// is the wire record sent with chunk data and carries no contents and no menu, so there is nothing
/// to open. This is why a minigame wanting a working chest supplies its own, as
/// <c>SkyWarsChestsFeature</c> does, and why the spectator branch of
/// <see cref="BlockInteraction.UseItemOn"/> is a comment.</item>
/// <item><b>Needs a container menu with server side logic</b> (9 classes):
/// <c>CraftingTableBlock</c>, <c>AnvilBlock</c>, <c>GrindstoneBlock</c>, <c>LoomBlock</c>,
/// <c>SmithingTableBlock</c>, <c>StonecutterBlock</c>, <c>CartographyTableBlock</c>,
/// <c>EnchantingTableBlock</c>, <c>BeaconBlock</c>. These need no block entity, but opening the
/// screen without the recipe handling behind it would be a window that does nothing.</item>
/// <item><b>Needs redstone or a block tick scheduler</b>: <c>RepeaterBlock</c> and
/// <c>ComparatorBlock</c> (both cycle a state and then schedule the tick that is the actual
/// behaviour; their <c>delay</c> and <c>mode</c> properties also have no generated interface yet),
/// <c>DaylightDetectorBlock</c>, <c>RedStoneWireBlock</c>, <c>RedStoneOreBlock</c>.</item>
/// <item><b>Needs a loot table outside <c>blocks/</c></b>: <c>SweetBerryBushBlock</c>,
/// <c>PumpkinBlock</c>, <c>CaveVinesBlock</c> and <c>CaveVinesPlantBlock</c> all harvest through
/// <c>dropFromBlockInteractLootTable</c> against <c>BuiltInLootTables.HARVEST_SWEET_BERRY_BUSH</c> or
/// <c>CARVE_PUMPKIN</c>. <c>LootTableCodeGen</c> only generates
/// <c>data/minecraft/loot_table/blocks/</c>, so those tables do not exist here. The rules are a small
/// generator change away rather than a subsystem away.</item>
/// <item><b>Needs another table that is a constructor argument or bootstrap data</b>:
/// <c>ComposterBlock</c> (the <c>COMPOSTABLES</c> map), <c>FlowerPotBlock</c> (which pot holds which
/// plant), <c>NoteBlock</c> (instrument resolution), <c>AbstractCauldronBlock</c> (the item to fluid
/// interaction matrix).</item>
/// <item><b>Needs another missing subsystem</b>, one each: <c>BedBlock</c> (sleeping),
/// <c>FenceBlock</c> (leads), <c>TntBlock</c> (a primed TNT entity), <c>CakeBlock</c> and
/// <c>CandleCakeBlock</c> (eating, through <c>CakeBlock.eat</c>), <c>RespawnAnchorBlock</c> (spawn
/// points), <c>LightBlock</c> (a creative only screen).</item>
/// </list>
/// </summary>
public static class VanillaBlockInteractions {
    public static IReadOnlyList<IBlockInteractionRule> All { get; } = [
        // The state togglers. All five are useWithoutItem, so none of them fires for an offhand
        // click or while crouching with a full hand.
        new DoorInteractionRule(),
        new TrapDoorInteractionRule(),
        new FenceGateInteractionRule(),
        new LeverInteractionRule(),
        new ButtonInteractionRule(),

        // The two that are not about opening something.
        new CandleInteractionRule(),
        new DragonEggInteractionRule()
    ];

    /// <summary>
    /// Everything but the named classes, for a consumer who wants vanilla's answers except for the
    /// blocks their own game redefines.
    /// </summary>
    public static IReadOnlyList<IBlockInteractionRule> Except(params BlockClass[] classes) {
        return All.Where(rule => !classes.Contains(rule.VanillaClass)).ToArray();
    }

    /// <summary>
    /// Only the named classes, for a consumer who wants a handful of vanilla's answers and nothing
    /// else.
    /// </summary>
    public static IReadOnlyList<IBlockInteractionRule> Only(params BlockClass[] classes) {
        return All.Where(rule => classes.Contains(rule.VanillaClass)).ToArray();
    }
}
