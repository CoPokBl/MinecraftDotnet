using ClientLib.World;
using Minecraft.Packets.Play.ClientBound;

namespace ClientLib;

/// <summary>Filled maps' pixels and markers, as the server sends them.</summary>
public sealed partial class MinecraftClient {
    // ClientLevel's mapData, which handleRespawn carries into the new level, so only a login drops it.
    private readonly Dictionary<int, ClientMapData> _maps = new();

    /// <summary><c>ClientLevel.getMapData</c>: null for a map the server has sent nothing of.</summary>
    public ClientMapData? MapData(int id) => _maps.GetValueOrDefault(id);

    /// <summary><c>handleMapItemData</c>.</summary>
    internal void HandleMapData(ClientBoundMapDataPacket packet) {
        if (!_maps.TryGetValue(packet.MapId, out ClientMapData? data)) {
            data = new ClientMapData(packet.Scale, packet.Locked);
            _maps[packet.MapId] = data;
        }
        data.Apply(packet);
    }
}
