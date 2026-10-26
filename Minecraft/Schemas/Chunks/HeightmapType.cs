namespace Minecraft.Schemas.Chunks;

/// <summary>
/// Vanilla's <c>Heightmap.Types</c>. The value is the protocol id, which upstream is the enum's own
/// <c>id</c> field and travels through <c>ByteBufCodecs.idMapper</c> rather than as an ordinal.
/// </summary>
/// <remarks>
/// Only three of these are ever sent. <c>ClientboundLevelChunkPacketData</c> filters on
/// <c>Types.sendToClient()</c>, which is <c>usage == CLIENT</c>, and that is
/// <see cref="WorldSurface"/>, <see cref="MotionBlocking"/> and <see cref="MotionBlockingNoLeaves"/>.
/// <see cref="OceanFloor"/> looks like it belongs with them and does not: it is <c>LIVE_WORLD</c>, kept
/// on the server. The two <c>_WG</c> pair are <c>WORLDGEN</c> and are discarded once a chunk is
/// generated. <see cref="Heightmaps.SentToClient"/> is the list to use rather than picking by hand.
/// </remarks>
public enum HeightmapType {
    WorldSurfaceWorldgen = 0,
    WorldSurface = 1,
    OceanFloorWorldgen = 2,
    OceanFloor = 3,
    MotionBlocking = 4,
    MotionBlockingNoLeaves = 5
}
