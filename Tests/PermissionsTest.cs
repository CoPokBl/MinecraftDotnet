using ManagedServer.Permissions.ContainerImpl;

namespace Tests;

public class PermissionsTest {

    [Test]
    public void TestPatternMatching() {
        MapPermissionContainer perms = new();
        
        perms.SetPermission("lovespotatoes", true);
        perms.SetPermission("lovespotatoes.baked", true);
        perms.SetPermission("adam.is.*", true);
        perms.SetPermission("lovespotatoes.fromcountry.*", true);
        perms.SetPermission("lovespotatoes.fromcountry.france", false);
        perms.SetPermission("lovespotatoes.fromcountry.fr*nce", false);

        Assert.That(perms.HasPermission("lovespotatoes"));
        Assert.That(perms.HasPermission("lovespotatoes.baked"));
        Assert.That(perms.HasPermission("adam.is.mad"));
        Assert.That(perms.HasPermission("lovespotatoes.mashed"), Is.False);
        Assert.That(perms.HasPermission("lovespotatoes.fromcountry.france"), Is.False);
        Assert.That(perms.HasPermission("lovespotatoes.fromcountry.frHELLOWORLDnce"), Is.False);
        Assert.That(perms.HasPermission("adam.bad"), Is.False);

        perms.SetPermission("*", true);
        Assert.That(perms.HasPermission("michael.exists"));
    }
}
