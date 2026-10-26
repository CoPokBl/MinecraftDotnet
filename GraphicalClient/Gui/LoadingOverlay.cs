namespace GraphicalClient.Gui;

/// <summary>
/// <c>LoadingOverlay</c>: covers the game while a resource reload runs, with the game pack's logo from
/// <paramref name="logo"/>, or this client's own lettering without one, on this client's own colour unless the
/// <c>darkMojangStudiosBackground</c> option asks for black. The game keeps ticking, and the HUD drawing, underneath.
/// The result is reported from <see cref="Tick"/> once the reload is done and, when the overlay faded in, a second
/// after that began; the overlay then fades out over two seconds and takes itself away through <paramref name="remove"/>.
/// </summary>
public sealed class LoadingOverlay(ResourceReload reload, Action<Exception?> onFinish, bool fadeIn, Action remove, Action initScreen, Func<uint> logo) {
    private const uint Background = 0x2A2420, BackgroundDark = 0x000000;
    private const long FadeOutTime = 1000L, FadeInTime = 500L;

    private float _currentProgress;
    private long _fadeOutStart = -1L, _fadeInStart = -1L;

    private static long Millis() => Environment.TickCount64;

    public void Render(GuiContext context, Screen? screen, float partialTick) {
        int width = context.Width, height = context.Height;
        uint background = context.Settings?.DarkMojangStudiosBackground == true ? BackgroundDark : Background;
        long now = Millis();
        if (fadeIn && _fadeInStart == -1L) {
            _fadeInStart = now;
        }
        float fadeOutAnim = _fadeOutStart > -1L ? (now - _fadeOutStart) / (float)FadeOutTime : -1.0F;
        float fadeInAnim = _fadeInStart > -1L ? (now - _fadeInStart) / (float)FadeInTime : -1.0F;
        float logoAlpha;
        if (fadeOutAnim >= 1.0F) {
            if (screen != null) {
                (context.MouseX, context.MouseY) = (0, 0);
                screen.Render(context, partialTick);
            }
            int alpha = (int)MathF.Ceiling((1.0F - Math.Clamp(fadeOutAnim - 1.0F, 0.0F, 1.0F)) * 255.0F);
            context.Gui.Rect(0, 0, width, height, (uint)alpha << 24 | background);
            logoAlpha = 1.0F - Math.Clamp(fadeOutAnim - 1.0F, 0.0F, 1.0F);
        }
        else if (fadeIn) {
            if (screen != null && fadeInAnim < 1.0F) {
                screen.Render(context, partialTick);
            }
            int alpha = (int)Math.Ceiling(Math.Clamp((double)fadeInAnim, 0.15, 1.0) * 255.0);
            context.Gui.Rect(0, 0, width, height, (uint)alpha << 24 | background);
            logoAlpha = Math.Clamp(fadeInAnim, 0.0F, 1.0F);
        }
        else {
            context.Gui.Rect(0, 0, width, height, 0xFF000000 | background);
            logoAlpha = 1.0F;
        }

        int contentX = (int)(width * 0.5);
        int logoY = (int)(height * 0.5);
        double logoHeight = Math.Min(width * 0.75, height) * 0.25;
        int logoHeightHalf = (int)(logoHeight * 0.5);
        int logoWidthHalf = (int)(logoHeight * 4.0 * 0.5);
        if (logo() is var texture and not 0) {
            // Each half of the wordmark is a 120 by 60 band of a 120 square, nudged a sixteenth of a texel apart.
            uint white = (uint)(int)(logoAlpha * 255.0F) << 24 | 0xFFFFFF;
            context.Gui.TexturedLighten(texture, contentX - logoWidthHalf, logoY - logoHeightHalf, logoWidthHalf, (int)logoHeight,
                -0.0625F / 120.0F, 0.0F, (120.0F - 0.0625F) / 120.0F, 0.5F, white);
            context.Gui.TexturedLighten(texture, contentX, logoY - logoHeightHalf, logoWidthHalf, (int)logoHeight,
                0.0625F / 120.0F, 0.5F, (120.0F + 0.0625F) / 120.0F, 1.0F, white);
        }
        else {
            RenderLettering(context, contentX, logoY, logoWidthHalf * 2, logoAlpha);
        }
        int barY = (int)(height * 0.8325);
        _currentProgress = Math.Clamp(_currentProgress * 0.95F + reload.Progress * 0.050000012F, 0.0F, 1.0F);
        if (fadeOutAnim < 1.0F) {
            RenderProgressBar(context, width / 2 - logoWidthHalf, barY - 5, width / 2 + logoWidthHalf, barY + 5, 1.0F - Math.Clamp(fadeOutAnim, 0.0F, 1.0F));
        }
        if (fadeOutAnim >= 2.0F) {
            remove();
        }
    }

    /// <summary>"mcdotnet" at the largest whole zoom that fits the width vanilla gives its logo, centred on the logo's middle.</summary>
    private static void RenderLettering(GuiContext context, float centreX, float centreY, int maxWidth, float alpha) {
        int alphaByte = (int)(alpha * 255.0F);
        if (alphaByte <= 4) {
            return;
        }
        const string Lettering = "mcdotnet";
        float zoom = Math.Max(1, maxWidth / Math.Max(1, context.Text.Width(Lettering)));
        context.Gui.Zoom = zoom;
        context.Text.DrawCentred(Lettering, centreX / zoom, centreY / zoom - 4.0F, (uint)alphaByte << 24 | 0xFFFFFF, false);
        context.Gui.Zoom = 1.0F;
    }

    public void Tick() {
        if (_fadeOutStart == -1L && reload.IsDone && IsReadyToFadeOut()) {
            onFinish(reload.Failure);
            _fadeOutStart = Millis();
            initScreen();
        }
    }

    private bool IsReadyToFadeOut() => !fadeIn || _fadeInStart > -1L && Millis() - _fadeInStart >= 1000L;

    private void RenderProgressBar(GuiContext context, int x0, int y0, int x1, int y1, float fade) {
        int width = (int)MathF.Ceiling((x1 - x0 - 2) * _currentProgress);
        uint white = (uint)Math.Round(fade * 255.0F) << 24 | 0xFFFFFF;
        Fill(context, x0 + 2, y0 + 2, x0 + width, y1 - 2, white);
        Fill(context, x0 + 1, y0, x1 - 1, y0 + 1, white);
        Fill(context, x0 + 1, y1, x1 - 1, y1 - 1, white);
        Fill(context, x0, y0, x0 + 1, y1, white);
        Fill(context, x1, y0, x1 - 1, y1, white);
    }

    /// <summary><c>GuiGraphicsExtractor.fill</c>, which takes its corners either way round.</summary>
    private static void Fill(GuiContext context, int x0, int y0, int x1, int y1, uint argb) {
        if (x0 > x1) {
            (x0, x1) = (x1, x0);
        }
        if (y0 > y1) {
            (y0, y1) = (y1, y0);
        }
        if (x1 > x0 && y1 > y0 && argb >> 24 != 0) {
            context.Gui.Rect(x0, y0, x1 - x0, y1 - y0, argb);
        }
    }
}
