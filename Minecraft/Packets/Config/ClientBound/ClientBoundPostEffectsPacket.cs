using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

/// <summary>The post processing shaders the client runs over its frame, by resource location. Sent in configuration and in play.</summary>
public class ClientBoundPostEffectsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:post_effects";

    public required Identifier[] PostEffects { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WritePrefixedArray(PostEffects, (effect, writer) => writer.WriteString(effect.ToString()));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundPostEffectsPacket {
        PostEffects = r.ReadPrefixedArray(reader => (Identifier)reader.ReadString())
    };
}
