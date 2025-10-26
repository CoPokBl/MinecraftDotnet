using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {
    public Identifier Category => "minecraft:button";
    public int ProtocolId => 450;
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
    public string SoundType => "bamboo_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:bamboo_button";
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
    public string TranslationKey => "block.minecraft.bamboo_button";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10689,
                        false => 10690,
                    },
                    Direction.South => Powered switch {
                        true => 10691,
                        false => 10692,
                    },
                    Direction.West => Powered switch {
                        true => 10693,
                        false => 10694,
                    },
                    Direction.East => Powered switch {
                        true => 10695,
                        false => 10696,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10697,
                        false => 10698,
                    },
                    Direction.South => Powered switch {
                        true => 10699,
                        false => 10700,
                    },
                    Direction.West => Powered switch {
                        true => 10701,
                        false => 10702,
                    },
                    Direction.East => Powered switch {
                        true => 10703,
                        false => 10704,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10705,
                        false => 10706,
                    },
                    Direction.South => Powered switch {
                        true => 10707,
                        false => 10708,
                    },
                    Direction.West => Powered switch {
                        true => 10709,
                        false => 10710,
                    },
                    Direction.East => Powered switch {
                        true => 10711,
                        false => 10712,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10689 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10690 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10691 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10692 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10693 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10694 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10695 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10696 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10697 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10698 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10699 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10700 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10701 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10702 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10703 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10704 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10705 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10706 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10707 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10708 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10709 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10710 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10711 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10712 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
