import java.io.DataOutputStream;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Random;
import java.util.function.BiConsumer;
import java.util.zip.GZIPOutputStream;

import net.minecraft.SharedConstants;
import net.minecraft.core.BlockPos;
import net.minecraft.core.SectionPos;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.level.BlockGetter;
import net.minecraft.world.level.ChunkPos;
import net.minecraft.world.level.LightLayer;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.block.Blocks;
import net.minecraft.world.level.block.entity.BlockEntity;
import net.minecraft.world.level.block.state.BlockState;
import net.minecraft.world.level.chunk.LightChunk;
import net.minecraft.world.level.chunk.LightChunkGetter;
import net.minecraft.world.level.lighting.ChunkSkyLightSources;
import net.minecraft.world.level.lighting.LayerLightEventListener;
import net.minecraft.world.level.lighting.LevelLightEngine;
import net.minecraft.world.level.material.FluidState;
import org.jspecify.annotations.Nullable;

/**
 * Lights three by three blocks of chunks with the vanilla light engine and writes what it worked
 * out for the middle one, so CalculatedLightingProviderConformanceTest can hold ours against it.
 * <p>
 * A packet is wrong in a way our own deserialiser cannot see, and light is wrong in a way our own
 * tests cannot: every rule in it, what a level loses crossing into a block and where a face closes
 * a gap, is a property of the game rather than of the format. The only thing that settles it is
 * the engine the game runs, which is what this drives.
 * <p>
 * The chunks are the real thing only as far as light is concerned: a {@link LightChunk} over an
 * array of states, with its sky light sources fed to vanilla's own {@link ChunkSkyLightSources}
 * one block at a time, the way {@code LevelChunk} feeds them when a block changes.
 * <p>
 * Compiled and run by Conformance/lighting.sh.
 */
public final class LightHarness {
    private static final int REGION = 3;

    /** Filled in below rather than here: touching Blocks before the bootstrap blows up. */
    private static BlockState air;

    public static void main(String[] args) throws Exception {
        if (args.length != 1) {
            System.err.println("Usage: LightHarness <output-file>");
            System.exit(1);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();
        air = Blocks.AIR.defaultBlockState();

        List<Scenario> scenarios = List.of(
                terrain(),
                structures(),
                caves(),
                emitters(),
                scatter("scatter-sparse", 48, 0.82, 1234567L),
                scatter("scatter-dense", 48, 0.45, 7654321L));

        try (OutputStream raw = Files.newOutputStream(Path.of(args[0]));
             GZIPOutputStream zipped = new GZIPOutputStream(raw);
             DataOutputStream out = new DataOutputStream(zipped)) {
            out.writeBytes("MCLIGHT1");
            out.writeInt(scenarios.size());
            for (Scenario scenario : scenarios) {
                scenario.write(out);
            }
        }

        for (Scenario scenario : scenarios) {
            System.out.println("  " + scenario.name + ": " + scenario.height + " blocks tall, "
                    + scenario.palette.size() + " states, sky light " + scenario.skyLight);
        }
        System.out.println("Wrote " + scenarios.size() + " scenarios to " + args[0]);
    }

    // ------------------------------------------------------------- scenarios

    /** Hills, a lake, trees and scattered light, which is the ordinary case. */
    private static Scenario terrain() {
        World world = new World(128);
        Random random = new Random(20260812L);

        for (int x = -16; x < 32; x++) {
            for (int z = -16; z < 32; z++) {
                int surface = 40 + (int) (5 * Math.sin(x * 0.31) + 4 * Math.cos(z * 0.27))
                        + random.nextInt(2);

                for (int y = 0; y < surface - 4; y++) {
                    world.set(x, y, z, state("minecraft:stone"));
                }
                for (int y = Math.max(0, surface - 4); y < surface; y++) {
                    world.set(x, y, z, state("minecraft:dirt"));
                }
                world.set(x, surface, z, state("minecraft:grass_block"));

                // Anything below the water line fills up, which is the one place a level is lost
                // to something that isn't a solid block.
                for (int y = surface + 1; y <= 42; y++) {
                    world.set(x, y, z, state("minecraft:water"));
                }
            }
        }

        for (int i = 0; i < 26; i++) {
            tree(world, random.nextInt(48) - 16, random.nextInt(48) - 16, random);
        }

        for (int i = 0; i < 40; i++) {
            int x = random.nextInt(48) - 16;
            int z = random.nextInt(48) - 16;
            int y = 30 + random.nextInt(30);
            world.set(x, y, z, pick(random, "minecraft:torch", "minecraft:glowstone",
                    "minecraft:sea_lantern", "minecraft:redstone_torch", "minecraft:soul_torch"));
        }

        return Scenario.of("terrain", world, true);
    }

    /**
     * The shapes light reads a face off: slabs, stairs, snow, carpets and glass, in every
     * orientation and stacked so their faces meet each other.
     */
    private static Scenario structures() {
        World world = new World(128);
        Random random = new Random(99887766L);

        for (int x = -16; x < 32; x++) {
            for (int z = -16; z < 32; z++) {
                for (int y = 0; y < 32; y++) {
                    world.set(x, y, z, state("minecraft:stone"));
                }
            }
        }

        List<BlockState> shapes = new ArrayList<>();
        for (String name : new String[]{
                "minecraft:oak_slab", "minecraft:stone_stairs", "minecraft:snow",
                "minecraft:white_carpet", "minecraft:glass", "minecraft:tinted_glass",
                "minecraft:oak_leaves", "minecraft:composter", "minecraft:repeater",
                "minecraft:farmland", "minecraft:dirt_path", "minecraft:daylight_detector",
                "minecraft:enchanting_table", "minecraft:end_portal_frame", "minecraft:lectern",
                "minecraft:stonecutter", "minecraft:sculk_sensor", "minecraft:sculk_shrieker",
                "minecraft:piston", "minecraft:piston_head", "minecraft:oak_shelf"}) {
            shapes.addAll(block(name).getStateDefinition().getPossibleStates());
        }

        // A grid of pillars a few blocks apart, each a stack of shaped blocks, so light has to get
        // between them past whatever pair of faces they leave facing each other.
        for (int x = -16; x < 32; x++) {
            for (int z = -16; z < 32; z++) {
                if (Math.floorMod(x, 3) != 0 || Math.floorMod(z, 3) != 0) {
                    continue;
                }
                int stack = 3 + random.nextInt(5);
                for (int i = 0; i < stack; i++) {
                    world.set(x, 32 + i, z, shapes.get(random.nextInt(shapes.size())));
                }
            }
        }

        // A roof of the same shapes with holes in it, which is what makes the sky sources of
        // neighbouring columns stop at different heights.
        for (int x = -16; x < 32; x++) {
            for (int z = -16; z < 32; z++) {
                if (random.nextDouble() < 0.25) {
                    continue;
                }
                world.set(x, 44, z, shapes.get(random.nextInt(shapes.size())));
            }
        }

        for (int i = 0; i < 30; i++) {
            world.set(random.nextInt(48) - 16, 33 + random.nextInt(10), random.nextInt(48) - 16,
                    pick(random, "minecraft:torch", "minecraft:lantern", "minecraft:shroomlight"));
        }

        return Scenario.of("structures", world, true);
    }

    /** Sky light finding its way down and sideways through openings, which is the hard direction. */
    private static Scenario caves() {
        World world = new World(128);
        Random random = new Random(555000111L);

        for (int x = -16; x < 32; x++) {
            for (int z = -16; z < 32; z++) {
                for (int y = 0; y < 70; y++) {
                    world.set(x, y, z, state("minecraft:stone"));
                }
            }
        }

        for (int i = 0; i < 60; i++) {
            int x = random.nextInt(48) - 16;
            int y = 20 + random.nextInt(50);
            int z = random.nextInt(48) - 16;
            int radius = 2 + random.nextInt(4);

            for (int dx = -radius; dx <= radius; dx++) {
                for (int dy = -radius; dy <= radius; dy++) {
                    for (int dz = -radius; dz <= radius; dz++) {
                        if (dx * dx + dy * dy + dz * dz <= radius * radius) {
                            world.set(x + dx, y + dy, z + dz, air);
                        }
                    }
                }
            }
        }

        // Shafts to the surface, so some of what is down there is lit by the sky rather than by
        // the torches.
        for (int i = 0; i < 12; i++) {
            int x = random.nextInt(48) - 16;
            int z = random.nextInt(48) - 16;
            for (int y = 0; y < 70; y++) {
                world.set(x, y, z, air);
            }
        }

        for (int i = 0; i < 50; i++) {
            world.set(random.nextInt(48) - 16, 20 + random.nextInt(45), random.nextInt(48) - 16,
                    pick(random, "minecraft:torch", "minecraft:lava", "minecraft:glowstone"));
        }

        return Scenario.of("caves", world, true);
    }

    /**
     * No sky at all, and sources put where only a region wide search reaches them: the corners of
     * the diagonal chunks, whose light arrives in the middle one through the chunks beside it.
     */
    private static Scenario emitters() {
        World world = new World(64);
        Random random = new Random(31415926L);

        for (int x = -16; x < 32; x++) {
            for (int z = -16; z < 32; z++) {
                world.set(x, 0, z, state("minecraft:bedrock"));
                world.set(x, 40, z, state("minecraft:bedrock"));
            }
        }

        int[][] corners = {{-1, -1}, {-1, 1}, {1, -1}, {1, 1}};
        for (int[] corner : corners) {
            int x = corner[0] < 0 ? -1 : 16;
            int z = corner[1] < 0 ? -1 : 16;
            world.set(x, 8, z, state("minecraft:glowstone"));
            world.set(x, 20, z, state("minecraft:sea_lantern"));
        }

        // A wall through the middle chunk, so the light that reaches the far side of it has to
        // have come round through a neighbour.
        for (int z = -16; z < 32; z++) {
            for (int y = 1; y < 12; y++) {
                world.set(8, y, z, state("minecraft:stone"));
            }
        }

        for (int i = 0; i < 60; i++) {
            world.set(random.nextInt(48) - 16, 1 + random.nextInt(38), random.nextInt(48) - 16,
                    pick(random, "minecraft:torch", "minecraft:glowstone", "minecraft:brown_mushroom",
                            "minecraft:sea_pickle", "minecraft:magma_block", "minecraft:crying_obsidian",
                            "minecraft:end_rod", "minecraft:soul_lantern"));
        }

        return Scenario.of("emitters", world, false);
    }

    /**
     * Blocks taken at random from every state of everything whose light behaviour is its own,
     * which is the one that puts unlikely pairs of faces against each other.
     */
    private static Scenario scatter(String name, int height, double airChance, long seed) {
        World world = new World(height);
        Random random = new Random(seed);
        List<BlockState> palette = scatterPalette();

        for (int x = -16; x < 32; x++) {
            for (int z = -16; z < 32; z++) {
                for (int y = 0; y < height; y++) {
                    if (random.nextDouble() >= airChance) {
                        world.set(x, y, z, palette.get(random.nextInt(palette.size())));
                    }
                }
            }
        }

        return Scenario.of(name, world, true);
    }

    private static List<BlockState> scatterPalette() {
        List<BlockState> palette = new ArrayList<>();
        for (String name : new String[]{
                // Everything that reads its own shape for light occlusion.
                "minecraft:oak_slab", "minecraft:oak_stairs", "minecraft:snow", "minecraft:farmland",
                "minecraft:dirt_path", "minecraft:daylight_detector", "minecraft:enchanting_table",
                "minecraft:end_portal_frame", "minecraft:lectern", "minecraft:stonecutter",
                "minecraft:sculk_sensor", "minecraft:sculk_shrieker", "minecraft:piston",
                "minecraft:piston_head", "minecraft:oak_shelf",
                // Dampening that isn't a solid block's.
                "minecraft:water", "minecraft:lava", "minecraft:ice", "minecraft:oak_leaves",
                "minecraft:slime_block", "minecraft:honey_block", "minecraft:cobweb",
                "minecraft:powder_snow", "minecraft:tinted_glass", "minecraft:glass",
                "minecraft:white_shulker_box", "minecraft:kelp_plant", "minecraft:sea_pickle",
                // Solid, and light that varies by state.
                "minecraft:stone", "minecraft:white_carpet", "minecraft:repeater",
                "minecraft:comparator", "minecraft:composter", "minecraft:torch",
                "minecraft:redstone_torch", "minecraft:furnace", "minecraft:campfire",
                "minecraft:candle", "minecraft:cave_vines", "minecraft:copper_bulb",
                "minecraft:glowstone", "minecraft:brown_mushroom", "minecraft:respawn_anchor",
                "minecraft:glow_lichen", "minecraft:light", "minecraft:vault"}) {
            palette.addAll(block(name).getStateDefinition().getPossibleStates());
        }
        return palette;
    }

    private static void tree(World world, int x, int z, Random random) {
        int ground = 0;
        for (int y = world.height - 1; y >= 0; y--) {
            if (!world.get(x, y, z).isAir()) {
                ground = y + 1;
                break;
            }
        }

        int trunk = 4 + random.nextInt(3);
        for (int i = 0; i < trunk; i++) {
            world.set(x, ground + i, z, state("minecraft:oak_log"));
        }

        for (int dx = -2; dx <= 2; dx++) {
            for (int dz = -2; dz <= 2; dz++) {
                for (int dy = 0; dy < 3; dy++) {
                    if (Math.abs(dx) + Math.abs(dz) + dy > 4) {
                        continue;
                    }
                    world.set(x + dx, ground + trunk - 1 + dy, z + dz, state("minecraft:oak_leaves"));
                }
            }
        }
    }

    private static BlockState pick(Random random, String... names) {
        return state(names[random.nextInt(names.length)]);
    }

    // ------------------------------------------------------------- the world

    /**
     * A three by three of chunks and nothing else. Only the middle one is compared, but all nine
     * are lit: light crosses fifteen blocks, which reaches in from the diagonals as well.
     */
    private static final class World implements LightChunkGetter, BlockGetter {
        final int height;
        final Map<Long, Chunk> chunks = new LinkedHashMap<>();

        World(int height) {
            this.height = height;
            for (int z = -1; z <= 1; z++) {
                for (int x = -1; x <= 1; x++) {
                    chunks.put(ChunkPos.pack(x, z), new Chunk(x, z, height, this));
                }
            }
        }

        Chunk chunk(int x, int z) {
            return chunks.get(ChunkPos.pack(x >> 4, z >> 4));
        }

        void set(int x, int y, int z, BlockState state) {
            if (y < 0 || y >= height) {
                return;
            }
            Chunk chunk = chunk(x, z);
            if (chunk != null) {
                chunk.set(x, y, z, state);
            }
        }

        BlockState get(int x, int y, int z) {
            if (y < 0 || y >= height) {
                return air;
            }
            Chunk chunk = chunk(x, z);
            return chunk == null ? air : chunk.get(x, y, z);
        }

        @Nullable
        @Override
        public LightChunk getChunkForLighting(final int x, final int z) {
            return chunks.get(ChunkPos.pack(x, z));
        }

        @Override
        public BlockGetter getLevel() {
            return this;
        }

        @Override
        public BlockState getBlockState(final BlockPos pos) {
            return get(pos.getX(), pos.getY(), pos.getZ());
        }

        @Override
        public FluidState getFluidState(final BlockPos pos) {
            return getBlockState(pos).getFluidState();
        }

        @Nullable
        @Override
        public BlockEntity getBlockEntity(final BlockPos pos) {
            return null;
        }

        @Override
        public int getHeight() {
            return height;
        }

        @Override
        public int getMinY() {
            return 0;
        }
    }

    private static final class Chunk implements LightChunk {
        final int chunkX;
        final int chunkZ;
        final int height;
        final BlockState[] blocks;
        final ChunkSkyLightSources sources;

        Chunk(int chunkX, int chunkZ, int height, BlockGetter level) {
            this.chunkX = chunkX;
            this.chunkZ = chunkZ;
            this.height = height;
            this.blocks = new BlockState[height * 256];
            java.util.Arrays.fill(this.blocks, air);
            this.sources = new ChunkSkyLightSources(level);
        }

        // Masked the way LevelChunk masks, because ChunkSkyLightSources hands its own relative
        // coordinates straight back to the chunk.
        BlockState get(int x, int y, int z) {
            return y < 0 || y >= height ? air : blocks[(y << 8) | ((z & 15) << 4) | (x & 15)];
        }

        void set(int x, int y, int z, BlockState state) {
            blocks[(y << 8) | ((z & 15) << 4) | (x & 15)] = state;
        }

        boolean sectionEmpty(int section) {
            for (int i = section << 12; i < (section + 1) << 12; i++) {
                if (!blocks[i].isAir()) {
                    return false;
                }
            }
            return true;
        }

        /**
         * Fills the sky light sources by handing vanilla every block from the top down, which is
         * what {@code LevelChunk} does per change and settles on the same answer as the bulk fill
         * a chunk load uses.
         */
        void fillSources() {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    for (int y = height - 1; y >= 0; y--) {
                        sources.update(this, x, y, z);
                    }
                }
            }
        }

        @Override
        public void findBlockLightSources(final BiConsumer<BlockPos, BlockState> consumer) {
            for (int y = 0; y < height; y++) {
                for (int z = 0; z < 16; z++) {
                    for (int x = 0; x < 16; x++) {
                        BlockState state = get(x, y, z);
                        if (state.getLightEmission() > 0) {
                            consumer.accept(new BlockPos(chunkX * 16 + x, y, chunkZ * 16 + z), state);
                        }
                    }
                }
            }
        }

        @Override
        public ChunkSkyLightSources getSkyLightSources() {
            return sources;
        }

        @Override
        public BlockState getBlockState(final BlockPos pos) {
            return get(pos.getX(), pos.getY(), pos.getZ());
        }

        @Override
        public FluidState getFluidState(final BlockPos pos) {
            return getBlockState(pos).getFluidState();
        }

        @Nullable
        @Override
        public BlockEntity getBlockEntity(final BlockPos pos) {
            return null;
        }

        @Override
        public int getHeight() {
            return height;
        }

        @Override
        public int getMinY() {
            return 0;
        }
    }

    // ---------------------------------------------------------------- output

    private record Scenario(String name, int height, boolean skyLight, List<BlockState> palette,
                            int[] blocks, byte[] sky, byte[] block) {

        static Scenario of(String name, World world, boolean skyLight) {
            for (Chunk chunk : world.chunks.values()) {
                chunk.fillSources();
            }

            LevelLightEngine engine = new LevelLightEngine(world, true, skyLight);
            int sections = world.height / 16;
            for (Chunk chunk : world.chunks.values()) {
                for (int section = 0; section < sections; section++) {
                    engine.updateSectionStatus(SectionPos.of(chunk.chunkX, section, chunk.chunkZ),
                            chunk.sectionEmpty(section));
                }
            }
            for (Chunk chunk : world.chunks.values()) {
                engine.propagateLightSources(new ChunkPos(chunk.chunkX, chunk.chunkZ));
            }
            while (engine.hasLightWork()) {
                engine.runLightUpdates();
            }

            Map<BlockState, Integer> ids = new LinkedHashMap<>();
            List<BlockState> palette = new ArrayList<>();
            int[] blocks = new int[REGION * REGION * world.height * 256];
            int at = 0;
            for (int slot = 0; slot < REGION * REGION; slot++) {
                Chunk chunk = world.chunks.get(ChunkPos.pack(slot % REGION - 1, slot / REGION - 1));
                for (int i = 0; i < world.height * 256; i++) {
                    BlockState state = chunk.blocks[i];
                    Integer id = ids.get(state);
                    if (id == null) {
                        id = palette.size();
                        ids.put(state, id);
                        palette.add(state);
                    }
                    blocks[at++] = id;
                }
            }

            LayerLightEventListener skyLayer = engine.getLayerListener(LightLayer.SKY);
            LayerLightEventListener blockLayer = engine.getLayerListener(LightLayer.BLOCK);
            byte[] sky = new byte[world.height * 256];
            byte[] block = new byte[world.height * 256];
            for (int y = 0; y < world.height; y++) {
                for (int z = 0; z < 16; z++) {
                    for (int x = 0; x < 16; x++) {
                        BlockPos pos = new BlockPos(x, y, z);
                        int i = (y << 8) | (z << 4) | x;
                        sky[i] = skyLight ? (byte) skyLayer.getLightValue(pos) : 0;
                        block[i] = (byte) blockLayer.getLightValue(pos);
                    }
                }
            }

            return new Scenario(name, world.height, skyLight, palette, blocks, sky, block);
        }

        void write(DataOutputStream out) throws Exception {
            out.writeUTF(name);
            out.writeInt(height);
            out.writeBoolean(skyLight);

            out.writeInt(palette.size());
            for (BlockState state : palette) {
                out.writeInt(Block.BLOCK_STATE_REGISTRY.getId(state));
            }

            for (int id : blocks) {
                out.writeShort(id);
            }
            out.write(sky);
            out.write(block);
        }
    }

    // --------------------------------------------------------------- lookups

    private static final Map<String, Block> BLOCKS = new HashMap<>();

    private static Block block(String name) {
        if (BLOCKS.isEmpty()) {
            for (Block block : BuiltInRegistries.BLOCK) {
                BLOCKS.put(BuiltInRegistries.BLOCK.getKey(block).toString(), block);
            }
        }

        Block block = BLOCKS.get(name);
        if (block == null) {
            throw new IllegalArgumentException("No block called " + name);
        }
        return block;
    }

    private static BlockState state(String name) {
        return block(name).defaultBlockState();
    }

    private LightHarness() {
    }
}
