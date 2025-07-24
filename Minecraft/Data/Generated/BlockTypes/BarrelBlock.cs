using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BarrelBlock(Identifier Identifier, Cardinal Facing, bool Open) : IBlock {

    public Identifier Category => "minecraft:barrel";
    public int ProtocolId => 807;
    public double Hardness => 2.5;
    public double ExplosionResistance => 2.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:barrel";
    public Identifier? Item => "minecraft:barrel";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.barrel";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Open switch {
                    true => 19463,
                    false => 19464,
                },
                Cardinal.East => Open switch {
                    true => 19465,
                    false => 19466,
                },
                Cardinal.South => Open switch {
                    true => 19467,
                    false => 19468,
                },
                Cardinal.West => Open switch {
                    true => 19469,
                    false => 19470,
                },
                Cardinal.Up => Open switch {
                    true => 19471,
                    false => 19472,
                },
                Cardinal.Down => Open switch {
                    true => 19473,
                    false => 19474,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19463 => new BarrelBlock(Identifier, Cardinal.North, true),
            19464 => new BarrelBlock(Identifier, Cardinal.North, false),
            19465 => new BarrelBlock(Identifier, Cardinal.East, true),
            19466 => new BarrelBlock(Identifier, Cardinal.East, false),
            19467 => new BarrelBlock(Identifier, Cardinal.South, true),
            19468 => new BarrelBlock(Identifier, Cardinal.South, false),
            19469 => new BarrelBlock(Identifier, Cardinal.West, true),
            19470 => new BarrelBlock(Identifier, Cardinal.West, false),
            19471 => new BarrelBlock(Identifier, Cardinal.Up, true),
            19472 => new BarrelBlock(Identifier, Cardinal.Up, false),
            19473 => new BarrelBlock(Identifier, Cardinal.Down, true),
            19474 => new BarrelBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
            Open = properties["open"].GetString() == "true",
        };
    }
    
}
