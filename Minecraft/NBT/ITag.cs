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
            case LongTag:
                return tag.GetLong();
            case ShortTag:
                return tag.GetShort();
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
            case IntegersTag ilt:
                JArray intArr = [];
                foreach (int item in ilt.Values) {
                    intArr.Add(item);
                }
                return intArr;
            case BytesTag bt:
                JArray byteArr = [];
                foreach (int item in bt.Values) {
                    if (item is < -128 or > 127) {
                        throw new ArgumentOutOfRangeException(nameof(item), "Byte value must be between -128 and 127.");
                    }
                    byteArr.Add(item);
                }
                return byteArr;
            case LongsTag lt:
                JArray longArr = [];
                foreach (long item in lt.Values) {
                    longArr.Add(item);
                }
                return longArr;
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

    public static string GetString(this ITag? tag) {
        return ((StringTag)tag!).Value;
    }
    
    public static byte GetByte(this ITag? tag) {
        if (tag is IntegerTag i) {
            if (i.Value is > 255 or < 0) {
                throw new ArgumentOutOfRangeException("Integer value out of range for byte: " + i.Value);
            }
            return (byte)i.Value;  // convert int to byte
        }
        return ((ByteTag)tag!).Value;
    }
    
    public static double GetDouble(this ITag? tag) {
        if (tag is FloatTag fl) {
            return fl.Value;
        }
        return ((DoubleTag)tag!).Value;
    }
    
    public static float GetFloat(this ITag? tag) {
        if (tag is DoubleTag d) {
            return (float)d.Value;  // convert double to float
        }
        return ((FloatTag)tag!).Value;
    }
    
    public static int GetInteger(this ITag? tag) {
        if (tag is ByteTag b) {
            return b.Value;  // byte can be used as int
        }
        if (tag is LongTag l) {
            if (l.Value is < int.MinValue or > int.MaxValue) {
                throw new ArgumentOutOfRangeException("Long value out of range for int: " + l.Value);
            }
            return (int)l.Value;  // convert long to int
        }
        return ((IntegerTag)tag!).Value;
    }
    
    public static long GetLong(this ITag? tag) {
        if (tag is ByteTag b) {
            return b.Value;  // byte can be used as long
        }
        if (tag is IntegerTag i) {
            return i.Value;  // integer can be used as long
        }
        return ((LongTag)tag!).Value;
    }
    
    public static short GetShort(this ITag? tag) {
        if (tag is ByteTag b) {
            return b.Value;  // byte can be used as short
        }
        if (tag is IntegerTag i) {
            if (i.Value is < short.MinValue or > short.MaxValue) {
                throw new ArgumentOutOfRangeException("Integer value out of range for short: " + i.Value);
            }
            return (short)i.Value;  // convert int to short
        }
        return ((ShortTag)tag!).Value;
    }
    
    public static bool GetBoolean(this ITag? tag) {
        if (tag is ByteTag b) {
            return b.BoolValue;
        }
        if (tag is IntegerTag i) {
            return i.Value != 0;  // treat non-zero integers as true
        }

        if ((BooleanTag)tag! == null) {
            if (tag == null) {
                throw new Exception("Tag is null.");
            }
            throw new InvalidCastException("Tag is not a BooleanTag. It's type is: " + tag.GetType().Name);
        }
        return ((BooleanTag)tag).Value;
    }

    public static int[] GetIntegers(this ITag? tag) {
        if (tag is ListTag list) {
            if (list.Tags.Length == 0) {
                return [];
            }
            
            int[] integers = new int[list.Tags.Length];
            for (int i = 0; i < list.Tags.Length; i++) {
                integers[i] = list.Tags[i].GetInteger();
            }
            return integers;
        }

        return ((IntegersTag)tag!).Values;
    }
    
    public static int[] GetBytes(this ITag? tag) {  // signed byte array
        if (tag is ListTag list) {
            if (list.Tags.Length == 0) {
                return [];
            }
            
            int[] bytes = new int[list.Tags.Length];
            for (int i = 0; i < list.Tags.Length; i++) {
                bytes[i] = list.Tags[i].GetByte();
            }
            return bytes;
        }

        return ((BytesTag)tag!).Values;
    }
    
    public static long[] GetLongs(this ITag? tag) {
        if (tag is ListTag list) {
            if (list.Tags.Length == 0) {
                return [];
            }
            
            long[] longs = new long[list.Tags.Length];
            for (int i = 0; i < list.Tags.Length; i++) {
                longs[i] = list.Tags[i].GetLong();
            }
            return longs;
        }

        return ((LongsTag)tag!).Values;
    }
    
    public static CompoundTag GetCompound(this ITag? tag) {
        if (tag is CompoundTag compound) {
            return compound;
        }
        
        if (tag is CompoundTagSerialisable cts) {
            return cts.SerialiseToTag();
        }

        throw new InvalidCastException("Tag is not a CompoundTag. It's type is: " + tag?.GetType().Name);
    }

    public static ListTag GetList(this ITag? tag) {
        if (tag is not ListTag list) {
            throw new InvalidCastException("Tag is not a ListTag. It's type is: " + tag?.GetType().Name);
        }
        return list;
    }
    
    public static JToken ToJson(this ITag tag) {
        return ITag.ToJson(tag);
    }
    
    public static string ToJsonString(this ITag tag) {
        return ITag.ToJsonString(tag);
    }
}