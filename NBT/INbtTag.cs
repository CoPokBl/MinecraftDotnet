using NBT.Tags;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NBT;

public interface INbtTag<out TSelf> : INbtTag where TSelf : INbtTag<TSelf> {
    /// <summary>
    /// Returns this NBT tag with the given name.
    /// <p/>
    /// See <see cref="INbtTag.GetName"/> for information about a tag's name.
    /// </summary>
    /// <param name="name">The name to give it.</param>
    /// <returns>This tag with the given name.</returns>
    new TSelf WithName(string? name);
}

public interface INbtTag {
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
    /// Returns this NBT tag with the given name.
    /// <p/>
    /// See <see cref="GetName"/> for information about a tag's name.
    /// </summary>
    /// <param name="name">The name to give it.</param>
    /// <returns>This tag with the given name.</returns>
    INbtTag WithName(string? name);
    
    /// <summary>
    /// Serialise this NBT tag into a byte array.
    /// </summary>
    /// <param name="noType">
    /// Whether to omit the type of this tag in its serialised representation.
    /// Use <see cref="GetPrefix"/> to find the type of this tag.
    /// </param>
    /// <returns>A byte array containing the serialised version of this tag with no padding.</returns>
    byte[] Serialise(bool noType = false);

    public static string ToJsonString(INbtTag tag) {
        return JsonConvert.SerializeObject(ToJson(tag));
    }
    
    public static JToken ToJson(INbtTag tag) {
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
                foreach (KeyValuePair<string, INbtTag> kvp in compound.ChildrenMap) {
                    obj[kvp.Key] = ToJson(kvp.Value);
                }

                return obj;
            }
            case ListTag list: {
                JArray arr = [];
                foreach (INbtTag item in list.Tags) {
                    arr.Add(item.ToJson());
                }

                return arr;
            }
            case ArrayTag<int> ilt:
                JArray intArr = [];
                foreach (int item in ilt.Values) {
                    intArr.Add(item);
                }
                return intArr;
            case ArrayTag<sbyte> bt:
                JArray byteArr = [];
                foreach (sbyte item in bt.Values) {
                    byteArr.Add(item);
                }
                return byteArr;
            case ArrayTag<long> lt:
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

    public static INbtTag FromJson(string json) {
        return FromJson(null, JsonConvert.DeserializeObject<JToken>(json)!);
    }
    
    public static INbtTag FromJson(string? name, JToken json) {
        if (json is JObject obj) {
            // compound tag
            List<INbtTag> tags = [];
            foreach (KeyValuePair<string, JToken?> kvp in obj) {
                tags.Add(FromJson(kvp.Key, kvp.Value!));
            }
            return new CompoundTag(name, tags.ToArray());
        }
        
        if (json is JArray arr) {
            // list tag
            List<INbtTag> tags = [];
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

    public static string GetString(this INbtTag? tag) {
        return ((StringTag)tag!).Value;
    }
    
    public static sbyte GetByte(this INbtTag? tag) {
        if (tag is IntegerTag i) {
            if (i.Value is > 128 or < -128) {
                throw new ArgumentOutOfRangeException("Integer value out of range for sbyte: " + i.Value);
            }
            return (sbyte)i.Value;  // convert int to byte
        }
        return ((ByteTag)tag!).Value;
    }
    
    public static double GetDouble(this INbtTag? tag) {
        if (tag is FloatTag fl) {
            return fl.Value;
        }
        return ((DoubleTag)tag!).Value;
    }
    
    public static float GetFloat(this INbtTag? tag) {
        if (tag is DoubleTag d) {
            return (float)d.Value;  // convert double to float
        }
        return ((FloatTag)tag!).Value;
    }
    
    public static int GetInteger(this INbtTag? tag) {
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
    
    public static long GetLong(this INbtTag? tag) {
        if (tag is ByteTag b) {
            return b.Value;  // byte can be used as long
        }
        if (tag is IntegerTag i) {
            return i.Value;  // integer can be used as long
        }
        return ((LongTag)tag!).Value;
    }
    
    public static short GetShort(this INbtTag? tag) {
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
    
    public static bool GetBoolean(this INbtTag? tag) {
        if (tag is ByteTag b) {
            return b.BoolValue;
        }
        if (tag is IntegerTag i) {
            return i.Value != 0;  // treat non-zero integers as true
        }

        if (tag is not BooleanTag booleanTag) {
            if (tag == null) {
                throw new Exception("Tag is null.");
            }
            throw new InvalidCastException("Tag is not a BooleanTag. It's type is: " + tag.GetType().Name);
        }
        return booleanTag.Value;
    }

    public static int[] GetIntegers(this INbtTag? tag) {
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

        return ((ArrayTag<int>)tag!).Values;
    }
    
    public static sbyte[] GetBytes(this INbtTag? tag) {  // signed byte array
        if (tag is ListTag list) {
            if (list.Tags.Length == 0) {
                return [];
            }
            
            sbyte[] bytes = new sbyte[list.Tags.Length];
            for (int i = 0; i < list.Tags.Length; i++) {
                bytes[i] = list.Tags[i].GetByte();
            }
            return bytes;
        }

        return ((ArrayTag<sbyte>)tag!).Values;
    }
    
    public static long[] GetLongs(this INbtTag? tag) {
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

        return ((ArrayTag<long>)tag!).Values;
    }
    
    public static CompoundTag GetCompound(this INbtTag? tag) {
        if (tag is CompoundTag compound) {
            return compound;
        }
        
        if (tag is CompoundTagSerialisable cts) {
            return cts.SerialiseToTag();
        }

        throw new InvalidCastException("Tag is not a CompoundTag. It's type is: " + tag?.GetType().Name);
    }

    public static ListTag GetList(this INbtTag? tag) {
        if (tag is not ListTag list) {
            throw new InvalidCastException("Tag is not a ListTag. It's type is: " + tag?.GetType().Name);
        }
        return list;
    }
    
    public static JToken ToJson(this INbtTag tag) {
        return INbtTag.ToJson(tag);
    }
    
    public static string ToJsonString(this INbtTag tag) {
        return INbtTag.ToJsonString(tag);
    }
}
