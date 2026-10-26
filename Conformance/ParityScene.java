import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.nio.file.Path;
import java.util.zip.GZIPInputStream;

/**
 * The three by three of chunks around one decorating chunk, before and after this build's decoration
 * pass, as {@code ManagedServer.Terrain.Features.FeatureLevelDump} wrote it.
 *
 * <p>Both states are here because that is the whole point: vanilla is run over the <b>before</b> and
 * its writes compared against the <b>after</b>, so the order the chunks were generated in cannot
 * affect the answer. Anything measured against a world vanilla generated on its own carries that order
 * with it and cannot be read as a parity number.
 */
public final class ParityScene {
    public long seed;
    public int chunkX;
    public int chunkZ;
    public int minY;
    public int height;

    /** How many blocks the structure pass wrote, which is what makes a chunk not comparable. */
    public int structureWrites;

    public String[] paletteNames;
    public int[] before;
    public int[] after;

    public String[] biomeNames;

    /** All nine grids, chunk by chunk from the low corner, then y, then z, then x. */
    public int[] biomes;

    /**
     * The two frozen heightmaps, per column of the three by three, in the port's own convention: the
     * highest matching position plus one, which is what {@code WorldGenRegion.getHeight} answers.
     * <p>
     * Carried rather than rescanned. They are the terrain as the carvers left it, and the state this
     * file records is later than that: whatever a neighbour forked in before the pass started is
     * already in it, and those blocks never moved the pair.
     */
    public int[] worldSurfaceWg;
    public int[] oceanFloorWg;

    /** The port's own features, and which of them wrote each position it touched. */
    public String[] ourFeatures;
    public final java.util.Map<Integer, Integer> ourWriter = new java.util.HashMap<>();

    /** The structure starts that reached this chunk, in the order they were placed. */
    public final java.util.List<Placement> placements = new java.util.ArrayList<>();

    public static ParityScene read(Path path) throws Exception {
        ParityScene scene = new ParityScene();

        try (DataInputStream in = new DataInputStream(new GZIPInputStream(
            new BufferedInputStream(new FileInputStream(path.toFile()))))) {

            scene.seed = in.readLong();
            scene.chunkX = in.readInt();
            scene.chunkZ = in.readInt();
            scene.minY = in.readInt();
            scene.height = in.readInt();
            scene.structureWrites = in.readInt();

            scene.paletteNames = new String[in.readInt()];
            for (int i = 0; i < scene.paletteNames.length; i++) {
                scene.paletteNames[i] = in.readUTF();
            }

            int cells = 9 * scene.height * 256;
            scene.before = runs(in, cells);
            scene.after = runs(in, cells);

            scene.biomeNames = new String[in.readInt()];
            for (int i = 0; i < scene.biomeNames.length; i++) {
                scene.biomeNames[i] = in.readUTF();
            }

            scene.biomes = runs(in, 9 * (scene.height / 4) * 16);

            scene.worldSurfaceWg = new int[9 * 256];
            scene.oceanFloorWg = new int[9 * 256];
            for (int i = 0; i < scene.worldSurfaceWg.length; i++) {
                scene.worldSurfaceWg[i] = in.readInt();
            }
            for (int i = 0; i < scene.oceanFloorWg.length; i++) {
                scene.oceanFloorWg[i] = in.readInt();
            }

            scene.ourFeatures = new String[in.readInt()];
            for (int i = 0; i < scene.ourFeatures.length; i++) {
                scene.ourFeatures[i] = in.readUTF();
            }

            int writes = in.readInt();
            for (int i = 0; i < writes; i++) {
                int x = in.readInt();
                int y = in.readInt();
                int z = in.readInt();
                scene.ourWriter.put(index(x, y, z, scene), in.readInt());
            }

            int starts = in.readInt();
            for (int i = 0; i < starts; i++) {
                scene.placements.add(new Placement(in.readUTF(), in.readInt(), in.readInt(),
                    in.readInt(), in.readInt()));
            }
        }

        return scene;
    }

    /**
     * One structure start that reached this chunk.
     *
     * <p>The source chunk is what a start is a function of and is not this chunk: a start is replayed
     * by every chunk its pieces reach. The step and index are what the placement random is seeded
     * from, and they are recorded rather than recomputed here so that this measures what a piece
     * <b>writes</b> given a seed rather than also re-deriving the seed.
     */
    public record Placement(String id, int sourceChunkX, int sourceChunkZ, int step, int index) {
    }

    private static int index(int x, int y, int z, ParityScene scene) {
        return scene.indexOf(x, y, z);
    }

    private static int[] runs(DataInputStream in, int cells) throws Exception {
        int[] values = new int[cells];
        int runs = in.readInt();
        int at = 0;

        for (int run = 0; run < runs; run++) {
            int length = in.readInt();
            int value = in.readInt();
            for (int i = 0; i < length; i++) {
                values[at++] = value;
            }
        }

        if (at != cells) {
            throw new IllegalStateException("The runs cover " + at + " cells, not " + cells);
        }

        return values;
    }

    /** Flat index of an absolute position, or -1 outside the three by three. */
    public int indexOf(int x, int y, int z) {
        int dx = Math.floorDiv(x, 16) - chunkX;
        int dz = Math.floorDiv(z, 16) - chunkZ;

        if (dx < -1 || dx > 1 || dz < -1 || dz > 1 || y < minY || y >= minY + height) {
            return -1;
        }

        int chunk = (dx + 1) * 3 + (dz + 1);
        return ((chunk * height + (y - minY)) * 16 + Math.floorMod(z, 16)) * 16 + Math.floorMod(x, 16);
    }

    /** The biome cell covering an absolute position, or -1 outside the three by three. */
    public int biomeIndexOf(int quartX, int quartY, int quartZ) {
        int dx = Math.floorDiv(quartX, 4) - chunkX;
        int dz = Math.floorDiv(quartZ, 4) - chunkZ;
        int cellY = quartY - (minY >> 2);

        if (dx < -1 || dx > 1 || dz < -1 || dz > 1) {
            return -1;
        }

        cellY = Math.max(0, Math.min(height / 4 - 1, cellY));
        int chunk = (dx + 1) * 3 + (dz + 1);

        return ((chunk * (height / 4) + cellY) * 4 + Math.floorMod(quartZ, 4)) * 4
            + Math.floorMod(quartX, 4);
    }
}
