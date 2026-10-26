namespace Minecraft.Data.DebugSubscriptions;

/// <summary>
/// One channel of the debug data stream, such as mob paths or village sections. A client asks for
/// the ones it wants with <c>ServerBoundDebugSubscriptionRequestPacket</c>, and the server answers
/// on those channels only.
/// </summary>
public interface IDebugSubscription : IProtocolType;
