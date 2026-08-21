import java.io.DataOutputStream;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.SortedMap;
import java.util.TreeMap;
import java.util.zip.GZIPOutputStream;

import com.mojang.serialization.JsonOps;

import net.minecraft.SharedConstants;
import net.minecraft.core.Holder;
import net.minecraft.core.HolderLookup;
import net.minecraft.core.Registry;
import net.minecraft.core.RegistryAccess;
import net.minecraft.core.component.DataComponentInitializers;
import net.minecraft.core.registries.BuiltInRegistries;
import net.minecraft.core.registries.Registries;
import net.minecraft.data.registries.VanillaRegistries;
import net.minecraft.resources.Identifier;
import net.minecraft.server.Bootstrap;
import net.minecraft.server.packs.PackType;
import net.minecraft.server.packs.repository.ServerPacksSource;
import net.minecraft.server.packs.resources.MultiPackResourceManager;
import net.minecraft.server.packs.resources.SimpleJsonResourceReloadListener;
import net.minecraft.tags.TagLoader;
import net.minecraft.world.item.Item;
import net.minecraft.world.item.ItemStack;
import net.minecraft.world.item.ItemStackTemplate;
import net.minecraft.world.entity.player.StackedContents;
import net.minecraft.world.item.crafting.CraftingInput;
import net.minecraft.world.item.crafting.Ingredient;
import net.minecraft.world.item.crafting.Recipe;
import net.minecraft.world.item.crafting.ShapedRecipe;
import net.minecraft.world.item.crafting.ShapelessRecipe;
import net.minecraft.world.item.crafting.TransmuteRecipe;

/**
 * Runs the game's own crafting matcher over a corpus of grids and commits which recipe it picked and
 * what that recipe assembled.
 * <p>
 * Pins {@code shrink}, the horizontal mirror and {@code Util.isSymmetrical} deciding when to skip it,
 * {@code StackedContents}, and the <b>order</b> recipes are tried in ({@code TreeMap} over ids, and
 * {@code Identifier.compareTo} sorts on the path before the namespace). Not the parse, on
 * {@code LootTableParser}'s reasoning: the JSON is the source both sides read.
 * <p>
 * <b>Scope: the three recipe types the port implements.</b> Both sides filter to shaped, shapeless
 * and transmute. The special types are a gap already recorded in
 * {@code DatapackCraftingRecipes.Declined}; including them would need a {@code Level}.
 * <p>
 * A result carrying data components is in scope, so the suspicious stews are among the recipes a
 * grid can match here. That is the whole of what their component changes: two stews are one recipe
 * to the matcher and differ only in what the result carries.
 * <p>
 * The corpus is derived from the recipes themselves, so it hits every real shape, and every grid is
 * written into the fixture as the items it holds rather than as a description of it.
 * <p>
 * The smithing trim recipes log a parse error on the way past: their template names the
 * {@code trim_pattern} dynamic registry, which is not loaded here. They are not crafting recipes.
 * <p>
 * Compiled and run by Conformance/crafting.sh.
 */
public final class CraftingHarness {
    /** What a perturbed grid gets in place of one of its real ingredients. */
    private static final Identifier FOREIGN = Identifier.withDefaultNamespace("bedrock");

    public static void main(String[] args) throws Exception {
        if (args.length != 1) {
            System.err.println("Usage: CraftingHarness <output-file>");
            System.exit(1);
        }

        SharedConstants.tryDetectVersion();
        Bootstrap.bootStrap();

        MultiPackResourceManager resources = new MultiPackResourceManager(PackType.SERVER_DATA,
                List.of(ServerPacksSource.createVanillaPackSource()));

        // Item tags, or every "#minecraft:planks" parses to an empty set. Item components, or
        // ItemStack's constructor throws.
        RegistryAccess registries = RegistryAccess.fromRegistryOfRegistries(BuiltInRegistries.REGISTRY);
        TagLoader.loadTagsForExistingRegistries(resources, registries)
                .forEach(Registry.PendingTags::apply);
        BuiltInRegistries.DATA_COMPONENT_INITIALIZERS.build(VanillaRegistries.createLookup())
                .forEach(DataComponentInitializers.PendingComponents::apply);

        List<Loaded> recipes = load(resources, registries);
        List<Case> corpus = corpus(recipes);
        List<Matcher> matchers = matchers();

        try (OutputStream raw = Files.newOutputStream(Path.of(args[0]));
             GZIPOutputStream zipped = new GZIPOutputStream(raw);
             DataOutputStream out = new DataOutputStream(zipped)) {
            write(out, recipes, corpus, matchers, remainders());
        }

        long matched = corpus.stream().filter(c -> c.recipe != null).count();
        System.out.println("crafting: " + recipes.size() + " recipes, " + corpus.size()
                + " grids, " + matched + " matched, " + matchers.size() + " matcher cases, "
                + remainders().size() + " remainders");
    }

    // ---------------------------------------------------------------- loading

    /** One recipe and its id, in the order {@code RecipeManager.prepare} builds them. */
    private record Loaded(Identifier id, Recipe<CraftingInput> recipe) {}

    /**
     * {@code RecipeManager.prepare}, cut down to the three types. The {@code TreeMap} is not an
     * incidental container: its order is the tie-break the whole fixture rests on.
     */
    @SuppressWarnings("unchecked")
    private static List<Loaded> load(MultiPackResourceManager resources, HolderLookup.Provider lookup) {
        SortedMap<Identifier, Recipe<?>> parsed = new TreeMap<>();
        SimpleJsonResourceReloadListener.scanDirectory(resources, Registries.RECIPE,
                lookup.createSerializationContext(JsonOps.INSTANCE), Recipe.CODEC, parsed);

        List<Loaded> result = new ArrayList<>();
        parsed.forEach((id, recipe) -> {
            if (recipe instanceof ShapedRecipe || recipe instanceof ShapelessRecipe
                    || recipe instanceof TransmuteRecipe) {

                result.add(new Loaded(id, (Recipe<CraftingInput>) recipe));
            }
        });

        if (result.isEmpty()) {
            throw new IllegalStateException("No crafting recipes loaded; check the tag binding above.");
        }

        return result;
    }

    // ---------------------------------------------------------------- corpus

    /** One grid and what vanilla made of it. */
    private record Case(int width, int height, Identifier[] items, Identifier recipe, Identifier result,
            int resultCount) {}

    private static List<Case> corpus(List<Loaded> recipes) {
        List<Case> cases = new ArrayList<>();

        for (Loaded loaded : recipes) {
            for (Identifier[] grid : grids(loaded.recipe)) {
                cases.add(answer(recipes, 3, 3, grid));

                // The same arrangement in the player's own two by two, when it fits. Catches a
                // shrink that crops the wrong way.
                Identifier[] small = toSmall(grid);
                if (small != null) {
                    cases.add(answer(recipes, 2, 2, small));
                }
            }
        }

        return cases;
    }

    /** What the recipe should make, that pushed into the corner, its mirror, and one cell replaced. */
    private static List<Identifier[]> grids(Recipe<CraftingInput> recipe) {
        List<Identifier[]> result = new ArrayList<>();
        Identifier[] canonical;

        if (recipe instanceof ShapedRecipe shaped) {
            int width = shaped.getWidth();
            int height = shaped.getHeight();
            canonical = new Identifier[9];
            List<Optional<Ingredient>> ingredients = shaped.getIngredients();

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    canonical[x + y * 3] = first(ingredients.get(x + y * width).orElse(null));
                }
            }

            result.add(canonical);
            result.add(shift(canonical, 3 - width, 3 - height));
            result.add(mirror(canonical, width, height));
        } else {
            List<Ingredient> ingredients = recipe.placementInfo().ingredients();
            canonical = new Identifier[9];

            for (int i = 0; i < ingredients.size() && i < 9; i++) {
                canonical[i] = first(ingredients.get(i));
            }

            result.add(canonical);

            // Shapeless recipes do not care where items sit, so spread the bag out rather than move it.
            Identifier[] spread = new Identifier[9];
            int cell = 0;
            for (int i = 0; i < ingredients.size() && i < 5; i++) {
                spread[cell] = first(ingredients.get(i));
                cell += 2;
            }
            result.add(spread);
        }

        result.add(perturb(canonical));
        return result;
    }

    /** The lowest named item an ingredient accepts, so the corpus is the same on every run. */
    private static Identifier first(Ingredient ingredient) {
        if (ingredient == null) {
            return null;
        }

        return ingredient.items()
                .map(holder -> BuiltInRegistries.ITEM.getKey(holder.value()))
                .min(Comparator.comparing(Identifier::toString))
                .orElse(null);
    }

    private static Identifier[] shift(Identifier[] grid, int dx, int dy) {
        Identifier[] result = new Identifier[9];

        for (int y = 0; y < 3; y++) {
            for (int x = 0; x < 3; x++) {
                if (grid[x + y * 3] == null || x + dx > 2 || y + dy > 2) {
                    continue;
                }

                result[x + dx + (y + dy) * 3] = grid[x + y * 3];
            }
        }

        return result;
    }

    private static Identifier[] mirror(Identifier[] grid, int width, int height) {
        Identifier[] result = new Identifier[9];

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                result[width - 1 - x + y * 3] = grid[x + y * 3];
            }
        }

        return result;
    }

    /** The grid with its first occupied cell replaced, which should stop most recipes matching. */
    private static Identifier[] perturb(Identifier[] grid) {
        Identifier[] result = grid.clone();

        for (int cell = 0; cell < 9; cell++) {
            if (result[cell] != null) {
                result[cell] = FOREIGN;
                return result;
            }
        }

        result[0] = FOREIGN;
        return result;
    }

    /** The top left two by two of a grid, or null if anything is outside it. */
    private static Identifier[] toSmall(Identifier[] grid) {
        for (int cell = 0; cell < 9; cell++) {
            if (grid[cell] != null && (cell % 3 == 2 || cell / 3 == 2)) {
                return null;
            }
        }

        return new Identifier[] { grid[0], grid[1], grid[3], grid[4] };
    }

    // ---------------------------------------------------------------- crafting remainders

    /** One item and what it leaves behind when a recipe spends it. */
    private record Remainder(Identifier item, Identifier leaves, int count) {}

    /**
     * Every item whose {@code getCraftingRemainder} is not null, which is the whole of the port's hand
     * written {@code CraftingRemainders} table. The value is an {@code Item.Properties} constructor
     * argument, so no generator here can see it; this is the backstop.
     */
    private static List<Remainder> remainders() {
        List<Remainder> result = new ArrayList<>();

        for (Item item : BuiltInRegistries.ITEM) {
            ItemStackTemplate remainder = item.getCraftingRemainder();

            if (remainder != null) {
                ItemStack stack = remainder.create();
                result.add(new Remainder(BuiltInRegistries.ITEM.getKey(item),
                        BuiltInRegistries.ITEM.getKey(stack.getItem()), stack.getCount()));
            }
        }

        return result;
    }

    // ---------------------------------------------------------------- the matcher on its own

    /** One question put straight to {@code StackedContents}, and the answer it gave. */
    private record Matcher(String name, List<List<Identifier>> ingredients, List<Identifier> available,
            List<Integer> counts, int capacity, boolean answer) {}

    /**
     * Cases for {@code StackedContents.tryPick} built by hand, because <b>the recipe corpus cannot
     * reach the case the algorithm exists for</b>. Measured, not assumed: no vanilla shapeless or
     * transmute recipe has two ingredients whose item sets overlap without being equal, so a greedy
     * matcher agrees with the real one on every vanilla grid. Answers still come from the game's own
     * {@code StackedContents} rather than from a second opinion.
     */
    private static List<Matcher> matchers() {
        Identifier a = Identifier.withDefaultNamespace("stone");
        Identifier b = Identifier.withDefaultNamespace("dirt");
        Identifier c = Identifier.withDefaultNamespace("oak_planks");
        Identifier d = Identifier.withDefaultNamespace("cobblestone");

        List<Matcher> cases = new ArrayList<>();

        // The trap, both ways round: the wide ingredient must give up the item the narrow one is the
        // only taker of. A greedy pass in either order gets one of these wrong.
        cases.add(matcher("wide then narrow", List.of(List.of(a, b), List.of(a)),
                List.of(a, b), List.of(1, 1), 1));
        cases.add(matcher("narrow then wide", List.of(List.of(a), List.of(a, b)),
                List.of(a, b), List.of(1, 1), 1));

        // One item short, so a merely permissive matcher fails here.
        cases.add(matcher("wide and narrow, one item", List.of(List.of(a, b), List.of(a)),
                List.of(a), List.of(2), 1));

        // An augmenting path more than one step long.
        cases.add(matcher("three deep", List.of(List.of(a, b, c), List.of(a, b), List.of(a)),
                List.of(a, b, c), List.of(1, 1, 1), 1));
        cases.add(matcher("three deep, wrong item", List.of(List.of(a, b, c), List.of(a, b), List.of(a)),
                List.of(b, c), List.of(1, 2), 1));

        // A cycle: a perfect matching exists but no ingredient is forced.
        cases.add(matcher("cycle of four",
                List.of(List.of(a, b), List.of(b, c), List.of(c, d), List.of(d, a)),
                List.of(a, b, c, d), List.of(1, 1, 1, 1), 1));

        // More ingredients than distinct items, satisfiable only through the counts.
        cases.add(matcher("three from two", List.of(List.of(a, b), List.of(a, b), List.of(a, b)),
                List.of(a, b), List.of(1, 1), 1));
        cases.add(matcher("three from two, stocked", List.of(List.of(a, b), List.of(a, b), List.of(a, b)),
                List.of(a, b), List.of(2, 1), 1));

        // Capacity: how many of the recipe are asked for at once.
        cases.add(matcher("two at a time", List.of(List.of(a, b), List.of(a)),
                List.of(a, b), List.of(2, 2), 2));
        cases.add(matcher("two at a time, short", List.of(List.of(a, b), List.of(a)),
                List.of(a, b), List.of(2, 1), 2));
        cases.add(matcher("capacity zero", List.of(List.of(a)), List.of(), List.of(), 0));

        // Nothing available, and an ingredient nothing in stock satisfies.
        cases.add(matcher("empty stock", List.of(List.of(a)), List.of(), List.of(), 1));
        cases.add(matcher("wrong stock", List.of(List.of(a)), List.of(b), List.of(4), 1));

        return cases;
    }

    private static Matcher matcher(String name, List<List<Identifier>> ingredients,
            List<Identifier> available, List<Integer> counts, int capacity) {
        // StackedContents rather than StackedItemContents: the capacity taking canCraft is private
        // there, and capacity is half of what these cases are about.
        StackedContents<Holder<Item>> contents = new StackedContents<>();
        for (int i = 0; i < available.size(); i++) {
            contents.account(BuiltInRegistries.ITEM.get(available.get(i)).orElseThrow(), counts.get(i));
        }

        List<Ingredient> parsed = new ArrayList<>();
        for (List<Identifier> items : ingredients) {
            parsed.add(Ingredient.of(items.stream()
                    .map(id -> (Item) BuiltInRegistries.ITEM.get(id).orElseThrow().value())));
        }

        boolean answer = contents.tryPick(parsed, capacity, null);
        return new Matcher(name, ingredients, available, counts, capacity, answer);
    }

    // ---------------------------------------------------------------- answering

    /** {@code RecipeMap.getRecipesFor(...).findFirst()} over the three types, then {@code assemble}. */
    private static Case answer(List<Loaded> recipes, int width, int height, Identifier[] items) {
        List<ItemStack> stacks = new ArrayList<>(items.length);
        for (Identifier item : items) {
            stacks.add(item == null ? ItemStack.EMPTY : new ItemStack(BuiltInRegistries.ITEM.get(item).orElseThrow()));
        }

        CraftingInput input = CraftingInput.of(width, height, stacks);

        if (!input.isEmpty()) {
            for (Loaded loaded : recipes) {
                if (!loaded.recipe.matches(input, null)) {
                    continue;
                }

                ItemStack result = loaded.recipe.assemble(input);
                return new Case(width, height, items, loaded.id,
                        result.isEmpty() ? null : BuiltInRegistries.ITEM.getKey(result.getItem()),
                        result.getCount());
            }
        }

        return new Case(width, height, items, null, null, 0);
    }

    // ---------------------------------------------------------------- writing

    private static void write(DataOutputStream out, List<Loaded> recipes, List<Case> corpus,
            List<Matcher> matchers, List<Remainder> remainders) throws Exception {
        out.writeBytes("MCCRAFT1");

        // The recipe ids in play, so a fixture replayed against a different pack fails loudly.
        out.writeInt(recipes.size());
        for (Loaded loaded : recipes) {
            out.writeUTF(loaded.id.toString());
        }

        Map<Identifier, Integer> palette = new HashMap<>();
        List<Identifier> items = new ArrayList<>();
        for (Case c : corpus) {
            for (Identifier item : c.items) {
                if (item != null && palette.putIfAbsent(item, items.size()) == null) {
                    items.add(item);
                }
            }

            if (c.result != null && palette.putIfAbsent(c.result, items.size()) == null) {
                items.add(c.result);
            }
        }

        out.writeInt(items.size());
        for (Identifier item : items) {
            out.writeUTF(item.toString());
        }

        out.writeInt(corpus.size());
        for (Case c : corpus) {
            out.writeByte(c.width);
            out.writeByte(c.height);
            out.writeByte(c.items.length);
            for (Identifier item : c.items) {
                out.writeShort(item == null ? -1 : palette.get(item));
            }

            out.writeUTF(c.recipe == null ? "" : c.recipe.toString());
            out.writeShort(c.result == null ? -1 : palette.get(c.result));
            out.writeByte(c.resultCount);
        }

        out.writeInt(matchers.size());
        for (Matcher m : matchers) {
            out.writeUTF(m.name);
            out.writeByte(m.capacity);
            out.writeBoolean(m.answer);

            out.writeByte(m.ingredients.size());
            for (List<Identifier> ingredient : m.ingredients) {
                out.writeByte(ingredient.size());
                for (Identifier item : ingredient) {
                    out.writeUTF(item.toString());
                }
            }

            out.writeByte(m.available.size());
            for (int i = 0; i < m.available.size(); i++) {
                out.writeUTF(m.available.get(i).toString());
                out.writeByte(m.counts.get(i));
            }
        }

        out.writeInt(remainders.size());
        for (Remainder remainder : remainders) {
            out.writeUTF(remainder.item.toString());
            out.writeUTF(remainder.leaves.toString());
            out.writeByte(remainder.count);
        }
    }
}
