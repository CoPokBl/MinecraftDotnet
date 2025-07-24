using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlastFurnaceBlock(Identifier Identifier, Direction Facing, bool Lit) : IBlock {

    public Identifier Category => "minecraft:blast_furnace";
    public int ProtocolId => 809;
    public double Hardness => 3.5;
    public double ExplosionResistance => 3.5;
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
    public Identifier? BlockEntity => "minecraft:blast_furnace";
    public Identifier? Item => "minecraft:blast_furnace";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.blast_furnace";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => 19483,
                    false => 19484,
                },
                Direction.South => Lit switch {
                    true => 19485,
                    false => 19486,
                },
                Direction.West => Lit switch {
                    true => 19487,
                    false => 19488,
                },
                Direction.East => Lit switch {
                    true => 19489,
                    false => 19490,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19483 => new BlastFurnaceBlock(Identifier, Direction.North, true),
            19484 => new BlastFurnaceBlock(Identifier, Direction.North, false),
            19485 => new BlastFurnaceBlock(Identifier, Direction.South, true),
            19486 => new BlastFurnaceBlock(Identifier, Direction.South, false),
            19487 => new BlastFurnaceBlock(Identifier, Direction.West, true),
            19488 => new BlastFurnaceBlock(Identifier, Direction.West, false),
            19489 => new BlastFurnaceBlock(Identifier, Direction.East, true),
            19490 => new BlastFurnaceBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Lit = properties["lit"].GetString() == "true",
        };
    }
    
}
