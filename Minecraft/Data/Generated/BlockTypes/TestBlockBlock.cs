using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TestBlockBlock(Identifier Identifier, TestBlockBlock.Mode ModeValue) : IBlock {

    public Identifier Category => "minecraft:test";
    public double Hardness => -1;
    public double ExplosionResistance => 3600000;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => "minecraft:test_block";
    public Identifier? Item => "minecraft:test_block";
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
    public string TranslationKey => "block.minecraft.test_block";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return ModeValue switch {
                Mode.Start => 20395,
                Mode.Log => 20396,
                Mode.Fail => 20397,
                Mode.Accept => 20398,
                _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20395 => new TestBlockBlock(Identifier, Mode.Start),
            20396 => new TestBlockBlock(Identifier, Mode.Log),
            20397 => new TestBlockBlock(Identifier, Mode.Fail),
            20398 => new TestBlockBlock(Identifier, Mode.Accept),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            ModeValue = ModeFromString(properties["mode"].GetString()),
        };
    }
    
    public enum Mode {
        Start,
        Log,
        Fail,
        Accept,
    }

    public static Mode ModeFromString(string value) {
        return value switch {
            "start" => Mode.Start,
            "log" => Mode.Log,
            "fail" => Mode.Fail,
            "accept" => Mode.Accept,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Mode.")
        };
    }
}
