import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;
import java.util.StringJoiner;
import java.util.zip.GZIPOutputStream;

/**
 * Writes down the order the real {@code java.util.HashSet} iterates a set of block positions in, into
 * the fixture {@code JavaHashSetConformanceTest} replays.
 *
 * <p>Usage: {@code java HashSetHarness <fixture>}. See Conformance/hashset.sh.
 *
 * <p><b>Vanilla's iteration order over a hash set decides where a feature's draws land.</b> A tree
 * collects its logs and leaves into {@code Sets.newHashSet()} and a vegetation patch collects its
 * surface columns into one, and both are then looped over with a fixed number of draws per entry. The
 * count of draws is the same whatever the order, so getting the order wrong is invisible in every
 * measurement except what the blocks turn out to be.
 *
 * <p>This is the only harness here that does not need the server jar. The order is
 * {@code java.util.HashMap}'s and nothing about it is Minecraft's, so the JDK is the whole of the
 * authority. What is Minecraft's is the hash it is taken over, {@code Vec3i.hashCode}, and the fact
 * that the sets are filled one {@code add} at a time: {@code new HashSet<>(collection)} presizes its
 * table and therefore never reaches the treeified buckets that make the history matter.
 *
 * <p>Fixture format, gzipped UTF-8 text, three lines per case: a header of
 * {@code <family> <size> <treeified>}, the values in insertion order, then the values in the order the
 * set iterated them. Values are {@code x,y,z}. {@code treeified} is whether the JDK's answer differs
 * from what the same table without treeified buckets would give, which is what says the case is
 * measuring the part that is easy to get wrong.
 */
public class HashSetHarness {

    /** {@code Vec3i.hashCode}, which is what decides the order. */
    private record Pos(int x, int y, int z) {
        @Override
        public int hashCode() {
            return (y + z * 31) * 31 + x;
        }

        @Override
        public String toString() {
            return x + "," + y + "," + z;
        }
    }

    // A tiny LCG rather than java.util.Random, so a case is a function of its number alone and the
    // fixture regenerates identically on any JDK.
    private static long state;

    private static int next(int bound) {
        state = state * 6364136223846793005L + 1442695040888963407L;
        int value = (int) ((state >>> 33) % bound);
        return value < 0 ? value + bound : value;
    }

    public static void main(String[] args) throws Exception {
        if (args.length < 1) {
            System.err.println("usage: HashSetHarness <fixture>");
            System.exit(2);
        }

        StringBuilder out = new StringBuilder();
        int treeified = 0;
        int cases = 0;

        for (int seed = 0; seed < 300; seed++) {
            treeified += write(out, "patch", patch(seed));
            cases++;
        }

        for (int seed = 0; seed < 200; seed++) {
            treeified += write(out, "tree", tree(seed));
            cases++;
        }

        for (int seed = 0; seed < 300; seed++) {
            treeified += write(out, "collide", collide(seed));
            cases++;
        }

        try (OutputStream raw = Files.newOutputStream(Path.of(args[0]));
             GZIPOutputStream gzip = new GZIPOutputStream(raw);
             Writer writer = new OutputStreamWriter(gzip, StandardCharsets.UTF_8)) {

            writer.write(out.toString());
        }

        System.out.println("Wrote " + cases + " cases to " + args[0]
            + ", " + treeified + " of them reaching a treeified bucket");
    }

    /**
     * A vegetation patch's surface: a grid of columns whose y follows a cave floor, with the edges
     * rolled off. This is the shape that reaches a bucket of nine within a hundred chunks.
     *
     * <p><b>The floor has to be smooth rather than random, or the case measures nothing.</b> The hash
     * is {@code x + 31y + 961z}, so at a table 64 wide the bucket is {@code x + 31y + z} folded down:
     * a run of columns at one height along a diagonal all land in the same bucket, and that is what
     * makes a patch reach nine. Drawing each column's y independently scatters them instead, and the
     * fixture then agrees with any implementation at all.
     */
    private static List<Pos> patch(int seed) {
        state = seed * 2654435761L + 12345;

        int baseX = next(60000) - 30000;
        int baseY = next(300) - 200;
        int baseZ = next(60000) - 30000;
        int radius = 4 + next(5);

        // A flat floor as often as a sloped one, which is what a lush cave mostly is and what puts a
        // whole diagonal of the patch in one bucket.
        boolean flat = next(2) == 0;
        int slopeX = flat ? 0 : next(5) - 2;
        int slopeZ = flat ? 0 : next(5) - 2;
        int curve = flat ? 0 : 11;

        List<Pos> positions = new ArrayList<>();

        for (int dx = -radius; dx <= radius; dx++) {
            for (int dz = -radius; dz <= radius; dz++) {
                if (next(10) < 2) {
                    continue;
                }

                int floor = ((dx * slopeX) / 3) + ((dz * slopeZ) / 3) + (curve == 0 ? 0 : (dx * dz) / curve);
                positions.add(new Pos(baseX + dx, baseY + floor, baseZ + dz));
            }
        }

        return positions;
    }

    /** A tree's logs and leaves: a tall narrow trunk with a blob on top of it. */
    private static List<Pos> tree(int seed) {
        state = seed * 2654435761L + 777;

        int baseX = next(60000) - 30000;
        int baseY = next(200) - 60;
        int baseZ = next(60000) - 30000;
        int height = 5 + next(26);
        int radius = 2 + next(5);

        List<Pos> positions = new ArrayList<>();

        for (int dy = 0; dy < height; dy++) {
            positions.add(new Pos(baseX, baseY + dy, baseZ));
        }

        for (int dy = height - 3; dy < height + 2; dy++) {
            for (int dx = -radius; dx <= radius; dx++) {
                for (int dz = -radius; dz <= radius; dz++) {
                    if (dx * dx + dz * dz > radius * radius || next(6) == 0) {
                        continue;
                    }

                    positions.add(new Pos(baseX + dx, baseY + dy, baseZ + dz));
                }
            }
        }

        return positions;
    }

    /**
     * Many values in one bucket, which is what makes a case reach the tree rather than merely a long
     * chain. A hash is reachable as {@code Pos(h, 0, 0)}, so the bucket is picked directly.
     */
    private static List<Pos> collide(int seed) {
        state = seed * 2654435761L + 7;

        int bucket = next(64);
        int colliding = 9 + next(40);
        int scattered = 20 + next(300);

        List<Integer> hashes = new ArrayList<>();

        for (int i = 0; i < colliding; i++) {
            hashes.add(bucket + 64 * (1 + next(500)));
        }

        for (int i = 0; i < scattered; i++) {
            int hash = next(60000);
            hashes.add((hash & 63) == bucket ? hash + 1 : hash);
        }

        // Interleaved, so the bucket crosses the threshold part way through rather than at the end.
        for (int i = hashes.size(); i > 1; i--) {
            Collections.swap(hashes, i - 1, next(i));
        }

        List<Pos> positions = new ArrayList<>();

        for (int hash : hashes) {
            positions.add(new Pos(hash, 0, 0));
        }

        return positions;
    }

    /** Reports whether the case reached a treeified bucket. */
    private static int write(StringBuilder out, String family, List<Pos> positions) {
        // Deduplicated first, so the insertion order written down is the order the set actually saw.
        LinkedHashSet<Pos> inserted = new LinkedHashSet<>(positions);

        Set<Pos> set = new HashSet<>();
        for (Pos pos : inserted) {
            set.add(pos);
        }

        List<Pos> iterated = new ArrayList<>(set);
        boolean treeified = !iterated.equals(withoutTrees(inserted));

        out.append(family).append(' ').append(inserted.size()).append(' ').append(treeified).append('\n');
        out.append(join(inserted)).append('\n');
        out.append(join(iterated)).append('\n');

        return treeified ? 1 : 0;
    }

    /**
     * What a table whose width follows from the size alone would iterate, with every bucket a chain.
     *
     * <p>Only used to label a case, so it is the plain algorithm rather than a second port. A case
     * that differs from it reached either a treeified bucket or the widening a long bucket forces on
     * a narrow table, and both are history the size cannot predict.
     */
    private static List<Pos> withoutTrees(LinkedHashSet<Pos> inserted) {
        int capacity = 16;
        while (inserted.size() > (int) (capacity * 0.75)) {
            capacity <<= 1;
        }

        List<List<Pos>> buckets = new ArrayList<>();
        for (int i = 0; i < capacity; i++) {
            buckets.add(new ArrayList<>());
        }

        for (Pos pos : inserted) {
            int hash = pos.hashCode();
            buckets.get((hash ^ (hash >>> 16)) & (capacity - 1)).add(pos);
        }

        List<Pos> order = new ArrayList<>();
        for (List<Pos> bucket : buckets) {
            order.addAll(bucket);
        }

        return order;
    }

    private static String join(Iterable<Pos> positions) {
        StringJoiner joiner = new StringJoiner(";");
        for (Pos pos : positions) {
            joiner.add(pos.toString());
        }

        return joiner.toString();
    }
}
