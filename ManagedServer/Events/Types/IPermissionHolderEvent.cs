using ManagedServer.Permissions;
using Minecraft.Implementations.Server.Events;

namespace ManagedServer.Events.Types;

public interface IPermissionHolderEvent : IServerEvent {
    public IPermissionHolder PermissionHolder { get; init; }
}
