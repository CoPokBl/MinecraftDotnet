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
    public int ProtocolId => 981;
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
                    true => 23238,
                    false => 23239,
                },
                Cardinal.East => Waterlogged switch {
                    true => 23240,
                    false => 23241,
                },
                Cardinal.South => Waterlogged switch {
                    true => 23242,
                    false => 23243,
                },
                Cardinal.West => Waterlogged switch {
                    true => 23244,
                    false => 23245,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 23246,
                    false => 23247,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 23248,
                    false => 23249,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23238 => new SmallAmethystBudBlock(Identifier, Cardinal.North, true),
            23239 => new SmallAmethystBudBlock(Identifier, Cardinal.North, false),
            23240 => new SmallAmethystBudBlock(Identifier, Cardinal.East, true),
            23241 => new SmallAmethystBudBlock(Identifier, Cardinal.East, false),
            23242 => new SmallAmethystBudBlock(Identifier, Cardinal.South, true),
            23243 => new SmallAmethystBudBlock(Identifier, Cardinal.South, false),
            23244 => new SmallAmethystBudBlock(Identifier, Cardinal.West, true),
            23245 => new SmallAmethystBudBlock(Identifier, Cardinal.West, false),
            23246 => new SmallAmethystBudBlock(Identifier, Cardinal.Up, true),
            23247 => new SmallAmethystBudBlock(Identifier, Cardinal.Up, false),
            23248 => new SmallAmethystBudBlock(Identifier, Cardinal.Down, true),
            23249 => new SmallAmethystBudBlock(Identifier, Cardinal.Down, false),
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
