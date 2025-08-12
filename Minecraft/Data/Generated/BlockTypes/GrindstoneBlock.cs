using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrindstoneBlock(Identifier Identifier, AttachDirection Face, Direction Facing) : IBlock {
    public Identifier Category => "minecraft:grindstone";
    public int ProtocolId => 812;
    public double Hardness => 2;
    public double ExplosionResistance => 6;
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
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:grindstone";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.125, 0.0] -> [0.75, 0.875, 0.75], AABB[0.125, 0.3125, 0.1875] -> [0.25, 0.6875, 0.5625], AABB[0.75, 0.3125, 0.1875] -> [0.875, 0.6875, 0.5625], AABB[0.125, 0.375, 0.5625] -> [0.25, 0.625, 1.0], AABB[0.75, 0.375, 0.5625] -> [0.875, 0.625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.125, 0.0] -> [0.75, 0.875, 0.75], AABB[0.125, 0.3125, 0.1875] -> [0.25, 0.6875, 0.5625], AABB[0.75, 0.3125, 0.1875] -> [0.875, 0.6875, 0.5625], AABB[0.125, 0.375, 0.5625] -> [0.25, 0.625, 1.0], AABB[0.75, 0.375, 0.5625] -> [0.875, 0.625, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.125, 0.0] -> [0.75, 0.875, 0.75], AABB[0.125, 0.3125, 0.1875] -> [0.25, 0.6875, 0.5625], AABB[0.75, 0.3125, 0.1875] -> [0.875, 0.6875, 0.5625], AABB[0.125, 0.375, 0.5625] -> [0.25, 0.625, 1.0], AABB[0.75, 0.375, 0.5625] -> [0.875, 0.625, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.125, 0.0] -> [0.75, 0.875, 0.75], AABB[0.125, 0.3125, 0.1875] -> [0.25, 0.6875, 0.5625], AABB[0.75, 0.3125, 0.1875] -> [0.875, 0.6875, 0.5625], AABB[0.125, 0.375, 0.5625] -> [0.25, 0.625, 1.0], AABB[0.75, 0.375, 0.5625] -> [0.875, 0.625, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Block;
    public int MapColorId => 6;
    public string TranslationKey => "block.minecraft.grindstone";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => 19493,
                    Direction.South => 19494,
                    Direction.West => 19495,
                    Direction.East => 19496,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => 19497,
                    Direction.South => 19498,
                    Direction.West => 19499,
                    Direction.East => 19500,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => 19501,
                    Direction.South => 19502,
                    Direction.West => 19503,
                    Direction.East => 19504,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19493 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.North),
            19494 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.South),
            19495 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.West),
            19496 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.East),
            19497 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.North),
            19498 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.South),
            19499 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.West),
            19500 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.East),
            19501 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.North),
            19502 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.South),
            19503 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.West),
            19504 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Face = properties.ChildrenMap.ContainsKey("face") ? AttachDirectionExtensions.FromString(properties["face"].GetString()) : Face,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("face", Face.ToName()),
            new StringTag("facing", Facing.ToName())
        );
    }
    
}
