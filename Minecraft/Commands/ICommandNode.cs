using Minecraft.Commands.NodeTypes;
using Minecraft.Registry;

namespace Minecraft.Commands;

public interface ICommandNode {
    public CommandNodeFlag Flags { get; init; }
    public int[] ChildrenIndexes { get; init; }
    public int? RedirectNode { get; init; }
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry);

    /// <summary>
    /// Only an argument node carries a suggestions id on the wire. Vanilla reads the type from the low
    /// two bits and treats the unused value 3 as a root, reading nothing after the redirect.
    /// </summary>
    public static ICommandNode ReadData(DataReader reader, MinecraftRegistry registry) {
        CommandNodeFlag flags = (CommandNodeFlag)reader.ReadByte();

        return ((int)flags & 0x03) switch {
            (int)CommandNodeFlag.ArgumentType => ArgumentNode.ReadAfterFlags(flags, reader, registry),
            (int)CommandNodeFlag.LiteralType => LiteralNode.ReadAfterFlags(flags, reader, registry),
            _ => RootNode.ReadAfterFlags(flags, reader, registry)
        };
    }
}
