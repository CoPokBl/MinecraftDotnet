namespace ClientLib.Commands;

/// <summary>Vanilla's <c>PermissionLevel</c>, set on the client by entity events 24 to 28.</summary>
public enum PermissionLevel {
    All = 0,
    Moderators = 1,
    Gamemasters = 2,
    Admins = 3,
    Owners = 4
}

/// <summary>Vanilla's <c>Permission</c>.</summary>
public abstract record Permission {
    public sealed record Atom(string Id) : Permission;

    public sealed record HasCommandLevel(PermissionLevel Level) : Permission;
}

/// <summary>The entries of vanilla's <c>Permissions</c> the client's command code asks about.</summary>
public static class Permissions {
    public static readonly Permission CommandsEntitySelectors = new Permission.Atom("commands/entity_selectors");

    /// <summary><c>ClientPacketListener.RESTRICTED_COMMAND</c>, which a node flagged restricted requires.</summary>
    public static readonly Permission RestrictedCommand = new Permission.Atom("client/commands/restricted");
}

/// <summary>Vanilla's <c>PermissionSet</c>.</summary>
public interface IPermissionSet {
    bool HasPermission(Permission permission);
}

/// <summary>Vanilla's <c>PermissionSet.NO_PERMISSIONS</c>.</summary>
public sealed class NoPermissions : IPermissionSet {
    public static readonly NoPermissions Instance = new();

    public bool HasPermission(Permission permission) => false;
}

/// <summary>
/// <c>ClientPacketListener</c>'s suggestion provider permissions: the player's level, as
/// <c>LevelBasedPermissionSet</c> answers for it, united with permission to use restricted nodes.
/// </summary>
public sealed class PlayerPermissions(Func<PermissionLevel?> level) : IPermissionSet {
    public bool HasPermission(Permission permission) {
        if (permission == Permissions.RestrictedCommand) {
            return true;
        }
        if (level() is not { } current) {
            return false;
        }
        if (permission is Permission.HasCommandLevel check) {
            return current >= check.Level;
        }
        return permission == Permissions.CommandsEntitySelectors && current >= PermissionLevel.Gamemasters;
    }
}
