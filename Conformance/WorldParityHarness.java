import java.io.DataOutputStream;
import java.io.DataInputStream;
import java.io.FileOutputStream;
import java.io.BufferedOutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.zip.GZIPOutputStream;
import net.minecraft.SharedConstants;
import net.minecraft.commands.arguments.blocks.BlockStateParser;
import net.minecraft.core.Holder;
import net.minecraft.core.RegistryAccess;
import net.minecraft.nbt.CompoundTag;
import net.minecraft.nbt.NbtIo;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.level.ChunkPos;
import net.minecraft.world.level.Level;
import net.minecraft.world.level.LevelHeightAccessor;
import net.minecraft.world.level.biome.Biome;
import net.minecraft.world.level.block.state.BlockState;
import net.minecraft.world.level.chunk.LevelChunkSection;
import net.minecraft.world.level.chunk.PalettedContainerFactory;
import net.minecraft.world.level.chunk.status.ChunkStatus;
import net.minecraft.world.level.chunk.storage.RegionFile;
import net.minecraft.world.level.chunk.storage.RegionStorageInfo;
import net.minecraft.world.level.chunk.storage.SerializableChunkData;

/**
 * Writes down every block and biome the real server put in a set of chunks, out of the region files it
 * saved, into the fixture WorldParityConformanceTest replays.
 *
 * <p>Usage: {@code java WorldParityHarness <regionDir> <fixture> <seed> <minY> <height> <scene>...}, a scene being
 * {@code name:chunkX:chunkZ:size}. See Conformance/worldparity.sh, which generates the world first.
 *
 * <p>This is the only fixture in the tree whose input is a world rather than a method. Everything else
 * here drives one vanilla method over inputs we chose, which cannot see a stage that is right in
 * isolation and wired up wrong: a village whose houses all fail to attach, or an ore that lands in the
 * wrong place, is a world made entirely of correct answers.
 *
 * <p>The chunks are read through {@link SerializableChunkData#parse}, so the palette, the bit widths
 * and the section layout are vanilla's own reading of its own file rather than a second guess at the
 * format. A chunk that is not {@link ChunkStatus#FULL} is refused rather than written: only the
 * forceloaded chunks are generated the whole way, and their neighbours sit at whatever status the
 * forceloaded ones needed.
 */
public class WorldParityHarness {

    /** The dimension's range, from the arguments. Written into the fixture, not assumed by it. */
    private static int MIN_Y;
    private static int HEIGHT;

    public static void main(String[] args) throws Exception {
        if (args.length < 6) {
            System.err.println("usage: WorldParityHarness <regionDir> <fixture> <seed> <minY> <height> <name:x:z:size>...");
            System.exit(2);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        Path regions = Path.of(args[0]);
        Path fixture = Path.of(args[1]);
        long seed = Long.parseLong(args[2]);
        MIN_Y = Integer.parseInt(args[3]);
        HEIGHT = Integer.parseInt(args[4]);

        List<Scene> scenes = new ArrayList<>();
        for (int i = 5; i < args.length; i++) {
            String[] parts = args[i].split(":");
            if (parts.length != 4) {
                System.err.println("Scene \"" + args[i] + "\" is not name:chunkX:chunkZ:size");
                System.exit(2);
            }

            scenes.add(new Scene(parts[0], Integer.parseInt(parts[1]), Integer.parseInt(parts[2]),
                Integer.parseInt(parts[3])));
        }

        RegistryAccess.Frozen registries = Harness.buildRegistryAccess();
        PalettedContainerFactory containers = PalettedContainerFactory.create(registries);
        LevelHeightAccessor bounds = new LevelHeightAccessor() {
            @Override public int getHeight() { return HEIGHT; }
            @Override public int getMinY() { return MIN_Y; }
        };

        Palette blocks = new Palette();
        Palette biomes = new Palette();
        List<Chunk> read = new ArrayList<>();

        for (Scene scene : scenes) {
            for (int x = scene.chunkX; x < scene.chunkX + scene.size; x++) {
                for (int z = scene.chunkZ; z < scene.chunkZ + scene.size; z++) {
                    read.add(readChunk(regions, bounds, containers, blocks, biomes, x, z));
                }
            }
        }

        Files.createDirectories(fixture.getParent());

        try (DataOutputStream out = new DataOutputStream(new GZIPOutputStream(
            new BufferedOutputStream(new FileOutputStream(fixture.toFile()))))) {

            out.writeLong(seed);
            out.writeInt(MIN_Y);
            out.writeInt(HEIGHT);

            blocks.write(out);
            biomes.write(out);

            out.writeInt(scenes.size());
            for (Scene scene : scenes) {
                out.writeUTF(scene.name);
                out.writeInt(scene.chunkX);
                out.writeInt(scene.chunkZ);
                out.writeInt(scene.size);
            }

            out.writeInt(read.size());
            for (Chunk chunk : read) {
                out.writeInt(chunk.x);
                out.writeInt(chunk.z);
                writeRuns(out, chunk.blocks);
                writeRuns(out, chunk.biomes);
            }
        }

        System.out.println("=== world parity fixture vs " + SharedConstants.getCurrentVersion().name()
            + " ===");
        System.out.println(read.size() + " chunks over " + scenes.size() + " scenes, "
            + blocks.size() + " block states and " + biomes.size() + " biomes, "
            + Files.size(fixture) / 1024 + "KB written to " + fixture);
    }

    private static Chunk readChunk(Path regions, LevelHeightAccessor bounds,
        PalettedContainerFactory containers, Palette blocks, Palette biomes, int x, int z)
        throws Exception {

        Path file = regions.resolve("r." + (x >> 5) + "." + (z >> 5) + ".mca");
        if (!Files.exists(file)) {
            throw new IllegalStateException("No region file " + file + " for chunk " + x + "," + z
                + ". The world was not generated over the scenes this was asked for.");
        }

        CompoundTag tag;
        try (RegionFile region = new RegionFile(
            new RegionStorageInfo("parity", Level.OVERWORLD, "chunk"), file, regions, true)) {

            try (DataInputStream stream = region.getChunkDataInputStream(new ChunkPos(x, z))) {
                if (stream == null) {
                    throw new IllegalStateException("Chunk " + x + "," + z + " is not in " + file
                        + ". It was never generated.");
                }

                tag = NbtIo.read(stream);
            }
        }

        SerializableChunkData data = SerializableChunkData.parse(bounds, containers, tag);

        if (data.chunkStatus() != ChunkStatus.FULL) {
            throw new IllegalStateException("Chunk " + x + "," + z + " is at status "
                + data.chunkStatus().getName() + " rather than full. Only a forceloaded chunk is "
                + "generated the whole way, so the scene has to be inside the forceloaded area.");
        }

        // A full chunk only settles the blocks its structures marked once it starts ticking, which
        // is after its neighbours are full, and the list is saved with it until then. Recorded
        // before that, a fence keeps the connections its piece wrote rather than the ones vanilla's
        // world ends up with.
        int pending = 0;
        for (it.unimi.dsi.fastutil.shorts.ShortList section : data.postProcessingSections()) {
            pending += section == null ? 0 : section.size();
        }

        if (pending > 0) {
            throw new IllegalStateException("Chunk " + x + "," + z + " still has " + pending
                + " blocks waiting for post processing. It was saved before it started ticking, so "
                + "wait longer before saving.");
        }

        // A section the file does not carry is one the generator left empty, which is air with the
        // section's own default biome. Indexed by section rather than by list position for that reason.
        Map<Integer, LevelChunkSection> sections = new HashMap<>();
        for (SerializableChunkData.SectionData section : data.sectionData()) {
            sections.put(section.y(), section.chunkSection());
        }

        int[] blockCells = new int[HEIGHT * 16 * 16];
        int[] biomeCells = new int[(HEIGHT / 4) * 4 * 4];
        int air = blocks.of("minecraft:air");
        int plains = biomes.of("minecraft:plains");

        // y then z then x, which is the order our own ChunkData walks and the palette stores.
        for (int y = 0; y < HEIGHT; y++) {
            LevelChunkSection section = sections.get((MIN_Y + y >> 4));

            for (int localZ = 0; localZ < 16; localZ++) {
                for (int localX = 0; localX < 16; localX++) {
                    int index = (y * 16 + localZ) * 16 + localX;

                    if (section == null) {
                        blockCells[index] = air;
                        continue;
                    }

                    BlockState state = section.getBlockState(localX, y & 15, localZ);
                    blockCells[index] = blocks.of(BlockStateParser.serialize(state));
                }
            }
        }

        for (int cellY = 0; cellY < HEIGHT / 4; cellY++) {
            LevelChunkSection section = sections.get((MIN_Y + cellY * 4 >> 4));

            for (int cellZ = 0; cellZ < 4; cellZ++) {
                for (int cellX = 0; cellX < 4; cellX++) {
                    int index = (cellY * 4 + cellZ) * 4 + cellX;

                    if (section == null) {
                        biomeCells[index] = plains;
                        continue;
                    }

                    Holder<Biome> biome = section.getNoiseBiome(cellX, cellY & 3, cellZ);
                    biomeCells[index] = biomes.of(biome.getRegisteredName());
                }
            }
        }

        return new Chunk(x, z, blockCells, biomeCells);
    }

    /**
     * Run length encoded, which is what keeps a fixture of ninety odd chunks to the size of the ones
     * beside it: a layer of stone is 256 identical cells in a row in this order.
     */
    private static void writeRuns(DataOutputStream out, int[] cells) throws Exception {
        List<int[]> runs = new ArrayList<>();

        int start = 0;
        for (int i = 1; i <= cells.length; i++) {
            if (i < cells.length && cells[i] == cells[start]) {
                continue;
            }

            runs.add(new int[] { i - start, cells[start] });
            start = i;
        }

        out.writeInt(runs.size());
        for (int[] run : runs) {
            out.writeInt(run[0]);
            out.writeInt(run[1]);
        }
    }

    /** The distinct values written once, so a chunk is a list of indices into them. */
    private static final class Palette {
        private final Map<String, Integer> indices = new HashMap<>();
        private final List<String> values = new ArrayList<>();

        int of(String value) {
            Integer known = indices.get(value);
            if (known != null) {
                return known;
            }

            indices.put(value, values.size());
            values.add(value);
            return values.size() - 1;
        }

        int size() {
            return values.size();
        }

        void write(DataOutputStream out) throws Exception {
            out.writeInt(values.size());
            for (String value : values) {
                out.writeUTF(value);
            }
        }
    }

    private record Scene(String name, int chunkX, int chunkZ, int size) { }

    private record Chunk(int x, int z, int[] blocks, int[] biomes) { }
}
