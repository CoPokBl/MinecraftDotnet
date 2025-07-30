using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record StructureBlockBlock(Identifier Identifier, StructureBlockBlock.Mode ModeValue) : IBlock {

    public Identifier Category => "minecraft:structure";
    public int ProtocolId => 865;
    public double Hardness => -1;
    public double ExplosionResistance => 3600000;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => "minecraft:structure_block";
    public Identifier? Item => "minecraft:structure_block";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 22;
    public string TranslationKey => "block.minecraft.structure_block";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return ModeValue switch {
                Mode.Save => 20411,
                Mode.Load => 20412,
                Mode.Corner => 20413,
                Mode.Data => 20414,
                _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20411 => new StructureBlockBlock(Identifier, Mode.Save),
            20412 => new StructureBlockBlock(Identifier, Mode.Load),
            20413 => new StructureBlockBlock(Identifier, Mode.Corner),
            20414 => new StructureBlockBlock(Identifier, Mode.Data),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            ModeValue = ModeFromString(properties["mode"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("mode", ModeToName(ModeValue))
        );
    }
    
    public enum Mode {
        Save,
        Load,
        Corner,
        Data,
    }

    public static Mode ModeFromString(string value) {
        return value switch {
            "save" => Mode.Save,
            "load" => Mode.Load,
            "corner" => Mode.Corner,
            "data" => Mode.Data,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Mode.")
        };
    }

    public static string ModeToName(Mode value) {
        return value switch {
            Mode.Save => "save",
            Mode.Load => "load",
            Mode.Corner => "corner",
            Mode.Data => "data",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Mode value.")
        };
    }
}
