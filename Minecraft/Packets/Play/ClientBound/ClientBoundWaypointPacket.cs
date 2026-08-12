using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Adds, updates or removes a marker on the client's locator bar.</summary>
public class ClientBoundWaypointPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:waypoint";

    public required WaypointOperation Operation { get; init; }
    public required TrackedWaypoint Waypoint { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt((int)Operation)
            .Write(Waypoint);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundWaypointPacket {
        Operation = (WaypointOperation)r.ReadVarInt(),
        Waypoint = TrackedWaypoint.Read(r)
    };

    public enum WaypointOperation {
        Track = 0,
        Untrack = 1,
        Update = 2
    }
}
