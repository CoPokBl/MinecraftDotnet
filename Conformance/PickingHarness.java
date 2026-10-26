import java.io.DataOutputStream;
import java.io.OutputStream;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.util.Collection;
import java.util.UUID;
import java.util.function.Consumer;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Random;
import java.util.zip.GZIPOutputStream;

import net.minecraft.SharedConstants;
import net.minecraft.core.BlockPos;
import net.minecraft.core.Direction;
import net.minecraft.core.Registry;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.component.DataComponentInitializers;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.data.registries.VanillaRegistries;
import net.minecraft.server.Bootstrap;
import net.minecraft.server.packs.PackType;
import net.minecraft.server.packs.repository.ServerPacksSource;
import net.minecraft.server.packs.resources.MultiPackResourceManager;
import net.minecraft.tags.TagLoader;
import com.mojang.authlib.GameProfile;
import com.mojang.datafixers.util.Either;
import net.minecraft.util.AbortableIterationConsumer;
import net.minecraft.world.entity.Entity;
import net.minecraft.world.entity.EntitySelector;
import net.minecraft.world.entity.EntitySpawnReason;
import net.minecraft.world.entity.EntityType;
import net.minecraft.world.entity.EntityTypes;
import net.minecraft.world.entity.decoration.ArmorStand;
import net.minecraft.world.entity.player.Player;
import net.minecraft.world.entity.projectile.ProjectileUtil;
import net.minecraft.world.item.Item;
import net.minecraft.world.item.component.AttackRange;
import net.minecraft.world.level.GameType;
import net.minecraft.world.level.Level;
import net.minecraft.world.level.border.WorldBorder;
import net.minecraft.world.level.entity.EntityTypeTest;
import net.minecraft.world.level.entity.LevelEntityGetter;
import net.minecraft.world.phys.AABB;
import net.minecraft.world.phys.EntityHitResult;
import net.minecraft.world.item.ItemStack;
import net.minecraft.world.item.Items;
import net.minecraft.world.level.BlockGetter;
import net.minecraft.world.level.ClipContext;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.block.Blocks;
import net.minecraft.world.level.block.LightBlock;
import net.minecraft.world.level.block.ScaffoldingBlock;
import net.minecraft.world.level.block.ShulkerBoxBlock;
import net.minecraft.world.level.block.entity.BlockEntity;
import net.minecraft.world.level.block.entity.ShulkerBoxBlockEntity;
import net.minecraft.world.level.block.piston.MovingPistonBlock;
import net.minecraft.world.level.block.piston.PistonBaseBlock;
import net.minecraft.world.level.block.piston.PistonHeadBlock;
import net.minecraft.world.level.block.state.BlockState;
import net.minecraft.world.level.block.state.properties.PistonType;
import net.minecraft.world.level.material.FluidState;
import net.minecraft.world.phys.BlockHitResult;
import net.minecraft.world.phys.HitResult;
import net.minecraft.world.phys.Vec3;
import net.minecraft.world.phys.shapes.CollisionContext;
import net.minecraft.world.phys.shapes.EntityCollisionContext;
import org.jspecify.annotations.Nullable;

/**
 * Runs the real {@code BlockGetter.clip} with {@code ClipContext.Block.OUTLINE}, the clip
 * {@code Entity.pick} makes for the crosshair, over the scenes whose outline the per state shape table
 * cannot describe, and writes what it decided into the fixture PickingConformanceTest replays: an
 * opening and closing shulker box, whose shape is its block entity's lid; a light block and scaffolding
 * under a context holding each item; and the moving pistons a piston leaves as it extends and retracts.
 * <p>
 * Each hit is written whole, block, face, location and whether the ray started inside, because all four
 * go into the use packet the server reads.
 * <p>
 * It also runs {@code ProjectileUtil.getHitEntitiesAlong} and {@code AttackRange.getClosesetHit}, the pick a held
 * attack range such as a spear's makes before the plain one, over players with entities, blocks and world borders
 * around their reach, and writes every candidate and the chosen hit.
 * <p>
 * Compiled and run by Conformance/picking.sh.
 */
public final class PickingHarness {
    private static final BlockPos ORIGIN = new BlockPos(3, 20, 5);

    public static void main(String[] args) throws Exception {
        if (args.length != 1) {
            System.err.println("Usage: PickingHarness <output-file>");
            System.exit(1);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();
        MultiPackResourceManager resources = new MultiPackResourceManager(PackType.SERVER_DATA,
                List.of(ServerPacksSource.createVanillaPackSource().fullResources()));
        TagLoader.loadTagsForExistingRegistries(resources, RegistryAccess.fromRegistryOfRegistries(BuiltInRegistries.REGISTRY))
                .forEach(Registry.PendingTags::apply);
        BuiltInRegistries.DATA_COMPONENT_INITIALIZERS.build(VanillaRegistries.createReloadableLookup(VanillaRegistries.createWorldLookup()))
                .forEach(DataComponentInitializers.PendingComponents::apply);

        double[][] rays = rays();
        try (OutputStream raw = Files.newOutputStream(Path.of(args[0]));
             GZIPOutputStream zipped = new GZIPOutputStream(raw);
             DataOutputStream out = new DataOutputStream(zipped)) {
            out.writeBytes("MCPICK1");
            out.writeInt(ORIGIN.getX());
            out.writeInt(ORIGIN.getY());
            out.writeInt(ORIGIN.getZ());
            out.writeInt(rays.length);
            for (double[] ray : rays) {
                for (double v : ray) {
                    out.writeDouble(v);
                }
            }

            int scenes = 0;

            // Kind 0: a shulker box, one scene per tick of opening it fully and closing it again. The
            // animation is ShulkerBoxBlockEntity.updateAnimation's arithmetic; the replay reaches the same
            // floats by ticking its own block entity, and checks that it did.
            for (Direction facing : Direction.values()) {
                BlockState state = Blocks.SHULKER_BOX.defaultBlockState().setValue(ShulkerBoxBlock.FACING, facing);
                float progressOld = 0.0F, progress = 0.0F;
                for (int step = 0; step <= 20; step++) {
                    if (step > 0) {
                        progressOld = progress;
                        if (step <= 10) {
                            progress += 0.1F;
                            if (progress >= 1.0F) {
                                progress = 1.0F;
                            }
                        } else {
                            progress -= 0.1F;
                            if (progress <= 0.0F) {
                                progress = 0.0F;
                            }
                        }
                    }
                    ShulkerBoxBlockEntity box = new ShulkerBoxBlockEntity(null, ORIGIN, state);
                    setFloat(box, "progressOld", progressOld);
                    setFloat(box, "progress", progress);
                    Scene scene = new Scene();
                    scene.put(ORIGIN, state, box);

                    out.writeByte(0);
                    out.writeInt(Block.BLOCK_STATE_REGISTRY.getId(state));
                    out.writeByte(step);
                    out.writeFloat(box.getProgress(0.0F));
                    out.writeFloat(box.getProgress(1.0F));
                    clipAll(out, scene, CollisionContext.empty(), rays);
                    scenes++;
                }
            }

            // Kind 1: one block on its own under a context holding an item, or nothing.
            List<BlockState> contextual = new ArrayList<>();
            contextual.add(Blocks.LIGHT.defaultBlockState());
            contextual.add(Blocks.LIGHT.defaultBlockState().setValue(LightBlock.LEVEL, 3));
            contextual.add(Blocks.SCAFFOLDING.defaultBlockState().setValue(ScaffoldingBlock.DISTANCE, 0).setValue(ScaffoldingBlock.BOTTOM, false));
            contextual.add(Blocks.SCAFFOLDING.defaultBlockState().setValue(ScaffoldingBlock.DISTANCE, 1).setValue(ScaffoldingBlock.BOTTOM, true));
            contextual.add(Blocks.SCAFFOLDING.defaultBlockState().setValue(ScaffoldingBlock.DISTANCE, 7).setValue(ScaffoldingBlock.BOTTOM, true));
            contextual.add(Blocks.BARRIER.defaultBlockState());
            contextual.add(Blocks.STRUCTURE_VOID.defaultBlockState());
            contextual.add(Blocks.POWDER_SNOW.defaultBlockState());
            Item[] held = { null, Items.LIGHT, Items.SCAFFOLDING, Items.BARRIER, Items.STRUCTURE_VOID };
            for (BlockState state : contextual) {
                for (Item item : held) {
                    Scene scene = new Scene();
                    scene.put(ORIGIN, state, null);
                    out.writeByte(1);
                    out.writeInt(Block.BLOCK_STATE_REGISTRY.getId(state));
                    out.writeUTF(item == null ? "" : BuiltInRegistries.ITEM.getKey(item).toString());
                    clipAll(out, scene, new Holding(item == null ? ItemStack.EMPTY : new ItemStack(item)), rays);
                    scenes++;
                }
            }

            // Kind 2: a piston at the origin, as PistonBaseBlock.triggerEvent leaves the level the moment the
            // block event arrives: extending into air, extending against a stone it pushes, and retracting.
            for (Direction facing : Direction.values()) {
                for (int action = 0; action < 3; action++) {
                    BlockState base = Blocks.PISTON.defaultBlockState().setValue(PistonBaseBlock.FACING, facing);
                    BlockState moving = Blocks.MOVING_PISTON.defaultBlockState()
                            .setValue(MovingPistonBlock.FACING, facing).setValue(MovingPistonBlock.TYPE, PistonType.DEFAULT);
                    BlockPos arm = ORIGIN.relative(facing);
                    BlockState head = Blocks.PISTON_HEAD.defaultBlockState()
                            .setValue(PistonHeadBlock.FACING, facing).setValue(PistonHeadBlock.TYPE, PistonType.DEFAULT);
                    Scene scene = new Scene();
                    if (action < 2) {
                        scene.put(ORIGIN, base.setValue(PistonBaseBlock.EXTENDED, true), null);
                        scene.put(arm, moving, MovingPistonBlock.newMovingBlockEntity(arm, moving, head, facing, true, true));
                        if (action == 1) {
                            BlockPos pushed = arm.relative(facing);
                            BlockState pushedState = Blocks.MOVING_PISTON.defaultBlockState().setValue(MovingPistonBlock.FACING, facing);
                            scene.put(pushed, pushedState,
                                    MovingPistonBlock.newMovingBlockEntity(pushed, pushedState, Blocks.STONE.defaultBlockState(), facing, true, false));
                        }
                    } else {
                        scene.put(ORIGIN, moving, MovingPistonBlock.newMovingBlockEntity(ORIGIN, moving, base, facing, false, true));
                    }

                    out.writeByte(2);
                    out.writeInt(Block.BLOCK_STATE_REGISTRY.getId(base));
                    out.writeInt(Block.BLOCK_STATE_REGISTRY.getId(base.setValue(PistonBaseBlock.EXTENDED, true)));
                    out.writeInt(Block.BLOCK_STATE_REGISTRY.getId(head));
                    out.writeByte(facing.get3DDataValue());
                    out.writeByte(action);
                    clipAll(out, scene, CollisionContext.empty(), rays);
                    scenes++;
                }
            }

            // Kind 3: AttackRange.getClosesetHit, the pick a held item with an attack range makes before the plain one.
            scenes += spearScenes(out);

            out.writeByte(255);
            System.out.println("Wrote " + scenes + " scenes to " + args[0]);
        }
    }

    /**
     * A player with a held attack range and up to four entities around its reach, some behind blocks or a world
     * border. Everything is placed relative to the head's look, so a scene lands near the near and far reach, the
     * hitbox margin either side of them, and the lengthening a movement along the look gives the far end.
     */
    private static int spearScenes(DataOutputStream out) throws Exception {
        // The second armor stand is made a marker, which is never picked, and an interaction is given its own size.
        EntityType<?>[] targetTypes = {
                EntityTypes.ZOMBIE, EntityTypes.SILVERFISH, EntityTypes.ARMOR_STAND, EntityTypes.ARMOR_STAND, EntityTypes.ITEM, EntityTypes.IRON_GOLEM,
                EntityTypes.INTERACTION
        };
        BlockState[] obstacles = {
                Blocks.STONE.defaultBlockState(), Blocks.GLASS.defaultBlockState(), Blocks.OAK_SLAB.defaultBlockState(),
                Blocks.OAK_FENCE.defaultBlockState(), Blocks.IRON_BARS.defaultBlockState(), Blocks.CHEST.defaultBlockState()
        };
        Random random = new Random(20261014L);
        int scenes = 0;
        for (int n = 0; n < 1500; n++) {
            SpearLevel level = SpearLevel.create();
            boolean creative = random.nextBoolean();
            Player player = new Player(level, new GameProfile(new UUID(1L, 2L), "spear")) {
                @Override
                public GameType gameMode() {
                    return creative ? GameType.CREATIVE : GameType.SURVIVAL;
                }

                @Override
                public boolean isCreative() {
                    return creative;
                }

                @Override
                public boolean isSpectator() {
                    return false;
                }
            };
            player.setId(1);
            player.setItemSlot(net.minecraft.world.entity.EquipmentSlot.MAINHAND, new ItemStack(Items.IRON_SPEAR));
            double px = 8.5 + random.nextDouble() * 2.0 - 1.0, py = 20.0 + random.nextDouble(), pz = 8.5 + random.nextDouble() * 2.0 - 1.0;
            player.setPos(px, py, pz);
            player.xo = px - (random.nextDouble() - 0.5) * 0.6;
            player.yo = py - (random.nextDouble() - 0.5) * 0.3;
            player.zo = pz - (random.nextDouble() - 0.5) * 0.6;
            float xRot = random.nextFloat() * 80.0F - 40.0F;
            float yRot = random.nextFloat() * 360.0F - 180.0F;
            float yHeadRot = random.nextInt(10) < 7 ? yRot : yRot + random.nextFloat() * 60.0F - 30.0F;
            player.setXRot(xRot);
            player.setYRot(yRot);
            player.setYHeadRot(yHeadRot);
            Vec3 movement = random.nextInt(10) < 3 ? Vec3.ZERO
                    : new Vec3(random.nextDouble() * 1.2 - 0.6, random.nextDouble() * 0.7 - 0.5, random.nextDouble() * 1.2 - 0.6);
            player.setDeltaMovement(movement);
            float partial = random.nextFloat();

            AttackRange range = switch (random.nextInt(20)) {
                case 0, 1, 2 -> new AttackRange(0.0F, 3.0F, 0.0F, 5.0F, 0.3F, 1.0F);
                case 3, 4 -> new AttackRange(1.0F, 4.0F, 0.5F, 6.0F, 0.0F, 1.0F);
                case 5, 6, 7 -> {
                    float min = random.nextFloat() * 3.0F;
                    float minCreative = random.nextFloat() * 3.0F;
                    yield new AttackRange(min, min + 0.5F + random.nextFloat() * 4.5F, minCreative, minCreative + 0.5F + random.nextFloat() * 4.5F,
                            random.nextFloat(), random.nextFloat() * 2.0F);
                }
                default -> Items.IRON_SPEAR.components().get(net.minecraft.core.component.DataComponents.ATTACK_RANGE);
            };

            Vec3 eye = player.getEyePosition();
            Vec3 look = player.getHeadLookAngle();
            Vec3 side = new Vec3(-look.z, 0.0, look.x).normalize();
            double minReach = range.effectiveMinRange(player), maxReach = range.effectiveMaxRange(player);
            double[] edges = { minReach - range.hitboxMargin(), minReach, maxReach, maxReach + range.hitboxMargin(),
                    maxReach + Math.max(0.0, movement.dot(look)) };

            int entityCount = 1 + random.nextInt(4);
            List<Entity> targets = new ArrayList<>();
            int[] kinds = new int[entityCount];
            for (int i = 0; i < entityCount; i++) {
                int kind = random.nextInt(targetTypes.length);
                kinds[i] = kind;
                Entity target = targetTypes[kind].create(level, EntitySpawnReason.COMMAND);
                target.setId(10 + i);
                if (kind == 3) {
                    Method setMarker = ArmorStand.class.getDeclaredMethod("setMarker", boolean.class);
                    setMarker.setAccessible(true);
                    setMarker.invoke(target, true);
                }
                if (target instanceof net.minecraft.world.entity.Interaction) {
                    for (String setter : new String[] { "setWidth", "setHeight" }) {
                        Method set = net.minecraft.world.entity.Interaction.class.getDeclaredMethod(setter, float.class);
                        set.setAccessible(true);
                        set.invoke(target, 0.2F + random.nextFloat() * 2.0F);
                    }
                    target.refreshDimensions();
                }
                double distance = random.nextInt(4) == 0 ? 0.3 + random.nextDouble() * 8.0 : edges[random.nextInt(edges.length)] + random.nextDouble() * 1.2 - 0.6;
                double across = random.nextInt(3) == 0 ? 0.0 : random.nextDouble() * 1.8 - 0.9;
                Vec3 at = eye.add(look.scale(distance)).add(side.scale(across));
                double drop = random.nextDouble() * target.getBbHeight() * 1.3 - target.getBbHeight() * 0.15;
                target.setPos(at.x, at.y - drop, at.z);
                targets.add(target);
            }
            level.entities.add(player);
            level.entities.addAll(targets);

            int blockCount = random.nextInt(3) == 0 ? 0 : 1 + random.nextInt(3);
            for (int i = 0; i < blockCount; i++) {
                Vec3 at = eye.add(look.scale(0.5 + random.nextDouble() * 7.0)).add(side.scale(random.nextDouble() * 1.6 - 0.8))
                        .add(0.0, random.nextDouble() * 1.6 - 0.8, 0.0);
                level.put(BlockPos.containing(at), obstacles[random.nextInt(obstacles.length)]);
            }

            int borderKind = random.nextInt(10);
            double borderX = 0.0, borderZ = 0.0, borderSize = 0.0;
            if (borderKind < 2) {
                double half = 1.5 + random.nextDouble() * 5.5;
                borderSize = half * 2.0;
                borderX = eye.x + (borderKind == 0 ? 0.0 : half + 2.0);
                borderZ = eye.z + (random.nextDouble() - 0.5);
                level.border.setCenter(borderX, borderZ);
                level.border.setSize(borderSize);
            }

            out.writeByte(3);
            out.writeBoolean(creative);
            writeVec(out, player.position());
            writeVec(out, new Vec3(player.xo, player.yo, player.zo));
            out.writeFloat(xRot);
            out.writeFloat(yRot);
            out.writeFloat(yHeadRot);
            writeVec(out, movement);
            out.writeFloat(partial);
            out.writeFloat(range.minReach());
            out.writeFloat(range.maxReach());
            out.writeFloat(range.minCreativeReach());
            out.writeFloat(range.maxCreativeReach());
            out.writeFloat(range.hitboxMargin());
            out.writeFloat(range.mobFactor());
            out.writeBoolean(borderKind < 2);
            out.writeDouble(borderX);
            out.writeDouble(borderZ);
            out.writeDouble(borderSize);
            out.writeByte(level.states.size());
            for (Map.Entry<BlockPos, BlockState> block : level.states.entrySet()) {
                out.writeInt(block.getKey().getX());
                out.writeInt(block.getKey().getY());
                out.writeInt(block.getKey().getZ());
                out.writeInt(Block.BLOCK_STATE_REGISTRY.getId(block.getValue()));
            }
            out.writeByte(targets.size());
            for (int i = 0; i < targets.size(); i++) {
                Entity target = targets.get(i);
                out.writeUTF(BuiltInRegistries.ENTITY_TYPE.getKey(target.getType()).toString());
                out.writeBoolean(kinds[i] == 3);
                boolean interaction = target instanceof net.minecraft.world.entity.Interaction;
                out.writeFloat(interaction ? target.getBbWidth() : 0.0F);
                out.writeFloat(interaction ? target.getBbHeight() : 0.0F);
                writeVec(out, target.position());
                AABB box = target.getBoundingBox();
                out.writeDouble(box.minX);
                out.writeDouble(box.minY);
                out.writeDouble(box.minZ);
                out.writeDouble(box.maxX);
                out.writeDouble(box.maxY);
                out.writeDouble(box.maxZ);
            }

            Either<BlockHitResult, Collection<EntityHitResult>> along =
                    ProjectileUtil.getHitEntitiesAlong(player, range, EntitySelector.CAN_BE_PICKED, ClipContext.Block.OUTLINE);
            if (along.left().isPresent()) {
                out.writeByte(0);
                writeHit(out, along.left().get(), targets);
            } else {
                Collection<EntityHitResult> hits = along.right().get();
                out.writeByte(1);
                out.writeByte(hits.size());
                for (EntityHitResult hit : hits) {
                    writeHit(out, hit, targets);
                }
            }
            writeHit(out, range.getClosesetHit(player, partial, EntitySelector.CAN_BE_PICKED), targets);
            scenes++;
        }
        return scenes;
    }

    private static void writeVec(DataOutputStream out, Vec3 vec) throws Exception {
        out.writeDouble(vec.x);
        out.writeDouble(vec.y);
        out.writeDouble(vec.z);
    }

    /** A miss as 0 and its location; a block as 1, whole; an entity as 2, its index among the targets and the location. */
    private static void writeHit(DataOutputStream out, HitResult hit, List<Entity> targets) throws Exception {
        if (hit instanceof EntityHitResult entity) {
            out.writeByte(2);
            out.writeByte(targets.indexOf(entity.getEntity()));
            writeVec(out, entity.getLocation());
            return;
        }
        BlockHitResult block = (BlockHitResult) hit;
        if (block.getType() == HitResult.Type.MISS) {
            out.writeByte(0);
            writeVec(out, block.getLocation());
            return;
        }
        out.writeByte(1);
        out.writeInt(block.getBlockPos().getX());
        out.writeInt(block.getBlockPos().getY());
        out.writeInt(block.getBlockPos().getZ());
        out.writeByte(block.getDirection().ordinal());
        writeVec(out, block.getLocation());
        out.writeBoolean(block.isInside());
        out.writeBoolean(block.isWorldBorderHit());
    }

    private static void clipAll(DataOutputStream out, Scene scene, CollisionContext context, double[][] rays) throws Exception {
        for (double[] ray : rays) {
            Vec3 from = new Vec3(ORIGIN.getX() + ray[0], ORIGIN.getY() + ray[1], ORIGIN.getZ() + ray[2]);
            Vec3 to = new Vec3(ORIGIN.getX() + ray[3], ORIGIN.getY() + ray[4], ORIGIN.getZ() + ray[5]);
            BlockHitResult hit = scene.clip(new ClipContext(from, to, ClipContext.Block.OUTLINE, ClipContext.Fluid.NONE, context));
            if (hit.getType() == HitResult.Type.MISS) {
                out.writeByte(0);
                continue;
            }
            out.writeByte(1);
            out.writeInt(hit.getBlockPos().getX());
            out.writeInt(hit.getBlockPos().getY());
            out.writeInt(hit.getBlockPos().getZ());
            out.writeByte(hit.getDirection().ordinal());
            out.writeDouble(hit.getLocation().x);
            out.writeDouble(hit.getLocation().y);
            out.writeDouble(hit.getLocation().z);
            out.writeBoolean(hit.isInside());
        }
    }

    private static void setFloat(Object target, String name, float value) throws Exception {
        Field field = target.getClass().getDeclaredField(name);
        field.setAccessible(true);
        field.setFloat(target, value);
    }

    /**
     * Rays relative to the origin. The fixed ones run along each axis through the middle of the block and
     * through the band a shulker's lid sweeps; the random ones aim anywhere a lid can reach.
     */
    private static double[][] rays() {
        List<double[]> rays = new ArrayList<>();
        double[] bands = { 0.5, 1.0 + 1.0E-6, 1.02, 1.25, 1.49, -0.02, -0.25, -0.49 };
        for (int axis = 0; axis < 3; axis++) {
            for (int sign = -1; sign <= 1; sign += 2) {
                for (int across = 0; across < 3; across++) {
                    if (across == axis) {
                        continue;
                    }
                    for (double a : bands) {
                        double[] from = { 0.5, 0.5, 0.5 };
                        from[axis] = 0.5 - sign * 3.0;
                        from[across] = a;
                        double[] to = from.clone();
                        to[axis] += sign * 6.0;
                        rays.add(new double[] { from[0], from[1], from[2], to[0], to[1], to[2] });
                    }
                }
                double[] out = { 0.5, 0.5, 0.5 };
                out[axis] += sign * 4.5;
                rays.add(new double[] { 0.5, 0.5, 0.5, out[0], out[1], out[2] });
            }
        }

        Random random = new Random(20261013L);
        for (int i = 0; i < 200; i++) {
            double fx = random.nextDouble() * 9.0 - 4.0;
            double fy = random.nextDouble() * 9.0 - 4.0;
            double fz = random.nextDouble() * 9.0 - 4.0;
            double tx = random.nextDouble() * 2.5 - 0.75;
            double ty = random.nextDouble() * 2.5 - 0.75;
            double tz = random.nextDouble() * 2.5 - 0.75;
            rays.add(new double[] { fx, fy, fz, fx + (tx - fx) * 2.0, fy + (ty - fy) * 2.0, fz + (tz - fz) * 2.0 });
        }
        return rays.toArray(new double[0][]);
    }

    /** {@code CollisionContext.of(entity)} for an entity holding a given main hand item. */
    private static final class Holding extends EntityCollisionContext {
        Holding(ItemStack held) {
            super(false, false, -Double.MAX_VALUE, held, false, null);
        }
    }

    /** A few blocks and their block entities, air everywhere else. */
    private static final class Scene implements BlockGetter {
        private final Map<BlockPos, BlockState> states = new HashMap<>();
        private final Map<BlockPos, BlockEntity> entities = new HashMap<>();

        void put(BlockPos pos, BlockState state, @Nullable BlockEntity entity) {
            this.states.put(pos, state);
            if (entity != null) {
                this.entities.put(pos, entity);
            }
        }

        @Override
        public @Nullable BlockEntity getBlockEntity(BlockPos at) {
            return this.entities.get(at);
        }

        @Override
        public BlockState getBlockState(BlockPos at) {
            return this.states.getOrDefault(at, Blocks.AIR.defaultBlockState());
        }

        @Override
        public FluidState getFluidState(BlockPos at) {
            return this.getBlockState(at).getFluidState();
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

    /**
     * A {@code Level} holding a few blocks, a world border and a list of entities, which is all
     * {@code ProjectileUtil.getHitEntitiesAlong} asks of one. It is allocated without running {@code Level}'s
     * constructor, so anything else on it is unset; the rest of the interface throws.
     */
    private static final class SpearLevel extends Level {
        Map<BlockPos, BlockState> states;
        List<Entity> entities;
        WorldBorder border;

        static SpearLevel create() throws Exception {
            Field theUnsafe = sun.misc.Unsafe.class.getDeclaredField("theUnsafe");
            theUnsafe.setAccessible(true);
            SpearLevel level = (SpearLevel) ((sun.misc.Unsafe) theUnsafe.get(null)).allocateInstance(SpearLevel.class);
            level.states = new java.util.LinkedHashMap<>();
            level.entities = new ArrayList<>();
            level.border = new WorldBorder();
            return level;
        }

        private SpearLevel() {
            super(null, null, null, null, false, false, 0L, 0);
        }

        void put(BlockPos pos, BlockState state) {
            this.states.put(pos, state);
        }

        @Override
        public BlockState getBlockState(BlockPos pos) {
            return this.states.getOrDefault(pos, Blocks.AIR.defaultBlockState());
        }

        @Override
        public FluidState getFluidState(BlockPos pos) {
            return this.getBlockState(pos).getFluidState();
        }

        @Override
        public net.minecraft.world.Difficulty getDifficulty() {
            return net.minecraft.world.Difficulty.NORMAL;
        }

        @Override
        public WorldBorder getWorldBorder() {
            return this.border;
        }

        @Override
        public Collection<net.minecraft.world.entity.boss.enderdragon.EnderDragonPart> dragonParts() {
            return List.of();
        }

        @Override
        protected LevelEntityGetter<Entity> getEntities() {
            return new LevelEntityGetter<>() {
                @Override
                public void get(AABB bb, Consumer<Entity> output) {
                    for (Entity entity : SpearLevel.this.entities) {
                        if (entity.getBoundingBox().intersects(bb)) {
                            output.accept(entity);
                        }
                    }
                }

                @Override
                public Entity get(int id) {
                    throw new UnsupportedOperationException();
                }

                @Override
                public Entity get(UUID id) {
                    throw new UnsupportedOperationException();
                }

                @Override
                public Iterable<Entity> getAll() {
                    throw new UnsupportedOperationException();
                }

                @Override
                public <U extends Entity> void get(EntityTypeTest<Entity, U> type, AbortableIterationConsumer<U> output) {
                    throw new UnsupportedOperationException();
                }

                @Override
                public <U extends Entity> void get(EntityTypeTest<Entity, U> type, AABB bb, AbortableIterationConsumer<U> output) {
                    throw new UnsupportedOperationException();
                }
            };
        }

        @Override
        public void sendBlockUpdated(net.minecraft.core.BlockPos a0, net.minecraft.world.level.block.state.BlockState a1, net.minecraft.world.level.block.state.BlockState a2, int a3) {
            throw new UnsupportedOperationException();
        }

        @Override
        public void playSeededSound(net.minecraft.world.entity.Entity a0, net.minecraft.world.entity.Entity a1, net.minecraft.core.Holder<net.minecraft.sounds.SoundEvent> a2, net.minecraft.sounds.SoundSource a3, float a4, float a5, long a6) {
            throw new UnsupportedOperationException();
        }

        @Override
        public void playSeededSound(net.minecraft.world.entity.Entity a0, double a1, double a2, double a3, net.minecraft.core.Holder<net.minecraft.sounds.SoundEvent> a4, net.minecraft.sounds.SoundSource a5, float a6, float a7, long a8) {
            throw new UnsupportedOperationException();
        }

        @Override
        public net.minecraft.world.TickRateManager tickRateManager() {
            throw new UnsupportedOperationException();
        }

        @Override
        public void explode(net.minecraft.world.entity.Entity a0, net.minecraft.world.damagesource.DamageSource a1, net.minecraft.world.level.ExplosionDamageCalculator a2, double a3, double a4, double a5, float a6, boolean a7, net.minecraft.world.level.Level.ExplosionInteraction a8, net.minecraft.core.particles.ParticleOptions a9, net.minecraft.core.particles.ParticleOptions a10, net.minecraft.util.random.WeightedList<net.minecraft.core.particles.ExplosionParticleInfo> a11, net.minecraft.core.Holder<net.minecraft.sounds.SoundEvent> a12) {
            throw new UnsupportedOperationException();
        }

        @Override
        public net.minecraft.world.entity.Entity getEntity(int a0) {
            throw new UnsupportedOperationException();
        }

        @Override
        public net.minecraft.world.attribute.EnvironmentAttributeSystem environmentAttributes() {
            throw new UnsupportedOperationException();
        }

        @Override
        public net.minecraft.world.clock.ClockManager clockManager() {
            throw new UnsupportedOperationException();
        }

        @Override
        public java.lang.String gatherChunkSourceStats() {
            throw new UnsupportedOperationException();
        }

        @Override
        public void setRespawnData(net.minecraft.world.level.storage.LevelData.RespawnData a0) {
            throw new UnsupportedOperationException();
        }

        @Override
        public net.minecraft.world.level.storage.LevelData.RespawnData getRespawnData() {
            throw new UnsupportedOperationException();
        }

        @Override
        public net.minecraft.world.level.saveddata.maps.MapItemSavedData getMapData(net.minecraft.world.level.saveddata.maps.MapId a0) {
            throw new UnsupportedOperationException();
        }

        @Override
        public void destroyBlockProgress(int a0, net.minecraft.core.BlockPos a1, int a2) {
            throw new UnsupportedOperationException();
        }

        @Override
        public net.minecraft.world.scores.Scoreboard getScoreboard() {
            throw new UnsupportedOperationException();
        }

        @Override
        public net.minecraft.world.item.crafting.RecipeAccess recipeAccess() {
            throw new UnsupportedOperationException();
        }



        @Override
        public net.minecraft.world.level.chunk.ChunkSource getChunkSource() {
            throw new UnsupportedOperationException();
        }

        @Override
        public void levelEvent(net.minecraft.world.entity.Entity a0, int a1, net.minecraft.core.BlockPos a2, int a3) {
            throw new UnsupportedOperationException();
        }

        @Override
        public void gameEvent(net.minecraft.core.Holder<net.minecraft.world.level.gameevent.GameEvent> a0, net.minecraft.world.phys.Vec3 a1, net.minecraft.world.level.gameevent.GameEvent.Context a2) {
            throw new UnsupportedOperationException();
        }

        @Override
        public net.minecraft.world.ticks.LevelTickAccess<net.minecraft.world.level.block.Block> getBlockTicks() {
            throw new UnsupportedOperationException();
        }

        @Override
        public net.minecraft.world.ticks.LevelTickAccess<net.minecraft.world.level.material.Fluid> getFluidTicks() {
            throw new UnsupportedOperationException();
        }

        @Override
        public int getSeaLevel() {
            throw new UnsupportedOperationException();
        }

        @Override
        public net.minecraft.core.Holder<net.minecraft.world.level.biome.Biome> getUncachedNoiseBiome(int a0, int a1, int a2) {
            throw new UnsupportedOperationException();
        }

        @Override
        public net.minecraft.world.flag.FeatureFlagSet enabledFeatures() {
            return net.minecraft.world.flag.FeatureFlags.REGISTRY.allFlags();
        }

        @Override
        public java.util.List<? extends net.minecraft.world.entity.player.Player> players() {
            throw new UnsupportedOperationException();
        }
    }

    private PickingHarness() {
    }
}
