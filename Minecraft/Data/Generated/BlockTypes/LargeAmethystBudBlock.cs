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
    public int ProtocolId => 979;
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
                    true => 23214,
                    false => 23215,
                },
                Cardinal.East => Waterlogged switch {
                    true => 23216,
                    false => 23217,
                },
                Cardinal.South => Waterlogged switch {
                    true => 23218,
                    false => 23219,
                },
                Cardinal.West => Waterlogged switch {
                    true => 23220,
                    false => 23221,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 23222,
                    false => 23223,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 23224,
                    false => 23225,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23214 => new LargeAmethystBudBlock(Identifier, Cardinal.North, true),
            23215 => new LargeAmethystBudBlock(Identifier, Cardinal.North, false),
            23216 => new LargeAmethystBudBlock(Identifier, Cardinal.East, true),
            23217 => new LargeAmethystBudBlock(Identifier, Cardinal.East, false),
            23218 => new LargeAmethystBudBlock(Identifier, Cardinal.South, true),
            23219 => new LargeAmethystBudBlock(Identifier, Cardinal.South, false),
            23220 => new LargeAmethystBudBlock(Identifier, Cardinal.West, true),
            23221 => new LargeAmethystBudBlock(Identifier, Cardinal.West, false),
            23222 => new LargeAmethystBudBlock(Identifier, Cardinal.Up, true),
            23223 => new LargeAmethystBudBlock(Identifier, Cardinal.Up, false),
            23224 => new LargeAmethystBudBlock(Identifier, Cardinal.Down, true),
            23225 => new LargeAmethystBudBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
