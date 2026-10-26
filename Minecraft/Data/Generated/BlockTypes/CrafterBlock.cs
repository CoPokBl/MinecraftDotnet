using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrafterBlock(Identifier Identifier, bool Crafting, Orientation Orientation, bool Triggered) : IBlock, IOriented {
    private static readonly BlockInfo Data = new("block.minecraft.crafter", 3.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:crafter", "minecraft:crafter", BlockInfo.VanillaOnly, "minecraft:blocks/crafter");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 15, PushReaction.PushPull, 11, "stone", NoteBlockInstrument.Harp, false, true, false, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

    public BlockStateInfo StateInfo => I0;

    public BlockInfo Info => Data;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public float FallDistanceReduction => Data.FallDistanceReduction;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public int LightEmission => StateInfo.LightEmission;
    public int LightDampening => StateInfo.LightDampening;
    public bool Replaceable => StateInfo.Replaceable;
    public string SoundType => StateInfo.SoundType;
    public ICollisionBox BlockShape => StateInfo.BlockShape;
    public ICollisionBox CollisionShape => StateInfo.CollisionShape;
    public ICollisionBox OcclusionShape => StateInfo.OcclusionShape;
    public ICollisionBox InteractionShape => StateInfo.InteractionShape;
    public ICollisionBox VisualShape => StateInfo.VisualShape;
    public ICollisionBox SupportShape => StateInfo.SupportShape;
    public bool RedstoneConductor => StateInfo.RedstoneConductor;
    public bool SignalSource => StateInfo.SignalSource;
    public bool Flammable => StateInfo.Flammable;
    public PushReaction PushReaction => StateInfo.PushReaction;
    public int MapColorId => StateInfo.MapColorId;
    public bool CanRespawnIn => StateInfo.CanRespawnIn;
    public bool RandomlyTicking => StateInfo.RandomlyTicking;
    public bool Suffocating => StateInfo.Suffocating;
    public bool ViewBlocking => StateInfo.ViewBlocking;
    public bool ViewBlockingNearPlane => StateInfo.ViewBlockingNearPlane;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithOrientation(Orientation orientation) => this with { Orientation = orientation };


    public uint StateId {
        get {
            return Crafting switch {
                true => Orientation switch {
                    Orientation.DownEast => Triggered switch {
                        true => 35459,
                        false => 35460,
                    },
                    Orientation.DownNorth => Triggered switch {
                        true => 35461,
                        false => 35462,
                    },
                    Orientation.DownSouth => Triggered switch {
                        true => 35463,
                        false => 35464,
                    },
                    Orientation.DownWest => Triggered switch {
                        true => 35465,
                        false => 35466,
                    },
                    Orientation.UpEast => Triggered switch {
                        true => 35467,
                        false => 35468,
                    },
                    Orientation.UpNorth => Triggered switch {
                        true => 35469,
                        false => 35470,
                    },
                    Orientation.UpSouth => Triggered switch {
                        true => 35471,
                        false => 35472,
                    },
                    Orientation.UpWest => Triggered switch {
                        true => 35473,
                        false => 35474,
                    },
                    Orientation.WestUp => Triggered switch {
                        true => 35475,
                        false => 35476,
                    },
                    Orientation.EastUp => Triggered switch {
                        true => 35477,
                        false => 35478,
                    },
                    Orientation.NorthUp => Triggered switch {
                        true => 35479,
                        false => 35480,
                    },
                    Orientation.SouthUp => Triggered switch {
                        true => 35481,
                        false => 35482,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
                },
                false => Orientation switch {
                    Orientation.DownEast => Triggered switch {
                        true => 35483,
                        false => 35484,
                    },
                    Orientation.DownNorth => Triggered switch {
                        true => 35485,
                        false => 35486,
                    },
                    Orientation.DownSouth => Triggered switch {
                        true => 35487,
                        false => 35488,
                    },
                    Orientation.DownWest => Triggered switch {
                        true => 35489,
                        false => 35490,
                    },
                    Orientation.UpEast => Triggered switch {
                        true => 35491,
                        false => 35492,
                    },
                    Orientation.UpNorth => Triggered switch {
                        true => 35493,
                        false => 35494,
                    },
                    Orientation.UpSouth => Triggered switch {
                        true => 35495,
                        false => 35496,
                    },
                    Orientation.UpWest => Triggered switch {
                        true => 35497,
                        false => 35498,
                    },
                    Orientation.WestUp => Triggered switch {
                        true => 35499,
                        false => 35500,
                    },
                    Orientation.EastUp => Triggered switch {
                        true => 35501,
                        false => 35502,
                    },
                    Orientation.NorthUp => Triggered switch {
                        true => 35503,
                        false => 35504,
                    },
                    Orientation.SouthUp => Triggered switch {
                        true => 35505,
                        false => 35506,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            35459 => new CrafterBlock(Identifier, true, Orientation.DownEast, true),
            35460 => new CrafterBlock(Identifier, true, Orientation.DownEast, false),
            35461 => new CrafterBlock(Identifier, true, Orientation.DownNorth, true),
            35462 => new CrafterBlock(Identifier, true, Orientation.DownNorth, false),
            35463 => new CrafterBlock(Identifier, true, Orientation.DownSouth, true),
            35464 => new CrafterBlock(Identifier, true, Orientation.DownSouth, false),
            35465 => new CrafterBlock(Identifier, true, Orientation.DownWest, true),
            35466 => new CrafterBlock(Identifier, true, Orientation.DownWest, false),
            35467 => new CrafterBlock(Identifier, true, Orientation.UpEast, true),
            35468 => new CrafterBlock(Identifier, true, Orientation.UpEast, false),
            35469 => new CrafterBlock(Identifier, true, Orientation.UpNorth, true),
            35470 => new CrafterBlock(Identifier, true, Orientation.UpNorth, false),
            35471 => new CrafterBlock(Identifier, true, Orientation.UpSouth, true),
            35472 => new CrafterBlock(Identifier, true, Orientation.UpSouth, false),
            35473 => new CrafterBlock(Identifier, true, Orientation.UpWest, true),
            35474 => new CrafterBlock(Identifier, true, Orientation.UpWest, false),
            35475 => new CrafterBlock(Identifier, true, Orientation.WestUp, true),
            35476 => new CrafterBlock(Identifier, true, Orientation.WestUp, false),
            35477 => new CrafterBlock(Identifier, true, Orientation.EastUp, true),
            35478 => new CrafterBlock(Identifier, true, Orientation.EastUp, false),
            35479 => new CrafterBlock(Identifier, true, Orientation.NorthUp, true),
            35480 => new CrafterBlock(Identifier, true, Orientation.NorthUp, false),
            35481 => new CrafterBlock(Identifier, true, Orientation.SouthUp, true),
            35482 => new CrafterBlock(Identifier, true, Orientation.SouthUp, false),
            35483 => new CrafterBlock(Identifier, false, Orientation.DownEast, true),
            35484 => new CrafterBlock(Identifier, false, Orientation.DownEast, false),
            35485 => new CrafterBlock(Identifier, false, Orientation.DownNorth, true),
            35486 => new CrafterBlock(Identifier, false, Orientation.DownNorth, false),
            35487 => new CrafterBlock(Identifier, false, Orientation.DownSouth, true),
            35488 => new CrafterBlock(Identifier, false, Orientation.DownSouth, false),
            35489 => new CrafterBlock(Identifier, false, Orientation.DownWest, true),
            35490 => new CrafterBlock(Identifier, false, Orientation.DownWest, false),
            35491 => new CrafterBlock(Identifier, false, Orientation.UpEast, true),
            35492 => new CrafterBlock(Identifier, false, Orientation.UpEast, false),
            35493 => new CrafterBlock(Identifier, false, Orientation.UpNorth, true),
            35494 => new CrafterBlock(Identifier, false, Orientation.UpNorth, false),
            35495 => new CrafterBlock(Identifier, false, Orientation.UpSouth, true),
            35496 => new CrafterBlock(Identifier, false, Orientation.UpSouth, false),
            35497 => new CrafterBlock(Identifier, false, Orientation.UpWest, true),
            35498 => new CrafterBlock(Identifier, false, Orientation.UpWest, false),
            35499 => new CrafterBlock(Identifier, false, Orientation.WestUp, true),
            35500 => new CrafterBlock(Identifier, false, Orientation.WestUp, false),
            35501 => new CrafterBlock(Identifier, false, Orientation.EastUp, true),
            35502 => new CrafterBlock(Identifier, false, Orientation.EastUp, false),
            35503 => new CrafterBlock(Identifier, false, Orientation.NorthUp, true),
            35504 => new CrafterBlock(Identifier, false, Orientation.NorthUp, false),
            35505 => new CrafterBlock(Identifier, false, Orientation.SouthUp, true),
            35506 => new CrafterBlock(Identifier, false, Orientation.SouthUp, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Crafting = properties.Contains("crafting") ? properties["crafting"].GetString() == "true" : Crafting,
            Orientation = properties.Contains("orientation") ? OrientationExtensions.FromString(properties["orientation"].GetString()) : Orientation,
            Triggered = properties.Contains("triggered") ? properties["triggered"].GetString() == "true" : Triggered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("crafting", new StringTag(Crafting.ToString().ToLower())),
            ("orientation", new StringTag(Orientation.ToName())),
            ("triggered", new StringTag(Triggered.ToString().ToLower()))
        );
    }
    
}
