namespace Minecraft.Implementations.Events;

public interface ICancelableEvent {
    public bool Cancelled { get; set; }
}