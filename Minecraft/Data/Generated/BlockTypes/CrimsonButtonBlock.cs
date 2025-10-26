using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 895;
    public double Hardness => 0.5;
    public double ExplosionResistance => 0.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:crimson_button";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, 0.375, 0.875] -> [0.6875, 0.625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.crimson_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 21264,
                        false => 21265,
                    },
                    Direction.South => Powered switch {
                        true => 21266,
                        false => 21267,
                    },
                    Direction.West => Powered switch {
                        true => 21268,
                        false => 21269,
                    },
                    Direction.East => Powered switch {
                        true => 21270,
                        false => 21271,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 21272,
                        false => 21273,
                    },
                    Direction.South => Powered switch {
                        true => 21274,
                        false => 21275,
                    },
                    Direction.West => Powered switch {
                        true => 21276,
                        false => 21277,
                    },
                    Direction.East => Powered switch {
                        true => 21278,
                        false => 21279,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 21280,
                        false => 21281,
                    },
                    Direction.South => Powered switch {
                        true => 21282,
                        false => 21283,
                    },
                    Direction.West => Powered switch {
                        true => 21284,
                        false => 21285,
                    },
                    Direction.East => Powered switch {
                        true => 21286,
                        false => 21287,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21264 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            21265 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            21266 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            21267 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            21268 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            21269 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            21270 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            21271 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            21272 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            21273 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            21274 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            21275 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            21276 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            21277 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            21278 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            21279 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            21280 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            21281 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            21282 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            21283 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            21284 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            21285 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            21286 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            21287 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Face = properties.ChildrenMap.ContainsKey("face") ? AttachDirectionExtensions.FromString(properties["face"].GetString()) : Face,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("face", Face.ToName()),
            new StringTag("facing", Facing.ToName()),
            new StringTag("powered", Powered.ToString().ToLower())
        );
    }
    
}
