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
    public int ProtocolId => 1097;
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
                        true => 27389,
                        false => 27390,
                    },
                    false => Waterlogged switch {
                        true => 27391,
                        false => 27392,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 27393,
                        false => 27394,
                    },
                    false => Waterlogged switch {
                        true => 27395,
                        false => 27396,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 27397,
                        false => 27398,
                    },
                    false => Waterlogged switch {
                        true => 27399,
                        false => 27400,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 27401,
                        false => 27402,
                    },
                    false => Waterlogged switch {
                        true => 27403,
                        false => 27404,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 27405,
                        false => 27406,
                    },
                    false => Waterlogged switch {
                        true => 27407,
                        false => 27408,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 27409,
                        false => 27410,
                    },
                    false => Waterlogged switch {
                        true => 27411,
                        false => 27412,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27389 => new WeatheredLightningRodBlock(Identifier, Cardinal.North, true, true),
            27390 => new WeatheredLightningRodBlock(Identifier, Cardinal.North, true, false),
            27391 => new WeatheredLightningRodBlock(Identifier, Cardinal.North, false, true),
            27392 => new WeatheredLightningRodBlock(Identifier, Cardinal.North, false, false),
            27393 => new WeatheredLightningRodBlock(Identifier, Cardinal.East, true, true),
            27394 => new WeatheredLightningRodBlock(Identifier, Cardinal.East, true, false),
            27395 => new WeatheredLightningRodBlock(Identifier, Cardinal.East, false, true),
            27396 => new WeatheredLightningRodBlock(Identifier, Cardinal.East, false, false),
            27397 => new WeatheredLightningRodBlock(Identifier, Cardinal.South, true, true),
            27398 => new WeatheredLightningRodBlock(Identifier, Cardinal.South, true, false),
            27399 => new WeatheredLightningRodBlock(Identifier, Cardinal.South, false, true),
            27400 => new WeatheredLightningRodBlock(Identifier, Cardinal.South, false, false),
            27401 => new WeatheredLightningRodBlock(Identifier, Cardinal.West, true, true),
            27402 => new WeatheredLightningRodBlock(Identifier, Cardinal.West, true, false),
            27403 => new WeatheredLightningRodBlock(Identifier, Cardinal.West, false, true),
            27404 => new WeatheredLightningRodBlock(Identifier, Cardinal.West, false, false),
            27405 => new WeatheredLightningRodBlock(Identifier, Cardinal.Up, true, true),
            27406 => new WeatheredLightningRodBlock(Identifier, Cardinal.Up, true, false),
            27407 => new WeatheredLightningRodBlock(Identifier, Cardinal.Up, false, true),
            27408 => new WeatheredLightningRodBlock(Identifier, Cardinal.Up, false, false),
            27409 => new WeatheredLightningRodBlock(Identifier, Cardinal.Down, true, true),
            27410 => new WeatheredLightningRodBlock(Identifier, Cardinal.Down, true, false),
            27411 => new WeatheredLightningRodBlock(Identifier, Cardinal.Down, false, true),
            27412 => new WeatheredLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
