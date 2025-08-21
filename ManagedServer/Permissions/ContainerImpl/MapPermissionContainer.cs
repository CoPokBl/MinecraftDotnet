namespace ManagedServer.Permissions.ContainerImpl;

public class MapPermissionContainer : NodeListPermissionContainer {
    private readonly Dictionary<string, bool> _permissions = [];
    
    public override void SetPermission(string node, bool value) {
        if (string.IsNullOrWhiteSpace(node)) {
            throw new ArgumentException("Permission node cannot be null or empty", nameof(node));
        }
        
        _permissions[node] = value;
    }

    public override void RemovePermission(string node) {
        if (string.IsNullOrWhiteSpace(node)) {
            throw new ArgumentException("Permission node cannot be null or empty", nameof(node));
        }
        
        _permissions.Remove(node);
    }

    public override void ClearPermissions() {
        _permissions.Clear();
    }
    
    public override (string node, bool value)[] GetPermissions() {
        return _permissions.Select(kvp => (kvp.Key, kvp.Value)).ToArray();
    }
}
