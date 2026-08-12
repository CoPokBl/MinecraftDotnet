using Minecraft.Data.DebugSubscriptions;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>
/// Asks the server for the debug channels the client wants. It replaces the whole subscription
/// set, so an empty list turns the debug stream off.
/// </summary>
public class ServerBoundDebugSubscriptionRequestPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:debug_subscription_request";

    public required IDebugSubscription[] Subscriptions { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w.WritePrefixedArray(Subscriptions, (subscription, writer) =>
            writer.WriteVarInt(reg.DebugSubscriptions.GetProtocolId(subscription)));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ServerBoundDebugSubscriptionRequestPacket {
        Subscriptions = r.ReadPrefixedArray(reader => reg.DebugSubscriptions[reader.ReadVarInt()])
    };
}
