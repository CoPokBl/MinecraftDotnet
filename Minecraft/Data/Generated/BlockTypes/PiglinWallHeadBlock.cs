using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PiglinWallHeadBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:piglinwallskull";
    public int ProtocolId => 464;
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
    public Identifier? Item => "minecraft:piglin_head";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.25, 0.5] -> [0.8125, 0.75, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.25, 0.5] -> [0.8125, 0.75, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.25, 0.5] -> [0.8125, 0.75, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.25, 0.5] -> [0.8125, 0.75, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.piglin_head";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => 10985,
                    false => 10986,
                },
                Direction.South => Powered switch {
                    true => 10987,
                    false => 10988,
                },
                Direction.West => Powered switch {
                    true => 10989,
                    false => 10990,
                },
                Direction.East => Powered switch {
                    true => 10991,
                    false => 10992,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10985 => new PiglinWallHeadBlock(Identifier, Direction.North, true),
            10986 => new PiglinWallHeadBlock(Identifier, Direction.North, false),
            10987 => new PiglinWallHeadBlock(Identifier, Direction.South, true),
            10988 => new PiglinWallHeadBlock(Identifier, Direction.South, false),
            10989 => new PiglinWallHeadBlock(Identifier, Direction.West, true),
            10990 => new PiglinWallHeadBlock(Identifier, Direction.West, false),
            10991 => new PiglinWallHeadBlock(Identifier, Direction.East, true),
            10992 => new PiglinWallHeadBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("powered", Powered.ToString().ToLower())
        );
    }
    
}
