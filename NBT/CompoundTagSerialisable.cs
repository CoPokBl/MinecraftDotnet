using NBT.Tags;

namespace NBT;

public abstract class CompoundTagSerialisable : INbtTag<CompoundTagSerialisable> {
    public string? ComponentName;  // name for this NBT tag when it gets serialised (so it can be nested)
    
    public byte GetPrefix() {
        return NbtTagPrefix.Compound;
    }

    public string? GetName() {
        return ComponentName;
    }
    
    CompoundTagSerialisable INbtTag<CompoundTagSerialisable>.WithName(string? name) {
        ComponentName = name;
        return this;
    }

    public INbtTag WithName(string? name) => ((INbtTag<CompoundTagSerialisable>)this).WithName(name);
    
    /// <summary>
    /// Internal method that is used to format the NBT to be used in packets.
    /// <p/>
    /// It is not recommended to change this unless you know what you're doing.
    /// </summary>
    /// <param name="name">The name to give this tag.</param>
    /// <returns>This TextComponent with its name changed.</returns>
    public CompoundTagSerialisable WithComponentName(string? name) {
        ComponentName = name;
        return this;
    }

    public byte[] Serialise(bool noType = false) {
        return SerialiseToTag().Serialise(noType);
    }

    public abstract CompoundTag SerialiseToTag();
}
