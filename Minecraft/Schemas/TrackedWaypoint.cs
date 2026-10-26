using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas;

/// <summary>
/// A marker the client draws on its locator bar. How precisely the position is given depends on
/// how far away the waypoint is: nearby ones send exact coordinates, distant ones only a chunk
/// or a compass bearing.
/// </summary>
public abstract record TrackedWaypoint : IWritable {
    /// <summary>Identifies the waypoint, by entity uuid for players or by a free-form string.</summary>
    public required Or<Guid, string> Id { get; init; }

    public WaypointIcon Icon { get; init; } = new();

    protected abstract WaypointType Type { get; }

    protected abstract void WriteContents(DataWriter w);

    public void Write(DataWriter w) {
        if (Id.IsValue1) {
            w.WriteBoolean(true).WriteUuid(Id.Value1);
        }
        else {
            w.WriteBoolean(false).WriteString(Id.Value2!);
        }

        Icon.Write(w);
        w.WriteVarInt((int)Type);
        WriteContents(w);
    }

    public static TrackedWaypoint Read(DataReader r) {
        Or<Guid, string> id = r.ReadBoolean()
            ? Or<Guid, string>.FromValue1(r.ReadUuid())
            : Or<Guid, string>.FromValue2(r.ReadString());
        WaypointIcon icon = WaypointIcon.Read(r);

        return (WaypointType)r.ReadVarInt() switch {
            WaypointType.Empty => new Empty { Id = id, Icon = icon },
            WaypointType.Position => new Position {
                Id = id, Icon = icon,
                Location = new Vec3<int>(r.ReadVarInt(), r.ReadVarInt(), r.ReadVarInt())
            },
            WaypointType.Chunk => new Chunk {
                Id = id, Icon = icon,
                ChunkX = r.ReadVarInt(), ChunkZ = r.ReadVarInt()
            },
            WaypointType.Azimuth => new Azimuth { Id = id, Icon = icon, Angle = r.ReadFloat() },
            var type => throw new ArgumentOutOfRangeException(nameof(r), type, "Unknown waypoint type")
        };
    }

    /// <summary>Carries no position, used when untracking a waypoint.</summary>
    public record Empty : TrackedWaypoint {
        protected override WaypointType Type => WaypointType.Empty;

        protected override void WriteContents(DataWriter w) { }
    }

    /// <summary>An exact block position, sent when the waypoint is close enough to pinpoint.</summary>
    public record Position : TrackedWaypoint {
        public required Vec3<int> Location { get; init; }

        protected override WaypointType Type => WaypointType.Position;

        protected override void WriteContents(DataWriter w) {
            w.WriteVarInt(Location.X)
                .WriteVarInt(Location.Y)
                .WriteVarInt(Location.Z);
        }
    }

    /// <summary>Only the chunk the waypoint is in, sent at medium range.</summary>
    public record Chunk : TrackedWaypoint {
        public required int ChunkX { get; init; }
        public required int ChunkZ { get; init; }

        protected override WaypointType Type => WaypointType.Chunk;

        protected override void WriteContents(DataWriter w) {
            w.WriteVarInt(ChunkX).WriteVarInt(ChunkZ);
        }
    }

    /// <summary>Only a bearing in radians, sent when the waypoint is too far away to place.</summary>
    public record Azimuth : TrackedWaypoint {
        public required float Angle { get; init; }

        protected override WaypointType Type => WaypointType.Azimuth;

        protected override void WriteContents(DataWriter w) {
            w.WriteFloat(Angle);
        }
    }

    public enum WaypointType {
        Empty = 0,
        Position = 1,
        Chunk = 2,
        Azimuth = 3
    }
}

/// <summary>How a waypoint is drawn on the locator bar.</summary>
public record WaypointIcon : IWritable {
    /// <summary>Key of a waypoint style asset in the resource pack.</summary>
    public Identifier Style { get; init; } = "minecraft:default";

    /// <summary>Packed RGB tint applied to the icon, or null to use the style's own colour.</summary>
    public int? Color { get; init; }

    public void Write(DataWriter w) {
        w.WriteString(Style)
            // Only the three colour channels go on the wire, any alpha is dropped.
            .WritePrefixedOptional(Color, (color, writer) => writer
                .WriteUnsignedByte((byte)((color >> 16) & 0xFF))
                .WriteUnsignedByte((byte)((color >> 8) & 0xFF))
                .WriteUnsignedByte((byte)(color & 0xFF)));
    }

    public static WaypointIcon Read(DataReader r) {
        return new WaypointIcon {
            Style = r.ReadString(),
            Color = r.ReadPrefixedOptionalValue<int>(reader =>
                (reader.Read() << 16) | (reader.Read() << 8) | reader.Read())
        };
    }
}
