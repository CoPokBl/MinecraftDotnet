using Minecraft.Data;
using Minecraft.Registry;

namespace Minecraft.Schemas.Recipes;

/// <summary>
/// How one recipe is drawn in the recipe book. This is a presentation of a recipe rather than the
/// recipe itself; the server keeps the real recipes and only sends what the book needs to draw.
/// </summary>
public abstract record RecipeDisplay : INetworkType<RecipeDisplay> {
    /// <summary>Key of this kind in the recipe display registry.</summary>
    public abstract Identifier Type { get; }

    /// <summary>What the recipe produces.</summary>
    public abstract SlotDisplay Result { get; }

    /// <summary>The block the recipe is made at, drawn beside it in the book.</summary>
    public abstract SlotDisplay CraftingStation { get; }

    protected abstract void WriteContents(DataWriter w, MinecraftRegistry reg);

    public DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        w.WriteVarInt(reg.RecipeDisplayTypes.GetProtocolId(Type));
        WriteContents(w, reg);
        return w;
    }

    public static RecipeDisplay ReadData(DataReader r, MinecraftRegistry reg) {
        Identifier type = reg.RecipeDisplayTypes[r.ReadVarInt()].Identifier;
        return type.ToString() switch {
            "minecraft:crafting_shapeless" => new ShapelessCrafting(
                r.ReadPrefixedArray<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg)),

            "minecraft:crafting_shaped" => new ShapedCrafting(
                r.ReadVarInt(),
                r.ReadVarInt(),
                r.ReadPrefixedArray<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg)),

            "minecraft:furnace" => new Furnace(
                r.Read<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg),
                r.ReadVarInt(),
                r.ReadFloat()),

            "minecraft:stonecutter" => new Stonecutter(
                r.Read<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg)),

            "minecraft:smithing" => new Smithing(
                r.Read<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg),
                r.Read<SlotDisplay>(reg)),

            _ => throw new ArgumentException($"Unknown recipe display type {type}", nameof(r))
        };
    }

    public record ShapelessCrafting(SlotDisplay[] Ingredients, SlotDisplay Result, SlotDisplay CraftingStation)
        : RecipeDisplay {
        public override Identifier Type => "minecraft:crafting_shapeless";
        public override SlotDisplay Result { get; } = Result;
        public override SlotDisplay CraftingStation { get; } = CraftingStation;

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.WritePrefixedArray(Ingredients, reg)
                .Write(Result, reg)
                .Write(CraftingStation, reg);
        }
    }

    /// <param name="Ingredients">The grid read in rows, <paramref name="Width"/> entries per row.</param>
    public record ShapedCrafting(
        int Width,
        int Height,
        SlotDisplay[] Ingredients,
        SlotDisplay Result,
        SlotDisplay CraftingStation) : RecipeDisplay {
        public override Identifier Type => "minecraft:crafting_shaped";
        public override SlotDisplay Result { get; } = Result;
        public override SlotDisplay CraftingStation { get; } = CraftingStation;

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.WriteVarInt(Width)
                .WriteVarInt(Height)
                .WritePrefixedArray(Ingredients, reg)
                .Write(Result, reg)
                .Write(CraftingStation, reg);
        }
    }

    /// <param name="Duration">How many ticks the recipe takes to smelt.</param>
    public record Furnace(
        SlotDisplay Ingredient,
        SlotDisplay Fuel,
        SlotDisplay Result,
        SlotDisplay CraftingStation,
        int Duration,
        float Experience) : RecipeDisplay {
        public override Identifier Type => "minecraft:furnace";
        public override SlotDisplay Result { get; } = Result;
        public override SlotDisplay CraftingStation { get; } = CraftingStation;

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.Write(Ingredient, reg)
                .Write(Fuel, reg)
                .Write(Result, reg)
                .Write(CraftingStation, reg)
                .WriteVarInt(Duration)
                .WriteFloat(Experience);
        }
    }

    public record Stonecutter(SlotDisplay Input, SlotDisplay Result, SlotDisplay CraftingStation) : RecipeDisplay {
        public override Identifier Type => "minecraft:stonecutter";
        public override SlotDisplay Result { get; } = Result;
        public override SlotDisplay CraftingStation { get; } = CraftingStation;

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.Write(Input, reg)
                .Write(Result, reg)
                .Write(CraftingStation, reg);
        }
    }

    public record Smithing(
        SlotDisplay Template,
        SlotDisplay Base,
        SlotDisplay Addition,
        SlotDisplay Result,
        SlotDisplay CraftingStation) : RecipeDisplay {
        public override Identifier Type => "minecraft:smithing";
        public override SlotDisplay Result { get; } = Result;
        public override SlotDisplay CraftingStation { get; } = CraftingStation;

        protected override void WriteContents(DataWriter w, MinecraftRegistry reg) {
            w.Write(Template, reg)
                .Write(Base, reg)
                .Write(Addition, reg)
                .Write(Result, reg)
                .Write(CraftingStation, reg);
        }
    }
}
