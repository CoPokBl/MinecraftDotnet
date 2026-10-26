using System.Globalization;
using Minecraft.Schemas;

namespace GraphicalClient;

/// <summary>The chat options, under <c>ChatOptionsScreen</c>'s keys, and the accessibility ones chat reads.</summary>
public sealed partial class GameSettings {
    /// <summary><c>chatVisibility</c>, which goes to the server in the client information.</summary>
    public ChatMode ChatVisibility { get; set; } = ChatMode.Enabled;

    /// <summary><c>chatColors</c>: sent to the server, and without it the chat window strips section sign codes.</summary>
    public bool ChatColors { get; set; } = true;

    public bool ChatLinks { get; set; } = true;
    public bool ChatLinksPrompt { get; set; } = true;
    public double ChatOpacity { get; set; } = 1.0;
    public double TextBackgroundOpacity { get; set; } = 0.5;
    public double ChatScale { get; set; } = 1.0;
    public double ChatLineSpacing { get; set; }

    /// <summary><c>chatDelay</c>, in seconds, 0 to 6 in tenths.</summary>
    public double ChatDelay { get; set; }

    public double ChatWidth { get; set; } = 1.0;
    public double ChatHeightFocused { get; set; } = 1.0;

    /// <summary><c>ChatComponent.defaultUnfocusedPct</c>: 90 pixels of the 20 to 180 range.</summary>
    public double ChatHeightUnfocused { get; set; } = 70.0 / (180 - 20);

    public bool AutoSuggestions { get; set; } = true;
    public bool HideMatchedNames { get; set; } = true;
    public bool ReducedDebugInfo { get; set; }
    public bool OnlyShowSecureChat { get; set; }
    public bool SaveChatDrafts { get; set; }

    /// <summary>
    /// <c>chatSigning</c>, this client's own: whether chat is signed with the account's chat key. Off, no key is
    /// fetched and no chat session is announced, as vanilla without one.
    /// </summary>
    public bool ChatSigning { get; set; } = true;

    /// <summary>The accessibility option <c>backgroundForChatOnly</c>: text backgrounds other than chat keep their own opacity.</summary>
    public bool BackgroundForChatOnly { get; set; } = true;

    /// <summary><c>advancedItemTooltips</c>, which F3+H toggles: also what lets a <c>show_entity</c> hover show.</summary>
    public bool AdvancedItemTooltips { get; set; }

    /// <summary><c>Options.getBackgroundColor(int)</c>: the colour given, unless text backgrounds follow the chat's opacity.</summary>
    public uint BackgroundColor(uint defaultColor) => BackgroundForChatOnly ? defaultColor : (uint)Math.Floor(TextBackgroundOpacity * 255.0) << 24;

    /// <summary>The chat lines; null for a key that is none of them.</summary>
    private bool? ReadChat(string key, string value) {
        switch (key) {
            case "chatVisibility":
                // ChatVisiblity.LEGACY_CODEC: the id, wrapped round the three values.
                if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int id)) {
                    return false;
                }
                ChatVisibility = (ChatMode)((id % 3 + 3) % 3);
                return true;
            case "chatColors": return JsonBool(value, on => ChatColors = on);
            case "chatLinks": return JsonBool(value, on => ChatLinks = on);
            case "chatLinksPrompt": return JsonBool(value, on => ChatLinksPrompt = on);
            case "autoSuggestions": return JsonBool(value, on => AutoSuggestions = on);
            case "hideMatchedNames": return JsonBool(value, on => HideMatchedNames = on);
            case "reducedDebugInfo": return JsonBool(value, on => ReducedDebugInfo = on);
            case "onlyShowSecureChat": return JsonBool(value, on => OnlyShowSecureChat = on);
            case "saveChatDrafts": return JsonBool(value, on => SaveChatDrafts = on);
            case "backgroundForChatOnly": return JsonBool(value, on => BackgroundForChatOnly = on);
            case "chatSigning":
                if (value is not ("true" or "false")) {
                    return false;
                }
                ChatSigning = value == "true";
                return true;
            case "chatOpacity": return UnitDouble(value, v => ChatOpacity = v);
            case "textBackgroundOpacity": return UnitDouble(value, v => TextBackgroundOpacity = v);
            case "chatScale": return UnitDouble(value, v => ChatScale = v);
            case "chatLineSpacing": return UnitDouble(value, v => ChatLineSpacing = v);
            case "chatWidth": return UnitDouble(value, v => ChatWidth = v);
            case "chatHeightFocused": return UnitDouble(value, v => ChatHeightFocused = v);
            case "chatHeightUnfocused": return UnitDouble(value, v => ChatHeightUnfocused = v);
            case "chatDelay":
                // Codec.doubleRange(0, 6).
                if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double delay) || delay is < 0.0 or > 6.0) {
                    return false;
                }
                ChatDelay = delay;
                return true;
            case "advancedItemTooltips":
                // Options.process(String, boolean): exactly true or false.
                if (value is not ("true" or "false")) {
                    return false;
                }
                AdvancedItemTooltips = value == "true";
                return true;
        }
        return null;
    }

    /// <summary><c>Codec.BOOL</c> through <c>JsonOps</c>: a JSON boolean, or a number that is true when not zero.</summary>
    private static bool JsonBool(string value, Action<bool> set) {
        if (value is "true" or "false") {
            set(value == "true");
            return true;
        }
        if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double number)) {
            set((sbyte)(long)number != 0);
            return true;
        }
        return false;
    }

    /// <summary><c>OptionInstance.UnitDouble</c>'s codec: a number from 0 to 1, or a boolean for either end.</summary>
    private static bool UnitDouble(string value, Action<double> set) {
        if (value is "true" or "false") {
            set(value == "true" ? 1.0 : 0.0);
            return true;
        }
        if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double number) || number is < 0.0 or > 1.0) {
            return false;
        }
        set(number);
        return true;
    }

    private IEnumerable<string> ChatLines() {
        static string D(double value) => value.ToString(CultureInfo.InvariantCulture);
        static string B(bool value) => value ? "true" : "false";
        return [
            "chatVisibility:" + (int)ChatVisibility, "chatColors:" + B(ChatColors), "chatLinks:" + B(ChatLinks), "chatLinksPrompt:" + B(ChatLinksPrompt),
            "chatOpacity:" + D(ChatOpacity), "textBackgroundOpacity:" + D(TextBackgroundOpacity), "chatScale:" + D(ChatScale),
            "chatLineSpacing:" + D(ChatLineSpacing), "chatDelay:" + D(ChatDelay), "chatWidth:" + D(ChatWidth),
            "chatHeightFocused:" + D(ChatHeightFocused), "chatHeightUnfocused:" + D(ChatHeightUnfocused), "autoSuggestions:" + B(AutoSuggestions),
            "hideMatchedNames:" + B(HideMatchedNames), "reducedDebugInfo:" + B(ReducedDebugInfo), "onlyShowSecureChat:" + B(OnlyShowSecureChat),
            "saveChatDrafts:" + B(SaveChatDrafts), "backgroundForChatOnly:" + B(BackgroundForChatOnly), "advancedItemTooltips:" + B(AdvancedItemTooltips),
            "chatSigning:" + B(ChatSigning)
        ];
    }
}
