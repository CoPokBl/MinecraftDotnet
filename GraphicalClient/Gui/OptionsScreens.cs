using ClientLib;
using Minecraft.Schemas.Sound;
using Silk.NET.Input;

namespace GraphicalClient.Gui;

/// <summary>A screen made of vanilla's buttons and sliders over a darkened game, with a title.</summary>
public abstract class MenuScreen : Screen {
    protected abstract string Title { get; }

    /// <summary>Where the title sits; vanilla's sub screens put it in a 33 pixel header.</summary>
    protected virtual float TitleY => 15;

    public override void Render(GuiContext context, float partialTick) {
        // Screen.renderTransparentBackground's gradient, flattened.
        context.Gui.Rect(0, 0, context.Width, context.Height, 0xC8101010);
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

    private void Back(GuiContext context) {
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
        // padded 50 down to clear the title.
        const int rows = 3;
        float top = (height - (50 + 20 + (rows - 1) * 24)) * 0.25F + 50;
        float left = width / 2.0F - 102;
        Add(new Button(T("menu.returnToGame"), left, top, 204, () => Close(context)));
        Add(new Button(T("menu.options"), left, top + 24, 204, () => context.Open?.Invoke(new OptionsScreen(this))));
        Add(new Button(T("menu.disconnect"), left, top + 48, 204, quit));
    }
}

/// <summary>
/// Vanilla's <c>OptionsScreen</c> with what applies here: the field of view, the sensitivity vanilla keeps
/// under Controls, the sounds, the video settings and accessibility.
/// </summary>
public sealed class OptionsScreen(Screen parent) : OptionsPage(parent) {
    protected override string Title => T("options.title");

    protected override void Init(GuiContext context, int width, int height) {
        GameSettings settings = context.Settings!;
        float left = width / 2.0F - 155, right = width / 2.0F + 5;
        Add(new Slider(left, 41, 150, () => (settings.Fov - 30) / 80.0, value => settings.Fov = 30 + (int)Math.Round(value * 80.0), FovLabel));
        Add(new Slider(right, 41, 150, () => settings.Sensitivity, value => settings.Sensitivity = value, SensitivityLabel));
        Add(new Button(T("options.sounds"), left, 65, 150, () => context.Open?.Invoke(new SoundOptionsScreen(this))));
        Add(new Button(T("options.video"), right, 65, 150, () => context.Open?.Invoke(new VideoSettingsScreen(this))));
        Add(new Button(T("options.accessibility"), left, 89, 150, () => context.Open?.Invoke(new AccessibilityOptionsScreen(this))));
        AddDone(context, width, height);
    }

    private static string FovLabel(double value) => (30 + (int)Math.Round(value * 80.0)) switch {
        70 => $"{T("options.fov")}: {T("options.fov.min")}",
        110 => $"{T("options.fov")}: {T("options.fov.max")}",
        var fov => $"{T("options.fov")}: {fov}"
    };

    /// <summary>The <c>options.sensitivity</c> label: a percentage of the default, with names for the ends.</summary>
    private static string SensitivityLabel(double value) => value switch {
        0.0 => $"{T("options.sensitivity")}: {T("options.sensitivity.min")}",
        1.0 => $"{T("options.sensitivity")}: {T("options.sensitivity.max")}",
        _ => Percent(T("options.sensitivity"), 2.0 * value)
    };
}

/// <summary>Vanilla's <c>VideoSettingsScreen</c>, with the options that apply here: the entity distance and the vignette.</summary>
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
        AddDone(context, width, height);
    }

    /// <summary><c>IntRangeBase.toSliderValue</c>: each step in the middle of its share of the track.</summary>
    private static double ToSliderValue(int value) => value == MinQuarters ? 0.0
        : value == MaxQuarters ? 1.0
        : (value + 0.5 - MinQuarters) / (MaxQuarters + 1.0 - MinQuarters);

    /// <summary><c>IntRangeBase.fromSliderValue</c>.</summary>
    private static int FromSliderValue(double slider) {
        if (slider >= 1.0) {
            slider = 0.99999F;
        }
        return (int)Math.Floor(MinQuarters + slider * (MaxQuarters + 1.0 - MinQuarters));
    }
}

/// <summary>Vanilla's <c>AccessibilityOptionsScreen</c> with the options this client has, in its order.</summary>
public sealed class AccessibilityOptionsScreen(Screen parent) : OptionsPage(parent) {
    protected override string Title => T("options.accessibility.title");

    protected override void Init(GuiContext context, int width, int height) {
        GameSettings settings = context.Settings!;
        float left = width / 2.0F - 155, right = width / 2.0F + 5;
        Add(new Slider(left, 37, 150, () => settings.ScreenEffectScale, value => settings.ScreenEffectScale = value, value => PercentOrOff(T("options.screenEffectScale"), value)));
        // fovEffectScale's slider is the square root of the value, which the label shows.
        Add(new Slider(right, 37, 150, () => Math.Sqrt(settings.FovEffectScale), value => settings.FovEffectScale = value * value,
            value => PercentOrOff(T("options.fovEffectScale"), value * value)));
        Add(new Slider(left, 62, 150, () => settings.GlintSpeed, value => settings.GlintSpeed = value, value => PercentOrOff(T("options.glintSpeed"), value)));
        Add(new Slider(right, 62, 150, () => settings.GlintStrength, value => settings.GlintStrength = value, value => PercentOrOff(T("options.glintStrength"), value)));
        AddDone(context, width, height);
    }
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
        AddDone(context, width, height);
    }

    private static Slider VolumeSlider(GuiContext context, SoundCategory category, float x, float y, float w) =>
        new(x, y, w, () => context.Settings!.Volumes[(int)category], value => {
            context.Settings!.Volumes[(int)category] = (float)value;
            context.Sounds?.Engine.SetCategoryVolume(category, (float)value);
        }, value => PercentOrOff(T("soundCategory." + GameSettings.CategoryNames[category]), value));
}
