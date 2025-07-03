namespace Minecraft;

public interface IDataReadable<out T> {
    T Read(DataReader reader);
}
