using Minecraft.Commands;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundCommandsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:commands";
    
    public required ICommandNode[] Nodes { get; init; }
    public required int RootIndex { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        return w
            .WritePrefixedArray(Nodes, (n, wr) => n.WriteData(wr, registry))
            .WriteVarInt(RootIndex);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundCommandsPacket {
        Nodes = r.ReadPrefixedArray(re => ICommandNode.ReadData(re, reg)),
        RootIndex = r.ReadVarInt()
    };
}
