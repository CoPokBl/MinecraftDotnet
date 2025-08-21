namespace ManagedServer.Permissions;

public interface IPermissionContainer {
    public void SetPermission(string node, bool value);
    public bool HasPermission(string perm);
    public void RemovePermission(string node);
    public void ClearPermissions();
    
    public bool this[string node] {
        get => HasPermission(node);
        set => SetPermission(node, value);
    }
}
