using GraphicalClient.Assets.ResourcePacks;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Rendering;

/// <summary><c>MipmapStrategy</c>: how a texture's smaller levels are made.</summary>
public enum MipmapStrategy {
    Auto,
    Mean,
    Cutout,
    StrictCutout,
    DarkCutout
}

/// <summary>What a texture's <c>.mcmeta</c> <c>texture</c> section says about its mipmaps.</summary>
public readonly record struct TextureMipSettings(MipmapStrategy Strategy, float AlphaCutoffBias) {
    public static readonly TextureMipSettings Default = new(MipmapStrategy.Auto, 0.0F);

    /// <summary>The settings in a <c>.mcmeta</c>, or the defaults when it has none or does not parse.</summary>
    public static TextureMipSettings Read(byte[]? meta) {
        if (meta == null) {
            return Default;
        }
        try {
            if (JObject.Parse(System.Text.Encoding.UTF8.GetString(meta))["texture"] is not JObject texture) {
                return Default;
            }
            MipmapStrategy strategy = texture.Value<string>("mipmap_strategy") switch {
                "mean" => MipmapStrategy.Mean,
                "cutout" => MipmapStrategy.Cutout,
                "strict_cutout" => MipmapStrategy.StrictCutout,
                "dark_cutout" => MipmapStrategy.DarkCutout,
                _ => MipmapStrategy.Auto
            };
            return new TextureMipSettings(strategy, texture.Value<float?>("alpha_cutoff_bias") ?? 0.0F);
        }
        catch (Newtonsoft.Json.JsonException) {
            return Default;
        }
    }
}

/// <summary>
/// <c>MipmapGenerator.generateMipLevels</c> and what it calls: the transparent texels of a cut out texture take the
/// colour of the nearest opaque one, each level averages four texels in linear light, and a cut out texture's alpha
/// is rescaled level by level so the alpha test keeps as much of it as it keeps of the full size image. A plain box
/// filter instead averages the transparent texels' colour in and lets the alpha fade, so distant leaves and flames
/// come out dark and thin.
/// </summary>
public static class Mipmaps {
    private static readonly short[] SrgbToLinear = BuildSrgbToLinear();
    private static readonly byte[] LinearToSrgb = BuildLinearToSrgb();

    private static readonly (int X, int Y)[] Directions = [(1, 0), (-1, 0), (0, 1), (0, -1)];

    private static short[] BuildSrgbToLinear() {
        short[] lookup = new short[256];
        for (int i = 0; i < lookup.Length; i++) {
            float channel = i / 255.0F;
            float linear = channel >= 0.04045F ? (float)Math.Pow((channel + 0.055) / 1.055, 2.4) : channel / 12.92F;
            lookup[i] = (short)JavaRound(linear * 1023.0F);
        }
        return lookup;
    }

    private static byte[] BuildLinearToSrgb() {
        byte[] lookup = new byte[1024];
        for (int i = 0; i < lookup.Length; i++) {
            float channel = i / 1023.0F;
            float srgb = channel >= 0.0031308F ? (float)(1.055 * Math.Pow(channel, 0.4166666666666667) - 0.055) : 12.92F * channel;
            lookup[i] = (byte)JavaRound(srgb * 255.0F);
        }
        return lookup;
    }

    /// <summary>Java's <c>Math.round(float)</c>, which rounds halves up rather than to even.</summary>
    private static int JavaRound(float value) => (int)MathF.Floor(value + 0.5F);

    /// <param name="image">The whole image as the pack has it: every frame of an animated strip, which vanilla mips as one.</param>
    /// <param name="isItem">The sprite's path starts with <c>item/</c>, whose transparent texels are left as they are.</param>
    /// <param name="levels">How many levels to return, the full size image first.</param>
    public static TextureImage[] Generate(TextureImage image, TextureMipSettings settings, bool isItem, int levels) {
        MipmapStrategy strategy = settings.Strategy;
        if (strategy == MipmapStrategy.Auto) {
            strategy = HasTransparent(image) ? MipmapStrategy.Cutout : MipmapStrategy.Mean;
        }
        TextureImage top = image;
        if (!isItem) {
            if (strategy is MipmapStrategy.Cutout or MipmapStrategy.StrictCutout) {
                top = Solidify(image);
            }
            else if (strategy == MipmapStrategy.DarkCutout) {
                top = FillEmptyAreasWithDarkColor(image);
            }
        }

        TextureImage[] result = new TextureImage[levels];
        result[0] = top;
        bool isCutoutMip = strategy is MipmapStrategy.Cutout or MipmapStrategy.StrictCutout or MipmapStrategy.DarkCutout;
        float cutoutRef = strategy == MipmapStrategy.StrictCutout ? 0.3F : 0.5F;
        float originalCoverage = isCutoutMip ? AlphaTestCoverage(top, cutoutRef, 1.0F) : 0.0F;
        for (int level = 1; level < levels; level++) {
            TextureImage last = result[level - 1];
            int width = last.Width >> 1, height = last.Height >> 1;
            byte[] rgba = new byte[width * height * 4];
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    int i1 = (y * 2 * last.Width + x * 2) * 4, i2 = i1 + 4, i3 = i1 + last.Width * 4, i4 = i3 + 4;
                    int at = (y * width + x) * 4;
                    if (strategy == MipmapStrategy.DarkCutout) {
                        DarkenedAlphaBlend(last.Rgba, i1, i2, i3, i4, rgba, at);
                    }
                    else {
                        MeanLinear(last.Rgba, i1, i2, i3, i4, rgba, at);
                    }
                }
            }
            result[level] = new TextureImage(width, height, rgba);
            if (isCutoutMip) {
                ScaleAlphaToCoverage(result[level], originalCoverage, cutoutRef, settings.AlphaCutoffBias);
            }
        }
        return result;
    }

    /// <summary>Whether any texel is fully transparent, the half of <c>NativeImage.computeTransparency</c> this reads.</summary>
    private static bool HasTransparent(TextureImage image) {
        for (int i = 3; i < image.Rgba.Length; i += 4) {
            if (image.Rgba[i] == 0) {
                return true;
            }
        }
        return false;
    }

    /// <summary><c>ARGB.meanLinear</c>: alpha averaged as stored, colour averaged through the 10 bit linear table.</summary>
    private static void MeanLinear(byte[] from, int i1, int i2, int i3, int i4, byte[] to, int at) {
        for (int c = 0; c < 3; c++) {
            int linear = (SrgbToLinear[from[i1 + c]] + SrgbToLinear[from[i2 + c]] + SrgbToLinear[from[i3 + c]] + SrgbToLinear[from[i4 + c]]) / 4;
            to[at + c] = LinearToSrgb[linear];
        }
        to[at + 3] = (byte)((from[i1 + 3] + from[i2 + 3] + from[i3 + 3] + from[i4 + 3]) / 4);
    }

    /// <summary><c>MipmapGenerator.darkenedAlphaBlend</c>: only the texels with any alpha count, each channel, alpha too, through linear light.</summary>
    private static void DarkenedAlphaBlend(byte[] from, int i1, int i2, int i3, int i4, byte[] to, int at) {
        Span<float> total = stackalloc float[4];
        foreach (int i in (ReadOnlySpan<int>)[i1, i2, i3, i4]) {
            if (from[i + 3] == 0) {
                continue;
            }
            for (int c = 0; c < 4; c++) {
                total[c] += SrgbToLinear[from[i + c]] / 1023.0F;
            }
        }
        for (int c = 0; c < 4; c++) {
            to[at + c] = LinearToSrgb[(int)MathF.Floor(total[c] / 4.0F * 1023.0F)];
        }
    }

    /// <summary>
    /// <c>TextureUtil.solidify</c>: each fully transparent texel takes the colour of the nearest texel with any alpha,
    /// by a breadth first flood in vanilla's neighbour order, keeping its zero alpha.
    /// </summary>
    private static TextureImage Solidify(TextureImage image) {
        int width = image.Width, height = image.Height;
        byte[] rgba = (byte[])image.Rgba.Clone();
        int[] nearest = new int[width * height];
        int[] distances = new int[width * height];
        Array.Fill(distances, int.MaxValue);
        Queue<int> queue = new();
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                int packed = x + y * width;
                if (rgba[packed * 4 + 3] != 0) {
                    distances[packed] = 0;
                    nearest[packed] = packed;
                    queue.Enqueue(packed);
                }
            }
        }
        while (queue.Count > 0) {
            int packed = queue.Dequeue();
            int x = packed % width, y = packed / width;
            foreach ((int dx, int dy) in Directions) {
                int nx = x + dx, ny = y + dy;
                int neighbour = nx + ny * width;
                if (nx >= 0 && ny >= 0 && nx < width && ny < height && distances[neighbour] > distances[packed] + 1) {
                    distances[neighbour] = distances[packed] + 1;
                    nearest[neighbour] = nearest[packed];
                    queue.Enqueue(neighbour);
                }
            }
        }
        for (int i = 0; i < width * height; i++) {
            if (rgba[i * 4 + 3] != 0) {
                continue;
            }
            // With nothing opaque in the image, vanilla's nearest colour is still its initial zero.
            if (distances[i] == int.MaxValue) {
                rgba[i * 4] = rgba[i * 4 + 1] = rgba[i * 4 + 2] = 0;
            }
            else {
                Array.Copy(image.Rgba, nearest[i] * 4, rgba, i * 4, 3);
            }
        }
        return new TextureImage(width, height, rgba);
    }

    /// <summary><c>TextureUtil.fillEmptyAreasWithDarkColor</c>: transparent texels take three quarters of the darkest opaque one's colour.</summary>
    private static TextureImage FillEmptyAreasWithDarkColor(TextureImage image) {
        byte[] rgba = (byte[])image.Rgba.Clone();
        int darkest = -1, minBrightness = int.MaxValue;
        for (int x = 0; x < image.Width; x++) {
            for (int y = 0; y < image.Height; y++) {
                int i = (y * image.Width + x) * 4;
                if (rgba[i + 3] != 0) {
                    int brightness = rgba[i] + rgba[i + 1] + rgba[i + 2];
                    if (brightness < minBrightness) {
                        minBrightness = brightness;
                        darkest = i;
                    }
                }
            }
        }
        // Vanilla's darkest colour starts as -1, white, when nothing is opaque.
        int red = darkest < 0 ? 255 : rgba[darkest], green = darkest < 0 ? 255 : rgba[darkest + 1], blue = darkest < 0 ? 255 : rgba[darkest + 2];
        byte darkRed = (byte)(3 * red / 4), darkGreen = (byte)(3 * green / 4), darkBlue = (byte)(3 * blue / 4);
        for (int i = 0; i < rgba.Length; i += 4) {
            if (rgba[i + 3] == 0) {
                rgba[i] = darkRed;
                rgba[i + 1] = darkGreen;
                rgba[i + 2] = darkBlue;
            }
        }
        return new TextureImage(image.Width, image.Height, rgba);
    }

    /// <summary>
    /// <c>MipmapGenerator.alphaTestCoverage</c>: the share of the image that passes the alpha test, sampling each cell
    /// between four texels bilinearly at 4 by 4 points. An image a texel wide has no cells and reads as NaN, as in vanilla.
    /// </summary>
    private static float AlphaTestCoverage(TextureImage image, float alphaRef, float alphaScale) {
        int width = image.Width, height = image.Height;
        float coverage = 0.0F;
        for (int y = 0; y < height - 1; y++) {
            for (int x = 0; x < width - 1; x++) {
                float alpha00 = Math.Clamp(Alpha(image, x, y) * alphaScale, 0.0F, 1.0F);
                float alpha10 = Math.Clamp(Alpha(image, x + 1, y) * alphaScale, 0.0F, 1.0F);
                float alpha01 = Math.Clamp(Alpha(image, x, y + 1) * alphaScale, 0.0F, 1.0F);
                float alpha11 = Math.Clamp(Alpha(image, x + 1, y + 1) * alphaScale, 0.0F, 1.0F);
                float texelCoverage = 0.0F;
                for (int sy = 0; sy < 4; sy++) {
                    float fy = (sy + 0.5F) / 4.0F;
                    for (int sx = 0; sx < 4; sx++) {
                        float fx = (sx + 0.5F) / 4.0F;
                        float alpha = alpha00 * (1.0F - fx) * (1.0F - fy) + alpha10 * fx * (1.0F - fy) + alpha01 * (1.0F - fx) * fy + alpha11 * fx * fy;
                        if (alpha > alphaRef) {
                            texelCoverage++;
                        }
                    }
                }
                coverage += texelCoverage / 16.0F;
            }
        }
        return coverage / ((width - 1) * (height - 1));
    }

    private static float Alpha(TextureImage image, int x, int y) => image.Rgba[(y * image.Width + x) * 4 + 3] / 255.0F;

    /// <summary><c>MipmapGenerator.scaleAlphaToCoverage</c>: five steps of bisection for the alpha scale, then every texel's alpha scaled and biased.</summary>
    private static void ScaleAlphaToCoverage(TextureImage image, float desiredCoverage, float alphaRef, float alphaCutoffBias) {
        float minAlphaScale = 0.0F, maxAlphaScale = 4.0F, alphaScale = 1.0F, bestAlphaScale = 1.0F, bestError = float.MaxValue;
        for (int i = 0; i < 5; i++) {
            float currentCoverage = AlphaTestCoverage(image, alphaRef, alphaScale);
            float error = Math.Abs(currentCoverage - desiredCoverage);
            if (error < bestError) {
                bestError = error;
                bestAlphaScale = alphaScale;
            }
            if (currentCoverage < desiredCoverage) {
                minAlphaScale = alphaScale;
            }
            else {
                if (!(currentCoverage > desiredCoverage)) {
                    break;
                }
                maxAlphaScale = alphaScale;
            }
            alphaScale = (minAlphaScale + maxAlphaScale) * 0.5F;
        }
        byte[] rgba = image.Rgba;
        for (int i = 3; i < rgba.Length; i += 4) {
            float alpha = rgba[i] / 255.0F * bestAlphaScale + alphaCutoffBias + 0.025F;
            rgba[i] = (byte)(int)MathF.Floor(Math.Clamp(alpha, 0.0F, 1.0F) * 255.0F);
        }
    }
}
