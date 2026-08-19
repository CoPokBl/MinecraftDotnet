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
    private static readonly BlockInfo Data = new("minecraft:crafter", "block.minecraft.crafter", 3.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:crafter", "minecraft:crafter", BlockInfo.VanillaOnly, "minecraft:blocks/crafter");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 15, PushReaction.Normal, 11, "stone", NoteBlockInstrument.Harp, false, true, false, true, false, false, false, false, true, true, false, false, true, true, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

    public BlockStateInfo StateInfo => I0;

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
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
    public bool BlocksMotion => StateInfo.BlocksMotion;
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
                        true => 32102,
                        false => 32103,
                    },
                    Orientation.DownNorth => Triggered switch {
                        true => 32104,
                        false => 32105,
                    },
                    Orientation.DownSouth => Triggered switch {
                        true => 32106,
                        false => 32107,
                    },
                    Orientation.DownWest => Triggered switch {
                        true => 32108,
                        false => 32109,
                    },
                    Orientation.UpEast => Triggered switch {
                        true => 32110,
                        false => 32111,
                    },
                    Orientation.UpNorth => Triggered switch {
                        true => 32112,
                        false => 32113,
                    },
                    Orientation.UpSouth => Triggered switch {
                        true => 32114,
                        false => 32115,
                    },
                    Orientation.UpWest => Triggered switch {
                        true => 32116,
                        false => 32117,
                    },
                    Orientation.WestUp => Triggered switch {
                        true => 32118,
                        false => 32119,
                    },
                    Orientation.EastUp => Triggered switch {
                        true => 32120,
                        false => 32121,
                    },
                    Orientation.NorthUp => Triggered switch {
                        true => 32122,
                        false => 32123,
                    },
                    Orientation.SouthUp => Triggered switch {
                        true => 32124,
                        false => 32125,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
                },
                false => Orientation switch {
                    Orientation.DownEast => Triggered switch {
                        true => 32126,
                        false => 32127,
                    },
                    Orientation.DownNorth => Triggered switch {
                        true => 32128,
                        false => 32129,
                    },
                    Orientation.DownSouth => Triggered switch {
                        true => 32130,
                        false => 32131,
                    },
                    Orientation.DownWest => Triggered switch {
                        true => 32132,
                        false => 32133,
                    },
                    Orientation.UpEast => Triggered switch {
                        true => 32134,
                        false => 32135,
                    },
                    Orientation.UpNorth => Triggered switch {
                        true => 32136,
                        false => 32137,
                    },
                    Orientation.UpSouth => Triggered switch {
                        true => 32138,
                        false => 32139,
                    },
                    Orientation.UpWest => Triggered switch {
                        true => 32140,
                        false => 32141,
                    },
                    Orientation.WestUp => Triggered switch {
                        true => 32142,
                        false => 32143,
                    },
                    Orientation.EastUp => Triggered switch {
                        true => 32144,
                        false => 32145,
                    },
                    Orientation.NorthUp => Triggered switch {
                        true => 32146,
                        false => 32147,
                    },
                    Orientation.SouthUp => Triggered switch {
                        true => 32148,
                        false => 32149,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            32102 => new CrafterBlock(Identifier, true, Orientation.DownEast, true),
            32103 => new CrafterBlock(Identifier, true, Orientation.DownEast, false),
            32104 => new CrafterBlock(Identifier, true, Orientation.DownNorth, true),
            32105 => new CrafterBlock(Identifier, true, Orientation.DownNorth, false),
            32106 => new CrafterBlock(Identifier, true, Orientation.DownSouth, true),
            32107 => new CrafterBlock(Identifier, true, Orientation.DownSouth, false),
            32108 => new CrafterBlock(Identifier, true, Orientation.DownWest, true),
            32109 => new CrafterBlock(Identifier, true, Orientation.DownWest, false),
            32110 => new CrafterBlock(Identifier, true, Orientation.UpEast, true),
            32111 => new CrafterBlock(Identifier, true, Orientation.UpEast, false),
            32112 => new CrafterBlock(Identifier, true, Orientation.UpNorth, true),
            32113 => new CrafterBlock(Identifier, true, Orientation.UpNorth, false),
            32114 => new CrafterBlock(Identifier, true, Orientation.UpSouth, true),
            32115 => new CrafterBlock(Identifier, true, Orientation.UpSouth, false),
            32116 => new CrafterBlock(Identifier, true, Orientation.UpWest, true),
            32117 => new CrafterBlock(Identifier, true, Orientation.UpWest, false),
            32118 => new CrafterBlock(Identifier, true, Orientation.WestUp, true),
            32119 => new CrafterBlock(Identifier, true, Orientation.WestUp, false),
            32120 => new CrafterBlock(Identifier, true, Orientation.EastUp, true),
            32121 => new CrafterBlock(Identifier, true, Orientation.EastUp, false),
            32122 => new CrafterBlock(Identifier, true, Orientation.NorthUp, true),
            32123 => new CrafterBlock(Identifier, true, Orientation.NorthUp, false),
            32124 => new CrafterBlock(Identifier, true, Orientation.SouthUp, true),
            32125 => new CrafterBlock(Identifier, true, Orientation.SouthUp, false),
            32126 => new CrafterBlock(Identifier, false, Orientation.DownEast, true),
            32127 => new CrafterBlock(Identifier, false, Orientation.DownEast, false),
            32128 => new CrafterBlock(Identifier, false, Orientation.DownNorth, true),
            32129 => new CrafterBlock(Identifier, false, Orientation.DownNorth, false),
            32130 => new CrafterBlock(Identifier, false, Orientation.DownSouth, true),
            32131 => new CrafterBlock(Identifier, false, Orientation.DownSouth, false),
            32132 => new CrafterBlock(Identifier, false, Orientation.DownWest, true),
            32133 => new CrafterBlock(Identifier, false, Orientation.DownWest, false),
            32134 => new CrafterBlock(Identifier, false, Orientation.UpEast, true),
            32135 => new CrafterBlock(Identifier, false, Orientation.UpEast, false),
            32136 => new CrafterBlock(Identifier, false, Orientation.UpNorth, true),
            32137 => new CrafterBlock(Identifier, false, Orientation.UpNorth, false),
            32138 => new CrafterBlock(Identifier, false, Orientation.UpSouth, true),
            32139 => new CrafterBlock(Identifier, false, Orientation.UpSouth, false),
            32140 => new CrafterBlock(Identifier, false, Orientation.UpWest, true),
            32141 => new CrafterBlock(Identifier, false, Orientation.UpWest, false),
            32142 => new CrafterBlock(Identifier, false, Orientation.WestUp, true),
            32143 => new CrafterBlock(Identifier, false, Orientation.WestUp, false),
            32144 => new CrafterBlock(Identifier, false, Orientation.EastUp, true),
            32145 => new CrafterBlock(Identifier, false, Orientation.EastUp, false),
            32146 => new CrafterBlock(Identifier, false, Orientation.NorthUp, true),
            32147 => new CrafterBlock(Identifier, false, Orientation.NorthUp, false),
            32148 => new CrafterBlock(Identifier, false, Orientation.SouthUp, true),
            32149 => new CrafterBlock(Identifier, false, Orientation.SouthUp, false),
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
