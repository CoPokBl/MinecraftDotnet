namespace Minecraft.Commands;

[Flags]
public enum CommandNodeFlag : sbyte {
    // Node types
    RootType = 0x00,
    LiteralType = 0x01,
    ArgumentType = 0x02,
    
    // Settings
    IsExecutable = 0x04,
    HasRedirect = 0x08,
    HasSuggestionsType = 0x10,
    IsRestricted = 0x20
}
