using ManagedServer.Terrain.Features;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// <c>RuleTest</c>: whether one block state matches, which is half of what a <c>rule</c> processor is.
/// </summary>
/// <remarks>
/// A rule asks two of these, and the difference between them is what is being tested rather than how:
/// the <b>input</b> predicate looks at the state the template holds, and the <b>location</b> predicate
/// at the state already in the world where it is about to go. That is what lets a village path replace
/// grass with a path block and leave the water alone.
/// <p/>
/// Some of them draw, so the order they are asked in is part of the world. The position is the one
/// the block is going to, for the input predicate as much as for the location one.
/// </remarks>
public interface IRuleTest {
    bool Test(uint stateId, Vec3<int> pos, RandomSource random, IFeatureLevel level);

    /// <summary>
    /// The same test against what is already at a position.
    /// </summary>
    /// <remarks>
    /// Overridden by <see cref="AlwaysTrue"/> alone, so that the commonest location predicate in the
    /// game does not read a block to ignore it.
    /// </remarks>
    bool TestAgainstWorld(IFeatureLevel level, Vec3<int> pos, RandomSource random) {
        return Test(level.GetState(pos.X, pos.Y, pos.Z), pos, random, level);
    }

    public sealed class AlwaysTrue : IRuleTest {
        public static readonly AlwaysTrue Instance = new();

        public bool Test(uint stateId, Vec3<int> pos, RandomSource random, IFeatureLevel level) => true;

        public bool TestAgainstWorld(IFeatureLevel level, Vec3<int> pos, RandomSource random) => true;
    }

    /// <summary>Matches any state of one block.</summary>
    public sealed class BlockMatch(Identifier block) : IRuleTest {
        public bool Test(uint stateId, Vec3<int> pos, RandomSource random, IFeatureLevel level) {
            return level.Registry.Blocks.GetByStateId(stateId).Identifier.Equals(block);
        }
    }

    /// <summary>Matches one exact state, properties included.</summary>
    public sealed class BlockStateMatch(uint stateId) : IRuleTest {
        public bool Test(uint state, Vec3<int> pos, RandomSource random, IFeatureLevel level) => state == stateId;
    }

    public sealed class TagMatch(Identifier tag) : IRuleTest {
        public bool Test(uint stateId, Vec3<int> pos, RandomSource random, IFeatureLevel level) {
            return level.Blocks.IsIn(tag, stateId);
        }
    }

    /// <summary>
    /// A block match that then rolls, which is what scatters cracked bricks through a wall.
    /// </summary>
    /// <remarks>
    /// The draw happens <b>only when the block matched</b>, because the two are one <c>&amp;&amp;</c>
    /// upstream and Java short circuits. Rolling first would consume a number per position tested
    /// rather than per position that could match, and move everything the rule places afterwards.
    /// </remarks>
    public sealed class RandomBlockMatch(Identifier block, float probability) : IRuleTest {
        public bool Test(uint stateId, Vec3<int> pos, RandomSource random, IFeatureLevel level) {
            return level.Registry.Blocks.GetByStateId(stateId).Identifier.Equals(block)
                && random.NextFloat() < probability;
        }
    }

    public sealed class RandomBlockStateMatch(uint stateId, float probability) : IRuleTest {
        public bool Test(uint state, Vec3<int> pos, RandomSource random, IFeatureLevel level) {
            return state == stateId && random.NextFloat() < probability;
        }
    }

    /// <summary>Every rule in order, stopping at the first that fails, so a later one's draw may not happen.</summary>
    public sealed class AllOf(IReadOnlyList<IRuleTest> rules) : IRuleTest {
        public bool Test(uint stateId, Vec3<int> pos, RandomSource random, IFeatureLevel level) {
            foreach (IRuleTest rule in rules) {
                if (!rule.Test(stateId, pos, random, level)) {
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>Every rule in order, stopping at the first that holds.</summary>
    public sealed class AnyOf(IReadOnlyList<IRuleTest> rules) : IRuleTest {
        public bool Test(uint stateId, Vec3<int> pos, RandomSource random, IFeatureLevel level) {
            foreach (IRuleTest rule in rules) {
                if (rule.Test(stateId, pos, random, level)) {
                    return true;
                }
            }

            return false;
        }
    }

    public sealed class Not(IRuleTest rule) : IRuleTest {
        public bool Test(uint stateId, Vec3<int> pos, RandomSource random, IFeatureLevel level) {
            return !rule.Test(stateId, pos, random, level);
        }
    }

    /// <summary>The position's y, both bounds inclusive; the state is not read.</summary>
    public sealed class HeightMatch(int minInclusive, int maxInclusive) : IRuleTest {
        public bool Test(uint stateId, Vec3<int> pos, RandomSource random, IFeatureLevel level) {
            return minInclusive <= pos.Y && pos.Y <= maxInclusive;
        }
    }
}

/// <summary>
/// <c>PosRuleTest</c>: whether a rule applies at a position, which is the third predicate of a rule.
/// </summary>
/// <remarks>
/// Both of the real ones fade a chance out with distance from the structure's reference position,
/// which is how an ancient city's ruin thins towards its edges.
/// </remarks>
public interface IPosRuleTest {
    bool Test(Vec3<int> inTemplate, Vec3<int> world, Vec3<int> reference, RandomSource random);

    public sealed class AlwaysTrue : IPosRuleTest {
        public static readonly AlwaysTrue Instance = new();

        public bool Test(Vec3<int> inTemplate, Vec3<int> world, Vec3<int> reference,
            RandomSource random) => true;
    }

    /// <summary>The chance lerped over the Manhattan distance from the reference position.</summary>
    public sealed class LinearPos(float minChance, float maxChance, int minDist, int maxDist)
        : IPosRuleTest {

        public bool Test(Vec3<int> inTemplate, Vec3<int> world, Vec3<int> reference,
            RandomSource random) {

            int distance = Math.Abs(world.X - reference.X) + Math.Abs(world.Y - reference.Y)
                + Math.Abs(world.Z - reference.Z);

            return random.NextFloat()
                <= Mth.ClampedLerp(Mth.InverseLerp((float)distance, minDist, maxDist), minChance,
                    maxChance);
        }
    }

    /// <summary>
    /// The same, measured along one axis only.
    /// </summary>
    /// <remarks>
    /// The distance is taken as a float and then <b>truncated to an int</b>, which is vanilla's own
    /// and is why a fractional axis component cannot happen: the step of a direction is one or zero.
    /// </remarks>
    public sealed class AxisAlignedLinearPos(float minChance, float maxChance, int minDist,
        int maxDist, Axis axis) : IPosRuleTest {

        public bool Test(Vec3<int> inTemplate, Vec3<int> world, Vec3<int> reference,
            RandomSource random) {

            float dx = Math.Abs((world.X - reference.X) * (axis == Axis.X ? 1 : 0));
            float dy = Math.Abs((world.Y - reference.Y) * (axis == Axis.Y ? 1 : 0));
            float dz = Math.Abs((world.Z - reference.Z) * (axis == Axis.Z ? 1 : 0));
            int distance = (int)(dx + dy + dz);

            return random.NextFloat()
                <= Mth.ClampedLerp(Mth.InverseLerp((float)distance, minDist, maxDist), minChance,
                    maxChance);
        }
    }
}
