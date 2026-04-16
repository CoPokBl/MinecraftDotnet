using Minecraft.Data.Timelines;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class TimelineRegistry : SequentialRegistry<TimelineRegistry, ITimeline>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:timeline";

    public void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg) {
        Clear();

        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            if (entry.Value is CompoundTag compoundTag) {
                ITimeline timeline = ITimeline.FromNbt(entry.Key, compoundTag, reg);
                Add(timeline);
            }
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (ITimeline entry in Entries) {
            nbtDict.Add(entry.Identifier.ToString(), entry.ToNbt());
        }
        return nbtDict;
    }
}
