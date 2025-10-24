using Minecraft.Data;
using Minecraft.Data.Attributes;
using Minecraft.Registry;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Attributes;
using Minecraft.Text;

namespace Minecraft.Schemas;

public record ItemAttributeModifier(
    IAttribute Attribute,
    Identifier Id,
    double Value,
    AttributeOperation Operation,
    EquipmentSlotGroup Slot,
    ItemAttributeModifier.Display DisplayMode) : INetworkType<ItemAttributeModifier> {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(Attribute.ProtocolId)
            .WriteString(Id)
            .WriteDouble(Value)
            .WriteVarInt((int)Operation)
            .WriteVarInt(Slot.ProtocolId)
            .Write(DisplayMode, registry);
    }
    
    public static ItemAttributeModifier ReadData(DataReader reader, MinecraftRegistry registry) {
        return new ItemAttributeModifier(
            registry.Attributes[reader.ReadVarInt()],
            reader.ReadString(),
            reader.ReadDouble(),
            (AttributeOperation)reader.ReadVarInt(),
            EquipmentSlotGroup.FromProtocolId(reader.ReadVarInt()),
            reader.Read<Display>(registry)
        );
    }
    
    public AttributeModifier ToAttributeModifier() {
        return new AttributeModifier(Id, Value, Operation);
    }
    
    public enum DisplayType {
        Default,
        Hidden,
        Override
    }

    public abstract record Display : INetworkType<Display> {
        public static Display DefaultMode() => new Default();
        public static Display HiddenMode() => new Hidden();
        public static Display OverrideMode(TextComponent text) => new Override(text);
        
        
        public abstract DisplayType Type { get; }

        public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
            return WriteDisplayData(writer.WriteVarInt((int)Type), registry);
        }

        public static Display ReadData(DataReader reader, MinecraftRegistry registry) {
            return (DisplayType)reader.ReadVarInt() switch {
                DisplayType.Default => Default.ReadDisplayData(reader, registry),
                DisplayType.Hidden => Hidden.ReadDisplayData(reader, registry),
                DisplayType.Override => Override.ReadDisplayData(reader, registry),
                _ => throw new ArgumentException("Unknown DisplayType: " + reader.ReadVarInt())
            };
        }
        
        protected abstract DataWriter WriteDisplayData(DataWriter writer, MinecraftRegistry registry);
        
        public record Default : Display {
            public override DisplayType Type => DisplayType.Default;
            protected override DataWriter WriteDisplayData(DataWriter writer, MinecraftRegistry registry) => writer;
            public static Display ReadDisplayData(DataReader reader, MinecraftRegistry registry) => new Default();
        }
        
        public record Hidden : Display {
            public override DisplayType Type => DisplayType.Hidden;
            protected override DataWriter WriteDisplayData(DataWriter writer, MinecraftRegistry registry) => writer;
            public static Display ReadDisplayData(DataReader reader, MinecraftRegistry registry) => new Hidden();
        }
        
        public record Override(TextComponent Text) : Display {
            public override DisplayType Type => DisplayType.Override;
            protected override DataWriter WriteDisplayData(DataWriter writer, MinecraftRegistry registry) => writer
                .WriteNbt(Text);
            public static Display ReadDisplayData(DataReader reader, MinecraftRegistry registry) => new Hidden();
        }
    }
}
