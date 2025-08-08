using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Commands.NodeTypes;

public record RootNode : ICommandNode {
    
    public RootNode(CommandNodeFlag Flags,
        int[] ChildrenIndexes,
        int? RedirectNode,
        Identifier? SuggestionsType) {
        
        if (!Flags.HasFlag(CommandNodeFlag.RootType)) {
            throw new ArgumentException("RootNode must have the RootType flag set.", nameof(Flags));
        }

        if (Flags.HasFlag(CommandNodeFlag.HasRedirect) && RedirectNode is null) {
            throw new ArgumentException("RedirectNode must be set when HasRedirect flag is set.", nameof(RedirectNode));
        }
        
        this.Flags = Flags;
        this.ChildrenIndexes = ChildrenIndexes;
        this.RedirectNode = RedirectNode;
        this.SuggestionsType = SuggestionsType;
    }

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        writer
            .WriteByte((byte)Flags)
            .WritePrefixedArray(ChildrenIndexes, (i, wr) => wr.WriteVarInt(i));

        if (Flags.HasFlag(CommandNodeFlag.HasRedirect)) {
            writer.WriteVarInt(RedirectNode.ThrowIfNull());
        }
        
        if (Flags.HasFlag(CommandNodeFlag.HasSuggestionsType)) {
            writer.Write(SuggestionsType.ThrowIfNull());
        }
        
        return writer;
    }

    public static ICommandNode ReadAfterFlags(CommandNodeFlag flags, DataReader reader, MinecraftRegistry registry) {
        int[] childrenIndexes = reader.ReadPrefixedArray(r => r.ReadVarInt());
        int? redirectNode = flags.HasFlag(CommandNodeFlag.HasRedirect) ? reader.ReadVarInt() : null;
        Identifier? suggestionsType = flags.HasFlag(CommandNodeFlag.HasSuggestionsType) ? reader.Read<Identifier>(registry) : null!;

        return new RootNode(flags, childrenIndexes, redirectNode, suggestionsType);
    }

    public CommandNodeFlag Flags { get; init; }
    public int[] ChildrenIndexes { get; init; }
    public int? RedirectNode { get; init; }
    public Identifier? SuggestionsType { get; init; }

    public void Deconstruct(out CommandNodeFlag flags, out int[] childrenIndexes, out int? redirectNode, out Identifier? suggestionsType) {
        suggestionsType = SuggestionsType;
        flags = Flags;
        childrenIndexes = ChildrenIndexes;
        redirectNode = RedirectNode;
    }
}
