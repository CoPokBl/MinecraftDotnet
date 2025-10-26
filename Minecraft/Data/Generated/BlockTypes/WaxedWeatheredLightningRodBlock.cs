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
    public int ProtocolId => 1101;
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
                        true => 27485,
                        false => 27486,
                    },
                    false => Waterlogged switch {
                        true => 27487,
                        false => 27488,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 27489,
                        false => 27490,
                    },
                    false => Waterlogged switch {
                        true => 27491,
                        false => 27492,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 27493,
                        false => 27494,
                    },
                    false => Waterlogged switch {
                        true => 27495,
                        false => 27496,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 27497,
                        false => 27498,
                    },
                    false => Waterlogged switch {
                        true => 27499,
                        false => 27500,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 27501,
                        false => 27502,
                    },
                    false => Waterlogged switch {
                        true => 27503,
                        false => 27504,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 27505,
                        false => 27506,
                    },
                    false => Waterlogged switch {
                        true => 27507,
                        false => 27508,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27485 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.North, true, true),
            27486 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.North, true, false),
            27487 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.North, false, true),
            27488 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.North, false, false),
            27489 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.East, true, true),
            27490 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.East, true, false),
            27491 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.East, false, true),
            27492 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.East, false, false),
            27493 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.South, true, true),
            27494 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.South, true, false),
            27495 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.South, false, true),
            27496 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.South, false, false),
            27497 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.West, true, true),
            27498 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.West, true, false),
            27499 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.West, false, true),
            27500 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.West, false, false),
            27501 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Up, true, true),
            27502 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Up, true, false),
            27503 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Up, false, true),
            27504 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Up, false, false),
            27505 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Down, true, true),
            27506 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Down, true, false),
            27507 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Down, false, true),
            27508 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
