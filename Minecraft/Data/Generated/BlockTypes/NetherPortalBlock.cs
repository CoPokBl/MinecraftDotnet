using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record NetherPortalBlock(Identifier Identifier, NetherPortalBlock.Axis AxisValue) : IBlock {

    public double Hardness => -1;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 11;
    public bool Replaceable => false;
    public string SoundType => "glass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => null;
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Block;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.nether_portal";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return AxisValue switch {
                Axis.X => 6043,
                Axis.Z => 6044,
                _ => throw new ArgumentOutOfRangeException(nameof(AxisValue), AxisValue, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6043 => new NetherPortalBlock(Identifier, Axis.X),
            6044 => new NetherPortalBlock(Identifier, Axis.Z),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            AxisValue = AxisFromString(properties["axis"].GetString()),
        };
    }
    
    public enum Axis {
        X,
        Z,
    }

    public static Axis AxisFromString(string value) {
        return value switch {
            "x" => Axis.X,
            "z" => Axis.Z,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Axis.")
        };
    }
}
