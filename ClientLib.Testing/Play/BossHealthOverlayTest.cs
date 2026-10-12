using Minecraft.Packets.Play.ClientBound;
using Minecraft.Text;

namespace ClientLib.Testing.Play;

/// <summary><c>BossHealthOverlay.update</c> and <c>LerpingBossEvent</c>'s progress glide.</summary>
public class BossHealthOverlayTest {
    private static ClientBoundBossBarPacket Packet(Guid id, ClientBoundBossBarPacket.IActionData action) {
        return new ClientBoundBossBarPacket { Uuid = id, Action = action };
    }

    private static ClientBoundBossBarPacket Add(Guid id, string name, float progress = 1.0F, ClientBoundBossBarPacket.Flags flags = ClientBoundBossBarPacket.Flags.None) {
        return Packet(id, new ClientBoundBossBarPacket.Add(TextComponent.Text(name), progress,
            ClientBoundBossBarPacket.Color.Red, ClientBoundBossBarPacket.Division.Ten, flags));
    }

    [Test]
    public void ProgressGlidesOverAHundredMilliseconds() {
        BossHealthOverlay overlay = new();
        Guid id = Guid.NewGuid();
        overlay.Update(Add(id, "a", 1.0F), 1000);
        overlay.Update(Packet(id, new ClientBoundBossBarPacket.UpdateHealth(0.0F)), 2000);
        LerpingBossEvent bar = overlay.Events.Single();
        Assert.That(bar.GetProgress(2000), Is.EqualTo(1.0F));
        Assert.That(bar.GetProgress(2025), Is.EqualTo(0.75F).Within(1e-6F));
        Assert.That(bar.GetProgress(2100), Is.EqualTo(0.0F));
        Assert.That(bar.GetProgress(5000), Is.EqualTo(0.0F));
    }

    /// <summary>A second update mid glide starts from where the bar is drawn, not from the old target.</summary>
    [Test]
    public void ARetargetStartsFromTheDrawnProgress() {
        BossHealthOverlay overlay = new();
        Guid id = Guid.NewGuid();
        overlay.Update(Add(id, "a", 1.0F), 0);
        overlay.Update(Packet(id, new ClientBoundBossBarPacket.UpdateHealth(0.0F)), 1000);
        overlay.Update(Packet(id, new ClientBoundBossBarPacket.UpdateHealth(1.0F)), 1050);
        LerpingBossEvent bar = overlay.Events.Single();
        Assert.That(bar.GetProgress(1050), Is.EqualTo(0.5F).Within(1e-6F));
        Assert.That(bar.GetProgress(1100), Is.EqualTo(0.75F).Within(1e-6F));
    }

    /// <summary>The overlay is a <c>LinkedHashMap</c>: a re-added id keeps its place, a removed one loses it.</summary>
    [Test]
    public void BarsKeepTheOrderTheyWereAddedIn() {
        BossHealthOverlay overlay = new();
        Guid a = Guid.NewGuid(), b = Guid.NewGuid(), c = Guid.NewGuid();
        overlay.Update(Add(a, "a"), 0);
        overlay.Update(Add(b, "b"), 0);
        overlay.Update(Add(c, "c"), 0);
        overlay.Update(Add(a, "a2"), 0);
        Assert.That(overlay.Events.Select(e => e.Id), Is.EqualTo(new[] { a, b, c }));
        overlay.Update(Packet(b, new ClientBoundBossBarPacket.Remove()), 0);
        overlay.Update(Add(b, "b"), 0);
        Assert.That(overlay.Events.Select(e => e.Id), Is.EqualTo(new[] { a, c, b }));
    }

    [Test]
    public void FlagsMapToTheThreeProperties() {
        BossHealthOverlay overlay = new();
        Guid id = Guid.NewGuid();
        overlay.Update(Add(id, "a", flags: ClientBoundBossBarPacket.Flags.DarkenSky), 0);
        Assert.That(overlay.ShouldDarkenScreen(), Is.True);
        Assert.That(overlay.ShouldPlayMusic(), Is.False);
        Assert.That(overlay.ShouldCreateWorldFog(), Is.False);
        overlay.Update(Packet(id, new ClientBoundBossBarPacket.UpdateFlags(ClientBoundBossBarPacket.Flags.IsDragonBar | ClientBoundBossBarPacket.Flags.CreateFog)), 0);
        Assert.That(overlay.ShouldDarkenScreen(), Is.False);
        Assert.That(overlay.ShouldPlayMusic(), Is.True);
        Assert.That(overlay.ShouldCreateWorldFog(), Is.True);
    }

    [Test]
    public void AnUpdateForAnUnknownBarIsIgnored() {
        BossHealthOverlay overlay = new();
        overlay.Update(Packet(Guid.NewGuid(), new ClientBoundBossBarPacket.UpdateHealth(0.5F)), 0);
        Assert.That(overlay.Count, Is.Zero);
    }
}
