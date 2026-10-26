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
public record PaleOakWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.pale_oak_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:pale_oak_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/pale_oak_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 14, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S116, BlockShapes.S117, BlockShapes.S1, BlockShapes.S1, BlockShapes.S117, BlockShapes.S116);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S118, CollisionShape = BlockShapes.S119, VisualShape = BlockShapes.S119, SupportShape = BlockShapes.S118 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S118, CollisionShape = BlockShapes.S119, VisualShape = BlockShapes.S119, SupportShape = BlockShapes.S118 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 8391];

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 8391,
                    false => 8392,
                },
                Direction.South => Waterlogged switch {
                    true => 8393,
                    false => 8394,
                },
                Direction.West => Waterlogged switch {
                    true => 8395,
                    false => 8396,
                },
                Direction.East => Waterlogged switch {
                    true => 8397,
                    false => 8398,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8391 => new PaleOakWallHangingSignBlock(Identifier, Direction.North, true),
            8392 => new PaleOakWallHangingSignBlock(Identifier, Direction.North, false),
            8393 => new PaleOakWallHangingSignBlock(Identifier, Direction.South, true),
            8394 => new PaleOakWallHangingSignBlock(Identifier, Direction.South, false),
            8395 => new PaleOakWallHangingSignBlock(Identifier, Direction.West, true),
            8396 => new PaleOakWallHangingSignBlock(Identifier, Direction.West, false),
            8397 => new PaleOakWallHangingSignBlock(Identifier, Direction.East, true),
            8398 => new PaleOakWallHangingSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
