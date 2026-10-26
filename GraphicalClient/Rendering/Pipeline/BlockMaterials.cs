using Minecraft.Data.Blocks;
using Minecraft.Registry;
using NBT;
using NBT.Tags;

namespace GraphicalClient.Rendering.Pipeline;

/// <summary>
/// The material number a pack's <c>materials</c> give each block state, which the mesher writes into
/// the high six bits of a terrain vertex's flags byte. A pack that names no materials gets
/// <see cref="None"/>, and the mesher then does no work for them.
/// </summary>
public sealed class BlockMaterials {
    public const int MaxId = 63;

    /// <summary>The material of each state's own geometry.</summary>
    public readonly byte[] ByState;

    /// <summary>The material of the fluid drawn with each state: water's for anything waterlogged, lava's for lava.</summary>
    public readonly byte[] FluidByState;

    /// <summary>Bit per material whose faces are never merged with their neighbours.</summary>
    public readonly ulong Unmerged;

    public static readonly BlockMaterials None = new([], [], 0);

    private BlockMaterials(byte[] byState, byte[] fluidByState, ulong unmerged) {
        ByState = byState;
        FluidByState = fluidByState;
        Unmerged = unmerged;
    }

    public bool IsEmpty => ByState.Length == 0;

    public byte Of(int state) => IsEmpty ? (byte)0 : ByState[state];

    public byte FluidOf(int state) => IsEmpty ? (byte)0 : FluidByState[state];

    public bool SameAs(BlockMaterials other) =>
        Unmerged == other.Unmerged && ByState.AsSpan().SequenceEqual(other.ByState) && FluidByState.AsSpan().SequenceEqual(other.FluidByState);

    /// <param name="warn">Told about each block name the registry does not have, which would otherwise match nothing in silence.</param>
    public static BlockMaterials Build(IReadOnlyList<MaterialDefinition> materials, MinecraftRegistry registry, uint waterState, uint lavaState, Action<string> warn) {
        if (materials.Count == 0) {
            return None;
        }
        // Each selector: the block, and the properties a state must have, from "name:key=value:key=value".
        Dictionary<string, List<(Dictionary<string, string> Properties, byte Id)>> selectors = new();
        ulong unmerged = 0;
        foreach (MaterialDefinition material in materials) {
            if (material.Id is < 1 or > MaxId) {
                throw new InvalidDataException($"Material {material.Id}: ids run from 1 to {MaxId}");
            }
            if (!material.Merge) {
                unmerged |= 1UL << material.Id;
            }
            foreach (string selector in material.Blocks) {
                string[] parts = selector.Split(':');
                int first = parts.Length > 1 && !parts[1].Contains('=') ? 2 : 1;
                string name = first == 2 ? parts[0] + ":" + parts[1] : "minecraft:" + parts[0];
                Dictionary<string, string> properties = new();
                foreach (string part in parts.Skip(first)) {
                    string[] pair = part.Split('=', 2);
                    if (pair.Length != 2) {
                        throw new InvalidDataException($"Material {material.Id}: cannot read {selector}");
                    }
                    properties[pair[0]] = pair[1];
                }
                if (!selectors.TryGetValue(name, out var list)) {
                    selectors[name] = list = [];
                }
                list.Add((properties, (byte)material.Id));
            }
        }

        int count = (int)registry.Blocks.StatesCount;
        byte[] byState = new byte[count];
        HashSet<string> found = [];
        for (uint state = 0; state < count; state++) {
            IBlock block = registry.Blocks.GetByStateId(state);
            string name = block.Identifier.ToString();
            if (!selectors.TryGetValue(name, out var list)) {
                continue;
            }
            found.Add(name);
            CompoundTag? nbt = null;
            foreach ((Dictionary<string, string> properties, byte id) in list) {
                nbt ??= properties.Count > 0 ? block.ToStateNbt() : null;
                if (properties.All(p => nbt != null && PropertyIs(nbt, p.Key, p.Value))) {
                    byState[state] = id;
                    break;
                }
            }
        }
        foreach (string name in selectors.Keys.Where(n => !found.Contains(n))) {
            warn($"Shader pack materials name {name}, which is not a block");
        }

        byte water = byState[waterState], lava = byState[lavaState];
        byte[] fluidByState = new byte[count];
        for (uint state = 0; state < count; state++) {
            IBlock block = registry.Blocks.GetByStateId(state);
            fluidByState[state] = block.Identifier.Key == "lava" ? lava : block.Fluid?.Key is "water" or "flowing_water" || block.Identifier.Key == "water" ? water : (byte)0;
        }
        return new BlockMaterials(byState, fluidByState, unmerged);
    }

    private static bool PropertyIs(CompoundTag state, string key, string value) {
        foreach ((string name, INbtTag tag) in state.Children) {
            if (name == key) {
                return (tag is StringTag s ? s.Value : tag.ToString()) == value;
            }
        }
        return false;
    }
}
