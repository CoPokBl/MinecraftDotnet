using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundChatMessagePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:chat";
    
    public required string Message;
    public required long Timestamp;
    public required long Salt;
    public byte[]? Signature;
    public required int MessageCount;
    public required byte[] Acknowledged;
    public required byte Checksum;

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
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundChatMessagePacket {
        Message = r.ReadString(),
        Timestamp = r.ReadLong(),
        Salt = r.ReadLong(),
        Signature = r.ReadPrefixedOptional(reader => reader.Read(256)),
        MessageCount = r.ReadVarInt(),
        Acknowledged = r.Read(3),
        Checksum = (byte)r.ReadByte()
    };
}
