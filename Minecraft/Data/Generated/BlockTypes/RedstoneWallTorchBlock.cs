using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedstoneWallTorchBlock(Identifier Identifier, Direction Facing, bool Lit) : IBlock {
    public Identifier Category => "minecraft:redstone_wall_torch";
    public int ProtocolId => 273;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 7;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:redstone_torch";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.34375, 0.1875, 0.6875] -> [0.65625, 0.8125, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.redstone_torch";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => 6686,
                    false => 6687,
                },
                Direction.South => Lit switch {
                    true => 6688,
                    false => 6689,
                },
                Direction.West => Lit switch {
                    true => 6690,
                    false => 6691,
                },
                Direction.East => Lit switch {
                    true => 6692,
                    false => 6693,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6686 => new RedstoneWallTorchBlock(Identifier, Direction.North, true),
            6687 => new RedstoneWallTorchBlock(Identifier, Direction.North, false),
            6688 => new RedstoneWallTorchBlock(Identifier, Direction.South, true),
            6689 => new RedstoneWallTorchBlock(Identifier, Direction.South, false),
            6690 => new RedstoneWallTorchBlock(Identifier, Direction.West, true),
            6691 => new RedstoneWallTorchBlock(Identifier, Direction.West, false),
            6692 => new RedstoneWallTorchBlock(Identifier, Direction.East, true),
            6693 => new RedstoneWallTorchBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Lit = properties.ChildrenMap.ContainsKey("lit") ? properties["lit"].GetString() == "true" : Lit,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("lit", Lit.ToString().ToLower())
        );
    }
    
}
