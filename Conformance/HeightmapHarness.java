import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;

import net.minecraft.SharedConstants;
import net.minecraft.core.BlockPos;
import net.minecraft.core.RegistryAccess;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.level.ChunkPos;
import net.minecraft.world.level.LevelHeightAccessor;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.block.state.BlockState;
import net.minecraft.world.level.chunk.PalettedContainerFactory;
import net.minecraft.world.level.chunk.ProtoChunk;
import net.minecraft.world.level.chunk.UpgradeData;
import net.minecraft.world.level.levelgen.Heightmap;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.EnumSet;
import java.util.List;
import java.util.Set;

/**
 * Diffs our heightmaps against the ones vanilla's own {@code Heightmap.primeHeightmaps} decides on.
 *
 * <p>Every rule on our side is a reading of the jar: whether {@code MOTION_BLOCKING} is
 * {@code blocksMotion()} or that or a fluid, whether leaves are excluded by class or by tag, and
 * whether the stored number is the highest matching position or one above it. Our own tests encode
 * the same reading, so they cannot catch a misreading; this can.
 *
 * <p>{@code primeHeightmaps} only reads block states and the chunk's height bounds, so it needs a
 * {@link ProtoChunk} over a stubbed {@link LevelHeightAccessor} and nothing resembling a server
 * level. That is the same stubbing {@code PlacementHarness} does for {@code LevelReader}.
 */
public final class HeightmapHarness {
    /** The three {@code Types.sendToClient()} selects. Deliberately not all six. */
    private static final Set<Heightmap.Types> CLIENT_TYPES =
        EnumSet.of(Heightmap.Types.WORLD_SURFACE, Heightmap.Types.MOTION_BLOCKING,
            Heightmap.Types.MOTION_BLOCKING_NO_LEAVES);

    public static void main(String[] args) throws IOException {
        if (args.length < 1) {
            System.err.println("usage: HeightmapHarness <corpus.json>");
            System.exit(2);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        // The same bootstrap the packet harness uses. A paletted container factory needs the biome
        // registry as well as the block one, and biomes are datapack driven, so the static layer on
        // its own is not enough.
        RegistryAccess.Frozen registries = Harness.buildRegistryAccess();

        JsonObject root = JsonParser.parseString(Files.readString(Path.of(args[0]))).getAsJsonObject();
        int worldHeight = root.get("worldHeight").getAsInt();
        int minY = root.get("minY").getAsInt();

        List<String> failures = new ArrayList<>();
        int passed = 0;

        for (JsonElement element : root.get("scenes").getAsJsonArray()) {
            JsonObject scene = element.getAsJsonObject();
            String name = scene.get("name").getAsString();

            try {
                String mismatch = check(scene, worldHeight, minY, registries);
                if (mismatch == null) {
                    passed++;
                } else {
                    failures.add(name + ": " + mismatch);
                }
            } catch (Exception ex) {
                Throwable root2 = ex;
                while (root2.getCause() != null) root2 = root2.getCause();
                failures.add(name + ": " + root2.getClass().getSimpleName() + ": " + root2.getMessage());
            }
        }

        System.out.println();
        System.out.println("=== heightmap conformance vs "
            + SharedConstants.getCurrentVersion().name() + " ===");
        for (String failure : failures) {
            System.out.println("FAIL  " + failure);
        }
        System.out.println(passed + " passed, " + failures.size() + " failed");
        System.exit(failures.isEmpty() ? 0 : 1);
    }

    private static String check(JsonObject scene, int worldHeight, int minY,
        RegistryAccess.Frozen registries) {

        LevelHeightAccessor bounds = new LevelHeightAccessor() {
            @Override public int getHeight() { return worldHeight; }
            @Override public int getMinY() { return minY; }
        };

        ProtoChunk chunk = new ProtoChunk(new ChunkPos(0, 0), UpgradeData.EMPTY, bounds,
            PalettedContainerFactory.create(registries), null);

        // The samples index by protocol y, counting from the world floor, which is what our own
        // ChunkData does. Vanilla wants the real y.
        for (JsonElement element : scene.get("blocks").getAsJsonArray()) {
            JsonObject placed = element.getAsJsonObject();
            BlockState state = Block.stateById(placed.get("state").getAsInt());
            chunk.setBlockState(
                new BlockPos(placed.get("x").getAsInt(), placed.get("y").getAsInt() + minY,
                    placed.get("z").getAsInt()),
                state, 0);
        }

        Heightmap.primeHeightmaps(chunk, CLIENT_TYPES);

        String mismatch = diff(chunk, minY, Heightmap.Types.WORLD_SURFACE,
            scene.get("worldSurface").getAsJsonArray(), "worldSurface");
        if (mismatch != null) return mismatch;

        mismatch = diff(chunk, minY, Heightmap.Types.MOTION_BLOCKING,
            scene.get("motionBlocking").getAsJsonArray(), "motionBlocking");
        if (mismatch != null) return mismatch;

        return diff(chunk, minY, Heightmap.Types.MOTION_BLOCKING_NO_LEAVES,
            scene.get("motionBlockingNoLeaves").getAsJsonArray(), "motionBlockingNoLeaves");
    }

    /**
     * Compares one map, column by column.
     *
     * <p>Vanilla's {@code getFirstAvailable} answers in real y; the stored form, and ours, is that
     * minus the world's min y. Comparing the stored form is the point: the offset is one of the
     * things that could be wrong.
     */
    private static String diff(ProtoChunk chunk, int minY, Heightmap.Types type, JsonArray ours,
        String label) {

        Heightmap map = chunk.getOrCreateHeightmapUnprimed(type);

        for (int z = 0; z < 16; z++) {
            for (int x = 0; x < 16; x++) {
                int expected = map.getFirstAvailable(x, z) - minY;
                int actual = ours.get(z * 16 + x).getAsInt();

                if (expected != actual) {
                    return label + " at x=" + x + " z=" + z + ": vanilla says " + expected
                        + ", we say " + actual;
                }
            }
        }

        return null;
    }
}
