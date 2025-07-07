namespace Minecraft.Schemas.Shapes;

public record CompositeBox(params ICollisionBox[] Children) : ICollisionBox;
