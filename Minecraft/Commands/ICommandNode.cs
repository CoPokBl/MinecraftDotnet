using Minecraft.Commands.NodeTypes;
using Minecraft.Registry;

namespace Minecraft.Commands;

public interface ICommandNode {
    public CommandNodeFlag Flags { get; init; }
    public int[] ChildrenIndexes { get; init; }
    public int? RedirectNode { get; init; }
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry);

    public static ICommandNode ReadData(DataReader reader, MinecraftRegistry registry) {
        CommandNodeFlag flags = (CommandNodeFlag)reader.ReadByte();

        if (flags.HasFlag(CommandNodeFlag.ArgumentType)) {
            return ArgumentNode.ReadAfterFlags(flags, reader, registry);
        }
        
        if (flags.HasFlag(CommandNodeFlag.LiteralType)) {
            return LiteralNode.ReadAfterFlags(flags, reader, registry);
        }
        
        if (flags.HasFlag(CommandNodeFlag.RootType)) {
            return RootNode.ReadAfterFlags(flags, reader, registry);
        }
        
        throw new NotSupportedException($"Unsupported command node type with flags: {flags}");
    }
}
