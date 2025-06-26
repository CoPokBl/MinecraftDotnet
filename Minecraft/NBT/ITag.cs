using Minecraft.NBT.Tags;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

    public static string ToJsonString(ITag tag) {
        return JsonConvert.SerializeObject(ToJson(tag));
    }
    
    public static JToken ToJson(ITag tag) {
        switch (tag) {
            case EmptyTag:
                return JValue.CreateNull();
            case StringTag:
                return tag.GetString();
            case BooleanTag:
                return tag.GetBoolean();
            case ByteTag:
                return tag.GetByte();
            case DoubleTag:
                return tag.GetDouble();
            case FloatTag:
                return tag.GetFloat();
            case IntegerTag:
                return tag.GetInteger();
            case CompoundTag compound: {
                JObject obj = new();
                foreach (KeyValuePair<string, ITag> kvp in compound.ChildrenMap) {
                    obj[kvp.Key] = ToJson(kvp.Value);
                }

                return obj;
            }
            case ListTag list: {
                JArray arr = [];
                foreach (ITag item in list.Tags) {
                    arr.Add(item.ToJson());
                }

                return arr;
            }
            case CompoundTagSerialisable cts:
                return ToJson(cts.SerialiseToTag());
            default:
                throw new NotImplementedException("Cannot serialise tag of type " + tag.GetType().Name + " to JSON.");
        }
    }

    public static ITag FromJson(string json) {
        return FromJson(null, JsonConvert.DeserializeObject<JToken>(json)!);
    }
    
    public static ITag FromJson(string? name, JToken json) {
        if (json is JObject obj) {
            // compound tag
            List<ITag> tags = [];
            foreach (KeyValuePair<string, JToken?> kvp in obj) {
                tags.Add(FromJson(kvp.Key, kvp.Value!));
            }
            return new CompoundTag(name, tags.ToArray());
        }
        
        if (json is JArray arr) {
            // list tag
            List<ITag> tags = [];
            foreach (JToken item in arr) {
                tags.Add(FromJson(null, item));
            }
            return new ListTag(name, tags.ToArray());
        }
        
        // primitive tag
        if (json.Type == JTokenType.Null) {
            return new EmptyTag();
        }
        
        if (json.Type == JTokenType.Boolean) {
            return new BooleanTag(name, json.ToObject<bool>());
        }
        
        if (json.Type == JTokenType.String) {
            return new StringTag(name, json.ToString());
        }
        
        if (json.Type == JTokenType.Integer) {
            return new IntegerTag(name, json.ToObject<int>());
        }
        
        if (json.Type == JTokenType.Float) {
            return new DoubleTag(name, json.ToObject<float>());  // use high precision for doubles
        }
        
        throw new NotImplementedException("Cannot create tag from JSON of type " + json.Type + ".");
    }
}

public static class TagExtensions {

    public static string GetString(this ITag tag) {
        return ((StringTag)tag).Value;
    }
    
    public static byte GetByte(this ITag tag) {
        if (tag is IntegerTag i) {
            if (i.Value is > 255 or < 0) {
                throw new ArgumentOutOfRangeException("Integer value out of range for byte: " + i.Value);
            }
            return (byte)i.Value;  // convert int to byte
        }
        return ((ByteTag)tag).Value;
    }
    
    public static double GetDouble(this ITag tag) {
        if (tag is FloatTag fl) {
            return fl.Value;
        }
        return ((DoubleTag)tag).Value;
    }
    
    public static float GetFloat(this ITag tag) {
        if (tag is DoubleTag d) {
            return (float)d.Value;  // convert double to float
        }
        return ((FloatTag)tag).Value;
    }
    
    public static int GetInteger(this ITag tag) {
        if (tag is ByteTag b) {
            return b.Value;  // byte can be used as int
        }
        return ((IntegerTag)tag).Value;
    }
    
    public static bool GetBoolean(this ITag tag) {
        if (tag is ByteTag b) {
            return b.BoolValue;
        }
        if (tag is IntegerTag i) {
            return i.Value != 0;  // treat non-zero integers as true
        }
        return ((ByteTag)tag).BoolValue;
    }
    
    public static JToken ToJson(this ITag tag) {
        return ITag.ToJson(tag);
    }
    
    public static string ToJsonString(this ITag tag) {
        return ITag.ToJsonString(tag);
    }
}