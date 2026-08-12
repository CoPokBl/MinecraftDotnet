using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:waxed_oxidized_lightning_rod";
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
    public string TranslationKey => "block.minecraft.waxed_oxidized_lightning_rod";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 30184,
                        false => 30185,
                    },
                    false => Waterlogged switch {
                        true => 30186,
                        false => 30187,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30188,
                        false => 30189,
                    },
                    false => Waterlogged switch {
                        true => 30190,
                        false => 30191,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30192,
                        false => 30193,
                    },
                    false => Waterlogged switch {
                        true => 30194,
                        false => 30195,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30196,
                        false => 30197,
                    },
                    false => Waterlogged switch {
                        true => 30198,
                        false => 30199,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30200,
                        false => 30201,
                    },
                    false => Waterlogged switch {
                        true => 30202,
                        false => 30203,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30204,
                        false => 30205,
                    },
                    false => Waterlogged switch {
                        true => 30206,
                        false => 30207,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30184 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.North, true, true),
            30185 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.North, true, false),
            30186 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.North, false, true),
            30187 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.North, false, false),
            30188 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.East, true, true),
            30189 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.East, true, false),
            30190 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.East, false, true),
            30191 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.East, false, false),
            30192 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.South, true, true),
            30193 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.South, true, false),
            30194 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.South, false, true),
            30195 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.South, false, false),
            30196 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.West, true, true),
            30197 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.West, true, false),
            30198 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.West, false, true),
            30199 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.West, false, false),
            30200 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30201 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30202 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30203 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30204 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30205 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30206 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30207 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
