using Minecraft.Registry;

namespace Minecraft.Data.ArgumentParsers.Types;

/// <summary>
/// An argument handed to the command as the text that was typed. These are the types whose meaning
/// depends on server state (a selector needs the entities, a resource needs the datapack), so
/// resolving them is left to the command; the wire form is the whole of what is fixed.
/// <p/>
/// One argument ends at the first space that is not inside brackets, braces or quotes, so a selector
/// such as <c>@e[type=cow, limit=1]</c> or an SNBT compound with spaces in it stays one argument.
/// </summary>
public abstract record TokenArgumentType : ArgumentParser<string> {
    /// <summary>Whether the argument takes the rest of the line, as <c>message</c> does.</summary>
    protected virtual bool Greedy => false;

    public override string Parse(ref string str, MinecraftRegistry reg) {
        if (Greedy) {
            string all = str;
            str = string.Empty;
            return all;
        }

        int depth = 0;
        char quote = '\0';
        int i = 0;
        for (; i < str.Length; i++) {
            char c = str[i];
            if (quote != '\0') {
                if (c == '\\') {
                    i++;
                }
                else if (c == quote) {
                    quote = '\0';
                }
                continue;
            }
            if (c is '"' or '\'') {
                quote = c;
            }
            else if (c is '[' or '{' or '(') {
                depth++;
            }
            else if (c is ']' or '}' or ')') {
                depth--;
            }
            else if (c == ' ' && depth <= 0) {
                break;
            }
        }

        string token = str[..i];
        str = i < str.Length ? str[(i + 1)..] : string.Empty;
        if (token.Length == 0) {
            throw new ArgumentException($"Expected {Identifier}");
        }
        return token;
    }

    public override string Format(string value) => value;
}

/// <summary>A token argument whose wire form names the registry it draws from.</summary>
public abstract record RegistryTokenArgumentType(Schemas.Identifier Registry) : TokenArgumentType {
    public override DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteString(Registry.ToString());
    }

    public override IArgumentParser ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with { Registry = reader.ReadString() };
    }
}
