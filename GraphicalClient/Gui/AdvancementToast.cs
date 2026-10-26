using ClientLib;
using ClientLib.Advancements;
using Minecraft.Data.Generated;
using Minecraft.Data.Sounds;
using Minecraft.Schemas.Advancements;
using Minecraft.Text;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>AdvancementToast</c>: the frame's name over the advancement's title, or for a title of two lines or more the
/// name alone for a second and a half, fading into the title. A challenge plays its fanfare as it comes in.
/// </summary>
public sealed class AdvancementToast(AdvancementNode advancement) : Toast {
    private const long DisplayTime = 5000;
    private const int TitleWidth = 125;

    private ToastVisibility _wantedVisibility = ToastVisibility.Hide;
    private TextRenderer? _measuredWith;
    private List<List<TextRun>> _lines = [];

    private AdvancementDisplay? Display => advancement.Display;

    public override ToastVisibility WantedVisibility => _wantedVisibility;

    public override void Update(ToastManager manager, long fullyVisibleForMs) {
        _wantedVisibility = Display == null || fullyVisibleForMs >= DisplayTime * manager.NotificationDisplayTimeMultiplier
            ? ToastVisibility.Hide
            : ToastVisibility.Show;
    }

    public override ISoundType? Sound => Display?.Frame == AdvancementFrame.Challenge ? SoundType.ToastChallengeComplete : null;

    public override void Measure(TextRenderer text) {
        if (_measuredWith != text && Display != null) {
            _measuredWith = text;
            _lines = text.Wrap(Menus.Runs(Display.Title), TitleWidth);
        }
    }

    /// <summary><c>AdvancementType.getDisplayName</c>.</summary>
    public static string FrameName(AdvancementFrame frame) => Menus.T(frame switch {
        AdvancementFrame.Challenge => "advancements.toast.challenge",
        AdvancementFrame.Goal => "advancements.toast.goal",
        _ => "advancements.toast.task"
    });

    public override void Render(GuiContext context, float x, float y, long fullyVisibleForMs) {
        if (!context.Sprites.Sprite(context.Gui, "toast/advancement", x, y, Width, Height)) {
            DrawFallbackBackground(context, x, y, Width, Height);
        }
        if (Display is not { } display) {
            return;
        }
        int titleRgb = display.Frame == AdvancementFrame.Challenge ? 0xFF88FF : 0xFFFF00;
        string frameName = FrameName(display.Frame);
        if (_lines.Count == 1) {
            context.Text.Draw(frameName, x + 30, y + 7, 0xFF000000 | (uint)titleRgb, false);
            context.Text.Draw(_lines[0], x + 30, y + 18, 255, false);
        }
        else if (fullyVisibleForMs < 1500) {
            int alpha = (int)Math.Floor(Math.Clamp((1500 - fullyVisibleForMs) / 300.0F, 0.0F, 1.0F) * 255.0F);
            if (alpha != 0) {
                context.Text.Draw(frameName, x + 30, y + 11, (uint)alpha << 24 | (uint)titleRgb, false);
            }
        }
        else {
            int alpha = (int)Math.Floor(Math.Clamp((fullyVisibleForMs - 1500) / 300.0F, 0.0F, 1.0F) * 252.0F);
            float lineY = y + Height / 2 - _lines.Count * TextRenderer.LineHeight / 2;
            if (alpha != 0) {
                foreach (List<TextRun> line in _lines) {
                    context.Text.Draw(line, x + 30, lineY, (byte)alpha, false);
                    lineY += TextRenderer.LineHeight;
                }
            }
        }
        GuiItems.Icon(context, display.Icon, x + 8, y + 8);
    }

    /// <summary>The built in look of a toast's 160 by 32 box, for when no pack has one.</summary>
    public static void DrawFallbackBackground(GuiContext context, float x, float y, float w, float h) {
        context.Gui.Rect(x, y, w, h, 0xFF000000);
        context.Gui.Rect(x + 1, y + 1, w - 2, h - 2, 0xFF5A5A5A);
        context.Gui.Rect(x + 2, y + 2, w - 4, h - 4, 0xFF212121);
    }
}
