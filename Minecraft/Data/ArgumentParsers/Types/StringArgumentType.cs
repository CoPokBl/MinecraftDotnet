using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record StringArgumentType(int ProtocolId, StringArgumentType.Behaviour ValueBehaviour = StringArgumentType.Behaviour.SingleWord) 
    : ArgumentParser<string>(ProtocolId) {
    public override Identifier Identifier => "brigadier:string";
    
    public enum Behaviour {
        /// <summary>
        /// A single word, no spaces allowed.
        /// e.g. /cmd hello
        /// </summary>
        SingleWord = 0,
        
        /// <summary>
        /// A string that can contain spaces but must be quoted if it contains spaces.
        /// e.g. /cmd "hello world"
        /// </summary>
        QuotablePhrase = 1,
        
        /// <summary>
        /// A string that can contain spaces and does not need to be quoted.
        /// The rest of the arguments will be consumed until the end of the command.
        /// e.g. /cmd hello there world
        /// </summary>
        GreedyPhrase = 2
    }

    public override DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt((int)ValueBehaviour);
    }

    public override IArgumentParser ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with {
            ValueBehaviour = (Behaviour)reader.ReadVarInt()
        };
    }

    public override string Parse(ref string str, MinecraftRegistry _) {
        switch (ValueBehaviour) {
            case Behaviour.SingleWord: {
                int spaceIndex = str.IndexOf(' ');
                string val = str;
                str = spaceIndex == -1 ? string.Empty : str[(spaceIndex + 1)..]; // remove the word from the string
                return spaceIndex == -1 ? val : val[..spaceIndex];
            }

            case Behaviour.QuotablePhrase: {
                if (str.StartsWith('"')) {
                    int end = str.IndexOf('"', 1);
                    if (end == -1) {
                        throw new ArgumentException("Unmatched quotes in string argument.", nameof(str));
                    }
                    string result = str[1..end]; // remove the quotes
                    str = end + 1 < str.Length ? str[(end + 1)..] : string.Empty; // remove the quoted part from the string
                    return result;
                }
                
                // Single word without quotes
                int spaceIndex = str.IndexOf(' ');
                str = spaceIndex == -1 ? string.Empty : str[(spaceIndex + 1)..]; // remove the word from the string
                return spaceIndex == -1 ? str : str[..spaceIndex];
            }

            case Behaviour.GreedyPhrase: {
                string result = str;
                str = string.Empty; // consume the entire string
                return result;
            }
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public override string Format(string value) {
        return ValueBehaviour switch {
            Behaviour.SingleWord => value // no quotes needed
            ,
            Behaviour.QuotablePhrase => $"\"{value}\"" // always quote
            ,
            Behaviour.GreedyPhrase => value // no quotes needed
            ,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
