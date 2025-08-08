using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Commands.NodeTypes;

public record LiteralNode : ICommandNode {
    
    public LiteralNode(CommandNodeFlag Flags,
        int[] ChildrenIndexes,
        int? RedirectNode,
        string Name,
        Identifier? SuggestionsType) {
        
        if (!Flags.HasFlag(CommandNodeFlag.LiteralType)) {
            throw new ArgumentException("LiteralNode must have the LiteralType flag set.", nameof(Flags));
        }

        if (Flags.HasFlag(CommandNodeFlag.HasRedirect) && RedirectNode is null) {
            throw new ArgumentException("RedirectNode must be set when HasRedirect flag is set.", nameof(RedirectNode));
        }
        
        this.Flags = Flags;
        this.ChildrenIndexes = ChildrenIndexes;
        this.RedirectNode = RedirectNode;
        this.Name = Name;
        this.SuggestionsType = SuggestionsType;
    }

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        writer
            .WriteByte((byte)Flags)
            .WritePrefixedArray(ChildrenIndexes, (i, wr) => wr.WriteVarInt(i));

        if (Flags.HasFlag(CommandNodeFlag.HasRedirect)) {
            writer.WriteVarInt(RedirectNode.ThrowIfNull());
        }

        writer.WriteString(Name);
        
        if (Flags.HasFlag(CommandNodeFlag.HasSuggestionsType)) {
            writer.Write(SuggestionsType.ThrowIfNull());
        }
        
        return writer;
    }

    public static ICommandNode ReadAfterFlags(CommandNodeFlag flags, DataReader reader, MinecraftRegistry registry) {
        int[] childrenIndexes = reader.ReadPrefixedArray(r => r.ReadVarInt());
        int? redirectNode = flags.HasFlag(CommandNodeFlag.HasRedirect) ? reader.ReadVarInt() : null;
        string name = reader.ReadString();
        Identifier? suggestionsType = flags.HasFlag(CommandNodeFlag.HasSuggestionsType) ? reader.Read<Identifier>(registry) : null!;

        return new LiteralNode(flags, childrenIndexes, redirectNode, name, suggestionsType);
    }

    public CommandNodeFlag Flags { get; }
    public int[] ChildrenIndexes { get; }
    public int? RedirectNode { get; }
    public string Name { get; }
    public Identifier? SuggestionsType { get; }

    public void Deconstruct(out CommandNodeFlag flags, out int[] childrenIndexes, out int? redirectNode, 
        out string name, out Identifier? suggestionsType) {
        flags = Flags;
        childrenIndexes = ChildrenIndexes;
        redirectNode = RedirectNode;
        name = Name;
        suggestionsType = SuggestionsType;
    }
}
