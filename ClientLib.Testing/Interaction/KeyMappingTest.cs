using ClientLib.Interaction;

namespace ClientLib.Testing.Interaction;

/// <summary><c>KeyMapping</c> and <c>ToggleKeyMapping</c>: how a press, a release and a screen opening and closing move a key.</summary>
public class KeyMappingTest {
    private static KeyMapping Toggle(Func<bool> needsToggle, bool restores = true) =>
        new(true) { NeedsToggle = needsToggle, RestoresAfterScreen = restores };

    [Test]
    public void TestAToggledKeyFlipsOnEachPressAndIgnoresTheRelease() {
        KeyMapping sneak = Toggle(() => true);
        sneak.SetDown(true);
        sneak.SetDown(false);
        Assert.That(sneak.IsDown, Is.True);
        sneak.SetDown(true);
        sneak.SetDown(false);
        Assert.That(sneak.IsDown, Is.False);
    }

    [Test]
    public void TestAHeldToggleMappingFollowsTheKey() {
        KeyMapping sneak = Toggle(() => false);
        sneak.SetDown(true);
        Assert.That(sneak.IsDown, Is.True);
        sneak.SetDown(false);
        Assert.That(sneak.IsDown, Is.False);
    }

    [Test]
    public void TestAScreenKeepsAToggleMappingsClicksButNotAPlainOnes() {
        KeyMapping attack = Toggle(() => false);
        KeyMapping drop = new(true);
        attack.Press();
        drop.Press();
        attack.Release();
        drop.Release();
        Assert.Multiple(() => {
            Assert.That(attack.IsDown, Is.False);
            Assert.That(attack.ConsumeClick(), Is.True);
            Assert.That(drop.IsDown, Is.False);
            Assert.That(drop.ConsumeClick(), Is.False);
        });
    }

    [Test]
    public void TestAToggledKeyComesBackOnceWhenTheScreenCloses() {
        KeyMapping sprint = Toggle(() => true);
        sprint.SetDown(true);
        sprint.Release();
        Assert.That(sprint.IsDown, Is.False);
        Assert.That(sprint.ShouldRestoreStateOnScreenClosed(true), Is.True);
        Assert.That(sprint.ShouldRestoreStateOnScreenClosed(true), Is.False);
    }

    [Test]
    public void TestAToggledMouseButtonOrAMappingThatDoesNotRestoreStaysUp() {
        KeyMapping attack = Toggle(() => true);
        attack.SetDown(true);
        attack.Release();
        Assert.That(attack.ShouldRestoreStateOnScreenClosed(false), Is.False);

        KeyMapping use = Toggle(() => true, restores: false);
        use.SetDown(true);
        use.Release();
        Assert.That(use.ShouldRestoreStateOnScreenClosed(true), Is.False);
    }

    [Test]
    public void TestASecondScreenStillRemembersTheFirstRelease() {
        KeyMapping sneak = Toggle(() => true);
        sneak.SetDown(true);
        sneak.Release();
        sneak.Release();
        Assert.That(sneak.ShouldRestoreStateOnScreenClosed(true), Is.True);
    }

    [Test]
    public void TestRespawnLetsGoOfAToggledKey() {
        KeyMappings keys = new();
        bool toggle = true;
        keys.UseToggleOptions(() => false, () => false, () => toggle, () => false);
        keys.Sneak.SetDown(true);
        Assert.That(keys.KeyboardInput().Shift, Is.True);
        keys.ResetToggleKeys();
        Assert.That(keys.KeyboardInput().Shift, Is.False);
    }
}
