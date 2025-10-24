using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 896;
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
    public Identifier? Item => "minecraft:warped_button";
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
    public string TranslationKey => "block.minecraft.warped_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 21288,
                        false => 21289,
                    },
                    Direction.South => Powered switch {
                        true => 21290,
                        false => 21291,
                    },
                    Direction.West => Powered switch {
                        true => 21292,
                        false => 21293,
                    },
                    Direction.East => Powered switch {
                        true => 21294,
                        false => 21295,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 21296,
                        false => 21297,
                    },
                    Direction.South => Powered switch {
                        true => 21298,
                        false => 21299,
                    },
                    Direction.West => Powered switch {
                        true => 21300,
                        false => 21301,
                    },
                    Direction.East => Powered switch {
                        true => 21302,
                        false => 21303,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 21304,
                        false => 21305,
                    },
                    Direction.South => Powered switch {
                        true => 21306,
                        false => 21307,
                    },
                    Direction.West => Powered switch {
                        true => 21308,
                        false => 21309,
                    },
                    Direction.East => Powered switch {
                        true => 21310,
                        false => 21311,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21288 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            21289 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            21290 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            21291 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            21292 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            21293 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            21294 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            21295 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            21296 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            21297 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            21298 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            21299 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            21300 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            21301 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            21302 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            21303 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            21304 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            21305 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            21306 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            21307 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            21308 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            21309 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            21310 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            21311 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
