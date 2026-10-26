using Minecraft.Data;
using Minecraft.Data.DebugSubscriptions;
using Minecraft.Registry;

namespace Minecraft.Schemas;

/// <summary>
/// The current value of one debug channel, or its absence when the thing it described is gone.
/// </summary>
public class DebugSubscriptionUpdate : INetworkType<DebugSubscriptionUpdate> {
    public required IDebugSubscription Subscription { get; init; }

    /// <summary>
    /// The payload, in the shape the subscription defines, or null when the value was cleared.
    /// Kept raw because each channel carries a different structure, none of which the client uses
    /// outside a development build.
    /// </summary>
    public byte[]? Value { get; init; }

    public DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteVarInt(reg.DebugSubscriptions.GetProtocolId(Subscription))
            .WritePrefixedOptional(Value, (value, writer) => writer.Write(value));
    }

    public static DebugSubscriptionUpdate ReadData(DataReader r, MinecraftRegistry reg) {
        return new DebugSubscriptionUpdate {
            Subscription = reg.DebugSubscriptions[r.ReadVarInt()],
            Value = r.ReadPrefixedOptional(reader => reader.ReadRemaining())
        };
    }
}
