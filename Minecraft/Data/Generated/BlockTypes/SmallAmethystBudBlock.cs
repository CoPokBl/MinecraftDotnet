using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmallAmethystBudBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock {
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
    public int LightEmission => 1;
    public bool Replaceable => false;
    public string SoundType => "small_amethyst_bud";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:small_amethyst_bud";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.1875, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.1875, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.1875, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 24;
    public string TranslationKey => "block.minecraft.small_amethyst_bud";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Waterlogged switch {
                    true => 23440,
                    false => 23441,
                },
                Cardinal.East => Waterlogged switch {
                    true => 23442,
                    false => 23443,
                },
                Cardinal.South => Waterlogged switch {
                    true => 23444,
                    false => 23445,
                },
                Cardinal.West => Waterlogged switch {
                    true => 23446,
                    false => 23447,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 23448,
                    false => 23449,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 23450,
                    false => 23451,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23440 => new SmallAmethystBudBlock(Identifier, Cardinal.North, true),
            23441 => new SmallAmethystBudBlock(Identifier, Cardinal.North, false),
            23442 => new SmallAmethystBudBlock(Identifier, Cardinal.East, true),
            23443 => new SmallAmethystBudBlock(Identifier, Cardinal.East, false),
            23444 => new SmallAmethystBudBlock(Identifier, Cardinal.South, true),
            23445 => new SmallAmethystBudBlock(Identifier, Cardinal.South, false),
            23446 => new SmallAmethystBudBlock(Identifier, Cardinal.West, true),
            23447 => new SmallAmethystBudBlock(Identifier, Cardinal.West, false),
            23448 => new SmallAmethystBudBlock(Identifier, Cardinal.Up, true),
            23449 => new SmallAmethystBudBlock(Identifier, Cardinal.Up, false),
            23450 => new SmallAmethystBudBlock(Identifier, Cardinal.Down, true),
            23451 => new SmallAmethystBudBlock(Identifier, Cardinal.Down, false),
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
