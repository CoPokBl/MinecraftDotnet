using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.ArgumentParsers.Types;

public record BlockStateArgumentType(int ProtocolId) : ArgumentParser<IBlock>(ProtocolId) {
    public override Identifier Identifier => "minecraft:block_state";
    
    private static CompoundTag PropertiesStringToNbt(string propsStr) {
        // string should look like: north=false,south=false,west=true,waterlogged=false,east=true
        // so just chuck it into a string, string dictionary
        if (string.IsNullOrWhiteSpace(propsStr)) {
            return new CompoundTag(null);
        }
        
        List<INbtTag?> props = [];
        string[] pairs = propsStr.Split(',');
        foreach (string pair in pairs) {
            string[] vals = pair.Split('=');
            string key = vals[0].Trim();
            string value = vals[1].Trim();
            props.Add(new StringTag(key, value));
        }

        return new CompoundTag(null, props.ToArray());
    }
    
    private static string PropertiesNbtToString(CompoundTag properties) {
        // Convert the properties NBT to a string format
        // This is the reverse of PropertiesStringToNbt
        List<string> pairs = [];
        foreach (INbtTag? tag in properties.Children) {
            if (tag is StringTag stringTag) {
                pairs.Add($"{stringTag.Name}={stringTag.Value}");
            }
        }
        return string.Join(",", pairs);
    }
    
    // should look like:
    // minecraft:oak_fence[facing=north]
    // minecraft:stone
    public override IBlock Parse(ref string str, MinecraftRegistry reg) {
        // Get the block name, so get until the first '[' or space
        int bracketIndex = str.IndexOf('[');
        int spaceIndex = str.IndexOf(' ');
        int endIndex;
        if (bracketIndex == -1 && spaceIndex == -1) {
            endIndex = str.Length-1;
        }
        else if (bracketIndex != -1 && spaceIndex != -1) {
            endIndex = Math.Min(bracketIndex - 1, spaceIndex - 1);
        }
        else if (bracketIndex != -1) {  // There's a bracket
            endIndex = bracketIndex - 1;
        }
        else {  // There's a space
            endIndex = spaceIndex - 1;
        }
        
        string blockName = str.Substring(0, endIndex + 1).Trim();
        str = str.Substring(endIndex + 1).Trim();  // Remove the block name
        
        IBlock block = reg.Blocks[blockName];
        
        // If there are properties, get the string of them
        str = str.Trim();
        if (str.StartsWith('[')) {
            int endBracketIndex = str.IndexOf(']');
            if (endBracketIndex == -1) {
                throw new ArgumentException($"Invalid block state format: {str}");
            }
            
            string propertiesString = str.Substring(1, endBracketIndex - 1).Trim();  // Remove the brackets
            str = str[(endBracketIndex + 1)..].Trim();  // Remove the properties

            block = block.WithState(PropertiesStringToNbt(propertiesString));
        }

        return block;
    }

    public override string Format(IBlock value) {
        return $"{value.Identifier}[{PropertiesNbtToString(value.ToStateNbt())}]";
    }
}
