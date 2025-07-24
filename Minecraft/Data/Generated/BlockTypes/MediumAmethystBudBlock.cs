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
    public int ProtocolId => 942;
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
                    true => 22117,
                    false => 22118,
                },
                Cardinal.East => Waterlogged switch {
                    true => 22119,
                    false => 22120,
                },
                Cardinal.South => Waterlogged switch {
                    true => 22121,
                    false => 22122,
                },
                Cardinal.West => Waterlogged switch {
                    true => 22123,
                    false => 22124,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 22125,
                    false => 22126,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 22127,
                    false => 22128,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22117 => new MediumAmethystBudBlock(Identifier, Cardinal.North, true),
            22118 => new MediumAmethystBudBlock(Identifier, Cardinal.North, false),
            22119 => new MediumAmethystBudBlock(Identifier, Cardinal.East, true),
            22120 => new MediumAmethystBudBlock(Identifier, Cardinal.East, false),
            22121 => new MediumAmethystBudBlock(Identifier, Cardinal.South, true),
            22122 => new MediumAmethystBudBlock(Identifier, Cardinal.South, false),
            22123 => new MediumAmethystBudBlock(Identifier, Cardinal.West, true),
            22124 => new MediumAmethystBudBlock(Identifier, Cardinal.West, false),
            22125 => new MediumAmethystBudBlock(Identifier, Cardinal.Up, true),
            22126 => new MediumAmethystBudBlock(Identifier, Cardinal.Up, false),
            22127 => new MediumAmethystBudBlock(Identifier, Cardinal.Down, true),
            22128 => new MediumAmethystBudBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
