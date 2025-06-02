namespace Minecraft.NBT;

public interface ITag {
    byte GetPrefix();
    byte[] Serialise(bool noType = false);
}