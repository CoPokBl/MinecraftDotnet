using System.IO.Compression;
using System.Text;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Testing.Schemas;

/// <summary>
/// Replays the order the real <c>java.util.HashSet</c> iterated a set of block positions in, from the
/// fixture <c>Conformance/hashset.sh</c> produced.
/// </summary>
/// <remarks>
/// <b>Vanilla's iteration order over a hash set decides where a feature's draws land.</b> A tree
/// collects its logs and leaves into <c>Sets.newHashSet()</c> and a vegetation patch collects its
/// surface columns into one; both are then looped over with a fixed number of draws per entry, so the
/// set picks which block each draw lands on while the draw count is identical either way. Nothing but
/// the blocks that come out can see it, which is why it is a fixture rather than a unit test.
/// <p/>
/// The part that a reading of the algorithm gets wrong is the <b>treeified bucket</b>. A bucket of
/// nine turns into a red-black tree whose root is then moved to the front of the chain the iterator
/// walks, and every later insertion into it can rebalance and move a new root there. Below a table 64
/// wide the same threshold widens the table instead, which changes the width every later bucket is
/// taken modulo. Neither is a function of the size and the insertion order alone.
/// </remarks>
[TestFixture]
public class JavaHashSetConformanceTest {
    private static string FixturePath =>
        Path.Combine(TestContext.CurrentContext.TestDirectory, "Schemas", "vanilla-hashset.txt.gz");

    /// <summary><c>Vec3i.hashCode</c>, which is what the order is taken over.</summary>
    private static int Hash(Vec3<int> pos) => (pos.Y + pos.Z * 31) * 31 + pos.X;

    private sealed record Case(string Family, int Size, bool Treeified, Vec3<int>[] Inserted,
        Vec3<int>[] Iterated);

    private static IReadOnlyList<Case> Read() {
        using FileStream file = File.OpenRead(FixturePath);
        using GZipStream gzip = new(file, CompressionMode.Decompress);
        using StreamReader reader = new(gzip, Encoding.UTF8);

        List<Case> cases = [];

        while (reader.ReadLine() is { } header) {
            string[] parts = header.Split(' ');
            Vec3<int>[] inserted = Positions(reader.ReadLine()!);
            Vec3<int>[] iterated = Positions(reader.ReadLine()!);

            cases.Add(new Case(parts[0], int.Parse(parts[1]), bool.Parse(parts[2]), inserted, iterated));
        }

        return cases;
    }

    private static Vec3<int>[] Positions(string line) {
        return line.Split(';', StringSplitOptions.RemoveEmptyEntries)
            .Select(part => part.Split(','))
            .Select(parts => new Vec3<int>(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2])))
            .ToArray();
    }

    [Test]
    public void EveryCaseIteratesInVanillaOrder() {
        IReadOnlyList<Case> cases = Read();

        // A fixture that decoded to nothing would agree with anything, and one whose cases all stayed
        // short chains would agree with the reading of the algorithm that leaves out the tree. Both
        // are checked before the answers are trusted.
        Assert.That(cases, Has.Count.EqualTo(800));
        Assert.That(cases.Select(one => one.Family).Distinct().Order(),
            Is.EqualTo(new[] { "collide", "patch", "tree" }));
        Assert.That(cases.Count(one => one.Treeified), Is.GreaterThan(150),
            "too few cases reach a treeified bucket for this to be measuring one");

        List<string> failures = [];

        foreach (Case one in cases) {
            Assert.That(one.Inserted, Has.Length.EqualTo(one.Size), "fixture size disagrees with itself");
            Assert.That(one.Iterated, Has.Length.EqualTo(one.Size),
                "the set lost or gained a value, so the fixture is not a permutation");

            JavaHashSet<Vec3<int>> set = new(Hash);

            foreach (Vec3<int> position in one.Inserted) {
                set.Add(position);
            }

            Vec3<int>[] actual = set.ToArray();

            if (actual.SequenceEqual(one.Iterated)) {
                continue;
            }

            int at = Enumerable.Range(0, Math.Min(actual.Length, one.Iterated.Length))
                .FirstOrDefault(index => !actual[index].Equals(one.Iterated[index]), -1);

            failures.Add($"{one.Family} case of {one.Size}"
                + (one.Treeified ? " (treeified)" : "")
                + $" first differs at {at}: ours {Describe(actual, at)}, "
                + $"vanilla {Describe(one.Iterated, at)}");
        }

        Assert.That(failures, Is.Empty,
            $"{failures.Count} of {cases.Count} cases differ\n" + string.Join("\n", failures.Take(10)));
    }

    /// <summary>Whether membership still works once a bucket is a tree rather than a chain.</summary>
    [Test]
    public void EveryValueIsStillFound() {
        foreach (Case one in Read()) {
            JavaHashSet<Vec3<int>> set = new(Hash);

            foreach (Vec3<int> position in one.Inserted) {
                Assert.That(set.Add(position), Is.True, "a value the fixture holds once was added twice");
            }

            foreach (Vec3<int> position in one.Inserted) {
                Assert.That(set.Contains(position), Is.True, $"{position} was lost by the set");
                Assert.That(set.Add(position), Is.False, $"{position} was added a second time");
            }

            Assert.That(set.Count, Is.EqualTo(one.Size));
        }
    }

    private static string Describe(Vec3<int>[] positions, int at) {
        return at < 0 || at >= positions.Length ? "<end>" : positions[at].ToString();
    }
}
