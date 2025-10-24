using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 445;
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
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:acacia_button";
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
    public string TranslationKey => "block.minecraft.acacia_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10569,
                        false => 10570,
                    },
                    Direction.South => Powered switch {
                        true => 10571,
                        false => 10572,
                    },
                    Direction.West => Powered switch {
                        true => 10573,
                        false => 10574,
                    },
                    Direction.East => Powered switch {
                        true => 10575,
                        false => 10576,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10577,
                        false => 10578,
                    },
                    Direction.South => Powered switch {
                        true => 10579,
                        false => 10580,
                    },
                    Direction.West => Powered switch {
                        true => 10581,
                        false => 10582,
                    },
                    Direction.East => Powered switch {
                        true => 10583,
                        false => 10584,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10585,
                        false => 10586,
                    },
                    Direction.South => Powered switch {
                        true => 10587,
                        false => 10588,
                    },
                    Direction.West => Powered switch {
                        true => 10589,
                        false => 10590,
                    },
                    Direction.East => Powered switch {
                        true => 10591,
                        false => 10592,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10569 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10570 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10571 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10572 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10573 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10574 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10575 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10576 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10577 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10578 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10579 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10580 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10581 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10582 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10583 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10584 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10585 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10586 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10587 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10588 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10589 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10590 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10591 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10592 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
