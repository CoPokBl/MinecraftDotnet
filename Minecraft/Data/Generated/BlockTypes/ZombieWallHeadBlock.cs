using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ZombieWallHeadBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock {

    public Identifier Category => "minecraft:wall_skull";
    public int ProtocolId => 426;
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
    public Identifier? Item => "minecraft:zombie_head";
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
    public string TranslationKey => "block.minecraft.zombie_head";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => 9748,
                    false => 9749,
                },
                Direction.South => Powered switch {
                    true => 9750,
                    false => 9751,
                },
                Direction.West => Powered switch {
                    true => 9752,
                    false => 9753,
                },
                Direction.East => Powered switch {
                    true => 9754,
                    false => 9755,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9748 => new ZombieWallHeadBlock(Identifier, Direction.North, true),
            9749 => new ZombieWallHeadBlock(Identifier, Direction.North, false),
            9750 => new ZombieWallHeadBlock(Identifier, Direction.South, true),
            9751 => new ZombieWallHeadBlock(Identifier, Direction.South, false),
            9752 => new ZombieWallHeadBlock(Identifier, Direction.West, true),
            9753 => new ZombieWallHeadBlock(Identifier, Direction.West, false),
            9754 => new ZombieWallHeadBlock(Identifier, Direction.East, true),
            9755 => new ZombieWallHeadBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("powered", Powered.ToString().ToLower())
        );
    }
    
}
