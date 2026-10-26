using System.Globalization;

namespace ClientLib.Multiplayer;

/// <summary>
/// <c>ServerAddress</c>: a host and port as typed into the server list, parsed as Guava's
/// <c>HostAndPort.fromString</c> parses it, the port defaulting to 25565.
/// </summary>
public sealed record ServerAddress(string RawHost, int Port) {
    public const int DefaultPort = 25565;

    private static readonly ServerAddress Invalid = new("server.invalid", DefaultPort);

    /// <summary><c>getHost</c>: the host through <c>IDN.toASCII</c>, empty when that refuses it.</summary>
    public string Host => ToAscii(RawHost) ?? "";

    public static ServerAddress Parse(string? input) {
        if (input == null || !TryParseHostAndPort(input, out string host, out int? port) || host.Length == 0) {
            return Invalid;
        }
        return new ServerAddress(host, port ?? DefaultPort);
    }

    public static bool IsValidAddress(string input) =>
        TryParseHostAndPort(input, out string host, out _) && host.Length > 0 && ToAscii(host) != null;

    /// <summary><c>parsePort</c>.</summary>
    public static int ParsePort(string text) => int.TryParse(text.Trim(), NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out int port) ? port : DefaultPort;

    /// <summary><c>HostAndPort.fromString</c>: false where Guava throws.</summary>
    private static bool TryParseHostAndPort(string text, out string host, out int? port) {
        port = null;
        string? portText;
        if (text.StartsWith('[')) {
            int colon = text.IndexOf(':');
            int close = text.LastIndexOf(']');
            host = "";
            if (colon < 0 || close <= colon) {
                return false;
            }
            host = text[1..close];
            if (close + 1 == text.Length) {
                portText = "";
            }
            else {
                if (text[close + 1] != ':') {
                    return false;
                }
                for (int i = close + 2; i < text.Length; i++) {
                    // Character.isDigit, which takes any Unicode digit; the ASCII check below then refuses the rest.
                    if (!char.IsDigit(text[i])) {
                        return false;
                    }
                }
                portText = text[(close + 2)..];
            }
        }
        else {
            int colon = text.IndexOf(':');
            if (colon >= 0 && text.IndexOf(':', colon + 1) == -1) {
                host = text[..colon];
                portText = text[(colon + 1)..];
            }
            else {
                host = text;
                portText = null;
            }
        }
        if (string.IsNullOrEmpty(portText)) {
            return true;
        }
        if (portText.StartsWith('+') || portText.Any(c => c > 127)
            || !int.TryParse(portText, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out int parsed) || parsed is < 0 or > 65535) {
            return false;
        }
        port = parsed;
        return true;
    }

    /// <summary>
    /// <c>IDN.toASCII</c> without its flags: an ASCII host comes back as it is once each label is checked
    /// for being empty or over 63 characters, which is all Java checks without the STD3 rules; anything
    /// else goes through punycode. Null where Java throws.
    /// </summary>
    private static string? ToAscii(string host) {
        if (host.All(c => c < 128)) {
            string[] labels = host.Split('.');
            for (int i = 0; i < labels.Length; i++) {
                bool rootSeparator = i == labels.Length - 1 && i > 0;
                if (labels[i].Length == 0 && !rootSeparator || labels[i].Length > 63) {
                    return null;
                }
            }
            return host;
        }
        try {
            return new IdnMapping().GetAscii(host);
        }
        catch (ArgumentException) {
            return null;
        }
    }

    public override string ToString() => RawHost.Contains(':') ? $"[{RawHost}]:{Port}" : $"{RawHost}:{Port}";
}
