using NBT;
using NBT.Tags;

namespace Minecraft.Implementations.Storage;

/// <summary>
/// A whole NBT file: a compound written with a name of its own, which is the shape every file on disk
/// takes and no tag inside one does.
/// </summary>
/// <remarks>
/// Serialising a compound writes its type and its children and stops, so a file cannot be produced by
/// serialising the root. Wrapping it in another compound gets the name in but leaves a spare type byte
/// at the front and a spare end byte at the back, and a vanilla reader counts both against the length
/// the region file recorded.
/// </remarks>
public static class NbtRoot {
    public static byte[] Serialise(CompoundTag root, string name = "") {
        NbtBuilder builder = new();
        builder.Write(NbtTagPrefix.Compound);
        builder.WriteString(name);
        root.Write(builder, true);
        return builder.ToArray();
    }

    /// <exception cref="InvalidDataException">The bytes are not a whole NBT file.</exception>
    public static CompoundTag Parse(byte[] data) {
        // The reader's implied root mode brackets the bytes with the type and end this one omits, and
        // hands back the outer compound holding the real root under its name.
        CompoundTag wrapper;
        try {
            wrapper = NbtReader.ReadNbt(data, true).GetCompound();
        } catch (Exception e) when (e is not InvalidDataException) {
            // The reader reports truncated or malformed input as whatever its indexing hit, an
            // ArgumentOutOfRangeException as often as an end of stream. Telling damaged bytes apart
            // from a fault is what a caller deciding whether to regenerate needs, so they are all one
            // exception here, as NbtIo's are one family upstream.
            throw new InvalidDataException("The data is not a whole NBT file.", e);
        }

        foreach ((string _, INbtTag child) in wrapper.Children) {
            return child.GetCompound();
        }

        throw new InvalidDataException("NBT data holds no root tag.");
    }
}
