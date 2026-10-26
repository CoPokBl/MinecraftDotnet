using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;

namespace Minecraft.Data.Components;

public abstract record IDataComponent<T> : IDataComponent {
    public abstract Identifier Identifier { get; }
    
    public abstract DataWriter WriteData(T val, DataWriter writer, MinecraftRegistry registry);
    public abstract object ReadData(DataReader reader, MinecraftRegistry registry);

    public abstract bool ValuesEqual(T val1, T val2);

    /// <summary>
    /// How this component reads and writes as data, or null where it has none.
    /// </summary>
    /// <remarks>
    /// <b>Return a cached instance, not a fresh one.</b> This is asked once per component of every
    /// stack read or written, and a codec holds nothing that varies.
    /// <p/>
    /// Null is a claim, not a gap to fill in silently. Three components upstream have no persistent
    /// form at all, and a component that simply has no port here says so on itself; either way a
    /// caller has to report the absence by name rather than substitute a value.
    /// </remarks>
    public virtual NbtCodec<T>? Codec => null;

    public bool HasNbtForm => Codec is not null;

    public INbtTag ToNbt(object val, MinecraftRegistry registry) {
        return Required().ToNbt((T)val, registry);
    }

    public object FromNbt(INbtTag tag, MinecraftRegistry registry) {
        return Required().FromNbt(tag, registry)!;
    }
    
    public bool ValuesEqual(object val1, object val2) {
        if (val1 is not T v1 || val2 is not T v2) {
            return false;
        }

        return ValuesEqual(v1, v2);
    }

    public DataWriter WriteData(object val, DataWriter writer, MinecraftRegistry registry) {
        return WriteData((T)val, writer, registry);
    }

    public override int GetHashCode() {
        return Identifier.GetHashCode();
    }

    private NbtCodec<T> Required() {
        return Codec ?? throw new UnportedComponentException(Identifier);
    }
}

/// <summary>
/// Generic interface for data components in Minecraft.
/// </summary>
public interface IDataComponent : IProtocolType {
    public DataWriter WriteData(object val, DataWriter writer, MinecraftRegistry registry);
    public object ReadData(DataReader reader, MinecraftRegistry registry);
    
    public bool ValuesEqual(object val1, object val2);

    /// <summary>Whether this component can be read and written as data at all.</summary>
    public bool HasNbtForm { get; }

    /// <summary>
    /// The value as a datapack spells it, which is also how an item stack saves it. This is vanilla's
    /// <c>DataComponentType.codec</c> and is <b>not</b> the network form: the wire carries neither
    /// key names nor defaults, so several components differ between the two and neither can be
    /// derived from the other.
    /// </summary>
    /// <exception cref="UnportedComponentException">There is no persistent form.</exception>
    public INbtTag ToNbt(object val, MinecraftRegistry registry);

    /// <inheritdoc cref="ToNbt"/>
    public object FromNbt(INbtTag tag, MinecraftRegistry registry);
}
