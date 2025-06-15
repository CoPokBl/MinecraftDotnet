using Minecraft.NBT;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundRegistryDataPacket(string registryId, Dictionary<string, ITag?> entries) : MinecraftPacket {
    public Dictionary<string, ITag?> Entries = entries;
    public string RegistryId = registryId;
    
    public ClientBoundRegistryDataPacket() : this("", new Dictionary<string, ITag?>()) { }

    public override int GetPacketId() {
        return 0x07;
    }

    protected override byte[] GetData() {
        return new DataWriter()
            .WriteString(RegistryId)
            .WritePrefixedArray(
                Entries.ToArray(),
                (entry, writer) => writer
                    .WriteString(entry.Key)
                    .WritePrefixedOptional(entry.Value, (tag, dataWriter) => dataWriter.WriteNbt(tag)))
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        RegistryId = r.ReadString();
        KeyValuePair<string, ITag?>[] entries = r.ReadPrefixedArray(reader => new KeyValuePair<string, ITag?>(
            reader.ReadString(),
            reader.ReadPrefixedOptional(re => re.ReadNbt())));
        Entries = new Dictionary<string, ITag?>(entries);
        return this;
    }
}