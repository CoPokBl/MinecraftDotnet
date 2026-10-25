using ClientLib;
using Minecraft.Text;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>ClientCommonPacketListenerImpl.PackConfirmScreen</c>: asks whether to take the server's packs. Another
/// push while it is open replaces it with one asking about every pack so far, worded for the newest.
/// </summary>
public sealed class PackConfirmScreen : ConfirmScreen {
    private readonly IReadOnlyList<PendingPackRequest> _requests;
    private readonly Screen? _parent;

    private PackConfirmScreen(MinecraftClient client, Action<Screen?> open, Screen? parent, IReadOnlyList<PendingPackRequest> requests, bool required,
        TextComponent? prompt) : base(accepted => {
            open(parent);
            client.AnswerPackPrompt(requests, required, accepted);
        },
        TextComponent.Translatable(required ? "multiplayer.requiredTexturePrompt.line1" : "multiplayer.texturePrompt.line1"),
        PreparePackPrompt(required
            ? TextComponent.Translatable("multiplayer.requiredTexturePrompt.line2").WithColor(TextColor.Yellow).WithBold()
            : TextComponent.Translatable("multiplayer.texturePrompt.line2"), prompt),
        Menus.T(required ? "gui.proceed" : "gui.yes"),
        Menus.T(required ? "menu.disconnect" : "gui.no")) {
        _requests = requests;
        _parent = parent;
    }

    /// <summary><c>addOrUpdatePackPrompt</c>.</summary>
    public static Screen AddOrUpdate(Screen? current, MinecraftClient client, Action<Screen?> open, PackPromptRequest request) =>
        current is PackConfirmScreen prompt
            ? new PackConfirmScreen(client, open, prompt._parent, [.. prompt._requests, request.Request], request.Required, request.Prompt)
            : new PackConfirmScreen(client, open, current, [request.Request], request.Required, request.Prompt);

    /// <summary><c>preparePackPrompt</c>: the server's own words after the line, when it sent any.</summary>
    private static TextComponent PreparePackPrompt(TextComponent header, TextComponent? prompt) =>
        prompt == null ? header : TextComponent.Translatable("multiplayer.texturePrompt.serverPrompt", with: [header, prompt]);
}
