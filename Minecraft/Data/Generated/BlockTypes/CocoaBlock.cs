using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CocoaBlock(Identifier Identifier, int Age, Direction Facing) : IBlock {

    public Identifier Category => "minecraft:cocoa";
    public int ProtocolId => 365;
    public double Hardness => 0.2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cocoa_beans";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.4375, 0.0625] -> [0.625, 0.75, 0.3125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.4375, 0.0625] -> [0.625, 0.75, 0.3125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.4375, 0.0625] -> [0.625, 0.75, 0.3125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.cocoa";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => Facing switch {
                    Direction.North => 8203,
                    Direction.South => 8204,
                    Direction.West => 8205,
                    Direction.East => 8206,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                1 => Facing switch {
                    Direction.North => 8207,
                    Direction.South => 8208,
                    Direction.West => 8209,
                    Direction.East => 8210,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                2 => Facing switch {
                    Direction.North => 8211,
                    Direction.South => 8212,
                    Direction.West => 8213,
                    Direction.East => 8214,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8203 => new CocoaBlock(Identifier, 0, Direction.North),
            8204 => new CocoaBlock(Identifier, 0, Direction.South),
            8205 => new CocoaBlock(Identifier, 0, Direction.West),
            8206 => new CocoaBlock(Identifier, 0, Direction.East),
            8207 => new CocoaBlock(Identifier, 1, Direction.North),
            8208 => new CocoaBlock(Identifier, 1, Direction.South),
            8209 => new CocoaBlock(Identifier, 1, Direction.West),
            8210 => new CocoaBlock(Identifier, 1, Direction.East),
            8211 => new CocoaBlock(Identifier, 2, Direction.North),
            8212 => new CocoaBlock(Identifier, 2, Direction.South),
            8213 => new CocoaBlock(Identifier, 2, Direction.West),
            8214 => new CocoaBlock(Identifier, 2, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("age", Age.ToString()),
            new StringTag("facing", Facing.ToName())
        );
    }
    
}
