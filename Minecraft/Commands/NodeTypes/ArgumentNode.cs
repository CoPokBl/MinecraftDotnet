using Minecraft.Data.ArgumentParsers;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Commands.NodeTypes;

public record ArgumentNode : ICommandNode {
    public ArgumentNode(CommandNodeFlag Flags,
        int[] ChildrenIndexes,
        int? RedirectNode,
        string Name,
        IArgumentParser Parser,
        Identifier? SuggestionsType) {
        
        if (!Flags.HasFlag(CommandNodeFlag.ArgumentType)) {
            throw new ArgumentException("ArgumentNode must have the ArgumentType flag set.", nameof(Flags));
        }

        if (Flags.HasFlag(CommandNodeFlag.HasRedirect) && RedirectNode is null) {
            throw new ArgumentException("RedirectNode must be set when HasRedirect flag is set.", nameof(RedirectNode));
        }
        
        this.Flags = Flags;
        this.ChildrenIndexes = ChildrenIndexes;
        this.RedirectNode = RedirectNode;
        this.Name = Name;
        this.Parser = Parser;
        this.SuggestionsType = SuggestionsType;
    }

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        writer
            .WriteByte((byte)Flags)
            .WritePrefixedArray(ChildrenIndexes, (i, wr) => wr.WriteVarInt(i));

        if (Flags.HasFlag(CommandNodeFlag.HasRedirect)) {
            writer.WriteVarInt(RedirectNode.ThrowIfNull());
        }

        writer
            .WriteString(Name)
            .WriteVarInt(Parser.ProtocolId)
            .Write(wr => Parser.WriteData(wr, registry));
        
        if (Flags.HasFlag(CommandNodeFlag.HasSuggestionsType)) {
            writer.Write(SuggestionsType.ThrowIfNull());
        }
        
        return writer;
    }

    public static ICommandNode ReadAfterFlags(CommandNodeFlag flags, DataReader reader, MinecraftRegistry registry) {
        int[] childrenIndexes = reader.ReadPrefixedArray(r => r.ReadVarInt());
        int? redirectNode = flags.HasFlag(CommandNodeFlag.HasRedirect) ? reader.ReadVarInt() : null;
        string name = reader.ReadString();
        int parserId = reader.ReadVarInt();
        IArgumentParser parser = registry.CommandArgumentTypes[parserId].ReadData(reader, registry);
        Identifier? suggestionsType = flags.HasFlag(CommandNodeFlag.HasSuggestionsType) ? reader.Read<Identifier>(registry) : null!;

        return new ArgumentNode(flags, childrenIndexes, redirectNode, name, parser, suggestionsType);
    }

    public CommandNodeFlag Flags { get; }
    public int[] ChildrenIndexes { get; }
    public int? RedirectNode { get; }
    public string Name { get; }
    public IArgumentParser Parser { get; }
    public Identifier? SuggestionsType { get; }

    public void Deconstruct(out CommandNodeFlag flags, out int[] childrenIndexes, out int? redirectNode, out string name, 
        out IArgumentParser parser, out Identifier? suggestionsType) {
        flags = Flags;
        childrenIndexes = ChildrenIndexes;
        redirectNode = RedirectNode;
        name = Name;
        parser = Parser;
        suggestionsType = SuggestionsType;
    }
}

public class ArgumentNodeBuilder(string name, IArgumentParser parser) {
    public CommandNodeFlag Flags { get; set; } = CommandNodeFlag.ArgumentType;
    public List<int> ChildrenIndexes { get; set; } = [];
    public int? RedirectNode { get; set; }
    public Identifier? SuggestionsType { get; set; }

    public ArgumentNode Build() {
        return new ArgumentNode(Flags | CommandNodeFlag.ArgumentType, ChildrenIndexes.ToArray(), RedirectNode, name, parser, SuggestionsType);
    }
    
    public ArgumentNodeBuilder WithRestricted() {
        Flags |= CommandNodeFlag.IsRestricted;
        return this;
    }
    
    public ArgumentNodeBuilder WithExecutable() {
        Flags |= CommandNodeFlag.IsExecutable;
        return this;
    }
    
    public ArgumentNodeBuilder WithRedirect(int redirectNode) {
        Flags |= CommandNodeFlag.HasRedirect;
        RedirectNode = redirectNode;
        return this;
    }
    
    public ArgumentNodeBuilder WithChildrenIndexes(IEnumerable<int> childrenIndexes) {
        ChildrenIndexes.AddRange(childrenIndexes);
        return this;
    }
    
    public ArgumentNodeBuilder WithRedirectNode(int? redirectNode) {
        RedirectNode = redirectNode;
        return this;
    }
    
    public ArgumentNodeBuilder WithSuggestionsType(Identifier? suggestionsType) {
        SuggestionsType = suggestionsType;
        return this;
    }
    
    public ArgumentNodeBuilder WithChild(int childIndex) {
        ChildrenIndexes.Add(childIndex);
        return this;
    }
}
