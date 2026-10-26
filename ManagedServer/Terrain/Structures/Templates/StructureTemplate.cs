using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Features.Blocks;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Registry;
using Minecraft.Schemas.Vec;
using NBT.Tags;
using Minecraft.Fluids;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>One block of a template, in the template's own coordinates.</summary>
/// <param name="Nbt">
/// The block entity the block carried when the template was saved. Nothing here reads its contents,
/// but its presence is what marks a data marker or a jigsaw block, and both of those are read.
/// </param>
public readonly record struct TemplateBlockInfo(Vec3<int> Pos, uint StateId, CompoundTag? Nbt);

/// <summary>An entity saved inside a template, at its position relative to the template's corner.</summary>
public readonly record struct TemplateEntityInfo(Vec3<double> Pos, Vec3<int> BlockPos, CompoundTag Nbt);

/// <summary>
/// <c>StructureTemplate</c>: a piece of a structure saved as blocks rather than written as code, which
/// is what every shipwreck, igloo, ocean ruin, ruined portal, mansion room and jigsaw piece is made of.
/// </summary>
/// <remarks>
/// A template is <b>immutable and shared</b>. One is parsed per id per pack and handed to every piece
/// that names it, and the structure pass runs on the thread pool, so nothing here may be mutated after
/// loading. <see cref="StructurePlaceSettings"/> is the per placement half.
/// <p/>
/// The blocks are ordered as vanilla orders them, full cubes first, then everything else, then the
/// blocks carrying a block entity. That order is what stops a torch being written before the wall it
/// hangs on.
/// <p/>
/// <b>Entities inside a template are not placed.</b> 55 of the vanilla templates carry one, which is
/// every villager, cat, iron golem, piglin and the igloo's basement pair. A chunk is generated before
/// it holds anything, and the generation API writes blocks, so there is nowhere to put them. The same
/// gap leaves a structure's chests real and empty.
/// </remarks>
public sealed class StructureTemplate {
    private readonly TemplatePalette[] _palettes;
    private readonly TemplateEntityInfo[] _entities;

    public StructureTemplate(Vec3<int> size, TemplatePalette[] palettes, TemplateEntityInfo[] entities) {
        Size = size;
        _palettes = palettes;
        _entities = entities;
    }

    public Vec3<int> Size { get; }

    public IReadOnlyList<TemplatePalette> Palettes => _palettes;

    public IReadOnlyList<TemplateEntityInfo> Entities => _entities;

    /// <summary>The size as it comes out once turned, which swaps x and z on the quarter turns.</summary>
    public Vec3<int> SizeAfter(BlockRotation rotation) {
        return rotation is BlockRotation.Clockwise90 or BlockRotation.CounterClockwise90
            ? new Vec3<int>(Size.Z, Size.Y, Size.X)
            : Size;
    }

    // ------------------------------------------------------------- transforms

    /// <summary>
    /// <c>StructureTemplate.transform</c>: a template position mirrored and then turned about a pivot.
    /// </summary>
    /// <remarks>
    /// The mirror is a plain negation rather than a reflection through the template, so the pivot is
    /// what puts the result back over the template's own footprint. A caller that mirrors without a
    /// pivot gets a piece in the wrong place rather than a piece the wrong way round.
    /// </remarks>
    public static Vec3<int> Transform(Vec3<int> pos, BlockMirror mirror, BlockRotation rotation,
        Vec3<int> pivot) {

        int x = pos.X;
        int y = pos.Y;
        int z = pos.Z;
        bool mirrored = true;

        switch (mirror) {
            case BlockMirror.LeftRight:
                z = -z;
                break;

            case BlockMirror.FrontBack:
                x = -x;
                break;

            default:
                mirrored = false;
                break;
        }

        int pivotX = pivot.X;
        int pivotZ = pivot.Z;

        return rotation switch {
            BlockRotation.CounterClockwise90 => new Vec3<int>(pivotX - pivotZ + z, y, pivotX + pivotZ - x),
            BlockRotation.Clockwise90 => new Vec3<int>(pivotX + pivotZ - z, y, pivotZ - pivotX + x),
            BlockRotation.Clockwise180 => new Vec3<int>(pivotX + pivotX - x, y, pivotZ + pivotZ - z),
            _ => mirrored ? new Vec3<int>(x, y, z) : pos
        };
    }

    /// <summary>
    /// The same for an entity's fractional position, which reflects through the <b>middle</b> of a
    /// block rather than through its corner.
    /// </summary>
    /// <remarks>
    /// That is the extra one in each arm: a block at x is mirrored to -x, but a point at x is mirrored
    /// to 1 - x, so an entity standing in the centre of a block stays in the centre of the mirrored one.
    /// </remarks>
    public static Vec3<double> Transform(Vec3<double> pos, BlockMirror mirror, BlockRotation rotation,
        Vec3<int> pivot) {

        double x = pos.X;
        double y = pos.Y;
        double z = pos.Z;
        bool mirrored = true;

        switch (mirror) {
            case BlockMirror.LeftRight:
                z = 1.0 - z;
                break;

            case BlockMirror.FrontBack:
                x = 1.0 - x;
                break;

            default:
                mirrored = false;
                break;
        }

        int pivotX = pivot.X;
        int pivotZ = pivot.Z;

        return rotation switch {
            BlockRotation.CounterClockwise90 =>
                new Vec3<double>(pivotX - pivotZ + z, y, pivotX + pivotZ + 1 - x),
            BlockRotation.Clockwise90 =>
                new Vec3<double>(pivotX + pivotZ + 1 - z, y, pivotZ - pivotX + x),
            BlockRotation.Clockwise180 =>
                new Vec3<double>(pivotX + pivotX + 1 - x, y, pivotZ + pivotZ + 1 - z),
            _ => mirrored ? new Vec3<double>(x, y, z) : pos
        };
    }

    public static Vec3<int> CalculateRelativePosition(StructurePlaceSettings settings, Vec3<int> pos) {
        return Transform(pos, settings.Mirror, settings.Rotation, settings.RotationPivot);
    }

    /// <summary>
    /// <c>calculateConnectedPosition</c>: how far one template has to move for its connection point to
    /// land on another's, which is the whole of how two jigsaw pieces are joined.
    /// </summary>
    public static Vec3<int> CalculateConnectedPosition(StructurePlaceSettings from, Vec3<int> connection,
        StructurePlaceSettings to, Vec3<int> otherConnection) {

        Vec3<int> here = CalculateRelativePosition(from, connection);
        Vec3<int> there = CalculateRelativePosition(to, otherConnection);
        return new Vec3<int>(here.X - there.X, here.Y - there.Y, here.Z - there.Z);
    }

    /// <summary>
    /// <c>getZeroPositionWithTransform</c>: where the template's own origin ends up once it is turned,
    /// so that the turned footprint still starts at the position asked for.
    /// </summary>
    public static Vec3<int> ZeroPositionWithTransform(Vec3<int> zero, BlockMirror mirror,
        BlockRotation rotation, int sizeX, int sizeZ) {

        sizeX--;
        sizeZ--;

        int mirrorX = mirror == BlockMirror.FrontBack ? sizeX : 0;
        int mirrorZ = mirror == BlockMirror.LeftRight ? sizeZ : 0;

        return rotation switch {
            BlockRotation.CounterClockwise90 =>
                new Vec3<int>(zero.X + mirrorZ, zero.Y, zero.Z + sizeX - mirrorX),
            BlockRotation.Clockwise90 =>
                new Vec3<int>(zero.X + sizeZ - mirrorZ, zero.Y, zero.Z + mirrorX),
            BlockRotation.Clockwise180 =>
                new Vec3<int>(zero.X + sizeX - mirrorX, zero.Y, zero.Z + sizeZ - mirrorZ),
            _ => new Vec3<int>(zero.X + mirrorX, zero.Y, zero.Z + mirrorZ)
        };
    }

    public Vec3<int> ZeroPositionWithTransform(Vec3<int> zero, BlockMirror mirror,
        BlockRotation rotation) {

        return ZeroPositionWithTransform(zero, mirror, rotation, Size.X, Size.Z);
    }

    public BoundingBox GetBoundingBox(StructurePlaceSettings settings, Vec3<int> position) {
        return GetBoundingBox(position, settings.Rotation, settings.RotationPivot, settings.Mirror,
            Size);
    }

    /// <summary>
    /// The box the template occupies once placed, worked out from its two turned corners.
    /// </summary>
    /// <remarks>
    /// Turning the corners rather than the size is what makes this right for a mirrored placement: the
    /// transform moves a corner off the origin, so the box has to be built from where the corners
    /// actually landed and then shifted.
    /// </remarks>
    public static BoundingBox GetBoundingBox(Vec3<int> position, BlockRotation rotation,
        Vec3<int> pivot, BlockMirror mirror, Vec3<int> size) {

        Vec3<int> far = new(size.X - 1, size.Y - 1, size.Z - 1);
        Vec3<int> corner1 = Transform(new Vec3<int>(0, 0, 0), mirror, rotation, pivot);
        Vec3<int> corner2 = Transform(far, mirror, rotation, pivot);

        return new BoundingBox(
            Math.Min(corner1.X, corner2.X), Math.Min(corner1.Y, corner2.Y),
            Math.Min(corner1.Z, corner2.Z),
            Math.Max(corner1.X, corner2.X), Math.Max(corner1.Y, corner2.Y),
            Math.Max(corner1.Z, corner2.Z))
            .Move(position.X, position.Y, position.Z);
    }

    // ----------------------------------------------------------------- reading

    /// <summary>
    /// Every block of one kind, at its placed position and turned, which is how a piece finds its data
    /// markers and its jigsaw blocks.
    /// </summary>
    /// <remarks>
    /// Only the <b>rotation</b> is applied to the state, not the mirror, which is vanilla's own
    /// asymmetry here and does not matter for the two blocks this is ever asked about.
    /// </remarks>
    public List<TemplateBlockInfo> FilterBlocks(Vec3<int> position, StructurePlaceSettings settings,
        Identifier block, MinecraftRegistry registry) {

        List<TemplateBlockInfo> result = [];

        if (_palettes.Length == 0) {
            return result;
        }

        BoundingBox? box = settings.BoundingBox;

        foreach (TemplateBlockInfo info in settings.RandomPalette(_palettes, position).BlocksOf(block, registry)) {

            Vec3<int> relative = CalculateRelativePosition(settings, info.Pos);
            Vec3<int> placed = new(relative.X + position.X, relative.Y + position.Y,
                relative.Z + position.Z);

            if (box is not null && !box.IsInside(placed.X, placed.Y, placed.Z)) {
                continue;
            }

            result.Add(new TemplateBlockInfo(placed, Turn(registry, info.StateId, settings.Rotation),
                info.Nbt));
        }

        return result;
    }

    /// <summary>
    /// The jigsaw blocks of this template, at their placed positions, for a pool element being asked
    /// where it can connect.
    /// </summary>
    /// <remarks>
    /// No mirror, because a jigsaw structure never mirrors a piece: <c>getJigsaws</c> builds its own
    /// settings out of the rotation alone.
    /// </remarks>
    public List<JigsawBlockInfo> GetJigsaws(Vec3<int> position, BlockRotation rotation,
        MinecraftRegistry registry) {

        if (_palettes.Length == 0) {
            return [];
        }

        StructurePlaceSettings settings = new() { Rotation = rotation };
        List<JigsawBlockInfo> found = [];

        foreach (JigsawBlockInfo jigsaw in settings.RandomPalette(_palettes, position).Jigsaws(registry)) {
            TemplateBlockInfo info = jigsaw.Info;
            Vec3<int> relative = CalculateRelativePosition(settings, info.Pos);

            found.Add(jigsaw with {
                Info = info with {
                    Pos = new Vec3<int>(relative.X + position.X, relative.Y + position.Y,
                        relative.Z + position.Z),
                    StateId = Turn(registry, info.StateId, rotation)
                }
            });
        }

        return found;
    }

    // ----------------------------------------------------------------- placing

    /// <summary>
    /// Writes the template's blocks into the level, turned, processed and clipped to the settings' box.
    /// </summary>
    /// <remarks>
    /// <b>The blocks and their shapes.</b> Vanilla also loads each block entity from the tag beside it
    /// and spawns the saved entities, and neither exists in the generator: a template's chests are
    /// real and empty and its villagers absent. The same two gaps the feature pass documents.
    /// <p/>
    /// The shapes <b>do</b> settle, through <c>updateShapeAtEdge</c> over the outside of what was
    /// written and then <c>updateFromNeighbourShapes</c> over each block of it, in that order and for
    /// the same reason vanilla runs them that way: the edge pass can change a block the second one
    /// then reads. A saved build carries the connections it had where it was cut from, so this is not
    /// a refinement: a shipwreck's stairs are saved as <c>outer_right</c> and every one of them is
    /// wrong until it settles.
    /// <p/>
    /// The <b>loot seed is still drawn</b> for a container, on <c>StructurePiece.ConsumeLootSeed</c>'s
    /// reasoning: vanilla takes it from the random passed in here, so skipping it moves every block a
    /// later piece of the same structure places.
    /// </remarks>
    public bool PlaceInWorld(IFeatureLevel level, Vec3<int> position, Vec3<int> referencePos,
        StructurePlaceSettings settings, RandomSource random) {

        if (_palettes.Length == 0) {
            return false;
        }

        IReadOnlyList<TemplateBlockInfo> blocks = settings.RandomPalette(_palettes, position).Blocks;

        if (blocks.Count == 0 || Size.X < 1 || Size.Y < 1 || Size.Z < 1) {
            return false;
        }

        BoundingBox? box = settings.BoundingBox;
        List<Vec3<int>> placed = [];

        // The two halves of the water pass. A position goes in the first when the template wrote its
        // own source there, which is what stops a wreck's own water flooding the hull it sits in; in
        // the second when a block that could hold water was written into something that was not a
        // source, which is what the flood back then reconsiders.
        HashSet<Vec3<int>> lockedFluids = [];
        List<Vec3<int>> toFill = [];

        foreach (TemplateBlockInfo info in ProcessBlockInfos(level, position, referencePos, settings,
            blocks)) {

            Vec3<int> pos = info.Pos;

            if (box is not null && !box.IsInside(pos.X, pos.Y, pos.Z)) {
                continue;
            }

            uint previous = level.GetState(pos.X, pos.Y, pos.Z);
            uint state = Turn(level.Registry, info.StateId, settings.Mirror, settings.Rotation);

            level.SetState(pos.X, pos.Y, pos.Z, state);
            placed.Add(pos);

            // Classified on the template's own state rather than on what it becomes, which is
            // upstream's order and not a detail: a stair written into the sea is waterlogged and is
            // still not a source the template placed, so it goes on feeding the flood back for the
            // dry cells behind it. Locking it instead walls off the inside of a hull.
            if (settings.ApplyWaterlogging) {
                if (IsSource(level, state)) {
                    lockedFluids.Add(pos);
                } else if (Waterloggable(level, state)) {
                    if (IsWaterSource(level, previous)) {
                        level.SetState(pos.X, pos.Y, pos.Z, PlaceLiquid(level, state));
                    }

                    if (!IsSource(level, previous)) {
                        toFill.Add(pos);
                    }
                }
            }

            if (info.Nbt is not null && IsRandomisableContainer(level, state)) {
                random.NextLong();
            }
        }

        FloodBack(level, toFill, lockedFluids);

        if (!settings.KnownShape) {
            SettleShapes(level, placed);
        }

        return true;
    }

    /// <summary>The five faces the flood back looks along, in vanilla's order and without down.</summary>
    private static readonly BlockFace[] FloodFrom = [
        BlockFace.PosY, BlockFace.NegZ, BlockFace.PosX, BlockFace.PosZ, BlockFace.NegX
    ];

    /// <summary>
    /// Waterlogs what the template wrote into a dry cell that the sea can still reach.
    /// </summary>
    /// <remarks>
    /// <b>This is not a fluid tick and does not need one.</b> A hull is written into open water and
    /// every plank of it displaces a source, so without this pass a wreck comes out with a dry shell
    /// of stairs and fences around a flooded inside. The walk repeats until a pass fills nothing,
    /// because a cell filled by one neighbour is a source for the next.
    /// <p/>
    /// The first source found along the five faces wins even when it is lava, exactly as upstream:
    /// the search stops at any source and only water can then be placed, so a lava neighbour keeps a
    /// water one further down the list from being reached.
    /// </remarks>
    private static void FloodBack(IFeatureLevel level, List<Vec3<int>> toFill,
        HashSet<Vec3<int>> lockedFluids) {

        bool filled = true;

        while (filled && toFill.Count > 0) {
            filled = false;

            for (int i = toFill.Count - 1; i >= 0; i--) {
                Vec3<int> pos = toFill[i];
                uint state = level.GetState(pos.X, pos.Y, pos.Z);
                uint toPlace = state;

                for (int face = 0; face < FloodFrom.Length && !IsSource(level, toPlace); face++) {
                    Vec3<int> neighbourPos = pos.GetBlockTowards(FloodFrom[face]);
                    uint neighbour = level.GetState(neighbourPos.X, neighbourPos.Y, neighbourPos.Z);

                    if (IsSource(level, neighbour) && !lockedFluids.Contains(neighbourPos)) {
                        toPlace = neighbour;
                    }
                }

                if (!IsSource(level, toPlace) || !IsWaterSource(level, toPlace)
                    || !Waterloggable(level, state)) {

                    continue;
                }

                level.SetState(pos.X, pos.Y, pos.Z, PlaceLiquid(level, state));
                toFill.RemoveAt(i);
                filled = true;
            }
        }
    }

    /// <summary>
    /// Settles the states of what was written and of what it was written against.
    /// </summary>
    /// <remarks>
    /// The edge pass first, then every placed block, which is the order upstream runs them in and not
    /// an arbitrary one: the edge pass reaches a block <b>outside</b> what was written, so a fence the
    /// template landed beside is joined before the template's own fence is asked what it joins.
    /// <p/>
    /// The box is the placed blocks' own rather than the template's, because a piece is clipped to the
    /// chunk being generated: a shape covering the whole template would walk faces in the two thirds of
    /// it that were never written here and settle blocks belonging to another chunk's share.
    /// </remarks>
    private static void SettleShapes(IFeatureLevel level, List<Vec3<int>> placed) {
        if (placed.Count == 0) {
            return;
        }

        Vec3<int> min = placed[0];
        Vec3<int> max = placed[0];

        foreach (Vec3<int> pos in placed) {
            min = new Vec3<int>(Math.Min(min.X, pos.X), Math.Min(min.Y, pos.Y), Math.Min(min.Z, pos.Z));
            max = new Vec3<int>(Math.Max(max.X, pos.X), Math.Max(max.Y, pos.Y), Math.Max(max.Z, pos.Z));
        }

        FeatureShape shape = new(min, max);

        foreach (Vec3<int> pos in placed) {
            shape.Fill(pos);
        }

        shape.UpdateShapeAtEdge(level);

        foreach (Vec3<int> pos in placed) {
            IBlock state = level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z));
            IBlock settled = FeatureShapeUpdate.UpdateFromNeighbourShapes(state, level, pos);

            if (settled.StateId != state.StateId) {
                level.SetState(pos.X, pos.Y, pos.Z, settled.StateId);
            }
        }
    }

    /// <summary>
    /// <c>processBlockInfos</c>: every block put through the settings' processors in order, dropping
    /// the ones a processor answered nothing for.
    /// </summary>
    /// <remarks>
    /// The processors see the block at its <b>placed</b> position but are handed the template position
    /// as well, because a rule keyed on where a block sits inside its own piece has to be able to ask.
    /// <p/>
    /// A processor that reads the whole piece turns off the "only this chunk" filter, since it cannot
    /// count what it has not been shown. The four vanilla lists use one such processor, <c>capped</c>.
    /// </remarks>
    private static List<TemplateBlockInfo> ProcessBlockInfos(IFeatureLevel level, Vec3<int> position,
        Vec3<int> referencePos, StructurePlaceSettings settings,
        IReadOnlyList<TemplateBlockInfo> blocks) {

        List<TemplateBlockInfo> original = [];
        List<TemplateBlockInfo> processed = [];

        bool onlyThisChunk = true;

        foreach (IStructureProcessor processor in settings.Processors) {
            if (processor.EvaluatesEntirePieceState) {
                onlyThisChunk = false;
                break;
            }
        }

        BoundingBox? box = settings.BoundingBox;

        foreach (TemplateBlockInfo info in blocks) {
            Vec3<int> relative = CalculateRelativePosition(settings, info.Pos);
            Vec3<int> placed = new(relative.X + position.X, relative.Y + position.Y,
                relative.Z + position.Z);

            if (onlyThisChunk && box is not null && !box.IsInside(placed.X, placed.Y, placed.Z)) {
                continue;
            }

            TemplateBlockInfo? current = info with { Pos = placed };

            foreach (IStructureProcessor processor in settings.Processors) {
                if (current is null) {
                    break;
                }

                current = processor.ProcessBlock(level, position, referencePos, info.Pos,
                    current.Value, settings);
            }

            if (current is null) {
                continue;
            }

            processed.Add(current.Value);
            original.Add(info);
        }

        foreach (IStructureProcessor processor in settings.Processors) {
            processed = processor.FinalizeProcessing(level, position, referencePos, original, processed,
                settings);
        }

        return processed;
    }

    /// <summary>
    /// <c>SimpleWaterloggedBlock.placeLiquid</c>: the state a block that can hold water comes out as
    /// once it is put in some.
    /// </summary>
    private static uint PlaceLiquid(IFeatureLevel level, uint stateId) {
        IBlock block = level.Registry.Blocks.GetByStateId(stateId);

        return block is IWaterlogged waterlogged && !waterlogged.Waterlogged
            ? waterlogged.WithWaterlogged(true).StateId
            : stateId;
    }

    /// <summary><c>LiquidBlockContainer</c>, which for every block here is holding water.</summary>
    private static bool Waterloggable(IFeatureLevel level, uint stateId) {
        return level.Registry.Blocks.GetByStateId(stateId) is IWaterlogged;
    }

    /// <summary>
    /// <c>FluidState.isSource</c>, which is not "carries a fluid": a flowing cell carries one and is
    /// not a source, and only a source waterlogs anything or feeds the flood back.
    /// </summary>
    private static bool IsSource(IFeatureLevel level, uint stateId) {
        Identifier? fluid = level.Registry.Blocks.GetByStateId(stateId).Fluid;
        return fluid is not null && (fluid.Equals(WaterFluid) || fluid.Equals(LavaFluid));
    }

    private static bool IsWaterSource(IFeatureLevel level, uint stateId) {
        return level.Registry.Blocks.GetByStateId(stateId).Fluid is { } fluid
            && fluid.Equals(WaterFluid);
    }

    private static readonly Identifier WaterFluid = "minecraft:water";
    private static readonly Identifier LavaFluid = "minecraft:lava";

    /// <summary>
    /// Whether a state is one whose block entity vanilla would have given a loot table seed.
    /// </summary>
    /// <remarks>
    /// <c>RandomizableContainer</c> is the interface on the block entity, which has no port here, so
    /// the test is on the block instead. What matters is only how many times the random is drawn from.
    /// <p/>
    /// <b>Being a container is not the test, and the two lists differ.</b> A furnace, a blast furnace,
    /// a smoker and a brewing stand all hold items and none of them is randomisable: they descend from
    /// <c>BaseContainerBlockEntity</c> while a chest descends from
    /// <c>RandomizableContainerBlockEntity</c>. Counting one of those spends a <c>nextLong</c> vanilla
    /// does not, which writes the same blocks and moves everything the piece draws afterwards, so a
    /// village's furnace shows up as its tree being the wrong shape.
    /// </remarks>
    internal static bool IsRandomisableContainer(IFeatureLevel level, uint stateId) {
        Identifier? entity = level.Registry.Blocks.GetByStateId(stateId).BlockEntity;

        return entity is not null && RandomisableContainers.Contains(entity.Value);
    }

    private static readonly HashSet<Identifier> RandomisableContainers = [
        BlockEntityType.Chest.Identifier,
        BlockEntityType.TrappedChest.Identifier,
        BlockEntityType.Barrel.Identifier,
        BlockEntityType.Dispenser.Identifier,
        BlockEntityType.Dropper.Identifier,
        BlockEntityType.Hopper.Identifier,
        BlockEntityType.ShulkerBox.Identifier,
        BlockEntityType.Crafter.Identifier,
        BlockEntityType.DecoratedPot.Identifier
    ];

    private static uint Turn(MinecraftRegistry registry, uint stateId, BlockRotation rotation) {
        return Turn(registry, stateId, BlockMirror.None, rotation);
    }

    private static uint Turn(MinecraftRegistry registry, uint stateId, BlockMirror mirror,
        BlockRotation rotation) {

        if (mirror == BlockMirror.None && rotation == BlockRotation.None) {
            return stateId;
        }

        IBlock block = registry.Blocks.GetByStateId(stateId);
        block = BlockStateTransform.Mirror(block, mirror);
        block = BlockStateTransform.Rotate(block, rotation);
        return block.StateId;
    }
}
