namespace Minecraft.NBT.Tags;

public class BooleanTag(string? name, bool val) : ByteTag(name, (byte)(val ? 0x01 : 0x00));
