using Minecraft.Data.Blocks;
using NBT;
using NBT.Tags;

namespace GraphicalClient.Assets;

/// <summary>A block state's properties by name, as a blockstate file spells them.</summary>
public static class StateProperties {
    public static Dictionary<string, string> Of(IBlock state) {
        Dictionary<string, string> properties = new();
        foreach ((string key, INbtTag value) in state.ToStateNbt().Children) {
            properties[key] = value is StringTag s ? s.Value : value.ToString() ?? "";
        }
        return properties;
    }

    public static string? Get(IBlock state, string name) {
        foreach ((string key, INbtTag value) in state.ToStateNbt().Children) {
            if (key == name && value is StringTag s) {
                return s.Value;
            }
        }
        return null;
    }

    public static int GetInt(IBlock state, string name) => int.TryParse(Get(state, name), out int parsed) ? parsed : 0;
}
