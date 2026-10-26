import java.io.DataOutputStream;
import java.io.OutputStream;
import java.io.StringReader;
import java.lang.reflect.Field;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.EnumMap;
import java.util.List;
import java.util.Map;
import java.util.Random;
import java.util.zip.GZIPOutputStream;

import com.mojang.blaze3d.vertex.QuadInstance;
import com.mojang.blaze3d.vertex.VertexConsumer;
import com.mojang.math.Quadrant;
import net.minecraft.SharedConstants;
import net.minecraft.client.color.block.BlockColors;
import net.minecraft.client.renderer.block.BlockAndTintGetter;
import net.minecraft.client.renderer.block.BlockModelLighter;
import net.minecraft.client.renderer.block.FluidModel;
import net.minecraft.client.renderer.block.FluidRenderer;
import net.minecraft.client.renderer.block.FluidStateModelSet;
import net.minecraft.client.renderer.block.ModelBlockRenderer;
import net.minecraft.client.renderer.block.dispatch.BlockModelRotation;
import net.minecraft.client.renderer.block.dispatch.BlockStateModel;
import net.minecraft.client.renderer.block.dispatch.BlockStateModelPart;
import net.minecraft.client.renderer.texture.TextureAtlasSprite;
import net.minecraft.client.resources.model.ModelBaker;
import net.minecraft.client.resources.model.cuboid.CuboidFace;
import net.minecraft.client.resources.model.cuboid.CuboidModel;
import net.minecraft.client.resources.model.cuboid.CuboidModelElement;
import net.minecraft.client.resources.model.cuboid.FaceBakery;
import net.minecraft.client.resources.model.cuboid.UnbakedCuboidGeometry;
import net.minecraft.client.resources.model.geometry.BakedQuad;
import net.minecraft.client.resources.model.sprite.Material;
import net.minecraft.core.BlockPos;
import net.minecraft.core.Direction;
import net.minecraft.core.Registry;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.server.Bootstrap;
import net.minecraft.server.packs.PackType;
import net.minecraft.server.packs.repository.ServerPacksSource;
import net.minecraft.server.packs.resources.MultiPackResourceManager;
import net.minecraft.tags.TagLoader;
import net.minecraft.util.RandomSource;
import net.minecraft.world.level.CardinalLighting;
import net.minecraft.world.level.ColorResolver;
import net.minecraft.world.level.LightLayer;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.block.Blocks;
import net.minecraft.world.level.block.IronBarsBlock;
import net.minecraft.world.level.block.LiquidBlock;
import net.minecraft.world.level.block.SlabBlock;
import net.minecraft.world.level.block.SnowLayerBlock;
import net.minecraft.world.level.block.StairBlock;
import net.minecraft.world.level.block.entity.BlockEntity;
import net.minecraft.world.level.block.state.BlockState;
import net.minecraft.world.level.block.state.properties.BlockStateProperties;
import net.minecraft.world.level.block.state.properties.SlabType;
import net.minecraft.world.level.lighting.LevelLightEngine;
import net.minecraft.world.level.material.Fluids;
import net.minecraft.world.level.material.FluidState;
import org.joml.Vector3fc;
import org.jspecify.annotations.Nullable;
import sun.misc.Unsafe;

/**
 * Builds small scenes of block states with chosen light, draws the middle block with the real
 * {@code ModelBlockRenderer} and {@code FluidRenderer}, and writes every vertex's position, colour and
 * light coords, so BlockLightConformanceTest can hold the graphical client's mesher against them.
 * <p>
 * The middle block is drawn from block models written here rather than the game's, baked with the real
 * {@code FaceBakery}; the test bakes the same JSON with the client's own baker, so the fixture also pins
 * that the two put a quad's corners in the same order, which the ambient occlusion remap depends on. The
 * light is chosen rather than computed: the light engine has its own harness, and what this one pins is
 * only what the renderers do with the light they are given.
 * <p>
 * Compiled and run by Conformance/blocklight.sh against the client jar.
 */
public final class BlockLightHarness {
    private static final int RADIUS = 2;
    private static final int SIZE = 2 * RADIUS + 1;
    private static final int SCENES_PER_CENTRE = 10;

    private static final String CUBE = """
            { "elements": [ { "from": [0, 0, 0], "to": [16, 16, 16], "faces": {
                "down": { "texture": "#all", "cullface": "down" }, "up": { "texture": "#all", "cullface": "up" },
                "north": { "texture": "#all", "cullface": "north" }, "south": { "texture": "#all", "cullface": "south" },
                "west": { "texture": "#all", "cullface": "west" }, "east": { "texture": "#all", "cullface": "east" } } } ] }""";
    private static final String CUBE_FLAT = """
            { "ambientocclusion": false, "elements": [ { "from": [0, 0, 0], "to": [16, 16, 16], "faces": {
                "down": { "texture": "#all", "cullface": "down" }, "up": { "texture": "#all", "cullface": "up" },
                "north": { "texture": "#all", "cullface": "north" }, "south": { "texture": "#all", "cullface": "south" },
                "west": { "texture": "#all", "cullface": "west" }, "east": { "texture": "#all", "cullface": "east" } } } ] }""";
    private static final String SLAB_BOTTOM = """
            { "elements": [ { "from": [0, 0, 0], "to": [16, 8, 16], "faces": {
                "down": { "texture": "#all", "cullface": "down" }, "up": { "texture": "#all" },
                "north": { "texture": "#all", "cullface": "north" }, "south": { "texture": "#all", "cullface": "south" },
                "west": { "texture": "#all", "cullface": "west" }, "east": { "texture": "#all", "cullface": "east" } } } ] }""";
    private static final String SLAB_TOP = """
            { "elements": [ { "from": [0, 8, 0], "to": [16, 16, 16], "faces": {
                "down": { "texture": "#all" }, "up": { "texture": "#all", "cullface": "up" },
                "north": { "texture": "#all", "cullface": "north" }, "south": { "texture": "#all", "cullface": "south" },
                "west": { "texture": "#all", "cullface": "west" }, "east": { "texture": "#all", "cullface": "east" } } } ] }""";
    private static final String STEP = """
            { "elements": [
              { "from": [0, 0, 0], "to": [16, 8, 16], "faces": {
                "down": { "texture": "#all", "cullface": "down" }, "up": { "texture": "#all" },
                "north": { "texture": "#all", "cullface": "north" }, "south": { "texture": "#all", "cullface": "south" },
                "west": { "texture": "#all", "cullface": "west" }, "east": { "texture": "#all", "cullface": "east" } } },
              { "from": [8, 8, 0], "to": [16, 16, 16], "faces": {
                "up": { "texture": "#all", "cullface": "up" }, "north": { "texture": "#all", "cullface": "north" },
                "south": { "texture": "#all", "cullface": "south" }, "west": { "texture": "#all" },
                "east": { "texture": "#all", "cullface": "east" } } } ] }""";
    private static final String LAYER_6 = """
            { "elements": [ { "from": [0, 0, 0], "to": [16, 6, 16], "faces": {
                "down": { "texture": "#all", "cullface": "down" }, "up": { "texture": "#all" },
                "north": { "texture": "#all", "cullface": "north" }, "south": { "texture": "#all", "cullface": "south" },
                "west": { "texture": "#all", "cullface": "west" }, "east": { "texture": "#all", "cullface": "east" } } } ] }""";
    private static final String LAYER_1 = """
            { "elements": [ { "from": [0, 0, 0], "to": [16, 1, 16], "faces": {
                "down": { "texture": "#all", "cullface": "down" }, "up": { "texture": "#all" },
                "north": { "texture": "#all", "cullface": "north" }, "south": { "texture": "#all", "cullface": "south" },
                "west": { "texture": "#all", "cullface": "west" }, "east": { "texture": "#all", "cullface": "east" } } } ] }""";
    private static final String POST = """
            { "ambientocclusion": false, "elements": [ { "from": [7, 0, 7], "to": [9, 10, 9], "faces": {
                "down": { "texture": "#all", "cullface": "down" }, "up": { "texture": "#all" },
                "north": { "texture": "#all" }, "south": { "texture": "#all" },
                "west": { "texture": "#all" }, "east": { "texture": "#all" } } } ] }""";
    private static final String DIAGONAL = """
            { "ambientocclusion": false, "elements": [
              { "from": [1, 0, 8], "to": [15, 14, 8], "rotation": { "origin": [8, 8, 8], "axis": "y", "angle": 45, "rescale": true },
                "shade_direction_override": "up",
                "faces": { "north": { "texture": "#all" }, "south": { "texture": "#all" } } },
              { "from": [8, 0, 1], "to": [8, 14, 15], "rotation": { "origin": [8, 8, 8], "axis": "y", "angle": 45, "rescale": true },
                "shade_direction_override": "up",
                "faces": { "west": { "texture": "#all" }, "east": { "texture": "#all" } } } ] }""";
    private static final String OVERRIDE = """
            { "elements": [ { "from": [0, 0, 0], "to": [16, 16, 16], "shade_direction_override": "north", "faces": {
                "down": { "texture": "#all", "cullface": "down" }, "up": { "texture": "#all", "cullface": "up" },
                "north": { "texture": "#all", "cullface": "north" }, "south": { "texture": "#all", "cullface": "south" },
                "west": { "texture": "#all", "cullface": "west" }, "east": { "texture": "#all", "cullface": "east" } } } ] }""";
    private static final String GLOWING = """
            { "elements": [ { "from": [0, 0, 0], "to": [16, 16, 16], "light_emission": 10, "faces": {
                "down": { "texture": "#all", "cullface": "down" }, "up": { "texture": "#all", "cullface": "up" },
                "north": { "texture": "#all", "cullface": "north" }, "south": { "texture": "#all", "cullface": "south" },
                "west": { "texture": "#all", "cullface": "west" }, "east": { "texture": "#all", "cullface": "east" } } } ] }""";
    private static final String TILTED = """
            { "elements": [ { "from": [2, 0, 2], "to": [14, 8, 14], "rotation": { "origin": [8, 4, 8], "axis": "x", "angle": 22.5 }, "faces": {
                "down": { "texture": "#all" }, "up": { "texture": "#all" }, "north": { "texture": "#all" },
                "south": { "texture": "#all" }, "west": { "texture": "#all" }, "east": { "texture": "#all" } } } ] }""";
    private static final String INSET = """
            { "elements": [ { "from": [2, 3, 4], "to": [13, 14, 15], "faces": {
                "down": { "texture": "#all" }, "up": { "texture": "#all" }, "north": { "texture": "#all" },
                "south": { "texture": "#all" }, "west": { "texture": "#all" }, "east": { "texture": "#all" } } } ] }""";

    private record Part(String json, int x, int y) {
    }

    private record Centre(String name, BlockState state, List<Part> parts) {
    }

    private static final Unsafe UNSAFE = unsafe();

    /** A sprite that holds no texture, which only texture coordinates read. */
    private static final TextureAtlasSprite BLANK = blank();

    public static void main(String[] args) throws Exception {
        if (args.length != 1) {
            System.err.println("Usage: BlockLightHarness <output-file>");
            System.exit(1);
        }
        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();
        MultiPackResourceManager resources = new MultiPackResourceManager(
                PackType.SERVER_DATA, List.of(ServerPacksSource.createVanillaPackSource().fullResources()));
        TagLoader.loadTagsForExistingRegistries(resources, RegistryAccess.fromRegistryOfRegistries(BuiltInRegistries.REGISTRY))
                .forEach(Registry.PendingTags::apply);

        List<Centre> centres = centres();
        BlockState[] palette = palette();
        Random random = new Random(20261026L);
        int[][] positions = {{15, 15, 15}, {0, 0, 0}, {7, 8, 9}, {15, 0, 15}, {0, 15, 0}};

        try (OutputStream raw = Files.newOutputStream(Path.of(args[0]));
             GZIPOutputStream zipped = new GZIPOutputStream(raw);
             DataOutputStream out = new DataOutputStream(zipped)) {
            out.writeBytes("MCBLKLT1");
            out.writeInt(centres.size() * SCENES_PER_CENTRE);
            int index = 0;
            for (Centre centre : centres) {
                for (int i = 0; i < SCENES_PER_CENTRE; i++, index++) {
                    int[] local = positions[index % positions.length];
                    CardinalLighting lighting = index % 7 == 3 ? CardinalLighting.NETHER : CardinalLighting.DEFAULT;
                    boolean ambientOcclusion = index % 5 != 4;
                    Scene scene = new Scene(new BlockPos(local[0], local[1], local[2]), lighting);
                    fill(scene, centre, palette, random, i);
                    writeScene(out, centre.name() + " " + i, scene, centre, ambientOcclusion);
                }
            }
        }
        System.out.println("Wrote " + centres.size() * SCENES_PER_CENTRE + " scenes to " + args[0]);
    }

    private static List<Centre> centres() {
        List<Centre> centres = new ArrayList<>();
        List<Part> cube = List.of(new Part(CUBE, 0, 0));
        for (Block block : List.of(Blocks.STONE, Blocks.GLASS, Blocks.OAK_LEAVES, Blocks.MAGMA_BLOCK, Blocks.SEA_LANTERN, Blocks.GLOWSTONE,
                Blocks.MUD, Blocks.ICE, Blocks.BARRIER, Blocks.DIRT)) {
            centres.add(new Centre(BuiltInRegistries.BLOCK.getKey(block).getPath(), block.defaultBlockState(), cube));
        }
        centres.add(new Centre("snow_8", Blocks.SNOW.defaultBlockState().setValue(SnowLayerBlock.LAYERS, 8), cube));
        centres.add(new Centre("cube_flat", Blocks.STONE.defaultBlockState(), List.of(new Part(CUBE_FLAT, 0, 0))));
        centres.add(new Centre("slab_bottom", Blocks.OAK_SLAB.defaultBlockState(), List.of(new Part(SLAB_BOTTOM, 0, 0))));
        centres.add(new Centre("slab_top", Blocks.OAK_SLAB.defaultBlockState().setValue(SlabBlock.TYPE, SlabType.TOP), List.of(new Part(SLAB_TOP, 0, 0))));
        centres.add(new Centre("slab_waterlogged", Blocks.OAK_SLAB.defaultBlockState().setValue(BlockStateProperties.WATERLOGGED, true),
                List.of(new Part(SLAB_BOTTOM, 0, 0))));
        centres.add(new Centre("stairs", Blocks.OAK_STAIRS.defaultBlockState().setValue(StairBlock.FACING, Direction.SOUTH), List.of(new Part(STEP, 0, 90))));
        centres.add(new Centre("stairs_upside_down", Blocks.OAK_STAIRS.defaultBlockState().setValue(StairBlock.HALF, net.minecraft.world.level.block.state.properties.Half.TOP),
                List.of(new Part(STEP, 180, 270))));
        centres.add(new Centre("snow_3", Blocks.SNOW.defaultBlockState().setValue(SnowLayerBlock.LAYERS, 3), List.of(new Part(LAYER_6, 0, 0))));
        centres.add(new Centre("carpet", Blocks.MOSS_CARPET.defaultBlockState(), List.of(new Part(LAYER_1, 0, 0))));
        centres.add(new Centre("torch", Blocks.TORCH.defaultBlockState(), List.of(new Part(POST, 0, 0))));
        centres.add(new Centre("cross", Blocks.SUGAR_CANE.defaultBlockState(), List.of(new Part(DIAGONAL, 0, 0))));
        centres.add(new Centre("shade_override", Blocks.STONE.defaultBlockState(), List.of(new Part(OVERRIDE, 0, 0))));
        centres.add(new Centre("light_emission", Blocks.STONE.defaultBlockState(), List.of(new Part(GLOWING, 0, 0))));
        centres.add(new Centre("tilted", Blocks.STONE.defaultBlockState(), List.of(new Part(TILTED, 0, 0))));
        centres.add(new Centre("inset", Blocks.STONE.defaultBlockState(), List.of(new Part(INSET, 0, 0))));
        centres.add(new Centre("first_part_flat", Blocks.STONE.defaultBlockState(), List.of(new Part(POST, 0, 0), new Part(CUBE, 0, 0))));
        centres.add(new Centre("first_part_smooth", Blocks.STONE.defaultBlockState(), List.of(new Part(CUBE, 0, 0), new Part(POST, 0, 0))));
        centres.add(new Centre("water", Blocks.WATER.defaultBlockState(), List.of()));
        centres.add(new Centre("water_3", Blocks.WATER.defaultBlockState().setValue(LiquidBlock.LEVEL, 3), List.of()));
        centres.add(new Centre("water_falling", Blocks.WATER.defaultBlockState().setValue(LiquidBlock.LEVEL, 8), List.of()));
        centres.add(new Centre("lava", Blocks.LAVA.defaultBlockState(), List.of()));
        centres.add(new Centre("lava_4", Blocks.LAVA.defaultBlockState().setValue(LiquidBlock.LEVEL, 4), List.of()));
        return centres;
    }

    private static BlockState[] palette() {
        return new BlockState[]{
                Blocks.AIR.defaultBlockState(), Blocks.AIR.defaultBlockState(), Blocks.AIR.defaultBlockState(), Blocks.AIR.defaultBlockState(),
                Blocks.STONE.defaultBlockState(), Blocks.DIRT.defaultBlockState(), Blocks.GLASS.defaultBlockState(),
                Blocks.OAK_LEAVES.defaultBlockState().setValue(BlockStateProperties.PERSISTENT, true),
                Blocks.OAK_SLAB.defaultBlockState(), Blocks.OAK_SLAB.defaultBlockState().setValue(SlabBlock.TYPE, SlabType.TOP),
                Blocks.OAK_SLAB.defaultBlockState().setValue(BlockStateProperties.WATERLOGGED, true),
                Blocks.SNOW.defaultBlockState().setValue(SnowLayerBlock.LAYERS, 3), Blocks.SNOW.defaultBlockState().setValue(SnowLayerBlock.LAYERS, 8),
                Blocks.MAGMA_BLOCK.defaultBlockState(), Blocks.SEA_LANTERN.defaultBlockState(), Blocks.GLOWSTONE.defaultBlockState(),
                Blocks.MUD.defaultBlockState(), Blocks.SOUL_SAND.defaultBlockState(), Blocks.MOSS_CARPET.defaultBlockState(),
                Blocks.TORCH.defaultBlockState(), Blocks.ICE.defaultBlockState(), Blocks.BARRIER.defaultBlockState(),
                Blocks.OAK_STAIRS.defaultBlockState(), Blocks.IRON_BARS.defaultBlockState().setValue(IronBarsBlock.NORTH, true).setValue(IronBarsBlock.SOUTH, true),
                Blocks.GLASS_PANE.defaultBlockState().setValue(IronBarsBlock.EAST, true),
                Blocks.WATER.defaultBlockState(), Blocks.WATER.defaultBlockState(), Blocks.WATER.defaultBlockState().setValue(LiquidBlock.LEVEL, 4),
                Blocks.WATER.defaultBlockState().setValue(LiquidBlock.LEVEL, 8), Blocks.LAVA.defaultBlockState(),
                Blocks.LAVA.defaultBlockState().setValue(LiquidBlock.LEVEL, 2)
        };
    }

    /**
     * Random neighbours and light. A fifth of the scenes keep every level at two or under, where
     * {@code smoothBlend} stops borrowing from the centre, and a fluid's neighbours lean to the same
     * fluid and to air so its corner heights get exercised.
     */
    private static void fill(Scene scene, Centre centre, BlockState[] palette, Random random, int variant) {
        boolean dim = variant % 5 == 2;
        boolean fluid = centre.parts().isEmpty();
        for (int i = 0; i < SIZE * SIZE * SIZE; i++) {
            BlockState state = palette[random.nextInt(palette.length)];
            if (fluid && random.nextInt(3) == 0) {
                state = random.nextBoolean() ? Blocks.AIR.defaultBlockState() : centre.state().getBlock().defaultBlockState()
                        .setValue(LiquidBlock.LEVEL, random.nextInt(3) == 0 ? 0 : random.nextInt(16));
            }
            scene.states[i] = state;
            int top = dim ? 3 : 16;
            scene.sky[i] = (byte)(random.nextInt(5) == 0 ? 0 : random.nextInt(top));
            scene.block[i] = (byte)(random.nextInt(3) == 0 ? 0 : random.nextInt(top));
        }
        scene.states[Scene.index(RADIUS, RADIUS, RADIUS)] = centre.state();
    }

    private static void writeScene(DataOutputStream out, String name, Scene scene, Centre centre, boolean ambientOcclusion) throws Exception {
        out.writeUTF(name);
        CardinalLighting lighting = scene.lighting;
        for (Direction direction : Direction.values()) {
            out.writeFloat(lighting.byFace(direction));
        }
        out.writeBoolean(ambientOcclusion);
        out.writeByte(scene.centre.getX());
        out.writeByte(scene.centre.getY());
        out.writeByte(scene.centre.getZ());
        for (int i = 0; i < SIZE * SIZE * SIZE; i++) {
            out.writeInt(Block.BLOCK_STATE_REGISTRY.getId(scene.states[i]));
            out.writeByte(scene.sky[i]);
            out.writeByte(scene.block[i]);
        }

        List<TestPart> parts = new ArrayList<>();
        List<BakedQuad> baked = new ArrayList<>();
        List<Direction> culls = new ArrayList<>();
        out.writeInt(centre.parts().size());
        for (Part part : centre.parts()) {
            out.writeUTF(part.json());
            out.writeInt(part.x());
            out.writeInt(part.y());
            parts.add(bake(part, baked, culls));
        }
        out.writeInt(baked.size());
        for (int q = 0; q < baked.size(); q++) {
            BakedQuad quad = baked.get(q);
            for (int v = 0; v < 4; v++) {
                Vector3fc position = quad.position(v);
                out.writeFloat(position.x());
                out.writeFloat(position.y());
                out.writeFloat(position.z());
            }
            out.writeByte(quad.direction().get3DDataValue());
            out.writeByte(culls.get(q) == null ? -1 : culls.get(q).get3DDataValue());
            Direction shade = quad.materialInfo().shadeDirectionOverride();
            out.writeByte(shade == null ? -1 : shade.get3DDataValue());
            out.writeByte(quad.materialInfo().lightEmission());
        }

        List<float[]> vertices = new ArrayList<>();
        float x = scene.centre.getX() & 15, y = scene.centre.getY() & 15, z = scene.centre.getZ() & 15;
        BlockModelLighter.enableCaching();
        if (!parts.isEmpty()) {
            ModelBlockRenderer renderer = new ModelBlockRenderer(ambientOcclusion, true, new BlockColors());
            BlockStateModel model = new TestModel(parts);
            renderer.tesselateBlock((ox, oy, oz, quad, instance) -> {
                int emission = quad.materialInfo().lightEmission();
                for (int v = 0; v < 4; v++) {
                    Vector3fc position = quad.position(v);
                    vertices.add(new float[]{position.x() + ox, position.y() + oy, position.z() + oz,
                            Float.intBitsToFloat(instance.getColor(v)), Float.intBitsToFloat(instance.getLightCoordsWithEmission(v, emission))});
                }
            }, x, y, z, scene, scene.centre, centre.state(), model, 42L);
        }
        FluidState fluid = centre.state().getFluidState();
        if (!fluid.isEmpty()) {
            fluidRenderer().tesselate(scene, scene.centre, layer -> new Capture(vertices), centre.state(), fluid);
        }
        BlockModelLighter.clearCache();

        out.writeInt(vertices.size() / 4);
        for (float[] vertex : vertices) {
            out.writeFloat(vertex[0]);
            out.writeFloat(vertex[1]);
            out.writeFloat(vertex[2]);
            out.writeInt(Float.floatToRawIntBits(vertex[3]));
            out.writeInt(Float.floatToRawIntBits(vertex[4]));
        }
    }

    /** {@code UnbakedCuboidGeometry.bake}'s loop, with no sprites: what is written is only what light reads off a quad. */
    private static TestPart bake(Part part, List<BakedQuad> all, List<Direction> allCulls) {
        CuboidModel model = CuboidModel.fromStream(new StringReader(part.json()));
        UnbakedCuboidGeometry geometry = (UnbakedCuboidGeometry)model.geometry();
        BlockModelRotation rotation = BlockModelRotation.get(Quadrant.fromXYZAngles(quadrant(part.x()), quadrant(part.y()), Quadrant.R0));
        Map<Direction, List<BakedQuad>> culled = new EnumMap<>(Direction.class);
        for (Direction direction : Direction.values()) {
            culled.put(direction, new ArrayList<>());
        }
        List<BakedQuad> unculled = new ArrayList<>();
        for (CuboidModelElement element : geometry.elements()) {
            Vector3fc from = element.from(), to = element.to();
            boolean drawX = true, drawY = true, drawZ = true;
            if (from.x() == to.x()) {
                drawY = false;
                drawZ = false;
            }
            if (from.y() == to.y()) {
                drawX = false;
                drawZ = false;
            }
            if (from.z() == to.z()) {
                drawX = false;
                drawY = false;
            }
            if (!drawX && !drawY && !drawZ) {
                continue;
            }
            for (Map.Entry<Direction, CuboidFace> entry : element.faces().entrySet()) {
                Direction facing = entry.getKey();
                CuboidFace face = entry.getValue();
                boolean draw = switch (facing.getAxis()) {
                    case X -> drawX;
                    case Y -> drawY;
                    case Z -> drawZ;
                };
                if (!draw) {
                    continue;
                }
                BakedQuad.MaterialInfo info = new BakedQuad.MaterialInfo(BLANK, null, null, null, null, -1,
                        element.shadeDirectionOverride(), element.lightEmission());
                CuboidFace.UVs uvs = face.uvs() != null ? face.uvs() : new CuboidFace.UVs(0, 0, 16, 16);
                BakedQuad quad = FaceBakery.bakeQuad(INTERNER, from, to, uvs, face.rotation(), info, facing, rotation, element.rotation());
                Direction cull = face.cullForDirection() == null ? null : Direction.rotate(rotation.transformation().getMatrix(), face.cullForDirection());
                if (cull == null) {
                    unculled.add(quad);
                }
                else {
                    culled.get(cull).add(quad);
                }
                all.add(quad);
                allCulls.add(cull);
            }
        }
        return new TestPart(culled, unculled, model.ambientOcclusion() == null || model.ambientOcclusion());
    }

    private static Quadrant quadrant(int degrees) {
        return switch (degrees) {
            case 90 -> Quadrant.R90;
            case 180 -> Quadrant.R180;
            case 270 -> Quadrant.R270;
            default -> Quadrant.R0;
        };
    }

    private static final ModelBaker.Interner INTERNER = new ModelBaker.Interner() {
        @Override
        public Vector3fc vector(Vector3fc vector) {
            return vector;
        }

        @Override
        public BakedQuad.MaterialInfo materialInfo(BakedQuad.MaterialInfo material) {
            return material;
        }
    };

    private record TestPart(Map<Direction, List<BakedQuad>> culled, List<BakedQuad> unculled, boolean ambientOcclusion) implements BlockStateModelPart {
        @Override
        public List<BakedQuad> getQuads(@Nullable Direction direction) {
            return direction == null ? unculled : culled.get(direction);
        }

        @Override
        public boolean useAmbientOcclusion() {
            return ambientOcclusion;
        }

        @Override
        public Material.Baked particleMaterial() {
            return null;
        }

        @Override
        public int materialFlags() {
            return 0;
        }
    }

    private record TestModel(List<TestPart> parts) implements BlockStateModel {
        @Override
        public void collectParts(RandomSource random, List<BlockStateModelPart> output) {
            output.addAll(parts);
        }

        @Override
        public Material.Baked particleMaterial() {
            return null;
        }

        @Override
        public int materialFlags() {
            return 0;
        }
    }

    private static TextureAtlasSprite blank() {
        try {
            return (TextureAtlasSprite)UNSAFE.allocateInstance(TextureAtlasSprite.class);
        }
        catch (InstantiationException e) {
            throw new IllegalStateException(e);
        }
    }

    private static FluidRenderer fluidRenderer() {
        Material.Baked blank = new Material.Baked(BLANK, false);
        FluidModel water = new FluidModel(null, blank, blank, blank, null);
        FluidModel lava = new FluidModel(null, blank, blank, null, null);
        return new FluidRenderer(new FluidStateModelSet(
                Map.of(Fluids.WATER, water, Fluids.FLOWING_WATER, water, Fluids.LAVA, lava, Fluids.FLOWING_LAVA, lava), water));
    }

    private static final class Capture implements VertexConsumer {
        private final List<float[]> vertices;

        Capture(List<float[]> vertices) {
            this.vertices = vertices;
        }

        @Override
        public void addVertex(float x, float y, float z, int color, float u, float v, int overlayCoords, int lightCoords, float nx, float ny, float nz) {
            vertices.add(new float[]{x, y, z, Float.intBitsToFloat(color), Float.intBitsToFloat(lightCoords)});
        }

        @Override
        public VertexConsumer addVertex(float x, float y, float z) {
            throw new UnsupportedOperationException();
        }

        @Override
        public VertexConsumer setColor(int r, int g, int b, int a) {
            return this;
        }

        @Override
        public VertexConsumer setColor(int color) {
            return this;
        }

        @Override
        public VertexConsumer setUv(float u, float v) {
            return this;
        }

        @Override
        public VertexConsumer setUv1(int u, int v) {
            return this;
        }

        @Override
        public VertexConsumer setUv2(int u, int v) {
            return this;
        }

        @Override
        public VertexConsumer setUv3(float u, float v) {
            return this;
        }

        @Override
        public VertexConsumer setNormal(float x, float y, float z) {
            return this;
        }

        @Override
        public VertexConsumer setLineWidth(float width) {
            return this;
        }
    }

    /** Five by five by five states and light around a centre; air and darkness beyond. */
    private static final class Scene implements BlockAndTintGetter {
        final BlockPos centre;
        final CardinalLighting lighting;
        final BlockState[] states = new BlockState[SIZE * SIZE * SIZE];
        final byte[] sky = new byte[SIZE * SIZE * SIZE];
        final byte[] block = new byte[SIZE * SIZE * SIZE];

        Scene(BlockPos centre, CardinalLighting lighting) {
            this.centre = centre;
            this.lighting = lighting;
        }

        static int index(int x, int y, int z) {
            return (y * SIZE + z) * SIZE + x;
        }

        private int indexOf(BlockPos pos) {
            int x = pos.getX() - centre.getX() + RADIUS, y = pos.getY() - centre.getY() + RADIUS, z = pos.getZ() - centre.getZ() + RADIUS;
            return x < 0 || y < 0 || z < 0 || x >= SIZE || y >= SIZE || z >= SIZE ? -1 : index(x, y, z);
        }

        @Override
        public CardinalLighting cardinalLighting() {
            return lighting;
        }

        @Override
        public int getBlockTint(BlockPos pos, ColorResolver color) {
            return -1;
        }

        @Override
        public LevelLightEngine getLightEngine() {
            return LevelLightEngine.EMPTY;
        }

        @Override
        public int getBrightness(LightLayer layer, BlockPos pos) {
            int i = indexOf(pos);
            return i < 0 ? 0 : layer == LightLayer.SKY ? sky[i] : block[i];
        }

        @Override
        public @Nullable BlockEntity getBlockEntity(BlockPos pos) {
            return null;
        }

        @Override
        public BlockState getBlockState(BlockPos pos) {
            int i = indexOf(pos);
            return i < 0 ? Blocks.AIR.defaultBlockState() : states[i];
        }

        @Override
        public FluidState getFluidState(BlockPos pos) {
            return getBlockState(pos).getFluidState();
        }

        @Override
        public int getHeight() {
            return 384;
        }

        @Override
        public int getMinY() {
            return -64;
        }
    }

    private static Unsafe unsafe() {
        try {
            Field field = Unsafe.class.getDeclaredField("theUnsafe");
            field.setAccessible(true);
            return (Unsafe)field.get(null);
        }
        catch (ReflectiveOperationException e) {
            throw new IllegalStateException(e);
        }
    }
}
