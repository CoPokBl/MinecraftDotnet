using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundBossBarPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:boss_event";
    
    public required IActionData Action { get; init; }
    public required Guid Uuid { get; init; }
    
    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteUuid(Uuid)
            .WriteVarInt(Action.ActionId)
            .Write(Action);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundBossBarPacket {
        Action = r.ReadVarInt() switch {
            1 => new Add(r.ReadString(), r.ReadFloat(), (Color)r.ReadVarInt(), (Division)r.ReadVarInt(), (Flags)r.ReadByte()),
            2 => new Remove(),
            3 => new UpdateHealth(r.ReadFloat()),
            4 => new UpdateTitle(r.ReadString()),
            5 => new UpdateStyle((Color)r.ReadVarInt(), (Division)r.ReadVarInt()),
            6 => new UpdateFlags((Flags)r.ReadByte()),
            _ => throw new Exception("Invalid boss bar action")
        },
        Uuid = r.ReadUuid()
    };
    
    public interface IActionData : IWritable {
        public int ActionId { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Title">Title</param>
    /// <param name="Health">From 0 to 1, at around 1.5 starts rendering part of a second health bar</param>
    /// <param name="Color">Color</param>
    /// <param name="Division">Describes the notches within the bar</param>
    /// <param name="Flags">Bit mask. 0x01: should darken sky, 0x02: is dragon bar (used to play end music), 0x04: create fog (previously was also controlled by 0x02)</param>
    public record Add(TextComponent Title, float Health, Color Color, Division Division, Flags Flags) : IActionData {
        public int ActionId => 0;
        
        public void Write(DataWriter w) {
            w.WriteNbt(Title)
                .WriteFloat(Health)
                .WriteVarInt((int)Color)
                .WriteVarInt((int)Division)
                .WriteUnsignedByte((byte)Flags);
        }
    }
    
    public record Remove : IActionData {
        public int ActionId => 1;
        
        public void Write(DataWriter w) { }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Health">From 0 to 1, at around 1.5 starts rendering part of a second health bar</param>
    public record UpdateHealth(float Health) : IActionData {
        public int ActionId => 2;
        
        public void Write(DataWriter w) {
            w.WriteFloat(Health);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Title">Title</param>
    public record UpdateTitle(TextComponent Title) : IActionData {
        public int ActionId => 3;
        
        public void Write(DataWriter w) {
            w.WriteNbt(Title);
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Color">Color</param>
    /// <param name="Division">Describes the notches within the bar</param>
    public record UpdateStyle(Color Color, Division Division) : IActionData {
        public int ActionId => 4;
        
        public void Write(DataWriter w) {
            w.WriteVarInt((int)Color)
                .WriteVarInt((int)Division);
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Flags">Bit mask. 0x01: should darken sky, 0x02: is dragon bar (used to play end music), 0x04: create fog (previously was also controlled by 0x02)</param>
    public record UpdateFlags(Flags Flags) : IActionData {
        public int ActionId => 5;
        
        public void Write(DataWriter w) {
            w.WriteUnsignedByte((byte)Flags);
        }
    }
    
    public enum Color {
        Pink = 0,
        Blue = 1,
        Red = 2,
        Green = 3,
        Yellow = 4,
        Purple = 5,
        White = 6
    }

    public enum Division {
        Zero = 0,
        Six = 1,
        Ten = 2,
        Twelve = 3,
        Twenty = 4
    }
    
    [Flags]
    public enum Flags : byte {
        None = 0,
        DarkenSky = 0x01,
        IsDragonBar = 0x02,
        CreateFog = 0x04
    }
}

