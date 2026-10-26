using System.Globalization;
using System.IO.Compression;
using System.Numerics;
using System.Reflection;
using Minecraft.Data.DimensionType;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Generated;
using Minecraft.Data.Timelines;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Tags;
using Minecraft.Schemas.Vec;
using NBT;

namespace Minecraft.Testing.Data;

/// <summary>
/// Replays what the real <c>EnvironmentAttributeSystem</c> said every attribute comes to, written by
/// <c>Conformance/environmentattributes.sh</c>, through the port: the dimension, biome, timeline and weather layers,
/// with and without the camera's blend of the biomes round the position.
/// </summary>
public class EnvironmentAttributeConformanceTest {
    private static readonly string FixturePath =
        Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "vanilla-environment-attributes.txt.gz");

    private static readonly MinecraftRegistry Reg = VanillaRegistry.Data;

    private sealed class Level : IClockSource, IWeatherAccess, IEnvironmentBiomeSource {
        public long Ticks;
        public float RainLevel { get; set; }
        public float ThunderLevel { get; set; }
        public required BakedAttributeMap[] Biomes;
        public required BakedAttributeMap Plains;

        public long TotalTicks(Identifier clock) => Ticks;

        /// <summary>The harness's layout: blocks of three by three quarts, five high, with a lone biome far out east and south.</summary>
        public BakedAttributeMap NoiseBiomeAtQuart(int quartX, int quartY, int quartZ) {
            if (quartX >= 2000 && quartZ >= 2000) {
                return Plains;
            }
            int index = Mth.FloorMod(FloorDiv(quartX, 3) * 7 + FloorDiv(quartZ, 3) * 13 + FloorDiv(quartY, 5) * 3, Biomes.Length);
            return Biomes[index];
        }

        public BakedAttributeMap BiomeAt(int x, int y, int z) => throw new InvalidOperationException("No attribute read here wants the zoomed biome");

        private static int FloorDiv(int a, int b) => (int)Math.Floor((double)a / b);
    }

    [Test]
    public void EveryAttributeMatchesVanilla() {
        if (!File.Exists(FixturePath)) {
            Assert.Ignore("No fixture; run Conformance/environmentattributes.sh");
        }
        using StreamReader reader = new(new GZipStream(File.OpenRead(FixturePath), CompressionMode.Decompress));
        string[] header = reader.ReadLine()!.Split(' ');
        Identifier[] biomeIds = Reg.Biomes.All.Select(b => b.Identifier).OrderBy(id => id.ToString(), StringComparer.Ordinal).ToArray();
        Assert.That(header[1..], Is.EqualTo(biomeIds.Select(id => id.ToString()).ToArray()), "The biome layout has to be over the same biomes in the same order");

        Level level = new() {
            Biomes = biomeIds.Select(id => BakedAttributeMap.Of(Reg.Biomes[id].Attributes, Reg)).ToArray(),
            Plains = BakedAttributeMap.Of(Reg.Biomes[Biome.Plains.Identifier].Attributes, Reg)
        };
        Dictionary<string, EnvironmentAttributeSystem> systems = [];
        EnvironmentAttributeSystem? system = null;
        Vec3<double> pos = default;
        SpatialAttributeInterpolator interpolator = new();
        int cases = 0, values = 0;
        List<string> failures = [];
        string? currentCase = null;
        while (reader.ReadLine() is { } line) {
            string[] parts = line.Split(' ');
            if (parts[0] == "case") {
                currentCase = line;
                cases++;
                if (!systems.TryGetValue(parts[1], out system)) {
                    system = Build(parts[1], level);
                    systems[parts[1]] = system;
                }
                level.Ticks = long.Parse(parts[2]);
                level.RainLevel = BitConverter.Int32BitsToSingle((int)uint.Parse(parts[3], NumberStyles.HexNumber));
                level.ThunderLevel = BitConverter.Int32BitsToSingle((int)uint.Parse(parts[4], NumberStyles.HexNumber));
                pos = new Vec3<double>(Double(parts[5]), Double(parts[6]), Double(parts[7]));
                system.InvalidateTickCache();
                interpolator.Clear();
                GaussianSampler.Sample(new Vec3<double>(pos.X * 0.25, pos.Y * 0.25, pos.Z * 0.25), level.NoiseBiomeAtQuart,
                    (weight, biome) => interpolator.Accumulate(weight, biome));
                continue;
            }
            IEnvironmentAttribute attribute = Reg.EnvironmentAttributes[parts[0]];
            string[] ours = (string[])ReadMethod.MakeGenericMethod(attribute.GetType().GetGenericArguments()[0])
                .Invoke(null, [attribute, system!, pos, interpolator])!;
            for (int i = 1; i < parts.Length; i++) {
                values++;
                if (ours[i - 1] != parts[i] && failures.Count < 40) {
                    failures.Add($"{currentCase}\n  {parts[0]} [{(i == 1 ? "blended" : "plain")}] vanilla {parts[i]} ours {ours[i - 1]}");
                }
            }
        }
        Assert.That(failures, Is.Empty, $"{cases} cases, {values} values");
        TestContext.Out.WriteLine($"{cases} cases, {values} values, all equal");
    }

    private static double Double(string hex) => BitConverter.Int64BitsToDouble((long)ulong.Parse(hex, NumberStyles.HexNumber));

    private static EnvironmentAttributeSystem Build(string dimension, Level level) {
        IDimensionType type = Reg.DimensionTypes[dimension];
        bool canHaveWeather = type.HasSkyLight && !type.HasCeiling && dimension != "minecraft:the_end";
        IEnumerable<ITimeline> timelines = BakedTimeline.HolderSet(type.Timelines, Reg,
            tag => ((IRegistryTag<ITimeline>)Reg.Timelines.Tags[tag]).GetValues(Reg));
        return EnvironmentAttributeSystem.CreateBuilder()
            .AddDefaultLayers(type, Reg, level, timelines, level, canHaveWeather ? level : null)
            .Build();
    }

    private static readonly MethodInfo ReadMethod = typeof(EnvironmentAttributeConformanceTest).GetMethod(nameof(Read), BindingFlags.NonPublic | BindingFlags.Static)!;

    private static string[] Read<T>(EnvironmentAttribute<T> attribute, EnvironmentAttributeSystem system, Vec3<double> pos,
        SpatialAttributeInterpolator interpolator) =>
        attribute.Positional
            ? [Encode(system.GetValue(attribute, pos, interpolator)), Encode(system.GetValue(attribute, pos))]
            : [Encode(system.GetDimensionValue(attribute))];

    private static string Bits(float value) => ((uint)BitConverter.SingleToInt32Bits(value)).ToString("x");

    private static string Bits(double value) => ((ulong)BitConverter.DoubleToInt64Bits(value)).ToString("x");

    private static string Sound(SoundEvent sound) => sound.Type.Identifier.ToString();

    private static string Music(Music? music) =>
        music == null ? "-" : $"{Sound(music.Sound)}/{music.MinDelay}/{music.MaxDelay}/{(music.ReplaceCurrentMusic ? "true" : "false")}";

    private static string Encode(object? value) => value switch {
        float number => Bits(number),
        bool b => b ? "true" : "false",
        Vector3 v => $"{Bits(v.X)},{Bits(v.Y)},{Bits(v.Z)}",
        Vector4 v => $"{Bits(v.X)},{Bits(v.Y)},{Bits(v.Z)},{Bits(v.W)}",
        TriState state => state.ToProtocolString(),
        MoonPhase phase => phase.ToProtocolString(),
        Identifier id => id.ToString(),
        ParticleValue particle => particle.Type.ToString(),
        BedRule rule => $"{rule.CanSleep.ToProtocolString()}|{rule.CanSetSpawn.ToProtocolString()}|{(rule.DestroyOnUse ? "true" : "false")}|" +
                        $"{(rule.DestroyOnLeave ? "true" : "false")}|{(rule.ErrorMessage != null ? "true" : "false")}",
        BackgroundMusic music => $"{Music(music.Default)}|{Music(music.Creative)}|{Music(music.Underwater)}",
        AmbientSounds sounds => $"{(sounds.Loop == null ? "-" : Sound(sounds.Loop))}|" +
                                $"{(sounds.Mood is { } mood ? $"{Sound(mood.Sound)}/{mood.TickDelay}/{mood.BlockSearchExtent}/{Bits(mood.Offset)}" : "-")}|" +
                                string.Join(";", sounds.Additions.Select(a => $"{Sound(a.Sound)}/{Bits(a.TickChance)}")),
        IReadOnlyList<AmbientParticle> list => list.Count == 0 ? "[]" : string.Join(";", list.Select(p => $"{p.Particle.Type}@{Bits(p.Probability)}")),
        _ => throw new ArgumentException($"Cannot encode {value?.GetType()}")
    };
}
