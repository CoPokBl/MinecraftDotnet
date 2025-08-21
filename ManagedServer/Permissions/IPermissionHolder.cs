using ManagedServer.Events;
using Minecraft.Implementations.Events;
using Minecraft.Implementations.Server.Events;

namespace ManagedServer.Permissions;

public interface IPermissionHolder {
    public IPermissionContainer PermissionContainer { get; }
    public EventNode<IServerEvent> EventNode { get; }
}

public static class PermissionHolderExtensions {
    
    public static bool HasPermission(this IPermissionHolder holder, string permission) {
        return holder.PermissionContainer.HasPermission(permission);
    }
    
    public static void SetPermission(this IPermissionHolder holder, string permission, bool value) {
        PermissionChangeEvent changeEvent = new() {
            PermissionHolder = holder,
            Node = permission,
            Change = value ? PermissionChange.Grant : PermissionChange.Deny
        };
        holder.EventNode.CallEvent(changeEvent);
        
        holder.PermissionContainer.SetPermission(permission, value);
    }
    
    public static void RemovePermission(this IPermissionHolder holder, string permission) {
        PermissionChangeEvent changeEvent = new() {
            PermissionHolder = holder,
            Node = permission,
            Change = PermissionChange.Remove
        };
        holder.EventNode.CallEvent(changeEvent);
        
        holder.PermissionContainer.RemovePermission(permission);
    }
    
    public static void ClearPermissions(this IPermissionHolder holder) {
        PermissionChangeEvent changeEvent = new() {
            PermissionHolder = holder,
            Node = "*",
            Change = PermissionChange.Remove
        };
        holder.EventNode.CallEvent(changeEvent);
        
        holder.PermissionContainer.ClearPermissions();
    }
    
    public static bool HasPermissions(this IPermissionHolder holder, params string[] permissions) {
        return permissions.All(holder.HasPermission);
    }
}
