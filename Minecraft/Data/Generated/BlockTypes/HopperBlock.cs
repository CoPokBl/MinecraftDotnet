using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record HopperBlock(Identifier Identifier, bool Enabled, HopperBlock.Facing FacingValue) : IBlock {
    public Identifier Category => "minecraft:hopper";
    public int ProtocolId => 445;
    public double Hardness => 3;
    public double ExplosionResistance => 4.8;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "metal";
    public Identifier? BlockEntity => "minecraft:hopper";
    public Identifier? Item => "minecraft:hopper";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 0.6875, 0.625], AABB[0.25, 0.25, 0.25] -> [0.375, 0.6875, 0.75], AABB[0.375, 0.25, 0.25] -> [0.75, 0.6875, 0.375], AABB[0.375, 0.25, 0.625] -> [0.75, 0.6875, 0.75], AABB[0.625, 0.25, 0.375] -> [0.75, 0.6875, 0.625], AABB[0.0, 0.625, 0.0] -> [0.25, 0.6875, 1.0], AABB[0.25, 0.625, 0.0] -> [1.0, 0.6875, 0.25], AABB[0.25, 0.625, 0.75] -> [1.0, 0.6875, 1.0], AABB[0.75, 0.625, 0.25] -> [1.0, 0.6875, 0.75], AABB[0.0, 0.6875, 0.0] -> [0.125, 1.0, 1.0], AABB[0.125, 0.6875, 0.0] -> [1.0, 1.0, 0.125], AABB[0.125, 0.6875, 0.875] -> [1.0, 1.0, 1.0], AABB[0.875, 0.6875, 0.125] -> [1.0, 1.0, 0.875]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 0.6875, 0.625], AABB[0.25, 0.25, 0.25] -> [0.375, 0.6875, 0.75], AABB[0.375, 0.25, 0.25] -> [0.75, 0.6875, 0.375], AABB[0.375, 0.25, 0.625] -> [0.75, 0.6875, 0.75], AABB[0.625, 0.25, 0.375] -> [0.75, 0.6875, 0.625], AABB[0.0, 0.625, 0.0] -> [0.25, 0.6875, 1.0], AABB[0.25, 0.625, 0.0] -> [1.0, 0.6875, 0.25], AABB[0.25, 0.625, 0.75] -> [1.0, 0.6875, 1.0], AABB[0.75, 0.625, 0.25] -> [1.0, 0.6875, 0.75], AABB[0.0, 0.6875, 0.0] -> [0.125, 1.0, 1.0], AABB[0.125, 0.6875, 0.0] -> [1.0, 1.0, 0.125], AABB[0.125, 0.6875, 0.875] -> [1.0, 1.0, 1.0], AABB[0.875, 0.6875, 0.125] -> [1.0, 1.0, 0.875]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.125, 0.6875, 0.125] -> [0.875, 1.0, 0.875]]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 0.6875, 0.625], AABB[0.25, 0.25, 0.25] -> [0.375, 0.6875, 0.75], AABB[0.375, 0.25, 0.25] -> [0.75, 0.6875, 0.375], AABB[0.375, 0.25, 0.625] -> [0.75, 0.6875, 0.75], AABB[0.625, 0.25, 0.375] -> [0.75, 0.6875, 0.625], AABB[0.0, 0.625, 0.0] -> [0.25, 0.6875, 1.0], AABB[0.25, 0.625, 0.0] -> [1.0, 0.6875, 0.25], AABB[0.25, 0.625, 0.75] -> [1.0, 0.6875, 1.0], AABB[0.75, 0.625, 0.25] -> [1.0, 0.6875, 0.75], AABB[0.0, 0.6875, 0.0] -> [0.125, 1.0, 1.0], AABB[0.125, 0.6875, 0.0] -> [1.0, 1.0, 0.125], AABB[0.125, 0.6875, 0.875] -> [1.0, 1.0, 1.0], AABB[0.875, 0.6875, 0.125] -> [1.0, 1.0, 0.875]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.hopper";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Enabled switch {
                true => FacingValue switch {
                    Facing.Down => 10034,
                    Facing.North => 10035,
                    Facing.South => 10036,
                    Facing.West => 10037,
                    Facing.East => 10038,
                    _ => throw new ArgumentOutOfRangeException(nameof(FacingValue), FacingValue, "Unknown value for property facing.")
                },
                false => FacingValue switch {
                    Facing.Down => 10039,
                    Facing.North => 10040,
                    Facing.South => 10041,
                    Facing.West => 10042,
                    Facing.East => 10043,
                    _ => throw new ArgumentOutOfRangeException(nameof(FacingValue), FacingValue, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10034 => new HopperBlock(Identifier, true, Facing.Down),
            10035 => new HopperBlock(Identifier, true, Facing.North),
            10036 => new HopperBlock(Identifier, true, Facing.South),
            10037 => new HopperBlock(Identifier, true, Facing.West),
            10038 => new HopperBlock(Identifier, true, Facing.East),
            10039 => new HopperBlock(Identifier, false, Facing.Down),
            10040 => new HopperBlock(Identifier, false, Facing.North),
            10041 => new HopperBlock(Identifier, false, Facing.South),
            10042 => new HopperBlock(Identifier, false, Facing.West),
            10043 => new HopperBlock(Identifier, false, Facing.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Enabled = properties.ChildrenMap.ContainsKey("enabled") ? properties["enabled"].GetString() == "true" : Enabled,
            FacingValue = properties.ChildrenMap.ContainsKey("facing") ? FacingFromString(properties["facing"].GetString()) : FacingValue,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("enabled", Enabled.ToString().ToLower()),
            new StringTag("facing", FacingToName(FacingValue))
        );
    }
    
    public enum Facing {
        Down,
        North,
        South,
        West,
        East,
    }

    public static Facing FacingFromString(string value) {
        return value switch {
            "down" => Facing.Down,
            "north" => Facing.North,
            "south" => Facing.South,
            "west" => Facing.West,
            "east" => Facing.East,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Facing.")
        };
    }

    public static string FacingToName(Facing value) {
        return value switch {
            Facing.Down => "down",
            Facing.North => "north",
            Facing.South => "south",
            Facing.West => "west",
            Facing.East => "east",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Facing value.")
        };
    }
}
