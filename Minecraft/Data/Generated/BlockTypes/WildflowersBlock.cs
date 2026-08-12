using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WildflowersBlock(Identifier Identifier, Direction Facing, int FlowerAmount) : IBlock {
    public Identifier Category => "minecraft:flower_bed";
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "pink_petals";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:wildflowers";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [0.5, 0.1875, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.wildflowers";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => FlowerAmount switch {
                    1 => 30323,
                    2 => 30324,
                    3 => 30325,
                    4 => 30326,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.South => FlowerAmount switch {
                    1 => 30327,
                    2 => 30328,
                    3 => 30329,
                    4 => 30330,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.West => FlowerAmount switch {
                    1 => 30331,
                    2 => 30332,
                    3 => 30333,
                    4 => 30334,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.East => FlowerAmount switch {
                    1 => 30335,
                    2 => 30336,
                    3 => 30337,
                    4 => 30338,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30323 => new WildflowersBlock(Identifier, Direction.North, 1),
            30324 => new WildflowersBlock(Identifier, Direction.North, 2),
            30325 => new WildflowersBlock(Identifier, Direction.North, 3),
            30326 => new WildflowersBlock(Identifier, Direction.North, 4),
            30327 => new WildflowersBlock(Identifier, Direction.South, 1),
            30328 => new WildflowersBlock(Identifier, Direction.South, 2),
            30329 => new WildflowersBlock(Identifier, Direction.South, 3),
            30330 => new WildflowersBlock(Identifier, Direction.South, 4),
            30331 => new WildflowersBlock(Identifier, Direction.West, 1),
            30332 => new WildflowersBlock(Identifier, Direction.West, 2),
            30333 => new WildflowersBlock(Identifier, Direction.West, 3),
            30334 => new WildflowersBlock(Identifier, Direction.West, 4),
            30335 => new WildflowersBlock(Identifier, Direction.East, 1),
            30336 => new WildflowersBlock(Identifier, Direction.East, 2),
            30337 => new WildflowersBlock(Identifier, Direction.East, 3),
            30338 => new WildflowersBlock(Identifier, Direction.East, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            FlowerAmount = properties.Contains("flower_amount") ? int.Parse(properties["flower_amount"].GetString()) : FlowerAmount,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("flower_amount", new StringTag(FlowerAmount.ToString()))
        );
    }
    
}
