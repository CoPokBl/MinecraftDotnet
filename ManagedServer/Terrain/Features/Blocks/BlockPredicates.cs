using ManagedServer.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Blocks;

/// <summary>
/// <c>BlockPredicate</c>: a question a feature or a placement modifier asks about a position.
/// </summary>
/// <remarks>
/// Everything but the combinators tests a position <b>offset</b> from the one given, which is what
/// lets a filter written as "air here, dirt below" be two predicates rather than a special case.
/// </remarks>
public abstract record BlockPredicate {
    public abstract bool Test(IFeatureLevel level, int x, int y, int z);

    public bool Test(IFeatureLevel level, Vec3<int> pos) => Test(level, pos.X, pos.Y, pos.Z);

    /// <summary><c>TrueBlockPredicate</c>.</summary>
    public sealed record True : BlockPredicate {
        public static readonly True Instance = new();

        public override bool Test(IFeatureLevel level, int x, int y, int z) => true;
    }

    /// <summary><c>NotPredicate</c>.</summary>
    public sealed record Not(BlockPredicate Predicate) : BlockPredicate {
        public override bool Test(IFeatureLevel level, int x, int y, int z) {
            return !Predicate.Test(level, x, y, z);
        }
    }

    /// <summary><c>AllOfPredicate</c>.</summary>
    public sealed record AllOf(IReadOnlyList<BlockPredicate> Predicates) : BlockPredicate {
        public override bool Test(IFeatureLevel level, int x, int y, int z) {
            foreach (BlockPredicate predicate in Predicates) {
                if (!predicate.Test(level, x, y, z)) {
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary><c>AnyOfPredicate</c>.</summary>
    public sealed record AnyOf(IReadOnlyList<BlockPredicate> Predicates) : BlockPredicate {
        public override bool Test(IFeatureLevel level, int x, int y, int z) {
            foreach (BlockPredicate predicate in Predicates) {
                if (predicate.Test(level, x, y, z)) {
                    return true;
                }
            }

            return false;
        }
    }

    /// <summary><c>MatchingBlockTagPredicate</c>.</summary>
    public sealed record MatchingBlockTag(Vec3<int> Offset, Identifier Tag) : BlockPredicate {
        public override bool Test(IFeatureLevel level, int x, int y, int z) {
            return level.Blocks.IsIn(Tag, level.GetState(x + Offset.X, y + Offset.Y, z + Offset.Z));
        }
    }

    /// <summary>
    /// <c>MatchingBlocksPredicate</c>. The set is state ids rather than blocks because that is what a
    /// read hands back, and a block's states are all in it or all out.
    /// </summary>
    public sealed record MatchingBlocks(Vec3<int> Offset, IReadOnlySet<Identifier> Blocks) : BlockPredicate {
        public override bool Test(IFeatureLevel level, int x, int y, int z) {
            uint state = level.GetState(x + Offset.X, y + Offset.Y, z + Offset.Z);
            return Blocks.Contains(level.Registry.Blocks.GetByStateId(state).Identifier);
        }
    }

    /// <summary>
    /// <c>MatchingFluidsPredicate</c>. <c>minecraft:empty</c> is the fluid a state with none carries,
    /// so "no fluid" is written as a match against it rather than as a negation.
    /// </summary>
    public sealed record MatchingFluids(Vec3<int> Offset, IReadOnlySet<Identifier> Fluids) : BlockPredicate {
        private static readonly Identifier Empty = "minecraft:empty";

        public override bool Test(IFeatureLevel level, int x, int y, int z) {
            uint state = level.GetState(x + Offset.X, y + Offset.Y, z + Offset.Z);
            Identifier fluid = level.Registry.Blocks.GetByStateId(state).Fluid ?? Empty;
            return Fluids.Contains(fluid);
        }
    }

    /// <summary><c>SolidPredicate</c>, which is <c>BlockState.isSolid</c>.</summary>
    public sealed record Solid(Vec3<int> Offset) : BlockPredicate {
        public override bool Test(IFeatureLevel level, int x, int y, int z) {
            return level.Blocks.IsSolid(level.GetState(x + Offset.X, y + Offset.Y, z + Offset.Z));
        }
    }

    /// <summary><c>ReplaceablePredicate</c>.</summary>
    public sealed record Replaceable(Vec3<int> Offset) : BlockPredicate {
        public override bool Test(IFeatureLevel level, int x, int y, int z) {
            return level.Blocks.IsReplaceable(level.GetState(x + Offset.X, y + Offset.Y, z + Offset.Z));
        }
    }

    /// <summary><c>InsideWorldBoundsPredicate</c>.</summary>
    public sealed record InsideWorldBounds(Vec3<int> Offset) : BlockPredicate {
        public override bool Test(IFeatureLevel level, int x, int y, int z) {
            return level.InWorld(y + Offset.Y);
        }
    }

    /// <summary>
    /// <c>HasSturdyFacePredicate</c>, which is <c>BlockState.isFaceSturdy</c> and therefore the same
    /// support shape question the block placement rules ask.
    /// </summary>
    public sealed record HasSturdyFace(Vec3<int> Offset, BlockFace Face) : BlockPredicate {
        public override bool Test(IFeatureLevel level, int x, int y, int z) {
            uint state = level.GetState(x + Offset.X, y + Offset.Y, z + Offset.Z);
            return ShapeSupport.IsFaceSturdy(level.Registry.Blocks.GetByStateId(state), Face);
        }
    }

    /// <summary>
    /// <c>WouldSurvivePredicate</c>: whether the state would stay if it were put at the position.
    /// </summary>
    /// <remarks>
    /// Vanilla calls <c>BlockState.canSurvive</c>, which here lives on <c>IBlockPlacementRule</c> and
    /// takes a <c>World</c> the generator has none of. So this is a separate transcription of the
    /// survival rules of the twelve blocks the vanilla data actually asks about, in
    /// <see cref="FeatureSurvival"/>, rather than a call into the placement registry.
    /// </remarks>
    public sealed record WouldSurvive(Vec3<int> Offset, IBlock State) : BlockPredicate {
        public override bool Test(IFeatureLevel level, int x, int y, int z) {
            return FeatureSurvival.CanSurvive(State, level, x + Offset.X, y + Offset.Y, z + Offset.Z);
        }
    }

    /// <summary>
    /// <c>UnobstructedPredicate</c>: nothing in the way of a line from the position to the one below
    /// it. Only reachable through a hand built predicate upstream, so it is here for completeness and
    /// tests the position alone.
    /// </summary>
    public sealed record Unobstructed(Vec3<int> Offset) : BlockPredicate {
        public override bool Test(IFeatureLevel level, int x, int y, int z) {
            return level.Blocks.IsAir(level.GetState(x + Offset.X, y + Offset.Y, z + Offset.Z));
        }
    }
}
