using ManagedServer.Fluids;
using Minecraft.Placement.Helpers;
using Minecraft.Placement.Rules;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;
using Minecraft.Fluids;

namespace ManagedServer.Terrain.Features.Blocks;

/// <summary>
/// <c>BlockState.canSurvive</c>, for the blocks the vanilla worldgen data asks about.
/// </summary>
/// <remarks>
/// The <c>would_survive</c> block predicate is what stops a tree being planted on stone and sugar cane
/// on dry sand, so it has to be real rather than permissive. It cannot be
/// <c>BlockPlacementRules</c>: those hooks take a <c>World</c>, and a generator has none, so this is a
/// second transcription of the same vanilla methods against <see cref="IFeatureLevel"/>.
/// <p/>
/// Resolution walks <c>BlockClasses.Of</c> <b>nearest first</b>, as Java's own dispatch does, so a
/// sapling reaches <c>VegetationBlock</c> through its own class while the mangrove propagule and tall
/// seagrass reach their own overrides first. Adding a class means adding a branch here; the order of
/// the branches does not matter, only that each class has one.
/// <p/>
/// The <c>would_survive</c> predicate is not the only caller. Several features place their own
/// vegetation and ask directly, which is why this covers seagrass, kelp, sea pickles, bamboo and the
/// nether plants beyond the twelve states the data names.
/// <p/>
/// Where a per block value is a <b>constructor argument</b> in <c>Blocks.java</c> the table the
/// placement rules already keep is the one to read: <c>GrowingPlantPlacementRule.Families</c> for
/// which way kelp grows, <c>GrownFromTagPlacementRule.Tags</c> for what a nether fungus grows on. A
/// second copy here would be a second thing to update, and <c>VegetationSupportTableTest</c> only
/// covers the first.
/// <p/>
/// Anything else answers <b>true</b>, which is <c>BlockBehaviour.canSurvive</c>'s own body. A block
/// with no survival rule really does survive anywhere.
/// </remarks>
public static class FeatureSurvival {
    private static readonly Identifier SupportsVegetation = "minecraft:supports_vegetation";
    private static readonly Identifier SupportsMangrovePropagule = "minecraft:supports_mangrove_propagule";
    private static readonly Identifier SupportsHangingMangrovePropagule =
        "minecraft:supports_hanging_mangrove_propagule";
    private static readonly Identifier SupportsSugarCane = "minecraft:supports_sugar_cane";
    private static readonly Identifier SupportsSugarCaneAdjacently = "minecraft:supports_sugar_cane_adjacently";
    private static readonly Identifier SupportsCactus = "minecraft:supports_cactus";
    private static readonly Identifier CannotSupportSnowLayer = "minecraft:cannot_support_snow_layer";
    private static readonly Identifier SupportOverrideSnowLayer = "minecraft:support_override_snow_layer";
    private static readonly Identifier CannotSupportSeagrass = "minecraft:cannot_support_seagrass";
    private static readonly Identifier SupportsBamboo = "minecraft:supports_bamboo";
    private static readonly Identifier SupportsLilyPad = "minecraft:supports_lily_pad";
    private static readonly Identifier OverridesMushroomLight =
        "minecraft:overrides_mushroom_light_requirement";
    private static readonly Identifier UnstableBottomCenter = "minecraft:unstable_bottom_center";
    private static readonly Identifier CannotSupportKelp = "minecraft:cannot_support_kelp";
    private static readonly Identifier KelpHead = "minecraft:kelp";
    private static readonly Identifier SupportsNetherSprouts = "minecraft:supports_nether_sprouts";
    private static readonly Identifier SupportsSmallDripleaf = "minecraft:supports_small_dripleaf";

    /// <summary>
    /// The <c>VegetationBlock</c> subclasses whose <c>mayPlaceOn</c> is one tag test, and the tag.
    /// </summary>
    /// <remarks>
    /// One line of <c>canSurvive</c> is inherited by every plant and each subclass overrides only the
    /// tag it asks about, so collapsing the family onto <c>supports_vegetation</c> is permissive for
    /// some and refuses everything for others: a dead bush grows on sand and red sand, which that tag
    /// does not hold, so it can never be placed at all.
    /// <p/>
    /// Walked nearest first with the class chain, so the most derived entry wins. Same tags as
    /// <c>TagVegetationPlacementRule</c>'s subclasses, which is the placement half of the same rule.
    /// </remarks>
    private static readonly Dictionary<BlockClass, Identifier> VegetationTags = new() {
        [BlockClass.CropBlock] = "minecraft:supports_crops",
        [BlockClass.AzaleaBlock] = "minecraft:supports_azalea",
        [BlockClass.DryVegetationBlock] = "minecraft:supports_dry_vegetation",
        [BlockClass.NetherWartBlock] = "minecraft:supports_nether_wart",
        [BlockClass.WitherRoseBlock] = "minecraft:supports_wither_rose",
        [BlockClass.VegetationBlock] = SupportsVegetation
    };

    public static bool CanSurvive(IBlock block, IFeatureLevel level, int x, int y, int z) {
        foreach (BlockClass vanillaClass in BlockClasses.Of(block.Identifier)) {
            if (vanillaClass == BlockClass.MangrovePropaguleBlock) {
                return MangrovePropagule(block, level, x, y, z);
            }

            if (vanillaClass == BlockClass.TallSeagrassBlock) {
                return TallSeagrass(block, level, x, y, z);
            }

            if (vanillaClass == BlockClass.SeagrassBlock) {
                return MayPlaceSeagrassOn(level, x, y - 1, z);
            }

            if (vanillaClass == BlockClass.SeaPickleBlock) {
                return MayPlacePickleOn(level, x, y - 1, z);
            }

            if (vanillaClass == BlockClass.BambooStalkBlock) {
                return level.Blocks.IsIn(SupportsBamboo, level.GetState(x, y - 1, z));
            }

            if (vanillaClass == BlockClass.GrowingPlantBlock) {
                return GrowingPlant(block, level, x, y, z);
            }

            if (vanillaClass == BlockClass.NetherSproutsBlock) {
                return level.Blocks.IsIn(SupportsNetherSprouts, level.GetState(x, y - 1, z));
            }

            if (vanillaClass == BlockClass.NetherFungusBlock || vanillaClass == BlockClass.NetherRootsBlock
                || vanillaClass == BlockClass.StemBlock || vanillaClass == BlockClass.AttachedStemBlock) {

                return GrownFromTag(block, level, x, y, z);
            }

            if (vanillaClass == BlockClass.DoublePlantBlock) {
                return DoublePlant(block, level, x, y, z);
            }

            if (vanillaClass == BlockClass.SmallDripleafBlock) {
                return SmallDripleaf(block, level, x, y, z);
            }

            if (vanillaClass == BlockClass.LilyPadBlock) {
                return LilyPad(level, x, y, z);
            }

            if (vanillaClass == BlockClass.MushroomBlock) {
                return Mushroom(level, x, y, z);
            }

            if (vanillaClass == BlockClass.SporeBlossomBlock) {
                return SupportsCenter(level, x, y + 1, z)
                    && !FeatureFluids.IsWater(level, level.GetState(x, y, z));
            }

            if (vanillaClass == BlockClass.LeafLitterBlock) {
                return ShapeSupport.IsFaceSturdy(
                    level.Registry.Blocks.GetByStateId(level.GetState(x, y - 1, z)), BlockFace.PosY);
            }

            if (vanillaClass == BlockClass.MossyCarpetBlock) {
                return MossyCarpet(block, level, x, y, z);
            }

            // Below CarpetBlock's subclasses, since MossyCarpetBlock is one and asks a different
            // question of the same position.
            if (vanillaClass == BlockClass.CarpetBlock) {
                return !level.Blocks.IsAir(level.GetState(x, y - 1, z));
            }

            if (VegetationTags.TryGetValue(vanillaClass, out Identifier vegetationTag)) {
                // CropBlock's hasSufficientLight, getRawBrightness(pos, 0) >= 8, which the sky
                // answers alone while the pass runs.
                if (vanillaClass == BlockClass.CropBlock && !level.HasSkyLight) {
                    return false;
                }

                return level.Blocks.IsIn(vegetationTag, level.GetState(x, y - 1, z));
            }

            if (vanillaClass == BlockClass.SugarCaneBlock) {
                return SugarCane(block, level, x, y, z);
            }

            if (vanillaClass == BlockClass.CactusBlock) {
                return Cactus(block, level, x, y, z);
            }

            if (vanillaClass == BlockClass.SnowLayerBlock) {
                return SnowLayer(level, x, y, z);
            }
        }

        return true;
    }

    /// <summary>
    /// <c>MangrovePropaguleBlock.canSurvive</c>: a hanging propagule holds onto the block above it, a
    /// planted one onto the block below.
    /// </summary>
    private static bool MangrovePropagule(IBlock block, IFeatureLevel level, int x, int y, int z) {
        if (IsHanging(block)) {
            return level.Blocks.IsIn(SupportsHangingMangrovePropagule, level.GetState(x, y + 1, z));
        }

        return level.Blocks.IsIn(SupportsMangrovePropagule, level.GetState(x, y - 1, z));
    }

    /// <summary>
    /// <c>SugarCaneBlock.canSurvive</c>: on more sugar cane, or on ground with water beside that
    /// ground.
    /// </summary>
    /// <remarks>
    /// The four neighbours are checked at the level of the block <b>below</b>, not beside the cane
    /// itself, which is why cane grows one block up from a shoreline rather than in it.
    /// </remarks>
    private static bool SugarCane(IBlock block, IFeatureLevel level, int x, int y, int z) {
        uint below = level.GetState(x, y - 1, z);

        if (level.Registry.Blocks.GetByStateId(below).Identifier.Equals(block.Identifier)) {
            return true;
        }

        if (!level.Blocks.IsIn(SupportsSugarCane, below)) {
            return false;
        }

        foreach ((int dx, int dz) in Horizontal) {
            uint beside = level.GetState(x + dx, y - 1, z + dz);
            if (FeatureFluids.IsWater(level, beside) || level.Blocks.IsIn(SupportsSugarCaneAdjacently, beside)) {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// <c>CactusBlock.canSurvive</c>: nothing solid or burning beside it, sand or more cactus below,
    /// and no fluid directly above.
    /// </summary>
    private static bool Cactus(IBlock block, IFeatureLevel level, int x, int y, int z) {
        foreach ((int dx, int dz) in Horizontal) {
            uint neighbour = level.GetState(x + dx, y, z + dz);
            if (level.Blocks.IsSolid(neighbour) || FeatureFluids.IsLava(level, neighbour)) {
                return false;
            }
        }

        uint below = level.GetState(x, y - 1, z);
        bool supported = level.Registry.Blocks.GetByStateId(below).Identifier.Equals(block.Identifier)
            || level.Blocks.IsIn(SupportsCactus, below);

        return supported && !level.Registry.Blocks.GetByStateId(level.GetState(x, y + 1, z)).Liquid;
    }

    /// <summary>
    /// <c>SnowLayerBlock.canSurvive</c>: the two tags overrule the shape in both directions, and only
    /// what is left falls through to it.
    /// </summary>
    /// <remarks>
    /// The shape asked for is the <b>collision</b> shape, not the support shape every other attachment
    /// reads. That is why snow settles on leaves, which collide as a cube and support nothing.
    /// </remarks>
    private static bool SnowLayer(IFeatureLevel level, int x, int y, int z) {
        uint below = level.GetState(x, y - 1, z);

        if (level.Blocks.IsIn(CannotSupportSnowLayer, below)) {
            return false;
        }

        if (level.Blocks.IsIn(SupportOverrideSnowLayer, below)) {
            return true;
        }

        IBlock belowBlock = level.Registry.Blocks.GetByStateId(below);

        // A full stack of snow supports another layer, which is what lets snow build up on itself.
        // Only a full one: eight layers is a whole block, and fewer is not.
        if (belowBlock.Identifier.Equals(Block.Snow.Identifier)) {
            return belowBlock is IStackable stack && stack.Count == stack.MaxCount;
        }

        return ShapeSupport.IsFaceFull(belowBlock.CollisionShape, BlockFace.PosY);
    }

    /// <summary>
    /// <c>NetherRootsBlock</c>, <c>NetherFungusBlock</c> and the two stems: the tag they grow on is a
    /// constructor argument, so it is per block rather than per class.
    /// </summary>
    /// <remarks>
    /// The table is <c>GrownFromTagPlacementRule.Tags</c> rather than a second copy, and it is the one
    /// <c>VegetationSupportTableTest</c> already covers. An unknown member of the class falls back to
    /// the base answer rather than refusing, since a plant that can never be placed is the worse
    /// failure of the two.
    /// </remarks>
    private static bool GrownFromTag(IBlock block, IFeatureLevel level, int x, int y, int z) {
        uint below = level.GetState(x, y - 1, z);

        return GrownFromTagPlacementRule.Tags.TryGetValue(block.Identifier, out Identifier tag)
            ? level.Blocks.IsIn(tag, below)
            : level.Blocks.IsIn(SupportsVegetation, below);
    }

    /// <summary>
    /// <c>SeagrassBlock.mayPlaceOn</c>, which both seagrass blocks share.
    /// </summary>
    /// <remarks>
    /// A tag rather than a shape rules magma out, so seagrass will not grow on it even though it is a
    /// full cube.
    /// </remarks>
    /// <summary>
    /// <c>LilyPadBlock.mayPlaceOn</c>: a water source underneath, or one of the frozen surfaces the
    /// tag names, and nothing fluid in the pad's own cell.
    /// </summary>
    /// <remarks>
    /// The test is <c>getType() == Fluids.WATER</c>, which is the <b>source</b> fluid and not the
    /// <c>#water</c> kind, so a pad does not float on a flow. Reaching this through
    /// <c>VegetationBlock</c>'s inherited tag instead asks about <c>supports_vegetation</c>, which
    /// water is not in and dirt is, so every pad is refused over the lake and accepted on the bank.
    /// </remarks>
    private static bool LilyPad(IFeatureLevel level, int x, int y, int z) {
        uint below = level.GetState(x, y - 1, z);

        bool floats = FeatureFluids.IsWaterSource(level, below)
            || level.Blocks.IsIn(SupportsLilyPad, below);

        return floats && FeatureFluids.IsEmpty(level, level.GetState(x, y, z));
    }

    /// <summary>
    /// <c>MushroomBlock.canSurvive</c>: the tag outright, or a block that renders as a full cube
    /// under a position dark enough.
    /// </summary>
    /// <remarks>
    /// <b>The light term is the dimension's sky and nothing else.</b> A chunk reaches
    /// <c>INITIALIZE_LIGHT</c> after <c>FEATURES</c>, so while the pass runs no light section exists
    /// and <c>SkyLightSectionStorage.getLightValue</c> falls through to its default and answers 15 at
    /// every position, however deep. <c>getRawBrightness(pos, 0) &lt; 13</c> is therefore false
    /// wherever a feature asks under a sky, so there a mushroom grows on mycelium, podzol or nylium and
    /// nowhere else; in the nether there is no sky layer, the answer is 0, and any full block will do.
    /// <p/>
    /// That is not the approximation <c>MushroomPlacementRule</c> makes. A player places a block into
    /// a world whose light is real, so that rule errs permissive and this one does not.
    /// <p/>
    /// Reaching this through <c>VegetationBlock</c>'s inherited tag instead asks about
    /// <c>supports_vegetation</c>, which is a different set again.
    /// </remarks>
    private static bool Mushroom(IFeatureLevel level, int x, int y, int z) {
        uint below = level.GetState(x, y - 1, z);

        return level.Blocks.IsIn(OverridesMushroomLight, below)
            || (!level.HasSkyLight && level.Blocks.IsSolidRender(below));
    }

    /// <summary>
    /// <c>MossyCarpetBlock.canSurvive</c>: the base lies on anything that is not air, and the tuft
    /// that climbs a wall survives only while its own base is the block under it.
    /// </summary>
    private static bool MossyCarpet(IBlock block, IFeatureLevel level, int x, int y, int z) {
        uint below = level.GetState(x, y - 1, z);

        if (block is IBottomed { Bottom: true }) {
            return !level.Blocks.IsAir(below);
        }

        IBlock under = level.Registry.Blocks.GetByStateId(below);
        return under.Identifier.Equals(block.Identifier) && under is IBottomed { Bottom: true };
    }

    /// <summary>
    /// <c>Block.canSupportCenter</c>, which is the centre of a face and not the whole of it, with the
    /// tag that refuses an upward hang outright.
    /// </summary>
    private static bool SupportsCenter(IFeatureLevel level, int x, int y, int z) {
        uint state = level.GetState(x, y, z);

        if (level.Blocks.IsIn(UnstableBottomCenter, state)) {
            return false;
        }

        return ShapeSupport.IsFaceSturdy(level.Registry.Blocks.GetByStateId(state), BlockFace.NegY,
            SupportType.Center);
    }

    private static bool MayPlaceSeagrassOn(IFeatureLevel level, int x, int y, int z) {
        uint state = level.GetState(x, y, z);
        IBlock block = level.Registry.Blocks.GetByStateId(state);

        return ShapeSupport.IsFaceSturdy(block, BlockFace.PosY)
            && !level.Blocks.IsIn(CannotSupportSeagrass, state);
    }

    /// <summary>
    /// <c>TallSeagrassBlock.canSurvive</c>: the upper half holds onto the lower, and the lower needs
    /// ground plus a full block of water at its own position.
    /// </summary>
    private static bool TallSeagrass(IBlock block, IFeatureLevel level, int x, int y, int z) {
        if (block is IDoubleHalved { Half: BlockHalf.Upper }) {
            IBlock below = level.Registry.Blocks.GetByStateId(level.GetState(x, y - 1, z));
            return below.Identifier.Equals(block.Identifier)
                && below is IDoubleHalved { Half: BlockHalf.Lower };
        }

        FluidState fluid = FluidState.Of(level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)));
        return MayPlaceSeagrassOn(level, x, y - 1, z) && fluid.Kind == FluidKind.Water && fluid.Amount == 8;
    }

    /// <summary>
    /// <c>SeaPickleBlock.mayPlaceOn</c>: either shape reaching the boundary, not both.
    /// </summary>
    /// <remarks>
    /// The collision half asks only that the up face is <b>not empty</b>, so a fence post holds a sea
    /// pickle while a bottom slab, whose collision shape stops halfway, does not.
    /// </remarks>
    private static bool MayPlacePickleOn(IFeatureLevel level, int x, int y, int z) {
        IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z));

        return ShapeSupport.FaceShape(block.CollisionShape, BlockFace.PosY).Length > 0
            || ShapeSupport.IsFaceSturdy(block, BlockFace.PosY);
    }

    /// <summary>
    /// <c>GrowingPlantBlock.canSurvive</c>: held from behind by more of its own plant or by a sturdy
    /// face pointing the way it grows.
    /// </summary>
    /// <remarks>
    /// Which way a family grows is a constructor argument in <c>Blocks.java</c>, so the table is
    /// <c>GrowingPlantPlacementRule.Families</c> rather than a second copy here. Kelp's
    /// <c>canAttachTo</c> override is the one member of the family that refuses a tag outright.
    /// </remarks>
    private static bool GrowingPlant(IBlock block, IFeatureLevel level, int x, int y, int z) {
        if (!GrowingPlantPlacementRule.Families.TryGetValue(block.Identifier,
            out GrowingPlantPlacementRule.Family family)) {

            return true;
        }

        Vec3<int> behind = new Vec3<int>(x, y, z).GetBlockTowards(family.Growth.Opposite());
        uint state = level.GetState(behind.X, behind.Y, behind.Z);
        IBlock attached = level.Registry.Blocks.GetByStateId(state);

        if (family.Head == KelpHead && level.Blocks.IsIn(CannotSupportKelp, state)) {
            return false;
        }

        return attached.Identifier.Equals(family.Head) || attached.Identifier.Equals(family.Body)
            || ShapeSupport.IsFaceSturdy(attached, family.Growth);
    }

    /// <summary>
    /// <c>DoublePlantBlock.canSurvive</c>: the upper half holds onto the lower half of the same plant
    /// rather than onto the ground.
    /// </summary>
    private static bool DoublePlant(IBlock block, IFeatureLevel level, int x, int y, int z) {
        if (block is not IDoubleHalved { Half: BlockHalf.Upper }) {
            return level.Blocks.IsIn(SupportsVegetation, level.GetState(x, y - 1, z));
        }

        IBlock below = level.Registry.Blocks.GetByStateId(level.GetState(x, y - 1, z));

        return below.Identifier.Equals(block.Identifier)
            && below is IDoubleHalved { Half: BlockHalf.Lower };
    }

    /// <summary>
    /// <c>SmallDripleafBlock.canSurvive</c>: its own tag, or standing in water on anything a plant
    /// grows on.
    /// </summary>
    /// <remarks>
    /// The water half is what puts a dripleaf in the pool of a lush caves clay patch rather than
    /// around it, and the source it asks about is at the plant's own position rather than under it:
    /// <c>mayPlaceOn</c> is handed the block below and looks back up from there.
    /// <p/>
    /// The upper half of the plant asks <c>DoublePlantBlock.canSurvive</c> instead, which nothing in
    /// the feature pass places on its own: a vegetation patch writes the lower half and the feature
    /// grows the rest.
    /// </remarks>
    private static bool SmallDripleaf(IBlock block, IFeatureLevel level, int x, int y, int z) {
        if (block is IDoubleHalved { Half: BlockHalf.Upper }) {
            return level.Blocks.IsIn(SupportsVegetation, level.GetState(x, y - 2, z));
        }

        uint below = level.GetState(x, y - 1, z);

        if (level.Blocks.IsIn(SupportsSmallDripleaf, below)) {
            return true;
        }

        FluidState here = FluidState.Of(level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)));

        return here.Kind == FluidKind.Water && here.Amount == 8
            && level.Blocks.IsIn(SupportsVegetation, below);
    }

    /// <summary><c>Direction.Plane.HORIZONTAL</c>: north, east, south, west.</summary>
    private static readonly (int X, int Z)[] Horizontal = [(0, -1), (1, 0), (0, 1), (-1, 0)];

    /// <summary>
    /// Whether a propagule is the hanging form. Reads the property through the generated interface so
    /// a rename upstream breaks the build rather than making every propagule look planted.
    /// </summary>
    private static bool IsHanging(IBlock block) {
        return block is Minecraft.Data.Blocks.Properties.IHanging { Hanging: true };
    }
}

/// <summary>
/// Which fluid a state carries, by identifier.
/// </summary>
/// <remarks>
/// Vanilla asks a <b>fluid tag</b> here (<c>FluidTags.LAVA</c>,
/// <c>FluidTags.SUPPORTS_SUGAR_CANE_ADJACENTLY</c>, which is <c>#water</c>). There is no fluid
/// registry in this framework and therefore no fluid tags, so the two tags that the worldgen data
/// reaches are their four members written out. Both tags are closed sets upstream, so this is the
/// same question rather than an approximation of it.
/// </remarks>
public static class FeatureFluids {
    private static readonly Identifier Water = "minecraft:water";
    private static readonly Identifier FlowingWater = "minecraft:flowing_water";
    private static readonly Identifier Lava = "minecraft:lava";
    private static readonly Identifier FlowingLava = "minecraft:flowing_lava";

    public static bool IsWater(IFeatureLevel level, uint stateId) {
        Identifier? fluid = level.Registry.Blocks.GetByStateId(stateId).Fluid;
        return fluid is not null && (fluid.Equals(Water) || fluid.Equals(FlowingWater));
    }

    public static bool IsLava(IFeatureLevel level, uint stateId) {
        Identifier? fluid = level.Registry.Blocks.GetByStateId(stateId).Fluid;
        return fluid is not null && (fluid.Equals(Lava) || fluid.Equals(FlowingLava));
    }

    /// <summary>
    /// Whether a state holds a water <b>source</b>, which is <c>getType() == Fluids.WATER</c>.
    /// </summary>
    /// <remarks>
    /// Deliberately apart from <see cref="IsWater"/>, which is the <c>#water</c> kind and holds both
    /// forms. The generated block data already draws the line: a source state carries
    /// <c>minecraft:water</c> and a flowing one <c>minecraft:flowing_water</c>, and a waterlogged
    /// block carries the source. A leaf waterlogged in a flow would hold water where there was none.
    /// </remarks>
    public static bool IsWaterSource(IFeatureLevel level, uint stateId) {
        return level.Registry.Blocks.GetByStateId(stateId).Fluid is { } fluid && fluid.Equals(Water);
    }

    /// <summary><c>getFluidState(pos).getType() == Fluids.EMPTY</c>.</summary>
    public static bool IsEmpty(IFeatureLevel level, uint stateId) {
        return level.Registry.Blocks.GetByStateId(stateId).Fluid is null;
    }
}
