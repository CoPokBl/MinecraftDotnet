using ClientLib.Brigadier;
using Minecraft.Text;

namespace ClientLib.Commands;

/// <summary>The <c>Component</c> factories the command code builds its messages with.</summary>
public static class Component {
    /// <summary><c>Component.translatable(key, args)</c>: a non-component argument prints as Java's <c>String.valueOf</c>.</summary>
    public static TextComponent Translatable(string key, params object[] args) {
        if (args.Length == 0) {
            return TextComponent.Translatable(key);
        }
        return TextComponent.Translatable(key, null, args.Select(Argument).ToArray());
    }

    /// <summary><c>Component.translatableEscape</c>, which differs from <see cref="Translatable"/> only in how it stores the arguments.</summary>
    public static TextComponent TranslatableEscape(string key, params object[] args) => Translatable(key, args);

    private static TextComponent Argument(object arg) => arg as TextComponent ?? TextComponent.Text(JavaText.ValueOf(arg));
}
