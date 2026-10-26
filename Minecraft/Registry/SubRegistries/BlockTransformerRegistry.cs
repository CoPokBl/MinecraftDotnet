using Minecraft.Data.BlockTransformer;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class BlockTransformerRegistry : SequentialRegistry<BlockTransformerRegistry, IBlockTransformer>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:block_transformer";

    public void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg) {
        Clear();

        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            Add(IBlockTransformer.FromNbt(entry.Key, entry.Value, reg));
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (IBlockTransformer entry in Entries) {
            nbtDict.Add(entry.Identifier.ToString(), entry.ToNbt());
        }
        return nbtDict;
    }
}
