using ClientLib;
using Minecraft.Schemas.Sound;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>A screen made of vanilla's buttons and sliders over a darkened game, with a title.</summary>
public abstract class MenuScreen : Screen {
    protected abstract string Title { get; }

    protected override string NarrationTitle => Title;

    /// <summary>Where the title sits; vanilla's sub screens put it in a 33 pixel header.</summary>
    protected virtual float TitleY => 15;

    public override void Render(GuiContext context, float partialTick) {
        Menus.Background(context);
        context.Text.DrawCentred(Title, context.Width / 2.0F, TitleY, 0xFFFFFFFF);
        RenderWidgets(context);
    }

    protected static string T(string key) => Translations.Get(key) ?? key;

    /// <summary><c>Options.percentValueLabel</c>.</summary>
    protected static string Percent(string caption, double value) => $"{caption}: {(int)(value * 100.0)}%";

    /// <summary><c>Options.percentValueOrOffLabel</c>.</summary>
    protected static string PercentOrOff(string caption, double value) => value == 0.0 ? $"{caption}: {T("options.off")}" : Percent(caption, value);
}

/// <summary>An options page: Escape and Done both go back to the screen that opened it, saving.</summary>
public abstract class OptionsPage(Screen parent) : MenuScreen {
    protected void AddDone(GuiContext context, int width, int height) =>
        Add(new Button(T("gui.done"), width / 2.0F - 100, height - 27, 200, () => Back(context)));

    public override void KeyDown(GuiContext context, Key key, bool control) {
        if (key == Key.Escape) {
            Back(context);
        }
    }

    protected void Back(GuiContext context) {
        context.Settings!.Save();
        context.Open?.Invoke(parent);
    }
}

/// <summary>
/// Vanilla's <c>PauseScreen</c>, with the buttons this client has something behind. On a server it
/// pauses nothing, as vanilla's does not.
/// </summary>
public sealed class PauseScreen(Action quit) : MenuScreen {
    protected override string Title => T("menu.game");

    protected override float TitleY => 40;

    protected override void Init(GuiContext context, int width, int height) {
        // FrameLayout.alignInRectangle(grid, 0, 0, width, height, 0.5F, 0.25F): rows 24 apart, the first
        // padded 50 down to clear the title, and the half width pair 106 apart. The row of link and social
        // icons under the pair is left out, there being nothing of Mojang's behind them here.
        const int rows = 4;
        float top = (height - (50 + 20 + (rows - 1) * 24)) * 0.25F + 50;
        float left = width / 2.0F - 102;
        Add(new Button(T("menu.returnToGame"), left, top, 204, () => Close(context)));
        Add(new Button(T("gui.advancements"), left, top + 24, 98,
            () => context.Open?.Invoke(new AdvancementsScreen(context, context.Client.Advancements, this))));
        Add(new Button(T("gui.stats"), left + 106, top + 24, 98, () => context.Open?.Invoke(new StatsScreen(this))));
        Add(new Button(T("menu.options"), left, top + 48, 204, () => context.Open?.Invoke(new OptionsScreen(this))));
        Add(new Button(T("menu.disconnect"), left, top + 72, 204, quit));
    }

    public override void Tick(GuiContext context) {
        if (RendersNowPlayingToast(context)) {
            NowPlayingToast.TickMusicNotes(context.Toasts.CurrentMusic());
        }
    }

    public override void Render(GuiContext context, float partialTick) {
        base.Render(context, partialTick);
        if (RendersNowPlayingToast(context)) {
            NowPlayingToast.Draw(context, context.Toasts.CurrentMusic(), 0, 0);
        }
    }

    /// <summary><c>rendersNowPlayingToast</c>: the music toast option allows it and the music can be heard.</summary>
    private static bool RendersNowPlayingToast(GuiContext context) =>
        context.Settings is { } settings && settings.MusicToast.RenderInPauseScreen() && settings.FinalSoundSourceVolume(SoundCategory.Music) > 0.0F;
}

/// <summary>Vanilla's <c>OptionsScreen</c> with what applies here: the field of view and the sub screens this client has.</summary>
public sealed class OptionsScreen(Screen parent) : OptionsPage(parent) {
    protected override string Title => T("options.title");

    protected override void Init(GuiContext context, int width, int height) {
        GameSettings settings = context.Settings!;
        Add(new Slider(width / 2.0F - 155, 41, 150, () => (settings.Fov - 30) / 80.0, value => settings.Fov = 30 + (int)Math.Round(value * 80.0), FovLabel));
        AddGridButton(context, 0, "options.skinCustomisation", () => new SkinCustomizationScreen(this));
        AddGridButton(context, 1, "options.sounds", () => new SoundOptionsScreen(this));
        AddGridButton(context, 2, "options.video", () => new VideoSettingsScreen(this));
        AddGridButton(context, 3, "options.controls", () => new ControlsScreen(this));
        AddGridButton(context, 4, "options.language", () => new LanguageSelectScreen(this));
        AddGridButton(context, 5, "options.chat", () => new ChatOptionsScreen(this));
        AddGridButton(context, 6, "options.resourcepack", () => new PackSelectionScreen(this));
        AddGridButton(context, 7, "options.accessibility", () => new AccessibilityOptionsScreen(this));
        AddDone(context, width, height);
    }

    /// <summary>
    /// One of the grid's ten buttons by its place in vanilla's order (skin, sounds, video, controls, language,
    /// chat, resource packs, accessibility, telemetry, credits): two 150 wide columns with 4 pixels of padding
    /// round each cell, rows 24 apart, centred between the 61 pixel header and the 33 pixel footer.
    /// </summary>
    private void AddGridButton(GuiContext context, int index, string label, Func<Screen> open) {
        const int rows = 5, gridWidth = 2 * 158;
        int left = (context.Width - gridWidth) / 2 + 4;
        int top = 61 + (context.Height - 33 - 61 - rows * 24) / 2;
        Add(new Button(T(label), left + index % 2 * 158, top + index / 2 * 24, 150, () => context.Open?.Invoke(open())));
    }

    private static string FovLabel(double value) => (30 + (int)Math.Round(value * 80.0)) switch {
        70 => $"{T("options.fov")}: {T("options.fov.min")}",
        110 => $"{T("options.fov")}: {T("options.fov.max")}",
        var fov => $"{T("options.fov")}: {fov}"
    };
}

/// <summary>Vanilla's <c>VideoSettingsScreen</c>, with the options that apply here: the entity distance, the vignette, particles and entity shadows.</summary>
public sealed class VideoSettingsScreen(Screen parent) : OptionsPage(parent) {
    protected override string Title => T("options.videoTitle");

    /// <summary><c>entityDistanceScaling</c>'s <c>IntRange(2, 20)</c>, in quarters.</summary>
    private const int MinQuarters = 2, MaxQuarters = 20;

    protected override void Init(GuiContext context, int width, int height) {
        GameSettings settings = context.Settings!;
        Add(new Slider(width / 2.0F - 155, 37, 150, () => ToSliderValue((int)(settings.EntityDistanceScaling * 4.0)),
            value => settings.EntityDistanceScaling = FromSliderValue(value) / 4.0, value => Percent(T("options.entityDistanceScaling"), FromSliderValue(value) / 4.0)));
        Add(new CycleButton<bool>([true, false], settings.Vignette, on => $"{T("options.vignette")}: {T(on ? "options.on" : "options.off")}", width / 2.0F + 5, 37, 150,
            on => settings.Vignette = on));
        Add(new CycleButton<Minecraft.Schemas.ParticleStatus>([Minecraft.Schemas.ParticleStatus.All, Minecraft.Schemas.ParticleStatus.Decreased, Minecraft.Schemas.ParticleStatus.Minimal], settings.Particles,
            status => $"{T("options.particles")}: {T(ParticleCaption(status))}", width / 2.0F - 155, 61, 150, status => settings.Particles = status));
        Add(new CycleButton<CloudStatus>([CloudStatus.Off, CloudStatus.Fast, CloudStatus.Fancy], settings.Clouds,
            status => $"{T("options.renderClouds")}: {T(CloudCaption(status))}", width / 2.0F + 5, 61, 150, status => settings.Clouds = status));
        Add(new Slider(width / 2.0F - 155, 85, 150, () => ToSlider(settings.CloudRange, 2, 128), value => settings.CloudRange = FromSlider(value, 2, 128),
            value => $"{T("options.renderCloudsDistance")}: {T("options.chunks").Replace("%s", FromSlider(value, 2, 128).ToString())}"));
        Add(new Slider(width / 2.0F + 5, 85, 150, () => ToSlider(settings.WeatherRadius, 3, 10), value => settings.WeatherRadius = FromSlider(value, 3, 10),
            value => $"{T("options.weatherRadius")}: {T("options.blocks").Replace("%s", FromSlider(value, 3, 10).ToString())}"));
        Add(new CycleButton<bool>([true, false], settings.EntityShadows, on => $"{T("options.entityShadows")}: {T(on ? "options.on" : "options.off")}",
            width / 2.0F - 155, 109, 150, on => settings.EntityShadows = on));
        AddDone(context, width, height);
    }

    /// <summary><c>CloudStatus.caption</c>.</summary>
    private static string CloudCaption(CloudStatus status) => status switch {
        CloudStatus.Fast => "options.clouds.fast",
        CloudStatus.Fancy => "options.clouds.fancy",
        _ => "options.off"
    };

    /// <summary><c>ParticleStatus.caption</c>.</summary>
    private static string ParticleCaption(Minecraft.Schemas.ParticleStatus status) => status switch {
        Minecraft.Schemas.ParticleStatus.Decreased => "options.particles.decreased",
        Minecraft.Schemas.ParticleStatus.Minimal => "options.particles.minimal",
        _ => "options.particles.all"
    };

    private static double ToSliderValue(int value) => ToSlider(value, MinQuarters, MaxQuarters);

    private static int FromSliderValue(double slider) => FromSlider(slider, MinQuarters, MaxQuarters);

    /// <summary><c>IntRangeBase.toSliderValue</c>: each step in the middle of its share of the track.</summary>
    private static double ToSlider(int value, int min, int max) => value == min ? 0.0
        : value == max ? 1.0
        : (value + 0.5 - min) / (max + 1.0 - min);

    /// <summary><c>IntRangeBase.fromSliderValue</c>.</summary>
    private static int FromSlider(double slider, int min, int max) {
        if (slider >= 1.0) {
            slider = 0.99999F;
        }
        return (int)Math.Floor(min + slider * (max + 1.0 - min));
    }
}

/// <summary>Vanilla's <c>AccessibilityOptionsScreen</c> with the options this client has, in its order: the narrator and a way to the controls first.</summary>
public sealed class AccessibilityOptionsScreen(Screen parent) : OptionsPage(parent) {
    protected override string Title => T("options.accessibility.title");

    protected override void Init(GuiContext context, int width, int height) {
        GameSettings settings = context.Settings!;
        float left = width / 2.0F - 155, right = width / 2.0F + 5;
        Add(NarratorButton = OptionWidgets.Narrator(context, left, 37));
        Add(new Button(T("options.controls"), right, 37, 150, () => context.Open?.Invoke(new ControlsScreen(this))));
        Add(new Slider(left, 62, 150, () => settings.ScreenEffectScale, value => settings.ScreenEffectScale = value, value => PercentOrOff(T("options.screenEffectScale"), value)));
        // fovEffectScale's slider is the square root of the value, which the label shows.
        Add(new Slider(right, 62, 150, () => Math.Sqrt(settings.FovEffectScale), value => settings.FovEffectScale = value * value,
            value => PercentOrOff(T("options.fovEffectScale"), value * value)));
        Add(new Slider(left, 87, 150, () => settings.GlintSpeed, value => settings.GlintSpeed = value, value => PercentOrOff(T("options.glintSpeed"), value)));
        Add(new Slider(right, 87, 150, () => settings.GlintStrength, value => settings.GlintStrength = value, value => PercentOrOff(T("options.glintStrength"), value)));
        Add(OptionWidgets.Boolean("options.accessibility.narrator_hotkey", settings.NarratorHotkey, left, 112, on => settings.NarratorHotkey = on));
        Add(OptionWidgets.Boolean("options.hideLightningFlashes", settings.HideLightningFlashes, left, 137, on => settings.HideLightningFlashes = on));
        // notificationDisplayTime is an IntRange(5, 100) in tenths; its label is the multiplier as Java prints a double.
        Add(new Slider(right, 112, 150, () => TenthsToSlider((int)Math.Round(settings.NotificationDisplayTime * 10.0)),
            value => settings.NotificationDisplayTime = SliderToTenths(value) / 10.0,
            value => $"{T("options.notifications.display_time")}: {T("options.multiplier").Replace("%s", JavaDouble(SliderToTenths(value) / 10.0))}"));
        AddDone(context, width, height);
    }

    private const int MinTenths = 5, MaxTenths = 100;

    /// <summary><c>IntRangeBase.toSliderValue</c>.</summary>
    private static double TenthsToSlider(int value) => value <= MinTenths ? 0.0
        : value >= MaxTenths ? 1.0
        : (value + 0.5 - MinTenths) / (MaxTenths + 1.0 - MinTenths);

    /// <summary><c>IntRangeBase.fromSliderValue</c>.</summary>
    private static int SliderToTenths(double slider) => (int)Math.Floor(MinTenths + Math.Min(slider, 0.99999F) * (MaxTenths + 1.0 - MinTenths));

    private static string JavaDouble(double value) => value == Math.Floor(value)
        ? value.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture)
        : value.ToString(System.Globalization.CultureInfo.InvariantCulture);
}

/// <summary>Vanilla's <c>SoundOptionsScreen</c>: master across the top, the other categories in pairs.</summary>
public sealed class SoundOptionsScreen(Screen parent) : OptionsPage(parent) {
    protected override string Title => T("options.sounds.title");

    /// <summary><c>SoundSource</c> order after master.</summary>
    private static readonly SoundCategory[] Categories = [
        SoundCategory.Music, SoundCategory.Records, SoundCategory.Weather, SoundCategory.Blocks, SoundCategory.Hostile,
        SoundCategory.Neutral, SoundCategory.Players, SoundCategory.Ambient, SoundCategory.Voice, SoundCategory.Ui
    ];

    protected override void Init(GuiContext context, int width, int height) {
        float left = width / 2.0F - 155, right = width / 2.0F + 5;
        // OptionsList rows are 25 apart, starting under the 33 pixel header.
        float y = 37;
        Add(VolumeSlider(context, SoundCategory.Master, left, y, 310));
        for (int i = 0; i < Categories.Length; i++) {
            if (i % 2 == 0) {
                y += 25;
            }
            Add(VolumeSlider(context, Categories[i], i % 2 == 0 ? left : right, y, 150));
        }
        // The sound device, subtitles and directional audio rows above this one are left out.
        y += 25;
        GameSettings settings = context.Settings!;
        Add(new CycleButton<Audio.MusicFrequency>(Audio.MusicFrequency.All, settings.MusicFrequency,
            frequency => OptionWidgets.Generic("options.music_frequency", T(frequency.Caption)), left, y, 150, frequency => settings.MusicFrequency = frequency));
        Add(new CycleButton<MusicToastDisplayState>(MusicToastDisplayStates.All, settings.MusicToast,
            state => OptionWidgets.Generic("options.musicToast", T(state.TranslationKey())), right, y, 150, state => settings.MusicToast = state));
        AddDone(context, width, height);
    }

    private static Slider VolumeSlider(GuiContext context, SoundCategory category, float x, float y, float w) =>
        new(x, y, w, () => context.Settings!.Volumes[(int)category], value => {
            GameSettings settings = context.Settings!;
            settings.Volumes[(int)category] = (float)value;
            if (category is SoundCategory.Master or SoundCategory.Music && settings.FinalSoundSourceVolume(SoundCategory.Music) > 0.0F) {
                context.Sounds?.Music?.ShowNowPlayingToastIfNeeded();
            }
            context.Sounds?.Engine.SetCategoryVolume(category, (float)value);
        }, value => PercentOrOff(T("soundCategory." + GameSettings.CategoryNames[category]), value));
}
