namespace ClientLib.Profiles;

/// <summary>
/// <c>SkinTextureDownloader.processLegacySkin</c>, on 8 bit RGBA rows, top first: a 64 by 32 skin from before
/// the second layer gains a bottom half holding its limbs mirrored to the left side, and the parts with no
/// overlay are made opaque.
/// </summary>
public static class SkinTextureProcessing {
    /// <returns>The 64 by 64 skin, or null for any other size, which vanilla discards.</returns>
    public static byte[]? ProcessLegacySkin(int width, int height, byte[] rgba) {
        if (width != 64 || height is not (32 or 64)) {
            return null;
        }
        bool isLegacy = height == 32;
        byte[] image = new byte[64 * 64 * 4];
        Array.Copy(rgba, image, Math.Min(rgba.Length, image.Length));
        if (isLegacy) {
            CopyRect(image, 4, 16, 16, 32, 4, 4);
            CopyRect(image, 8, 16, 16, 32, 4, 4);
            CopyRect(image, 0, 20, 24, 32, 4, 12);
            CopyRect(image, 4, 20, 16, 32, 4, 12);
            CopyRect(image, 8, 20, 8, 32, 4, 12);
            CopyRect(image, 12, 20, 16, 32, 4, 12);
            CopyRect(image, 44, 16, -8, 32, 4, 4);
            CopyRect(image, 48, 16, -8, 32, 4, 4);
            CopyRect(image, 40, 20, 0, 32, 4, 12);
            CopyRect(image, 44, 20, -8, 32, 4, 12);
            CopyRect(image, 48, 20, -16, 32, 4, 12);
            CopyRect(image, 52, 20, -8, 32, 4, 12);
        }
        SetNoAlpha(image, 0, 0, 32, 16);
        if (isLegacy) {
            DoNotchTransparencyHack(image, 32, 0, 64, 32);
        }
        SetNoAlpha(image, 0, 16, 64, 32);
        SetNoAlpha(image, 16, 48, 48, 64);
        return image;
    }

    /// <summary><c>NativeImage.copyRect</c> within the image, mirrored left to right.</summary>
    private static void CopyRect(byte[] image, int startX, int startY, int offsetX, int offsetY, int sizeX, int sizeY) {
        for (int y = 0; y < sizeY; y++) {
            for (int x = 0; x < sizeX; x++) {
                int dx = sizeX - 1 - x;
                Array.Copy(image, Index(startX + x, startY + y), image, Index(startX + offsetX + dx, startY + offsetY + y), 4);
            }
        }
    }

    /// <summary>The hat clears to transparent when no pixel of it already is.</summary>
    private static void DoNotchTransparencyHack(byte[] image, int x0, int y0, int x1, int y1) {
        for (int x = x0; x < x1; x++) {
            for (int y = y0; y < y1; y++) {
                if (image[Index(x, y) + 3] < 128) {
                    return;
                }
            }
        }
        for (int x = x0; x < x1; x++) {
            for (int y = y0; y < y1; y++) {
                image[Index(x, y) + 3] = 0;
            }
        }
    }

    private static void SetNoAlpha(byte[] image, int x0, int y0, int x1, int y1) {
        for (int x = x0; x < x1; x++) {
            for (int y = y0; y < y1; y++) {
                image[Index(x, y) + 3] = 255;
            }
        }
    }

    private static int Index(int x, int y) => (y * 64 + x) * 4;
}
