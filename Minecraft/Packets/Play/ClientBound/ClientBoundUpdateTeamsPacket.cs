using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateTeamsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_player_team";
    
    public required string TeamName { get; init; }
    public required Method Action { get; init; }
    
    public TextComponent? TeamDisplayName { get; init; }
    public FriendlyFlag? FriendlyFlags { get; init; }
    public NameTagVisibility? NameTagVisibilityRule { get; init; }
    public CollisionRule? CollisionRuleOption { get; init; }
    public TeamColor? Color { get; init; }
    public TextComponent? Prefix { get; init; }
    public TextComponent? Suffix { get; init; }
    /// <summary>
    /// Identifiers of entities to be in this team.
    /// For players, this is their username.
    /// For entities, it's their UUID.
    /// </summary>
    public string[]? Entities { get; init; }
    
    public static ClientBoundUpdateTeamsPacket CreateTeam(string teamName, TextComponent displayName, 
        FriendlyFlag friendlyFlags, NameTagVisibility nameTagVisibility, CollisionRule collisionRule, 
        TeamColor color, TextComponent prefix, TextComponent suffix, string[] entities) => new() {
            TeamName = teamName,
            Action = Method.CreateTeam,
            TeamDisplayName = displayName,
            FriendlyFlags = friendlyFlags,
            NameTagVisibilityRule = nameTagVisibility,
            CollisionRuleOption = collisionRule,
            Color = color,
            Prefix = prefix,
            Suffix = suffix,
            Entities = entities
        };
    
    public static ClientBoundUpdateTeamsPacket UpdateTeamInfo(string teamName, TextComponent displayName, 
        FriendlyFlag friendlyFlags, NameTagVisibility nameTagVisibility, CollisionRule collisionRule, 
        TeamColor color, TextComponent prefix, TextComponent suffix, string[] entities) => new() {
        TeamName = teamName,
        Action = Method.UpdateTeamInfo,
        TeamDisplayName = displayName,
        FriendlyFlags = friendlyFlags,
        NameTagVisibilityRule = nameTagVisibility,
        CollisionRuleOption = collisionRule,
        Color = color,
        Prefix = prefix,
        Suffix = suffix,
        Entities = entities
    };
    
    public static ClientBoundUpdateTeamsPacket RemoveTeam(string teamName) => new() {
        TeamName = teamName,
        Action = Method.RemoveTeam
    };
    
    public static ClientBoundUpdateTeamsPacket AddEntities(string teamName, string[] entities) => new() {
        TeamName = teamName,
        Action = Method.AddEntities,
        Entities = entities
    };
    
    public static ClientBoundUpdateTeamsPacket RemoveEntities(string teamName, string[] entities) => new() {
        TeamName = teamName,
        Action = Method.RemoveEntities,
        Entities = entities
    };
    
    [Flags]
    public enum FriendlyFlag : sbyte {
        AllowFriendlyFire = 0x01,
        SeeInvisibleTeammates = 0x02
    }
    
    public enum Method : sbyte {
        CreateTeam = 0,
        RemoveTeam = 1,
        UpdateTeamInfo = 2,
        AddEntities = 3,
        RemoveEntities = 4
    }
    
    public enum NameTagVisibility {
        Always = 0,
        Never = 1,
        HideForOtherTeams = 2,
        HideForOwnTeam = 3
    }
    
    public enum CollisionRule {
        Always = 0,
        Never = 1,
        PushOtherTeams = 2,
        PushOwnTeam = 3
    }
    
    public enum TeamColor {
        Black = 0,
        DarkBlue = 1,
        DarkGreen = 2,
        DarkAqua = 3,
        DarkRed = 4,
        DarkPurple = 5,
        Gold = 6,
        Gray = 7,
        DarkGray = 8,
        Blue = 9,
        Green = 10,
        Aqua = 11,
        Red = 12,
        LightPurple = 13,
        Yellow = 14,
        White = 15,
        Obfuscated = 16,
        Bold = 17,
        Strikethrough = 18,
        Underlined = 19,
        Italic = 20,
        Reset = 21
    }

    protected override DataWriter WriteData(DataWriter w) {
        w.WriteString(TeamName)
            .WriteByte((sbyte)Action);

        if (Action is Method.CreateTeam or Method.UpdateTeamInfo) {
            // Only the sixteen colours travel; Reset and the formatting codes are sent as no colour.
            TeamColor color = Color.ThrowIfNull();
            w.WriteNbt(TeamDisplayName.ThrowIfNull())
                .WriteNbt(Prefix.ThrowIfNull())
                .WriteNbt(Suffix.ThrowIfNull())
                .WriteVarInt((int)NameTagVisibilityRule.ThrowIfNull())
                .WriteVarInt((int)CollisionRuleOption.ThrowIfNull())
                .WritePrefixedOptional(color <= TeamColor.White ? (TeamColor?)color : null, (c, wr) => wr.WriteVarInt((int)c))
                .WriteByte((sbyte)FriendlyFlags.ThrowIfNull());
        }

        if (Action is Method.CreateTeam or Method.AddEntities or Method.RemoveEntities) {
            w.WritePrefixedArray(Entities.ThrowIfNull(), (s, wr) => wr.WriteString(s));
        }
        
        return w;
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (w, _) => {
        string name = w.ReadString();
        Method action = (Method)w.ReadByte();
        
        TextComponent? displayName = null;
        FriendlyFlag? friendlyFlags = null;
        NameTagVisibility? nameTagVisibility = null;
        CollisionRule? collisionRule = null;
        TeamColor? color = null;
        TextComponent? prefix = null;
        TextComponent? suffix = null;
        string[]? entities = null;
        
        if (action is Method.CreateTeam or Method.UpdateTeamInfo) {
            displayName = w.ReadText();
            prefix = w.ReadText();
            suffix = w.ReadText();
            nameTagVisibility = (NameTagVisibility)w.ReadVarInt();
            collisionRule = (CollisionRule)w.ReadVarInt();
            color = w.ReadBoolean() ? (TeamColor)w.ReadVarInt() : TeamColor.Reset;
            friendlyFlags = (FriendlyFlag)w.ReadByte();
        }
        
        if (action is Method.CreateTeam or Method.AddEntities or Method.RemoveEntities) {
            entities = w.ReadPrefixedArray(wr => wr.ReadString());
        }

        return new ClientBoundUpdateTeamsPacket {
            TeamName = name,
            Action = action,
            TeamDisplayName = displayName,
            FriendlyFlags = friendlyFlags,
            NameTagVisibilityRule = nameTagVisibility,
            CollisionRuleOption = collisionRule,
            Color = color,
            Prefix = prefix,
            Suffix = suffix,
            Entities = entities
        };
    };
}
