using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundChatMessagePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:chat";
    
    public required string Message { get; init; }
    public required long Timestamp { get; init; }
    public required long Salt { get; init; }
    public byte[]? Signature;
    public required int MessageCount { get; init; }
    public required byte[] Acknowledged { get; init; }
    public required byte Checksum { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        if (Signature != null) AssertLength(Signature, 256);
        AssertLength(Acknowledged, 3);
        
        return w
            .WriteString(Message)
            .WriteLong(Timestamp)
            .WriteLong(Salt)
            .WritePrefixedOptional(Signature, (v, wr) => wr.Write(v)) // must be 256
            .WriteVarInt(MessageCount)
            .Write(Acknowledged)  // BitSet of length 20, ceil(20/8)=3 bytes
            .WriteByte(Checksum);
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
