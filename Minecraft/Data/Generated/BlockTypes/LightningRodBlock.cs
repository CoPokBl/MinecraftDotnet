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

    public Identifier Category => "minecraft:lightning_rod";
    public int ProtocolId => 1041;
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
                        true => 25784,
                        false => 25785,
                    },
                    false => Waterlogged switch {
                        true => 25786,
                        false => 25787,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 25788,
                        false => 25789,
                    },
                    false => Waterlogged switch {
                        true => 25790,
                        false => 25791,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 25792,
                        false => 25793,
                    },
                    false => Waterlogged switch {
                        true => 25794,
                        false => 25795,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 25796,
                        false => 25797,
                    },
                    false => Waterlogged switch {
                        true => 25798,
                        false => 25799,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 25800,
                        false => 25801,
                    },
                    false => Waterlogged switch {
                        true => 25802,
                        false => 25803,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 25804,
                        false => 25805,
                    },
                    false => Waterlogged switch {
                        true => 25806,
                        false => 25807,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25784 => new LightningRodBlock(Identifier, Cardinal.North, true, true),
            25785 => new LightningRodBlock(Identifier, Cardinal.North, true, false),
            25786 => new LightningRodBlock(Identifier, Cardinal.North, false, true),
            25787 => new LightningRodBlock(Identifier, Cardinal.North, false, false),
            25788 => new LightningRodBlock(Identifier, Cardinal.East, true, true),
            25789 => new LightningRodBlock(Identifier, Cardinal.East, true, false),
            25790 => new LightningRodBlock(Identifier, Cardinal.East, false, true),
            25791 => new LightningRodBlock(Identifier, Cardinal.East, false, false),
            25792 => new LightningRodBlock(Identifier, Cardinal.South, true, true),
            25793 => new LightningRodBlock(Identifier, Cardinal.South, true, false),
            25794 => new LightningRodBlock(Identifier, Cardinal.South, false, true),
            25795 => new LightningRodBlock(Identifier, Cardinal.South, false, false),
            25796 => new LightningRodBlock(Identifier, Cardinal.West, true, true),
            25797 => new LightningRodBlock(Identifier, Cardinal.West, true, false),
            25798 => new LightningRodBlock(Identifier, Cardinal.West, false, true),
            25799 => new LightningRodBlock(Identifier, Cardinal.West, false, false),
            25800 => new LightningRodBlock(Identifier, Cardinal.Up, true, true),
            25801 => new LightningRodBlock(Identifier, Cardinal.Up, true, false),
            25802 => new LightningRodBlock(Identifier, Cardinal.Up, false, true),
            25803 => new LightningRodBlock(Identifier, Cardinal.Up, false, false),
            25804 => new LightningRodBlock(Identifier, Cardinal.Down, true, true),
            25805 => new LightningRodBlock(Identifier, Cardinal.Down, true, false),
            25806 => new LightningRodBlock(Identifier, Cardinal.Down, false, true),
            25807 => new LightningRodBlock(Identifier, Cardinal.Down, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
            Powered = properties["powered"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
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
