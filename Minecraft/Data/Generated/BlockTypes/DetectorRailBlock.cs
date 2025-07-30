using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DetectorRailBlock(Identifier Identifier, bool Powered, RailDirection Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:detector_rail";
    public int ProtocolId => 127;
    public double Hardness => 0.7;
    public double ExplosionResistance => 0.7;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "metal";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:detector_rail";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.detector_rail";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 2011,
                        false => 2012,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2013,
                        false => 2014,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2015,
                        false => 2016,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2017,
                        false => 2018,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2019,
                        false => 2020,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2021,
                        false => 2022,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 2023,
                        false => 2024,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2025,
                        false => 2026,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2027,
                        false => 2028,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2029,
                        false => 2030,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2031,
                        false => 2032,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2033,
                        false => 2034,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2011 => new DetectorRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            2012 => new DetectorRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            2013 => new DetectorRailBlock(Identifier, true, RailDirection.EastWest, true),
            2014 => new DetectorRailBlock(Identifier, true, RailDirection.EastWest, false),
            2015 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            2016 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            2017 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            2018 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            2019 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            2020 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            2021 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            2022 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            2023 => new DetectorRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            2024 => new DetectorRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            2025 => new DetectorRailBlock(Identifier, false, RailDirection.EastWest, true),
            2026 => new DetectorRailBlock(Identifier, false, RailDirection.EastWest, false),
            2027 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            2028 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            2029 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            2030 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            2031 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            2032 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            2033 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            2034 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties["powered"].GetString() == "true",
            Shape = RailDirectionExtensions.FromString(properties["shape"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("shape", Shape.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
