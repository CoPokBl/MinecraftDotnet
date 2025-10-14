namespace NBT.Tags;

public class EmptyTag : INbtTag<EmptyTag> {
    
    public byte GetPrefix() {
        return NbtTagPrefix.End;
    }

    public string GetName() {
        throw new NotSupportedException("EmptyTag may only be used at the root level.");
    }

    public EmptyTag WithName(string? name) {
        throw new NotSupportedException("EmptyTag may only be used at the root level.");
    }

    INbtTag INbtTag.WithName(string? name) {
        throw new NotSupportedException("EmptyTag may only be used at the root level.");
    }

    public byte[] Serialise(bool noType = false) {
        return new NbtBuilder()
            .Write(GetPrefix())
            .ToArray();
    }
}
