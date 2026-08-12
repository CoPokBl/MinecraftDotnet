using Minecraft.Data.SulfurCubeArchetype;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class SulfurCubeArchetypeRegistry : SequentialRegistry<SulfurCubeArchetypeRegistry, ISulfurCubeArchetype>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:sulfur_cube_archetype";

    public void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg) {
        Clear();

        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            if (entry.Value is CompoundTag compoundTag) {
                Add(ISulfurCubeArchetype.FromNbt(entry.Key, compoundTag, reg));
            }
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (ISulfurCubeArchetype entry in Entries) {
            nbtDict.Add(entry.Identifier.ToString(), entry.ToNbt());
        }
        return nbtDict;
    }
}
