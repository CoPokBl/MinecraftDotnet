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
    public int ProtocolId => 1102;
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
                        true => 27509,
                        false => 27510,
                    },
                    false => Waterlogged switch {
                        true => 27511,
                        false => 27512,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 27513,
                        false => 27514,
                    },
                    false => Waterlogged switch {
                        true => 27515,
                        false => 27516,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 27517,
                        false => 27518,
                    },
                    false => Waterlogged switch {
                        true => 27519,
                        false => 27520,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 27521,
                        false => 27522,
                    },
                    false => Waterlogged switch {
                        true => 27523,
                        false => 27524,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 27525,
                        false => 27526,
                    },
                    false => Waterlogged switch {
                        true => 27527,
                        false => 27528,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 27529,
                        false => 27530,
                    },
                    false => Waterlogged switch {
                        true => 27531,
                        false => 27532,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27509 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.North, true, true),
            27510 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.North, true, false),
            27511 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.North, false, true),
            27512 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.North, false, false),
            27513 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.East, true, true),
            27514 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.East, true, false),
            27515 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.East, false, true),
            27516 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.East, false, false),
            27517 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.South, true, true),
            27518 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.South, true, false),
            27519 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.South, false, true),
            27520 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.South, false, false),
            27521 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.West, true, true),
            27522 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.West, true, false),
            27523 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.West, false, true),
            27524 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.West, false, false),
            27525 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            27526 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            27527 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            27528 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            27529 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            27530 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            27531 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            27532 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
