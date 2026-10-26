using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using static ManagedServer.Terrain.Structures.Types.EndCityStructure;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>EndCityPieces</c>: the recursive grammar that grows an end city out of one starting tower.
/// </summary>
/// <remarks>
/// <b>One instance per structure being laid out.</b> Vanilla's four section generators are static
/// singletons, and one of them keeps <c>shipCreated</c> as a field on that singleton; two cities laid
/// out at once would then interleave and one of them could lose its ship. This pass runs on the thread
/// pool, so the flag lives here instead. Same reasoning as the stronghold's and the fortress's tables.
/// <p/>
/// A section that grows children builds them into a <b>separate list</b> and keeps them only if none
/// collides with something already placed. Every piece of one attempt shares a drawn tag so that
/// pieces of the same attempt do not reject each other, and the draw is taken whether or not the
/// attempt is kept.
/// </remarks>
internal sealed class EndCityLayout(StructureTemplateManager templates, RandomSource random) {
    private const int MaxGenDepth = 8;

    /// <summary>Where a bridge may leave a tower, as a turn and an offset within the tower.</summary>
    private static readonly (BlockRotation Rotation, Vec3<int> Offset)[] TowerBridges = [
        (BlockRotation.None, new Vec3<int>(1, -1, 0)),
        (BlockRotation.Clockwise90, new Vec3<int>(6, -1, 1)),
        (BlockRotation.CounterClockwise90, new Vec3<int>(0, -1, 5)),
        (BlockRotation.Clockwise180, new Vec3<int>(5, -1, 6))
    ];

    private static readonly (BlockRotation Rotation, Vec3<int> Offset)[] FatTowerBridges = [
        (BlockRotation.None, new Vec3<int>(4, -1, 0)),
        (BlockRotation.Clockwise90, new Vec3<int>(12, -1, 4)),
        (BlockRotation.CounterClockwise90, new Vec3<int>(0, -1, 8)),
        (BlockRotation.Clockwise180, new Vec3<int>(8, -1, 12))
    ];

    /// <summary>Whether this city has already grown its ship, which it only ever gets one of.</summary>
    private bool _shipCreated;

    public void StartHouseTower(Vec3<int> origin, BlockRotation rotation,
        List<StructurePiece> pieces) {

        EndCityPiece last = Add(pieces,
            new EndCityPiece(templates, "base_floor", origin, rotation, true));

        last = Add(pieces, Attach(last, new Vec3<int>(-1, 0, -1), "second_floor_1", rotation, false));
        last = Add(pieces, Attach(last, new Vec3<int>(-1, 4, -1), "third_floor_1", rotation, false));
        last = Add(pieces, Attach(last, new Vec3<int>(-1, 8, -1), "third_roof", rotation, true));

        RecursiveChildren(Tower, 1, last, NoOffset, pieces);
    }

    /// <summary>
    /// A house tower: a base floor and up to two more, with a tower on top of the taller ones.
    /// </summary>
    private bool HouseTower(int genDepth, EndCityPiece parent, Vec3<int> offset,
        List<StructurePiece> pieces) {
        if (genDepth > MaxGenDepth) {
            return false;
        }

        BlockRotation rotation = parent.PlaceSettings.Rotation;

        EndCityPiece last = Add(pieces,
            Attach(parent, offset, "base_floor", rotation, true));

        int floors = random.NextInt(3);

        if (floors == 0) {
            Add(pieces, Attach(last, new Vec3<int>(-1, 4, -1), "base_roof", rotation, true));
            return true;
        }

        last = Add(pieces, Attach(last, new Vec3<int>(-1, 0, -1), "second_floor_2", rotation, false));

        if (floors == 1) {
            last = Add(pieces,
                Attach(last, new Vec3<int>(-1, 8, -1), "second_roof", rotation, false));
        } else {
            last = Add(pieces, Attach(last, new Vec3<int>(-1, 4, -1), "third_floor_2", rotation,
                false));

            last = Add(pieces, Attach(last, new Vec3<int>(-1, 8, -1), "third_roof", rotation, true));
        }

        RecursiveChildren(Tower, genDepth + 1, last, NoOffset, pieces);
        return true;
    }

    /// <summary>
    /// A tower: a base, a stack of sections, and then either bridges and a top or a fat tower.
    /// </summary>
    /// <remarks>
    /// Which section the bridges leave from is drawn <b>as the tower is built</b>: the first section
    /// has a one in three chance, and every section but the last may replace it on a coin flip. A
    /// tower that never picks one grows a fat tower instead, unless it is already at depth seven.
    /// </remarks>
    private bool Tower(int genDepth, EndCityPiece parent, Vec3<int> offset,
        List<StructurePiece> pieces) {
        BlockRotation rotation = parent.PlaceSettings.Rotation;

        EndCityPiece last = Add(pieces, Attach(parent,
            new Vec3<int>(3 + random.NextInt(2), -3, 3 + random.NextInt(2)), "tower_base", rotation,
            true));

        last = Add(pieces, Attach(last, new Vec3<int>(0, 7, 0), "tower_piece", rotation, true));

        EndCityPiece? bridgeFrom = random.NextInt(3) == 0 ? last : null;
        int height = 1 + random.NextInt(3);

        for (int i = 0; i < height; i++) {
            last = Add(pieces, Attach(last, new Vec3<int>(0, 4, 0), "tower_piece", rotation, true));

            if (i < height - 1 && random.NextBoolean()) {
                bridgeFrom = last;
            }
        }

        if (bridgeFrom is not null) {
            foreach ((BlockRotation turn, Vec3<int> bridgeOffset) in TowerBridges) {
                if (!random.NextBoolean()) {
                    continue;
                }

                EndCityPiece start = Add(pieces, Attach(bridgeFrom, bridgeOffset, "bridge_end",
                    Rotated(rotation, turn), true));

                RecursiveChildren(TowerBridge, genDepth + 1, start, NoOffset, pieces);
            }

            Add(pieces, Attach(last, new Vec3<int>(-1, 4, -1), "tower_top", rotation, true));
            return true;
        }

        if (genDepth != 7) {
            return RecursiveChildren(FatTower, genDepth + 1, last, NoOffset, pieces);
        }

        Add(pieces, Attach(last, new Vec3<int>(-1, 4, -1), "tower_top", rotation, true));
        return true;
    }

    /// <summary>
    /// A bridge, and whatever it leads to: a ship, or another house tower.
    /// </summary>
    /// <remarks>
    /// The ship's chance is <c>nextInt(10 - genDepth)</c>, so a bridge further from the start is more
    /// likely to end in one, and the city gets at most a single ship. The two bridge ends are marked
    /// with a generation depth of minus one, which excludes them from the collision tag their siblings
    /// share.
    /// </remarks>
    private bool TowerBridge(int genDepth, EndCityPiece parent, Vec3<int> offset,
        List<StructurePiece> pieces) {
        BlockRotation rotation = parent.PlaceSettings.Rotation;
        int length = random.NextInt(4) + 1;

        EndCityPiece last = Add(pieces,
            Attach(parent, new Vec3<int>(0, 0, -4), "bridge_piece", rotation, true));

        last.GenDepth = -1;

        int nextY = 0;

        for (int i = 0; i < length; i++) {
            if (random.NextBoolean()) {
                last = Add(pieces, Attach(last, new Vec3<int>(0, nextY, -4), "bridge_piece",
                    rotation, true));

                nextY = 0;
                continue;
            }

            last = random.NextBoolean()
                ? Add(pieces, Attach(last, new Vec3<int>(0, nextY, -4), "bridge_steep_stairs",
                    rotation, true))
                : Add(pieces, Attach(last, new Vec3<int>(0, nextY, -8), "bridge_gentle_stairs",
                    rotation, true));

            nextY = 4;
        }

        if (!_shipCreated && random.NextInt(10 - genDepth) == 0) {
            Add(pieces, Attach(last,
                new Vec3<int>(-8 + random.NextInt(8), nextY, -70 + random.NextInt(10)), "ship",
                rotation, true));

            _shipCreated = true;
        } else if (!RecursiveChildren(HouseTower, genDepth + 1, last,
            new Vec3<int>(-3, nextY + 1, -11), pieces)) {
            return false;
        }

        last = Add(pieces, Attach(last, new Vec3<int>(4, nextY, 0), "bridge_end",
            Rotated(rotation, BlockRotation.Clockwise180), true));

        last.GenDepth = -1;
        return true;
    }

    /// <summary>
    /// A fat tower: a base, a middle, up to two more middles with bridges off each, and a top.
    /// </summary>
    /// <remarks>
    /// The loop's condition draws, so a fat tower that stops early has still consumed one number more
    /// than the sections it built.
    /// </remarks>
    private bool FatTower(int genDepth, EndCityPiece parent, Vec3<int> offset,
        List<StructurePiece> pieces) {
        BlockRotation rotation = parent.PlaceSettings.Rotation;

        EndCityPiece last = Add(pieces,
            Attach(parent, new Vec3<int>(-3, 4, -3), "fat_tower_base", rotation, true));

        last = Add(pieces, Attach(last, new Vec3<int>(0, 4, 0), "fat_tower_middle", rotation, true));

        for (int i = 0; i < 2 && random.NextInt(3) != 0; i++) {
            last = Add(pieces, Attach(last, new Vec3<int>(0, 8, 0), "fat_tower_middle", rotation,
                true));

            foreach ((BlockRotation turn, Vec3<int> bridgeOffset) in FatTowerBridges) {
                if (!random.NextBoolean()) {
                    continue;
                }

                EndCityPiece start = Add(pieces, Attach(last, bridgeOffset, "bridge_end",
                    Rotated(rotation, turn), true));

                RecursiveChildren(TowerBridge, genDepth + 1, start, NoOffset, pieces);
            }
        }

        Add(pieces, Attach(last, new Vec3<int>(-2, 8, -2), "fat_tower_top", rotation, true));
        return true;
    }

    private delegate bool SectionGenerator(int genDepth, EndCityPiece parent, Vec3<int> offset,
        List<StructurePiece> pieces);

    /// <summary>What a section that ignores its offset is handed. Only the house tower reads one.</summary>
    private static readonly Vec3<int> NoOffset = new(0, 0, 0);

    /// <summary>
    /// Runs one section into a scratch list, and keeps it only if nothing in it collides.
    /// </summary>
    /// <remarks>
    /// The tag is drawn <b>before</b> the collision walk and written onto every child, so a child that
    /// meets a sibling of the same attempt is allowed and one that meets the parent's own attempt is
    /// too. Anything else rejects the whole section.
    /// </remarks>
    private bool RecursiveChildren(SectionGenerator generator, int genDepth, EndCityPiece parent,
        Vec3<int> offset, List<StructurePiece> pieces) {

        if (genDepth > MaxGenDepth) {
            return false;
        }

        List<StructurePiece> children = [];

        if (!generator(genDepth, parent, offset, children)) {
            return false;
        }

        bool collision = false;
        int tag = random.NextInt();

        foreach (StructurePiece child in children) {
            child.GenDepth = tag;

            StructurePiece? hit = StructurePiece.FindCollisionPiece(pieces, child.BoundingBox);

            if (hit is not null && hit.GenDepth != parent.GenDepth) {
                collision = true;
                break;
            }
        }

        if (collision) {
            return false;
        }

        pieces.AddRange(children);
        return true;
    }

    /// <summary>
    /// A piece joined to another so that the offset inside the parent lands on the child's origin.
    /// </summary>
    private EndCityPiece Attach(EndCityPiece parent, Vec3<int> offset, string templateName,
        BlockRotation rotation, bool overwrite) {

        EndCityPiece child = new(templates, templateName, parent.TemplatePosition, rotation,
            overwrite);

        Vec3<int> origin = StructureTemplate.CalculateConnectedPosition(parent.PlaceSettings, offset,
            child.PlaceSettings, new Vec3<int>(0, 0, 0));

        child.Move(origin.X, origin.Y, origin.Z);
        return child;
    }

    private static EndCityPiece Add(List<StructurePiece> pieces, EndCityPiece piece) {
        pieces.Add(piece);
        return piece;
    }

    private static BlockRotation Rotated(BlockRotation rotation, BlockRotation by) {
        return (BlockRotation)(((int)rotation + (int)by) % 4);
    }
}
