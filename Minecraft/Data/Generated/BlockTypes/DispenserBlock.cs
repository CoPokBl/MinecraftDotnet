using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DispenserBlock(Identifier Identifier, Cardinal Facing, bool Triggered) : IBlock {

    public Identifier Category => "minecraft:dispenser";
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
    public Identifier? BlockEntity => "minecraft:dispenser";
    public Identifier? Item => "minecraft:dispenser";
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
    public string TranslationKey => "block.minecraft.dispenser";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Triggered switch {
                    true => 566,
                    false => 567,
                },
                Cardinal.East => Triggered switch {
                    true => 568,
                    false => 569,
                },
                Cardinal.South => Triggered switch {
                    true => 570,
                    false => 571,
                },
                Cardinal.West => Triggered switch {
                    true => 572,
                    false => 573,
                },
                Cardinal.Up => Triggered switch {
                    true => 574,
                    false => 575,
                },
                Cardinal.Down => Triggered switch {
                    true => 576,
                    false => 577,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            566 => new DispenserBlock(Identifier, Cardinal.North, true),
            567 => new DispenserBlock(Identifier, Cardinal.North, false),
            568 => new DispenserBlock(Identifier, Cardinal.East, true),
            569 => new DispenserBlock(Identifier, Cardinal.East, false),
            570 => new DispenserBlock(Identifier, Cardinal.South, true),
            571 => new DispenserBlock(Identifier, Cardinal.South, false),
            572 => new DispenserBlock(Identifier, Cardinal.West, true),
            573 => new DispenserBlock(Identifier, Cardinal.West, false),
            574 => new DispenserBlock(Identifier, Cardinal.Up, true),
            575 => new DispenserBlock(Identifier, Cardinal.Up, false),
            576 => new DispenserBlock(Identifier, Cardinal.Down, true),
            577 => new DispenserBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
            Triggered = properties["triggered"].GetString() == "true",
        };
    }
    
}
