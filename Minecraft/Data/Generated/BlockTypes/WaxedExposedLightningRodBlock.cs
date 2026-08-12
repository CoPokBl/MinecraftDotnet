using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:waxed_exposed_lightning_rod";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.waxed_exposed_lightning_rod";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 30136,
                        false => 30137,
                    },
                    false => Waterlogged switch {
                        true => 30138,
                        false => 30139,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30140,
                        false => 30141,
                    },
                    false => Waterlogged switch {
                        true => 30142,
                        false => 30143,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30144,
                        false => 30145,
                    },
                    false => Waterlogged switch {
                        true => 30146,
                        false => 30147,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30148,
                        false => 30149,
                    },
                    false => Waterlogged switch {
                        true => 30150,
                        false => 30151,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30152,
                        false => 30153,
                    },
                    false => Waterlogged switch {
                        true => 30154,
                        false => 30155,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30156,
                        false => 30157,
                    },
                    false => Waterlogged switch {
                        true => 30158,
                        false => 30159,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30136 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, true, true),
            30137 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, true, false),
            30138 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, false, true),
            30139 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, false, false),
            30140 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, true, true),
            30141 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, true, false),
            30142 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, false, true),
            30143 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, false, false),
            30144 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, true, true),
            30145 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, true, false),
            30146 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, false, true),
            30147 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, false, false),
            30148 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, true, true),
            30149 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, true, false),
            30150 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, false, true),
            30151 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, false, false),
            30152 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30153 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30154 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30155 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30156 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30157 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30158 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30159 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
