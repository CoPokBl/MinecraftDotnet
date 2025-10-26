using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:lightning_rod";
    public int ProtocolId => 1099;
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:waxed_lightning_rod";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.waxed_lightning_rod";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 27437,
                        false => 27438,
                    },
                    false => Waterlogged switch {
                        true => 27439,
                        false => 27440,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 27441,
                        false => 27442,
                    },
                    false => Waterlogged switch {
                        true => 27443,
                        false => 27444,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 27445,
                        false => 27446,
                    },
                    false => Waterlogged switch {
                        true => 27447,
                        false => 27448,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 27449,
                        false => 27450,
                    },
                    false => Waterlogged switch {
                        true => 27451,
                        false => 27452,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 27453,
                        false => 27454,
                    },
                    false => Waterlogged switch {
                        true => 27455,
                        false => 27456,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 27457,
                        false => 27458,
                    },
                    false => Waterlogged switch {
                        true => 27459,
                        false => 27460,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27437 => new WaxedLightningRodBlock(Identifier, Cardinal.North, true, true),
            27438 => new WaxedLightningRodBlock(Identifier, Cardinal.North, true, false),
            27439 => new WaxedLightningRodBlock(Identifier, Cardinal.North, false, true),
            27440 => new WaxedLightningRodBlock(Identifier, Cardinal.North, false, false),
            27441 => new WaxedLightningRodBlock(Identifier, Cardinal.East, true, true),
            27442 => new WaxedLightningRodBlock(Identifier, Cardinal.East, true, false),
            27443 => new WaxedLightningRodBlock(Identifier, Cardinal.East, false, true),
            27444 => new WaxedLightningRodBlock(Identifier, Cardinal.East, false, false),
            27445 => new WaxedLightningRodBlock(Identifier, Cardinal.South, true, true),
            27446 => new WaxedLightningRodBlock(Identifier, Cardinal.South, true, false),
            27447 => new WaxedLightningRodBlock(Identifier, Cardinal.South, false, true),
            27448 => new WaxedLightningRodBlock(Identifier, Cardinal.South, false, false),
            27449 => new WaxedLightningRodBlock(Identifier, Cardinal.West, true, true),
            27450 => new WaxedLightningRodBlock(Identifier, Cardinal.West, true, false),
            27451 => new WaxedLightningRodBlock(Identifier, Cardinal.West, false, true),
            27452 => new WaxedLightningRodBlock(Identifier, Cardinal.West, false, false),
            27453 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            27454 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            27455 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            27456 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            27457 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            27458 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            27459 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            27460 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
