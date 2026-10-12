using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Testing.Placement;

/// <summary>
/// Every block state in the game through every hook of whichever rule claims it, asserting only that
/// nothing throws.
/// <p/>
/// A weak assertion on purpose, and it is not a substitute for a conformance harness. What it covers
/// is a rule registered against a class whose blocks do not all carry the state it assumes: a cast to
/// a property interface that holds for the block the rule was written against and not for its
/// siblings. Sea pickles and turtle eggs share a shape and not a property set, and the weathering
/// copper families keep gaining members.
/// <p/>
/// It used to be aimed at property access by name, which threw for a block without the property. That
/// route is gone: every property a rule touches now has a generated interface, so the misspelling it
/// was guarding against does not compile. What is left is the cast, which does not.
/// </summary>
[TestFixture]
public class PlacementRuleSweepTest {
    private static readonly PlacementScene Scene = new();

    /// <summary>
    /// Placement, over the middle of the yard so every neighbour lookup is inside a loaded chunk.
    /// Both cursor halves and all six clicked faces, because the rules branch on them.
    /// </summary>
    [Test]
    public void NoRuleThrowsPlacingAnyState() {
        List<string> failures = [];

        foreach (IBlock state in AllStates()) {
            IBlockPlacementRule? rule = Scene.Rules.For(state, Scene.World);
            if (rule is null) {
                continue;
            }

            foreach (BlockFace face in Directions.All) {
                Try(failures, state, $"place {face}",
                    () => rule.GetStateForPlacement(state, Scene.ContextFor(Scene.Floor(0, 0), face)));
            }
        }

        Assert.That(failures, Is.Empty);
    }

    /// <summary>
    /// The two hooks the cascade drives. A rule whose <c>UpdateShape</c> throws does not merely fail
    /// to update the block, it takes down the whole neighbour pass and with it every write that
    /// started it.
    /// </summary>
    [Test]
    public void NoRuleThrowsRespondingToANeighbour() {
        List<string> failures = [];
        Vec3<int> pos = Scene.Above(0, 0);

        foreach (IBlock state in AllStates()) {
            IBlockPlacementRule? rule = Scene.Rules.For(state, Scene.World);
            if (rule is null) {
                continue;
            }

            Try(failures, state, "survive", () => rule.CanSurvive(state, Scene.World, pos));

            foreach (BlockFace face in Directions.UpdateShapeOrder) {
                Vec3<int> neighbour = pos.GetBlockTowards(face);
                Try(failures, state, $"update {face}", () => rule.UpdateShape(
                    state, Scene.World, pos, face, neighbour, Scene.World.GetBlock(neighbour)));
            }
        }

        Assert.That(failures, Is.Empty);
    }

    private static IEnumerable<IBlock> AllStates() {
        foreach ((uint id, IBlock block) in Scene.World.Server.Registry.Blocks.StatesByStateId) {
            yield return block.WithState(id);
        }
    }

    private static void Try(List<string> failures, IBlock state, string what, Action action) {
        try {
            action();
        }
        catch (Exception e) {
            failures.Add($"{state.Identifier} [{what}]: {e.GetType().Name}: {e.Message}");
        }
    }
}
