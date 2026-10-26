using Minecraft;
using Minecraft.Data.BlockTransformer;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using NBT;
using NBT.Tags;

namespace ClientLib.Interaction;

/// <summary>
/// <c>BlockTransformer.transformBlock</c>'s search, over the transformers the server synchronised: the
/// first entry the clicked face allows whose provider has a state for the clicked block.
/// </summary>
/// <remarks>
/// Divergence: of the block predicates a rule can test, only the logical ones and the two that match
/// blocks are evaluated, which is every one vanilla's own three transformers use. Any other makes its
/// rule fail, so a datapack transformer that relies on one is predicted as passing and costs a missing
/// swing until the server's answer arrives.
/// </remarks>
public sealed class BlockTransforms(MinecraftClient client, BlockTags tags) {
    /// <summary>The entry that applies, and what it turns the block into.</summary>
    public sealed record Match(BlockTransformData Data, IBlock Result);

    /// <param name="stateAt">The level to test against, which lets a caller ask about the block as it was.</param>
    public Match? Find(ItemStack held, int x, int y, int z, BlockFace face, Func<int, int, int, ushort> stateAt) {
        MinecraftRegistry registry = client.Registry;
        if (!ItemComponents.Has(held, DataComponent.BlockTransformer)) {
            return null;
        }

        Identifier name = ItemComponents.Get(held, DataComponent.BlockTransformer);
        if (!registry.BlockTransformers.Contains(name)) {
            return null;
        }

        foreach (BlockTransformData data in registry.BlockTransformers[name].Transforms) {
            if (data.DisallowedFaces is { } disallowed && Array.IndexOf(disallowed, face) >= 0) {
                continue;
            }

            if (OptionalState(data.BlockStateProvider, x, y, z, stateAt) is { } result) {
                return new Match(data, result);
            }
        }

        return null;
    }

    /// <summary><c>BlockStateProvider.getOptionalState</c>, which only a rule based provider can answer null to.</summary>
    private IBlock? OptionalState(INbtTag provider, int x, int y, int z, Func<int, int, int, ushort> stateAt) {
        CompoundTag tag = Resolve(provider);
        if (!tag.Contains("type")) {
            return State(tag);
        }

        switch (tag["type"].GetString()) {
            case "minecraft:rule_based":
                foreach (INbtTag rule in tag["rules"].AsList()) {
                    CompoundTag ruleTag = rule.GetCompound();
                    if (Test(ruleTag["if_true"].GetCompound(), x, y, z, stateAt)
                        && OptionalState(ruleTag["then"]!, x, y, z, stateAt) is { } state) {
                        return state;
                    }
                }

                return tag["fallback"] is { } fallback ? OptionalState(fallback, x, y, z, stateAt) : null;

            case "minecraft:copy_properties":
                return OptionalState(tag["source"]!, x, y, z, stateAt) is { } source
                    ? WithPropertiesOf(source, client.Registry.Blocks.GetByStateId(stateAt(x, y, z)))
                    : null;

            case "minecraft:simple":
                return BlockState(tag["state"]!);

            default:
                // The world generation providers draw from noise or a random source, which a transform
                // does not use, so there is no answer to predict.
                return null;
        }
    }

    /// <summary>A registry reference, or the provider itself.</summary>
    private CompoundTag Resolve(INbtTag provider) {
        return provider is StringTag name ? client.Registry.BlockStateProviders[(Identifier)name.Value].Data : provider.GetCompound();
    }

    /// <summary><c>BlockState.CODEC</c>: a block's name for its default state, or the full form.</summary>
    private IBlock BlockState(INbtTag tag) {
        return tag is StringTag name ? client.Registry.Blocks[(Identifier)name.Value] : State(tag.GetCompound());
    }

    /// <summary><c>BlockState.FULL_CODEC</c>: <c>{id, properties}</c>.</summary>
    private IBlock State(CompoundTag tag) {
        IBlock block = client.Registry.Blocks[(Identifier)tag["id"].GetString()];
        return tag["properties"] is CompoundTag properties ? block.WithState(properties) : block;
    }

    /// <summary><c>withPropertiesOf</c>: each of the source's properties the result also has is copied over.</summary>
    private static IBlock WithPropertiesOf(IBlock result, IBlock source) {
        return result.WithState(source.ToStateNbt());
    }

    private bool Test(CompoundTag predicate, int x, int y, int z, Func<int, int, int, ushort> stateAt) {
        switch (predicate["type"].GetString()) {
            case "minecraft:all_of":
                return predicate["predicates"].AsList().All(p => Test(p.GetCompound(), x, y, z, stateAt));
            case "minecraft:any_of":
                return predicate["predicates"].AsList().Any(p => Test(p.GetCompound(), x, y, z, stateAt));
            case "minecraft:not":
                return !Test(predicate["predicate"].GetCompound(), x, y, z, stateAt);
            case "minecraft:true":
                return true;
            case "minecraft:matching_blocks":
                return MatchesBlocks(predicate["blocks"]!, Offset(predicate, x, y, z, stateAt));
            case "minecraft:matching_block_tag":
                return tags.Contains((Identifier)predicate["tag"].GetString(), Offset(predicate, x, y, z, stateAt));
            default:
                return false;
        }
    }

    /// <summary><c>StateTestingPredicate.test</c>: the state at the predicate's offset from the clicked block.</summary>
    private IBlock Offset(CompoundTag predicate, int x, int y, int z, Func<int, int, int, ushort> stateAt) {
        if (predicate["offset"] is { } offset) {
            INbtTag[] at = offset.AsList();
            x += at[0].AsInt();
            y += at[1].AsInt();
            z += at[2].AsInt();
        }

        return client.Registry.Blocks.GetByStateId(stateAt(x, y, z));
    }

    /// <summary>A block <c>HolderSet</c>: one name, a list of names, or a tag.</summary>
    private bool MatchesBlocks(INbtTag blocks, IBlock state) {
        if (blocks is StringTag single) {
            string value = single.Value;
            return value.StartsWith('#') ? tags.Contains((Identifier)value[1..], state) : state.Identifier == (Identifier)value;
        }

        return blocks.AsList().Any(name => state.Identifier == (Identifier)name.GetString());
    }
}
