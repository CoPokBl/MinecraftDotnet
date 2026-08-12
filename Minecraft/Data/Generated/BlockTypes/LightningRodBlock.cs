using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:lightning_rod";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.lightning_rod";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 30016,
                        false => 30017,
                    },
                    false => Waterlogged switch {
                        true => 30018,
                        false => 30019,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30020,
                        false => 30021,
                    },
                    false => Waterlogged switch {
                        true => 30022,
                        false => 30023,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30024,
                        false => 30025,
                    },
                    false => Waterlogged switch {
                        true => 30026,
                        false => 30027,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30028,
                        false => 30029,
                    },
                    false => Waterlogged switch {
                        true => 30030,
                        false => 30031,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30032,
                        false => 30033,
                    },
                    false => Waterlogged switch {
                        true => 30034,
                        false => 30035,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30036,
                        false => 30037,
                    },
                    false => Waterlogged switch {
                        true => 30038,
                        false => 30039,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30016 => new LightningRodBlock(Identifier, Cardinal.North, true, true),
            30017 => new LightningRodBlock(Identifier, Cardinal.North, true, false),
            30018 => new LightningRodBlock(Identifier, Cardinal.North, false, true),
            30019 => new LightningRodBlock(Identifier, Cardinal.North, false, false),
            30020 => new LightningRodBlock(Identifier, Cardinal.East, true, true),
            30021 => new LightningRodBlock(Identifier, Cardinal.East, true, false),
            30022 => new LightningRodBlock(Identifier, Cardinal.East, false, true),
            30023 => new LightningRodBlock(Identifier, Cardinal.East, false, false),
            30024 => new LightningRodBlock(Identifier, Cardinal.South, true, true),
            30025 => new LightningRodBlock(Identifier, Cardinal.South, true, false),
            30026 => new LightningRodBlock(Identifier, Cardinal.South, false, true),
            30027 => new LightningRodBlock(Identifier, Cardinal.South, false, false),
            30028 => new LightningRodBlock(Identifier, Cardinal.West, true, true),
            30029 => new LightningRodBlock(Identifier, Cardinal.West, true, false),
            30030 => new LightningRodBlock(Identifier, Cardinal.West, false, true),
            30031 => new LightningRodBlock(Identifier, Cardinal.West, false, false),
            30032 => new LightningRodBlock(Identifier, Cardinal.Up, true, true),
            30033 => new LightningRodBlock(Identifier, Cardinal.Up, true, false),
            30034 => new LightningRodBlock(Identifier, Cardinal.Up, false, true),
            30035 => new LightningRodBlock(Identifier, Cardinal.Up, false, false),
            30036 => new LightningRodBlock(Identifier, Cardinal.Down, true, true),
            30037 => new LightningRodBlock(Identifier, Cardinal.Down, true, false),
            30038 => new LightningRodBlock(Identifier, Cardinal.Down, false, true),
            30039 => new LightningRodBlock(Identifier, Cardinal.Down, false, false),
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
