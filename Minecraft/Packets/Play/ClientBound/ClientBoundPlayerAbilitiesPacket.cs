using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundPlayerAbilitiesPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:player_abilities";
    
    public required Abilities Flags;
    public required float FlyingSpeed;  // 0.05 by default
    public required float FovModifier;  // 0.1 by default
    
    [Flags]
    public enum Abilities {
        Invulnerable = 0x01,
        Flying = 0x02,
        AllowFlying = 0x04,
        CreativeMode = 0x08
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteByte((int)Flags)
            .WriteFloat(FlyingSpeed)
            .WriteFloat(FovModifier);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundPlayerAbilitiesPacket {
        Flags = (Abilities)r.ReadByte(),
        FlyingSpeed = r.ReadFloat(),
        FovModifier = r.ReadFloat()
    };
}
