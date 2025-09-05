using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundDisplayObjectivePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_display_objective";

    public required DisplayPosition Position { get; init; }
    public required string ScoreName { get; init; }
    
    public enum DisplayPosition {
        List            = 0,
        Sidebar         = 1,
        BelowName       = 2,
        
        // 3-18 are team colors
        // it seems to use the legacy colour code
        // https://minecraft.wiki/w/Formatting_codes
        // where the position int is 3 + the colour code int
        TeamBlack       = 3,
        TeamDarkBlue    = 4,
        TeamDarkGreen   = 5,
        TeamDarkAqua    = 6,
        TeamDarkRed     = 7,
        TeamDarkPurple  = 8,
        TeamGold        = 9,
        TeamGray        = 10,
        TeamDarkGray    = 11,
        TeamBlue        = 12,
        TeamGreen       = 13,
        TeamAqua        = 14,
        TeamRed         = 15,
        TeamLightPurple = 16,
        TeamYellow      = 17,
        TeamWhite       = 18
    }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt((int)Position)
            .WriteString(ScoreName);
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundDisplayObjectivePacket {
        Position = (DisplayPosition)r.ReadVarInt(),
        ScoreName = r.ReadString()
    };
}
