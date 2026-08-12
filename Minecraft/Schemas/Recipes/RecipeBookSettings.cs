namespace Minecraft.Schemas.Recipes;

/// <summary>
/// Which recipe book tabs the player has open, and whether each is filtering to recipes they can
/// currently craft. The client keeps this across sessions, so the server sends it back on join.
/// </summary>
/// <param name="Crafting">The crafting table's book.</param>
/// <param name="Furnace">The furnace's book.</param>
/// <param name="BlastFurnace">The blast furnace's book.</param>
/// <param name="Smoker">The smoker's book.</param>
public record RecipeBookSettings(
    RecipeBookSettings.TypeSettings Crafting,
    RecipeBookSettings.TypeSettings Furnace,
    RecipeBookSettings.TypeSettings BlastFurnace,
    RecipeBookSettings.TypeSettings Smoker) : IWritable {

    public static readonly RecipeBookSettings Default = new(
        TypeSettings.Default, TypeSettings.Default, TypeSettings.Default, TypeSettings.Default);

    public void Write(DataWriter w) {
        Crafting.Write(w);
        Furnace.Write(w);
        BlastFurnace.Write(w);
        Smoker.Write(w);
    }

    public static RecipeBookSettings Read(DataReader r) {
        return new RecipeBookSettings(
            TypeSettings.Read(r),
            TypeSettings.Read(r),
            TypeSettings.Read(r),
            TypeSettings.Read(r));
    }

    /// <param name="Open">Whether the book is showing.</param>
    /// <param name="Filtering">Whether it is hiding recipes the player can't craft right now.</param>
    public record TypeSettings(bool Open, bool Filtering) {
        public static readonly TypeSettings Default = new(false, false);

        public void Write(DataWriter w) {
            w.WriteBoolean(Open).WriteBoolean(Filtering);
        }

        public static TypeSettings Read(DataReader r) {
            return new TypeSettings(r.ReadBoolean(), r.ReadBoolean());
        }
    }
}
