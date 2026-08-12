using Minecraft.Data.WorldClock;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class WorldClockRegistry : SequentialRegistry<WorldClockRegistry, IWorldClock>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:world_clock";

    public void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg) {
        Clear();

        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            if (entry.Value is CompoundTag compoundTag) {
                Add(IWorldClock.FromNbt(entry.Key, compoundTag, reg));
            }
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (IWorldClock entry in Entries) {
            nbtDict.Add(entry.Identifier.ToString(), entry.ToNbt());
        }
        return nbtDict;
    }
}
