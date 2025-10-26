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
    public int ProtocolId => 1100;
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
                        true => 27461,
                        false => 27462,
                    },
                    false => Waterlogged switch {
                        true => 27463,
                        false => 27464,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 27465,
                        false => 27466,
                    },
                    false => Waterlogged switch {
                        true => 27467,
                        false => 27468,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 27469,
                        false => 27470,
                    },
                    false => Waterlogged switch {
                        true => 27471,
                        false => 27472,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 27473,
                        false => 27474,
                    },
                    false => Waterlogged switch {
                        true => 27475,
                        false => 27476,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 27477,
                        false => 27478,
                    },
                    false => Waterlogged switch {
                        true => 27479,
                        false => 27480,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 27481,
                        false => 27482,
                    },
                    false => Waterlogged switch {
                        true => 27483,
                        false => 27484,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27461 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, true, true),
            27462 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, true, false),
            27463 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, false, true),
            27464 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, false, false),
            27465 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, true, true),
            27466 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, true, false),
            27467 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, false, true),
            27468 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, false, false),
            27469 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, true, true),
            27470 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, true, false),
            27471 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, false, true),
            27472 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, false, false),
            27473 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, true, true),
            27474 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, true, false),
            27475 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, false, true),
            27476 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, false, false),
            27477 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            27478 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            27479 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            27480 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            27481 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            27482 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            27483 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            27484 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
