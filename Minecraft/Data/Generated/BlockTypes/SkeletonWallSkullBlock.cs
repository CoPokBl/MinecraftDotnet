using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SkeletonWallSkullBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:wall_skull";
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => "minecraft:skull";
    public Identifier? Item => "minecraft:skeleton_skull";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.25, 0.5] -> [0.75, 0.75, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.25, 0.5] -> [0.75, 0.75, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.25, 0.5] -> [0.75, 0.75, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.25, 0.5] -> [0.75, 0.75, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.skeleton_skull";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => 10947,
                    false => 10948,
                },
                Direction.South => Powered switch {
                    true => 10949,
                    false => 10950,
                },
                Direction.West => Powered switch {
                    true => 10951,
                    false => 10952,
                },
                Direction.East => Powered switch {
                    true => 10953,
                    false => 10954,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10947 => new SkeletonWallSkullBlock(Identifier, Direction.North, true),
            10948 => new SkeletonWallSkullBlock(Identifier, Direction.North, false),
            10949 => new SkeletonWallSkullBlock(Identifier, Direction.South, true),
            10950 => new SkeletonWallSkullBlock(Identifier, Direction.South, false),
            10951 => new SkeletonWallSkullBlock(Identifier, Direction.West, true),
            10952 => new SkeletonWallSkullBlock(Identifier, Direction.West, false),
            10953 => new SkeletonWallSkullBlock(Identifier, Direction.East, true),
            10954 => new SkeletonWallSkullBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
