using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using NBT;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// <c>TemplateStructurePiece</c>: a piece that is a saved template rather than code that draws one.
/// </summary>
/// <remarks>
/// The two kinds of piece are the same thing from outside: both have a box, both are asked to write
/// their share of themselves into a chunk. What differs is where the blocks come from, and that
/// difference is entirely inside <see cref="PostProcess"/>.
/// <p/>
/// <b>The orientation is always north</b>, as vanilla sets it, so the base class's local to world turn
/// is the identity and the placement's own rotation is the only one that applies. A piece that also
/// used <see cref="StructurePiece.Orientation"/> would turn its blocks twice.
/// <p/>
/// The box is <b>recomputed per chunk</b> rather than being fixed at construction, because the place
/// settings carry the writable area and the box is derived from them. That is upstream's arrangement
/// and it is why the settings are mutable.
/// </remarks>
public abstract class TemplateStructurePiece : StructurePiece {
    protected TemplateStructurePiece(int genDepth, StructureTemplateManager templates,
        Identifier templateLocation, StructurePlaceSettings placeSettings, Vec3<int> position)
        : base(genDepth, templates.Get(templateLocation).GetBoundingBox(placeSettings, position)) {

        Orientation = Direction.North;

        TemplateName = templateLocation;
        Template = templates.Get(templateLocation);
        PlaceSettings = placeSettings;
        TemplatePosition = position;
    }

    public Identifier TemplateName { get; }

    public StructureTemplate Template { get; }

    public StructurePlaceSettings PlaceSettings { get; }

    /// <summary>Where the template's own origin sits in the world, before it settles.</summary>
    public Vec3<int> TemplatePosition { get; protected set; }

    public override void Move(int dx, int dy, int dz) {
        base.Move(dx, dy, dz);

        TemplatePosition = new Vec3<int>(TemplatePosition.X + dx, TemplatePosition.Y + dy,
            TemplatePosition.Z + dz);
    }

    /// <summary>
    /// Places the template, then acts on the data markers and jigsaw blocks it left behind.
    /// </summary>
    /// <remarks>
    /// The three steps are one method upstream and their order matters: the template's own blocks go
    /// down first, so a data marker handler that reads what is around it sees the finished piece, and
    /// the jigsaw blocks are replaced last so that a marker handler can still find one.
    /// <p/>
    /// A <b>data marker is never written</b>: every piece that uses one adds
    /// <see cref="BlockIgnoreProcessor.StructureBlock"/>, so the structure block is dropped before it
    /// reaches the level and only its metadata survives, through
    /// <see cref="HandleDataMarker"/>.
    /// </remarks>
    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        Vec3<int> position = SettleAgainstTerrain(level);

        PlaceSettings.BoundingBox = chunkBox;
        BoundingBox = Template.GetBoundingBox(PlaceSettings, position);

        if (!Template.PlaceInWorld(level, position, referencePos, PlaceSettings, random)) {
            return;
        }

        foreach (TemplateBlockInfo marker in Template.FilterBlocks(position, PlaceSettings,
            Block.StructureBlock.Identifier, level.Registry)) {

            if (marker.Nbt is null) {
                continue;
            }

            string mode = marker.Nbt.Contains("mode") ? marker.Nbt["mode"].GetString() : "DATA";

            if (!mode.Equals("DATA", StringComparison.Ordinal)) {
                continue;
            }

            string metadata = marker.Nbt.Contains("metadata")
                ? marker.Nbt["metadata"].GetString()
                : string.Empty;

            HandleDataMarker(metadata, marker.Pos, level, random, chunkBox);
        }

        foreach (TemplateBlockInfo jigsaw in Template.FilterBlocks(position, PlaceSettings,
            Block.Jigsaw.Identifier, level.Registry)) {

            if (jigsaw.Nbt is null) {
                continue;
            }

            string written = jigsaw.Nbt.Contains("final_state")
                ? jigsaw.Nbt["final_state"].GetString()
                : "minecraft:air";

            level.SetState(jigsaw.Pos.X, jigsaw.Pos.Y, jigsaw.Pos.Z,
                Data.BlockStateStrings.Parse(level.Registry, written));
        }
    }

    /// <summary>
    /// Where the template goes for this placement, which is the top of <c>postProcess</c> for the
    /// three pieces that drop themselves onto the ground they landed over.
    /// </summary>
    /// <remarks>
    /// <b>The answer must be a function of the terrain alone, never of which chunk is asking.</b> A
    /// start is replayed by every chunk it reaches, so a piece spanning a border is settled once per
    /// chunk and the halves only line up while every one of those calls agrees. The two <c>_WG</c>
    /// heightmaps are what makes that hold: they stop being maintained at the carvers step, so they
    /// answer the terrain rather than the column being decorated, and the terrain is a pure function
    /// of the seed and the position.
    /// <p/>
    /// It also has to answer without leaving the level's three by three, and it does: every one of
    /// these footprints is at most 28 blocks across, so it spans two chunks, and a chunk whose
    /// writable area the box reaches is at most one chunk from either.
    /// <p/>
    /// Nothing here writes to <see cref="TemplatePosition"/>. Upstream settles the field and guards
    /// it with a flag, which leaves the answer belonging to whichever chunk got there first; two of
    /// this pass's chunks reach a piece at once.
    /// </remarks>
    protected virtual Vec3<int> SettleAgainstTerrain(IFeatureLevel level) => TemplatePosition;

    /// <summary>
    /// What a piece does about one of its data markers, which is how a template says "a chest goes
    /// here" without saving the chest.
    /// </summary>
    /// <remarks>
    /// The position is <b>already in world coordinates</b> and is the marker's own cell, so a handler
    /// writes there directly rather than through <see cref="StructurePiece.PlaceBlock"/>.
    /// </remarks>
    protected abstract void HandleDataMarker(string marker, Vec3<int> position, IFeatureLevel level,
        RandomSource random, BoundingBox chunkBox);
}
