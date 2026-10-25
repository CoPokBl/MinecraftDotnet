using Minecraft.Packets.Play.ClientBound;

namespace ClientLib.World;

/// <summary><c>MapItemSavedData.createForClient</c>: what the server has sent of one map.</summary>
public sealed class ClientMapData(byte scale, bool locked) {
    public const int Size = 128;

    public byte Scale { get; } = scale;
    public bool Locked { get; } = locked;

    /// <summary>A packed <c>MapColor</c> id per pixel, in rows.</summary>
    public byte[] Colors { get; } = new byte[Size * Size];

    /// <summary><c>getDecorations</c>, in the order the server listed them.</summary>
    public IReadOnlyList<ClientBoundMapDataPacket.Decoration> Decorations { get; private set; } = [];

    /// <summary>Counts every update, for whoever draws the pixels to see they changed.</summary>
    public int Version { get; private set; }

    /// <summary><c>ClientboundMapItemDataPacket.applyToMap</c>: the decorations replaced, then the patch painted in.</summary>
    public void Apply(ClientBoundMapDataPacket packet) {
        if (packet.Decorations != null) {
            Decorations = packet.Decorations;
        }
        if (packet.Patch is { } patch) {
            for (int x = 0; x < patch.Width; x++) {
                for (int y = 0; y < patch.Height; y++) {
                    Colors[patch.StartX + x + (patch.StartZ + y) * Size] = patch.Colors[x + y * patch.Width];
                }
            }
        }
        Version++;
    }
}
