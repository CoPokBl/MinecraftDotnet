using System.Globalization;
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
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record {name}(Identifier Identifier, {args}) : IBlock{interfaces} {
{stateinfos}
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
        return new CompoundTag(
{to_nbt_fields}
        );
    }
    
{enums}}

""";
    
    /// <summary>
    /// What every generated block type puts in front of its <c>BlockInfo</c> and
    /// <c>BlockStateInfo</c>. They are written out rather than left as default interface members
    /// because a caller holding the concrete type, which is what <c>Block.Stone</c> is, would not
    /// see those.
    /// </summary>
    private const string ForwardingProperties =
"""
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public bool BlocksMotion => StateInfo.BlocksMotion;
    public int LightEmission => StateInfo.LightEmission;
    public int LightDampening => StateInfo.LightDampening;
    public bool Replaceable => StateInfo.Replaceable;
    public string SoundType => StateInfo.SoundType;
    public ICollisionBox BlockShape => StateInfo.BlockShape;
    public ICollisionBox CollisionShape => StateInfo.CollisionShape;
    public ICollisionBox OcclusionShape => StateInfo.OcclusionShape;
    public ICollisionBox InteractionShape => StateInfo.InteractionShape;
    public ICollisionBox VisualShape => StateInfo.VisualShape;
    public ICollisionBox SupportShape => StateInfo.SupportShape;
    public bool RedstoneConductor => StateInfo.RedstoneConductor;
    public bool SignalSource => StateInfo.SignalSource;
    public bool Flammable => StateInfo.Flammable;
    public PushReaction PushReaction => StateInfo.PushReaction;
    public int MapColorId => StateInfo.MapColorId;
    public bool CanRespawnIn => StateInfo.CanRespawnIn;
    public bool RandomlyTicking => StateInfo.RandomlyTicking;
    public bool Suffocating => StateInfo.Suffocating;
    public bool ViewBlocking => StateInfo.ViewBlocking;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

""";

    private const string ShapesFileTemplate =
"""
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.
// The shapes every block state points at, parsed once: the same few hundred turn up across all of
// them, and re-parsing one per property read is what block collision used to cost.
internal static class BlockShapes {
{entries}}

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

    /// <summary>
    /// Vanilla's <c>Half</c>, as opposed to <see cref="BlockHalfValues"/> which is its
    /// <c>DoubleBlockHalf</c>. Only <c>half</c> takes these two values, over the 85 stairs and
    /// trapdoors, so it is unambiguous to share the enum.
    /// </summary>
    private static readonly HashSet<string> TopBottomValues = ["top", "bottom"];
    private static readonly HashSet<string> LeftRightValues = ["left", "right"];
    private static readonly HashSet<string> AxisValues = ["x", "y", "z"];
    private static readonly HashSet<string> RailDirectionValues = ["north_south", "east_west", "ascending_east", "ascending_west", "ascending_north", "ascending_south"];
    private static readonly HashSet<string> WallSideValues = ["none", "low", "tall"];
    private static readonly HashSet<string> BedPartValues = ["head", "foot"];
    private static readonly HashSet<string> SculkSensorPhaseValues = ["inactive", "active", "cooldown"];
    private static readonly HashSet<string> OrientationValues = ["down_east", "down_north", "down_south", "down_west", "up_east", "up_north", "up_south", "up_west", "west_up", "east_up", "north_up", "south_up"];
    private static readonly HashSet<string> RedstoneWireConnectionValues = ["up", "side", "none"];
    private static readonly HashSet<string> ChestTypeValues = ["single", "left", "right"];
    private static readonly HashSet<string> SpeleothemThicknessValues = ["tip_merge", "tip", "frustum", "middle", "base"];
    private static readonly HashSet<string> VerticalDirectionValues = ["up", "down"];
    private static readonly HashSet<string> BellAttachTypeValues = ["floor", "ceiling", "single_wall", "double_wall"];
    private static readonly HashSet<string> CreakingHeartStateValues = ["uprooted", "dormant", "awake"];
    private static readonly HashSet<string> PotentSulfurStateValues = ["dry", "wet", "dormant", "erupting", "continuous"];
    private static readonly HashSet<string> RailShapeValues = ["north_south", "east_west", "ascending_east", "ascending_west", "ascending_north", "ascending_south", "south_east", "south_west", "north_west", "north_east"];
    private static readonly HashSet<string> NoteBlockInstrumentValues = ["harp", "basedrum", "snare", "hat", "bass", "flute", "bell", "guitar", "chime", "xylophone", "iron_xylophone", "cow_bell", "didgeridoo", "bit", "banjo", "pling", "trumpet", "trumpet_exposed", "trumpet_oxidized", "trumpet_weathered", "zombie", "skeleton", "creeper", "dragon", "wither_skeleton", "piglin", "custom_head"];

    /// <summary>
    /// Member names a block type already uses for what it reads off its <c>BlockStateInfo</c>. A
    /// property landing on one of these takes the suffix instead of colliding with it, which is what
    /// the note block's own instrument does.
    /// </summary>
    private static readonly HashSet<string> ReservedPropNames = ["Instrument"];


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
        string name = CodeGenUtils.NamespacedIdToPascalName(prop.Name);
        return prop is EnumProperty || ReservedPropNames.Contains(name) ? name + "Value" : name;
    }

    /// <summary>
    /// The <c>BlockFace</c> each per direction connection property stands for, in the order
    /// vanilla's <c>PROPERTY_BY_DIRECTION</c> is built from <c>Direction.values()</c>.
    /// </summary>
    /// <summary>
    /// The counting properties that stack in place when the same item is used on them. All six count
    /// from one. See <c>IStackable</c>.
    /// </summary>
    private static readonly HashSet<string> StackableProps =
        ["candles", "layers", "pickles", "eggs", "flower_amount", "segment_amount"];

    private static readonly (string Name, string Face)[] ConnectionFaces = [
        ("down", "NegY"), ("up", "PosY"), ("north", "NegZ"),
        ("south", "PosZ"), ("west", "NegX"), ("east", "PosX")
    ];

    /// <summary>
    /// The property interfaces a block implements because of the state properties it has, and the
    /// typed setters that come with them. See <c>Minecraft/Data/Blocks/Properties/README.md</c>.
    /// <p/>
    /// Matched on property name <b>and</b> resolved type, not on name alone, because two properties
    /// share a name and mean different things: <c>half</c> is vanilla's <c>Half</c> on a stair and
    /// its <c>DoubleBlockHalf</c> on a door, and a wall's <c>north</c> has a height where a fence's
    /// is a flag. Getting those the same way round as vanilla is the whole point of the exercise, so
    /// they get separate interfaces rather than one loose one.
    /// <p/>
    /// The getters are the record's own positional properties, so only the setters are written here.
    /// That only holds while <see cref="GetPascalPropName"/> leaves these names alone; a property
    /// that started taking the <c>Value</c> suffix would stop implementing its interface and fail to
    /// compile, which is the intended way to find out.
    /// </summary>
    private static (string Interfaces, string Methods) PropertyInterfaces(string typeName, List<IProperty> props) {
        List<string> interfaces = [];
        StringBuilder methods = new();

        void Setter(IProperty prop, string face, string method, string arg) {
            interfaces.Add(face);
            methods.Append($"\n    public IBlock {method}({GetCSharpType(typeName, prop)} {arg}) " +
                           $"=> this with {{ {GetPascalPropName(prop)} = {arg} }};\n");
        }

        foreach (IProperty prop in props) {
            string type = GetCSharpType(typeName, prop);
            bool boolean = prop.Type == PropertyType.Boolean;
            switch (prop.Name) {
                case "waterlogged" when boolean: Setter(prop, "IWaterlogged", "WithWaterlogged", "waterlogged"); break;
                case "powered" when boolean: Setter(prop, "IPowered", "WithPowered", "powered"); break;
                case "open" when boolean: Setter(prop, "IOpenable", "WithOpen", "open"); break;
                case "lit" when boolean: Setter(prop, "ILit", "WithLit", "lit"); break;
                case "facing" when type == "Direction": Setter(prop, "IHorizontalFacing", "WithFacing", "facing"); break;
                case "facing" when type == "Cardinal": Setter(prop, "IDirectional", "WithFacing", "facing"); break;
                case "axis" when type == "Axis": Setter(prop, "IAxisAligned", "WithAxis", "axis"); break;
                case "face" when type == "AttachDirection": Setter(prop, "IAttachFaced", "WithFace", "face"); break;
                case "rotation" when prop.Type == PropertyType.Integer: Setter(prop, "IRotated", "WithRotation", "rotation"); break;
                case "half" when type == "TopBottom": Setter(prop, "IHalved", "WithHalf", "half"); break;
                case "half" when type == "BlockHalf": Setter(prop, "IDoubleHalved", "WithHalf", "half"); break;
                case "type" when type == "SlabType": Setter(prop, "ISlabTyped", "WithType", "type"); break;
                case "shape" when type == "StairShape": Setter(prop, "IStairShaped", "WithShape", "shape"); break;
                case "part" when type == "BedPart": Setter(prop, "IBedParted", "WithPart", "part"); break;
                case "hinge" when type == "LeftRight": Setter(prop, "IHinged", "WithHinge", "hinge"); break;

                // The one property families. See Properties/FlagProperties.cs for why these are
                // types rather than being left to PlacementHelpers.WithProperty.
                case "in_wall" when boolean: Setter(prop, "IInWall", "WithInWall", "inWall"); break;
                case "locked" when boolean: Setter(prop, "ILocked", "WithLocked", "locked"); break;
                case "berries" when boolean: Setter(prop, "IBerried", "WithBerries", "berries"); break;
                case "bottom" when boolean: Setter(prop, "IBottomed", "WithBottom", "bottom"); break;
                case "snowy" when boolean: Setter(prop, "ISnowy", "WithSnowy", "snowy"); break;
                case "signal_fire" when boolean: Setter(prop, "ISignalFire", "WithSignalFire", "signalFire"); break;
                case "persistent" when boolean: Setter(prop, "IPersistent", "WithPersistent", "persistent"); break;
                case "enabled" when boolean: Setter(prop, "IEnabled", "WithEnabled", "enabled"); break;
                case "hanging" when boolean: Setter(prop, "IHanging", "WithHanging", "hanging"); break;
                case "attached" when boolean: Setter(prop, "IAttached", "WithAttached", "attached"); break;
                case "occupied" when boolean: Setter(prop, "IOccupied", "WithOccupied", "occupied"); break;
                case "tip" when boolean: Setter(prop, "ITipped", "WithTip", "tip"); break;

                // The one property families whose values are an enum. Each needed its value set
                // adding to the tables above first, so that the enum is shared rather than nested
                // inside one record and unnameable from an interface.
                case "type" when type == "ChestType": Setter(prop, "IChestTyped", "WithType", "type"); break;
                case "thickness" when type == "SpeleothemThickness": Setter(prop, "ISpeleothem", "WithThickness", "thickness"); break;
                case "vertical_direction" when type == "VerticalDirection": Setter(prop, "IVerticallyDirected", "WithVerticalDirection", "verticalDirection"); break;
                case "attachment" when type == "BellAttachType": Setter(prop, "IBellAttached", "WithAttachment", "attachment"); break;
                case "creaking_heart_state" when type == "CreakingHeartState": Setter(prop, "ICreakingHearted", "WithCreakingHeartState", "creakingHeartState"); break;
                case "potent_sulfur_state" when type == "PotentSulfurState": Setter(prop, "IPotentSulfured", "WithPotentSulfurState", "potentSulfurState"); break;
                case "shape" when type == "RailShape": Setter(prop, "IRailShaped", "WithShape", "shape"); break;
                case "shape" when type == "RailDirection": Setter(prop, "IRailDirected", "WithShape", "shape"); break;
                case "instrument" when type == "NoteBlockInstrument": Setter(prop, "IInstrumented", "WithInstrument", "instrument"); break;
                case "age" when prop.Type == PropertyType.Integer: Setter(prop, "IAged", "WithAge", "age"); break;
                case "distance" when prop.Type == PropertyType.Integer: Setter(prop, "IDistanced", "WithDistance", "distance"); break;
            }

            // The six counting properties that stack in place. Grouped into one interface because the
            // property name is the only thing that differs between the six placement bodies upstream.
            if (StackableProps.Contains(prop.Name) && prop is IntegerProperty counted) {
                interfaces.Add("IStackable");
                string name = GetPascalPropName(prop);
                methods.Append($"\n    public int Count => {name};\n")
                       .Append($"\n    public int MaxCount => {counted.Max};\n")
                       .Append($"\n    public IBlock WithCount(int count) => this with {{ {name} = count }};\n");
            }
        }

        // Per direction connections. A wall has both: WallSide horizontals and a boolean up.
        (string Face, string Prop)[] flags = ConnectionFaces
            .Select(f => (f.Face, Prop: props.FirstOrDefault(p => p.Name == f.Name && p.Type == PropertyType.Boolean)))
            .Where(f => f.Prop is not null)
            .Select(f => (f.Face, GetPascalPropName(f.Prop!)))
            .ToArray();

        (string Face, string Prop)[] sides = ConnectionFaces
            .Select(f => (f.Face, Prop: props.FirstOrDefault(p =>
                p.Name == f.Name && p is ExistingEnumProperty { ExistingEnum: "WallSide" })))
            .Where(f => f.Prop is not null)
            .Select(f => (f.Face, GetPascalPropName(f.Prop!)))
            .ToArray();

        if (flags.Length > 0) {
            interfaces.Add("IFaceConnected");
            string has = string.Join(" or ", flags.Select(f => $"BlockFace.{f.Face}"));
            methods.Append($"\n    public bool HasFace(BlockFace face) => face is {has};\n")
                   .Append("\n    public bool Connected(BlockFace face) => face switch {\n")
                   .Append(string.Join("", flags.Select(f => $"        BlockFace.{f.Face} => {f.Prop},\n")))
                   .Append("        _ => false\n    };\n")
                   .Append("\n    public IBlock WithConnection(BlockFace face, bool connected) => face switch {\n")
                   .Append(string.Join("", flags.Select(f => $"        BlockFace.{f.Face} => this with {{ {f.Prop} = connected }},\n")))
                   .Append("        _ => this\n    };\n");
        }

        if (sides.Length > 0) {
            interfaces.Add("IWallConnected");
            methods.Append("\n    public WallSide Side(BlockFace face) => face switch {\n")
                   .Append(string.Join("", sides.Select(s => $"        BlockFace.{s.Face} => {s.Prop},\n")))
                   .Append("        _ => WallSide.None\n    };\n")
                   .Append("\n    public IBlock WithSide(BlockFace face, WallSide side) => face switch {\n")
                   .Append(string.Join("", sides.Select(s => $"        BlockFace.{s.Face} => this with {{ {s.Prop} = side }},\n")))
                   .Append("        _ => this\n    };\n");
        }

        return (interfaces.Count == 0 ? "" : ", " + string.Join(", ", interfaces), methods.ToString());
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
        JObject blocksDataJson = JObject.Parse(CodeGenUtils.ReadDumpFile("block.json"));

        ShapeTable shapes = new();
        StringBuilder registryData = new();
        StringBuilder blocksFileEntries = new();

        foreach ((string id, JToken? value) in blocksJson) {
            JObject blockData = value!.ToObject<JObject>()!;
            string staticVarName = CodeGenUtils.NamespacedIdToPascalName(id);

            // FETCH ADDITIONAL DATA
            JObject dataEntry = blocksDataJson[id]!.ToObject<JObject>()!;
            int protocolId = dataEntry["id"]!.ToObject<int>();
            string category = blockData["definition"]!["type"]!.ToObject<string>()!;
            string blockInfo = BlockInfoCode(dataEntry, category);
            Dictionary<int, string[]> stateValues = StateValuesByStateId(dataEntry, shapes);

            // do we need a record?
            JArray states = blockData["states"]!.ToObject<JArray>()!;
            if (states.Count == 1) {  // simple! yay! fewer classes
                JObject state = states[0].ToObject<JObject>()!;
                int stateId = state["id"]!.ToObject<int>();

                registryData.Append($"{CodeGenUtils.GetIndentation(2)}Data.Blocks.Add({protocolId}, Block.{staticVarName}, {stateId});\n");
                blocksFileEntries.Append($"{CodeGenUtils.GetIndentation(1)}public static readonly SimpleBlock {staticVarName} = " +
                                         $"new(\"{id}\", {stateId}, {blockInfo}, new({string.Join(", ", stateValues[stateId])}));\n");
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

                registryData.Append($"{CodeGenUtils.GetIndentation(2)}Data.Blocks.Add({protocolId}, Block.{staticVarName}, {waterloggedState}, {airLoggedState});\n");
                blocksFileEntries.Append(
                    $"{CodeGenUtils.GetIndentation(1)}public static readonly WaterloggableBlock {staticVarName} = " +
                    $"new(\"{id}\", {airLoggedState}, {waterloggedState}, {defaultIsWaterlogged.ToString().ToLower()}, " +
                    $"{blockInfo}, new({string.Join(", ", stateValues[airLoggedState])}), " +
                    $"new({string.Join(", ", stateValues[waterloggedState])}));\n");
                continue;  // they don't need a record class, just a simple block
            }

            // complex! we need a record class
            string pascalName = CodeGenUtils.NamespacedIdToPascalName(id) + "Block";

            // COMPILE ALL THE DATA INTO PROPS
            StringBuilder staticData = new();
            staticData.Append($"{CodeGenUtils.GetIndentation(1)}public BlockInfo Info => Data;\n");
            staticData.Append(ForwardingProperties);

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

                if (SameValues(propAllowedValues, TopBottomValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "TopBottom", TopBottomValues));
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

                if (SameValues(propAllowedValues, NoteBlockInstrumentValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "NoteBlockInstrument", NoteBlockInstrumentValues));
                    continue;
                }

                if (SameValues(propAllowedValues, ChestTypeValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "ChestType", ChestTypeValues));
                    continue;
                }

                if (SameValues(propAllowedValues, SpeleothemThicknessValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "SpeleothemThickness", SpeleothemThicknessValues));
                    continue;
                }

                if (SameValues(propAllowedValues, VerticalDirectionValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "VerticalDirection", VerticalDirectionValues));
                    continue;
                }

                if (SameValues(propAllowedValues, BellAttachTypeValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "BellAttachType", BellAttachTypeValues));
                    continue;
                }

                if (SameValues(propAllowedValues, CreakingHeartStateValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "CreakingHeartState", CreakingHeartStateValues));
                    continue;
                }

                if (SameValues(propAllowedValues, PotentSulfurStateValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "PotentSulfurState", PotentSulfurStateValues));
                    continue;
                }

                if (SameValues(propAllowedValues, RailShapeValues)) {
                    props.Add(new ExistingEnumProperty(propAllowedValues, propName, "RailShape", RailShapeValues));
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

            // What the properties make this block, for anything holding an IBlock. See
            // Minecraft/Data/Blocks/Properties/README.md.
            (string interfacesCode, string withMethods) = PropertyInterfaces(pascalName, props);
            staticData.Append(withMethods);

            // =====================================================
            //                        ENUMs
            // =====================================================
            StringBuilder enumsCode = new();
            foreach (IProperty prop in props) {
                if (prop.Type != PropertyType.Enum) continue;
                string enumName = CodeGenUtils.NamespacedIdToPascalName(prop.Name);
                string[] enumValues = ((EnumProperty)prop).AllowedValues;
                
                // Definition
                enumsCode.Append($"    public enum {enumName} {{\n");
                foreach (string enumValue in enumValues) {
                    enumsCode.Append($"{CodeGenUtils.GetIndentation(2)}{CodeGenUtils.NamespacedIdToPascalName(enumValue)},\n");
                }
                enumsCode.Append("    }\n");
                
                // We need an extension method to convert from string to enum
                enumsCode.Append($"\n{CodeGenUtils.GetIndentation(1)}public static {enumName} {enumName}FromString(string value) {{\n")
                         .Append($"{CodeGenUtils.GetIndentation(2)}return value switch {{\n");
                foreach (string enumValue in enumValues) {
                    enumsCode.Append($"{CodeGenUtils.GetIndentation(3)}\"{enumValue}\" => {enumName}.{CodeGenUtils.NamespacedIdToPascalName(enumValue)},\n");
                }
                enumsCode.Append($"{CodeGenUtils.GetIndentation(3)}_ => throw new ArgumentOutOfRangeException(nameof(value), value, \"Unknown value for {enumName}.\")\n")
                         .Append($"{CodeGenUtils.GetIndentation(2)}}};\n")
                         .Append($"{CodeGenUtils.GetIndentation(1)}}}\n");
                
                // We also need a ToName method
                enumsCode.Append($"\n{CodeGenUtils.GetIndentation(1)}public static string {enumName}ToName({enumName} value) {{\n")
                         .Append($"{CodeGenUtils.GetIndentation(2)}return value switch {{\n");
                foreach (string enumValue in enumValues) {
                    enumsCode.Append($"{CodeGenUtils.GetIndentation(3)}{enumName}.{CodeGenUtils.NamespacedIdToPascalName(enumValue)} => \"{enumValue}\",\n");
                }
                enumsCode.Append($"{CodeGenUtils.GetIndentation(3)}_ => throw new ArgumentOutOfRangeException(nameof(value), value, \"Unknown {enumName} value.\")\n")
                         .Append($"{CodeGenUtils.GetIndentation(2)}}};\n")
                         .Append($"{CodeGenUtils.GetIndentation(1)}}}\n");
            }
            
            // =====================================================
            //                  To State Id Logic
            // =====================================================
            StringBuilder toStateLogic = new("return ");

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
                    toStateLogic.Append($"{stateId}");
                    return;
                }
                
                IProperty prop = props[index];

                string pascalPropName = GetPascalPropName(prop);
                toStateLogic.Append($"{pascalPropName} switch {{\n");
                string[] cases = GetCSharpSwitchCases(prop);
                for (int i = 0; i < cases.Length; i++) {
                    string t = cases[i];
                    toStateLogic.Append($"{CodeGenUtils.GetIndentation(index + 4)}{t} => ");
                    string[] newPath = path.ToArray();
                    newPath[index] = prop.AllowedValues[i];
                    GenSwitchStatement(index + 1, newPath);
                    toStateLogic.Append($",\n");
                }

                if (prop is BooleanProperty) {
                    toStateLogic.Append($"{CodeGenUtils.GetIndentation(index + 3)}}}");
                }
                else toStateLogic.Append($"{CodeGenUtils.GetIndentation(index + 4)}_ => throw new ArgumentOutOfRangeException(nameof({pascalPropName}), {pascalPropName}, \"Unknown value for property {prop.Name}.\")\n{CodeGenUtils.GetIndentation(index + 3)}}}");
            }
            
            GenSwitchStatement(0, new string[props.Count]);
            toStateLogic.Append(";");
            
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
            Func<string, string, string, string> withFormatter = (propName, fieldName, serialiser) => 
                $"{CodeGenUtils.GetIndentation(3)}{fieldName} = properties.Contains(\"{propName}\") ? {serialiser} : {fieldName},\n";
            foreach (IProperty prop in props) {
                string pascalPropName = GetPascalPropName(prop);
                switch (prop) {
                    case EnumProperty:
                        loadStateLogic.Append(withFormatter(prop.Name, pascalPropName, $"{CodeGenUtils.NamespacedIdToPascalName(prop.Name)}FromString(properties[\"{prop.Name}\"].GetString())"));
                        break;
                    case BooleanProperty:
                        loadStateLogic.Append(withFormatter(prop.Name, pascalPropName, $"properties[\"{prop.Name}\"].GetString() == \"true\""));
                        break;
                    case IntegerProperty:
                        loadStateLogic.Append(withFormatter(prop.Name, pascalPropName, $"int.Parse(properties[\"{prop.Name}\"].GetString())"));
                        break;
                    case ExistingEnumProperty ee: {
                        loadStateLogic.Append(withFormatter(prop.Name, pascalPropName, $"{ee.ExistingEnum}Extensions.FromString(properties[\"{ee.Name}\"].GetString())"));
                        break;
                    }
                }
            }
            loadStateLogic.Append($"{CodeGenUtils.GetIndentation(2)}}};");
            
            // =====================================================
            //               To NBT State Logic
            // =====================================================
            List<string> toNbtFields = [];
            Func<string, string, string> toNbtFieldGenerator = (name, strVal) => $"{CodeGenUtils.GetIndentation(3)}(\"{name}\", new StringTag({strVal}))";
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
                .Replace("{stateinfos}", StateInfosCode(blockInfo, stateIds, stateValues))
                .Replace("{args}", argsCode)
                .Replace("{interfaces}", interfacesCode)
                .Replace("{to_state_logic}", toStateLogic.ToString())
                .Replace("{from_state_logic}", fromStateLogic)
                .Replace("{enums}", enumsCode.ToString())
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
                int indexOfVal = Array.IndexOf(props[i].AllowedValues, propVal);
                regParams.Add(GetCSharpSwitchCases(props[i], pascalName, true)[indexOfVal]);
            }

            string defaultBlockDefinition = $"new(\"{id}\", {string.Join(", ", regParams)})";
            registryData.Append($"{CodeGenUtils.GetIndentation(2)}Data.Blocks.Add({protocolId}, Block.{staticVarName}, {string.Join(", ", stateIds)});\n");
            blocksFileEntries.Append(
                $"{CodeGenUtils.GetIndentation(1)}public static readonly {pascalName} {staticVarName} = {defaultBlockDefinition};\n");
            
            string path = Path.Combine(Directory.GetCurrentDirectory(), "BlockTypes", pascalName + ".cs");
            File.WriteAllText(path, file);
        }
        
        File.WriteAllText("Block.cs", BlocksFileTemplate
            .Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd"))
            .Replace("{entries}", blocksFileEntries.ToString()));
        File.WriteAllText("BlockShapes.cs", shapes.ToCode());

        return registryData.ToString();
    }

    /// <summary>
    /// The shapes every block state points at. The same few hundred boxes turn up across all 32 thousand
    /// states, so they get parsed once here rather than at every property read.
    /// </summary>
    private sealed class ShapeTable {
        private readonly Dictionary<string, string> _names = [];
        private readonly List<string> _order = [];

        /// <summary>The generated reference for an aabb list, adding it to the table if it is new.</summary>
        public string Reference(string aabbs) {
            if (!_names.TryGetValue(aabbs, out string? name)) {
                name = "S" + _order.Count;
                _names[aabbs] = name;
                _order.Add(aabbs);
            }

            return "BlockShapes." + name;
        }

        public string ToCode() {
            StringBuilder code = new(ShapesFileTemplate);
            StringBuilder entries = new();
            for (int i = 0; i < _order.Count; i++) {
                entries.Append($"{CodeGenUtils.GetIndentation(1)}public static readonly ICollisionBox S{i} = " +
                               $"ICollisionBox.ParseAabbArrayString(\"{_order[i]}\");\n");
            }

            return code.Replace("{entries}", entries.ToString()).ToString();
        }
    }

    /// <summary>
    /// A whole <c>BlockInfo</c> expression: the constructor call, and an initialiser for the members
    /// that are not constructor arguments.
    /// <p/>
    /// <c>ShapeOffsets</c> is not a constructor argument on purpose. It is zero for all but the forty
    /// odd blocks whose shapes move with their position, and leaving it off keeps it out of every other
    /// block's generated line.
    /// </summary>
    private static string BlockInfoCode(JObject dataEntry, string category) {
        int shapeOffsets = dataEntry["shapeOffsets"]?.ToObject<int>() ?? 0;

        List<string> initialisers = [];
        if (shapeOffsets != 0) {
            initialisers.Add($"ShapeOffsets = {ShapeOffsetsCode(shapeOffsets)}");
        }

        // Eighteen blocks of the twelve hundred, so it stays out of every other block's line for the
        // same reason ShapeOffsets does.
        if (dataEntry["experienceMin"] != null) {
            initialisers.Add($"Experience = ({dataEntry["experienceMin"]}, {dataEntry["experienceMax"]})");
        }

        string init = initialisers.Count == 0 ? "" : $" {{ {string.Join(", ", initialisers)} }}";
        return $"new({BlockInfoArguments(dataEntry, category)}){init}";
    }

    /// <summary>The dumper's bitmask as named flags, in the same order it sets them.</summary>
    private static string ShapeOffsetsCode(int mask) {
        string[] names = ["Block", "Collision", "Interaction", "Occlusion", "Visual"];
        IEnumerable<string> set = names.Where((_, i) => (mask & (1 << i)) != 0).Select(n => $"BlockShapeOffsets.{n}");
        return string.Join(" | ", set);
    }

    private static string BlockInfoArguments(JObject dataEntry, string category) {
        string offsetType = dataEntry["offsetType"]?.ToObject<string>() switch {
            null => "None",
            "xz" => "Xz",
            "xyz" => "Xyz",
            string other => throw new ArgumentOutOfRangeException(nameof(dataEntry), other, "Unknown offset type.")
        };

        JArray? features = dataEntry["requiredFeatures"]?.ToObject<JArray>();
        string requiredFeatures = features is null
            ? "BlockInfo.VanillaOnly"
            : "[" + string.Join(", ", features.Select(f => Str(f.ToObject<string>()))) + "]";

        return $"{Str(category)}, {Str(dataEntry["translationKey"]!.ToObject<string>())}, " +
               $"{Num(dataEntry["explosionResistance"])}f, {Num(dataEntry["friction"])}f, " +
               $"{Num(dataEntry["speedFactor"])}f, {Num(dataEntry["jumpFactor"])}f, " +
               $"{Num(dataEntry["bounceRestitution"])}f, {Bool(dataEntry["gravity"])}, " +
               $"{Bool(dataEntry["dynamicShape"])}, BlockOffsetType.{offsetType}, " +
               $"{Num(dataEntry["maxHorizontalOffset"])}f, {Num(dataEntry["maxVerticalOffset"])}f, " +
               $"{Str(dataEntry["blockEntity"]?["namespace"]?.ToObject<string>())}, " +
               $"{Str(dataEntry["correspondingItem"]?.ToObject<string>())}, {requiredFeatures}, " +
               $"{Str(dataEntry["lootTable"]?.ToObject<string>())}";
    }

    /// <summary>The names of the <c>BlockStateInfo</c> members, in constructor order.</summary>
    private static readonly string[] StateMembers = [
        "Hardness", "LightEmission", "LightDampening", "PushReaction", "MapColorId", "SoundType", "Instrument",
        "CanRespawnIn", "Occludes", "RequiresTool", "BlocksMotion", "Flammable", "Air", "Liquid",
        "Replaceable", "Solid", "RedstoneConductor", "SignalSource", "RandomlyTicking", "Suffocating",
        "ViewBlocking", "SpawnTerrainParticles", "PathfindableLand", "PathfindableWater", "PathfindableAir",
        "ValidSpawnFor", "Fluid", "BlockShape", "CollisionShape",
        "InteractionShape", "OcclusionShape", "VisualShape", "SupportShape"
    ];

    /// <summary>
    /// Every state of a block, resolved. The dump writes block level values once and lists only what
    /// each state disagrees with, which is what keeps it a file worth parsing.
    /// </summary>
    private static Dictionary<int, string[]> StateValuesByStateId(JObject dataEntry, ShapeTable shapes) {
        Dictionary<int, string[]> byStateId = [];

        foreach ((string _, JToken? state) in dataEntry["states"]!.ToObject<JObject>()!) {
            JObject overrides = state!.ToObject<JObject>()!;
            byStateId.Add(overrides["stateId"]!.ToObject<int>(),
                StateValues(key => overrides[key] ?? dataEntry[key], shapes));
        }

        return byStateId;
    }

    private static string[] StateValues(Func<string, JToken?> state, ShapeTable shapes) {
        string pushReaction = state("pushReaction")!.ToObject<string>() switch {
            "NORMAL" => "Normal",
            "DESTROY" => "Destroy",
            "BLOCK" => "Block",
            "PUSH_ONLY" => "PushOnly",
            string other => throw new ArgumentOutOfRangeException(nameof(state), other, "Unknown push reaction.")
        };

        JToken validSpawn = state("validSpawn")!;
        string validSpawnFor = validSpawn.Type == JTokenType.Boolean
            ? validSpawn.ToObject<bool>() ? "null" : "[]"
            : "[" + string.Join(", ", validSpawn.ToObject<JArray>()!.Select(t => Str(t.ToObject<string>()))) + "]";

        return [
            Num(state("hardness")) + "f",
            state("lightEmission")!.ToObject<int>().ToString(),
            state("lightBlock")!.ToObject<int>().ToString(),
            "PushReaction." + pushReaction,
            state("mapColorId")!.ToObject<int>().ToString(),
            Str(state("soundType")!.ToObject<string>()),
            "NoteBlockInstrument." + CodeGenUtils.NamespacedIdToPascalName(state("instrument")!.ToObject<string>()!),
            Bool(state("canRespawnIn")),
            Bool(state("occludes")),
            Bool(state("requiresTool")),
            Bool(state("blocksMotion")),
            Bool(state("flammable")),
            Bool(state("air")),
            Bool(state("liquid")),
            Bool(state("replaceable")),
            Bool(state("solid")),
            Bool(state("redstoneConductor")),
            Bool(state("signalSource")),
            Bool(state("randomlyTicking")),
            Bool(state("suffocating")),
            Bool(state("viewBlocking")),
            Bool(state("spawnTerrainParticles")),
            Bool(state("pathfindableLand")),
            Bool(state("pathfindableWater")),
            Bool(state("pathfindableAir")),
            validSpawnFor,
            Str(state("fluid")?.ToObject<string>()),
            shapes.Reference(state("shape")!.ToObject<string>()!),
            shapes.Reference(state("collisionShape")!.ToObject<string>()!),
            shapes.Reference(state("interactionShape")!.ToObject<string>()!),
            shapes.Reference(state("occlusionShape")!.ToObject<string>()!),
            shapes.Reference(state("visualShape")!.ToObject<string>()!),
            shapes.Reference(state("supportShape")!.ToObject<string>()!)
        ];
    }

    /// <summary>
    /// The state data of a block with more than one state: the block level half, one field per state
    /// that says something different from the default, and the lookup from state id to those.
    /// <p/>
    /// The fields are written out as differences from the default state, which is both shorter and
    /// clearer about what a state actually changes.
    /// </summary>
    private static string StateInfosCode(string blockInfo, int[] stateIds, Dictionary<int, string[]> stateValues) {
        int firstStateId = stateIds.Min();
        for (int i = 0; i < stateIds.Length; i++) {
            if (stateIds[i] != firstStateId + i) {
                throw new Exception("Block state ids are not contiguous, so they cannot index a table.");
            }
        }

        string[] defaults = stateValues[firstStateId];
        StringBuilder code = new($"{CodeGenUtils.GetIndentation(1)}private static readonly BlockInfo Data = {blockInfo};\n");

        // One field per distinct state, keyed by the values so identical states share one.
        Dictionary<string, string> names = [];
        StringBuilder fields = new();
        List<string> byState = [];

        foreach (int stateId in stateIds) {
            string[] values = stateValues[stateId];
            string key = string.Join(", ", values);

            if (!names.TryGetValue(key, out string? name)) {
                name = "I" + names.Count;
                names[key] = name;

                string definition = name == "I0"
                    ? $"new({key})"
                    : $"I0 with {{ {string.Join(", ", Differences(defaults, values))} }}";
                fields.Append($"{CodeGenUtils.GetIndentation(1)}private static readonly BlockStateInfo {name} = {definition};\n");
            }

            byState.Add(name);
        }

        code.Append(fields);
        if (names.Count == 1) {
            return code.Append($"\n{CodeGenUtils.GetIndentation(1)}public BlockStateInfo StateInfo => I0;\n").ToString();
        }

        code.Append($"{CodeGenUtils.GetIndentation(1)}private static readonly BlockStateInfo[] States = [\n" +
                    $"{CodeGenUtils.GetIndentation(2)}{string.Join(", ", byState)}\n" +
                    $"{CodeGenUtils.GetIndentation(1)}];\n");
        return code.Append($"\n{CodeGenUtils.GetIndentation(1)}public BlockStateInfo StateInfo => " +
                           $"States[StateId - {firstStateId}];\n").ToString();
    }

    private static IEnumerable<string> Differences(string[] defaults, string[] values) {
        for (int i = 0; i < values.Length; i++) {
            if (values[i] != defaults[i]) {
                yield return $"{StateMembers[i]} = {values[i]}";
            }
        }
    }

    private static string Str(string? value) => value is null ? "null" : $"\"{value}\"";

    private static string Bool(JToken? value) => value!.ToObject<bool>() ? "true" : "false";

    private static string Num(JToken? value) {
        return (value?.ToObject<double>() ?? 0).ToString(CultureInfo.InvariantCulture);
    }
}
