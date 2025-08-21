using ManagedServer.Events.Types;
using ManagedServer.Permissions;

namespace ManagedServer.Events;

public class PermissionChangeEvent : IPermissionHolderEvent {
    public required IPermissionHolder PermissionHolder { get; init; }
    public required string Node { get; init; }
    public required PermissionChange Change { get; init; }
}
