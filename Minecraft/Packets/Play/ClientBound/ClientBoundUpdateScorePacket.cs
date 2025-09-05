using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Objectives;
using Minecraft.Text;

namespace Minecraft.Packets.Play.ClientBound;

public class ClientBoundUpdateScorePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:set_score";
    
    public required string EntityName { get; init; }
    public required string ObjectiveName { get; init; }
    public required int Value { get; init; }
    public required TextComponent? DisplayName { get; init; }
    public required INumberFormat? NumberFormat { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry registry) {
        return w.WriteString(EntityName)
            .WriteString(ObjectiveName)
            .WriteVarInt(Value)
            .WritePrefixedOptional(DisplayName, (component, wr) => wr.WriteNbt(component))
            .WritePrefixedOptional(NumberFormat, (format, wr) => format.WriteData(wr, registry));
    }
    
    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundUpdateScorePacket {
        EntityName = r.ReadString(),
        ObjectiveName = r.ReadString(),
        Value = r.ReadVarInt(),
        DisplayName = r.ReadPrefixedOptional(r2 => r2.ReadText()),
        NumberFormat = r.ReadPrefixedOptional<INumberFormat>(r2 => {
            int typeId = r2.ReadVarInt();
            return typeId switch {
                0 => BlankNumberFormat.ReadData(r2, reg),
                1 => StyledNumberFormat.ReadData(r2, reg),
                2 => FixedNumberFormat.ReadData(r2, reg),
                _ => throw new Exception($"Unknown number format type ID: {typeId}")
            };
        })
    };
}
