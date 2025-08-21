using System.Text.RegularExpressions;

namespace ManagedServer.Permissions.ContainerImpl;

public abstract class NodeListPermissionContainer : IPermissionContainer {
    public abstract void SetPermission(string node, bool value);
    public abstract void RemovePermission(string node);
    public abstract (string node, bool value)[] GetPermissions();
    public abstract void ClearPermissions();

    public bool HasPermission(string perm) {
        if (string.IsNullOrWhiteSpace(perm)) {
            throw new ArgumentException("Permission node cannot be null or empty", nameof(perm));
        }
        
        bool matchesPos = false;

        foreach ((string node, bool value) in GetPermissions()) {
            Regex regex = new("^(" + node.Replace("*", ".*") + ")$");
            bool matches = regex.IsMatch(perm);
            if (!matches) continue;

            if (value) {
                matchesPos = true;
            } else {
                return false;
            }
        }

        return matchesPos;
    }
}
