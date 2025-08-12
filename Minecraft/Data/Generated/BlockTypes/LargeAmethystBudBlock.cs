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
    public int ProtocolId => 941;
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
                    true => 22105,
                    false => 22106,
                },
                Cardinal.East => Waterlogged switch {
                    true => 22107,
                    false => 22108,
                },
                Cardinal.South => Waterlogged switch {
                    true => 22109,
                    false => 22110,
                },
                Cardinal.West => Waterlogged switch {
                    true => 22111,
                    false => 22112,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 22113,
                    false => 22114,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 22115,
                    false => 22116,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22105 => new LargeAmethystBudBlock(Identifier, Cardinal.North, true),
            22106 => new LargeAmethystBudBlock(Identifier, Cardinal.North, false),
            22107 => new LargeAmethystBudBlock(Identifier, Cardinal.East, true),
            22108 => new LargeAmethystBudBlock(Identifier, Cardinal.East, false),
            22109 => new LargeAmethystBudBlock(Identifier, Cardinal.South, true),
            22110 => new LargeAmethystBudBlock(Identifier, Cardinal.South, false),
            22111 => new LargeAmethystBudBlock(Identifier, Cardinal.West, true),
            22112 => new LargeAmethystBudBlock(Identifier, Cardinal.West, false),
            22113 => new LargeAmethystBudBlock(Identifier, Cardinal.Up, true),
            22114 => new LargeAmethystBudBlock(Identifier, Cardinal.Up, false),
            22115 => new LargeAmethystBudBlock(Identifier, Cardinal.Down, true),
            22116 => new LargeAmethystBudBlock(Identifier, Cardinal.Down, false),
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
