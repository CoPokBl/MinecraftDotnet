using Minecraft.Data.JukeboxSong;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Registry.SubRegistries;

public class JukeboxSongRegistry : SequentialRegistry<JukeboxSongRegistry, IJukeboxSong>, INbtSerialisableRegistry {
    public override Identifier RegistryId => "minecraft:jukebox_song";

    public void LoadNbt(Dictionary<string, INbtTag> entries, MinecraftRegistry reg) {
        Clear();

        foreach (KeyValuePair<string, INbtTag> entry in entries) {
            if (entry.Value is CompoundTag compoundTag) {
                Add(IJukeboxSong.FromNbt(entry.Key, compoundTag, reg));
            }
        }
    }

    public Dictionary<string, INbtTag> ToNbt() {
        Dictionary<string, INbtTag> nbtDict = new();
        foreach (IJukeboxSong entry in Entries) {
            nbtDict.Add(entry.Identifier.ToString(), entry.ToNbt());
        }
        return nbtDict;
    }
}
