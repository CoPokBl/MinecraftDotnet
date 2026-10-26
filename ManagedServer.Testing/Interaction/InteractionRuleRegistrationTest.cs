using System.Reflection;
using ManagedServer.Interaction;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;

namespace ManagedServer.Testing.Interaction;

/// <summary>
/// That every interaction rule reaches a block, and that every hook it writes is one that gets
/// called. The two halves of <c>PlacementRuleRegistrationTest</c> and <c>RuleDispatchTest</c>, which
/// apply here verbatim because <see cref="IBlockInteractionRule"/> is the same shape.
/// </summary>
[TestFixture]
public class InteractionRuleRegistrationTest {
    private static readonly ManagedMinecraftServer Server = ManagedMinecraftServer.New();

    [Test]
    public void EveryRuleNamesAClassSomeBlockActuallyHas() {
        List<string> unmatched = [];
        foreach (IBlockInteractionRule rule in VanillaBlockInteractions.All) {
            if (!AnyBlockIs(rule.VanillaClass)) {
                unmatched.Add($"{rule.GetType().Name} -> {rule.VanillaClass}");
            }
        }

        Assert.That(unmatched, Is.Empty,
            "these rules name a vanilla class no block inherits, so they can never run");
    }

    [Test]
    public void NoTwoRulesClaimTheSameClass() {
        List<BlockClass> classes = VanillaBlockInteractions.All.Select(r => r.VanillaClass).ToList();
        Assert.That(classes, Is.Unique);
    }

    /// <summary>
    /// The silently permissive failure <c>RuleDispatchTest</c> documents: a rule under an abstract
    /// base that writes a hook without <c>override</c> adds a method nothing calls, and the interface
    /// default answers instead. Here the default is <c>Pass</c> or <c>TryWithEmptyHand</c>, so the
    /// block would quietly do nothing rather than throwing.
    /// </summary>
    [Test]
    public void NoRuleDeclaresAHookThatWillNeverBeCalled() {
        string[] hooks = [
            nameof(IBlockInteractionRule.UseItemOn),
            nameof(IBlockInteractionRule.UseWithoutItem)
        ];

        List<string> dead = [];

        foreach (IBlockInteractionRule rule in VanillaBlockInteractions.All) {
            Type type = rule.GetType();
            InterfaceMapping map = type.GetInterfaceMap(typeof(IBlockInteractionRule));

            foreach (string hook in hooks) {
                int index = Array.FindIndex(map.InterfaceMethods, method => method.Name == hook);
                MethodInfo dispatched = map.TargetMethods[index];

                for (Type? walk = type; walk is not null && walk != dispatched.DeclaringType;
                     walk = walk.BaseType) {
                    MethodInfo? declared = walk.GetMethod(hook,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    if (declared is not null) {
                        dead.Add($"{walk.Name}.{hook}");
                    }
                }
            }
        }

        Assert.That(dead, Is.Empty,
            "these hooks are shadowed by the interface default and are never called; they need override");
    }

    /// <summary>
    /// Every state of every block through whichever rule claims it, asserting only that nothing
    /// throws. Deliberately weak, and it covers the one failure the type system cannot: a rule
    /// casting to a property interface the block does not implement.
    /// </summary>
    [Test]
    public void NoRuleThrowsForAnyStateItClaims() {
        InteractionScene scene = new(new Features.Basic.VanillaBlockInteractionsFeature());
        List<string> failures = [];

        // StatesByStateId returns each block's default state, so every read has to WithState first
        // or the sweep only ever sees one state per block.
        foreach ((uint id, IBlock block) in Server.Registry.Blocks.StatesByStateId) {
            IBlockInteractionRule? rule = scene.Server.BlockInteractionRules.For(block, scene.World);
            if (rule is null) {
                continue;
            }

            IBlock state = block.WithState(id);
            BlockHit hit = new(scene.Above, Minecraft.Schemas.BlockFace.PosY,
                new Minecraft.Schemas.Vec.Vec3<double>(0.5, 1, 0.5), false);

            try {
                rule.UseItemOn(state, scene.World, scene.Above, scene.Player,
                    Minecraft.Schemas.Hand.MainHand, Minecraft.Schemas.Items.ItemStack.Air, hit);
                rule.UseWithoutItem(state, scene.World, scene.Above, scene.Player, hit);
            }
            catch (Exception ex) {
                failures.Add($"{rule.GetType().Name} on {state.Identifier}: {ex.Message}");
            }
        }

        Assert.That(failures, Is.Empty);
    }

    private static bool AnyBlockIs(BlockClass className) {
        foreach (IBlock block in Server.Registry.Blocks.StatesByStateId.Values) {
            if (BlockClasses.Is(block.Identifier, className)) {
                return true;
            }
        }

        return false;
    }
}
