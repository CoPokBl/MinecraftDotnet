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
                        true => 30112,
                        false => 30113,
                    },
                    false => Waterlogged switch {
                        true => 30114,
                        false => 30115,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30116,
                        false => 30117,
                    },
                    false => Waterlogged switch {
                        true => 30118,
                        false => 30119,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30120,
                        false => 30121,
                    },
                    false => Waterlogged switch {
                        true => 30122,
                        false => 30123,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30124,
                        false => 30125,
                    },
                    false => Waterlogged switch {
                        true => 30126,
                        false => 30127,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30128,
                        false => 30129,
                    },
                    false => Waterlogged switch {
                        true => 30130,
                        false => 30131,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30132,
                        false => 30133,
                    },
                    false => Waterlogged switch {
                        true => 30134,
                        false => 30135,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30112 => new WaxedLightningRodBlock(Identifier, Cardinal.North, true, true),
            30113 => new WaxedLightningRodBlock(Identifier, Cardinal.North, true, false),
            30114 => new WaxedLightningRodBlock(Identifier, Cardinal.North, false, true),
            30115 => new WaxedLightningRodBlock(Identifier, Cardinal.North, false, false),
            30116 => new WaxedLightningRodBlock(Identifier, Cardinal.East, true, true),
            30117 => new WaxedLightningRodBlock(Identifier, Cardinal.East, true, false),
            30118 => new WaxedLightningRodBlock(Identifier, Cardinal.East, false, true),
            30119 => new WaxedLightningRodBlock(Identifier, Cardinal.East, false, false),
            30120 => new WaxedLightningRodBlock(Identifier, Cardinal.South, true, true),
            30121 => new WaxedLightningRodBlock(Identifier, Cardinal.South, true, false),
            30122 => new WaxedLightningRodBlock(Identifier, Cardinal.South, false, true),
            30123 => new WaxedLightningRodBlock(Identifier, Cardinal.South, false, false),
            30124 => new WaxedLightningRodBlock(Identifier, Cardinal.West, true, true),
            30125 => new WaxedLightningRodBlock(Identifier, Cardinal.West, true, false),
            30126 => new WaxedLightningRodBlock(Identifier, Cardinal.West, false, true),
            30127 => new WaxedLightningRodBlock(Identifier, Cardinal.West, false, false),
            30128 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30129 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30130 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30131 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30132 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30133 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30134 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30135 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
