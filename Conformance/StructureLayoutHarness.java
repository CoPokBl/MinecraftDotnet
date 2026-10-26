import java.io.BufferedWriter;
import java.io.DataInputStream;
import java.io.OutputStreamWriter;
import java.io.FileOutputStream;
import java.io.BufferedOutputStream;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Optional;
import java.util.zip.GZIPOutputStream;
import net.minecraft.SharedConstants;
import net.minecraft.nbt.CompoundTag;
import net.minecraft.nbt.ListTag;
import net.minecraft.nbt.NbtIo;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.level.ChunkPos;
import net.minecraft.world.level.Level;
import net.minecraft.world.level.chunk.storage.RegionFile;
import net.minecraft.world.level.chunk.storage.RegionStorageInfo;

/**
 * Writes down every structure start the real server laid out over an area, out of the region files it
 * saved, into the fixture StructureLayoutConformanceTest replays.
 *
 * <p>Usage: {@code java StructureLayoutHarness <regionDir> <fixture> <seed> <chunkX>:<chunkZ>:<size>...}.
 * See Conformance/structurelayout.sh, which generates the world first.
 *
 * <p><b>An area is read far wider than it was forceloaded, and that is the point of it.</b> A start is
 * written the moment a chunk reaches {@code structure_starts}, the second status, and a full chunk
 * needs every chunk within eight of it at that status for its own references. So forceloading a two by
 * two writes starts for the seventeen by seventeen around it, and a chunk of start data costs about a
 * fortieth of a chunk of terrain.
 *
 * <p><b>This is the only measurement of the structure pass that names a structure.</b> The decoration
 * parity harness skips a chunk a structure wrote into, because it has no structure manager to build
 * starts with, and world parity reports one number per scene with the feature pass mixed into it. What
 * a start is, on the other hand, the server writes down for us: a chunk's {@code structures.starts}
 * carries every piece of every structure rooted in it, as a type, a bounding box, an orientation and a
 * generation depth. That is the whole of the layout, which is the half of the pass that decides where a
 * structure is and what it is made of; what the pieces then write is the templates and
 * {@code blocktransform.sh}.
 *
 * <p>A start is <b>a pure function of the world seed and its source chunk</b> on both sides, so nothing
 * here depends on the order the world was generated in. That is what makes this a pass rather than a
 * baseline, unlike world parity.
 *
 * <p>The fixture is plain text, gzipped: one line per piece, sorted, so a diff of two runs names the
 * structure that moved.
 */
public class StructureLayoutHarness {

    public static void main(String[] args) throws Exception {
        if (args.length < 4) {
            System.err.println(
                "usage: StructureLayoutHarness <regionDir> <fixture> <seed> <chunkX>:<chunkZ>:<size>...");
            System.exit(2);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        Path regions = Path.of(args[0]);
        Path fixture = Path.of(args[1]);
        long seed = Long.parseLong(args[2]);

        List<int[]> areas = new ArrayList<>();
        for (int i = 3; i < args.length; i++) {
            String[] parts = args[i].split(":");

            if (parts.length != 3) {
                System.err.println("Area \"" + args[i] + "\" is not chunkX:chunkZ:size");
                System.exit(2);
            }

            areas.add(new int[] {
                Integer.parseInt(parts[0]), Integer.parseInt(parts[1]), Integer.parseInt(parts[2])
            });
        }

        List<String> lines = new ArrayList<>();
        List<String> covered = new ArrayList<>();

        // The areas overlap where two clusters are close, and a chunk read twice would be a piece
        // counted twice on both sides.
        java.util.Set<Long> seen = new java.util.HashSet<>();
        int chunksRead = 0;
        int chunksMissing = 0;
        int starts = 0;

        for (int[] area : areas) {
            for (int x = area[0]; x < area[0] + area[2]; x++) {
                for (int z = area[1]; z < area[1] + area[2]; z++) {
                    if (!seen.add(((long) x << 32) | (z & 0xffffffffL))) {
                        continue;
                    }

                    CompoundTag chunk = read(regions, x, z);

                    if (chunk == null) {
                        chunksMissing++;
                        continue;
                    }

                    chunksRead++;

                    // A chunk that never reached full was never decorated, so the pieces that settle
                    // their own height inside postProcess are recorded where the layout left them.
                    // The test needs to know which those are, or it reads an unplaced shipwreck as a
                    // shipwreck in the wrong place.
                    String status = chunk.getString("Status").orElse("minecraft:empty");

                    covered.add(x + " " + z + " " + status);
                    starts += collect(chunk, x, z, lines);
                }
            }
        }

        if (chunksRead == 0) {
            throw new IllegalStateException("No chunk of the requested areas is in " + regions
                + ". The world was not generated over them.");
        }

        lines.sort(Comparator.naturalOrder());
        covered.sort(Comparator.naturalOrder());

        Files.createDirectories(fixture.getParent());

        try (BufferedWriter out = new BufferedWriter(new OutputStreamWriter(new GZIPOutputStream(
            new BufferedOutputStream(new FileOutputStream(fixture.toFile()))), StandardCharsets.UTF_8))) {

            out.write("seed " + seed);
            out.newLine();

            // The chunks that were actually recorded, since a chunk the world never reached has no
            // starts and is not the same thing as a chunk with none.
            out.write("chunks " + covered.size());
            out.newLine();

            for (String chunk : covered) {
                out.write("chunk " + chunk);
                out.newLine();
            }

            for (String line : lines) {
                out.write("piece " + line);
                out.newLine();
            }
        }

        System.out.println("=== structure layout fixture vs "
            + SharedConstants.getCurrentVersion().name() + " ===");
        System.out.println(chunksRead + " chunks read, " + chunksMissing + " never generated, "
            + starts + " starts and " + lines.size() + " pieces written to " + fixture);
    }

    /**
     * One chunk's own starts. A start recorded under a chunk that is not the one it names is a
     * reference rather than a start, and vanilla does not write those here.
     */
    private static int collect(CompoundTag chunk, int chunkX, int chunkZ, List<String> lines) {
        Optional<CompoundTag> structures = chunk.getCompound("structures");

        if (structures.isEmpty()) {
            return 0;
        }

        Optional<CompoundTag> all = structures.get().getCompound("starts");

        if (all.isEmpty()) {
            return 0;
        }

        int found = 0;

        for (String key : all.get().keySet()) {
            CompoundTag start = all.get().getCompound(key).orElseThrow();
            String id = start.getString("id").orElse("INVALID");

            // An invalid start is a structure that rolled its chunk and then declined, which both
            // sides express by having no start at all.
            if (id.equals("INVALID")) {
                continue;
            }

            found++;
            ListTag children = start.getList("Children").orElseGet(ListTag::new);

            for (int i = 0; i < children.size(); i++) {
                CompoundTag piece = children.getCompound(i).orElseThrow();
                int[] box = piece.getIntArray("BB").orElseThrow();

                lines.add(String.join(" ",
                    Integer.toString(chunkX), Integer.toString(chunkZ), id, Integer.toString(i),
                    piece.getString("id").orElse("?"),
                    Integer.toString(piece.getInt("GD").orElse(0)),
                    Integer.toString(piece.getInt("O").orElse(-1)),
                    Integer.toString(box[0]), Integer.toString(box[1]), Integer.toString(box[2]),
                    Integer.toString(box[3]), Integer.toString(box[4]), Integer.toString(box[5])));
            }
        }

        return found;
    }

    private static CompoundTag read(Path regions, int x, int z) throws Exception {
        Path file = regions.resolve("r." + (x >> 5) + "." + (z >> 5) + ".mca");

        if (!Files.exists(file)) {
            return null;
        }

        try (RegionFile region = new RegionFile(
            new RegionStorageInfo("structures", Level.OVERWORLD, "chunk"), file, regions, true)) {

            try (DataInputStream stream = region.getChunkDataInputStream(new ChunkPos(x, z))) {
                return stream == null ? null : NbtIo.read(stream);
            }
        }
    }

    private StructureLayoutHarness() {
    }
}
