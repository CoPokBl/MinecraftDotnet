using System.Collections.Concurrent;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Placement.Rules;

namespace Minecraft.Placement;

/// <summary>
/// Every placement rule that comes with the game, one per vanilla block class that overrides
/// something.
/// <p/>
/// A block whose class is not here places its default state and reacts to nothing, which is exactly
/// what <c>Block.getStateForPlacement</c> and the default <c>updateShape</c> do, so an unlisted
/// block is correct rather than merely unimplemented.
/// <p/>
/// Coverage is measured against the jar, over all four hooks rather than
/// <c>getStateForPlacement</c> alone: 113 classes declare that one, 63 override <c>canSurvive</c>
/// and 109 override <c>updateShape</c>, for 148 classes with a hook between them. Every one of them
/// is either in this list or in the list below.
/// <p/>
/// <b>Deliberately not transcribed</b>, with the reason each time:
/// <list type="bullet">
/// <item><c>Block</c> and <c>BlockBehaviour</c>: the defaults every unlisted block already gets.</item>
/// <item><c>RedStoneWireBlock</c>: needs the redstone engine. It is the only class that overrides
/// <c>updateIndirectNeighbourShapes</c>, which is not ported for the same reason.</item>
/// <item><c>BaseFireBlock</c>, <c>FireBlock</c>, <c>SoulFireBlock</c>, <c>PistonHeadBlock</c>,
/// <c>BubbleColumnBlock</c>, <c>LiquidBlock</c>: no item places any of them, so no placement path
/// reaches their rules. Fire also needs the flammability table, which is bootstrap code rather than
/// data.</item>
/// <item><c>FallingBlock</c>, <c>BrushableBlock</c>, <c>CoralBlock</c>, <c>SignBlock</c>,
/// <c>LightBlock</c>: their whole override is <c>scheduleTick</c>, and the state they return is the
/// one they were given. There is no block tick scheduler, so writing the rule would add nothing and
/// leaving it out is the same answer.</item>
/// <item><c>FlowerPotBlock</c>: overrides <c>updateShape</c> to break when it cannot survive, and
/// never overrides <c>canSurvive</c>, so the branch can never be taken.</item>
/// <item><c>NetherPortalBlock</c>: needs <c>PortalShape</c>, and there are no portals.</item>
/// <item><c>TestBlock</c>: reads the <c>block_state</c> item component, which the place path applies
/// after writing in any case.</item>
/// <item><c>CoralPlantBlock</c>, <c>CoralFanBlock</c>,
/// <c>CoralWallFanBlock</c>, <c>KelpBlock</c>, <c>GrowingPlantBlock</c>: their override is the
/// parent's answer plus a scheduled tick, so the chain resolving to the parent's rule is right
/// rather than approximate.</item>
/// </list>
/// </summary>
public static class VanillaPlacementRules {
    public static IReadOnlyList<IBlockPlacementRule> All { get; } = [
        // Half from the click point.
        new StairPlacementRule(),
        new SlabPlacementRule(),
        new TrapDoorPlacementRule(),

        // Axis from the clicked face.
        new RotatedPillarPlacementRule(),

        // The attachment search.
        new FaceAttachedPlacementRule(),
        new WallTorchPlacementRule(),
        new RedstoneWallTorchPlacementRule(),
        new LadderPlacementRule(),

        // Two cell blocks.
        new DoorPlacementRule(),
        new BedPlacementRule(),
        new DoublePlantPlacementRule(),

        new FenceGatePlacementRule(),

        // Connections.
        new FencePlacementRule(),
        new IronBarsPlacementRule(),
        new WallPlacementRule(),

        // Stacking in place.
        new CandlePlacementRule(),
        new SeaPicklePlacementRule(),
        new TurtleEggPlacementRule(),
        new FlowerBedPlacementRule(),
        new LeafLitterPlacementRule(),
        new SnowLayerPlacementRule(),

        // Turned to sixteen steps, and the wall mounted variants.
        new StandingSignPlacementRule(),
        new BannerPlacementRule(),
        new SkullPlacementRule(),
        new WallBannerPlacementRule(),
        new WallSkullPlacementRule(),
        new LanternPlacementRule(),
        new CocoaPlacementRule(),

        // Wall mounted signs, and the rest of the common blocks.
        new WallSignPlacementRule(),
        new WallHangingSignPlacementRule(),
        new ChainPlacementRule(),
        new LightningRodPlacementRule(),
        new HopperPlacementRule(),
        new WaterloggedTransparentPlacementRule(),
        new BaseRailPlacementRule(),

        // Horizontal facing, towards the placer.
        new AnvilPlacementRule(),
        new BellPlacementRule(),
        new CampfirePlacementRule(),
        new DecoratedPotPlacementRule(),

        // Horizontal facing, away from the placer.
        new AbstractFurnacePlacementRule(),
        new BeehivePlacementRule(),
        new CarvedPumpkinPlacementRule(),
        new ChiseledBookShelfPlacementRule(),
        new CopperGolemStatuePlacementRule(),
        new CrafterPlacementRule(),
        new DiodePlacementRule(),
        new DriedGhastPlacementRule(),
        new EnderChestPlacementRule(),
        new EndPortalFramePlacementRule(),
        new GlazedTerracottaPlacementRule(),
        new JigsawPlacementRule(),
        new LecternPlacementRule(),
        new LoomPlacementRule(),
        new ShelfPlacementRule(),
        new StonecutterPlacementRule(),
        new VaultPlacementRule(),

        // Nothing but the waterlog line.
        new BarrierPlacementRule(),
        new ConduitPlacementRule(),
        new HeavyCorePlacementRule(),
        new MangroveRootsPlacementRule(),
        new SculkSensorPlacementRule(),
        new CalibratedSculkSensorPlacementRule(),
        new SculkShriekerPlacementRule(),

        // A state read straight off the neighbours.
        new InfestedRotatedPillarPlacementRule(),
        new RedstoneLampPlacementRule(),
        new SnowyPlacementRule(),
        new NoteBlockPlacementRule(),
        new HugeMushroomPlacementRule(),
        new TripWirePlacementRule(),
        new CreakingHeartPlacementRule(),
        new PotentSulfurPlacementRule(),
        new LeavesPlacementRule(),
        new DirtPathPlacementRule(),
        new FarmlandPlacementRule(),
        new ConcretePowderPlacementRule(),

        // Attached to a wall or a ceiling.
        new CeilingHangingSignPlacementRule(),
        new TripWireHookPlacementRule(),
        new BaseCoralPlantTypePlacementRule(),
        new BaseCoralWallFanPlacementRule(),
        new HangingRootsPlacementRule(),

        // Held up by what is under, over or beside them.
        new BaseTorchPlacementRule(),
        new BasePressurePlatePlacementRule(),
        new CarpetPlacementRule(),
        new CakePlacementRule(),
        new CandleCakePlacementRule(),
        new GrindstonePlacementRule(),
        new CactusPlacementRule(),
        new SugarCanePlacementRule(),
        new SporeBlossomPlacementRule(),
        new HangingMossPlacementRule(),
        new FrogspawnPlacementRule(),
        new ChorusFlowerPlacementRule(),
        new BambooSaplingPlacementRule(),
        new BigDripleafStemPlacementRule(),

        // The VegetationBlock family, which differs in mayPlaceOn rather than canSurvive.
        new VegetationPlacementRule(),
        new CropPlacementRule(),
        new MushroomPlacementRule(),
        new AzaleaPlacementRule(),
        new DryVegetationPlacementRule(),
        new NetherSproutsPlacementRule(),
        new NetherWartPlacementRule(),
        new WitherRosePlacementRule(),
        new SeagrassPlacementRule(),
        new TallSeagrassPlacementRule(),
        new LilyPadPlacementRule(),
        new CactusFlowerPlacementRule(),
        new GrownFromTagPlacementRule(BlockClass.StemBlock),
        new AttachedStemPlacementRule(),
        new GrownFromTagPlacementRule(BlockClass.NetherFungusBlock),
        new GrownFromTagPlacementRule(BlockClass.NetherRootsBlock),

        // Faces of the same cell.
        new MultifacePlacementRule(),
        new VinePlacementRule(),
        new MossyCarpetPlacementRule(),
        new ChorusPlantPlacementRule(),

        // Plants that grow from a tip.
        new GrowingPlantPlacementRule(BlockClass.GrowingPlantHeadBlock),
        new GrowingPlantPlacementRule(BlockClass.GrowingPlantBodyBlock),
        new BambooStalkPlacementRule(),
        new MangrovePropagulePlacementRule(),
        new BigDripleafPlacementRule(),
        new SmallDripleafPlacementRule(),
        new PitcherCropPlacementRule(),

        // The stateful one offs.
        new SpeleothemPlacementRule(),
        new ScaffoldingPlacementRule(),
        new ChestPlacementRule(),
        new CopperChestPlacementRule(),
        new RepeaterPlacementRule(),
        new ComparatorPlacementRule(),

        // Six way facing.
        new PistonBasePlacementRule(),
        new DispenserPlacementRule(),
        new ObserverPlacementRule(),
        new BarrelPlacementRule(),
        new CommandPlacementRule(),
        new EndRodPlacementRule(),
        new ShulkerBoxPlacementRule(),
        new AmethystClusterPlacementRule()
    ];

    /// <summary>
    /// The vanilla set without the named classes, for a consumer who wants most of it and their own
    /// answer for the rest. Registering a replacement afterwards works too and is reversible, but
    /// leaving ours out entirely is clearer when there is no intention of ever going back.
    /// </summary>
    public static IReadOnlyList<IBlockPlacementRule> Except(params BlockClass[] classes) {
        return All.Where(rule => !classes.Contains(rule.VanillaClass)).ToArray();
    }

    /// <summary>
    /// Only the named classes, for a consumer who wants a handful of vanilla's answers and nothing
    /// else. A class with no rule is not an error, it is a block that places its default state.
    /// </summary>
    public static IReadOnlyList<IBlockPlacementRule> Only(params BlockClass[] classes) {
        return All.Where(rule => classes.Contains(rule.VanillaClass)).ToArray();
    }

    private static readonly ConcurrentDictionary<Identifier, IBlockPlacementRule?> Resolved = new();

    /// <summary>
    /// The rule from the whole set for a block, nearest class first, which is the answer a vanilla
    /// client always has.
    /// </summary>
    public static IBlockPlacementRule? For(IBlock block) {
        return Resolved.GetOrAdd(block.Identifier, id => {
            foreach (BlockClass className in BlockClasses.Of(id)) {
                if (All.FirstOrDefault(rule => rule.VanillaClass == className) is { } rule) {
                    return rule;
                }
            }
            return null;
        });
    }
}
