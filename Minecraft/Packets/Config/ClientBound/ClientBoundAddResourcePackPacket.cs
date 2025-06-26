using Minecraft.NBT.Text;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundAddResourcePackPacket : ClientBoundPacket {
    public required Guid Uuid;
    public required string Url;
    
    /// <summary>
    /// 40 character hexadecimal string representing the SHA-1 hash of the resource pack file.
    /// If the hash is not 40 characters or is not a valid SHA-1 hash, the Notchian client will ignore it.
    /// </summary>
    public string Hash = "";

    public required bool Forced;
    public TextComponent? Prompt;

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteUuid(Uuid)
            .WriteString(Url)
            .WriteString(Hash)
            .WriteBoolean(Forced)
            .WritePrefixedOptional(Prompt, (text, wr) => wr.WriteNbt(text))
            .ToArray();
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = r => new ClientBoundAddResourcePackPacket {
        Uuid = r.ReadUuid(),
        Url = r.ReadString(),
        Hash = r.ReadString(),
        Forced = r.ReadBoolean(),
        Prompt = r.ReadPrefixedOptional(re => re.ReadText())
    };
}
