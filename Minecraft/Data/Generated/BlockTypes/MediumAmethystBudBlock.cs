using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MediumAmethystBudBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:amethyst_cluster";
    public int ProtocolId => 980;
    public double Hardness => 1.5;
    public double ExplosionResistance => 1.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 2;
    public bool Replaceable => false;
    public string SoundType => "large_amethyst_bud";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:medium_amethyst_bud";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.25, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.25, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.25, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 24;
    public string TranslationKey => "block.minecraft.medium_amethyst_bud";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Waterlogged switch {
                    true => 23226,
                    false => 23227,
                },
                Cardinal.East => Waterlogged switch {
                    true => 23228,
                    false => 23229,
                },
                Cardinal.South => Waterlogged switch {
                    true => 23230,
                    false => 23231,
                },
                Cardinal.West => Waterlogged switch {
                    true => 23232,
                    false => 23233,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 23234,
                    false => 23235,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 23236,
                    false => 23237,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23226 => new MediumAmethystBudBlock(Identifier, Cardinal.North, true),
            23227 => new MediumAmethystBudBlock(Identifier, Cardinal.North, false),
            23228 => new MediumAmethystBudBlock(Identifier, Cardinal.East, true),
            23229 => new MediumAmethystBudBlock(Identifier, Cardinal.East, false),
            23230 => new MediumAmethystBudBlock(Identifier, Cardinal.South, true),
            23231 => new MediumAmethystBudBlock(Identifier, Cardinal.South, false),
            23232 => new MediumAmethystBudBlock(Identifier, Cardinal.West, true),
            23233 => new MediumAmethystBudBlock(Identifier, Cardinal.West, false),
            23234 => new MediumAmethystBudBlock(Identifier, Cardinal.Up, true),
            23235 => new MediumAmethystBudBlock(Identifier, Cardinal.Up, false),
            23236 => new MediumAmethystBudBlock(Identifier, Cardinal.Down, true),
            23237 => new MediumAmethystBudBlock(Identifier, Cardinal.Down, false),
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
