using Minecraft.Data.Components.Codecs;
using Minecraft.Data.JukeboxSong;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>What makes an item a music disc: the song a jukebox plays when it is put in.</summary>
public record JukeboxPlayableComponent() : IDataComponent<IJukeboxSong> {
    public override Identifier Identifier => "minecraft:jukebox_playable";

    public override NbtCodec<IJukeboxSong>? Codec => Persistent;
    private static readonly NbtCodec<IJukeboxSong> Persistent = NbtCodecs.Holder<IJukeboxSong>("minecraft:jukebox_playable", reg => reg.JukeboxSongs);

    public override DataWriter WriteData(IJukeboxSong val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteHolder(val, registry.JukeboxSongs, (inline, w) => w.Write(inline, registry));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadHolder(id => registry.JukeboxSongs[id], r => IJukeboxSong.ReadData(r, registry));
    }

    public override bool ValuesEqual(IJukeboxSong val1, IJukeboxSong val2) {
        return val1.Identifier == val2.Identifier;
    }
}
