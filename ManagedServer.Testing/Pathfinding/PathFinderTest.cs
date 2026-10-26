using ManagedServer.Entities.Types;
using ManagedServer.Pathfinding;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Providers;
using Minecraft.Schemas.Vec;
using Path = ManagedServer.Pathfinding.Path;

namespace ManagedServer.Testing.Pathfinding;

/// <summary>
/// A* over hand built terrain: the shapes of route the pathfinder has to get right for a mob to look
/// like it knows where it is going.
/// <p/>
/// These are about the <b>search</b>, not the classification. What a block means is pinned against
/// the game itself in <see cref="PathTypeConformanceTest"/>; what these check is that given a correct
/// graph the search walks round a wall, up a step, down a drop, and gives its best effort towards
/// somewhere it cannot get to rather than nothing at all.
/// </summary>
[TestFixture]
public class PathFinderTest {
    private ManagedMinecraftServer _server = null!;
    private World _world = null!;

    /// <summary>
    /// Stone floor everywhere. Note the provider works in <b>protocol</b> y, offset by the
    /// dimension's min y of -64, so a floor at its <c>y == 63</c> puts the surface a mob stands on at
    /// game y <b>0</b>. Everything below is written in game coordinates.
    /// </summary>
    private sealed class FloorProvider : PerBlockTerrainProvider {
        public override uint GetBlock(int x, int y, int z) {
            return y == 63 ? Block.Stone.StateId : Block.Air.StateId;
        }
    }

    [SetUp]
    public void Setup() {
        _server = new ManagedMinecraftServer { LogAction = _ => { } };
        _world = _server.CreateWorld(new FloorProvider(), "minecraft:overworld", new FullBrightLightingProvider());

        for (int x = -1; x <= 2; x++) {
            for (int z = -1; z <= 2; z++) {
                _world.LoadChunk(new Vec2<int>(x, z)).Wait();
            }
        }
    }

    [TearDown]
    public void TearDown() {
        _server.Stop();
    }

    private Mob Spawn(double x = 0.5, double z = 0.5) {
        Mob mob = new(EntityType.Zombie) {
            Position = new Vec3<double>(x, 0.0, z),
            OnGround = true
        };

        mob.SetWorld(_world);
        return mob;
    }

    private void Solid(int x, int y, int z) {
        _world.SetBlock(new Vec3<int>(x, y, z), Block.Stone);
    }

    private void Air(int x, int y, int z) {
        _world.SetBlock(new Vec3<int>(x, y, z), Block.Air);
    }

    /// <summary>
    /// Runs a search the way the navigation does, with a generous node budget so a failure is about
    /// the route rather than the cap.
    /// </summary>
    private Path? FindPath(Mob mob, Vec3<int> target, int reachRange = 1, int maxVisitedNodes = 4000,
        float maxPathLength = 64.0f) {
        PathFinder finder = new(new WalkNodeEvaluator(), maxVisitedNodes);
        return finder.FindPath(_world, mob, [target], maxPathLength, reachRange, 1.0f);
    }

    [Test]
    public void TestAStraightWalkOverFlatGroundIsFound() {
        Mob mob = Spawn();
        Path? path = FindPath(mob, new Vec3<int>(6, 0, 0));

        Assert.That(path, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(path!.CanReach, Is.True, "flat ground should be reachable");
            Assert.That(path.NodeCount, Is.GreaterThan(1), "a route to six blocks away needs nodes");

            // Every node is on the floor, so nothing has decided to climb or fall on flat ground.
            for (int i = 0; i < path.NodeCount; i++) {
                Assert.That(path.GetNode(i).Y, Is.EqualTo(0), $"node {i} left the floor");
            }
        });
    }

    [Test]
    public void TestAWallIsWalkedAround() {
        Mob mob = Spawn();

        // A wall two blocks tall across the direct line, open past z = 3. Two tall so it cannot be
        // jumped, which is what forces the detour rather than a climb.
        for (int z = -4; z <= 3; z++) {
            Solid(3, 0, z);
            Solid(3, 1, z);
        }

        Path? path = FindPath(mob, new Vec3<int>(6, 0, 0));

        Assert.That(path, Is.Not.Null);
        Assert.That(path!.CanReach, Is.True, "the far side is reachable round the end of the wall");

        bool wentRound = false;
        for (int i = 0; i < path.NodeCount; i++) {
            Node node = path.GetNode(i);
            Assert.That(node.X == 3 && node.Z <= 3 && node.Z >= -4, Is.False,
                $"node {i} at {node} is inside the wall");

            if (node.Z > 3) {
                wentRound = true;
            }
        }

        Assert.That(wentRound, Is.True, "the route should go round the open end rather than through");
    }

    [Test]
    public void TestAOneBlockStepIsClimbed() {
        Mob mob = Spawn();

        // A raised plateau rather than a single raised block: a one block wide ledge is climbed and
        // then immediately stepped off, so the route would legitimately end back down at y 0.
        for (int x = 3; x <= 7; x++) {
            for (int z = -2; z <= 2; z++) {
                Solid(x, 0, z);
            }
        }

        Path? path = FindPath(mob, new Vec3<int>(6, 1, 0));

        Assert.That(path, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(path!.CanReach, Is.True, "a one block step is a jump, not a wall");
            Assert.That(path.EndNode!.Y, Is.EqualTo(1), "the route should end on top of the step");
        });
    }

    [Test]
    public void TestADropIsWalkedDown() {
        Mob mob = Spawn();

        // A trench two deep from x 3 to 6: floor removed, new floor two blocks down.
        for (int x = 3; x <= 6; x++) {
            for (int z = -2; z <= 2; z++) {
                Air(x, -1, z);
                Solid(x, -3, z);
            }
        }

        Path? path = FindPath(mob, new Vec3<int>(5, -2, 0));

        Assert.That(path, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(path!.CanReach, Is.True, "a two block drop is under the fall limit");
            Assert.That(path.EndNode!.Y, Is.EqualTo(-2), "the route should end on the trench floor");
        });
    }

    [Test]
    public void TestADropTooFarToSurviveIsRefused() {
        Mob mob = Spawn();

        // Ten deep, well past a zombie's three block comfortable fall.
        for (int x = 3; x <= 6; x++) {
            for (int z = -2; z <= 2; z++) {
                Air(x, -1, z);
                Solid(x, -11, z);
            }
        }

        Path? path = FindPath(mob, new Vec3<int>(5, -10, 0));

        // A path is still returned, since the search always hands back its best effort. What says
        // the mob will not jump in is that it never gets there.
        Assert.That(path?.CanReach, Is.Not.EqualTo(true), "a ten block drop should not read as reachable");

        if (path != null) {
            Assert.That(path.EndNode!.Y, Is.EqualTo(0), "the route should stop on the lip of the drop");
        }
    }

    [Test]
    public void TestAnUnreachableTargetStillReturnsTheClosestApproach() {
        Mob mob = Spawn();

        // A closed ring around the target, three blocks tall so it cannot be jumped and cannot be
        // walked round. Leaving either end open makes this test pass for the wrong reason.
        for (int y = 0; y <= 2; y++) {
            for (int z = -2; z <= 2; z++) {
                Solid(4, y, z);
                Solid(8, y, z);
            }

            for (int x = 4; x <= 8; x++) {
                Solid(x, y, -2);
                Solid(x, y, 2);
            }
        }

        Path? path = FindPath(mob, new Vec3<int>(6, 0, 0));

        Assert.That(path, Is.Not.Null, "an unreachable target should still produce a best effort");
        Assert.Multiple(() => {
            Assert.That(path!.CanReach, Is.False, "nothing got within reach of the target");
            Assert.That(path.EndNode!.X, Is.LessThan(4), "the route should stop outside the ring");
            Assert.That(path.DistanceToTarget, Is.GreaterThan(0.0f), "it did not arrive");
        });
    }

    [Test]
    public void TestTheVisitedNodeCapIsHonoured() {
        Mob mob = Spawn();

        // Three nodes of budget cannot explore far enough to cross twenty blocks, so the search has
        // to stop early rather than run to the target.
        Path? capped = FindPath(mob, new Vec3<int>(20, 0, 0), maxVisitedNodes: 3);
        Path? uncapped = FindPath(mob, new Vec3<int>(20, 0, 0));

        Assert.That(uncapped, Is.Not.Null);
        Assert.That(uncapped!.CanReach, Is.True, "twenty blocks of flat ground is reachable with a budget");

        Assert.That(capped, Is.Not.Null, "the cap should still hand back what it found");
        Assert.Multiple(() => {
            Assert.That(capped!.CanReach, Is.False, "three nodes cannot reach twenty blocks away");
            Assert.That(capped.NodeCount, Is.LessThan(uncapped.NodeCount), "the capped route should be shorter");
        });
    }

    [Test]
    public void TestTheMaxPathLengthBoundsHowFarTheSearchSpreads() {
        Mob mob = Spawn();

        Path? shortLeash = FindPath(mob, new Vec3<int>(20, 0, 0), maxPathLength: 4.0f);

        Assert.That(shortLeash, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(shortLeash!.CanReach, Is.False, "twenty blocks is outside a four block leash");

            // Measured from the start, which is what maxPathLength bounds; a route that wandered
            // further than the leash would mean the wrong distance is being checked.
            Node end = shortLeash.EndNode!;
            double distance = Math.Sqrt(end.X * end.X + end.Y * end.Y + end.Z * end.Z);
            Assert.That(distance, Is.LessThanOrEqualTo(6.0), "the search spread past its leash");
        });
    }

    [Test]
    public void TestAMobStartingInsideAWallStillFindsAStart() {
        Mob mob = Spawn();

        // Buried where it stands. Vanilla falls back to the corners of the mob's box, so a search is
        // still possible rather than returning nothing.
        Solid(0, 0, 0);

        Path? path = FindPath(mob, new Vec3<int>(6, 0, 0));

        Assert.That(path, Is.Not.Null, "a buried mob should still get a start node");
    }

    [Test]
    public void TestALavaFloorIsRoutedAround() {
        Mob mob = Spawn();

        // Lava across the direct line. Nothing about it is solid, so the only thing that keeps a mob
        // out of it is the malus, which is what this checks.
        for (int z = -3; z <= 3; z++) {
            _world.SetBlock(new Vec3<int>(3, 0, z), Block.Lava);
        }

        Path? path = FindPath(mob, new Vec3<int>(6, 0, 0));

        Assert.That(path, Is.Not.Null);

        for (int i = 0; i < path!.NodeCount; i++) {
            Node node = path.GetNode(i);
            Assert.That(node.X == 3 && node.Z is >= -3 and <= 3, Is.False,
                $"node {i} at {node} walks through lava");
        }
    }
}
