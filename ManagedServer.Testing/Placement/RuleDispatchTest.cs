using System.Reflection;
using Minecraft.Placement;

namespace ManagedServer.Testing.Placement;

/// <summary>
/// That every hook a rule writes is a hook that actually gets called.
/// <para>
/// <see cref="IBlockPlacementRule"/> defaults all five of its members so a rule transcribes only what
/// its vanilla class overrides. That is what makes the rules readable, and it comes with a trap: a
/// class that implements the interface <b>fixes the interface's mapping at itself</b>, so a subclass
/// writing <c>public bool CanSurvive(...)</c> without <c>override</c> adds a method with the right
/// name and the right signature that nothing ever calls. The interface default answers instead.
/// </para>
/// <para>
/// Nothing complains. The compiler is happy, the method is public and looks implemented, and every
/// hand written test that calls the rule directly rather than through the interface passes. For a
/// survival rule the default is <c>true</c>, so the failure is silently permissive: the block can be
/// placed anywhere and never dies. Four rules were in that state when the conformance fixture first
/// ran, which is how this test came to exist.
/// </para>
/// </summary>
[TestFixture]
public class RuleDispatchTest {
    private static readonly string[] Hooks = [
        nameof(IBlockPlacementRule.GetStateForPlacement),
        nameof(IBlockPlacementRule.CanBeReplaced),
        nameof(IBlockPlacementRule.CanSurvive),
        nameof(IBlockPlacementRule.UpdateShape),
        nameof(IBlockPlacementRule.OnPlaced)
    ];

    [Test]
    public void NoRuleDeclaresAHookThatWillNeverBeCalled() {
        List<string> dead = [];

        foreach (IBlockPlacementRule rule in VanillaPlacementRules.All) {
            Type type = rule.GetType();
            InterfaceMapping map = type.GetInterfaceMap(typeof(IBlockPlacementRule));

            foreach (string hook in Hooks) {
                // What the interface will actually run for this rule.
                int index = Array.FindIndex(map.InterfaceMethods, method => method.Name == hook);
                MethodInfo dispatched = map.TargetMethods[index];

                // What the rule's own class chain declares under that name, nearest first. A plain
                // declaration below the one the interface points at is the dead one.
                for (Type? walk = type; walk is not null && walk != dispatched.DeclaringType;
                     walk = walk.BaseType) {
                    MethodInfo? declared = walk.GetMethod(hook,
                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                    if (declared is not null) {
                        dead.Add($"{type.Name}.{hook} is declared in {walk.Name} but the interface "
                                 + $"dispatches to {dispatched.DeclaringType?.Name}. Mark it override, "
                                 + "and make the base declaration virtual.");
                    }
                }
            }
        }

        Assert.That(dead, Is.Empty, string.Join(Environment.NewLine, dead));
    }
}
