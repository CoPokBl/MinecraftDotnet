using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:waxed_weathered_lightning_rod";
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
    public string TranslationKey => "block.minecraft.waxed_weathered_lightning_rod";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 30160,
                        false => 30161,
                    },
                    false => Waterlogged switch {
                        true => 30162,
                        false => 30163,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30164,
                        false => 30165,
                    },
                    false => Waterlogged switch {
                        true => 30166,
                        false => 30167,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30168,
                        false => 30169,
                    },
                    false => Waterlogged switch {
                        true => 30170,
                        false => 30171,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30172,
                        false => 30173,
                    },
                    false => Waterlogged switch {
                        true => 30174,
                        false => 30175,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30176,
                        false => 30177,
                    },
                    false => Waterlogged switch {
                        true => 30178,
                        false => 30179,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30180,
                        false => 30181,
                    },
                    false => Waterlogged switch {
                        true => 30182,
                        false => 30183,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30160 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.North, true, true),
            30161 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.North, true, false),
            30162 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.North, false, true),
            30163 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.North, false, false),
            30164 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.East, true, true),
            30165 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.East, true, false),
            30166 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.East, false, true),
            30167 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.East, false, false),
            30168 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.South, true, true),
            30169 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.South, true, false),
            30170 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.South, false, true),
            30171 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.South, false, false),
            30172 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.West, true, true),
            30173 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.West, true, false),
            30174 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.West, false, true),
            30175 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.West, false, false),
            30176 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30177 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30178 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30179 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30180 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30181 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30182 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30183 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
