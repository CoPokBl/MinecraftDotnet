using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.ChatType;

/// <summary>
/// How one flavour of message is turned into text: a translation key, the values that fill its
/// slots, and the style the finished line is drawn in.
/// </summary>
public record ChatTypeDecoration(
    string TranslationKey,
    ChatDecorationParameter[] Parameters,
    TextStyle Style) {

    public ChatTypeDecoration(string translationKey, params ChatDecorationParameter[] parameters)
        : this(translationKey, parameters, TextStyle.Empty) { }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("translation_key", new StringTag(TranslationKey)),
            ("parameters", new ListTag<StringTag>(Parameters
                .Select(p => new StringTag(p.ToProtocolString()))
                .ToArray()))
        ];

        // An unstyled decoration leaves the field out rather than sending an empty compound
        if (!Style.IsEmpty) {
            children.Add(("style", Style.ToNbt()));
        }

        return new CompoundTag(children.ToArray());
    }

    /// <summary>
    /// Writes the decoration in the form used inside packets, which sends the fields directly
    /// rather than as the NBT the registry travels as.
    /// </summary>
    public void Write(DataWriter w) {
        w.WriteString(TranslationKey)
            .WritePrefixedArray(Parameters, (parameter, writer) => writer.WriteVarInt((int)parameter))
            .WriteNbt(Style.ToNbt());
    }

    public static ChatTypeDecoration Read(DataReader r) {
        return new ChatTypeDecoration(
            r.ReadString(),
            r.ReadPrefixedArray(reader => (ChatDecorationParameter)reader.ReadVarInt()),
            TextStyle.FromNbt(r.ReadNbt()));
    }

    public static ChatTypeDecoration FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new ChatTypeDecoration(
            compound["translation_key"]!.GetString(),
            compound["parameters"]!.AsList()
                .Select(t => ChatDecorationParameterExtensions.ParseChatDecorationParameter(t.GetString()))
                .ToArray(),
            compound.Contains("style") ? TextStyle.FromNbt(compound["style"]!) : TextStyle.Empty);
    }

    public virtual bool Equals(ChatTypeDecoration? other) {
        return other != null
               && TranslationKey == other.TranslationKey
               && Parameters.SequenceEqual(other.Parameters)
               && Style == other.Style;
    }

    public override int GetHashCode() {
        return HashCode.Combine(TranslationKey, Parameters.Length, Style);
    }
}
