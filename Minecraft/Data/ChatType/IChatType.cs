using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.ChatType;

public interface IChatType : IProtocolType {
    /// <summary>How the message is shown in chat.</summary>
    public ChatTypeDecoration Chat { get; }

    /// <summary>How the message is read out by the narrator.</summary>
    public ChatTypeDecoration Narration { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("chat", Chat.ToNbt()),
            ("narration", Narration.ToNbt()));
    }

    public static IChatType FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleChatType(
            ident,
            ChatTypeDecoration.FromNbt(tag["chat"]!),
            ChatTypeDecoration.FromNbt(tag["narration"]!));
    }
}
