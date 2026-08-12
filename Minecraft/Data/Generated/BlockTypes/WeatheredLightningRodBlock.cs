using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:weathered_lightning_rod";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.weathered_lightning_rod";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 30064,
                        false => 30065,
                    },
                    false => Waterlogged switch {
                        true => 30066,
                        false => 30067,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30068,
                        false => 30069,
                    },
                    false => Waterlogged switch {
                        true => 30070,
                        false => 30071,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30072,
                        false => 30073,
                    },
                    false => Waterlogged switch {
                        true => 30074,
                        false => 30075,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30076,
                        false => 30077,
                    },
                    false => Waterlogged switch {
                        true => 30078,
                        false => 30079,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30080,
                        false => 30081,
                    },
                    false => Waterlogged switch {
                        true => 30082,
                        false => 30083,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30084,
                        false => 30085,
                    },
                    false => Waterlogged switch {
                        true => 30086,
                        false => 30087,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30064 => new WeatheredLightningRodBlock(Identifier, Cardinal.North, true, true),
            30065 => new WeatheredLightningRodBlock(Identifier, Cardinal.North, true, false),
            30066 => new WeatheredLightningRodBlock(Identifier, Cardinal.North, false, true),
            30067 => new WeatheredLightningRodBlock(Identifier, Cardinal.North, false, false),
            30068 => new WeatheredLightningRodBlock(Identifier, Cardinal.East, true, true),
            30069 => new WeatheredLightningRodBlock(Identifier, Cardinal.East, true, false),
            30070 => new WeatheredLightningRodBlock(Identifier, Cardinal.East, false, true),
            30071 => new WeatheredLightningRodBlock(Identifier, Cardinal.East, false, false),
            30072 => new WeatheredLightningRodBlock(Identifier, Cardinal.South, true, true),
            30073 => new WeatheredLightningRodBlock(Identifier, Cardinal.South, true, false),
            30074 => new WeatheredLightningRodBlock(Identifier, Cardinal.South, false, true),
            30075 => new WeatheredLightningRodBlock(Identifier, Cardinal.South, false, false),
            30076 => new WeatheredLightningRodBlock(Identifier, Cardinal.West, true, true),
            30077 => new WeatheredLightningRodBlock(Identifier, Cardinal.West, true, false),
            30078 => new WeatheredLightningRodBlock(Identifier, Cardinal.West, false, true),
            30079 => new WeatheredLightningRodBlock(Identifier, Cardinal.West, false, false),
            30080 => new WeatheredLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30081 => new WeatheredLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30082 => new WeatheredLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30083 => new WeatheredLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30084 => new WeatheredLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30085 => new WeatheredLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30086 => new WeatheredLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30087 => new WeatheredLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
