using Minecraft.NBT.Tags;

namespace Minecraft.NBT;

public interface ITag {
    /// <summary>
    /// Get the NBT prefix of this tag.
    /// </summary>
    /// <returns>The byte ID of this data type.</returns>
    byte GetPrefix();
    
    /// <summary>
    /// Gets the name of this tag in a compound tag.
    /// If this tag is not part of a compound tag this should be null.
    /// </summary>
    /// <returns>This tag's name or null.</returns>
    string? GetName();
    
    /// <summary>
    /// Serialise this NBT tag into a byte array.
    /// </summary>
    /// <param name="noType">
    /// Whether to omit the type of this tag in its serialised representation.
    /// Use <see cref="GetPrefix"/> to find the type of this tag.
    /// </param>
    /// <returns>A byte array containing the serialised version of this tag with no padding.</returns>
    byte[] Serialise(bool noType = false);
}

public static class TagExtensions {

    public static string GetString(this ITag tag) {
        return ((StringTag)tag).Value;
    }
    
    public static byte GetByte(this ITag tag) {
        return ((ByteTag)tag).Value;
    }
    
    public static double GetDouble(this ITag tag) {
        return ((DoubleTag)tag).Value;
    }
    
    public static float GetFloat(this ITag tag) {
        return ((FloatTag)tag).Value;
    }
    
    public static int GetInteger(this ITag tag) {
        return ((IntegerTag)tag).Value;
    }
    
    public static bool GetBoolean(this ITag tag) {
        return ((ByteTag)tag).BoolValue;
    }
}