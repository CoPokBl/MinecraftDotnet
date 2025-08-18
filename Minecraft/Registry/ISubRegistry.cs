namespace Minecraft.Registry;

public interface ISubRegistry<out TSelf> {
    public TSelf Clone();
    public void Clear();
}
