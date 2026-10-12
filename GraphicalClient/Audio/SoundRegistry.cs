using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Schemas;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Audio;

/// <summary>
/// Vanilla's <c>Sound</c>: one file a sound event can play, and how. <see cref="Volume"/> and
/// <see cref="Pitch"/> scale whatever the instance asks for.
/// </summary>
public sealed record Sound(Identifier Location, float Volume = 1, float Pitch = 1, int Weight = 1, bool Stream = false, bool Preload = false,
    int AttenuationDistance = 16) {
    /// <summary><c>SoundManager.EMPTY_SOUND</c>: what an event resolves to when it has nothing to play.</summary>
    public static readonly Sound Empty = new("minecraft:empty");

    /// <summary><c>SoundManager.INTENTIONALLY_EMPTY_SOUND</c>, which plays nothing and warns of nothing.</summary>
    public static readonly Sound IntentionallyEmpty = new("minecraft:intentionally_empty");

    /// <summary>The namespace the built in art's sounds live under, never a pack's.</summary>
    public const string DevNamespace = "mcdotnet_dev";

    /// <summary>Where a pack keeps a sound file.</summary>
    public static string FileOf(Identifier location) => $"assets/{location.Namespace}/sounds/{location.Key}.ogg";
}

/// <summary>Vanilla's <c>Weighted&lt;Sound&gt;</c>: a file, or another event to pick from.</summary>
public interface IWeightedSound {
    int Weight { get; }
    Sound GetSound(LegacyRandom random);
}

/// <summary>Vanilla's <c>WeighedSoundEvents</c>: what one sound event can play, picked by weight.</summary>
public sealed class WeighedSoundEvents(Identifier location) : IWeightedSound {
    private readonly List<IWeightedSound> _list = [];

    public Identifier Location { get; } = location;

    public int Weight => _list.Sum(s => s.Weight);

    public Sound GetSound(LegacyRandom random) {
        int weight = Weight;
        if (_list.Count == 0 || weight == 0) {
            return Sound.Empty;
        }
        int index = random.NextInt(weight);
        foreach (IWeightedSound weighted in _list) {
            index -= weighted.Weight;
            if (index < 0) {
                return weighted.GetSound(random);
            }
        }
        return Sound.Empty;
    }

    public void Add(IWeightedSound sound) => _list.Add(sound);
}

/// <summary>A sound that is itself a file.</summary>
public sealed record FileSound(Sound Sound) : IWeightedSound {
    public int Weight => Sound.Weight;
    public Sound GetSound(LegacyRandom random) => Sound;
}

/// <summary>
/// The sound events a pack stack defines, from every pack's <c>sounds.json</c> lowest first, as
/// <c>SoundManager.Preparations</c> builds them: a later pack adds to an event unless it says
/// <c>replace</c>. An event no pack defines falls back to the built in art.
/// </summary>
public sealed class SoundRegistry {
    private readonly Dictionary<Identifier, WeighedSoundEvents> _registry = new();
    private readonly Dictionary<Identifier, WeighedSoundEvents> _dev = new();

    public SoundRegistry(PackFiles? packs) {
        if (packs != null) {
            Load(packs);
        }
    }

    public int Count => _registry.Count;

    /// <summary>The event's sounds; the built in art's when no pack defines it.</summary>
    public WeighedSoundEvents? Get(Identifier location) {
        if (location == Sound.IntentionallyEmpty.Location) {
            return null;
        }
        if (_registry.TryGetValue(location, out WeighedSoundEvents? events)) {
            return events;
        }
        if (!_dev.TryGetValue(location, out events)) {
            events = new WeighedSoundEvents(location);
            events.Add(new FileSound(new Sound(new Identifier(Sound.DevNamespace, location.Namespace + "/" + location.Key))));
            _dev[location] = events;
        }
        return events;
    }

    private void Load(PackFiles packs) {
        HashSet<string> namespaces = ["minecraft"];
        foreach (string path in packs.Paths("assets/")) {
            string[] parts = path.Split('/');
            if (parts.Length == 3 && parts[2] == "sounds.json") {
                namespaces.Add(parts[1]);
            }
        }
        foreach (string ns in namespaces) {
            foreach (byte[] file in packs.ReadEach($"assets/{ns}/sounds.json")) {
                JObject json;
                try {
                    json = JObject.Parse(System.Text.Encoding.UTF8.GetString(file));
                }
                catch (Newtonsoft.Json.JsonException e) {
                    Console.Error.WriteLine($"Skipping a broken {ns}/sounds.json: {e.Message}");
                    continue;
                }
                foreach ((string name, JToken? token) in json) {
                    if (token is JObject entry) {
                        HandleRegistration(packs, new Identifier(ns, name), entry);
                    }
                }
            }
        }
    }

    /// <summary><c>Preparations.handleRegistration</c> with <c>SoundEventRegistrationSerializer</c>'s reading.</summary>
    private void HandleRegistration(PackFiles packs, Identifier location, JObject entry) {
        bool replace = entry.Value<bool?>("replace") ?? false;
        if (!_registry.TryGetValue(location, out WeighedSoundEvents? registration) || replace) {
            registration = new WeighedSoundEvents(location);
            _registry[location] = registration;
        }
        if (entry["sounds"] is not JArray sounds) {
            return;
        }
        foreach (JToken element in sounds) {
            (Sound sound, bool isEvent) = element.Type == JTokenType.String
                ? (new Sound(Identifier.Parse(element.ToString())), false)
                : ReadSound((JObject)element);
            if (!isEvent) {
                // validateSoundResource: a file no pack has is left out rather than played as silence.
                if (!packs.Exists(Sound.FileOf(sound.Location))) {
                    continue;
                }
                registration.Add(new FileSound(sound));
            }
            else {
                registration.Add(new EventReference(this, sound));
            }
        }
    }

    private static (Sound, bool IsEvent) ReadSound(JObject json) {
        Identifier name = Identifier.Parse(json.Value<string>("name")!);
        bool isEvent = (json.Value<string>("type") ?? "file") == "event";
        return (new Sound(name,
            json.Value<float?>("volume") ?? 1.0F,
            json.Value<float?>("pitch") ?? 1.0F,
            json.Value<int?>("weight") ?? 1,
            json.Value<bool?>("stream") ?? false,
            json.Value<bool?>("preload") ?? false,
            json.Value<int?>("attenuation_distance") ?? 16), isEvent);
    }

    /// <summary>
    /// An entry that plays another event's pick, its volume and pitch multiplied by this entry's: the
    /// anonymous <c>Weighted</c> in <c>handleRegistration</c>. Resolved when played, so it sees events
    /// defined after it.
    /// </summary>
    private sealed class EventReference(SoundRegistry registry, Sound sound) : IWeightedSound {
        public int Weight => registry._registry.TryGetValue(sound.Location, out WeighedSoundEvents? target) ? target.Weight : 0;

        public Sound GetSound(LegacyRandom random) {
            if (!registry._registry.TryGetValue(sound.Location, out WeighedSoundEvents? target)) {
                return Sound.Empty;
            }
            Sound wrapped = target.GetSound(random);
            return new Sound(wrapped.Location, wrapped.Volume * sound.Volume, wrapped.Pitch * sound.Pitch, sound.Weight,
                wrapped.Stream || sound.Stream, wrapped.Preload, wrapped.AttenuationDistance);
        }
    }
}
