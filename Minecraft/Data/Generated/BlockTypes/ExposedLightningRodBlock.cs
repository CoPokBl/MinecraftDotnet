using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_lightning_rod";
    public int ProtocolId => 1096;
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
    public Identifier? Item => "minecraft:exposed_lightning_rod";
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
    public string TranslationKey => "block.minecraft.exposed_lightning_rod";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 27365,
                        false => 27366,
                    },
                    false => Waterlogged switch {
                        true => 27367,
                        false => 27368,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 27369,
                        false => 27370,
                    },
                    false => Waterlogged switch {
                        true => 27371,
                        false => 27372,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 27373,
                        false => 27374,
                    },
                    false => Waterlogged switch {
                        true => 27375,
                        false => 27376,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 27377,
                        false => 27378,
                    },
                    false => Waterlogged switch {
                        true => 27379,
                        false => 27380,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 27381,
                        false => 27382,
                    },
                    false => Waterlogged switch {
                        true => 27383,
                        false => 27384,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 27385,
                        false => 27386,
                    },
                    false => Waterlogged switch {
                        true => 27387,
                        false => 27388,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27365 => new ExposedLightningRodBlock(Identifier, Cardinal.North, true, true),
            27366 => new ExposedLightningRodBlock(Identifier, Cardinal.North, true, false),
            27367 => new ExposedLightningRodBlock(Identifier, Cardinal.North, false, true),
            27368 => new ExposedLightningRodBlock(Identifier, Cardinal.North, false, false),
            27369 => new ExposedLightningRodBlock(Identifier, Cardinal.East, true, true),
            27370 => new ExposedLightningRodBlock(Identifier, Cardinal.East, true, false),
            27371 => new ExposedLightningRodBlock(Identifier, Cardinal.East, false, true),
            27372 => new ExposedLightningRodBlock(Identifier, Cardinal.East, false, false),
            27373 => new ExposedLightningRodBlock(Identifier, Cardinal.South, true, true),
            27374 => new ExposedLightningRodBlock(Identifier, Cardinal.South, true, false),
            27375 => new ExposedLightningRodBlock(Identifier, Cardinal.South, false, true),
            27376 => new ExposedLightningRodBlock(Identifier, Cardinal.South, false, false),
            27377 => new ExposedLightningRodBlock(Identifier, Cardinal.West, true, true),
            27378 => new ExposedLightningRodBlock(Identifier, Cardinal.West, true, false),
            27379 => new ExposedLightningRodBlock(Identifier, Cardinal.West, false, true),
            27380 => new ExposedLightningRodBlock(Identifier, Cardinal.West, false, false),
            27381 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            27382 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            27383 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            27384 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            27385 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            27386 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            27387 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            27388 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
