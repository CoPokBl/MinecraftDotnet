using Minecraft;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace ClientLib.Multiplayer;

/// <summary><c>ServerData.ServerPackStatus</c>: whether a server's resource packs are taken, refused, or asked about.</summary>
public enum ServerPackStatus {
    Enabled,
    Disabled,
    Prompt
}

/// <summary><c>ServerData.State</c>.</summary>
public enum ServerState {
    Initial,
    Pinging,
    Unreachable,
    Incompatible,
    Successful
}

/// <summary><c>ServerData.Type</c>.</summary>
public enum ServerType {
    Lan,
    Realm,
    Other
}

/// <summary><c>ServerStatus.Players</c>.</summary>
public sealed record ServerPlayers(int Max, int Online, IReadOnlyList<(Guid Id, string Name)> Sample);

/// <summary>
/// <c>ServerData</c>: a server list entry, what its last ping said, and what is remembered about it in
/// <c>servers.dat</c>. The ping writes the status fields from a worker thread, as vanilla's does.
/// </summary>
public sealed class ServerData(string name, string ip, ServerType type) {
    private const int MaxIconSize = 1024;

    public string Name { get; set; } = name;
    public string Ip { get; set; } = ip;
    public TextComponent? Status { get; set; }
    public TextComponent? Motd { get; set; }
    public ServerPlayers? Players { get; set; }
    public long Ping { get; set; }
    public int Protocol { get; set; } = ProtocolConstants.ProtocolVersion;
    public TextComponent Version { get; set; } = TextComponent.Text(ProtocolConstants.CurrentVersionString);
    public IReadOnlyList<TextComponent> PlayerList { get; set; } = [];

    /// <summary>The server's resource pack policy, which the join hands to whatever downloads server packs.</summary>
    public ServerPackStatus ResourcePackStatus { get; set; } = ServerPackStatus.Prompt;
    public byte[]? IconBytes { get; set; }
    public ServerType Type { get; private set; } = type;
    public ServerState State { get; set; } = ServerState.Initial;
    private int _acceptedCodeOfConduct;

    public bool IsLan => Type == ServerType.Lan;
    public bool IsRealm => Type == ServerType.Realm;

    public bool HasAcceptedCodeOfConduct(string codeOfConduct) => _acceptedCodeOfConduct == JavaHashCode(codeOfConduct);

    public void AcceptCodeOfConduct(string codeOfConduct) => _acceptedCodeOfConduct = JavaHashCode(codeOfConduct);

    public void ClearCodeOfConduct() => _acceptedCodeOfConduct = 0;

    /// <summary><c>String.hashCode</c>, which is what vanilla remembers an accepted code of conduct by.</summary>
    public static int JavaHashCode(string text) {
        int hash = 0;
        foreach (char c in text) {
            hash = unchecked(31 * hash + c);
        }
        return hash;
    }

    /// <summary><c>write</c>.</summary>
    public CompoundTag Write() {
        List<(string, INbtTag)> children = [("name", new StringTag(Name)), ("ip", new StringTag(Ip))];
        if (IconBytes != null) {
            children.Add(("icon", new StringTag(Convert.ToBase64String(IconBytes))));
        }
        // FIELD_CODEC: Codec.BOOL under acceptTextures, absent for prompt.
        if (ResourcePackStatus != ServerPackStatus.Prompt) {
            children.Add(("acceptTextures", new ByteTag((sbyte)(ResourcePackStatus == ServerPackStatus.Enabled ? 1 : 0))));
        }
        if (_acceptedCodeOfConduct != 0) {
            children.Add(("acceptedCodeOfConduct", new IntegerTag(_acceptedCodeOfConduct)));
        }
        return new CompoundTag(children.ToArray());
    }

    /// <summary><c>read</c>: a field of the wrong type reads as absent.</summary>
    public static ServerData Read(CompoundTag tag) {
        ServerData server = new(tag["name"] is StringTag name ? name.Value : "", tag["ip"] is StringTag ip ? ip.Value : "", ServerType.Other) {
            IconBytes = tag["icon"] is StringTag icon ? DecodeBase64(icon.Value) : null,
            ResourcePackStatus = NumericValue(tag["acceptTextures"]) is { } accept ? (sbyte)accept != 0 ? ServerPackStatus.Enabled : ServerPackStatus.Disabled
                : ServerPackStatus.Prompt,
            _acceptedCodeOfConduct = NumericValue(tag["acceptedCodeOfConduct"]) is { } accepted ? (int)accepted : 0
        };
        return server;
    }

    /// <summary>A <c>NumericTag</c>'s value, or null for any other tag.</summary>
    internal static long? NumericValue(INbtTag? tag) => tag switch {
        ByteTag b => b.Value,
        ShortTag s => s.Value,
        IntegerTag i => i.Value,
        LongTag l => l.Value,
        FloatTag f => (long)f.Value,
        DoubleTag d => (long)d.Value,
        _ => null
    };

    /// <summary><c>ExtraCodecs.BASE64_STRING</c>, Java's basic decoder, which takes no whitespace.</summary>
    internal static byte[]? DecodeBase64(string text) {
        if (text.Any(char.IsWhiteSpace)) {
            return null;
        }
        try {
            return Convert.FromBase64String(text);
        }
        catch (FormatException) {
            return null;
        }
    }

    public void CopyNameIconFrom(ServerData other) {
        Ip = other.Ip;
        Name = other.Name;
        IconBytes = other.IconBytes;
    }

    public void CopyFrom(ServerData other) {
        CopyNameIconFrom(other);
        ResourcePackStatus = other.ResourcePackStatus;
        Type = other.Type;
    }

    /// <summary><c>validateIcon</c>: a PNG no bigger than 1024 square, else nothing.</summary>
    public static byte[]? ValidateIcon(byte[]? bytes) {
        if (bytes != null && PngSize(bytes) is { } size && size.Width <= MaxIconSize && size.Height <= MaxIconSize) {
            return bytes;
        }
        return null;
    }

    /// <summary><c>PngInfo.fromBytes</c>: the signature, then the IHDR chunk's size.</summary>
    private static (int Width, int Height)? PngSize(byte[] bytes) {
        ReadOnlySpan<byte> signature = [0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A];
        if (bytes.Length < 24 || !bytes.AsSpan(0, 8).SequenceEqual(signature)
            || System.Buffers.Binary.BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(8)) != 13
            || !bytes.AsSpan(12, 4).SequenceEqual("IHDR"u8)) {
            return null;
        }
        return (System.Buffers.Binary.BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(16)), System.Buffers.Binary.BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(20)));
    }
}
