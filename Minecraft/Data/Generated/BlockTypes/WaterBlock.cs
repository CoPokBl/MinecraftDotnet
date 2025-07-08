using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaterBlock(Identifier Identifier, int Level) : IBlock {

    public Identifier Category => "minecraft:liquid";
    public double Hardness => 100;
    public double ExplosionResistance => 100;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => true;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => true;
    public string SoundType => "empty";
    public Identifier? BlockEntity => null;
    public Identifier? Item => null;
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 12;
    public string TranslationKey => "block.minecraft.water";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Level switch {
                0 => 86,
                1 => 87,
                2 => 88,
                3 => 89,
                4 => 90,
                5 => 91,
                6 => 92,
                7 => 93,
                8 => 94,
                9 => 95,
                10 => 96,
                11 => 97,
                12 => 98,
                13 => 99,
                14 => 100,
                15 => 101,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            86 => new WaterBlock(Identifier, 0),
            87 => new WaterBlock(Identifier, 1),
            88 => new WaterBlock(Identifier, 2),
            89 => new WaterBlock(Identifier, 3),
            90 => new WaterBlock(Identifier, 4),
            91 => new WaterBlock(Identifier, 5),
            92 => new WaterBlock(Identifier, 6),
            93 => new WaterBlock(Identifier, 7),
            94 => new WaterBlock(Identifier, 8),
            95 => new WaterBlock(Identifier, 9),
            96 => new WaterBlock(Identifier, 10),
            97 => new WaterBlock(Identifier, 11),
            98 => new WaterBlock(Identifier, 12),
            99 => new WaterBlock(Identifier, 13),
            100 => new WaterBlock(Identifier, 14),
            101 => new WaterBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = int.Parse(properties["level"].GetString()),
        };
    }
    
}
