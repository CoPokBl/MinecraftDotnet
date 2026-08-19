using ManagedServer.Placement;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// <c>BlockState.rotate</c> and <c>BlockState.mirror</c>: what a block turns into when the structure
/// holding it is placed facing a different way.
/// </summary>
/// <remarks>
/// Vanilla spreads this over 65 <c>rotate</c> and 60 <c>mirror</c> overrides, one per block class.
/// Resolution here is the same as <c>BlockPlacementRules</c>: a rule names the vanilla class it
/// transcribes as a <see cref="BlockClass"/> and <see cref="BlockClasses.Of"/> is walked
/// <b>nearest first</b>, which is Java's own virtual dispatch. So one <c>StairBlock</c> entry covers
/// all 60 stairs and the weathering copper ones.
/// <p/>
/// <b>Whether a class declares the override is the whole point of dispatching this way.</b> Fire and
/// chorus plant carry a connection per face and are never turned, because <c>FireBlock</c> and
/// <c>ChorusPlantBlock</c> declare neither hook; an anvil turns but does not mirror, because
/// <c>AnvilBlock</c> declares only the first. A rule keyed on the properties a block happens to have
/// cannot see any of that, and gets all three wrong in the permissive direction.
/// <p/>
/// The bodies are shared, because vanilla's are: almost every <c>mirror</c> is "turn a half if the
/// facing lies on the mirrored axis", which is <c>Mirror.getRotation</c>, and almost every
/// <c>rotate</c> is <c>Rotation.rotate</c> applied to whichever facing the block has.
/// <c>Conformance/blocktransform.sh</c> is what says the sharing is safe: it puts every block state
/// in the game through the real methods, and <c>BlockTransformConformanceTest</c> compares.
/// </remarks>
public static class BlockStateTransform {
    /// <summary>What one vanilla class does to a state. A hook it does not declare is left null.</summary>
    private sealed record Rule(
        Func<IBlock, BlockRotation, IBlock>? Rotate,
        Func<IBlock, BlockMirror, IBlock>? Mirror);

    /// <summary>Turns a state a quarter, half or three quarters clockwise about the vertical axis.</summary>
    public static IBlock Rotate(IBlock block, BlockRotation rotation) {
        if (rotation == BlockRotation.None) {
            return block;
        }

        return RuleFor(block)?.Rotate?.Invoke(block, rotation) ?? block;
    }

    /// <summary>Flips a state across an axis.</summary>
    public static IBlock Mirror(IBlock block, BlockMirror mirror) {
        if (mirror == BlockMirror.None) {
            return block;
        }

        return RuleFor(block)?.Mirror?.Invoke(block, mirror) ?? block;
    }

    /// <summary>
    /// <c>Rotation.rotate(Direction)</c>. A vertical facing is left alone, which is what makes a
    /// dropper pointing down stay pointing down.
    /// </summary>
    public static BlockFace RotateFace(BlockFace face, BlockRotation rotation) {
        if (!Directions.IsHorizontal(face)) {
            return face;
        }

        Direction direction = face.ToDirection();

        return rotation switch {
            BlockRotation.Clockwise90 => direction.ClockWise().ToFace(),
            BlockRotation.Clockwise180 => direction.Opposite().ToFace(),
            BlockRotation.CounterClockwise90 => direction.CounterClockWise().ToFace(),
            _ => face
        };
    }

    /// <summary><c>Mirror.mirror(Direction)</c>: the facing reflected, or itself off the axis.</summary>
    public static BlockFace MirrorFace(BlockFace face, BlockMirror mirror) {
        return OnAxis(face, mirror) ? face.ToDirection().Opposite().ToFace() : face;
    }

    /// <summary>Whether a facing lies on the axis a mirror reflects across.</summary>
    private static bool OnAxis(BlockFace face, BlockMirror mirror) {
        if (!Directions.IsHorizontal(face)) {
            return false;
        }

        return mirror switch {
            BlockMirror.LeftRight => face.ToDirection() is Direction.North or Direction.South,
            BlockMirror.FrontBack => face.ToDirection() is Direction.East or Direction.West,
            _ => false
        };
    }

    private static Rule? RuleFor(IBlock block) {
        foreach (BlockClass name in BlockClasses.Of(block.Identifier)) {
            if (Rules.TryGetValue(name, out Rule? rule)) {
                return rule;
            }
        }

        return null;
    }

    // ------------------------------------------------------------ the bodies

    /// <summary>
    /// The commonest pair by a wide margin: turn whichever facing the block has, and mirror by
    /// turning a half where the facing is on the mirrored axis.
    /// </summary>
    private static readonly Rule Facing = new(RotateFacing, MirrorFacing);

    /// <summary>Turns but never mirrors, which is what an anvil and a bell do.</summary>
    private static readonly Rule FacingRotateOnly = new(RotateFacing, null);

    private static IBlock RotateFacing(IBlock block, BlockRotation rotation) {
        if (block is IHorizontalFacing horizontal) {
            return horizontal.WithFacing(RotateFace(horizontal.Facing.ToFace(), rotation).ToDirection());
        }

        if (block is IDirectional directional) {
            return directional.WithFacing(RotateFace(directional.Facing.ToFace(), rotation).ToCardinal());
        }

        return block;
    }

    private static IBlock MirrorFacing(IBlock block, BlockMirror mirror) {
        if (block is IHorizontalFacing horizontal) {
            return horizontal.WithFacing(MirrorFace(horizontal.Facing.ToFace(), mirror).ToDirection());
        }

        if (block is IDirectional directional) {
            return directional.WithFacing(MirrorFace(directional.Facing.ToFace(), mirror).ToCardinal());
        }

        return block;
    }

    /// <summary>
    /// <c>JigsawBlock</c> and <c>CrafterBlock</c>: both directions of the orientation pair move.
    /// </summary>
    /// <remarks>
    /// Upstream this is <c>rotation.rotation().rotate(FrontAndTop)</c>, an octahedral group applied to
    /// the pair. Every rotation and mirror the structure system uses is about the vertical axis, and
    /// for those the group's action on a direction is exactly <see cref="RotateFace"/> and
    /// <see cref="MirrorFace"/>, so the pair is turned a direction at a time.
    /// <p/>
    /// <b>The top has to move with the front.</b> A jigsaw whose front is vertical carries its facing
    /// entirely in its top, and that top is what <c>canAttach</c> compares for an aligned joint, so a
    /// rule that turned only the front would leave every ceiling and floor connection of a rotated
    /// piece pointing the wrong way.
    /// </remarks>
    private static readonly Rule Oriented = new(
        (block, rotation) => TurnOrientation(block, face => RotateFace(face, rotation)),
        (block, mirror) => TurnOrientation(block, face => MirrorFace(face, mirror)));

    private static IBlock TurnOrientation(IBlock block, Func<BlockFace, BlockFace> turn) {
        if (block is not IOriented oriented) {
            return block;
        }

        (BlockFace front, BlockFace top) = Orientations.Split(oriented.Orientation);

        return oriented.WithOrientation(Orientations.Join(turn(front), turn(top)));
    }

    /// <summary>
    /// <c>HopperBlock</c>: the facing turns, and a hopper pointing down is left alone by both.
    /// </summary>
    /// <remarks>
    /// The mirror is written as a rotation upstream, <c>state.rotate(mirror.getRotation(facing))</c>,
    /// which comes to the same thing as reflecting the facing: a mirror across an axis the hopper does
    /// not point along is a half turn of nothing.
    /// </remarks>
    private static readonly Rule Hopper = new(
        (block, rotation) => TurnHopper(block, face => RotateFace(face, rotation)),
        (block, mirror) => TurnHopper(block, face => MirrorFace(face, mirror)));

    private static IBlock TurnHopper(IBlock block, Func<BlockFace, BlockFace> turn) {
        if (block is not IHopperFacing hopper) {
            return block;
        }

        return hopper.WithFacing(HopperDirectionExtensions.FromFace(turn(hopper.Facing.ToFace())));
    }

    /// <summary>
    /// <c>RotatedPillarBlock.rotatePillar</c>: a quarter turn either way swaps x and z, a half turn
    /// leaves the axis alone, and y is never touched. There is no mirror hook, since flipping a
    /// pillar across an axis it does not lie on changes nothing and across one it does is itself.
    /// </summary>
    private static readonly Rule Pillar = new(RotatePillar, null);

    private static IBlock RotatePillar(IBlock block, BlockRotation rotation) {
        if (block is not IAxisAligned aligned
            || rotation is not (BlockRotation.Clockwise90 or BlockRotation.CounterClockwise90)) {

            return block;
        }

        return aligned.Axis switch {
            Axis.X => aligned.WithAxis(Axis.Z),
            Axis.Z => aligned.WithAxis(Axis.X),
            _ => block
        };
    }

    /// <summary>
    /// <c>CrossCollisionBlock</c>, <c>WallBlock</c> and <c>RedStoneWireBlock</c>: the four horizontal
    /// sides move round together, and a mirror swaps one opposite pair.
    /// </summary>
    private static readonly Rule Connections = new(
        (block, rotation) => TurnConnections(block, face => RotateFace(face, rotation)),
        (block, mirror) => TurnConnections(block, face => MirrorFace(face, mirror)));

    /// <summary>
    /// Moves every horizontal side to where the turn sends it.
    /// </summary>
    /// <remarks>
    /// Read from a snapshot of the four sides rather than in place, because writing north from south
    /// and then south from north reads back what was just written.
    /// </remarks>
    private static IBlock TurnConnections(IBlock block, Func<BlockFace, BlockFace> turn) {
        if (block is IFaceConnected connected) {
            bool[] before = new bool[Directions.Horizontal.Length];

            for (int i = 0; i < before.Length; i++) {
                before[i] = connected.Connected(Directions.Horizontal[i]);
            }

            for (int i = 0; i < before.Length; i++) {
                connected = (IFaceConnected)connected.WithConnection(turn(Directions.Horizontal[i]),
                    before[i]);
            }

            block = connected;
        }

        // Walls are both: the four sides carry a height and the centre post is a plain connection.
        if (block is IWallConnected wall) {
            WallSide[] before = new WallSide[Directions.Horizontal.Length];

            for (int i = 0; i < before.Length; i++) {
                before[i] = wall.Side(Directions.Horizontal[i]);
            }

            for (int i = 0; i < before.Length; i++) {
                wall = (IWallConnected)wall.WithSide(turn(Directions.Horizontal[i]), before[i]);
            }

            block = wall;
        }

        // Redstone wire's sides are a third kind again: none, side or up rather than a flag or a
        // height, and the up value is what makes a wire climb the block beside it.
        if (block is IRedstoneConnected wire) {
            RedstoneWireConnection[] before = new RedstoneWireConnection[Directions.Horizontal.Length];

            for (int i = 0; i < before.Length; i++) {
                before[i] = wire.Connection(Directions.Horizontal[i]);
            }

            for (int i = 0; i < before.Length; i++) {
                wire = (IRedstoneConnected)wire.WithConnection(turn(Directions.Horizontal[i]), before[i]);
            }

            block = wire;
        }

        return block;
    }

    /// <summary>
    /// <c>StairBlock</c>. Rotation moves only the facing, and the mirror is the one shape in the
    /// game that is more than a half turn.
    /// </summary>
    private static readonly Rule Stairs = new(RotateFacing, MirrorStairs);

    /// <remarks>
    /// The corner shapes swap left for right, and which pair swaps depends on the mirror: across
    /// north and south the inner corners swap as well as the outer ones, across east and west only
    /// the outer ones do. A stair facing off the mirrored axis is left exactly as it is.
    /// </remarks>
    private static IBlock MirrorStairs(IBlock block, BlockMirror mirror) {
        if (block is not IStairShaped stairs || block is not IHorizontalFacing facing) {
            return block;
        }

        if (!OnAxis(facing.Facing.ToFace(), mirror)) {
            return block;
        }

        IBlock turned = RotateFacing(block, BlockRotation.Clockwise180);

        StairShape swapped = mirror == BlockMirror.LeftRight
            ? stairs.Shape switch {
                StairShape.InnerLeft => StairShape.InnerRight,
                StairShape.InnerRight => StairShape.InnerLeft,
                StairShape.OuterLeft => StairShape.OuterRight,
                StairShape.OuterRight => StairShape.OuterLeft,
                _ => StairShape.Straight
            }
            : stairs.Shape switch {
                StairShape.OuterLeft => StairShape.OuterRight,
                StairShape.OuterRight => StairShape.OuterLeft,
                _ => stairs.Shape
            };

        return ((IStairShaped)turned).WithShape(swapped);
    }

    /// <summary>
    /// <c>DoorBlock</c>: turns like anything else, and a mirror also swaps which side it hangs on so
    /// that a mirrored pair still opens outwards.
    /// </summary>
    private static readonly Rule Door = new(RotateFacing, (block, mirror) => {
        if (block is not IHinged hinged || block is not IHorizontalFacing facing) {
            return block;
        }

        BlockRotation asRotation = OnAxis(facing.Facing.ToFace(), mirror)
            ? BlockRotation.Clockwise180
            : BlockRotation.None;

        IBlock turned = RotateFacing(block, asRotation);

        return ((IHinged)turned).WithHinge(hinged.Hinge == LeftRight.Left
            ? LeftRight.Right
            : LeftRight.Left);
    });

    /// <summary>
    /// The rails, by turning the directions the shape is named after rather than by the ten entry
    /// table vanilla writes per rotation.
    /// </summary>
    /// <remarks>
    /// The two are the same function and <c>BlockTransformConformanceTest</c> is what says so: every
    /// rail shape under every rotation and mirror is in the fixture.
    /// </remarks>
    private static readonly Rule Rail = new(
        (block, rotation) => TurnRail(block, face => RotateFace(face, rotation)),
        (block, mirror) => TurnRail(block, face => MirrorFace(face, mirror)));

    private static IBlock TurnRail(IBlock block, Func<BlockFace, BlockFace> turn) {
        if (block is IRailShaped shaped) {
            return shaped.WithShape(TurnShape(shaped.Shape, turn));
        }

        if (block is IRailDirected directed) {
            return directed.WithShape(TurnDirection(directed.Shape, turn));
        }

        return block;
    }

    private static RailShape TurnShape(RailShape shape, Func<BlockFace, BlockFace> turn) {
        return shape switch {
            RailShape.NorthSouth => Straight(turn(BlockFace.NegZ)),
            RailShape.EastWest => Straight(turn(BlockFace.PosX)),

            RailShape.AscendingNorth => Ascending(turn(BlockFace.NegZ)),
            RailShape.AscendingSouth => Ascending(turn(BlockFace.PosZ)),
            RailShape.AscendingEast => Ascending(turn(BlockFace.PosX)),
            RailShape.AscendingWest => Ascending(turn(BlockFace.NegX)),

            RailShape.SouthEast => Curve(turn(BlockFace.PosZ), turn(BlockFace.PosX)),
            RailShape.SouthWest => Curve(turn(BlockFace.PosZ), turn(BlockFace.NegX)),
            RailShape.NorthWest => Curve(turn(BlockFace.NegZ), turn(BlockFace.NegX)),
            RailShape.NorthEast => Curve(turn(BlockFace.NegZ), turn(BlockFace.PosX)),

            _ => shape
        };
    }

    /// <summary>A powered rail's shorter set, which has the two straights and the four ascents.</summary>
    private static RailDirection TurnDirection(RailDirection shape, Func<BlockFace, BlockFace> turn) {
        RailShape asShape = shape switch {
            RailDirection.NorthSouth => RailShape.NorthSouth,
            RailDirection.EastWest => RailShape.EastWest,
            RailDirection.AscendingEast => RailShape.AscendingEast,
            RailDirection.AscendingWest => RailShape.AscendingWest,
            RailDirection.AscendingNorth => RailShape.AscendingNorth,
            _ => RailShape.AscendingSouth
        };

        return TurnShape(asShape, turn) switch {
            RailShape.NorthSouth => RailDirection.NorthSouth,
            RailShape.EastWest => RailDirection.EastWest,
            RailShape.AscendingEast => RailDirection.AscendingEast,
            RailShape.AscendingWest => RailDirection.AscendingWest,
            RailShape.AscendingNorth => RailDirection.AscendingNorth,
            _ => RailDirection.AscendingSouth
        };
    }

    /// <summary>The straight the turned face now lies along. A rail has no direction, only an axis.</summary>
    private static RailShape Straight(BlockFace face) {
        return face.ToDirection() is Direction.North or Direction.South
            ? RailShape.NorthSouth
            : RailShape.EastWest;
    }

    private static RailShape Ascending(BlockFace face) {
        return face.ToDirection() switch {
            Direction.North => RailShape.AscendingNorth,
            Direction.South => RailShape.AscendingSouth,
            Direction.East => RailShape.AscendingEast,
            _ => RailShape.AscendingWest
        };
    }

    /// <summary>The curve joining two faces, whichever order they arrive in.</summary>
    private static RailShape Curve(BlockFace first, BlockFace second) {
        bool north = first.ToDirection() == Direction.North || second.ToDirection() == Direction.North;
        bool east = first.ToDirection() == Direction.East || second.ToDirection() == Direction.East;

        return north
            ? east ? RailShape.NorthEast : RailShape.NorthWest
            : east ? RailShape.SouthEast : RailShape.SouthWest;
    }

    /// <summary>
    /// A standing sign or banner, whose facing is a sixteen step wheel rather than one of four
    /// directions.
    /// </summary>
    private static readonly Rule Steps = new(
        (block, rotation) => block is IRotated rotated
            ? rotated.WithRotation(RotateSteps(rotated.Rotation, 16, rotation))
            : block,
        (block, mirror) => block is IRotated rotated
            ? rotated.WithRotation(MirrorSteps(rotated.Rotation, 16, mirror))
            : block);

    /// <summary><c>Rotation.rotate(int, int)</c> over a wheel of the given number of steps.</summary>
    private static int RotateSteps(int value, int steps, BlockRotation rotation) {
        return rotation switch {
            BlockRotation.Clockwise90 => (value + steps / 4) % steps,
            BlockRotation.Clockwise180 => (value + steps / 2) % steps,
            BlockRotation.CounterClockwise90 => (value + steps * 3 / 4) % steps,
            _ => value
        };
    }

    /// <summary>
    /// <c>Mirror.mirror(int, int)</c>: a reflection of a sixteen step rotation, about the axis the
    /// mirror runs along.
    /// </summary>
    /// <remarks>
    /// The step is first pulled into the range around zero, which is what makes the reflection
    /// symmetric rather than off by a step on one side of the wheel.
    /// </remarks>
    private static int MirrorSteps(int value, int steps, BlockMirror mirror) {
        int halfSteps = steps / 2;
        int corrected = value > halfSteps ? value - steps : value;

        return mirror switch {
            BlockMirror.LeftRight => (halfSteps - corrected + steps) % steps,
            BlockMirror.FrontBack => (steps - corrected) % steps,
            _ => value
        };
    }

    // ------------------------------------------------------------- the table

    /// <summary>
    /// The classes whose hook cannot be transcribed here, because the property it moves has no
    /// generated interface to read it through.
    /// </summary>
    /// <remarks>
    /// Each needs the same thing: the property's value set made shared in <c>BlockCodeGen</c> and an
    /// interface over it, the way <c>IHorizontalFacing</c> and <c>IRailShaped</c> already are. Until
    /// then they are left unturned, which is wrong in the direction of doing nothing rather than of
    /// doing something arbitrary, and <c>BlockTransformConformanceTest</c> carries them as a
    /// baseline it asserts in both directions.
    /// <p/>
    /// The one left is placed by nothing: there is no nether portal block in any template, and no
    /// transcribed structure writes one.
    /// </remarks>
    public static readonly BlockClass[] ClassesWithoutAPropertyInterface = [
        // axis restricted to x and z, so the generator gives it a block local enum.
        BlockClass.NetherPortalBlock
    ];

    /// <summary>
    /// The classes that declare a hook, and which body each one is.
    /// </summary>
    /// <remarks>
    /// Every entry is a class that really declares <c>rotate</c> or <c>mirror</c> upstream, and a
    /// class that declares only one of them has null for the other. Anything not named here inherits
    /// <c>BlockBehaviour</c>'s identity, which is most of the game.
    /// <p/>
    /// Declared after the bodies it names, because C# runs static field initialisers in declaration
    /// order and a table built above them is built out of nulls.
    /// </remarks>
    private static readonly Dictionary<BlockClass, Rule> Rules = BuildRules();

    /// <summary>
    /// One entry per vanilla class that declares a hook.
    /// </summary>
    /// <remarks>
    /// One class is deliberately absent and named in
    /// <see cref="ClassesWithoutAPropertyInterface"/>: its facing lives in a property with no
    /// generated interface, so a rule for it could not read it. It is baselined in the conformance
    /// test rather than silently wrong.
    /// </remarks>
    private static Dictionary<BlockClass, Rule> BuildRules() {
        Dictionary<BlockClass, Rule> rules = new() {
            // The plain facing pair, which is what most of the overrides amount to.
            { BlockClass.HorizontalDirectionalBlock, Facing },
            { BlockClass.AbstractFurnaceBlock, Facing },
            { BlockClass.AmethystClusterBlock, Facing },
            { BlockClass.AttachedStemBlock, Facing },
            { BlockClass.BarrelBlock, Facing },
            { BlockClass.BaseCoralWallFanBlock, Facing },
            { BlockClass.BeehiveBlock, Facing },
            { BlockClass.CalibratedSculkSensorBlock, Facing },
            { BlockClass.CampfireBlock, Facing },
            { BlockClass.ChestBlock, Facing },
            { BlockClass.ChiseledBookShelfBlock, Facing },
            { BlockClass.CommandBlock, Facing },
            { BlockClass.CopperGolemStatueBlock, Facing },
            { BlockClass.CreakingHeartBlock, Pillar },
            { BlockClass.DecoratedPotBlock, Facing },
            { BlockClass.DispenserBlock, Facing },
            { BlockClass.EndPortalFrameBlock, Facing },
            { BlockClass.EnderChestBlock, Facing },
            { BlockClass.GrindstoneBlock, Facing },
            { BlockClass.LadderBlock, Facing },
            { BlockClass.LecternBlock, Facing },
            { BlockClass.MovingPistonBlock, Facing },
            { BlockClass.ObserverBlock, Facing },
            { BlockClass.PistonBaseBlock, Facing },
            { BlockClass.PistonHeadBlock, Facing },
            { BlockClass.RedstoneWallTorchBlock, Facing },
            { BlockClass.RodBlock, Facing },
            { BlockClass.ShelfBlock, Facing },
            { BlockClass.ShulkerBoxBlock, Facing },
            { BlockClass.SmallDripleafBlock, Facing },
            { BlockClass.StonecutterBlock, Facing },
            { BlockClass.TripWireHookBlock, Facing },
            { BlockClass.VaultBlock, Facing },
            { BlockClass.WallBannerBlock, Facing },
            { BlockClass.WallHangingSignBlock, Facing },
            { BlockClass.WallSignBlock, Facing },
            { BlockClass.WallSkullBlock, Facing },
            { BlockClass.WallTorchBlock, Facing },

            // Declares rotate and not mirror, so a mirrored one keeps its facing.
            { BlockClass.AnvilBlock, FacingRotateOnly },

            { BlockClass.RotatedPillarBlock, Pillar },
            { BlockClass.InfestedRotatedPillarBlock, Pillar },

            { BlockClass.CrossCollisionBlock, Connections },
            { BlockClass.WallBlock, Connections },
            { BlockClass.TripWireBlock, Connections },
            { BlockClass.VineBlock, Connections },
            { BlockClass.MultifaceBlock, Connections },
            { BlockClass.RedStoneWireBlock, Connections },
            { BlockClass.MossyCarpetBlock, Connections },
            { BlockClass.HugeMushroomBlock, Connections },
            { BlockClass.FlowerBedBlock, Facing },
            { BlockClass.LeafLitterBlock, Facing },

            { BlockClass.StairBlock, Stairs },
            { BlockClass.DoorBlock, Door },

            { BlockClass.RailBlock, Rail },
            { BlockClass.PoweredRailBlock, Rail },
            { BlockClass.DetectorRailBlock, Rail },

            { BlockClass.StandingSignBlock, Steps },
            { BlockClass.BannerBlock, Steps },
            { BlockClass.SkullBlock, Steps },
            { BlockClass.CeilingHangingSignBlock, Steps },

            { BlockClass.JigsawBlock, Oriented },
            { BlockClass.CrafterBlock, Oriented },
            { BlockClass.HopperBlock, Hopper },

            // A bell picks an attachment as well as a facing, and only the facing turns.
            { BlockClass.BellBlock, Facing }
        };

        foreach (BlockClass name in ClassesWithoutAPropertyInterface) {
            rules.TryAdd(name, new Rule(null, null));
        }

        return rules;
    }

}
