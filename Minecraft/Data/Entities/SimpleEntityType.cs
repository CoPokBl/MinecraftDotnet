using Minecraft.Schemas;

namespace Minecraft.Data.Entities;

public record SimpleEntityType(
    Identifier Identifier, 
    int ProtocolId, 
    bool FireImmune, 
    double Width, 
    double Height, 
    double EyeHeight,
    double Acceleration,
    double Drag,
    int ClientTrackingRange) : IEntityType;
