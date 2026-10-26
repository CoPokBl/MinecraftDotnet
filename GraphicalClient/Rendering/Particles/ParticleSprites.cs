using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities;
using Minecraft.Data.Generated;
using Minecraft.Data.Particles;
using Minecraft.Schemas;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Rendering.Particles;

/// <summary>
/// <c>ParticleResources</c>' sprite sets: each particle type's frames, packed into the entity atlas. A pack's
/// <c>particles/&lt;type&gt;.json</c> lists the frames as <c>textures/particle</c> sprites; a type the packs say
/// nothing about draws the built in art.
/// </summary>
public sealed class ParticleSprites {
    private readonly EntityTexture[][] _sets;

    public ParticleSprites(EntityTextures textures, ResourcePackSource? pack) {
        int count = (int)VanillaRegistry.Data.Particles.Count;
        _sets = new EntityTexture[count][];
        HashSet<string> missing = [];
        for (int id = 0; id < count; id++) {
            IParticle type = VanillaRegistry.Data.Particles[id];
            List<Identifier>? sprites = pack == null ? null : Description(pack, type.Identifier);
            if (sprites != null) {
                _sets[id] = sprites.Select(sprite => textures.GetNow($"particle:{sprite}", () => {
                    TextureImage? image = pack!.LoadFirstFrame($"assets/{sprite.Namespace}/textures/particle/{sprite.Key}.png");
                    if (image == null) {
                        lock (missing) {
                            missing.Add(sprite.ToString());
                        }
                    }
                    return image ?? EntityTextures.MissingImage();
                }) ?? textures.Missing).ToArray();
                continue;
            }
            TextureImage[] frames = DevArtParticles.Frames(type.Identifier);
            _sets[id] = frames.Select((frame, i) => textures.GetNow($"particle-art:{type.Identifier}:{i}", () => frame) ?? textures.Missing).ToArray();
        }
        if (missing.Count > 0) {
            Console.WriteLine($"Missing particle sprites: {string.Join(",", missing.Order())}");
        }
    }

    /// <summary><c>ParticleDescription.fromJson</c>: the frames a pack lists for a type, or null when no pack describes it.</summary>
    private static List<Identifier>? Description(ResourcePackSource pack, Identifier type) {
        byte[]? data = pack.ReadFile($"assets/{type.Namespace}/particles/{type.Key}.json");
        if (data == null) {
            return null;
        }
        try {
            if (JObject.Parse(System.Text.Encoding.UTF8.GetString(data))["textures"] is not JArray list) {
                return [];
            }
            return list.Select(texture => Identifier.Parse(texture.Value<string>()!)).ToList();
        }
        catch (Exception e) when (e is Newtonsoft.Json.JsonException or FormatException or ArgumentException) {
            Console.WriteLine($"Particle description {type}: {e.Message}");
            return null;
        }
    }

    /// <summary>A type's frames, empty when it has none.</summary>
    public EntityTexture[] Set(int type) => (uint)type < (uint)_sets.Length ? _sets[type] : [];
}
