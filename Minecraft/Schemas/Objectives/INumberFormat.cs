using Minecraft.Registry;

namespace Minecraft.Schemas.Objectives;

public interface INumberFormat<out TSelf> : INumberFormat {
    public static abstract TSelf ReadData(DataReader reader, MinecraftRegistry registry);
}

public interface INumberFormat {
    int TypeId { get; }
    DataWriter WriteData(DataWriter writer, MinecraftRegistry registry);
}
