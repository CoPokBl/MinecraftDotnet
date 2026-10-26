using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace ClientLib.Testing.Play;

/// <summary><c>LivingEntity.onKineticHit</c>'s ten tick gate and <c>getTicksSinceLastKineticHitFeedback</c>, which the spear's recoil reads.</summary>
public class KineticHitFeedbackTest {
    [Test]
    public void TestNoFeedbackReadsZero() {
        ClientEntity zombie = new() { Id = 1, Type = EntityType.Zombie };
        Assert.That(zombie.TicksSinceLastKineticHitFeedback(500L, 0.5F), Is.EqualTo(0.0F));
    }

    [Test]
    public void TestFeedbackCountsFromTheHitWithThePartialTick() {
        ClientEntity zombie = new() { Id = 1, Type = EntityType.Zombie };
        Assert.That(zombie.OnKineticHit(100L), Is.True);
        // (float)(103 - 100) + 0.25.
        Assert.That(zombie.TicksSinceLastKineticHitFeedback(103L, 0.25F), Is.EqualTo(3.25F));
    }

    [Test]
    public void TestAHitWithinTenTicksDoesNotRestartIt() {
        ClientEntity zombie = new() { Id = 1, Type = EntityType.Zombie };
        zombie.OnKineticHit(100L);
        // 110 - 100 = 10 is not more than 10.
        Assert.That(zombie.OnKineticHit(110L), Is.False);
        Assert.That(zombie.LastKineticHitFeedbackTime, Is.EqualTo(100L));
        Assert.That(zombie.OnKineticHit(111L), Is.True);
        Assert.That(zombie.LastKineticHitFeedbackTime, Is.EqualTo(111L));
    }

    [Test]
    public void TestTheFirstHitAtGameTimeZeroStartsFeedback() {
        // The field starts at Integer.MIN_VALUE, so 0 - MIN_VALUE is far past ten.
        ClientEntity zombie = new() { Id = 1, Type = EntityType.Zombie };
        Assert.That(zombie.OnKineticHit(0L), Is.True);
        Assert.That(zombie.TicksSinceLastKineticHitFeedback(0L, 0.0F), Is.EqualTo(0.0F));
    }
}
