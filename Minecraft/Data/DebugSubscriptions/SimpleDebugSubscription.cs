using Minecraft.Schemas;

namespace Minecraft.Data.DebugSubscriptions;

public record SimpleDebugSubscription(Identifier Identifier) : IDebugSubscription;
