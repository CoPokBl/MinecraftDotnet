import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.Set;
import java.util.TreeMap;
import java.util.TreeSet;
import java.util.stream.Stream;
import net.minecraft.SharedConstants;
import net.minecraft.core.BlockPos;
import net.minecraft.core.Holder;
import net.minecraft.core.HolderLookup;
import net.minecraft.core.HolderSet;
import net.minecraft.core.Registry;
import net.minecraft.core.RegistryAccess;
import net.minecraft.server.RegistryLayer;
import net.minecraft.resources.RegistryDataLoader;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.core.registries.Registries;
import net.minecraft.server.Bootstrap;
import net.minecraft.server.packs.PackType;
import net.minecraft.server.packs.repository.ServerPacksSource;
import net.minecraft.server.packs.resources.MultiPackResourceManager;
import net.minecraft.tags.TagLoader;
import net.minecraft.world.level.biome.Biome;
import net.minecraft.world.level.biome.BiomeSource;
import net.minecraft.world.level.biome.FeatureSorter;
import net.minecraft.world.level.biome.MultiNoiseBiomeSource;
import net.minecraft.world.level.biome.MultiNoiseBiomeSourceParameterList;
import net.minecraft.world.level.biome.MultiNoiseBiomeSourceParameterLists;
import net.minecraft.world.level.chunk.ChunkGenerator;
import net.minecraft.world.level.levelgen.GenerationStep;
import net.minecraft.world.level.levelgen.NoiseBasedChunkGenerator;
import net.minecraft.world.level.levelgen.NoiseGeneratorSettings;
import net.minecraft.world.level.levelgen.WorldgenRandom;
import net.minecraft.world.level.levelgen.XoroshiroRandomSource;
import net.minecraft.world.level.levelgen.feature.ConfiguredFeature;
import net.minecraft.world.level.levelgen.placement.PlacementFilter;
import net.minecraft.world.level.levelgen.placement.PlacedFeature;
import net.minecraft.world.level.levelgen.placement.PlacementContext;
import net.minecraft.world.level.levelgen.placement.PlacementModifier;
import net.minecraft.resources.Identifier;
import net.minecraft.resources.ResourceKey;
import net.minecraft.util.RandomSource;
import net.minecraft.util.datafix.DataFixers;
import net.minecraft.world.level.ChunkPos;
import net.minecraft.world.level.Level;
import net.minecraft.world.level.LevelHeightAccessor;
import net.minecraft.world.level.StructureManager;
import net.minecraft.world.level.levelgen.RandomState;
import net.minecraft.world.level.levelgen.structure.BoundingBox;
import net.minecraft.world.level.levelgen.structure.Structure;
import net.minecraft.world.level.levelgen.structure.StructureStart;
import net.minecraft.world.level.levelgen.structure.templatesystem.StructureTemplateManager;
import net.minecraft.world.level.storage.LevelStorageSource;

/**
 * Decorates each dumped chunk with the real vanilla feature pass and counts how much of what this
 * build wrote is what vanilla would have written.
 *
 * <p>Usage: {@code java DecorationParityHarness <directory>}. See Conformance/decorationparity.sh.
 *
 * <p><b>This is the parity number to optimise against.</b> Everything else here compares a generated
 * world against one vanilla generated on its own, which carries the order its chunks were made in:
 * a chunk decorates through its neighbours, so what one forked in before a chunk started sits in front
 * of that chunk's own features and what it forks in later sits on top. Varying only that order moves
 * the whole-world count by about a third, which is more than most fixes are worth, so a change of that
 * size cannot be read there at all.
 *
 * <p>Here both sides start from the <b>same bytes</b>: this build's own three by three as it stood the
 * moment its feature pass began. The order drops out entirely and what is left is the port. The number
 * is writes rather than blocks, because a decoration pass touches a few thousand positions out of a
 * million and counting the million would report every chunk as almost perfect.
 *
 * <p><b>Structures are placed here too, in the same interleaved loop vanilla runs them in:</b> every
 * structure of a decoration step and then every feature of it. A chunk is only skipped when its dump
 * recorded structure writes but no placements to replay, which is a dump taken before that section
 * existed.
 *
 * <p>Which starts reach a chunk is taken from the dump rather than recomputed, and the two halves that
 * splits into are pinned separately. Where a start sits and what pieces it is made of is
 * {@code structurelayout.sh}, over 8185 pieces the real server laid out. What each of those pieces
 * then <b>writes</b> is this, and it is the half nothing else covers: a mineshaft's corridors, a
 * stronghold's rooms and a monument's grid are drawn by {@code postProcess} rather than placed from a
 * template. Re-deriving the layout here would measure {@code structurelayout.sh} again and would need
 * the structure set placement, the ring search and a {@code StructureCheck}, every one of which is a
 * way for the harness to be wrong about the port rather than the other way round.
 */
public class DecorationParityHarness {

    private static final int DECORATION_STEPS = GenerationStep.Decoration.values().length;

    /**
     * Whether to diff the whole three by three after each feature rather than trusting what came
     * through {@code setBlock}, which is what puts a name on an ore's writes.
     * <p>
     * It costs a walk of a million positions per feature, so it is only affordable over a scene or
     * two: {@code PARITY_ATTRIBUTE=<x>_<z>} names them and runs nothing else.
     */
    private static boolean attributing;

    /** The feature {@code PARITY_TRACE} names, whose candidates are printed one per line. */
    private static String traced;

    /** A feature name to break the differences down by chunk for, so a trace has somewhere to go. */
    private static String worst;

    private static final Map<String, Integer> byChunk = new TreeMap<>();

    /** Every placed feature that wrote at least one block, which is what the run actually exercised. */
    private static final Set<String> ranFeatures = new TreeSet<>();

    /** Every structure id a scene asked to be placed, so a run says what it reached. */
    private static final Set<String> ranStructures = new TreeSet<>();

    /**
     * The vanilla structure apparatus, or null when nothing dumped a placement.
     *
     * <p>Built once: the template manager parses 1212 saved builds off the pack and a start's layout
     * reads only the registry, so nothing here is per chunk.
     */
    private static StructureTemplateManager templates;

    /**
     * A structure manager holding nothing.
     *
     * <p>{@code placeInChunk} hands it to every piece's {@code postProcess}, and what a piece asks it
     * is whether some other structure is at a position. Answering "none" is the same world the port
     * generates, which has no structure manager at all.
     */
    private static StructureManager structureManager;

    private static RandomState randomState;
    private static LevelHeightAccessor structureBounds;

    public static void main(String[] args) throws Exception {
        if (args.length < 1) {
            System.err.println("usage: DecorationParityHarness <directory>");
            System.exit(2);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();
        bindTags();

        RegistryAccess.Frozen registries = datapackRegistries();
        ChunkGenerator generator = overworldGenerator(registries);
        Registry<Biome> biomeRegistry = registries.lookupOrThrow(Registries.BIOME);

        // Resolved back through the registry the level reads from. The biome source's own holders come
        // from the parameter list and are a different set of objects, so comparing them by identity
        // finds nothing in common and the pass silently decorates with no biomes at all. The order is
        // the source's, since that is what breaks a tie between two features nothing else orders.
        List<Holder<Biome>> possibleBiomes = new ArrayList<>();
        for (Holder<Biome> biome : generator.getBiomeSource().possibleBiomes()) {
            possibleBiomes.add(biomeRegistry.getOrThrow(biome.unwrapKey().orElseThrow()));
        }

        List<FeatureSorter.StepFeatureData> perStep = FeatureSorter.buildFeaturesPerStep(
            possibleBiomes, biome -> biome.value().getGenerationSettings().features(), true);

        Set<Holder<Biome>> possible = Set.copyOf(possibleBiomes);

        Registry<PlacedFeature> placed = registries.lookupOrThrow(Registries.PLACED_FEATURE);
        Map<PlacedFeature, String> names = new java.util.IdentityHashMap<>();
        placed.forEach(feature -> names.put(feature,
            placed.getResourceKey(feature).map(key -> key.identifier().toString()).orElse("?")));

        worst = System.getenv("PARITY_WORST");
        String named = System.getenv("PARITY_ATTRIBUTE");
        attributing = named != null;
        traced = System.getenv("PARITY_TRACE");
        Set<String> only = named == null ? Set.of() : Set.of(named.split(","));

        List<Path> scenes;
        try (Stream<Path> files = Files.list(Path.of(args[0]))) {
            scenes = files.filter(p -> p.getFileName().toString().endsWith(".bin.gz"))
                .filter(p -> only.isEmpty()
                    || only.contains(p.getFileName().toString().replace(".bin.gz", "")))
                .sorted().toList();
        }

        long agreed = 0;
        long deliberate = 0;
        long ourWrites = 0;
        long theirWrites = 0;
        int compared = 0;
        int skipped = 0;
        Map<String, Integer> unreplayable = new TreeMap<>();
        Map<String, Integer> byPair = new TreeMap<>();
        Map<String, Integer> byFeature = new TreeMap<>();
        Set<String> seenBiomes = new TreeSet<>();
        int allFeatures = 0;
        for (FeatureSorter.StepFeatureData data : perStep) {
            allFeatures += data.features().size();
        }

        for (Path path : scenes) {
            ParityScene scene = ParityScene.read(path);

            // A chunk the structure pass wrote into is only skipped when the dump recorded no
            // placements to replay, which is a dump taken before that section existed. With them the
            // structures are laid out and placed here exactly as vanilla interleaves them.
            if (scene.structureWrites > 0 && scene.placements.isEmpty()) {
                skipped++;
                continue;
            }

            if (System.getenv("PARITY_DEBUG") != null) {
                System.out.printf("scene %d,%d structureWrites=%d placements=%d%n",
                    scene.chunkX, scene.chunkZ, scene.structureWrites, scene.placements.size());
            }

            if (!scene.placements.isEmpty()) {
                buildStructureApparatus(registries, scene);
            }

            for (String biome : scene.biomeNames) {
                seenBiomes.add(biome);
            }

            StubLevel level = new StubLevel(scene, registries);

            try {
                decorate(level, scene, generator, registries, perStep, possible, names);
            } catch (Unreplayable e) {
                unreplayable.merge(e.getMessage(), 1, Integer::sum);
                continue;
            }

            compared++;

            for (int at = 0; at < scene.before.length; at++) {
                String was = scene.paletteNames[scene.before[at]];
                String ours = scene.paletteNames[scene.after[at]];
                String theirs = level.describe(level.getBlockState(positionOf(scene, at)));

                boolean weWrote = !ours.equals(was);
                boolean theyWrote = !theirs.equals(was);

                if (!weWrote && !theyWrote) {
                    continue;
                }

                if (weWrote) {
                    ourWrites++;
                }

                if (theyWrote) {
                    theirWrites++;
                }

                if (ours.equals(theirs)) {
                    agreed++;
                } else if (name(ours).equals(name(theirs)) && name(ours).endsWith("_leaves")) {
                    // The one divergence this build chose: vanilla's updateLeaves writes a distance
                    // its own scheduled tick then lowers, and with no tick scheduler the port settles
                    // to that fixed point in the pass instead. Counted apart so the headline number
                    // is differences nobody has explained.
                    deliberate++;
                } else {
                    // Both sides' last writer, because one alone cannot tell a feature that wrote
                    // where it should not have from one that wrote the same block a few positions
                    // over: a shift names the same feature on both sides and an extra names it on
                    // one.
                    Integer ourWriter = scene.ourWriter.get(at);
                    String mine = ourWriter == null ? "-" : scene.ourFeatures[ourWriter];
                    String theirs2 = level.writerOf(at);

                    // The block names, unless they are the same one: a pair reading "A -> A" is a
                    // state that differs rather than a block, and the properties are the whole of
                    // what it has to say.
                    byPair.merge(name(ours).equals(name(theirs))
                        ? ours + " -> " + theirs
                        : name(ours) + " -> " + name(theirs), 1, Integer::sum);
                    byFeature.merge(mine + " -> " + (theirs2 == null ? "-" : theirs2), 1,
                        Integer::sum);

                    if (worst != null && (worst.equals(mine) || worst.equals(theirs2))) {
                        byChunk.merge(scene.chunkX + "_" + scene.chunkZ, 1, Integer::sum);
                    }

                    if (traced != null && (traced.equals(mine) || traced.equals(theirs2))) {
                        BlockPos where = positionOf(scene, at);
                        System.out.printf("DIFF %d %d %d ours=%s(%s) vanilla=%s(%s)%n", where.getX(),
                            where.getY(), where.getZ(), ours, mine, theirs,
                            theirs2 == null ? "-" : theirs2);
                    }
                }
            }
        }

        long positions = Math.max(ourWrites, theirWrites);
        System.out.printf("%d chunks compared, %d skipped for structures, %d unreplayable%n",
            compared, skipped, unreplayable.values().stream().mapToInt(Integer::intValue).sum());
        unreplayable.forEach((what, count) ->
            System.out.printf("  %d chunks hold a feature needing %s%n", count, what));
        System.out.printf("decoration writes: ours %d, vanilla %d, identical %d, "
            + "leaf distance settled deliberately %d%n", ourWrites, theirWrites, agreed, deliberate);
        System.out.printf("PARITY %.3f%%%n",
            positions == 0 ? 100.0 : (agreed + deliberate) * 100.0 / positions);

        System.out.printf("coverage: %d of %d biomes, %d of %d placed features wrote something%n",
            seenBiomes.size(), possibleBiomes.size(), ranFeatures.size(), allFeatures);

        // A structure is about one chunk in a hundred, so a sample drawn at random reaches almost
        // none of them and the ones it did reach is the whole of what the structure half is worth.
        int allStructures = registries.lookupOrThrow(Registries.STRUCTURE).size();
        System.out.printf("structures: %d of %d placed%n", ranStructures.size(), allStructures);

        if (!ranStructures.isEmpty()) {
            System.out.println("structures placed: " + ranStructures);
        }

        List<String> missedBiomes = new ArrayList<>();
        for (Holder<Biome> biome : possibleBiomes) {
            String name = biome.unwrapKey().orElseThrow().identifier().toString();
            if (!seenBiomes.contains(name)) {
                missedBiomes.add(name);
            }
        }
        System.out.println("biomes never seen: " + missedBiomes);

        List<String> missedFeatures = new ArrayList<>();
        for (FeatureSorter.StepFeatureData data : perStep) {
            for (PlacedFeature feature : data.features()) {
                String name = names.getOrDefault(feature, "?");
                if (feature != null && !ranFeatures.contains(name)) {
                    missedFeatures.add(name);
                }
            }
        }
        System.out.println("features that never wrote: " + missedFeatures);

        // Which feature wrote each differing position, this build's then vanilla's. That is the work
        // queue: the same name either side is a feature landing in the wrong place, and a dash is a
        // feature that wrote where the other wrote nothing at all.
        System.out.println("by feature:");
        byFeature.entrySet().stream()
            .sorted((a, b) -> b.getValue() - a.getValue())
            .limit(25)
            .forEach(entry -> System.out.printf("  %8d  %s%n", entry.getValue(), entry.getKey()));

        // Which chunks a named feature disagrees most in, so a trace has somewhere to start: the
        // per feature totals say what is wrong and not where to look at it.
        if (worst != null) {
            System.out.println("worst chunks for " + worst + ":");
            byChunk.entrySet().stream()
                .sorted((a, b) -> b.getValue() - a.getValue())
                .limit(10)
                .forEach(entry -> System.out.printf("  %8d  %s%n", entry.getValue(), entry.getKey()));
        }

        System.out.println("by block:");
        byPair.entrySet().stream()
            .sorted((a, b) -> b.getValue() - a.getValue())
            .limit(15)
            .forEach(entry -> System.out.printf("  %8d  %s%n", entry.getValue(), entry.getKey()));
    }

    /**
     * {@code ChunkGenerator.applyBiomeDecoration}, without the structures.
     *
     * <p>The structure loop is left out and its index counter with it, which changes no feature seed:
     * a feature is seeded from its <b>own</b> index in the global list for its step, and the structure
     * counter upstream is a separate variable that only structures read.
     */
    private static void decorate(StubLevel level, ParityScene scene, ChunkGenerator generator,
        RegistryAccess.Frozen registries, List<FeatureSorter.StepFeatureData> perStep,
        Set<Holder<Biome>> possibleBiomes, Map<PlacedFeature, String> names) {

        // Vanilla takes the union over the three by three and intersects it with what the biome source
        // can produce, where this build takes the chunk's own. Applying vanilla's rule here is what
        // makes that difference show up as a difference.
        Set<Holder<Biome>> present = new LinkedHashSet<>();
        for (int dx = -1; dx <= 1; dx++) {
            for (int dz = -1; dz <= 1; dz++) {
                present.addAll(level.biomesOf(dx, dz));
            }
        }

        present.retainAll(possibleBiomes);

        if (System.getenv("PARITY_DEBUG") != null) {
            System.out.println("biomes present " + present.size() + " of " + possibleBiomes.size()
                + " steps " + perStep.size());
        }

        if (attributing) {
            // Primes the diff with the state the scene starts in, under no writer at all, so the
            // first feature is not credited with the whole of the terrain.
            level.currentFeature = null;
            level.attribute();
        }

        WorldgenRandom random = new WorldgenRandom(new XoroshiroRandomSource(0L));
        currentRandom = random;
        long decorationSeed = random.setDecorationSeed(scene.seed, scene.chunkX << 4, scene.chunkZ << 4);
        BlockPos origin = new BlockPos(scene.chunkX << 4, 0, scene.chunkZ << 4);

        int steps = Math.max(DECORATION_STEPS, perStep.size());

        for (int step = 0; step < steps; step++) {
            // Before the step's own bounds test, since a structure step can be past the last one any
            // biome has features for.
            placeStructures(level, scene, generator, registries, step, random, decorationSeed);

            if (step >= perStep.size()) {
                continue;
            }

            FeatureSorter.StepFeatureData data = perStep.get(step);
            Set<Integer> wanted = new LinkedHashSet<>();

            for (Holder<Biome> biome : present) {
                List<HolderSet<PlacedFeature>> features = biome.value().getGenerationSettings().features();
                if (step < features.size()) {
                    features.get(step).stream()
                        .map(Holder::value)
                        .forEach(feature -> wanted.add(data.indexMapping().applyAsInt(feature)));
                }
            }

            int[] indices = wanted.stream().mapToInt(Integer::intValue).toArray();
            Arrays.sort(indices);

            for (int index : indices) {
                random.setFeatureSeed(decorationSeed, index, step);
                level.currentFeature = names.getOrDefault(data.features().get(index), "?");

                try {
                    if (level.currentFeature.equals(traced)) {
                        System.out.printf("TRACE chunk=%d,%d step=%d index=%d%n", scene.chunkX,
                            scene.chunkZ, step, index);
                        trace(data.features().get(index), level, generator, random, origin);
                    } else if (data.features().get(index)
                        .placeWithBiomeCheck(level, generator, random, origin)) {

                        // What the feature says it did, not what came through setBlock: an ore writes
                        // into a LevelChunkSection and the level never sees it.
                        ranFeatures.add(level.currentFeature);
                    }

                    if (attributing) {
                        level.attribute();
                    }

                } catch (UnsupportedOperationException e) {
                    // The stub cannot answer what this feature asked for, so nothing about this chunk
                    // can be compared: the feature has already consumed some of the shared random and
                    // everything after it is a different sequence. Reported rather than swallowed.
                    throw new Unreplayable(e.getMessage());
                }
            }
        }
    }

    /**
     * {@code PlacedFeature.placeWithContext} with a line printed per candidate, which is the same
     * shape the port prints under {@code FEATURE_LEVEL_DUMP}.
     * <p>
     * The chain is built out of lazy {@code flatMap} calls so that the whole tail of it runs for a
     * modifier's first position before its second exists, and every modifier draws from one shared
     * random. Walking the modifiers breadth first here would consume the same numbers in a different
     * order and trace a feature that is not the one that ran.
     */
    private static void trace(PlacedFeature feature, StubLevel level, ChunkGenerator generator,
        WorldgenRandom random, BlockPos origin) {

        PlacementContext context = new PlacementContext(level, generator, Optional.of(feature));
        Stream<BlockPos> positions = Stream.of(origin);

        // The biome filter is pulled off the end so that the positions it drops are printed too: a
        // divergence there shows up as the chain skipping a candidate, and the candidates on either
        // side of it look unrelated. It draws nothing and runs last, so taking it out and applying it
        // inside the walk leaves the order of every other draw alone.
        List<PlacementModifier> chain = feature.placement();
        boolean filtered = !chain.isEmpty()
            && chain.get(chain.size() - 1) instanceof PlacementFilter;

        for (PlacementModifier modifier : filtered ? chain.subList(0, chain.size() - 1) : chain) {
            Stream<BlockPos> sofar = positions;
            positions = sofar.flatMap(at -> modifier.getPositions(context, random, at))
                .peek(at -> System.out.printf("STAGE %s %d %d %d%n",
                    modifier.getClass().getSimpleName(), at.getX(), at.getY(), at.getZ()));
        }

        if (filtered) {
            PlacementFilter last = (PlacementFilter) chain.get(chain.size() - 1);
            positions = positions.filter(at -> {
                boolean keep = last.getPositions(context, random, at).findAny().isPresent();

                System.out.printf("FILTER %d %d %d %s %s keep=%s%n", at.getX(), at.getY(), at.getZ(),
                    name(level.describe(level.getBlockState(at))),
                    level.getBiome(at).unwrapKey().orElseThrow().identifier(), keep);

                return keep;
            });
        }

        ConfiguredFeature<?, ?> configured = feature.feature().value();

        positions.forEach(at -> {
            int before = random.getCount();
            boolean placed = configured.place(level, generator, random, at);

            System.out.printf("CAND %d %d %d placed=%s draws=%d%n", at.getX(), at.getY(), at.getZ(),
                placed, random.getCount() - before);
        });
    }

    /** The absolute position of a flat index into the scene's three by three. */
    private static BlockPos positionOf(ParityScene scene, int at) {
        int perChunk = scene.height * 256;
        int chunk = at / perChunk;
        int rest = at % perChunk;

        return new BlockPos(((scene.chunkX + chunk / 3 - 1) << 4) + rest % 16,
            scene.minY + rest / 256, ((scene.chunkZ + chunk % 3 - 1) << 4) + rest / 16 % 16);
    }

    private static String name(String state) {
        int bracket = state.indexOf('[');
        return bracket < 0 ? state : state.substring(0, bracket);
    }

    /**
     * Places every structure start the scene recorded for one decoration step.
     *
     * <p>Vanilla interleaves the two passes: {@code applyBiomeDecoration} places every structure of a
     * step and then every feature of it, so this runs at the top of each step exactly as the port's
     * own hook does. Getting that order wrong is not subtle: a feature judges the block already there,
     * so a monument placed after the vegetation has trees growing inside it.
     *
     * <p><b>Which starts reach the chunk is taken from the dump, not recomputed.</b> That is what
     * keeps this measuring the one thing nothing else does, which is what a piece <b>writes</b>. Where
     * a start sits and what pieces it is made of is pinned separately and exactly by
     * {@code structurelayout.sh}, over 8185 pieces the real server laid out; re-deriving it here would
     * measure that again and would need the structure set placement, the ring search and a
     * {@code StructureCheck}, every one of which is a way for the harness to be wrong.
     *
     * <p>The random is seeded once per <b>structure type</b> rather than per start, because vanilla
     * sets the feature seed in the loop over the step's structures and then places every start of that
     * one from the sequence that follows. Two halves of a temple across a border draw from one
     * sequence, and reseeding between them would be a different building.
     */
    private static void placeStructures(StubLevel level, ParityScene scene, ChunkGenerator generator,
        RegistryAccess.Frozen registries, int step, WorldgenRandom random, long decorationSeed) {

        int seeded = Integer.MIN_VALUE;

        for (ParityScene.Placement placement : scene.placements) {
            if (placement.step() != step) {
                continue;
            }

            // The index is used rather than derived, so it is checked instead. Vanilla groups the
            // structure registry by step and seeds the nth of a step with n, and the registry's own
            // order is the order the pack's directory was read in. Getting it wrong moves every
            // structure of that step onto another one's sequence, which no comparison of the blocks
            // could tell from the pieces themselves being wrong.
            List<String> vanillaOrder = structuresByStep(registries).get(step);
            String expected = vanillaOrder == null || placement.index() >= vanillaOrder.size()
                ? null
                : vanillaOrder.get(placement.index());

            if (!placement.id().equals(expected)) {
                throw new Unreplayable("structure " + placement.id() + " was seeded as index "
                    + placement.index() + " of step " + step + ", where vanilla has " + expected);
            }

            // Once per structure type rather than per start, because vanilla sets the feature seed in
            // the loop over the step's structures and places every start of that one from the
            // sequence that follows.
            if (placement.index() != seeded) {
                random.setFeatureSeed(decorationSeed, placement.index(), step);
                seeded = placement.index();
            }

            ResourceKey<Structure> key = ResourceKey.create(Registries.STRUCTURE,
                Identifier.parse(placement.id()));
            Holder<Structure> structure = registries.lookupOrThrow(Registries.STRUCTURE).getOrThrow(key);

            StructureStart start = structure.value().generate(structure, Level.OVERWORLD, registries,
                generator, generator.getBiomeSource(), randomState, templates, scene.seed,
                new ChunkPos(placement.sourceChunkX(), placement.sourceChunkZ()), 0, structureBounds,
                structure.value().biomes()::contains);

            if (!start.isValid()) {
                throw new Unreplayable("vanilla declined a start this build placed: " + placement.id());
            }

            ranStructures.add(placement.id());
            level.currentFeature = placement.id();

            // Where vanilla put the start, so a structure that differs can be told apart into a
            // layout that landed somewhere else and a placement that drew differently from there.
            if (System.getenv("PARITY_STARTS") != null) {
                System.out.printf("START %s source=%d,%d box=%s%n", placement.id(),
                    placement.sourceChunkX(), placement.sourceChunkZ(), start.getBoundingBox());
            }

            try {
                start.placeInChunk(level, structureManager, generator, random,
                    writableArea(scene), new ChunkPos(scene.chunkX, scene.chunkZ));
            } catch (UnsupportedOperationException e) {
                // The stub cannot answer what this piece asked for, so nothing about this chunk can
                // be compared: the piece has already drawn from the shared random and everything
                // after it is a different sequence. A mineshaft corridor's chest is the one that
                // reaches this, because it spawns a chest minecart and an entity wants a ServerLevel.
                throw new Unreplayable(placement.id() + " needs " + e.getMessage());
            }
        }
    }

    /** Vanilla's own per step structure order, which is what its index within a step means. */
    private static Map<Integer, List<String>> structuresByStep;

    private static Map<Integer, List<String>> structuresByStep(RegistryAccess.Frozen registries) {
        if (structuresByStep != null) {
            return structuresByStep;
        }

        structuresByStep = new TreeMap<>();
        Registry<Structure> registry = registries.lookupOrThrow(Registries.STRUCTURE);

        // The registry's own iteration order, which is what applyBiomeDecoration groups by step.
        registry.forEach(structure -> structuresByStep
            .computeIfAbsent(structure.step().ordinal(), step -> new ArrayList<>())
            .add(registry.getResourceKey(structure).orElseThrow().identifier().toString()));

        return structuresByStep;
    }

    /**
     * {@code ChunkGenerator.getWritableArea}: the column a structure may write into.
     *
     * <p>The bottom row is <b>excluded</b>, since it starts at {@code getMinY() + 1}, which is what
     * stops a structure taking the bedrock floor out.
     */
    private static BoundingBox writableArea(ParityScene scene) {
        int x = scene.chunkX << 4;
        int z = scene.chunkZ << 4;
        return new BoundingBox(x, scene.minY + 1, z, x + 15, scene.minY + scene.height - 1, z + 15);
    }

    /**
     * The vanilla structure apparatus, built on the first scene that recorded a placement.
     *
     * <p>The template manager wants somewhere to look for a world's own saved structures, which is a
     * path it only reads when asked for one by that name and no vanilla structure is. A real
     * {@code LevelStorageAccess} over a scratch directory is cheaper than a stub, since the
     * constructor dereferences it.
     */
    private static void buildStructureApparatus(RegistryAccess.Frozen registries, ParityScene scene)
        throws Exception {

        if (templates != null) {
            return;
        }

        MultiPackResourceManager resources = new MultiPackResourceManager(
            PackType.SERVER_DATA, List.of(ServerPacksSource.createVanillaPackSource()));

        Path scratch = Files.createTempDirectory("mcdotnet-structure-parity");

        templates = new StructureTemplateManager(resources,
            LevelStorageSource.createDefault(scratch).createAccess("parity"),
            DataFixers.getDataFixer(), registries.lookupOrThrow(Registries.BLOCK));

        structureManager = new NoStructures();

        randomState = RandomState.create(
            registries.lookupOrThrow(Registries.NOISE_SETTINGS)
                .getOrThrow(NoiseGeneratorSettings.OVERWORLD).value(),
            registries.lookupOrThrow(Registries.NOISE), scene.seed);

        int minY = scene.minY;
        int height = scene.height;

        structureBounds = new LevelHeightAccessor() {
            public int getHeight() {
                return height;
            }

            public int getMinY() {
                return minY;
            }
        };
    }

    /** A structure manager that answers no starts, which is the world this build generates. */
    private static final class NoStructures extends StructureManager {
        NoStructures() {
            super(null, null, null);
        }

        @Override
        public List<StructureStart> startsForStructure(ChunkPos chunk,
            java.util.function.Predicate<Structure> wanted) {

            return List.of();
        }
    }

    private static ChunkGenerator overworldGenerator(RegistryAccess.Frozen registries) {
        HolderLookup.RegistryLookup<MultiNoiseBiomeSourceParameterList> lists =
            registries.lookupOrThrow(Registries.MULTI_NOISE_BIOME_SOURCE_PARAMETER_LIST);
        HolderLookup.RegistryLookup<NoiseGeneratorSettings> settings =
            registries.lookupOrThrow(Registries.NOISE_SETTINGS);

        BiomeSource biomes = MultiNoiseBiomeSource.createFromPreset(
            lists.getOrThrow(MultiNoiseBiomeSourceParameterLists.OVERWORLD));

        return new NoiseBasedChunkGenerator(biomes, settings.getOrThrow(NoiseGeneratorSettings.OVERWORLD));
    }

    /**
     * Loads the block tags onto the built in registries.
     *
     * <p><b>Without this the harness lies.</b> Every {@code state.is(BlockTags.X)} answers false with
     * the tags unbound, so a sapling survives nowhere, every candidate is filtered out before its
     * feature runs, and the parity comes out near zero with nothing thrown to say why.
     */
    /**
     * The worldgen registries as a server builds them: decoded from the vanilla data pack's JSON,
     * not taken from {@code VanillaRegistries}' bootstrap objects.
     *
     * <p><b>The two are not the same, and the pack is the one that generates worlds.</b> A worldgen
     * registry reaches a running server only through {@code RegistryDataLoader}, which reads the
     * pack, so a datapack can replace any of it. The bootstrap objects are what the data generator
     * encodes to produce that pack, and the encode is lossy wherever a codec's {@code forGetter}
     * names the wrong field: {@code CherryFoliagePlacer}'s {@code corner_hole_chance} reads
     * {@code wideBottomLayerHoleChance}, so the shipped {@code cherry.json} says 0.25 where the
     * bootstrap object holds 0.5, and every cherry tree a server grows uses the 0.25.
     *
     * <p>Building this from the bootstrap objects instead measures the port against a configuration
     * no world is ever generated with.
     */
    private static RegistryAccess.Frozen datapackRegistries() {
        MultiPackResourceManager resources = new MultiPackResourceManager(
            PackType.SERVER_DATA, List.of(ServerPacksSource.createVanillaPackSource()));

        RegistryAccess.Frozen statik = RegistryLayer.createRegistryAccess().compositeAccess();

        List<HolderLookup.RegistryLookup<?>> lookups = new ArrayList<>();
        statik.registries().forEach(entry ->
            lookups.add((HolderLookup.RegistryLookup<?>) entry.value()));

        RegistryAccess.Frozen worldgen = RegistryDataLoader
            .load(resources, lookups, RegistryDataLoader.WORLDGEN_REGISTRIES, Runnable::run)
            .join();

        List<Registry<?>> all = new ArrayList<>();
        statik.registries().forEach(entry -> all.add(entry.value()));
        worldgen.registries().forEach(entry -> all.add(entry.value()));

        RegistryAccess.Frozen combined = new RegistryAccess.ImmutableRegistryAccess(all).freeze();

        // An item's default components are data driven, and anything that builds an ItemStack walks
        // them. A trial chamber's vault is the caller that notices: its block entity holds a stack,
        // so placing one throws "Components not bound yet" rather than answering anything.
        BuiltInRegistries.DATA_COMPONENT_INITIALIZERS.build(combined)
            .forEach(net.minecraft.core.component.DataComponentInitializers.PendingComponents::apply);

        return combined;
    }

    private static void bindTags() {
        MultiPackResourceManager resources = new MultiPackResourceManager(
            PackType.SERVER_DATA, List.of(ServerPacksSource.createVanillaPackSource()));

        TagLoader.loadTagsForExistingRegistries(resources,
                RegistryAccess.fromRegistryOfRegistries(BuiltInRegistries.REGISTRY))
            .forEach(Registry.PendingTags::apply);
    }

    /** A feature the stub level cannot serve, which makes its whole chunk incomparable. */
    private static final class Unreplayable extends RuntimeException {
        Unreplayable(String what) {
            super(what);
        }
    }

    /**
     * The random the decoration loop is drawing from, so a write can be logged with the draw count
     * that produced it. That count is the only way to see inside a feature from out here: the phases
     * of a tree are hundreds of draws apart, so the count at its first vine says how many the trunk
     * and foliage took.
     */
    static WorldgenRandom currentRandom;

    private DecorationParityHarness() {
    }

    /** A {@link WorldgenRandom} that prints every bit draw, for diffing against the port's. */
}
