namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundChatMessagePacket(
    string message, 
    long timestamp, 
    long salt, 
    byte[] signature, 
    int messageCount, 
    byte[] acknowledged, 
    byte checksum) : MinecraftPacket {
    
    public string Message = message;
    public long Timestamp = timestamp;
    public long Salt = salt;
    public byte[]? Signature = signature;
    public int MessageCount = messageCount;
    public byte[] Acknowledged = acknowledged;
    public byte Checksum = checksum;
    
    public ServerBoundChatMessagePacket() : this("", 0, 0, new byte[256], 0, new byte[3], 0x00) { }

    public override int GetPacketId() {
        return 0x07;
    }

    protected override byte[] GetData() {
        if (Signature != null) AssertLength(Signature, 256);
        AssertLength(Acknowledged, 3);
        
        return new DataWriter()
            .WriteString(Message)
            .WriteLong(Timestamp)
            .WriteLong(Salt)
            .WritePrefixedOptional(Signature, (v, w) => w.Write(v)) // must be 256
            .WriteVarInt(MessageCount)
            .Write(Acknowledged)  // BitSet of length 20, ceil(20/8)=3 bytes
            .WriteByte(Checksum)
            .ToArray();
    }

    protected override MinecraftPacket ParseData(byte[] data) {
        DataReader r = new(data);
        Message = r.ReadString();
        Timestamp = r.ReadLong();
        Salt = r.ReadLong();
        Signature = r.ReadPrefixedOptional(reader => r.Read(256));
        MessageCount = r.ReadVarInt();
        Acknowledged = r.Read(3);
        Checksum = r.ReadByte();
        return this;
    }
}