using Minecraft.Schemas;

namespace Minecraft;

/// <summary>
/// Class containing list of Minecraft blocks whose IDs have changed between recent versions.
/// DO NOT EXPECT THIS LIST TO BE COMPLETE. Feel free to PR more entries.
/// </summary>
public static class RenamedBlocks {
    public static readonly Dictionary<Identifier, Identifier> Map = new() {
        { "minecraft:chain", "minecraft:iron_chain" }
    };
}
