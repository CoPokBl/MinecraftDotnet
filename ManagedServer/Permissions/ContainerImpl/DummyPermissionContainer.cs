namespace ManagedServer.Permissions.ContainerImpl;

public class DummyPermissionContainer : IPermissionContainer {
    
    public void SetPermission(string node, bool value) {
        
    }

    public bool HasPermission(string perm) {
        return false;
    }

    public void RemovePermission(string node) {
        
    }

    public void ClearPermissions() {
        
    }
}
