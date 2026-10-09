import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;

import net.minecraft.SharedConstants;
import net.minecraft.core.RegistryAccess;
import net.minecraft.nbt.CompoundTag;
import net.minecraft.nbt.NbtIo;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.level.ChunkPos;
import net.minecraft.world.level.Level;
import net.minecraft.world.level.LevelHeightAccessor;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.block.state.BlockState;
import net.minecraft.world.level.chunk.LevelChunkSection;
import net.minecraft.world.level.chunk.PalettedContainerFactory;
import net.minecraft.world.level.chunk.status.ChunkStatus;
import net.minecraft.world.level.chunk.storage.RegionFile;
import net.minecraft.world.level.chunk.storage.RegionStorageInfo;
import net.minecraft.world.level.chunk.storage.SerializableChunkData;

import java.io.DataInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Opens a world directory {@code AnvilLoader} wrote with vanilla's own {@code RegionFile} and
 * {@code SerializableChunkData.parse}, and diffs every block, biome and block entity against what the
 * C# side meant to store.
 *
 * <p>A round trip through our own reader passes whenever the writer and the reader agree, including
 * about a mistake: a sector layout vanilla drops, a palette width it reads differently, a
 * {@code DataVersion} it would run fixers over. This is the reader a world is actually opened with.
 *
 * <p>{@code parse} is the half of loading that reads the file. The other half, {@code read}, builds a
 * level chunk and wants a {@code ServerLevel}, and decides nothing about the bytes.
 */
public final class AnvilHarness {
    public static void main(String[] args) throws IOException {
        if (args.length < 2) {
            System.err.println("usage: AnvilHarness <world directory> <expected.json>");
            System.exit(2);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        // A paletted container factory needs the biome registry as well as the block one, and biomes
        // are datapack driven.
        RegistryAccess.Frozen registries = Harness.buildRegistryAccess();
        PalettedContainerFactory containers = PalettedContainerFactory.create(registries);

        Path regionDirectory = Path.of(args[0]).resolve("region");
        JsonObject root = JsonParser.parseString(Files.readString(Path.of(args[1]))).getAsJsonObject();
        int minY = root.get("minY").getAsInt();
        int worldHeight = root.get("worldHeight").getAsInt();
        int dataVersion = root.get("dataVersion").getAsInt();

        LevelHeightAccessor bounds = new LevelHeightAccessor() {
            @Override public int getHeight() { return worldHeight; }
            @Override public int getMinY() { return minY; }
        };

        List<String> failures = new ArrayList<>();
        int passed = 0;

        int current = SharedConstants.getCurrentVersion().dataVersion().version();
        if (dataVersion != current) {
            failures.add("GameVersion.DataVersion is " + dataVersion + " and the jar is " + current);
        }

        Map<Path, RegionFile> regions = new HashMap<>();
        try {
            for (JsonElement element : root.get("chunks").getAsJsonArray()) {
                JsonObject chunk = element.getAsJsonObject();
                ChunkPos pos = new ChunkPos(chunk.get("x").getAsInt(), chunk.get("z").getAsInt());
                String name = chunk.get("name").getAsString() + " at " + pos;

                try {
                    CompoundTag tag = read(regions, regionDirectory, pos);
                    String mismatch = tag == null
                        ? "vanilla finds no chunk there"
                        : check(chunk, tag, pos, bounds, containers, minY, current);
                    if (mismatch == null) {
                        passed++;
                    } else {
                        failures.add(name + ": " + mismatch);
                    }
                } catch (Exception ex) {
                    Throwable cause = ex;
                    while (cause.getCause() != null) cause = cause.getCause();
                    failures.add(name + ": " + cause.getClass().getSimpleName() + ": " + cause.getMessage());
                }
            }

            for (JsonElement element : root.get("absent").getAsJsonArray()) {
                JsonArray at = element.getAsJsonArray();
                ChunkPos pos = new ChunkPos(at.get(0).getAsInt(), at.get(1).getAsInt());
                if (read(regions, regionDirectory, pos) != null) {
                    failures.add("deleted chunk at " + pos + ": vanilla still finds it");
                } else {
                    passed++;
                }
            }
        } finally {
            for (RegionFile region : regions.values()) {
                region.close();
            }
        }

        System.out.println();
        System.out.println("=== anvil conformance vs " + SharedConstants.getCurrentVersion().name() + " ===");
        for (String failure : failures) {
            System.out.println("FAIL  " + failure);
        }
        System.out.println(passed + " passed, " + failures.size() + " failed");
        System.exit(failures.isEmpty() ? 0 : 1);
    }

    private static CompoundTag read(Map<Path, RegionFile> regions, Path directory, ChunkPos pos)
        throws IOException {

        Path path = directory.resolve("r." + (pos.x() >> 5) + "." + (pos.z() >> 5) + ".mca");
        if (!Files.exists(path)) {
            return null;
        }

        RegionFile region = regions.get(path);
        if (region == null) {
            region = new RegionFile(new RegionStorageInfo("conformance", Level.OVERWORLD, "chunk"),
                path, directory, false);
            regions.put(path, region);
        }

        try (DataInputStream stream = region.getChunkDataInputStream(pos)) {
            return stream == null ? null : NbtIo.read(stream);
        }
    }

    private static String check(JsonObject expected, CompoundTag tag, ChunkPos pos,
        LevelHeightAccessor bounds, PalettedContainerFactory containers, int minY, int current) {

        int stamped = tag.getIntOr("DataVersion", -1);
        if (stamped != current) {
            return "stamped DataVersion " + stamped + ", so vanilla would run fixers from there to " + current;
        }

        SerializableChunkData data = SerializableChunkData.parse(bounds, containers, tag);
        if (data == null) {
            return "parse declined the chunk";
        }
        if (!data.chunkPos().equals(pos)) {
            return "stored as " + data.chunkPos();
        }
        if (data.chunkStatus() != ChunkStatus.FULL) {
            return "status " + data.chunkStatus().getName() + " rather than full";
        }

        Map<Integer, LevelChunkSection> sections = new HashMap<>();
        for (SerializableChunkData.SectionData section : data.sectionData()) {
            if (section.chunkSection() != null) {
                sections.put(section.y(), section.chunkSection());
            }
        }

        int sectionCount = bounds.getHeight() >> 4;
        int minSection = minY >> 4;
        for (int i = 0; i < sectionCount; i++) {
            if (!sections.containsKey(minSection + i)) {
                return "section " + (minSection + i) + " is missing";
            }
        }

        String blocks = diffStates(expected.get("states").getAsJsonArray(), sections, minSection, bounds.getHeight());
        if (blocks != null) return blocks;

        String biomes = diffBiomes(expected.get("biomes").getAsJsonArray(), sections, minSection, bounds.getHeight());
        if (biomes != null) return biomes;

        return diffBlockEntities(expected.get("blockEntities").getAsJsonArray(), data.blockEntities());
    }

    private static String diffStates(JsonArray runs, Map<Integer, LevelChunkSection> sections, int minSection,
        int height) {

        int run = 0;
        int left = 0;
        int want = 0;

        for (int y = 0; y < height; y++) {
            LevelChunkSection section = sections.get(minSection + (y >> 4));
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    if (left == 0) {
                        JsonArray next = runs.get(run++).getAsJsonArray();
                        want = next.get(0).getAsInt();
                        left = next.get(1).getAsInt();
                    }
                    left--;

                    BlockState state = section.getBlockState(x, y & 15, z);
                    if (Block.getId(state) != want) {
                        return "block at x=" + x + " y=" + (y + (minSection << 4)) + " z=" + z + ": vanilla reads "
                            + state + ", we stored " + Block.stateById(want);
                    }
                }
            }
        }

        return null;
    }

    private static String diffBiomes(JsonArray runs, Map<Integer, LevelChunkSection> sections, int minSection,
        int height) {

        int run = 0;
        int left = 0;
        String want = null;

        for (int y = 0; y < height; y += 4) {
            LevelChunkSection section = sections.get(minSection + (y >> 4));
            for (int z = 0; z < 4; z++) {
                for (int x = 0; x < 4; x++) {
                    if (left == 0) {
                        JsonArray next = runs.get(run++).getAsJsonArray();
                        want = next.get(0).getAsString();
                        left = next.get(1).getAsInt();
                    }
                    left--;

                    String got = section.getNoiseBiome(x, (y & 15) >> 2, z).getRegisteredName();
                    if (!got.equals(want)) {
                        return "biome at cell x=" + x + " y=" + (y + (minSection << 4)) + " z=" + z + ": vanilla reads "
                            + got + ", we stored " + want;
                    }
                }
            }
        }

        return null;
    }

    private static String diffBlockEntities(JsonArray expected, List<CompoundTag> stored) {
        if (expected.size() != stored.size()) {
            return "vanilla reads " + stored.size() + " block entities, we stored " + expected.size();
        }

        for (JsonElement element : expected) {
            JsonObject want = element.getAsJsonObject();
            CompoundTag match = null;
            for (CompoundTag tag : stored) {
                if (tag.getIntOr("x", Integer.MIN_VALUE) == want.get("x").getAsInt()
                    && tag.getIntOr("y", Integer.MIN_VALUE) == want.get("y").getAsInt()
                    && tag.getIntOr("z", Integer.MIN_VALUE) == want.get("z").getAsInt()) {
                    match = tag;
                }
            }

            if (match == null) {
                return "no block entity at " + want.get("x") + ", " + want.get("y") + ", " + want.get("z");
            }
            if (!match.getStringOr("id", "").equals(want.get("id").getAsString())) {
                return "block entity id " + match.getStringOr("id", "") + ", we stored " + want.get("id").getAsString();
            }
            if (!match.getStringOr("marker", "").equals(want.get("marker").getAsString())) {
                return "block entity at " + want.get("x") + ", " + want.get("y") + ", " + want.get("z")
                    + " lost its own tags";
            }
        }

        return null;
    }
}
