using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ClientBound;

public class ClientBoundKnownPacksPacket(KnownDataPack[] packs) : MinecraftPacket {
    public KnownDataPack[] Packs = packs;

    public ClientBoundKnownPacksPacket() : this([]) { }
    
    public override int GetPacketId() {
        return 0x0E;
    }

    protected override byte[] GetData() {
        DataWriter w = new();
        w.WritePrefixedArray(Packs, (pack, writer) => writer
            .WriteString(pack.Namespace)
            .WriteString(pack.Id)
            .WriteString(pack.Version));
        return w.ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Packs = r.ReadPrefixedArray(reader => 
            new KnownDataPack(reader.ReadString(), reader.ReadString(), reader.ReadString()));
        return this;
    }
}