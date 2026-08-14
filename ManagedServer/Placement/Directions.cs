using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Mth = Minecraft.Schemas.Mth;

namespace ManagedServer.Placement;

/// <summary>
/// The parts of vanilla's <c>Direction</c> that placement needs, over <see cref="BlockFace"/>.
/// <p/>
/// <see cref="Cardinal"/> shares <see cref="BlockFace"/>'s numbering exactly (down 0, up 1, north 2,
/// south 3, west 4, east 5), which is vanilla's <c>Direction</c> ordinal order, so those two convert
/// with a cast. <see cref="Direction"/> is the four horizontals only and does not.
/// </summary>
public static class Directions {
    /// <summary>
    /// Vanilla's <c>Direction.values()</c> order, which is what <c>orderedByNearest</c> sorts and
    /// what every <c>PROPERTY_BY_DIRECTION</c> map is built from.
    /// </summary>
    public static readonly BlockFace[] All = [
        BlockFace.NegY, BlockFace.PosY, BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX, BlockFace.PosX
    ];

    /// <summary>
    /// <c>Direction.Plane.HORIZONTAL</c>, in vanilla's order: north, south, west, east. The order is
    /// load bearing wherever a search takes the first match.
    /// </summary>
    public static readonly BlockFace[] Horizontal = [
        BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX, BlockFace.PosX
    ];

    /// <summary>
    /// <c>BlockBehaviour.UPDATE_SHAPE_ORDER</c>: west, east, north, south, down, up. Deliberately not
    /// <see cref="All"/>. A cascade of shape updates visits neighbours in this order and two blocks
    /// that each react to the other settle differently if it changes.
    /// </summary>
    public static readonly BlockFace[] UpdateShapeOrder = [
        BlockFace.NegX, BlockFace.PosX, BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegY, BlockFace.PosY
    ];

    public static Cardinal ToCardinal(this BlockFace face) => (Cardinal)(int)face;

    public static BlockFace ToFace(this Cardinal cardinal) => (BlockFace)(int)cardinal;

    public static bool IsHorizontal(BlockFace face) => face is not (BlockFace.NegY or BlockFace.PosY);

    /// <summary>The horizontal face as a <see cref="Direction"/>. Throws for up or down.</summary>
    public static Direction ToDirection(this BlockFace face) => face switch {
        BlockFace.NegZ => Direction.North,
        BlockFace.PosZ => Direction.South,
        BlockFace.NegX => Direction.West,
        BlockFace.PosX => Direction.East,
        _ => throw new ArgumentOutOfRangeException(nameof(face), face, "Not a horizontal face.")
    };

    public static BlockFace ToFace(this Direction direction) => direction switch {
        Direction.North => BlockFace.NegZ,
        Direction.South => BlockFace.PosZ,
        Direction.West => BlockFace.NegX,
        Direction.East => BlockFace.PosX,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Unknown Direction value.")
    };

    /// <summary><c>Direction.getClockWise()</c> about the Y axis: north to east to south to west.</summary>
    public static Direction ClockWise(this Direction direction) => direction switch {
        Direction.North => Direction.East,
        Direction.East => Direction.South,
        Direction.South => Direction.West,
        Direction.West => Direction.North,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Unknown Direction value.")
    };

    /// <summary><c>Direction.getCounterClockWise()</c> about the Y axis.</summary>
    public static Direction CounterClockWise(this Direction direction) => direction switch {
        Direction.North => Direction.West,
        Direction.West => Direction.South,
        Direction.South => Direction.East,
        Direction.East => Direction.North,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Unknown Direction value.")
    };

    /// <summary>Whether two horizontals share an axis, ie. are equal or opposite.</summary>
    public static bool SameAxis(Direction a, Direction b) => a == b || a == b.Opposite();

    /// <summary>
    /// The same over faces, where a vertical is on the Y axis and so shares it with nothing
    /// horizontal. Written as equal or opposite rather than through an axis enum, which there is
    /// none of here.
    /// </summary>
    public static bool SameAxis(BlockFace a, BlockFace b) => a == b || a == b.Opposite();

    public static Direction Opposite(this Direction direction) => direction switch {
        Direction.North => Direction.South,
        Direction.South => Direction.North,
        Direction.West => Direction.East,
        Direction.East => Direction.West,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Unknown Direction value.")
    };

    /// <summary>
    /// <c>Direction.get2DDataValue</c>: south 0, west 1, north 2, east 3. The clockwise order the
    /// sixteen step sign rotation and the dispenser context are both counted in.
    /// </summary>
    public static int To2DDataValue(this Direction direction) => direction switch {
        Direction.South => 0,
        Direction.West => 1,
        Direction.North => 2,
        Direction.East => 3,
        _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Unknown Direction value.")
    };

    /// <summary><c>Direction.from2DDataValue</c>, the inverse of <see cref="To2DDataValue"/>.</summary>
    public static Direction From2DDataValue(int value) => (value & 3) switch {
        0 => Direction.South,
        1 => Direction.West,
        2 => Direction.North,
        _ => Direction.East
    };

    /// <summary>
    /// <c>Direction.fromYRot</c>. Vanilla is
    /// <c>from2DDataValue(Mth.floor(yRot / 90.0 + 0.5) &amp; 3)</c>, and the floor is what puts the
    /// boundaries at the diagonals rather than at the axes.
    /// </summary>
    public static Direction FromYRot(double yRot) {
        return From2DDataValue((int)Math.Floor(yRot / 90.0 + 0.5) & 3);
    }

    public static BlockFace Opposite(this BlockFace face) => face switch {
        BlockFace.NegY => BlockFace.PosY,
        BlockFace.PosY => BlockFace.NegY,
        BlockFace.NegZ => BlockFace.PosZ,
        BlockFace.PosZ => BlockFace.NegZ,
        BlockFace.NegX => BlockFace.PosX,
        _ => BlockFace.NegX
    };

    /// <summary>
    /// <c>Direction.orderedByNearest</c>: the six faces sorted by how closely they line up with
    /// where the entity is looking, nearest first. Every attachable block places by walking this and
    /// taking the first candidate that survives, so its order decides which wall a torch lands on.
    /// <p/>
    /// Two things are load bearing and neither is obvious. The trigonometry is
    /// <see cref="Mth"/>, vanilla's <b>sine table</b>, not <c>Math.Sin</c>: the table is wrong by up
    /// to 1e-4, and these are strict comparisons between products of its outputs, so an accurate
    /// computation picks the other face along the diagonals. And it is <b>float throughout</b>, with
    /// the widening happening only inside <c>Mth</c>; carrying doubles moves the same boundaries.
    /// <p/>
    /// Vanilla reads the interpolated view rotation, <c>getViewXRot(1.0f)</c>, which for anything
    /// that is not riding is just the entity's own rotation.
    /// </summary>
    public static BlockFace[] OrderedByNearest(float xRot, float yRot) {
        float pitch = xRot * (float)(Math.PI / 180.0);
        float yaw = -yRot * (float)(Math.PI / 180.0);
        float pitchSin = Mth.Sin(pitch);
        float pitchCos = Mth.Cos(pitch);
        float yawSin = Mth.Sin(yaw);
        float yawCos = Mth.Cos(yaw);
        bool xPos = yawSin > 0.0f;
        bool yPos = pitchSin < 0.0f;
        bool zPos = yawCos > 0.0f;
        float xYaw = xPos ? yawSin : -yawSin;
        float yMag = yPos ? -pitchSin : pitchSin;
        float zYaw = zPos ? yawCos : -yawCos;
        float xMag = xYaw * pitchCos;
        float zMag = zYaw * pitchCos;
        BlockFace axisX = xPos ? BlockFace.PosX : BlockFace.NegX;
        BlockFace axisY = yPos ? BlockFace.PosY : BlockFace.NegY;
        BlockFace axisZ = zPos ? BlockFace.PosZ : BlockFace.NegZ;

        if (xYaw > zYaw) {
            if (yMag > xMag) {
                return MakeDirectionArray(axisY, axisX, axisZ);
            }

            return zMag > yMag
                ? MakeDirectionArray(axisX, axisZ, axisY)
                : MakeDirectionArray(axisX, axisY, axisZ);
        }

        if (yMag > zMag) {
            return MakeDirectionArray(axisY, axisZ, axisX);
        }

        return xMag > yMag
            ? MakeDirectionArray(axisZ, axisX, axisY)
            : MakeDirectionArray(axisZ, axisY, axisX);
    }

    /// <summary><c>Direction.makeDirectionArray</c>: three faces, then their opposites reversed.</summary>
    private static BlockFace[] MakeDirectionArray(BlockFace first, BlockFace second, BlockFace third) {
        return [first, second, third, third.Opposite(), second.Opposite(), first.Opposite()];
    }

    /// <summary>
    /// <c>Direction.getFacingAxis</c>, the vertical case only, which is the only one anything uses:
    /// <c>SpeleothemBlock</c> asks for the Y axis to decide whether a dripstone points up or down.
    /// </summary>
    public static BlockFace FacingAxisY(float xRot) {
        return xRot < 0.0f ? BlockFace.PosY : BlockFace.NegY;
    }
}
