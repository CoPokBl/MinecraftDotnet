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
                        true => 30088,
                        false => 30089,
                    },
                    false => Waterlogged switch {
                        true => 30090,
                        false => 30091,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30092,
                        false => 30093,
                    },
                    false => Waterlogged switch {
                        true => 30094,
                        false => 30095,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30096,
                        false => 30097,
                    },
                    false => Waterlogged switch {
                        true => 30098,
                        false => 30099,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30100,
                        false => 30101,
                    },
                    false => Waterlogged switch {
                        true => 30102,
                        false => 30103,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30104,
                        false => 30105,
                    },
                    false => Waterlogged switch {
                        true => 30106,
                        false => 30107,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30108,
                        false => 30109,
                    },
                    false => Waterlogged switch {
                        true => 30110,
                        false => 30111,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30088 => new OxidizedLightningRodBlock(Identifier, Cardinal.North, true, true),
            30089 => new OxidizedLightningRodBlock(Identifier, Cardinal.North, true, false),
            30090 => new OxidizedLightningRodBlock(Identifier, Cardinal.North, false, true),
            30091 => new OxidizedLightningRodBlock(Identifier, Cardinal.North, false, false),
            30092 => new OxidizedLightningRodBlock(Identifier, Cardinal.East, true, true),
            30093 => new OxidizedLightningRodBlock(Identifier, Cardinal.East, true, false),
            30094 => new OxidizedLightningRodBlock(Identifier, Cardinal.East, false, true),
            30095 => new OxidizedLightningRodBlock(Identifier, Cardinal.East, false, false),
            30096 => new OxidizedLightningRodBlock(Identifier, Cardinal.South, true, true),
            30097 => new OxidizedLightningRodBlock(Identifier, Cardinal.South, true, false),
            30098 => new OxidizedLightningRodBlock(Identifier, Cardinal.South, false, true),
            30099 => new OxidizedLightningRodBlock(Identifier, Cardinal.South, false, false),
            30100 => new OxidizedLightningRodBlock(Identifier, Cardinal.West, true, true),
            30101 => new OxidizedLightningRodBlock(Identifier, Cardinal.West, true, false),
            30102 => new OxidizedLightningRodBlock(Identifier, Cardinal.West, false, true),
            30103 => new OxidizedLightningRodBlock(Identifier, Cardinal.West, false, false),
            30104 => new OxidizedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30105 => new OxidizedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30106 => new OxidizedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30107 => new OxidizedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30108 => new OxidizedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30109 => new OxidizedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30110 => new OxidizedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30111 => new OxidizedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
