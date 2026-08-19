using System.Reflection;
using ManagedServer.Terrain;
using ManagedServer.Terrain.Density;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// Walks the interface map of every density function type and asserts that the bulk and rewrite
/// members reach the type's own code where it has any.
/// </summary>
/// <remarks>
/// <see cref="ISimpleDensityFunction"/> supplies default implementations of
/// <see cref="IDensityFunction.FillArray"/> and <see cref="IDensityFunction.MapChildren"/>, and a
/// default is what answers when a class's own method fails to line up with the interface. Both
/// failures are silent and both look like the port working: a wrong <c>FillArray</c> produces terrain
/// with a stripe of the wrong density and a wrong <c>MapChildren</c> produces a subtree that never
/// gets its noise, which reads as flat zero.
/// </remarks>
[TestFixture]
public class DensityFunctionDispatchTest {
    private static IEnumerable<Type> DensityFunctionTypes() {
        return typeof(VanillaTerrainGenerator).Assembly.GetTypes()
            .Where(t => t is { IsAbstract: false, IsInterface: false })
            .Where(t => typeof(IDensityFunction).IsAssignableFrom(t));
    }

    [Test]
    public void TestEveryTypeIsReachable() {
        // A guard on the sweep itself: a rename that makes the query find nothing would otherwise
        // turn this whole fixture into a pass.
        Assert.That(DensityFunctionTypes().Count(), Is.GreaterThan(15));
    }

    [Test]
    public void TestBulkFillDispatchesToTheTypeThatDeclaresIt() {
        List<string> failures = [];

        foreach (Type type in DensityFunctionTypes()) {
            MethodInfo? declared = type.GetMethod(nameof(IDensityFunction.FillArray),
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly,
                null, [typeof(double[]), typeof(IContextProvider)], null);

            if (declared == null) {
                // Nothing of its own, so the interface default is what it means to use.
                continue;
            }

            InterfaceMapping map = type.GetInterfaceMap(typeof(IDensityFunction));
            int index = Array.FindIndex(map.InterfaceMethods,
                m => m.Name == nameof(IDensityFunction.FillArray));

            if (map.TargetMethods[index].DeclaringType != type) {
                failures.Add($"{type.Name} declares FillArray but the interface maps to " +
                    $"{map.TargetMethods[index].DeclaringType?.Name}, so its own is never called.");
            }
        }

        Assert.That(failures, Is.Empty, string.Join("\n", failures));
    }

    [Test]
    public void TestMapChildrenDispatchesToTheTypeThatDeclaresIt() {
        List<string> failures = [];

        foreach (Type type in DensityFunctionTypes()) {
            MethodInfo? declared = type.GetMethod(nameof(IDensityFunction.MapChildren),
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly,
                null, [typeof(IDensityFunctionVisitor)], null);

            if (declared == null) {
                continue;
            }

            InterfaceMapping map = type.GetInterfaceMap(typeof(IDensityFunction));
            int index = Array.FindIndex(map.InterfaceMethods,
                m => m.Name == nameof(IDensityFunction.MapChildren));

            if (map.TargetMethods[index].DeclaringType != type) {
                failures.Add($"{type.Name} declares MapChildren but the interface maps to " +
                    $"{map.TargetMethods[index].DeclaringType?.Name}, so its children are never bound.");
            }
        }

        Assert.That(failures, Is.Empty, string.Join("\n", failures));
    }

    [Test]
    public void TestOnlyChildlessTypesTakeTheSimpleDefault() {
        // A node with children that took ISimpleDensityFunction's MapChildren would keep them unbound,
        // which is the failure the type system cannot see: it compiles and reads as flat zero.
        List<string> failures = [];

        foreach (Type type in DensityFunctionTypes()) {
            if (!typeof(ISimpleDensityFunction).IsAssignableFrom(type)) {
                continue;
            }

            bool holdsChildren = type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Any(f => typeof(IDensityFunction).IsAssignableFrom(f.FieldType)
                    || f.FieldType == typeof(NoiseHolder));

            if (holdsChildren) {
                failures.Add($"{type.Name} implements ISimpleDensityFunction but holds a child, " +
                    "so a visitor never reaches it.");
            }
        }

        Assert.That(failures, Is.Empty, string.Join("\n", failures));
    }
}
