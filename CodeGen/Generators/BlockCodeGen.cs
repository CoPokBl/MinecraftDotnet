using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public enum PropertyType {
    Boolean,
    Integer,
    Enum,
    ExistingEnum
}

public interface IProperty {
    public PropertyType Type { get; }
    public string Name { get; }
    public string[] AllowedValues { get; }
}

public record EnumProperty(string[] AllowedValues, string Name) : IProperty {
    public PropertyType Type => PropertyType.Enum;
}

public record BooleanProperty(string[] AllowedValues, string Name) : IProperty {
    public PropertyType Type => PropertyType.Boolean;
}

public record IntegerProperty(string[] AllowedValues, string Name, int Min, int Max) : IProperty {
    public PropertyType Type => PropertyType.Integer;
}

public record ExistingEnumProperty : IProperty {
    public ExistingEnumProperty(string[] AllowedValues, string Name, string ExistingEnum, IEnumerable<string> Vals) {
        this.AllowedValues = AllowedValues;
        this.Name = Name;
        this.ExistingEnum = ExistingEnum;
        this.Vals = Vals.Select(CodeGenUtils.NamespacedIdToPascalName).ToArray();
    }

    public PropertyType Type => PropertyType.ExistingEnum;
    public string[] AllowedValues { get; init; }
    public string Name { get; init; }
    public string ExistingEnum { get; init; }
    public string[] Vals { get; init; }
}

public static class BlockCodeGen {
    private const string TemplateFile = 
"""
using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record {name}(Identifier Identifier, {args}) : IBlock {

{reginfo}

    public uint StateId {
        get {
            {to_state_logic}
        }
    }
    
    public IBlock WithState(uint state) {
        {from_state_logic}
    }
    
    public IBlock WithState(CompoundTag properties) {
        {load_state_logic}
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
{to_nbt_fields}
        );
    }
    
{enums}}

""";
    
    private const string BlocksFileTemplate = 
"""
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Schemas;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.
public static class Block {
{entries}}

""";
    
    private static readonly HashSet<string> BoolValues = ["true", "false"];
    private static readonly HashSet<string> DirectionValues = ["north", "south", "west", "east"];
    private static readonly HashSet<string> StairShapeValues = ["straight", "inner_left", "inner_right", "outer_left", "outer_right"];
    private static readonly HashSet<string> CardinalValues = ["north", "east", "south", "west", "up", "down"];
    private static readonly HashSet<string> SlabTypeValues = ["top", "bottom", "double"];
    private static readonly HashSet<string> AttachDirectionValues = ["floor", "wall", "ceiling"];
    private static readonly HashSet<string> BlockHalfValues = ["upper", "lower"];
    private static readonly HashSet<string> LeftRightValues = ["left", "right"];
    private static readonly HashSet<string> AxisValues = ["x", "y", "z"];
    private static readonly HashSet<string> RailDirectionValues = ["north_south", "east_west", "ascending_east", "ascending_west", "ascending_north", "ascending_south"];
    private static readonly HashSet<string> WallSideValues = ["none", "low", "tall"];
    private static readonly HashSet<string> BedPartValues = ["head", "foot"];
    private static readonly HashSet<string> SculkSensorPhaseValues = ["inactive", "active", "cooldown"];
    private static readonly HashSet<string> OrientationValues = ["down_east", "down_north", "down_south", "down_west", "up_east", "up_north", "up_south", "up_west", "west_up", "east_up", "north_up", "south_up"];
    private static readonly HashSet<string> RedstoneWireConnectionValues = ["up", "side", "none"];
    
    public static string GetCSharpType(string typeName, IProperty prop) {
        return prop.Type switch {
            PropertyType.Boolean => "bool",
            PropertyType.Integer => "int",
            PropertyType.ExistingEnum => ((ExistingEnumProperty)prop).ExistingEnum,
            PropertyType.Enum => $"{typeName}.{CodeGenUtils.NamespacedIdToPascalName(((EnumProperty)prop).Name)}",
            _ => throw new ArgumentOutOfRangeException(nameof(prop), prop, null)
        };
    }

    public static string[] GetCSharpSwitchCases(IProperty prop, string className = "", bool externalVals = false) {
        return prop.Type switch {
            PropertyType.Boolean => BoolValues.ToArray(),
            PropertyType.Integer => Enumerable.Range(((IntegerProperty)prop).Min, ((IntegerProperty)prop).Max - ((IntegerProperty)prop).Min + 1).Select(i => i.ToString()).ToArray(),
            PropertyType.ExistingEnum => ((ExistingEnumProperty)prop).Vals.Select(v => $"{((ExistingEnumProperty)prop).ExistingEnum}.{v}").ToArray(),
            PropertyType.Enum => ((EnumProperty)prop).AllowedValues.Select(v => $"{(externalVals ? "Minecraft.Data.Generated.BlockTypes." + className + "." : "")}{CodeGenUtils.NamespacedIdToPascalName(prop.Name)}.{CodeGenUtils.NamespacedIdToPascalName(v)}").ToArray(),
            _ => throw new ArgumentOutOfRangeException(nameof(prop), prop, null)
        };
    }
    
    public static string GetPascalPropName(IProperty prop) {
        if (prop is EnumProperty) {
            return CodeGenUtils.NamespacedIdToPascalName(prop.Name) + "Value";
        }
        return CodeGenUtils.NamespacedIdToPascalName(prop.Name);
    }

    private static bool SameValues<T>(T[] set1, HashSet<T> set2) {
        return set1.Length == set2.Count && set1.All(set2.Contains);
    }

    public static string GenerateBlockCode(JObject registriesJson) {
        // Delete all files in BlockTypes folder
        foreach (string file in Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "BlockTypes"))) {
            File.Delete(file);
        }
        
        JObject blocksJson = JObject.Parse(CodeGenUtils.ReadVanillaDataFile("reports", "blocks.json"));
        JObject blocksDataJson = JObject.Parse(CodeGenUtils.ReadEmbeddedFile("blocks_data.json"));

        StringBuilder registryData = new();
        StringBuilder blocksFileEntries = new();
        
        foreach ((string id, JToken? value) in blocksJson) {
            JObject blockData = value!.ToObject<JObject>()!;
            string staticVarName = CodeGenUtils.NamespacedIdToPascalName(id);
            
            // FETCH ADDITIONAL DATA
            JObject dataEntry = blocksDataJson[id]!.ToObject<JObject>()!;
            int protocolId = dataEntry["id"].ToObject<int>();
            string category = blockData["definition"]!["type"]!.ToObject<string>()!;
            string translationKey = dataEntry["translationKey"]!.ToObject<string>()!;
            double explosionResistance = dataEntry["explosionResistance"]!.ToObject<double>();
            double friction = dataEntry["friction"]!.ToObject<double>();
            bool canRespawnIn = dataEntry["canRespawnIn"]!.ToObject<bool>();
            double hardness = dataEntry["hardness"]!.ToObject<double>();
            string pushReactionString = dataEntry["pushReaction"]!.ToObject<string>()!;
            int mapColorId = dataEntry["mapColorId"]!.ToObject<int>();
            bool occludes = dataEntry["occludes"]!.ToObject<bool>();
            bool requiresTool = dataEntry["requiresTool"]!.ToObject<bool>();
            bool blocksMotion = dataEntry["blocksMotion"]!.ToObject<bool>();
            bool flammable = dataEntry["flammable"]!.ToObject<bool>();
            bool air = dataEntry["air"]?.ToObject<bool>() ?? false;
            bool liquid = dataEntry["liquid"]?.ToObject<bool>() ?? false;
            bool replaceable = dataEntry["replaceable"]?.ToObject<bool>() ?? false;
            bool solid = dataEntry["solid"]!.ToObject<bool>();
            bool solidBlocking = dataEntry["solidBlocking"]!.ToObject<bool>();
            string soundType = dataEntry["soundType"]!.ToObject<string>()!;
            string shapeString = dataEntry["shape"]!.ToObject<string>()!;
            string collisionShapeString = dataEntry["collisionShape"]!.ToObject<string>()!;
            string interactionShapeString = dataEntry["interactionShape"]!.ToObject<string>()!;
            string occlusionShapeString = dataEntry["occlusionShape"]!.ToObject<string>()!;
            string visualShapeString = dataEntry["visualShape"]!.ToObject<string>()!;
            bool redstoneConductor = dataEntry["redstoneConductor"]?.ToObject<bool>() ?? false;
            bool signalSource = dataEntry["signalSource"]?.ToObject<bool>() ?? false;
            string? blockEntityId = dataEntry["blockEntity"]?["namespace"]!.ToObject<string>();
            int lightEmission = dataEntry["lightEmission"]?.ToObject<int>() ?? 0;
            double speedFactor = dataEntry["speedFactor"]?.ToObject<double>() ?? 1;
            double jumpFactor = dataEntry["jumpFactor"]?.ToObject<double>() ?? 1;
            string? item = dataEntry["correspondingItem"]?.ToObject<string>();

            Func<string, string> shapeCsParser = shapeStr => $"ICollisionBox.ParseAabbArrayString(\"{shapeStr}\")";
            Func<string, string> pushReactionCsParser = pushReaction => pushReaction switch {
                "NORMAL" => "PushReaction.Normal",
                "DESTROY" => "PushReaction.Destroy",
                "BLOCK" => "PushReaction.Block",
                "PUSH_ONLY" => "PushReaction.PushOnly",
                _ => throw new ArgumentOutOfRangeException(nameof(pushReaction), pushReaction, null)
            };
            Func<string?, string> toCsStr = str => str == null ? "null" : $"\"{str}\"";

            string propArgsStringRecord = $"{toCsStr(category)}, {hardness}, {explosionResistance}, {friction}, {speedFactor}, " +
                                          $"{jumpFactor}, {solid.ToString().ToLower()}, {liquid.ToString().ToLower()}, " +
                                          $"{occludes.ToString().ToLower()}, {requiresTool.ToString().ToLower()}, " +
                                          $"{lightEmission}, {replaceable.ToString().ToLower()}, {toCsStr(soundType)}, " +
                                          $"{toCsStr(blockEntityId)}, {toCsStr(item)}, {shapeCsParser(collisionShapeString)}, {shapeCsParser(occlusionShapeString)}, " +
                                          $"{shapeCsParser(shapeString)}, {shapeCsParser(interactionShapeString)}, {shapeCsParser(visualShapeString)}, " +
                                          $"{redstoneConductor.ToString().ToLower()}, " +
                                          $"{signalSource.ToString().ToLower()}, {flammable.ToString().ToLower()}, {pushReactionCsParser(pushReactionString)}, " +
                                          $"{mapColorId}, {toCsStr(translationKey)}, {canRespawnIn.ToString().ToLower()}";
            
            // do we need a record?
            JArray states = blockData["states"]!.ToObject<JArray>()!;
            if (states.Count == 1) {  // simple! yay! fewer classes
                JObject state = states[0].ToObject<JObject>()!;
                int stateId = state["id"]!.ToObject<int>();

                registryData.Append($"{CodeGenUtils.GetIndentation(2)}Data.Blocks.Add(Block.{staticVarName}, {stateId});\n");
                blocksFileEntries.Append($"{CodeGenUtils.GetIndentation(1)}public static readonly SimpleBlock {staticVarName} = " +
                                         $"new(\"{id}\", {protocolId}, {stateId}, {propArgsStringRecord});\n");
                continue;  // they don't need a record class, just a simple block
            }
            
            JObject propsJson = blockData["properties"]!.ToObject<JObject>()!;
            if (states.Count == 2 && propsJson.ContainsKey("waterlogged")) {
                // it's only got the water loggable prop
                JObject state1 = states[0].ToObject<JObject>()!;
                JObject state2 = states[1].ToObject<JObject>()!;
                
                int state1Id = state1["id"]!.ToObject<int>();
                int state2Id = state2["id"]!.ToObject<int>();
                
                bool stateOneIsWaterlogged = state1["properties"]!["waterlogged"]!.Value<string>() == "true";
                int waterloggedState = stateOneIsWaterlogged ? state1Id : state2Id;
                int airLoggedState = stateOneIsWaterlogged ? state2Id : state1Id;

                bool defaultIsWaterlogged = (stateOneIsWaterlogged ? state1 : state2).ContainsKey("default");
                
                registryData.Append($"{CodeGenUtils.GetIndentation(2)}Data.Blocks.Add(Block.{staticVarName}, {waterloggedState}, {airLoggedState});\n");
                blocksFileEntries.Append(
                    $"{CodeGenUtils.GetIndentation(1)}public static readonly WaterloggableBlock {staticVarName} = " +
                    $"new(\"{id}\", {protocolId}, {airLoggedState}, {waterloggedState}, {defaultIsWaterlogged.ToString().ToLower()}, {propArgsStringRecord});\n");
                continue;  // they don't need a record class, just a simple block
            }
            
            // complex! we need a record class
            string pascalName = CodeGenUtils.NamespacedIdToPascalName(id) + "Block";
            
            // COMPILE ALL THE DATA INTO PROPS
            StringBuilder staticData = new();
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public Identifier Category => {toCsStr(category)};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public int ProtocolId => {protocolId};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public double Hardness => {hardness};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public double ExplosionResistance => {explosionResistance};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public double Friction => {friction};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public double SpeedFactor => {speedFactor};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public double JumpFactor => {jumpFactor};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public bool Solid => {solid.ToString().ToLower()};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public bool Liquid => {liquid.ToString().ToLower()};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public bool Occludes => {occludes.ToString().ToLower()};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public bool RequiresTool => {requiresTool.ToString().ToLower()};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public int LightEmission => {lightEmission};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public bool Replaceable => {replaceable.ToString().ToLower()};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public string SoundType => \"{soundType}\";\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public Identifier? BlockEntity => " +
                              $"{(blockEntityId is null ? "null" : $"\"{blockEntityId}\"")};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public Identifier? Item => " +
                              $"{(item is null ? "null" : $"\"{item}\"")};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public ICollisionBox BlockShape => {shapeCsParser(shapeString)};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public ICollisionBox CollisionShape => {shapeCsParser(collisionShapeString)};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public ICollisionBox OcclusionShape => {shapeCsParser(occlusionShapeString)};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public ICollisionBox InteractionShape => {shapeCsParser(interactionShapeString)};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public ICollisionBox VisualShape => {shapeCsParser(visualShapeString)};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public bool RedstoneConductor => {redstoneConductor.ToString().ToLower()};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public bool SignalSource => {signalSource.ToString().ToLower()};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public bool Flammable => {flammable.ToString().ToLower()};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public PushReaction PushReaction => {pushReactionCsParser(pushReactionString)};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public int MapColorId => {mapColorId};\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public string TranslationKey => \"{translationKey}\";\n");
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public bool CanRespawnIn => {canRespawnIn.ToString().ToLower()};\n");
            
            // build a list of all the arguments correctly parsed
            
            List<IProperty> props = [];
            foreach ((string propName, JToken? jToken) in propsJson) {
                string[] propAllowedValues = jToken!.ToObject<string[]>()!;

                if (propAllowedValues.Length == 0) {
                    throw new Exception("Property " + propName + " has no allowed values.");
                }

                // bool
                if (SameValues(propAllowedValues, BoolValues)) {
                    props.Add(new BooleanProperty(propAllowedValues, propName));
                    continue;
                }

                if (SameValues(propAllowedValues, DirectionValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "Direction", DirectionValues));
                    continue;
                }
                
                if (SameValues(propAllowedValues, StairShapeValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "StairShape", StairShapeValues));
                    continue;
                }

                if (SameValues(propAllowedValues, CardinalValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "Cardinal", CardinalValues));
                    continue;
                }
                
                if (SameValues(propAllowedValues, SlabTypeValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "SlabType", SlabTypeValues));
                    continue;
                }
                
                if (SameValues(propAllowedValues, AttachDirectionValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "AttachDirection", AttachDirectionValues));
                    continue;
                }

                if (SameValues(propAllowedValues, BlockHalfValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "BlockHalf", BlockHalfValues));
                    continue;
                }

                if (SameValues(propAllowedValues, LeftRightValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "LeftRight", LeftRightValues));
                    continue;
                }

                if (SameValues(propAllowedValues, AxisValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "Axis", AxisValues));
                    continue;
                }

                if (SameValues(propAllowedValues, RailDirectionValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "RailDirection", RailDirectionValues));
                    continue;
                }

                if (SameValues(propAllowedValues, WallSideValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "WallSide", WallSideValues));
                    continue;
                }

                if (SameValues(propAllowedValues, BedPartValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "BedPart", BedPartValues));
                    continue;
                }

                if (SameValues(propAllowedValues, SculkSensorPhaseValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "SculkSensorPhase", SculkSensorPhaseValues));
                    continue;
                }

                if (SameValues(propAllowedValues, OrientationValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "Orientation", OrientationValues));
                    continue;
                }

                if (SameValues(propAllowedValues, RedstoneWireConnectionValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "RedstoneWireConnection", RedstoneWireConnectionValues));
                    continue;
                }

                // int
                int[]? intProps = new int[propAllowedValues.Length];
                for (int i = 0; i < propAllowedValues.Length; i++) {
                    string posInt = propAllowedValues[i];
                    if (!int.TryParse(posInt, out int v)) {
                        intProps = null;
                        break;
                    }
                    
                    intProps[i] = v;
                }
                if (intProps is not null) {
                    int min = intProps.Min();
                    int max = intProps.Max();
                    props.Add(new IntegerProperty(propAllowedValues, propName, min, max));
                    continue;
                }
                
                // it's an enum I guess
                props.Add(new EnumProperty(propAllowedValues, propName));
            }
            
            // okay we have the arguments, now we need to build actual arguments code
            string argsCode = string.Join(", ", props.Select(p => GetCSharpType(pascalName, p) + " " + GetPascalPropName(p)));
            
            // =====================================================
            //                        ENUMs
            // =====================================================
            string enumsCode = "";
            foreach (IProperty prop in props) {
                if (prop.Type != PropertyType.Enum) continue;
                string enumName = CodeGenUtils.NamespacedIdToPascalName(prop.Name);
                string[] enumValues = ((EnumProperty)prop).AllowedValues;
                
                // Definition
                enumsCode += $"    public enum {enumName} {{\n";
                foreach (string enumValue in enumValues) {
                    enumsCode += $"{CodeGenUtils.GetIndentation(2)}{CodeGenUtils.NamespacedIdToPascalName(enumValue)},\n";
                }
                enumsCode += "    }\n";
                
                // We need an extension method to convert from string to enum
                enumsCode += $"\n{CodeGenUtils.GetIndentation(1)}public static {enumName} {enumName}FromString(string value) {{\n" +
                             $"{CodeGenUtils.GetIndentation(2)}return value switch {{\n";
                enumsCode = enumValues.Aggregate(enumsCode, (current, enumValue) => 
                    current + $"{CodeGenUtils.GetIndentation(3)}\"{enumValue}\" => {enumName}.{CodeGenUtils.NamespacedIdToPascalName(enumValue)},\n");
                enumsCode += $"{CodeGenUtils.GetIndentation(3)}_ => throw new ArgumentOutOfRangeException(nameof(value), value, \"Unknown value for {enumName}.\")\n" +
                             $"{CodeGenUtils.GetIndentation(2)}}};\n" +
                             $"{CodeGenUtils.GetIndentation(1)}}}\n";
                
                // We also need a ToName method
                enumsCode += $"\n{CodeGenUtils.GetIndentation(1)}public static string {enumName}ToName({enumName} value) {{\n" +
                             $"{CodeGenUtils.GetIndentation(2)}return value switch {{\n";
                enumsCode = enumValues.Aggregate(enumsCode, (current, enumValue) =>
                    current + $"{CodeGenUtils.GetIndentation(3)}{enumName}.{CodeGenUtils.NamespacedIdToPascalName(enumValue)} => \"{enumValue}\",\n");
                enumsCode += $"{CodeGenUtils.GetIndentation(3)}_ => throw new ArgumentOutOfRangeException(nameof(value), value, \"Unknown {enumName} value.\")\n" +
                             $"{CodeGenUtils.GetIndentation(2)}}};\n" +
                             $"{CodeGenUtils.GetIndentation(1)}}}\n";
            }
            
            // =====================================================
            //                  To State Id Logic
            // =====================================================
            string toStateLogic = "return ";

            void GenSwitchStatement(int index, string[] path) {
                if (index >= props.Count) {
                    JObject state = states.First(s => {
                        JObject stateObj = s.ToObject<JObject>()!;
                        Dictionary<string, string> propertyVals = stateObj["properties"]!.ToObject<Dictionary<string, string>>()!;
                        for (int i = 0; i < path.Length; i++) {
                            string pathVal = path[i];
                            if (propertyVals[props[i].Name] != pathVal) {
                                return false;
                            }
                        }
                        return true;
                    }).ToObject<JObject>()!;
                    
                    int stateId = state["id"]!.ToObject<int>()!;
                    toStateLogic += $"{stateId}";
                    return;
                }
                
                IProperty prop = props[index];

                string pascalPropName = GetPascalPropName(prop);
                toStateLogic += $"{pascalPropName} switch {{\n";
                string[] cases = GetCSharpSwitchCases(prop);
                for (int i = 0; i < cases.Length; i++) {
                    string t = cases[i];
                    toStateLogic += $"{CodeGenUtils.GetIndentation(index + 4)}{t} => ";
                    string[] newPath = path.ToArray();
                    newPath[index] = prop.AllowedValues[i];
                    GenSwitchStatement(index + 1, newPath);
                    toStateLogic += $",\n";
                }

                if (prop is BooleanProperty) {
                    toStateLogic += $"{CodeGenUtils.GetIndentation(index + 3)}}}";
                }
                else toStateLogic += $"{CodeGenUtils.GetIndentation(index + 4)}_ => throw new ArgumentOutOfRangeException(nameof({pascalPropName}), {pascalPropName}, \"Unknown value for property {prop.Name}.\")\n{CodeGenUtils.GetIndentation(index + 3)}}}";
            }
            
            GenSwitchStatement(0, new string[props.Count]);
            toStateLogic += ";";
            
            // =====================================================
            //               From State Logic
            // =====================================================
            JObject? defaultState = null;
            int[] stateIds = new int[states.Count];
            string fromStateLogic = "return state switch {\n";
            for (int i = 0; i < states.Count; i++) {
                JToken stateTok = states[i];
                JObject stateObj = stateTok.ToObject<JObject>()!;
                int stateId = stateObj["id"]!.ToObject<int>();
                stateIds[i] = stateId;

                // quick check for default state
                if (stateObj.ContainsKey("default")) {
                    defaultState = stateObj;
                }

                Dictionary<string, string> propertyVals =
                    stateObj["properties"]!.ToObject<Dictionary<string, string>>()!;
                fromStateLogic += $"            {stateId} => new {pascalName}(Identifier, ";
                List<string> args = [];
                foreach (IProperty prop in props) {
                    if (prop.Type == PropertyType.Enum) {
                        string enumValue = propertyVals[prop.Name];
                        args.Add(
                            $"{CodeGenUtils.NamespacedIdToPascalName(prop.Name)}.{CodeGenUtils.NamespacedIdToPascalName(enumValue)}");
                    }
                    else if (prop.Type == PropertyType.Boolean) {
                        args.Add(propertyVals[prop.Name] == "true" ? "true" : "false");
                    }
                    else if (prop.Type == PropertyType.Integer) {
                        args.Add(propertyVals[prop.Name]);
                    }
                    else if (prop.Type == PropertyType.ExistingEnum) {
                        ExistingEnumProperty ee = (prop as ExistingEnumProperty)!;
                        args.Add($"{ee.ExistingEnum}.{CodeGenUtils.NamespacedIdToPascalName(propertyVals[ee.Name])}");
                    }
                }

                fromStateLogic += string.Join(", ", args) + "),\n";
            }

            fromStateLogic += "            _ => throw new ArgumentOutOfRangeException(nameof(state), state, \"Unknown state id.\")\n        };";
            
            // =====================================================
            //               Load State Logic
            // =====================================================
            StringBuilder loadStateLogic = new("return this with {\n");
            foreach (IProperty prop in props) {
                string pascalPropName = GetPascalPropName(prop);
                switch (prop) {
                    case EnumProperty:
                        loadStateLogic.Append($"{CodeGenUtils.GetIndentation(3)}{pascalPropName} = {CodeGenUtils.NamespacedIdToPascalName(prop.Name)}FromString(properties[\"{prop.Name}\"].GetString()),\n");
                        break;
                    case BooleanProperty:
                        loadStateLogic.Append($"{CodeGenUtils.GetIndentation(3)}{pascalPropName} = properties[\"{prop.Name}\"].GetString() == \"true\",\n");
                        break;
                    case IntegerProperty:
                        loadStateLogic.Append($"{CodeGenUtils.GetIndentation(3)}{pascalPropName} = int.Parse(properties[\"{prop.Name}\"].GetString()),\n");
                        break;
                    case ExistingEnumProperty ee: {
                        loadStateLogic.Append($"{CodeGenUtils.GetIndentation(3)}{pascalPropName} = {ee.ExistingEnum}Extensions.FromString(properties[\"{ee.Name}\"].GetString()),\n");
                        break;
                    }
                }
            }
            loadStateLogic.Append($"{CodeGenUtils.GetIndentation(2)}}};");
            
            // =====================================================
            //               To NBT State Logic
            // =====================================================
            List<string> toNbtFields = [];
            Func<string, string, string> toNbtFieldGenerator = (name, strVal) => $"{CodeGenUtils.GetIndentation(3)}new StringTag(\"{name}\", {strVal})";
            Action<string, string> addNbtField = (name, strVal) => {
                toNbtFields.Add(toNbtFieldGenerator(name, strVal));
            };
            foreach (IProperty prop in props) {
                string pascalPropName = GetPascalPropName(prop);
                switch (prop) {
                    case EnumProperty:
                        addNbtField(prop.Name, $"{CodeGenUtils.NamespacedIdToPascalName(prop.Name)}ToName({pascalPropName})");
                        break;
                    case BooleanProperty:
                        addNbtField(prop.Name, $"{pascalPropName}.ToString().ToLower()");
                        break;
                    case IntegerProperty:
                        addNbtField(prop.Name, $"{pascalPropName}.ToString()");
                        break;
                    case ExistingEnumProperty ee: {
                        addNbtField(prop.Name, $"{pascalPropName}.ToName()");
                        break;
                    }
                }
            }
            
            string file = TemplateFile.Replace("{name}", pascalName)
                .Replace("{args}", argsCode)
                .Replace("{to_state_logic}", toStateLogic)
                .Replace("{from_state_logic}", fromStateLogic)
                .Replace("{enums}", enumsCode)
                .Replace("{load_state_logic}", loadStateLogic.ToString())
                .Replace("{to_nbt_fields}", string.Join(",\n", toNbtFields))
                .Replace("{reginfo}", staticData.ToString())
                .Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd"));
            
            // let's get the default and add it to the registry
            if (defaultState == null) {
                throw new Exception($"Block {id} has no default state defined.");
            }

            List<string> regParams = [];
            for (int i = 0; i < props.Count; i++) {
                string propVal = defaultState["properties"]!.ToObject<Dictionary<string, string>>()![props[i].Name];
                int indexOfVal = props[i].AllowedValues.ToList().IndexOf(propVal);
                regParams.Add(GetCSharpSwitchCases(props[i], pascalName, true)[indexOfVal]);
            }

            string defaultBlockDefinition = $"new(\"{id}\", {string.Join(", ", regParams)})";
            registryData.Append($"{CodeGenUtils.GetIndentation(2)}Data.Blocks.Add(Block.{staticVarName}, {string.Join(", ", stateIds)});\n");
            blocksFileEntries.Append(
                $"{CodeGenUtils.GetIndentation(1)}public static readonly {pascalName} {staticVarName} = {defaultBlockDefinition};\n");
            
            string path = Path.Combine(Directory.GetCurrentDirectory(), "BlockTypes", pascalName + ".cs");
            File.WriteAllText(path, file);
        }
        
        File.WriteAllText("Block.cs", BlocksFileTemplate
            .Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd"))
            .Replace("{entries}", blocksFileEntries.ToString()));

        return registryData.ToString();
    }
}
