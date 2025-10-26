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
    public int ProtocolId => 842;
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
                    Direction.North => 20570,
                    Direction.South => 20571,
                    Direction.West => 20572,
                    Direction.East => 20573,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => 20574,
                    Direction.South => 20575,
                    Direction.West => 20576,
                    Direction.East => 20577,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => 20578,
                    Direction.South => 20579,
                    Direction.West => 20580,
                    Direction.East => 20581,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20570 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.North),
            20571 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.South),
            20572 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.West),
            20573 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.East),
            20574 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.North),
            20575 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.South),
            20576 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.West),
            20577 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.East),
            20578 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.North),
            20579 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.South),
            20580 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.West),
            20581 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.East),
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
