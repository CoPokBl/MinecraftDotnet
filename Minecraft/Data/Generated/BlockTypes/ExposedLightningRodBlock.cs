using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_lightning_rod";
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
    public Identifier? Item => "minecraft:exposed_lightning_rod";
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
    public string TranslationKey => "block.minecraft.exposed_lightning_rod";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 30040,
                        false => 30041,
                    },
                    false => Waterlogged switch {
                        true => 30042,
                        false => 30043,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30044,
                        false => 30045,
                    },
                    false => Waterlogged switch {
                        true => 30046,
                        false => 30047,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30048,
                        false => 30049,
                    },
                    false => Waterlogged switch {
                        true => 30050,
                        false => 30051,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30052,
                        false => 30053,
                    },
                    false => Waterlogged switch {
                        true => 30054,
                        false => 30055,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30056,
                        false => 30057,
                    },
                    false => Waterlogged switch {
                        true => 30058,
                        false => 30059,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30060,
                        false => 30061,
                    },
                    false => Waterlogged switch {
                        true => 30062,
                        false => 30063,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30040 => new ExposedLightningRodBlock(Identifier, Cardinal.North, true, true),
            30041 => new ExposedLightningRodBlock(Identifier, Cardinal.North, true, false),
            30042 => new ExposedLightningRodBlock(Identifier, Cardinal.North, false, true),
            30043 => new ExposedLightningRodBlock(Identifier, Cardinal.North, false, false),
            30044 => new ExposedLightningRodBlock(Identifier, Cardinal.East, true, true),
            30045 => new ExposedLightningRodBlock(Identifier, Cardinal.East, true, false),
            30046 => new ExposedLightningRodBlock(Identifier, Cardinal.East, false, true),
            30047 => new ExposedLightningRodBlock(Identifier, Cardinal.East, false, false),
            30048 => new ExposedLightningRodBlock(Identifier, Cardinal.South, true, true),
            30049 => new ExposedLightningRodBlock(Identifier, Cardinal.South, true, false),
            30050 => new ExposedLightningRodBlock(Identifier, Cardinal.South, false, true),
            30051 => new ExposedLightningRodBlock(Identifier, Cardinal.South, false, false),
            30052 => new ExposedLightningRodBlock(Identifier, Cardinal.West, true, true),
            30053 => new ExposedLightningRodBlock(Identifier, Cardinal.West, true, false),
            30054 => new ExposedLightningRodBlock(Identifier, Cardinal.West, false, true),
            30055 => new ExposedLightningRodBlock(Identifier, Cardinal.West, false, false),
            30056 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30057 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30058 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30059 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30060 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30061 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30062 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30063 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
