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
    public int ProtocolId => 837;
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
                    true => 20540,
                    false => 20541,
                },
                Cardinal.East => Open switch {
                    true => 20542,
                    false => 20543,
                },
                Cardinal.South => Open switch {
                    true => 20544,
                    false => 20545,
                },
                Cardinal.West => Open switch {
                    true => 20546,
                    false => 20547,
                },
                Cardinal.Up => Open switch {
                    true => 20548,
                    false => 20549,
                },
                Cardinal.Down => Open switch {
                    true => 20550,
                    false => 20551,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20540 => new BarrelBlock(Identifier, Cardinal.North, true),
            20541 => new BarrelBlock(Identifier, Cardinal.North, false),
            20542 => new BarrelBlock(Identifier, Cardinal.East, true),
            20543 => new BarrelBlock(Identifier, Cardinal.East, false),
            20544 => new BarrelBlock(Identifier, Cardinal.South, true),
            20545 => new BarrelBlock(Identifier, Cardinal.South, false),
            20546 => new BarrelBlock(Identifier, Cardinal.West, true),
            20547 => new BarrelBlock(Identifier, Cardinal.West, false),
            20548 => new BarrelBlock(Identifier, Cardinal.Up, true),
            20549 => new BarrelBlock(Identifier, Cardinal.Up, false),
            20550 => new BarrelBlock(Identifier, Cardinal.Down, true),
            20551 => new BarrelBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Open = properties.ChildrenMap.ContainsKey("open") ? properties["open"].GetString() == "true" : Open,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("open", Open.ToString().ToLower())
        );
    }
    
}
