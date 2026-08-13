using ManagedServer;
using ManagedServer.Placement;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;

namespace ManagedServer.Testing.Placement;

/// <summary>
/// That every rule actually reaches a block.
/// <p/>
/// Most of what this used to guard is now the compiler's job: <see cref="BlockClass"/> has one member
/// per class in the generated table, so a misspelling does not build and a class renamed upstream
/// breaks the build on the next generator run. What is left is the hole the type deliberately leaves
/// open, <see cref="BlockClass.Custom"/>, and the case the type cannot see at all: two rules claiming
/// the same class, where one of them is dead and it is never the one you expect.
/// </summary>
[TestFixture]
public class PlacementRuleRegistrationTest {
    [Test]
    public void EveryRuleNamesAClassSomeBlockActuallyHas() {
        List<string> unmatched = [];
        foreach (IBlockPlacementRule rule in VanillaPlacementRules.All) {
            if (!AnyBlockIs(rule.VanillaClass)) {
                unmatched.Add($"{rule.GetType().Name} -> {rule.VanillaClass}");
            }
        }

        Assert.That(unmatched, Is.Empty,
            "these rules name a vanilla class no block inherits, so they can never run");
    }

    [Test]
    public void NoTwoRulesClaimTheSameClass() {
        List<BlockClass> classes = VanillaPlacementRules.All.Select(r => r.VanillaClass).ToList();
        Assert.That(classes, Is.Unique);
    }

    private static readonly ManagedMinecraftServer Server = ManagedMinecraftServer.New();

    private static bool AnyBlockIs(BlockClass className) {
        foreach (IBlock block in Server.Registry.Blocks.StatesByStateId.Values) {
            if (BlockClasses.Is(block.Identifier, className)) {
                return true;
            }
        }

        return false;
    }
}
