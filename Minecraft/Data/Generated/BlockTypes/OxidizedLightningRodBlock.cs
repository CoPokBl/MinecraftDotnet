using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_lightning_rod";
    public int ProtocolId => 1098;
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
    public Identifier? Item => "minecraft:oxidized_lightning_rod";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.oxidized_lightning_rod";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 27413,
                        false => 27414,
                    },
                    false => Waterlogged switch {
                        true => 27415,
                        false => 27416,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 27417,
                        false => 27418,
                    },
                    false => Waterlogged switch {
                        true => 27419,
                        false => 27420,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 27421,
                        false => 27422,
                    },
                    false => Waterlogged switch {
                        true => 27423,
                        false => 27424,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 27425,
                        false => 27426,
                    },
                    false => Waterlogged switch {
                        true => 27427,
                        false => 27428,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 27429,
                        false => 27430,
                    },
                    false => Waterlogged switch {
                        true => 27431,
                        false => 27432,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 27433,
                        false => 27434,
                    },
                    false => Waterlogged switch {
                        true => 27435,
                        false => 27436,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27413 => new OxidizedLightningRodBlock(Identifier, Cardinal.North, true, true),
            27414 => new OxidizedLightningRodBlock(Identifier, Cardinal.North, true, false),
            27415 => new OxidizedLightningRodBlock(Identifier, Cardinal.North, false, true),
            27416 => new OxidizedLightningRodBlock(Identifier, Cardinal.North, false, false),
            27417 => new OxidizedLightningRodBlock(Identifier, Cardinal.East, true, true),
            27418 => new OxidizedLightningRodBlock(Identifier, Cardinal.East, true, false),
            27419 => new OxidizedLightningRodBlock(Identifier, Cardinal.East, false, true),
            27420 => new OxidizedLightningRodBlock(Identifier, Cardinal.East, false, false),
            27421 => new OxidizedLightningRodBlock(Identifier, Cardinal.South, true, true),
            27422 => new OxidizedLightningRodBlock(Identifier, Cardinal.South, true, false),
            27423 => new OxidizedLightningRodBlock(Identifier, Cardinal.South, false, true),
            27424 => new OxidizedLightningRodBlock(Identifier, Cardinal.South, false, false),
            27425 => new OxidizedLightningRodBlock(Identifier, Cardinal.West, true, true),
            27426 => new OxidizedLightningRodBlock(Identifier, Cardinal.West, true, false),
            27427 => new OxidizedLightningRodBlock(Identifier, Cardinal.West, false, true),
            27428 => new OxidizedLightningRodBlock(Identifier, Cardinal.West, false, false),
            27429 => new OxidizedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            27430 => new OxidizedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            27431 => new OxidizedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            27432 => new OxidizedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            27433 => new OxidizedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            27434 => new OxidizedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            27435 => new OxidizedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            27436 => new OxidizedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
