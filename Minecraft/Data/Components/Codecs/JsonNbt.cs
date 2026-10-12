using Minecraft.Schemas;
using NBT;
using NBT.Tags;
using System.Text.Json;

namespace Minecraft.Data.Components.Codecs;

/// <summary>
/// Lifts datapack JSON into the tag tree a component's codec reads.
/// </summary>
/// <remarks>
/// This is what lets one codec serve both formats. The mapping is the same one <c>INbtTag.FromJson</c>
/// makes from the other JSON library, so a component read through either arrives at the same tags:
/// every whole number becomes an integer tag and every fractional one a double tag, whatever width
/// the field wants, and <see cref="NbtValues"/> widens from there.
/// <p/>
/// Reading text rather than a document is deliberate. Handing the raw text back to
/// <c>INbtTag.FromJson</c> would reparse every component of every recipe and put a second JSON
/// library in the path for nothing.
/// </remarks>
public static class JsonNbt {
    /// <summary>The element as tags, with <paramref name="context"/> naming what failed.</summary>
    public static INbtTag FromJson(JsonElement element, Identifier context) {
        switch (element.ValueKind) {
            case JsonValueKind.Object: {
                List<(string, INbtTag)> children = [];

                foreach (JsonProperty property in element.EnumerateObject()) {
                    children.Add((property.Name, FromJson(property.Value, context)));
                }

                return new CompoundTag(children.ToArray());
            }

            case JsonValueKind.Array: {
                List<INbtTag> items = [];

                foreach (JsonElement item in element.EnumerateArray()) {
                    items.Add(FromJson(item, context));
                }

                try {
                    return new ListTag(items.ToArray());
                } catch (ArrayTypeMismatchException) {
                    // A list tag holds one type, so a mixed array has nowhere to go. Vanilla accepts
                    // one when reading JSON but can never write one, since the value has to survive
                    // being saved as NBT, so this only reaches a hand written pack.
                    throw new UnportedComponentException(context,
                        "a list mixing value types, which has no tag form.");
                }
            }

            case JsonValueKind.True:
            case JsonValueKind.False:
                return new BooleanTag(element.GetBoolean());

            case JsonValueKind.String:
                return new StringTag(element.GetString()!);

            case JsonValueKind.Number:
                return Number(element);

            case JsonValueKind.Null:
            case JsonValueKind.Undefined:
            default:
                return new EmptyTag();
        }
    }

    public static INbtTag FromJson(JsonElement element) {
        return FromJson(element, "minecraft:unknown");
    }

    /// <summary>
    /// A number as the widest tag its text needs.
    /// </summary>
    /// <remarks>
    /// Whether a number is whole is a property of how it was written and not of its value, which is
    /// why the text decides: <c>1</c> and <c>1.0</c> are different tags and the same float. Long is
    /// reached for only when the value will not fit an int, so nothing that reads as an integer tag
    /// through the other JSON library reads as something else here.
    /// </remarks>
    private static INbtTag Number(JsonElement element) {
        ReadOnlySpan<char> text = element.GetRawText();

        if (text.IndexOfAny('.', 'e', 'E') >= 0) {
            return new DoubleTag(element.GetDouble());
        }

        return element.TryGetInt32(out int whole)
            ? new IntegerTag(whole)
            : new LongTag(element.GetInt64());
    }
}
