using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundGameEventPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:game_event";
    
    public required GameEvent Event { get; init; }
    public required float Value { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteUnsignedByte((byte)Event)
            .WriteFloat(Value);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundGameEventPacket {
        Event = (GameEvent)r.Read(),
        Value = r.ReadFloat()
    };
    
    public static ClientBoundGameEventPacket ChangeGameMode(GameMode mode) {
        return new ClientBoundGameEventPacket {
            Event = GameEvent.ChangeGameMode,
            Value = mode switch {
                GameMode.Survival => 0,
                GameMode.Creative => 1,
                GameMode.Adventure => 2,
                GameMode.Spectator => 3,
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
            }
        };
    }
}
