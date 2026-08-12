using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ChainCommandBlockBlock(Identifier Identifier, bool Conditional, Cardinal Facing) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:command", "block.minecraft.chain_command_block", 3600000f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:command_block", "minecraft:chain_command_block", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(-1f, 0, 15, PushReaction.Normal, 27, "stone", NoteBlockInstrument.Harp, false, true, true, true, false, false, false, false, true, true, false, false, true, true, true, null, null, BlockShapes.S77, BlockShapes.S77, BlockShapes.S1, BlockShapes.S77, BlockShapes.S77);

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Conditional switch {
                true => Facing switch {
                    Cardinal.North => 14829,
                    Cardinal.East => 14830,
                    Cardinal.South => 14831,
                    Cardinal.West => 14832,
                    Cardinal.Up => 14833,
                    Cardinal.Down => 14834,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 14835,
                    Cardinal.East => 14836,
                    Cardinal.South => 14837,
                    Cardinal.West => 14838,
                    Cardinal.Up => 14839,
                    Cardinal.Down => 14840,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14829 => new ChainCommandBlockBlock(Identifier, true, Cardinal.North),
            14830 => new ChainCommandBlockBlock(Identifier, true, Cardinal.East),
            14831 => new ChainCommandBlockBlock(Identifier, true, Cardinal.South),
            14832 => new ChainCommandBlockBlock(Identifier, true, Cardinal.West),
            14833 => new ChainCommandBlockBlock(Identifier, true, Cardinal.Up),
            14834 => new ChainCommandBlockBlock(Identifier, true, Cardinal.Down),
            14835 => new ChainCommandBlockBlock(Identifier, false, Cardinal.North),
            14836 => new ChainCommandBlockBlock(Identifier, false, Cardinal.East),
            14837 => new ChainCommandBlockBlock(Identifier, false, Cardinal.South),
            14838 => new ChainCommandBlockBlock(Identifier, false, Cardinal.West),
            14839 => new ChainCommandBlockBlock(Identifier, false, Cardinal.Up),
            14840 => new ChainCommandBlockBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Conditional = properties.Contains("conditional") ? properties["conditional"].GetString() == "true" : Conditional,
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("conditional", new StringTag(Conditional.ToString().ToLower())),
            ("facing", new StringTag(Facing.ToName()))
        );
    }
    
}
