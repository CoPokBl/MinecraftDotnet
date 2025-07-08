using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record EndPortalFrameBlock(Identifier Identifier, bool Eye, Direction Facing) : IBlock {

    public Identifier Category => "minecraft:end_portal_frame";
    public double Hardness => -1;
    public double ExplosionResistance => 3600000;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 1;
    public bool Replaceable => false;
    public string SoundType => "glass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:end_portal_frame";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.8125, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.8125, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.8125, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.8125, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 27;
    public string TranslationKey => "block.minecraft.end_portal_frame";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Eye switch {
                true => Facing switch {
                    Direction.North => 8191,
                    Direction.South => 8192,
                    Direction.West => 8193,
                    Direction.East => 8194,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => 8195,
                    Direction.South => 8196,
                    Direction.West => 8197,
                    Direction.East => 8198,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8191 => new EndPortalFrameBlock(Identifier, true, Direction.North),
            8192 => new EndPortalFrameBlock(Identifier, true, Direction.South),
            8193 => new EndPortalFrameBlock(Identifier, true, Direction.West),
            8194 => new EndPortalFrameBlock(Identifier, true, Direction.East),
            8195 => new EndPortalFrameBlock(Identifier, false, Direction.North),
            8196 => new EndPortalFrameBlock(Identifier, false, Direction.South),
            8197 => new EndPortalFrameBlock(Identifier, false, Direction.West),
            8198 => new EndPortalFrameBlock(Identifier, false, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Eye = properties["eye"].GetString() == "true",
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
