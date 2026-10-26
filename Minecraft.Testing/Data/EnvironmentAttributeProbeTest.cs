using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Vec;

namespace Minecraft.Testing.Data;

/// <summary>
/// <c>EnvironmentAttributeProbe</c>: a value is held for the tick it was first asked for in and lerped from the last
/// tick's by the attribute type's partial tick lerp.
/// </summary>
public class EnvironmentAttributeProbeTest {
    private sealed class NoBiomes : IEnvironmentBiomeSource {
        public BakedAttributeMap NoiseBiomeAtQuart(int quartX, int quartY, int quartZ) => BakedAttributeMap.Empty;

        public BakedAttributeMap BiomeAt(int x, int y, int z) => BakedAttributeMap.Empty;
    }

    private float _sunAngle, _fogEnd;
    private MoonPhase _moonPhase;
    private EnvironmentAttributeSystem _system = null!;
    private readonly EnvironmentAttributeProbe _probe = new();

    [SetUp]
    public void Build() {
        _system = EnvironmentAttributeSystem.CreateBuilder()
            .AddTimeBasedLayer(EnvironmentAttribute.VisualSunAngle, (_, _) => _sunAngle)
            .AddTimeBasedLayer(EnvironmentAttribute.VisualFogEndDistance, (_, _) => _fogEnd)
            .AddTimeBasedLayer(EnvironmentAttribute.VisualMoonPhase, (_, _) => _moonPhase)
            .Build();
        _probe.Reset();
    }

    private void Tick() {
        _system.InvalidateTickCache();
        _probe.Tick(_system, new NoBiomes(), new Vec3<double>(0.5, 64.0, 0.5));
    }

    [Test]
    public void AnglesTakeTheShortWayRound() {
        _sunAngle = 350.0F;
        Tick();
        Assert.That(_probe.GetValue(EnvironmentAttribute.VisualSunAngle, 0.3F), Is.EqualTo(350.0F));
        _sunAngle = 10.0F;
        Tick();
        Assert.That(_probe.GetValue(EnvironmentAttribute.VisualSunAngle, 0.5F), Is.EqualTo(360.0F));
    }

    [Test]
    public void FloatsLerpAndStepsJump() {
        _fogEnd = 100.0F;
        _moonPhase = MoonPhase.FullMoon;
        Tick();
        _probe.GetValue(EnvironmentAttribute.VisualFogEndDistance, 0.0F);
        _probe.GetValue(EnvironmentAttribute.VisualMoonPhase, 0.0F);
        _fogEnd = 200.0F;
        _moonPhase = MoonPhase.NewMoon;
        Tick();
        Assert.Multiple(() => {
            Assert.That(_probe.GetValue(EnvironmentAttribute.VisualFogEndDistance, 0.25F), Is.EqualTo(125.0F));
            Assert.That(_probe.GetValue(EnvironmentAttribute.VisualMoonPhase, 0.0F), Is.EqualTo(MoonPhase.NewMoon));
        });
    }

    [Test]
    public void AValueIsHeldForItsTick() {
        _fogEnd = 100.0F;
        Tick();
        _probe.GetValue(EnvironmentAttribute.VisualFogEndDistance, 0.0F);
        _fogEnd = 200.0F;
        Assert.That(_probe.GetValue(EnvironmentAttribute.VisualFogEndDistance, 1.0F), Is.EqualTo(100.0F));
    }

    [Test]
    public void AnAttributeNobodyAskedForIsForgotten() {
        _fogEnd = 100.0F;
        Tick();
        _probe.GetValue(EnvironmentAttribute.VisualFogEndDistance, 0.0F);
        Tick();
        Tick();
        _fogEnd = 300.0F;
        Tick();
        Assert.That(_probe.GetValue(EnvironmentAttribute.VisualFogEndDistance, 0.0F), Is.EqualTo(300.0F));
    }
}
