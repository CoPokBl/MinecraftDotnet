using ClientLib.Brigadier;
using Minecraft.Schemas;

namespace ClientLib.Commands;

/// <summary>The command parsing half of vanilla's <c>Identifier</c>.</summary>
public static class Identifiers {
    public const string DefaultNamespace = "minecraft";

    public static readonly SimpleCommandExceptionType ErrorInvalid = new(Component.Translatable("argument.id.invalid"));

    public static string ReadGreedy(StringReader reader) {
        int start = reader.Cursor;
        while (reader.CanRead() && IsAllowedInIdentifier(reader.Peek())) {
            reader.Skip();
        }
        return reader.String[start..reader.Cursor];
    }

    public static Identifier Read(StringReader reader) {
        int start = reader.Cursor;
        string raw = ReadGreedy(reader);
        if (TryParse(raw) is not { } id) {
            reader.Cursor = start;
            throw ErrorInvalid.CreateWithContext(reader);
        }
        return id;
    }

    public static Identifier ReadNonEmpty(StringReader reader) {
        if (!reader.CanRead() || !IsAllowedInIdentifier(reader.Peek())) {
            throw ErrorInvalid.CreateWithContext(reader);
        }
        return Read(reader);
    }

    /// <summary><c>Identifier.tryParse</c>, which is what <c>parse</c> succeeds on.</summary>
    public static Identifier? TryParse(string identifier) {
        int separatorIndex = identifier.IndexOf(':');
        if (separatorIndex < 0) {
            return IsValidPath(identifier) ? new Identifier(DefaultNamespace, identifier) : (Identifier?)null;
        }
        string path = identifier[(separatorIndex + 1)..];
        if (!IsValidPath(path)) {
            return null;
        }
        if (separatorIndex == 0) {
            return new Identifier(DefaultNamespace, path);
        }
        string ns = identifier[..separatorIndex];
        return IsValidNamespace(ns) ? new Identifier(ns, path) : (Identifier?)null;
    }

    /// <summary>
    /// <c>Identifier.bySeparator</c>. Its <see cref="IdentifierException"/> is not a syntax exception, so
    /// bad characters fail as the dispatcher's <c>command.exception</c>, as they do in vanilla.
    /// </summary>
    public static Identifier BySeparator(string identifier, char separator) {
        int separatorIndex = identifier.IndexOf(separator);
        if (separatorIndex < 0) {
            return CreateUntrusted(DefaultNamespace, identifier);
        }
        string path = identifier[(separatorIndex + 1)..];
        return separatorIndex != 0 ? CreateUntrusted(identifier[..separatorIndex], path) : CreateUntrusted(DefaultNamespace, path);
    }

    private static Identifier CreateUntrusted(string ns, string path) {
        if (!IsValidNamespace(ns)) {
            throw new IdentifierException("Non [a-z0-9_.-] character in namespace of identifier: " + ns + ":" + path);
        }
        if (!IsValidPath(path)) {
            throw new IdentifierException("Non [a-z0-9/._-] character in path of location: " + ns + ":" + path);
        }
        return new Identifier(ns, path);
    }

    public static bool IsAllowedInIdentifier(char c) => c is >= '0' and <= '9' or >= 'a' and <= 'z' or '_' or ':' or '/' or '.' or '-';

    public static bool IsValidPath(string path) => path.All(ValidPathChar);

    public static bool IsValidNamespace(string ns) => ns != ".." && ns.All(ValidNamespaceChar);

    private static bool ValidPathChar(char c) => c is '_' or '-' or >= 'a' and <= 'z' or >= '0' and <= '9' or '/' or '.';

    private static bool ValidNamespaceChar(char c) => c is '_' or '-' or >= 'a' and <= 'z' or >= '0' and <= '9' or '.';
}

/// <summary>Vanilla's <c>IdentifierException</c>.</summary>
public sealed class IdentifierException(string message) : Exception(message);
