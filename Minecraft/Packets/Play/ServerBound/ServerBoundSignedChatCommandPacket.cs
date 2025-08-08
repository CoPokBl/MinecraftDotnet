using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

public class ServerBoundSignedChatCommandPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:chat_command_signed";

    public required string Command { get; init; }
    public required long Timestamp { get; init; }
    public required long Salt { get; init; }
    public required (string Name, byte[] Signature)[] ArgumentSignatures { get; init; }
    public required int MessageCount { get; init; }
    public required byte[] Acknowledged { get; init; }
    public required byte Checksum { get; init; }
    
    protected override DataWriter WriteData(DataWriter w) {
        AssertLength(Acknowledged, 3);
        Array.ForEach(ArgumentSignatures, tuple => AssertLength(tuple.Signature, 256));
        
        return w
            .WriteString(Command)
            .WriteLong(Timestamp)
            .WriteLong(Salt)
            .WritePrefixedArray(ArgumentSignatures, (args, wr) => wr
                .WriteString(args.Name)
                .WriteArray(args.Signature, (b, wri) => wri.Write(b)))
            .WriteVarInt(MessageCount)
            .WriteArray(Acknowledged, (b, wri) => wri.Write(b))
            .Write(Checksum);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSignedChatCommandPacket {
        Command = r.ReadString(),
        Timestamp = r.ReadLong(),
        Salt = r.ReadLong(),
        ArgumentSignatures = r.ReadPrefixedArray(reader => (
            Name: reader.ReadString(),
            Signature: reader.Read(256)
        )),
        MessageCount = r.ReadVarInt(),
        Acknowledged = r.Read(3),
        Checksum = (byte)r.ReadByte()
    };
}
