using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LargeAmethystBudBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:amethyst_cluster";
    public double Hardness => 1.5;
    public double ExplosionResistance => 1.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 4;
    public bool Replaceable => false;
    public string SoundType => "medium_amethyst_bud";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:large_amethyst_bud";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.3125, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.3125, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.3125, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 24;
    public string TranslationKey => "block.minecraft.large_amethyst_bud";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Waterlogged switch {
                    true => 23416,
                    false => 23417,
                },
                Cardinal.East => Waterlogged switch {
                    true => 23418,
                    false => 23419,
                },
                Cardinal.South => Waterlogged switch {
                    true => 23420,
                    false => 23421,
                },
                Cardinal.West => Waterlogged switch {
                    true => 23422,
                    false => 23423,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 23424,
                    false => 23425,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 23426,
                    false => 23427,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23416 => new LargeAmethystBudBlock(Identifier, Cardinal.North, true),
            23417 => new LargeAmethystBudBlock(Identifier, Cardinal.North, false),
            23418 => new LargeAmethystBudBlock(Identifier, Cardinal.East, true),
            23419 => new LargeAmethystBudBlock(Identifier, Cardinal.East, false),
            23420 => new LargeAmethystBudBlock(Identifier, Cardinal.South, true),
            23421 => new LargeAmethystBudBlock(Identifier, Cardinal.South, false),
            23422 => new LargeAmethystBudBlock(Identifier, Cardinal.West, true),
            23423 => new LargeAmethystBudBlock(Identifier, Cardinal.West, false),
            23424 => new LargeAmethystBudBlock(Identifier, Cardinal.Up, true),
            23425 => new LargeAmethystBudBlock(Identifier, Cardinal.Up, false),
            23426 => new LargeAmethystBudBlock(Identifier, Cardinal.Down, true),
            23427 => new LargeAmethystBudBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
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
