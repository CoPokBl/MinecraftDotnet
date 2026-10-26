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
public record HopperBlock(Identifier Identifier, bool Enabled, HopperDirection Facing) : IBlock, IEnabled, IHopperFacing {
    private static readonly BlockInfo Data = new("block.minecraft.hopper", 4.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hopper", "minecraft:hopper", BlockInfo.VanillaOnly, "minecraft:blocks/hopper");
    private static readonly BlockStateInfo I0 = new(3f, 0, 0, PushReaction.PushPull, 11, "metal", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S602, BlockShapes.S602, BlockShapes.S603, BlockShapes.S1, BlockShapes.S602, BlockShapes.S602);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S604, CollisionShape = BlockShapes.S604, InteractionShape = BlockShapes.S605, VisualShape = BlockShapes.S604, SupportShape = BlockShapes.S604 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S606, CollisionShape = BlockShapes.S606, InteractionShape = BlockShapes.S607, VisualShape = BlockShapes.S606, SupportShape = BlockShapes.S606 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S608, CollisionShape = BlockShapes.S608, InteractionShape = BlockShapes.S609, VisualShape = BlockShapes.S608, SupportShape = BlockShapes.S608 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S610, CollisionShape = BlockShapes.S610, InteractionShape = BlockShapes.S611, VisualShape = BlockShapes.S610, SupportShape = BlockShapes.S610 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I0, I1, I2, I3, I4
    ];

    public BlockStateInfo StateInfo => States[StateId - 13080];

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

    public IBlock WithEnabled(bool enabled) => this with { Enabled = enabled };

    public IBlock WithFacing(HopperDirection facing) => this with { Facing = facing };


    public uint StateId {
        get {
            return Enabled switch {
                true => Facing switch {
                    HopperDirection.Down => 13080,
                    HopperDirection.North => 13081,
                    HopperDirection.South => 13082,
                    HopperDirection.West => 13083,
                    HopperDirection.East => 13084,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    HopperDirection.Down => 13085,
                    HopperDirection.North => 13086,
                    HopperDirection.South => 13087,
                    HopperDirection.West => 13088,
                    HopperDirection.East => 13089,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13080 => new HopperBlock(Identifier, true, HopperDirection.Down),
            13081 => new HopperBlock(Identifier, true, HopperDirection.North),
            13082 => new HopperBlock(Identifier, true, HopperDirection.South),
            13083 => new HopperBlock(Identifier, true, HopperDirection.West),
            13084 => new HopperBlock(Identifier, true, HopperDirection.East),
            13085 => new HopperBlock(Identifier, false, HopperDirection.Down),
            13086 => new HopperBlock(Identifier, false, HopperDirection.North),
            13087 => new HopperBlock(Identifier, false, HopperDirection.South),
            13088 => new HopperBlock(Identifier, false, HopperDirection.West),
            13089 => new HopperBlock(Identifier, false, HopperDirection.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Enabled = properties.Contains("enabled") ? properties["enabled"].GetString() == "true" : Enabled,
            Facing = properties.Contains("facing") ? HopperDirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("enabled", new StringTag(Enabled.ToString().ToLower())),
            ("facing", new StringTag(Facing.ToName()))
        );
    }
    
}
