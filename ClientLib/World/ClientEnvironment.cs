using System.Numerics;
using ClientLib.Entities;
using Minecraft.Data.DimensionType;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Timelines;
using Minecraft.Schemas;
using EntityClass = Minecraft.Data.Generated.EntityClass;
using EnvironmentAttribute = Minecraft.Data.Generated.EnvironmentAttribute;

namespace ClientLib.World;

/// <summary>
/// What <c>ClientLevel</c> keeps of the environment: its <c>EnvironmentAttributeSystem</c> with the two layers the
/// client adds over the default ones, the lightning's sky flash, the end's flashes and <c>Level.getSkyDarken</c>.
/// </summary>
public sealed class ClientEnvironment : IClockSource, IWeatherAccess, IEnvironmentBiomeSource {
    private static readonly Vector3 FlashColor = new(0.8F, 0.8F, 1.0F);

    private readonly ClientLevel _level;
    private EnvironmentAttributeSystem? _attributes;
    private readonly Dictionary<ClientEntity, Bolt> _bolts = new(ReferenceEqualityComparer.Instance);
    private readonly List<ClientEntity> _gone = [];
    private readonly Random _random = new();

    public ClientEnvironment(ClientLevel level) {
        _level = level;
        EndFlash = level.DimensionType.Skybox == Skybox.End ? new EndFlashState() : null;
    }

    /// <summary>Built on first use, so the timeline tags the server sends during configuration are in.</summary>
    public EnvironmentAttributeSystem Attributes => _attributes ??= Build();

    /// <summary><c>ClientLevel.skyFlashTime</c>: two while a lightning bolt is in one of its flashes, counting down after.</summary>
    public int SkyFlashTime { get; set; }

    /// <summary>The <c>hideLightningFlash</c> option, which <c>getSkyFlashTime</c> answers zero for.</summary>
    public bool HideLightningFlash { get; set; }

    /// <summary><c>ClientLevel.endFlashState</c>, for a dimension with the end's sky.</summary>
    public EndFlashState? EndFlash { get; }

    /// <summary><c>Level.getSkyDarken</c>: how many levels the sky light is taken down by, set at the start of each tick.</summary>
    public int SkyDarken { get; private set; }

    /// <summary>A rain and thunder level the weather layers read in place of the level's, for drawing a forced weather.</summary>
    public (float Rain, float Thunder)? WeatherOverride { get; set; }

    public float RainLevel => WeatherOverride?.Rain ?? _level.RainLevel;

    public float ThunderLevel => WeatherOverride?.Thunder ?? _level.ThunderLevel * _level.RainLevel;

    public long TotalTicks(Identifier clock) => _level.Clocks.GetTotalTicks(clock);

    public BakedAttributeMap NoiseBiomeAtQuart(int quartX, int quartY, int quartZ) =>
        BakedAttributeMap.Of(BiomeClimate.NoiseBiome(_level, quartX, quartY, quartZ).Attributes, _level.Registry);

    public BakedAttributeMap BiomeAt(int x, int y, int z) => BakedAttributeMap.Of(BiomeClimate.Biome(_level, x, y, z).Attributes, _level.Registry);

    private int EffectiveSkyFlashTime => HideLightningFlash ? 0 : SkyFlashTime;

    /// <summary><c>ClientLevel.addEnvironmentAttributeLayers</c>: the default layers, then lightning lighting the sky.</summary>
    private EnvironmentAttributeSystem Build() {
        IEnumerable<ITimeline> timelines = BakedTimeline.HolderSet(_level.DimensionType.Timelines, _level.Registry, tag =>
            (_level.TimelineTag?.Invoke(tag) ?? []).Where(id => _level.Registry.Timelines.Contains(id)).Select(id => _level.Registry.Timelines[id]));
        EnvironmentAttributeSystem.Builder builder = EnvironmentAttributeSystem.CreateBuilder()
            .AddDefaultLayers(_level.DimensionType, _level.Registry, this, timelines, this, _level.CanHaveWeather ? this : null);
        builder.AddTimeBasedLayer(EnvironmentAttribute.VisualSkyColor,
            (skyColor, _) => EffectiveSkyFlashTime > 0 ? ArgbVectors.SrgbLerp(0.22F, skyColor, FlashColor) : skyColor);
        builder.AddTimeBasedLayer(EnvironmentAttribute.VisualSkyLightFactor, (skyFactor, _) => EffectiveSkyFlashTime > 0 ? 1.0F : skyFactor);
        return builder.Build();
    }

    /// <summary><c>Level.updateSkyBrightness</c>, the first thing <c>ClientLevel.tick</c> does.</summary>
    public void UpdateSkyBrightness() => SkyDarken = (int)(15.0F - Attributes.GetDimensionValue(EnvironmentAttribute.GameplaySkyLightLevel));

    /// <summary>The rest of <c>ClientLevel.tick</c> that is the environment's, after the level's time has moved.</summary>
    public void Tick() {
        if (SkyFlashTime > 0) {
            SkyFlashTime--;
        }
        EndFlash?.Tick(_level.DefaultClockTime);
        Attributes.InvalidateTickCache();
    }

    private sealed class Bolt {
        public int Life = 2;
        public int Flashes;
    }

    /// <summary>
    /// The client half of <c>LightningBolt.tick</c> for every bolt, run where the entities tick: a bolt keeps the sky
    /// flash at two while it is in one of its one to three flashes, with a pause of up to ten ticks between them, drawn
    /// from this client's own random as vanilla draws from the client entity's. The server only says when the bolt
    /// arrives and when it is gone.
    /// </summary>
    public void TickLightning(IReadOnlyDictionary<int, ClientEntity> entities) {
        foreach (ClientEntity entity in entities.Values) {
            if (!entity.Is(EntityClass.LightningBolt)) {
                continue;
            }
            if (!_bolts.TryGetValue(entity, out Bolt? bolt)) {
                bolt = new Bolt { Flashes = _random.Next(3) + 1 };
                _bolts[entity] = bolt;
            }
            bolt.Life--;
            if (bolt.Life < 0 && bolt.Flashes > 0 && bolt.Life < -_random.Next(10)) {
                bolt.Flashes--;
                bolt.Life = 1;
            }
            if (bolt.Life >= 0) {
                SkyFlashTime = 2;
            }
        }
        foreach (ClientEntity tracked in _bolts.Keys) {
            if (!entities.TryGetValue(tracked.Id, out ClientEntity? current) || current != tracked) {
                _gone.Add(tracked);
            }
        }
        foreach (ClientEntity gone in _gone) {
            _bolts.Remove(gone);
        }
        _gone.Clear();
    }
}
