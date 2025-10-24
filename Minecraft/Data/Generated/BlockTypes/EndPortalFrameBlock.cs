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
    public int ProtocolId => 391;
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
                    Direction.North => 9268,
                    Direction.South => 9269,
                    Direction.West => 9270,
                    Direction.East => 9271,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => 9272,
                    Direction.South => 9273,
                    Direction.West => 9274,
                    Direction.East => 9275,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9268 => new EndPortalFrameBlock(Identifier, true, Direction.North),
            9269 => new EndPortalFrameBlock(Identifier, true, Direction.South),
            9270 => new EndPortalFrameBlock(Identifier, true, Direction.West),
            9271 => new EndPortalFrameBlock(Identifier, true, Direction.East),
            9272 => new EndPortalFrameBlock(Identifier, false, Direction.North),
            9273 => new EndPortalFrameBlock(Identifier, false, Direction.South),
            9274 => new EndPortalFrameBlock(Identifier, false, Direction.West),
            9275 => new EndPortalFrameBlock(Identifier, false, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Eye = properties.ChildrenMap.ContainsKey("eye") ? properties["eye"].GetString() == "true" : Eye,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("eye", Eye.ToString().ToLower()),
            new StringTag("facing", Facing.ToName())
        );
    }
    
}
