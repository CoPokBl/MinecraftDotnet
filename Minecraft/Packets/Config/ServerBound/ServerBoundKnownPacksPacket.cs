using Minecraft.Schemas;

namespace Minecraft.Packets.Config.ServerBound;

public class ServerBoundKnownPacksPacket(KnownDataPack[] packs) : MinecraftPacket {
    public KnownDataPack[] Packs = packs;

    public ServerBoundKnownPacksPacket() : this([]) { }
    
    public override int GetPacketId() {
        return 0x07;
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