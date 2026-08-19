using System.Buffers;
using Minecraft.Registry;

namespace Minecraft.Schemas.Chunks;

/// <summary>
/// The heightmaps a chunk carries on the wire, computed over its finished contents.
/// </summary>
/// <remarks>
/// Each entry is vanilla's <c>Heightmap.getFirstAvailable</c>: <b>one above</b> the highest position
/// whose state matches the type's predicate, and zero for a column where nothing does. Everything is
/// in protocol y, since vanilla stores <c>y - minY</c> and counts from an already offset y.
/// <p/>
/// A scan, as vanilla's is (<c>ChunkGenerator</c> calls <c>primeHeightmaps</c> after
/// <c>fillFromNoise</c>), and not a running total: air written over something invalidates one, which a
/// carver does, a decorator does, and a player placing a block does forever after.
/// <p/>
/// The scan is palette aware rather than per block, so a section holding one state resolves all 256
/// columns from a single predicate, and the walk stops once all three maps know every column.
/// </remarks>
public sealed class Heightmaps {
    public const int Columns = 256;

    /// <summary>
    /// The three <c>Types.sendToClient()</c> selects, in id order. Not every type: <c>OCEAN_FLOOR</c>
    /// is <c>LIVE_WORLD</c> and the <c>_WG</c> pair are discarded after generation.
    /// </summary>
    public static readonly HeightmapType[] SentToClient =
        [HeightmapType.WorldSurface, HeightmapType.MotionBlocking, HeightmapType.MotionBlockingNoLeaves];

    /// <summary>Indexed by <c>z * 16 + x</c>, as vanilla's <c>SimpleBitStorage</c> is.</summary>
    public ushort[] WorldSurface { get; }
    public ushort[] MotionBlocking { get; }
    public ushort[] MotionBlockingNoLeaves { get; }

    private Heightmaps(ushort[] worldSurface, ushort[] motionBlocking, ushort[] motionBlockingNoLeaves) {
        WorldSurface = worldSurface;
        MotionBlocking = motionBlocking;
        MotionBlockingNoLeaves = motionBlockingNoLeaves;
    }

    public ushort[] Of(HeightmapType type) {
        return type switch {
            HeightmapType.WorldSurface => WorldSurface,
            HeightmapType.MotionBlocking => MotionBlocking,
            HeightmapType.MotionBlockingNoLeaves => MotionBlockingNoLeaves,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type,
                "Only the three client sent heightmaps are computed.")
        };
    }

    /// <summary>All three in one top down pass.</summary>
    public static Heightmaps Compute(ChunkData chunk, MinecraftRegistry registry) {
        ushort[] worldSurface = new ushort[Columns];
        ushort[] motionBlocking = new ushort[Columns];
        ushort[] motionBlockingNoLeaves = new ushort[Columns];

        // Zero is the "not found yet" sentinel and can never be a real answer, since an answer is a
        // position plus one.
        int unknownWorldSurface = Columns;
        int unknownMotionBlocking = Columns;
        int unknownNoLeaves = Columns;

        uint[]? flat = null;
        try {
            for (int s = chunk.Sections.Length - 1; s >= 0; s--) {
                if (unknownWorldSurface == 0 && unknownMotionBlocking == 0 && unknownNoLeaves == 0) {
                    break;
                }

                ChunkSection section = chunk.Sections[s];
                int sectionBottom = s * ChunkSection.Size;

                uint? uniform = section.UniformState;
                if (uniform is not null) {
                    byte flags = HeightmapStates.FlagsOf(uniform.Value, registry);
                    if (flags == 0) {
                        continue;  // an air section, which is most of a world
                    }

                    // Every column's answer is the top of this section, for whichever maps match.
                    ushort value = (ushort)(sectionBottom + ChunkSection.Size);
                    if ((flags & HeightmapStates.NotAir) != 0) {
                        FillUnknown(worldSurface, value, ref unknownWorldSurface);
                    }
                    if ((flags & HeightmapStates.MotionBlocking) != 0) {
                        FillUnknown(motionBlocking, value, ref unknownMotionBlocking);
                    }
                    if ((flags & HeightmapStates.MotionBlockingNoLeaves) != 0) {
                        FillUnknown(motionBlockingNoLeaves, value, ref unknownNoLeaves);
                    }

                    continue;
                }

                flat ??= ArrayPool<uint>.Shared.Rent(ChunkSection.Size * Columns);
                section.FillFlatStateIds(flat);

                for (int y = ChunkSection.Size - 1; y >= 0; y--) {
                    if (unknownWorldSurface == 0 && unknownMotionBlocking == 0 && unknownNoLeaves == 0) {
                        break;
                    }

                    ushort value = (ushort)(sectionBottom + y + 1);
                    int rowStart = y * Columns;

                    for (int column = 0; column < Columns; column++) {
                        // Nothing left to learn about this column, so skip the lookup entirely.
                        if (worldSurface[column] != 0 && motionBlocking[column] != 0
                            && motionBlockingNoLeaves[column] != 0) {
                            continue;
                        }

                        byte flags = HeightmapStates.FlagsOf(flat[rowStart + column], registry);
                        if (flags == 0) {
                            continue;
                        }

                        Record(worldSurface, column, value, flags, HeightmapStates.NotAir,
                            ref unknownWorldSurface);
                        Record(motionBlocking, column, value, flags, HeightmapStates.MotionBlocking,
                            ref unknownMotionBlocking);
                        Record(motionBlockingNoLeaves, column, value, flags,
                            HeightmapStates.MotionBlockingNoLeaves, ref unknownNoLeaves);
                    }
                }
            }
        } finally {
            if (flat != null) {
                ArrayPool<uint>.Shared.Return(flat);
            }
        }

        return new Heightmaps(worldSurface, motionBlocking, motionBlockingNoLeaves);
    }

    private static void FillUnknown(ushort[] map, ushort value, ref int unknown) {
        if (unknown == 0) {
            return;
        }

        for (int i = 0; i < Columns; i++) {
            if (map[i] == 0) {
                map[i] = value;
            }
        }

        unknown = 0;
    }

    private static void Record(ushort[] map, int column, ushort value, byte flags, byte wanted,
        ref int unknown) {

        if (map[column] != 0 || (flags & wanted) == 0) {
            return;
        }

        map[column] = value;
        unknown--;
    }

    /// <summary>
    /// The wire form: a VarInt count, then each map as its type id and a VarInt prefixed long array.
    /// </summary>
    /// <remarks>
    /// <c>ByteBufCodecs.map</c> over <c>Types.STREAM_CODEC</c> and <c>ByteBufCodecs.LONG_ARRAY</c>, and
    /// the long array codec <em>is</em> length prefixed, unlike the one a paletted container writes.
    /// </remarks>
    public void Write(DataWriter w, int worldHeight) {
        int bits = Mth.CeilLog2(worldHeight + 1);

        w.WriteVarInt(SentToClient.Length);
        foreach (HeightmapType type in SentToClient) {
            w.WriteVarInt((int)type);
            w.WritePrefixedPacketDataArray(bits, Of(type));
        }
    }

    /// <summary>
    /// Reads what <see cref="Write"/> wrote, keeping the three types this holds and skipping any
    /// other. Nothing in the server path reads a chunk back off the wire, but a reader that discarded
    /// these would make a round trip through <c>PolarLoader</c> lossy.
    /// </summary>
    public static Heightmaps? Read(DataReader r, int worldHeight) {
        int bits = Mth.CeilLog2(worldHeight + 1);
        int count = r.ReadVarInt();

        ushort[] worldSurface = new ushort[Columns];
        ushort[] motionBlocking = new ushort[Columns];
        ushort[] motionBlockingNoLeaves = new ushort[Columns];
        bool any = false;

        for (int i = 0; i < count; i++) {
            HeightmapType type = (HeightmapType)r.ReadVarInt();
            int longCount = r.ReadVarInt();

            int entriesPerLong = 64 / bits;
            int entries = longCount * entriesPerLong;
            uint[] values = r.ReadPacketDataArray32(bits, entries);

            ushort[]? target = type switch {
                HeightmapType.WorldSurface => worldSurface,
                HeightmapType.MotionBlocking => motionBlocking,
                HeightmapType.MotionBlockingNoLeaves => motionBlockingNoLeaves,
                _ => null
            };

            if (target == null) {
                continue;
            }

            for (int c = 0; c < Columns && c < values.Length; c++) {
                target[c] = (ushort)values[c];
            }
            any = true;
        }

        return any ? new Heightmaps(worldSurface, motionBlocking, motionBlockingNoLeaves) : null;
    }
}
