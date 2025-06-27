namespace Minecraft.Schemas.Vec;

public record SVec3(short X, short Y, short Z) {
    public static readonly SVec3 Zero = new(0, 0, 0);
}