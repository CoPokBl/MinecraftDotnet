using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Objectives;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateObjectivePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_objective";
    
    public required string ObjectiveName { get; init; }
    public required Mode UpdateMode { get; init; }
    public TextComponent? ObjectiveValue { get; init; }
    public Type? ObjectiveType { get; init; }
    public Optional<INumberFormat>? NumberFormat { get; init; }
    
    public static ClientBoundUpdateObjectivePacket Remove(string objectiveName) => new() {
        ObjectiveName = objectiveName,
        UpdateMode = Mode.Remove
    };
    
    public enum Mode : sbyte {
        Create = 0,
        Remove = 1,
        UpdateText = 2
    }
    
    public enum Type {
        Integer = 0,
        Hearts = 1
    }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        w.WriteString(ObjectiveName);
        w.WriteByte((sbyte)UpdateMode);

        if (UpdateMode == Mode.Remove) return w;
        
        w.WriteNbt(ObjectiveValue.ThrowIfNull());
        w.WriteVarInt((int)ObjectiveType.ThrowIfNull());
        w.WritePrefixedOptional(NumberFormat.ThrowIfNull(), (format, wr) => 
            format.WriteData(wr, reg));

        return w;
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => {
        string objectiveName = r.ReadString();
        Mode updateMode = (Mode)r.ReadByte();

        if (updateMode == Mode.Remove) {
            return new ClientBoundUpdateObjectivePacket {
                ObjectiveName = objectiveName,
                UpdateMode = updateMode
            };
        }

        TextComponent objectiveValue = r.ReadText();
        Type objectiveType = (Type)r.ReadVarInt();
        INumberFormat? numberFormat = r.ReadPrefixedOptional<INumberFormat>(re => {
            int formatType = re.ReadVarInt();
            return formatType switch {
                0 => BlankNumberFormat.ReadData(re, reg),
                1 => StyledNumberFormat.ReadData(re, reg),
                2 => FixedNumberFormat.ReadData(re, reg),
                _ => throw new Exception($"Unknown number format type: {formatType}")
            };
        });

        return new ClientBoundUpdateObjectivePacket {
            ObjectiveName = objectiveName,
            UpdateMode = updateMode,
            ObjectiveValue = objectiveValue,
            ObjectiveType = objectiveType,
            NumberFormat = new Optional<INumberFormat>(numberFormat)
        };
    };
}
