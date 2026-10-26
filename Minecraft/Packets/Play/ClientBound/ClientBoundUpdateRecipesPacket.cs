using Minecraft.Data.Items;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Recipes;
using Minecraft.Schemas.Tags;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Tells the client which items each recipe-driven screen accepts, so it can grey out slots
/// without knowing the recipes themselves.
/// </summary>
public class ClientBoundUpdateRecipesPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:update_recipes";

    /// <summary>
    /// Accepted inputs per property set, keyed by names such as <c>minecraft:furnace_input</c>
    /// and <c>minecraft:smithing_base</c>.
    /// </summary>
    public required Dictionary<Identifier, IItem[]> ItemSets { get; init; }

    /// <summary>Every stonecutter recipe, since the client draws the whole list of outputs.</summary>
    public required StonecutterRecipe[] StonecutterRecipes { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        w.WriteVarInt(ItemSets.Count);
        foreach ((Identifier name, IItem[] items) in ItemSets) {
            w.Write(name)
                .WritePrefixedArray(items, (item, writer) => writer.WriteVarInt(reg.Items.GetProtocolId(item)));
        }

        return w.WritePrefixedArray(StonecutterRecipes, (recipe, writer) => writer
            .Write(recipe.Input, reg)
            .Write(recipe.Result, reg));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => {
        int setCount = r.ReadVarInt();
        Dictionary<Identifier, IItem[]> itemSets = new(setCount);
        for (int i = 0; i < setCount; i++) {
            Identifier name = r.ReadString();
            itemSets.Add(name, r.ReadPrefixedArray(reader => reg.Items[reader.ReadVarInt()]));
        }

        return new ClientBoundUpdateRecipesPacket {
            ItemSets = itemSets,
            StonecutterRecipes = r.ReadPrefixedArray(reader => new StonecutterRecipe(
                reader.Read<IdSet>(reg),
                reader.Read<SlotDisplay>(reg)))
        };
    };

    /// <param name="Input">The items the recipe can be made from.</param>
    /// <param name="Result">What the recipe produces, as drawn in the stonecutter's list.</param>
    public record StonecutterRecipe(IdSet Input, SlotDisplay Result);
}
