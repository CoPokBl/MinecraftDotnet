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
                    true => 20742,
                    false => 20743,
                },
                Cardinal.East => Open switch {
                    true => 20744,
                    false => 20745,
                },
                Cardinal.South => Open switch {
                    true => 20746,
                    false => 20747,
                },
                Cardinal.West => Open switch {
                    true => 20748,
                    false => 20749,
                },
                Cardinal.Up => Open switch {
                    true => 20750,
                    false => 20751,
                },
                Cardinal.Down => Open switch {
                    true => 20752,
                    false => 20753,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20742 => new BarrelBlock(Identifier, Cardinal.North, true),
            20743 => new BarrelBlock(Identifier, Cardinal.North, false),
            20744 => new BarrelBlock(Identifier, Cardinal.East, true),
            20745 => new BarrelBlock(Identifier, Cardinal.East, false),
            20746 => new BarrelBlock(Identifier, Cardinal.South, true),
            20747 => new BarrelBlock(Identifier, Cardinal.South, false),
            20748 => new BarrelBlock(Identifier, Cardinal.West, true),
            20749 => new BarrelBlock(Identifier, Cardinal.West, false),
            20750 => new BarrelBlock(Identifier, Cardinal.Up, true),
            20751 => new BarrelBlock(Identifier, Cardinal.Up, false),
            20752 => new BarrelBlock(Identifier, Cardinal.Down, true),
            20753 => new BarrelBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("open", new StringTag(Open.ToString().ToLower()))
        );
    }
    
}
