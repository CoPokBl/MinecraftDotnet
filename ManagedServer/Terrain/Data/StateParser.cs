using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace ManagedServer.Terrain.Data;

/// <summary>
/// <c>NbtUtils.readBlockState</c>: a block state in the form the datapack and the structure templates
/// both write it, a name plus the properties that differ from the block's default.
/// </summary>
/// <remarks>
/// <b>A property the block does not have is an error here.</b> <see cref="IBlock.WithState(CompoundTag)"/>
/// ignores an unknown key, so reading one straight would turn an upstream rename into a state that
/// silently comes out as the block's default: a top slab as a bottom one, a north facing stair as an
/// east facing one. Both sides of the comparison come from the same jar, so a mismatch means one of
/// them is stale and is worth failing the load for.
/// </remarks>
public static class StateParser {
    /// <summary>The named block's default state, with the given properties applied.</summary>
    public static IBlock Read(MinecraftRegistry registry, Identifier name, CompoundTag? properties) {
        if (!registry.Blocks.Contains(name)) {
            throw new FormatException($"No block registered as \"{name}\".");
        }

        IBlock block = registry.Blocks[name];

        return properties is null ? block : Apply(block, properties);
    }

    /// <summary>The state with the given properties applied, throwing for one it does not have.</summary>
    public static IBlock Apply(IBlock block, CompoundTag properties) {
        if (properties.ChildCount == 0) {
            return block;
        }

        CompoundTag known = block.ToStateNbt();

        foreach ((string key, INbtTag _) in properties.Children) {
            if (!known.Contains(key)) {
                throw new FormatException(
                    $"\"{block.Identifier}\" has no property \"{key}\". It has "
                    + $"[{string.Join(", ", known.Children.Select(child => child.key))}].");
            }
        }

        return block.WithState(properties);
    }
}

/// <summary>
/// <c>BlockStateParser.parseForBlock</c>: a block state written the way a command writes it,
/// <c>namespace:block[key=value,key=value]</c>.
/// </summary>
/// <remarks>
/// This is a <b>different form</b> from the NBT one <see cref="StateParser"/> reads, and the only
/// place it turns up is a jigsaw block's <c>final_state</c>. Reading one with the other's parser is a
/// silent miss, since neither shape is valid input to the other.
/// </remarks>
public static class BlockStateStrings {
    public static uint Parse(MinecraftRegistry registry, string written) {
        string text = written.Trim();
        int bracket = text.IndexOf('[');

        if (bracket < 0) {
            return StateParser.Read(registry, Identifier.Parse(text), null).StateId;
        }

        int close = text.LastIndexOf(']');

        if (close < bracket) {
            throw new FormatException($"\"{written}\" opens a property list and does not close it.");
        }

        Identifier name = Identifier.Parse(text[..bracket]);
        string body = text[(bracket + 1)..close];

        List<(string, INbtTag)> properties = [];

        foreach (string pair in body.Split(',', StringSplitOptions.RemoveEmptyEntries)) {
            int equals = pair.IndexOf('=');

            if (equals < 0) {
                throw new FormatException($"\"{pair}\" in \"{written}\" is not a key=value pair.");
            }

            properties.Add((pair[..equals].Trim(), new StringTag(pair[(equals + 1)..].Trim())));
        }

        return StateParser.Read(registry, name, new CompoundTag(properties.ToArray())).StateId;
    }
}
