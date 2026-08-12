import java.io.IOException;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;
import java.lang.reflect.ParameterizedType;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Objects;
import java.util.Set;
import java.util.TreeMap;

import net.minecraft.SharedConstants;
import net.minecraft.core.BlockPos;
import net.minecraft.core.Holder;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.resources.Identifier;
import net.minecraft.server.Bootstrap;
import net.minecraft.world.entity.EntityAttachment;
import net.minecraft.world.entity.EntityAttachments;
import net.minecraft.world.entity.EntityDimensions;
import net.minecraft.world.entity.EntityType;
import net.minecraft.world.entity.EntityTypes;
import net.minecraft.world.entity.LivingEntity;
import net.minecraft.world.entity.ai.attributes.AttributeInstance;
import net.minecraft.world.entity.ai.attributes.AttributeSupplier;
import net.minecraft.world.entity.ai.attributes.DefaultAttributes;
import net.minecraft.world.entity.ai.attributes.RangedAttribute;
import net.minecraft.world.flag.FeatureFlags;
import net.minecraft.world.item.Item;
import net.minecraft.world.level.EmptyBlockGetter;
import net.minecraft.world.level.block.Block;
import net.minecraft.world.level.block.Blocks;
import net.minecraft.world.level.block.FireBlock;
import net.minecraft.world.level.block.SoundType;
import net.minecraft.world.level.block.entity.BlockEntityType;
import net.minecraft.world.level.block.state.BlockBehaviour;
import net.minecraft.world.level.block.state.BlockState;
import net.minecraft.world.level.material.FluidState;
import net.minecraft.world.phys.Vec3;
import net.minecraft.world.phys.shapes.CollisionContext;
import net.minecraft.world.phys.shapes.VoxelShape;

/**
 * Dumps the parts of the vanilla data that no report exposes: block physics and shapes, entity
 * type dimensions, and attribute ranges. Everything CodeGen needs beyond this already comes out
 * of net.minecraft.data.Main --reports.
 * <p>
 * Kept deliberately dumb. It reads values straight off the registries and writes them out
 * verbatim; every decision about what the data means happens on the C# side.
 * <p>
 * Compiled and run by CodeGen against the unpacked server jar, see Program.cs.
 */
public final class Dumper {
    public static void main(String[] args) throws Exception {
        if (args.length != 1) {
            System.err.println("Usage: Dumper <output-directory>");
            System.exit(1);
        }

        Path out = Path.of(args[0]);
        Files.createDirectories(out);

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        write(out.resolve("block.json"), blocks());
        write(out.resolve("entity_type.json"), entityTypes());
        write(out.resolve("attribute.json"), attributes());

        reportUnknownMembers();
        System.out.println("Dumped block.json, entity_type.json and attribute.json to " + out);
    }

    // ------------------------------------------------------- completeness

    /**
     * Warns about anything on the vanilla types below that this file doesn't know about.
     * <p>
     * The dump asks for the values it wants rather than reflecting over everything, which is what
     * keeps a renamed accessor a compile error instead of a key that silently goes missing. The
     * cost is that a newly added property goes unnoticed, which is how bounceRestitution stayed out
     * of the data for a release. So: notice, don't guess. A name showing up here is either
     * something worth dumping or something to add to the list beside it.
     */
    private static void reportUnknownMembers() {
        report("BlockBehaviour.Properties", declaredFieldNames(BlockBehaviour.Properties.class), Set.of(
                // Dumped, either directly or through the state values below.
                "bounceRestitution", "canOcclude", "descriptionId", "destroyTime", "explosionResistance",
                "friction", "hasCollision", "id", "instrument", "isAir", "isRedstoneConductor",
                "jumpFactor", "lightEmission", "liquid", "mapColor", "offsetFunction", "pushReaction",
                "replaceable", "requiresCorrectToolForDrops", "soundType", "speedFactor",
                "dynamicShape", "isRandomlyTicking", "isSuffocating", "isValidSpawn", "isViewBlocking",
                "requiredFeatures", "spawnTerrainParticles",
                // Solidity is read off the state, which is what these two force.
                "forceSolidOff", "forceSolidOn",
                // Server behaviour or rendering, none of which the protocol layer models.
                "drops", "emissiveRendering", "ignitedByLava", "postProcess"));

        report("BlockState", zeroArgMethodNames(BlockBehaviour.BlockStateBase.class), Set.of(
                // Dumped.
                "blocksMotion", "canBeReplaced", "canOcclude", "getLightDampening", "getLightEmission",
                "getOcclusionShape", "getPistonPushReaction", "getSoundType", "hasOffsetFunction",
                "isAir", "isSignalSource", "isSolid", "liquid", "requiresCorrectToolForDrops",
                "instrument", "isRandomlyTicking", "shouldSpawnTerrainParticles", "getFluidState",
                // Reachable from what is dumped, or not data at all.
                "getBlock", "hasBlockEntity", "hasLargeCollisionShape", "initCache", "typeHolder",
                // Rendering, lighting and server behaviour.
                "emissiveRendering", "getRenderShape", "hasAnalogOutputSignal", "ignitedByLava",
                "isSolidRender", "propagatesSkylightDown", "useShapeForLightOcclusion"));

        report("EntityType", zeroArgMethodNames(EntityType.class), Set.of(
                // Dumped.
                "clientTrackingRange", "fireImmune", "getDescriptionId", "getDimensions", "getHeight",
                "getWidth",
                // Always Entity, which is why the entity class comes off EntityTypes' generics.
                "getBaseClass",
                // Spawning, tracking and loot, none of which the protocol layer models.
                "builtInRegistryHolder", "canSerialize", "canSpawnFarFromPlayer", "canSummon",
                "getCategory", "getDefaultLootTable", "getDescription", "isAllowedInPeaceful",
                "onlyOpCanSetNbt", "requiredFeatures", "toShortString", "toString", "trackDeltas",
                "updateInterval"));
    }

    private static void report(String owner, List<String> found, Set<String> known) {
        if (found.isEmpty()) {
            // Otherwise a reflection change turns this check into one that always passes.
            throw new IllegalStateException("Found no members at all on " + owner);
        }

        for (String name : found) {
            if (!known.contains(name)) {
                System.out.println("WARNING: " + owner + "." + name + " is new, and nothing dumps it");
            }
        }
    }

    private static List<String> declaredFieldNames(Class<?> owner) {
        List<String> names = new ArrayList<>();
        for (Field declared : owner.getDeclaredFields()) {
            if (!Modifier.isStatic(declared.getModifiers())) {
                names.add(declared.getName());
            }
        }
        return names;
    }

    private static List<String> zeroArgMethodNames(Class<?> owner) {
        List<String> names = new ArrayList<>();
        for (Method declared : owner.getDeclaredMethods()) {
            if (Modifier.isPublic(declared.getModifiers()) && declared.getParameterCount() == 0) {
                names.add(declared.getName());
            }
        }
        return names;
    }

    // ---------------------------------------------------------------- blocks

    private static Obj blocks() {
        Obj blocks = new Obj();
        Map<SoundType, String> soundNames = soundTypeNames();
        Map<Block, Obj> byBlock = new IdentityHashMap<>();

        for (Block block : BuiltInRegistries.BLOCK) {
            BlockState defaultState = block.defaultBlockState();

            Obj json = new Obj();
            json.put("id", BuiltInRegistries.BLOCK.getId(block));
            json.put("translationKey", block.getDescriptionId());
            json.put("explosionResistance", block.getExplosionResistance());
            json.put("friction", block.getFriction());
            json.put("speedFactor", block.getSpeedFactor());
            json.put("jumpFactor", block.getJumpFactor());
            json.put("bounceRestitution", block.getBounceRestitution());
            json.put("defaultStateId", Block.BLOCK_STATE_REGISTRY.getId(defaultState));
            json.put("gravity", block instanceof net.minecraft.world.level.block.FallingBlock);
            json.put("dynamicShape", getBoolean(Hidden.DYNAMIC_SHAPE, block));

            // Everything is vanilla apart from the handful an experiment gates, so only those are
            // worth writing out.
            if (!block.requiredFeatures().equals(FeatureFlags.VANILLA_SET)) {
                List<Object> names = new ArrayList<>();
                for (Identifier feature : FeatureFlags.REGISTRY.toNames(block.requiredFeatures())) {
                    names.add(feature.toString());
                }
                json.put("requiredFeatures", names);
            }

            Item item = Item.BY_BLOCK.get(block);
            if (item != null) {
                json.put("correspondingItem", BuiltInRegistries.ITEM.getKey(item).toString());
            }

            // The shape is moved by a hash of the block position for these, so the dumped shape has
            // the offset taken back out of it. There are XZ and XYZ offset functions and nothing
            // else, and the offset at the origin is minus the maximum, so a y there means XYZ.
            if (defaultState.hasOffsetFunction()) {
                boolean vertical = defaultState.getOffset(BlockPos.ZERO).y != 0;
                json.put("offsetType", vertical ? "xyz" : "xz");
                json.put("maxHorizontalOffset", invoke(Hidden.MAX_HORIZONTAL_OFFSET, block));
                json.put("maxVerticalOffset", vertical ? invoke(Hidden.MAX_VERTICAL_OFFSET, block) : 0.0f);
            }

            Obj properties = new Obj();
            for (net.minecraft.world.level.block.state.properties.Property<?> property
                    : block.getStateDefinition().getProperties()) {
                List<Object> values = new ArrayList<>();
                for (Comparable<?> value : property.getPossibleValues()) {
                    values.add(value.toString().toLowerCase(Locale.ROOT));
                }
                properties.put(property.getName(), values);
            }
            if (!properties.isEmpty()) {
                json.put("properties", properties);
            }

            // Block level values are the default state's, and a state only carries what differs
            // from them. Keeps the file to a size worth parsing: most states differ in nothing.
            Obj defaults = state(block, defaultState, soundNames);
            json.putAll(defaults);

            Obj states = new Obj();
            for (BlockState blockState : block.getStateDefinition().getPossibleStates()) {
                Obj stateJson = new Obj();
                stateJson.put("stateId", Block.BLOCK_STATE_REGISTRY.getId(blockState));
                state(block, blockState, soundNames).forEachDifferent(defaults, stateJson::put);

                List<String> assignments = new ArrayList<>();
                blockState.getValues().forEach(v -> assignments.add(v.toString().toLowerCase(Locale.ROOT)));
                states.put("[" + String.join(",", assignments) + "]", stateJson);
            }
            json.put("states", states);

            byBlock.put(block, json);
            blocks.put(BuiltInRegistries.BLOCK.getKey(block).toString(), json);
        }

        addBlockEntities(byBlock);
        return blocks;
    }

    /** Everything about a block that can vary between its states. */
    private static Obj state(Block block, BlockState blockState, Map<SoundType, String> soundNames) {
        Obj json = new Obj();
        json.put("canRespawnIn", block.isPossibleToRespawnInThis(blockState));
        json.put("hardness", blockState.getDestroySpeed(EmptyBlockGetter.INSTANCE, BlockPos.ZERO));
        json.put("lightEmission", blockState.getLightEmission());
        json.put("lightBlock", blockState.getLightDampening());
        json.put("pushReaction", blockState.getPistonPushReaction().name());
        json.put("mapColorId", blockState.getMapColor(EmptyBlockGetter.INSTANCE, BlockPos.ZERO).id);
        json.put("occludes", blockState.canOcclude());
        json.put("requiresTool", blockState.requiresCorrectToolForDrops());
        json.put("blocksMotion", blockState.blocksMotion());
        json.put("flammable", flammable(blockState));
        json.put("air", blockState.isAir());
        json.put("liquid", blockState.liquid());
        json.put("replaceable", blockState.canBeReplaced());
        json.put("solid", blockState.isSolid());
        json.put("soundType", soundNames.get(blockState.getSoundType()));
        json.put("redstoneConductor", blockState.isRedstoneConductor(EmptyBlockGetter.INSTANCE, BlockPos.ZERO));
        json.put("signalSource", blockState.isSignalSource());
        json.put("randomlyTicking", blockState.isRandomlyTicking());
        json.put("instrument", blockState.instrument().name().toLowerCase(Locale.ROOT));
        json.put("suffocating", blockState.isSuffocating(EmptyBlockGetter.INSTANCE, BlockPos.ZERO));
        json.put("viewBlocking", blockState.isViewBlocking(EmptyBlockGetter.INSTANCE, BlockPos.ZERO));
        json.put("spawnTerrainParticles", blockState.shouldSpawnTerrainParticles());
        json.put("validSpawn", validSpawn(blockState));
        // A waterlogged block carries water without being it, and the client counts the states with
        // a fluid in a chunk section off this rather than off the block. Written even when there is
        // none: a state only lists what it disagrees with the default about, and a missing key would
        // read as agreement.
        FluidState fluid = blockState.getFluidState();
        json.put("fluid", fluid.isEmpty() ? null : BuiltInRegistries.FLUID.getKey(fluid.getType()).toString());
        json.put("shape", shape(blockState, pos -> blockState.getShape(EmptyBlockGetter.INSTANCE, pos)));
        json.put("collisionShape", shape(blockState, pos -> blockState.getCollisionShape(EmptyBlockGetter.INSTANCE, pos)));
        json.put("interactionShape", shape(blockState, pos -> blockState.getInteractionShape(EmptyBlockGetter.INSTANCE, pos)));
        json.put("occlusionShape", shape(blockState, pos -> blockState.getOcclusionShape()));
        json.put("visualShape", shape(blockState, pos -> blockState.getVisualShape(
                EmptyBlockGetter.INSTANCE, pos, CollisionContext.empty())));
        return json;
    }

    /**
     * Whether a mob can spawn on this state. The predicate takes an entity type and leaves use that,
     * so a single boolean would be a lie: the answer is either uniform, or the list of types it holds
     * for.
     */
    private static Object validSpawn(BlockState blockState) {
        List<Object> allowed = new ArrayList<>();
        boolean all = true;
        for (EntityType<?> type : BuiltInRegistries.ENTITY_TYPE) {
            if (blockState.isValidSpawn(EmptyBlockGetter.INSTANCE, BlockPos.ZERO, type)) {
                allowed.add(BuiltInRegistries.ENTITY_TYPE.getKey(type).toString());
            } else {
                all = false;
            }
        }

        if (all) {
            return Boolean.TRUE;
        }
        return allowed.isEmpty() ? Boolean.FALSE : allowed;
    }

    /**
     * A shape with the position hash offset taken back out of it, so what lands in the data is the
     * shape before vanilla moves it. CodeGen has the offset bounds and puts it back per position.
     * <p>
     * The offset at the origin is exactly minus the block's maximum, so undoing it there is lossless.
     * A shape that comes out the same at two positions never had an offset applied, which is how the
     * ones taking no position (occlusion) and the empty ones stay untouched.
     */
    private static String shape(BlockState blockState, java.util.function.Function<BlockPos, VoxelShape> shapeAt) {
        String atOrigin = aabbs(shapeAt.apply(BlockPos.ZERO));
        if (!blockState.hasOffsetFunction() || atOrigin.equals(aabbs(shapeAt.apply(OFFSET_PROBE)))) {
            return atOrigin;
        }

        Vec3 offset = blockState.getOffset(BlockPos.ZERO);
        return aabbs(shapeAt.apply(BlockPos.ZERO).move(-offset.x, -offset.y, -offset.z));
    }

    /** Any position whose offset differs from the origin's, which is what makes an offset visible. */
    private static final BlockPos OFFSET_PROBE = new BlockPos(7, 0, 13);

    private static String aabbs(VoxelShape shape) {
        return shape.toAabbs().toString();
    }

    @SuppressWarnings("unchecked")
    private static void addBlockEntities(Map<Block, Obj> byBlock) {
        Field validBlocks = field(BlockEntityType.class, "validBlocks");
        for (BlockEntityType<?> type : BuiltInRegistries.BLOCK_ENTITY_TYPE) {
            Obj entry = new Obj();
            entry.put("namespace", BuiltInRegistries.BLOCK_ENTITY_TYPE.getKey(type).toString());
            entry.put("id", BuiltInRegistries.BLOCK_ENTITY_TYPE.getId(type));
            try {
                for (Block block : (Set<Block>) validBlocks.get(type)) {
                    byBlock.get(block).put("blockEntity", entry);
                }
            } catch (IllegalAccessException e) {
                throw new RuntimeException(e);
            }
        }
    }

    /**
     * Held apart so it initialises on first use rather than when Dumper loads: touching Blocks
     * before {@link Bootstrap#bootStrap()} has run blows up in the registries.
     */
    private static final class Hidden {
        /** FireBlock owns the burn table and keeps the lookup to itself. */
        static final FireBlock FIRE = (FireBlock) Blocks.FIRE;
        static final Method CAN_BURN = method(FireBlock.class, "canBurn", BlockState.class);

        // Protected on BlockBehaviour, and only meaningful for the handful of blocks whose shape
        // is moved by a position hash.
        static final Method MAX_HORIZONTAL_OFFSET = method(BlockBehaviour.class, "getMaxHorizontalOffset");
        static final Method MAX_VERTICAL_OFFSET = method(BlockBehaviour.class, "getMaxVerticalOffset");

        /** Protected, and nothing on the block or the state exposes it. */
        static final Field DYNAMIC_SHAPE = field(BlockBehaviour.class, "dynamicShape");

        /** AttributeSupplier keeps its instances to itself, and only their base values are data. */
        static final Field ATTRIBUTE_INSTANCES = field(AttributeSupplier.class, "instances");

        /** Same for the attachment points hanging off EntityDimensions. */
        static final Field ATTACHMENT_POINTS = field(EntityAttachments.class, "attachments");
    }

    private static Object invoke(Method method, Object target) {
        try {
            return method.invoke(target);
        } catch (ReflectiveOperationException e) {
            throw new RuntimeException(e);
        }
    }

    private static boolean getBoolean(Field field, Object target) {
        try {
            return field.getBoolean(target);
        } catch (IllegalAccessException e) {
            throw new RuntimeException(e);
        }
    }

    private static boolean flammable(BlockState blockState) {
        try {
            return (boolean) Hidden.CAN_BURN.invoke(Hidden.FIRE, blockState);
        } catch (ReflectiveOperationException e) {
            throw new RuntimeException(e);
        }
    }

    /** SoundType instances are static fields with no name of their own. */
    private static Map<SoundType, String> soundTypeNames() {
        Map<SoundType, String> names = new HashMap<>();
        for (Field declared : SoundType.class.getDeclaredFields()) {
            if (!Modifier.isStatic(declared.getModifiers()) || declared.getType() != SoundType.class) {
                continue;
            }
            try {
                names.put((SoundType) declared.get(null), declared.getName().toLowerCase(Locale.ROOT));
            } catch (IllegalAccessException e) {
                throw new RuntimeException(e);
            }
        }
        return names;
    }

    // ---------------------------------------------------------- entity types

    private static Obj entityTypes() {
        Map<EntityType<?>, String> classNames = entityClassNames();
        Obj entities = new Obj();

        for (EntityType<?> type : BuiltInRegistries.ENTITY_TYPE) {
            EntityDimensions dimensions = type.getDimensions();

            Obj json = new Obj();
            json.put("id", BuiltInRegistries.ENTITY_TYPE.getId(type));
            json.put("translationKey", type.getDescriptionId());
            json.put("fireImmune", type.fireImmune());
            json.put("width", dimensions.width());
            json.put("height", dimensions.height());
            json.put("eyeHeight", dimensions.eyeHeight());
            json.put("clientTrackingRange", type.clientTrackingRange());
            json.put("attachments", attachments(dimensions.attachments()));
            // Gravity and air drag are constants returned by overrides on the entity class rather
            // than anything hanging off EntityType, so CodeGen reads them out of the class file.
            json.put("entityClass", classNames.get(type));

            if (DefaultAttributes.hasSupplier(type)) {
                json.put("attributes", defaultAttributes(type));
            }

            entities.put(BuiltInRegistries.ENTITY_TYPE.getKey(type).toString(), json);
        }

        return entities;
    }

    /**
     * Where riders sit, where a vehicle holds this entity, and where the name tag floats. Each
     * attachment carries a list because a boat has two seats.
     */
    @SuppressWarnings("unchecked")
    private static Obj attachments(EntityAttachments entityAttachments) {
        Map<EntityAttachment, List<Vec3>> points;
        try {
            points = (Map<EntityAttachment, List<Vec3>>) Hidden.ATTACHMENT_POINTS.get(entityAttachments);
        } catch (IllegalAccessException e) {
            throw new RuntimeException(e);
        }

        Obj json = new Obj();
        for (EntityAttachment attachment : EntityAttachment.values()) {
            List<Vec3> attached = points.get(attachment);
            if (attached == null) {
                continue;
            }

            List<Object> values = new ArrayList<>();
            for (Vec3 point : attached) {
                values.add(List.of(point.x, point.y, point.z));
            }
            json.put(attachment.name().toLowerCase(Locale.ROOT), values);
        }
        return json;
    }

    /** The base values a mob starts its attributes on, which is not the attribute's own default. */
    @SuppressWarnings("unchecked")
    private static Obj defaultAttributes(EntityType<?> type) {
        AttributeSupplier supplier = DefaultAttributes.getSupplier((EntityType<? extends LivingEntity>) type);
        Map<Holder<net.minecraft.world.entity.ai.attributes.Attribute>, AttributeInstance> instances;
        try {
            instances = (Map<Holder<net.minecraft.world.entity.ai.attributes.Attribute>, AttributeInstance>)
                    Hidden.ATTRIBUTE_INSTANCES.get(supplier);
        } catch (IllegalAccessException e) {
            throw new RuntimeException(e);
        }

        // Ordered by registry id so the generated code does not churn between runs.
        Map<Integer, AttributeInstance> byId = new TreeMap<>();
        instances.forEach((holder, instance) ->
                byId.put(BuiltInRegistries.ATTRIBUTE.getId(holder.value()), instance));

        Obj json = new Obj();
        for (AttributeInstance instance : byId.values()) {
            json.put(BuiltInRegistries.ATTRIBUTE.getKey(instance.getAttribute().value()).toString(),
                    instance.getBaseValue());
        }
        return json;
    }

    /**
     * EntityType does not know its own entity class, but every one of them is declared as an
     * {@code EntityType<TheClass>} field on EntityTypes, so the generic parameter names it.
     */
    private static Map<EntityType<?>, String> entityClassNames() {
        Map<EntityType<?>, String> names = new IdentityHashMap<>();
        for (Field declared : EntityTypes.class.getDeclaredFields()) {
            if (!EntityType.class.isAssignableFrom(declared.getType())) {
                continue;
            }
            try {
                EntityType<?> type = (EntityType<?>) declared.get(null);
                java.lang.reflect.Type argument =
                        ((ParameterizedType) declared.getGenericType()).getActualTypeArguments()[0];
                names.put(type, ((Class<?>) argument).getName());
            } catch (IllegalAccessException e) {
                throw new RuntimeException(e);
            }
        }
        return names;
    }

    // ------------------------------------------------------------ attributes

    private static Obj attributes() {
        Obj attributes = new Obj();
        for (net.minecraft.world.entity.ai.attributes.Attribute attribute : BuiltInRegistries.ATTRIBUTE) {
            Obj json = new Obj();
            json.put("id", BuiltInRegistries.ATTRIBUTE.getId(attribute));
            json.put("translationKey", attribute.getDescriptionId());
            json.put("defaultValue", attribute.getDefaultValue());
            json.put("clientSync", attribute.isClientSyncable());
            if (attribute instanceof RangedAttribute ranged) {
                json.put("minValue", ranged.getMinValue());
                json.put("maxValue", ranged.getMaxValue());
            }
            attributes.put(BuiltInRegistries.ATTRIBUTE.getKey(attribute).toString(), json);
        }
        return attributes;
    }

    // ------------------------------------------------------------ reflection

    private static Field field(Class<?> owner, String name) {
        try {
            Field found = owner.getDeclaredField(name);
            found.setAccessible(true);
            return found;
        } catch (NoSuchFieldException e) {
            throw new RuntimeException("Missing field " + owner.getName() + "." + name, e);
        }
    }

    private static Method method(Class<?> owner, String name, Class<?>... parameters) {
        try {
            Method found = owner.getDeclaredMethod(name, parameters);
            found.setAccessible(true);
            return found;
        } catch (NoSuchMethodException e) {
            throw new RuntimeException("Missing method " + owner.getName() + "." + name, e);
        }
    }

    // ------------------------------------------------------------------ json

    /** Just enough JSON to write these three files, in insertion order. */
    private static final class Obj {
        private final Map<String, Object> values = new LinkedHashMap<>();

        void put(String key, Object value) {
            values.put(key, value);
        }

        void putAll(Obj other) {
            values.putAll(other.values);
        }

        boolean isEmpty() {
            return values.isEmpty();
        }

        /** Hands over every entry whose value differs from the one {@code inherited} carries. */
        void forEachDifferent(Obj inherited, java.util.function.BiConsumer<String, Object> consumer) {
            values.forEach((key, value) -> {
                if (!Objects.equals(value, inherited.values.get(key))) {
                    consumer.accept(key, value);
                }
            });
        }
    }

    private static void write(Path path, Obj root) throws IOException {
        StringBuilder builder = new StringBuilder();
        writeValue(builder, root);
        Files.writeString(path, builder.toString(), StandardCharsets.UTF_8);
    }

    private static void writeValue(StringBuilder builder, Object value) {
        switch (value) {
            case null -> builder.append("null");
            case Obj obj -> {
                builder.append('{');
                boolean first = true;
                for (Map.Entry<String, Object> entry : obj.values.entrySet()) {
                    if (!first) {
                        builder.append(',');
                    }
                    first = false;
                    writeString(builder, entry.getKey());
                    builder.append(':');
                    writeValue(builder, entry.getValue());
                }
                builder.append('}');
            }
            case List<?> list -> {
                builder.append('[');
                for (int i = 0; i < list.size(); i++) {
                    if (i > 0) {
                        builder.append(',');
                    }
                    writeValue(builder, list.get(i));
                }
                builder.append(']');
            }
            case String string -> writeString(builder, string);
            case Boolean bool -> builder.append(bool.booleanValue());
            // Float.toString gives the shortest text that round trips back to the same float, which
            // Double.toString of the widened value does not: 0.6f would come out as 0.6000000238.
            case Float number -> builder.append(number.floatValue());
            case Number number -> builder.append(number);
            default -> throw new IllegalArgumentException("Cannot write " + value.getClass());
        }
    }

    private static void writeString(StringBuilder builder, String value) {
        builder.append('"');
        for (int i = 0; i < value.length(); i++) {
            char c = value.charAt(i);
            switch (c) {
                case '"' -> builder.append("\\\"");
                case '\\' -> builder.append("\\\\");
                case '\n' -> builder.append("\\n");
                case '\r' -> builder.append("\\r");
                case '\t' -> builder.append("\\t");
                default -> {
                    if (c < 0x20 || c > 0x7E) {
                        builder.append(String.format("\\u%04x", (int) c));
                    } else {
                        builder.append(c);
                    }
                }
            }
        }
        builder.append('"');
    }

    private Dumper() {
    }
}
