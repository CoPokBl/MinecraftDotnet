namespace Minecraft.Schemas;

public record CustomModelData(float[] Floats, bool[] Flags, string[] Strings, int[] Colors) {
    public virtual bool Equals(CustomModelData? other) {
        if (other == null) return false;
        if (!Floats.SequenceEqual(other.Floats)) return false;
        if (!Flags.SequenceEqual(other.Flags)) return false;
        if (!Strings.SequenceEqual(other.Strings)) return false;
        if (!Colors.SequenceEqual(other.Colors)) return false;
        return true;
    }

    public override int GetHashCode() {
        int hash = Floats.Aggregate(17, (current, f) => current * 31 + f.GetHashCode());
        hash = Flags.Aggregate(hash, (current, b) => current * 31 + b.GetHashCode());
        hash = Strings.Aggregate(hash, (current, s) => current * 31 + s.GetHashCode());
        return Colors.Aggregate(hash, (current, i) => current * 31 + i.GetHashCode());
    }
}
