using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ObserverBlock(Identifier Identifier, Cardinal Facing, bool Powered) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:observer", "block.minecraft.observer", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:observer", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 15, PushReaction.Normal, 11, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, true, false, true, true, true, null, null, BlockShapes.S77, BlockShapes.S77, BlockShapes.S1, BlockShapes.S77, BlockShapes.S77);

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
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => 14852,
                    false => 14853,
                },
                Cardinal.East => Powered switch {
                    true => 14854,
                    false => 14855,
                },
                Cardinal.South => Powered switch {
                    true => 14856,
                    false => 14857,
                },
                Cardinal.West => Powered switch {
                    true => 14858,
                    false => 14859,
                },
                Cardinal.Up => Powered switch {
                    true => 14860,
                    false => 14861,
                },
                Cardinal.Down => Powered switch {
                    true => 14862,
                    false => 14863,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14852 => new ObserverBlock(Identifier, Cardinal.North, true),
            14853 => new ObserverBlock(Identifier, Cardinal.North, false),
            14854 => new ObserverBlock(Identifier, Cardinal.East, true),
            14855 => new ObserverBlock(Identifier, Cardinal.East, false),
            14856 => new ObserverBlock(Identifier, Cardinal.South, true),
            14857 => new ObserverBlock(Identifier, Cardinal.South, false),
            14858 => new ObserverBlock(Identifier, Cardinal.West, true),
            14859 => new ObserverBlock(Identifier, Cardinal.West, false),
            14860 => new ObserverBlock(Identifier, Cardinal.Up, true),
            14861 => new ObserverBlock(Identifier, Cardinal.Up, false),
            14862 => new ObserverBlock(Identifier, Cardinal.Down, true),
            14863 => new ObserverBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
