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
    public int ProtocolId => 1095;
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
                        true => 27341,
                        false => 27342,
                    },
                    false => Waterlogged switch {
                        true => 27343,
                        false => 27344,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 27345,
                        false => 27346,
                    },
                    false => Waterlogged switch {
                        true => 27347,
                        false => 27348,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 27349,
                        false => 27350,
                    },
                    false => Waterlogged switch {
                        true => 27351,
                        false => 27352,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 27353,
                        false => 27354,
                    },
                    false => Waterlogged switch {
                        true => 27355,
                        false => 27356,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 27357,
                        false => 27358,
                    },
                    false => Waterlogged switch {
                        true => 27359,
                        false => 27360,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 27361,
                        false => 27362,
                    },
                    false => Waterlogged switch {
                        true => 27363,
                        false => 27364,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27341 => new LightningRodBlock(Identifier, Cardinal.North, true, true),
            27342 => new LightningRodBlock(Identifier, Cardinal.North, true, false),
            27343 => new LightningRodBlock(Identifier, Cardinal.North, false, true),
            27344 => new LightningRodBlock(Identifier, Cardinal.North, false, false),
            27345 => new LightningRodBlock(Identifier, Cardinal.East, true, true),
            27346 => new LightningRodBlock(Identifier, Cardinal.East, true, false),
            27347 => new LightningRodBlock(Identifier, Cardinal.East, false, true),
            27348 => new LightningRodBlock(Identifier, Cardinal.East, false, false),
            27349 => new LightningRodBlock(Identifier, Cardinal.South, true, true),
            27350 => new LightningRodBlock(Identifier, Cardinal.South, true, false),
            27351 => new LightningRodBlock(Identifier, Cardinal.South, false, true),
            27352 => new LightningRodBlock(Identifier, Cardinal.South, false, false),
            27353 => new LightningRodBlock(Identifier, Cardinal.West, true, true),
            27354 => new LightningRodBlock(Identifier, Cardinal.West, true, false),
            27355 => new LightningRodBlock(Identifier, Cardinal.West, false, true),
            27356 => new LightningRodBlock(Identifier, Cardinal.West, false, false),
            27357 => new LightningRodBlock(Identifier, Cardinal.Up, true, true),
            27358 => new LightningRodBlock(Identifier, Cardinal.Up, true, false),
            27359 => new LightningRodBlock(Identifier, Cardinal.Up, false, true),
            27360 => new LightningRodBlock(Identifier, Cardinal.Up, false, false),
            27361 => new LightningRodBlock(Identifier, Cardinal.Down, true, true),
            27362 => new LightningRodBlock(Identifier, Cardinal.Down, true, false),
            27363 => new LightningRodBlock(Identifier, Cardinal.Down, false, true),
            27364 => new LightningRodBlock(Identifier, Cardinal.Down, false, false),
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
