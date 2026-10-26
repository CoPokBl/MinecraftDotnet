using Newtonsoft.Json.Linq;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>
/// An animated texture from its <c>.mcmeta</c>: the frames cut from the image, and the order and
/// ticks to show them for, as <c>SpriteContents.createAnimatedTexture</c> reads them.
/// </summary>
public sealed record TextureAnimation(TextureImage[] Frames, (int Index, int Time)[] Sequence, bool Interpolate) {
    /// <summary>The image the frames were cut from, which vanilla mipmaps whole; null for frames drawn one by one.</summary>
    public TextureImage? Strip { get; init; }

    /// <summary>Frames across a row of <see cref="Strip"/>.</summary>
    public int Columns { get; init; } = 1;

    public Rendering.TextureMipSettings Mip { get; init; } = Rendering.TextureMipSettings.Default;

    public bool IsItem { get; init; }

    private TextureImage[][]? _levels;

    /// <summary>
    /// A frame's mipmap levels at <paramref name="size"/> square, cut from the strip's levels as vanilla's frames are.
    /// Frames that are not that size, or have no strip, are each scaled to it and mipped alone, which differs from
    /// vanilla only where the flood fill or the alpha coverage would have reached across a frame's edge.
    /// </summary>
    public TextureImage[] FrameLevels(int frame, int size, int levels) {
        if (_levels == null) {
            int width = Frames[0].Width, height = Frames[0].Height;
            if (Strip is { } strip && width == size && height == size) {
                TextureImage[] stripLevels = Rendering.Mipmaps.Generate(strip, Mip, IsItem, levels);
                _levels = new TextureImage[Frames.Length][];
                for (int i = 0; i < Frames.Length; i++) {
                    _levels[i] = new TextureImage[levels];
                    for (int level = 0; level < levels; level++) {
                        _levels[i][level] = stripLevels[level].Region((i % Columns * width) >> level, (i / Columns * height) >> level,
                            Math.Max(1, width >> level), Math.Max(1, height >> level));
                    }
                }
            }
            else {
                _levels = Frames.Select(f => Rendering.Mipmaps.Generate(f.Resized(size), Mip, IsItem, levels)).ToArray();
            }
        }
        return _levels[frame];
    }

    /// <summary>The animation in a texture, or null for a still one; frames are square unless the metadata sizes them.</summary>
    public static TextureAnimation? Read(TextureImage image, byte[]? meta) {
        if (Section(meta) is not { } animation) {
            return null;
        }
        int width = animation.Value<int?>("width") ?? Math.Min(image.Width, image.Height);
        int height = animation.Value<int?>("height") ?? Math.Min(image.Width, image.Height);
        if (width <= 0 || height <= 0 || image.Width % width != 0 || image.Height % height != 0) {
            return null;
        }
        int columns = image.Width / width, total = columns * (image.Height / height);
        TextureImage[] frames = new TextureImage[total];
        for (int i = 0; i < total; i++) {
            frames[i] = image.Region(i % columns * width, i / columns * height, width, height);
        }

        int frameTime = animation.Value<int?>("frametime") ?? 1;
        List<(int, int)> sequence = [];
        if (animation["frames"] is JArray listed) {
            foreach (JToken entry in listed) {
                (int index, int time) = entry is JObject frame
                    ? (frame.Value<int>("index"), frame.Value<int?>("time") ?? frameTime)
                    : (entry.Value<int>(), frameTime);
                // Out of range or zero length frames are dropped, with a warning in the game's log.
                if (index >= 0 && index < total && time > 0) {
                    sequence.Add((index, time));
                }
            }
        }
        else {
            for (int i = 0; i < total; i++) {
                sequence.Add((i, Math.Max(1, frameTime)));
            }
        }
        return sequence.Count <= 1
            ? null
            : new TextureAnimation(frames, sequence.ToArray(), animation.Value<bool?>("interpolate") ?? false) {
                Strip = image, Columns = columns, Mip = Rendering.TextureMipSettings.Read(meta)
            };
    }

    /// <summary>A <c>.mcmeta</c>'s <c>animation</c> section; null when there is none or the file does not parse.</summary>
    public static JObject? Section(byte[]? meta) {
        if (meta == null) {
            return null;
        }
        try {
            return JObject.Parse(System.Text.Encoding.UTF8.GetString(meta))["animation"] as JObject;
        }
        catch (Newtonsoft.Json.JsonException) {
            return null;
        }
    }
}
