using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement;

/// <summary>
/// A player right clicking a block, vanilla's <c>BlockPlaceContext</c>.
/// <p/>
/// Vanilla caches exactly two things over the raw hit, and everything else is derived from them: the
/// position across the clicked face, and whether the clicked block agreed to be replaced. Both are
/// worked out in the constructor because the second one asks a rule a question, and asking it again
/// part way through placement could give a different answer once the world has moved.
/// </summary>
public sealed class PlayerPlaceContext : IBlockPlaceContext {
    private readonly Vec3<int> _relativePos;

    /// <summary>
    /// Vanilla declares this as <c>protected boolean replaceClicked = true</c>, and the initialiser
    /// is load bearing rather than tidiness. The constructor asks the clicked block whether it can be
    /// replaced, that question can ask this context the same thing back, and the answer it gets is
    /// whatever the field holds at the time. Because the field starts <b>true</b>, the first call
    /// reads "yes, replacing the clicked block" and the blocks that branch on it take their
    /// geometric branch, not their unconditional one.
    /// <p/>
    /// Four blocks depend on it: <c>SlabBlock</c> and <c>SnowLayerBlock</c> from here, and
    /// <c>LadderBlock</c> and <c>TrapDoorBlock</c> later on when it holds its real value. Starting it
    /// false instead is what made a slab clicked on the side double rather than being placed beside.
    /// </summary>
    private readonly bool _replaceClicked = true;
    private BlockFace[]? _nearestLooking;

    public World World { get; }
    public Player? Player { get; }
    public ItemStack ItemInHand { get; }
    public Hand Hand { get; }
    public Vec3<int> HitPos { get; }
    public BlockFace ClickedFace { get; }
    public Vec3<double> ClickLocation { get; }
    public bool IsInside { get; }

    /// <summary>The rules, needed to ask the clicked block whether it can be replaced.</summary>
    private readonly BlockPlacementRules _rules;

    public PlayerPlaceContext(World world, Player? player, Hand hand, ItemStack itemInHand,
        Vec3<int> hitPos, BlockFace clickedFace, Vec3<double> clickLocation, bool isInside,
        BlockPlacementRules rules) {
        World = world;
        Player = player;
        Hand = hand;
        ItemInHand = itemInHand;
        HitPos = hitPos;
        ClickedFace = clickedFace;
        ClickLocation = clickLocation;
        IsInside = isInside;
        _rules = rules;

        _relativePos = hitPos.GetBlockTowards(clickedFace);

        // Reads _replaceClicked as true while it runs, per the note on the field, so PlacePos below
        // is the clicked block and the geometric branches see the block they are being asked about.
        _replaceClicked = CanBeReplaced(world.GetBlock(hitPos));
    }

    public Vec3<int> PlacePos => _replaceClicked ? HitPos : _relativePos;

    public bool ReplacingClickedOnBlock => _replaceClicked;

    public Direction HorizontalDirection =>
        Player is null ? Direction.North : Directions.FromYRot(Player.Yaw.DegreesF);

    public float Rotation => Player?.Yaw.DegreesF ?? 0f;

    public bool IsSecondaryUseActive => Player?.Crouching ?? false;

    public BlockFace NearestLookingDirection => LookOrder()[0];

    public BlockFace NearestLookingVerticalDirection =>
        Directions.FacingAxisY(Player?.Pitch.DegreesF ?? 0f);

    public BlockFace[] NearestLookingDirections {
        get {
            BlockFace[] order = LookOrder();
            if (_replaceClicked) {
                return order;
            }

            // Vanilla rotates the opposite of the clicked face to the front, keeping the rest in
            // order. That is what makes a torch attach to the wall you aimed at rather than to
            // whichever wall you happen to be more square to.
            BlockFace wanted = ClickedFace.Opposite();
            BlockFace[] rotated = new BlockFace[order.Length];
            rotated[0] = wanted;
            int at = 1;
            foreach (BlockFace face in order) {
                if (face != wanted) {
                    rotated[at++] = face;
                }
            }

            return rotated;
        }
    }

    public bool CanPlace() {
        return _replaceClicked || CanBeReplaced(World.GetBlock(PlacePos));
    }

    public bool CanReplaceAt(Vec3<int> pos) {
        return CanBeReplaced(World.GetBlock(pos));
    }

    public IBlockPlaceContext At(Vec3<int> pos, BlockFace face) {
        // Vanilla synthesises a hit at the centre of the face it came in through.
        Vec3<double> centre = new(pos.X + 0.5, pos.Y + 0.5, pos.Z + 0.5);
        return new PlayerPlaceContext(World, Player, Hand, ItemInHand, pos.GetBlockTowards(face.Opposite()),
            face, centre, false, _rules);
    }

    /// <summary>
    /// Asks the block's own rule whether it can be replaced, which is what makes a slab double and
    /// a snow layer stack rather than being placed beside.
    /// </summary>
    private bool CanBeReplaced(IBlock existing) {
        IBlockPlacementRule? rule = _rules.For(existing, World);
        return rule?.CanBeReplaced(existing, this)
               ?? IBlockPlacementRule.DefaultCanBeReplaced(existing, this);
    }

    /// <summary>
    /// The look order, computed once. A placement asks for it up to six times while it walks the
    /// candidates, and it is a dozen table lookups and float multiplies each time.
    /// </summary>
    private BlockFace[] LookOrder() {
        return _nearestLooking ??= Player is null
            ? Directions.All
            : Directions.OrderedByNearest(Player.Pitch.DegreesF, Player.Yaw.DegreesF);
    }
}
